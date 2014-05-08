using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Data.Common;
using System.Threading;
using SQLiteBase;
using CTP_FUNCTION;
using CTP;

namespace CTP_TRADER
{
    public partial class MainForm : Form
    {
        #region 全局变量定义处
        //交易前置交易地址
        public string sTDAddress = "";
        //行情前置交易地址
        public string sMDAddress = "";
        //经纪公司代码
        public string sBrokerID = "";
        //投资者代码
        public string sUserID = "";
        //用户密码
        public string sPassword = "";
        //行情接口
        CTPMDAdapter CtpMDApi = null;
        //交易接口
        CTPTDAdapter CtpTDApi = null;
        //行情接口API
        CTPMDAPI sCtpMdApi;
        //交易接口API
        CTPTDAPI sCtpTdApi;
        //交易日期
        string sTradingDay = string.Empty;
        //内存表名
        string sTableName = string.Empty;
        //主线程队列
        List<QueueSendData> List_QueueSend = new List<QueueSendData>();
        //主线程队列信号
        AutoResetEvent AutoSign_QueueSend = new AutoResetEvent(false);
        public AutoResetEvent SignMainQueueSend
        {
            get { return AutoSign_QueueSend; }
            set { AutoSign_QueueSend = value; }
        }
        //线程发送队列
        List<PolicyDataQueue> PolicyDataQueueList = new List<PolicyDataQueue>();

        string sDeepRspTableSql = "CREATE TABLE {0}" +
                        "(TRADINGDAY VARCHAR2(200),INSTRUMENTID VARCHAR2(200)," +
                        "EXCHANGEID VARCHAR2(200),EXCHANGEINSTID VARCHAR2(200),LASTPRICE DOUBLE," +
                        "PRESETTLEMENTPRICE DOUBLE,PRECLOSEPRICE DOUBLE,PREOPENINTEREST DOUBLE," +
                        "OPENPRICE DOUBLE,HIGHESTPRICE DOUBLE,LOWESTPRICE DOUBLE,VOLUME INT," +
                        "TURNOVER DOUBLE,OPENINTEREST DOUBLE,CLOSEPRICE DOUBLE,SETTLEMENTPRICE DOUBLE," +
                        "UPPERLIMITPRICE DOUBLE,LOWERLIMITPRICE DOUBLE,PREDELTA DOUBLE,CURRDELTA DOUBLE," +
                        "UPDATETIME VARCHAR2(200),UPDATEMILLISEC INT," +
                        "AskPrice1 DOUBLE,AskVolume1 INT,BidPrice1 DOUBLE,BidVolume1 INT," +
                        "AskPrice2 DOUBLE,AskVolume2 INT,BidPrice2 DOUBLE,BidVolume2 INT," +
                        "AskPrice3 DOUBLE,AskVolume3 INT,BidPrice3 DOUBLE,BidVolume3 INT," +
                        "AskPrice4 DOUBLE,AskVolume4 INT,BidPrice4 DOUBLE,BidVolume4 INT," +
                        "AskPrice5 DOUBLE,AskVolume5 INT,BidPrice5 DOUBLE,BidVolume5 INT," +
                        "AVERAGEPRICE DOUBLE,ACTIONDAY VARCHAR2(200))";

        //内存数据存储数据初始化
        SQLiteBase.SQLiteBase MemDB;
        public int iResult = 0;
        public int nRequestID = 0;
        //报单引用ID
        public int iOrderRefID = 0;
        //前置编号
        public int iFrontID;
        //会话编号
        public int iSessionID;
        //品种数组
        string[] sInstrument = new string[10000];
        //行情接口->深度行情回馈信息表
        public DataTable DT_DeepInstrumentRSP = new DataTable();
        //交易接口->所有交易品种回馈信息表
        public DataTable DT_Instrument = new DataTable();
        //交易接口->报单回馈信息表
        public DataTable DT_RtnOrder = new DataTable();
        //交易接口->持仓回馈明细表
        public DataTable DT_InvestorPositionDetail = new DataTable();

        // 这里加入需要队列的程序
        //SQLite 入库线程
        PolicyDataQueue Queue_SQLite = new PolicyDataQueue("SQLite");
        PolicyDataQueue Queue_PolicySample = new PolicyDataQueue("PolicySample");
        #endregion

        #region 主窗体构造,创建及一些参数的初始化

        /// <summary>
        /// 主窗体构造
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  SQLite数据库配置的读取和初始化
        /// </summary>
        private void InitConfig()
        {
            SQLiteBase.SQLiteBase SQLiteCtl = new SQLiteBase.SQLiteBase("ConfigDB.db");
            string sSql = string.Empty;
            SQLiteCtl.OpenDB();
            if (!SQLiteCtl.existTable("CTP_LOGIN_INFO"))
            {
                sSql = "CREATE TABLE CTP_LOGIN_INFO " +
                           "(ID INT,TDADDR VARCHAR(200),MDADDR VARCHAR(200),BROKER_ID VARCHAR(20),USER_ID VARCHAR(20),PASSWD VARCHAR(20),DB_TYPE INT,PRIMARY KEY (ID))";
                SQLiteCtl.setSQL(sSql);
                SQLiteCtl.Execute();
                sSql = "INSERT INTO CTP_LOGIN_INFO SELECT 1, 'tcp://ctpmn1-front1.citicsf.com:51205','tcp://ctpmn1-front1.citicsf.com:51213','1017','00000054','123456','0'";
                SQLiteCtl.setSQL(sSql);
                SQLiteCtl.Execute();
                SQLiteCtl.Commit();
                MessageBox.Show("CTP_LOGIN_INFO数据库初始化成功!");
            }

            sSql = "SELECT * FROM CTP_LOGIN_INFO";
            SQLiteCtl.setSQL(sSql);
            SQLiteCtl.OpenSQL();
            if (SQLiteCtl.Next())
            {
                TextBox_TDADDRESS.Text = SQLiteCtl.filed["TDADDR"].ToString();
                TextBox_MDADDRESS.Text = SQLiteCtl.filed["MDADDR"].ToString();
                TextBox_BrokerID.Text = SQLiteCtl.filed["BROKER_ID"].ToString();
                TextBox_UserID.Text = SQLiteCtl.filed["USER_ID"].ToString();
                TextBox_PassWord.Text = SQLiteCtl.filed["PASSWD"].ToString();
                if (SQLiteCtl.filed["DB_TYPE"].ToString() == "0")
                {
                    this.radioButton_MemDB.Checked = true;
                    this.radioButton_FileDB.Checked = false;
                }
                else
                {
                    this.radioButton_MemDB.Checked = false;
                    this.radioButton_FileDB.Checked = true;
                }

            }
            SQLiteCtl.CloseDB();
        }


        private void sqlitedb(object s)
        {
            MainForm cMainForm = (MainForm)s;
            ThostFtdcDepthMarketDataField pDepthMarketData = new ThostFtdcDepthMarketDataField();
            QueueSendData Data = new QueueSendData();
            bool bCommit=false;
            while (Queue_SQLite.bUse)
            {
                if (Queue_SQLite.DataQ.Count == 0)
                {
                    Queue_SQLite.Are.WaitOne();
                    Queue_SQLite.Are.Reset();
                    if(bCommit)
                        MemDB.Commit();
                }
                else
                {
                    Data = Queue_SQLite.DataQ.Dequeue();
                    Queue_SQLite.m_lReceiveNum++;
                    #region 这里写策略
                    switch (Data.QueueType)
                    {
                        case EnumQueueType.DepthMarketData:
                            pDepthMarketData = (ThostFtdcDepthMarketDataField)Data.QueueData;
                            if (pDepthMarketData.TradingDay == "" || pDepthMarketData.InstrumentID == "")
                            {
                                Queue_SQLite.m_lDropNum++;
                                Queue_SQLite.Are.Reset();
                            }
                            #region 数据入内存数据库
                            if (sTradingDay != pDepthMarketData.TradingDay || sTableName == string.Empty)
                            {
                                sTableName = "TIP_" + pDepthMarketData.TradingDay;
                                sTradingDay = pDepthMarketData.TradingDay;
                                if (!MemDB.existTable(sTableName))
                                {
                                    string vSQL = string.Format(sDeepRspTableSql, sTableName);
                                    MemDB.setSQL(vSQL);
                                    MemDB.Execute();
                                    MemDB.Commit();
                                }
                            }
                            string sSql = "insert into " + sTableName + "(ActionDay,BidPrice1,BidPrice2,BidPrice3,BidPrice4,BidPrice5,BidVolume1,BidVolume2,BidVolume3,BidVolume4,BidVolume5,AveragePrice,AskPrice1,AskPrice2,AskPrice3,AskPrice4,AskPrice5,AskVolume1,AskVolume2,AskVolume3,AskVolume4,AskVolume5,ClosePrice,CurrDelta,ExchangeID,ExchangeInstID,HighestPrice,InstrumentID,LastPrice,LowerLimitPrice,LowestPrice,OpenInterest,OpenPrice,PreClosePrice,PreDelta,PreOpenInterest,PreSettlementPrice,SettlementPrice,TradingDay,Turnover,UpdateMillisec,UpdateTime,UpperLimitPrice,Volume) values ('"
                                + pDepthMarketData.ActionDay + "','" + pDepthMarketData.BidPrice1 + "','"
                                + pDepthMarketData.BidPrice2 + "','" + pDepthMarketData.BidPrice3 + "','" + pDepthMarketData.BidPrice4 + "','" + pDepthMarketData.BidPrice5 + "','"
                                + pDepthMarketData.BidVolume1 + "','" + pDepthMarketData.BidVolume2 + "','" + pDepthMarketData.BidVolume3 + "','" + pDepthMarketData.BidVolume4 + "','"
                                + pDepthMarketData.BidVolume5 + "','" + pDepthMarketData.AveragePrice + "','" + pDepthMarketData.AskPrice1 + "','" + pDepthMarketData.AskPrice2 + "','"
                                + pDepthMarketData.AskPrice3 + "','" + pDepthMarketData.AskPrice4 + "','" + pDepthMarketData.AskPrice5 + "','" + pDepthMarketData.AskVolume1 + "','"
                                + pDepthMarketData.AskVolume2 + "','" + pDepthMarketData.AskVolume3 + "','" + pDepthMarketData.AskVolume4 + "','" + pDepthMarketData.AskVolume5 + "','"
                                + pDepthMarketData.ClosePrice + "','" + pDepthMarketData.CurrDelta + "','" + pDepthMarketData.ExchangeID + "','"
                                + pDepthMarketData.ExchangeInstID + "','" + pDepthMarketData.HighestPrice + "','" + pDepthMarketData.InstrumentID + "','"
                                + pDepthMarketData.LastPrice + "','" + pDepthMarketData.LowerLimitPrice + "','" + pDepthMarketData.LowestPrice + "','"
                                + pDepthMarketData.OpenInterest + "','" + pDepthMarketData.OpenPrice + "','" + pDepthMarketData.PreClosePrice + "','"
                                + pDepthMarketData.PreDelta + "','" + pDepthMarketData.PreOpenInterest + "','" + pDepthMarketData.PreSettlementPrice + "','"
                                + pDepthMarketData.SettlementPrice + "','" + pDepthMarketData.TradingDay + "','" + pDepthMarketData.Turnover + "','"
                                + pDepthMarketData.UpdateMillisec + "','" + pDepthMarketData.UpdateTime + "','" + pDepthMarketData.UpperLimitPrice + "','" + pDepthMarketData.Volume + "')";
                            MemDB.setSQL(sSql);
                            MemDB.Execute();
                            bCommit = true;
                            Queue_SQLite.m_lRunNum++;
                            #endregion
                            break;
                        case EnumQueueType.OnRtnOrder:
                            break;
                        case EnumQueueType.StopSign0:
                            Queue_PolicySample.bUse = false;
                            return;
                        default:
                            break;
                    }
                }
                #endregion

            }
        }

        /// <summary>
        /// 主窗体创建的时候相应动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            #region API初始化
            CtpMDApi = new CTPMDAdapter();
            CtpTDApi = new CTPTDAdapter();
            sCtpMdApi = new CTPMDAPI(this);
            sCtpTdApi = new CTPTDAPI(this);
            #endregion

            #region 登录数据库初始化
            this.InitConfig();
            #endregion

            #region 消息队列初始化
            Thread td_SendData = new Thread(SendData);
            td_SendData.IsBackground = true;
            td_SendData.Start();
            #endregion 消息队列初始化

            #region SQLite 入库线程启动
            Queue_SQLite.bUse = true;
            Queue_SQLite.t = new Thread(sqlitedb);
            Queue_SQLite.t.IsBackground = true;
            Queue_SQLite.t.Start(this);

            #endregion SQLite 入库线程启动

            #region GridView深度行情
            string[] columnNames = 
            { "品种名称", "交易日", "自然日", "时间", "毫秒", "最新价", "上次结算价", "昨收盘",
              "昨持仓", "开盘价", "最高价", "最低价", "数量", "成交金额", "持仓量", "收盘价", "结算价",
              "涨停板价", "跌停板价", "昨虚实度", "虚实度",
              "叫卖价", "叫卖量", "叫买价", "叫买量",
              "叫卖价2", "叫卖量2", "叫买价2", "叫买量2",
              "叫卖价3", "叫卖量3", "叫买价3", "叫买量3",
              "叫卖价4", "叫卖量4", "叫买价4", "叫买量4",
              "叫卖价5", "叫卖量5", "叫买价5", "叫买量5",
              "当日均价"};
            foreach (string n in columnNames)
            {
                DT_DeepInstrumentRSP.Columns.Add(n, typeof(String));
            }
            //建立主键
            DataColumn[] cols = new DataColumn[] { DT_DeepInstrumentRSP.Columns["品种名称"] };
            this.DT_DeepInstrumentRSP.PrimaryKey = cols;
            this.GridView_DeepInstrument.DataSource = this.DT_DeepInstrumentRSP;
            this.GridView_DeepInstrument.Columns["昨虚实度"].Visible = false;
            this.GridView_DeepInstrument.Columns["交易日"].Visible = false;
            this.GridView_DeepInstrument.Columns["最高价"].Visible = false;
            this.GridView_DeepInstrument.Columns["最低价"].Visible = false;
            this.GridView_DeepInstrument.Columns["开盘价"].Visible = false;
            this.GridView_DeepInstrument.Columns["虚实度"].Visible = false;
            this.GridView_DeepInstrument.Columns["结算价"].Visible = false;
            this.GridView_DeepInstrument.Columns["自然日"].Visible = false;
            this.GridView_DeepInstrument.Columns["上次结算价"].Visible = false;
            this.GridView_DeepInstrument.Columns["昨收盘"].Visible = false;
            this.GridView_DeepInstrument.Columns["昨持仓"].Visible = false;
            this.GridView_DeepInstrument.Columns["收盘价"].Visible = false;
            this.GridView_DeepInstrument.Columns["涨停板价"].Visible = false;
            this.GridView_DeepInstrument.Columns["跌停板价"].Visible = false;
            this.GridView_DeepInstrument.Columns["当日均价"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫卖价2"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫卖价3"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫卖价4"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫卖价5"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫卖量2"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫卖量3"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫卖量4"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫卖量5"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫买价2"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫买价3"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫买价4"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫买价5"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫买量2"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫买量3"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫买量4"].Visible = false;
            this.GridView_DeepInstrument.Columns["叫买量5"].Visible = false;
            #endregion

            #region GridView可供订阅的品种
            string[] columnNames1 = { "品种名称", "合约名称", "中文名", "交易所ID" };
            foreach (string n in columnNames1)
            {
                DT_Instrument.Columns.Add(n, typeof(String));
            }
            //建立主键
            this.DT_Instrument.PrimaryKey = new DataColumn[] { DT_Instrument.Columns["品种名称"] };
            this.GridView_RegistInstrument_Data.DataSource = this.DT_Instrument;
            this.GridView_RegistInstrument_Data.Columns["合约名称"].Visible = false;
            this.GridView_RegistInstrument_Data.Columns["交易所ID"].Visible = false;
            #endregion

            #region Gridview报单通知
            string[] columnNames2 = { "报单引用", "会话标识", "前置机标识", "报单编号", "交易所", "品种名称", "买卖", "开平", "投机标志", "价格", "报单量", "今成交", "剩余量", "报单日期", "报单时间", "报单状态", "状态信息", "备注" };
            foreach (string n in columnNames2)
            {
                this.DT_RtnOrder.Columns.Add(n, typeof(String));
            }
            //建立主键
            this.DT_RtnOrder.PrimaryKey = new DataColumn[] { DT_RtnOrder.Columns["报单引用"], DT_RtnOrder.Columns["会话标识"], DT_RtnOrder.Columns["前置机标识"] };
            this.GridView_RtnOrder.DataSource = DT_RtnOrder;
            this.GridView_RtnOrder.Columns["会话标识"].Visible = false;
            this.GridView_RtnOrder.Columns["报单编号"].Visible = false;
            this.GridView_RtnOrder.Columns["报单引用"].Visible = false;
            this.GridView_RtnOrder.Columns["前置机标识"].Visible = false;
            this.GridView_RtnOrder.Columns["报单状态"].Visible = false;
            this.GridView_RtnOrder.Columns["交易所"].Visible = false;
            #endregion

            #region GridView持仓查询通知
            string[] columnNames3 = { "合约代码", "开仓日期", "交易日", "持仓类型", "买卖", "数量", "开仓价", "投机标志", "成交编号", "结算编号", "成交类型", "昨结算价", "结算价", "平仓量", "平仓金额" };
            foreach (string n in columnNames3)
            {
                this.DT_InvestorPositionDetail.Columns.Add(n, typeof(String));
            }
            //建立主键
            //this.sDT_InvestorPositionDetail.PrimaryKey = new DataColumn[] { sDT_InvestorPositionDetail.Columns["合约代码"] };

            this.GridView_InvestorPositionDetail.DataSource = DT_InvestorPositionDetail;
            this.GridView_InvestorPositionDetail.Columns["结算编号"].Visible = false;
            this.GridView_InvestorPositionDetail.Columns["开仓日期"].Visible = false;
            this.GridView_InvestorPositionDetail.Columns["交易日"].Visible = false;
            this.GridView_InvestorPositionDetail.Columns["平仓量"].Visible = false;
            this.GridView_InvestorPositionDetail.Columns["平仓金额"].Visible = false;
            this.GridView_InvestorPositionDetail.Columns["成交编号"].Visible = false;
            #endregion

        }

        /// <summary>
        /// 窗口关闭前的动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Closeing(object sender, FormClosingEventArgs e)
        {
            const string message = "退出程序吗?\n如果使用内存数据库模式,内存数据将丢失!";
            const string caption = "确认关闭";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        #endregion 主窗体构造

        #region 交易&行情API
        /// <summary>
        /// 交易API实现类
        /// </summary>
        class CTPTDAPI
        {
            MainForm cMainForm = new MainForm();
            public CTPTDAPI(MainForm cMF)
            {
                cMainForm = cMF;
            }

            ///当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
            public void OnFrontConnected()
            {
                cMainForm.SetTDConnState((object)"已连接");
            }

            ///当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
            ///@param nReason 错误原因
            ///        0x1001 网络读失败
            ///        0x1002 网络写失败
            ///        0x2001 接收心跳超时
            ///        0x2002 发送心跳失败
            ///        0x2003 收到错误报文
            public void OnFrontDisconnected(int nReason)
            {
                cMainForm.SetTDConnState((object)"已断开");
            }

            ///心跳超时警告。当长时间未收到报文时，该方法被调用。
            ///@param nTimeLapse 距离上次接收报文的时间
            public void OnHeartBeatWarning(int nTimeLapse)
            {
            }

            ///客户端认证响应
            public void OnRspAuthenticate(ThostFtdcRspAuthenticateField pRspAuthenticateField, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///登录请求响应
            public void OnRspUserLogin(ThostFtdcRspUserLoginField pRspUserLogin, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                    cMainForm.SetTDLoginState((object)"已连接");
                    cMainForm.iOrderRefID = Int32.Parse(pRspUserLogin.MaxOrderRef);
                    cMainForm.iSessionID = pRspUserLogin.SessionID;
                    cMainForm.iFrontID = pRspUserLogin.FrontID;
                }
            }

            ///登出请求响应
            public void OnRspUserLogout(ThostFtdcUserLogoutField pUserLogout, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///用户口令更新请求响应
            public void OnRspUserPasswordUpdate(ThostFtdcUserPasswordUpdateField pUserPasswordUpdate, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///资金账户口令更新请求响应
            public void OnRspTradingAccountPasswordUpdate(ThostFtdcTradingAccountPasswordUpdateField pTradingAccountPasswordUpdate, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///报单录入请求响应
            public void OnRspOrderInsert(ThostFtdcInputOrderField pInputOrder, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///预埋单录入请求响应
            public void OnRspParkedOrderInsert(ThostFtdcParkedOrderField pParkedOrder, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///预埋撤单录入请求响应
            public void OnRspParkedOrderAction(ThostFtdcParkedOrderActionField pParkedOrderAction, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///报单操作请求响应
            public void OnRspOrderAction(ThostFtdcInputOrderActionField pInputOrderAction, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///查询最大报单数量响应
            public void OnRspQueryMaxOrderVolume(ThostFtdcQueryMaxOrderVolumeField pQueryMaxOrderVolume, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///投资者结算结果确认响应
            public void OnRspSettlementInfoConfirm(ThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///删除预埋单响应
            public void OnRspRemoveParkedOrder(ThostFtdcRemoveParkedOrderField pRemoveParkedOrder, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///删除预埋撤单响应
            public void OnRspRemoveParkedOrderAction(ThostFtdcRemoveParkedOrderActionField pRemoveParkedOrderAction, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询报单响应
            public void OnRspQryOrder(ThostFtdcOrderField pOrder, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询成交响应
            public void OnRspQryTrade(ThostFtdcTradeField pTrade, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询投资者持仓响应
            public void OnRspQryInvestorPosition(ThostFtdcInvestorPositionField pInvestorPosition, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo) && pInvestorPosition != null)
                {
                    cMainForm.SetTDRspQryInvestorPosition((object)pInvestorPosition);
                }
            }

            ///请求查询资金账户响应
            public void OnRspQryTradingAccount(ThostFtdcTradingAccountField pTradingAccount, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询投资者响应
            public void OnRspQryInvestor(ThostFtdcInvestorField pInvestor, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询交易编码响应
            public void OnRspQryTradingCode(ThostFtdcTradingCodeField pTradingCode, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询合约保证金率响应
            public void OnRspQryInstrumentMarginRate(ThostFtdcInstrumentMarginRateField pInstrumentMarginRate, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询合约手续费率响应
            public void OnRspQryInstrumentCommissionRate(ThostFtdcInstrumentCommissionRateField pInstrumentCommissionRate, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询交易所响应
            public void OnRspQryExchange(ThostFtdcExchangeField pExchange, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询合约响应
            public void OnRspQryInstrument(ThostFtdcInstrumentField pInstrument, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo) && pInstrument != null)
                {
                    if (pInstrument.ProductClass != EnumProductClassType.EFP)
                    {
                        cMainForm.SetTDRspQryInstrument((object)pInstrument);
                    }
                }
            }

            ///请求查询行情响应
            public void OnRspQryDepthMarketData(ThostFtdcDepthMarketDataField pDepthMarketData, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询投资者结算结果响应
            public void OnRspQrySettlementInfo(ThostFtdcSettlementInfoField pSettlementInfo, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询转帐银行响应
            public void OnRspQryTransferBank(ThostFtdcTransferBankField pTransferBank, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询投资者持仓明细响应
            public void OnRspQryInvestorPositionDetail(ThostFtdcInvestorPositionDetailField pInvestorPositionDetail, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo) && pInvestorPositionDetail != null)
                {
                    if (pInvestorPositionDetail.Volume != 0)
                    {
                        cMainForm.SetTDRspQryInvestorPositionDetail((object)pInvestorPositionDetail);
                    }
                }
            }

            ///请求查询客户通知响应
            public void OnRspQryNotice(ThostFtdcNoticeField pNotice, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询结算信息确认响应
            public void OnRspQrySettlementInfoConfirm(ThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询投资者持仓明细响应
            public void OnRspQryInvestorPositionCombineDetail(ThostFtdcInvestorPositionCombineDetailField pInvestorPositionCombineDetail, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///查询保证金监管系统经纪公司资金账户密钥响应
            public void OnRspQryCFMMCTradingAccountKey(ThostFtdcCFMMCTradingAccountKeyField pCFMMCTradingAccountKey, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询仓单折抵信息响应
            public void OnRspQryEWarrantOffset(ThostFtdcEWarrantOffsetField pEWarrantOffset, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询转帐流水响应
            public void OnRspQryTransferSerial(ThostFtdcTransferSerialField pTransferSerial, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询银期签约关系响应
            public void OnRspQryAccountregister(ThostFtdcAccountregisterField pAccountregister, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///错误应答
            public void OnRspError(ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///报单通知
            public void OnRtnOrder(ThostFtdcOrderField pOrder)
            {
                cMainForm.SetTDOnRtnOrder((object)pOrder);
            }

            ///成交通知
            public void OnRtnTrade(ThostFtdcTradeField pTrade)
            {
                cMainForm.SetTDOnRtnTrade((object)pTrade);
            }

            ///报单录入错误回报
            public void OnErrRtnOrderInsert(ThostFtdcInputOrderField pInputOrder, ThostFtdcRspInfoField pRspInfo)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///报单操作错误回报
            public void OnErrRtnOrderAction(ThostFtdcOrderActionField pOrderAction, ThostFtdcRspInfoField pRspInfo)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///合约交易状态通知
            public void OnRtnInstrumentStatus(ThostFtdcInstrumentStatusField pInstrumentStatus)
            {
            }

            ///交易通知
            public void OnRtnTradingNotice(ThostFtdcTradingNoticeInfoField pTradingNoticeInfo)
            {
            }

            ///提示条件单校验错误
            public void OnRtnErrorConditionalOrder(ThostFtdcErrorConditionalOrderField pErrorConditionalOrder)
            {
            }

            ///请求查询签约银行响应
            public void OnRspQryContractBank(ThostFtdcContractBankField pContractBank, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询预埋单响应
            public void OnRspQryParkedOrder(ThostFtdcParkedOrderField pParkedOrder, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询预埋撤单响应
            public void OnRspQryParkedOrderAction(ThostFtdcParkedOrderActionField pParkedOrderAction, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询交易通知响应
            public void OnRspQryTradingNotice(ThostFtdcTradingNoticeField pTradingNotice, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询经纪公司交易参数响应
            public void OnRspQryBrokerTradingParams(ThostFtdcBrokerTradingParamsField pBrokerTradingParams, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///请求查询经纪公司交易算法响应
            public void OnRspQryBrokerTradingAlgos(ThostFtdcBrokerTradingAlgosField pBrokerTradingAlgos, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///银行发起银行资金转期货通知
            public void OnRtnFromBankToFutureByBank(ThostFtdcRspTransferField pRspTransfer)
            {
            }

            ///银行发起期货资金转银行通知
            public void OnRtnFromFutureToBankByBank(ThostFtdcRspTransferField pRspTransfer)
            {
            }

            ///银行发起冲正银行转期货通知
            public void OnRtnRepealFromBankToFutureByBank(ThostFtdcRspRepealField pRspRepeal)
            {
            }

            ///银行发起冲正期货转银行通知
            public void OnRtnRepealFromFutureToBankByBank(ThostFtdcRspRepealField pRspRepeal)
            {
            }

            ///期货发起银行资金转期货通知
            public void OnRtnFromBankToFutureByFuture(ThostFtdcRspTransferField pRspTransfer)
            {
            }

            ///期货发起期货资金转银行通知
            public void OnRtnFromFutureToBankByFuture(ThostFtdcRspTransferField pRspTransfer)
            {
            }

            ///系统运行时期货端手工发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
            public void OnRtnRepealFromBankToFutureByFutureManual(ThostFtdcRspRepealField pRspRepeal)
            {
            }

            ///系统运行时期货端手工发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
            public void OnRtnRepealFromFutureToBankByFutureManual(ThostFtdcRspRepealField pRspRepeal)
            {
            }

            ///期货发起查询银行余额通知
            public void OnRtnQueryBankBalanceByFuture(ThostFtdcNotifyQueryAccountField pNotifyQueryAccount)
            {
            }

            ///期货发起银行资金转期货错误回报
            public void OnErrRtnBankToFutureByFuture(ThostFtdcReqTransferField pReqTransfer, ThostFtdcRspInfoField pRspInfo)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///期货发起期货资金转银行错误回报
            public void OnErrRtnFutureToBankByFuture(ThostFtdcReqTransferField pReqTransfer, ThostFtdcRspInfoField pRspInfo)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///系统运行时期货端手工发起冲正银行转期货错误回报
            public void OnErrRtnRepealBankToFutureByFutureManual(ThostFtdcReqRepealField pReqRepeal, ThostFtdcRspInfoField pRspInfo)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///系统运行时期货端手工发起冲正期货转银行错误回报
            public void OnErrRtnRepealFutureToBankByFutureManual(ThostFtdcReqRepealField pReqRepeal, ThostFtdcRspInfoField pRspInfo)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///期货发起查询银行余额错误回报
            public void OnErrRtnQueryBankBalanceByFuture(ThostFtdcReqQueryAccountField pReqQueryAccount, ThostFtdcRspInfoField pRspInfo)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///期货发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
            public void OnRtnRepealFromBankToFutureByFuture(ThostFtdcRspRepealField pRspRepeal)
            {
            }

            ///期货发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
            public void OnRtnRepealFromFutureToBankByFuture(ThostFtdcRspRepealField pRspRepeal)
            {
            }

            ///期货发起银行资金转期货应答
            public void OnRspFromBankToFutureByFuture(ThostFtdcReqTransferField pReqTransfer, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///期货发起期货资金转银行应答
            public void OnRspFromFutureToBankByFuture(ThostFtdcReqTransferField pReqTransfer, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///期货发起查询银行余额应答
            public void OnRspQueryBankAccountMoneyByFuture(ThostFtdcReqQueryAccountField pReqQueryAccount, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }

            ///银行发起银期开户通知
            public void OnRtnOpenAccountByBank(ThostFtdcOpenAccountField pOpenAccount)
            {
            }

            ///银行发起银期销户通知
            public void OnRtnCancelAccountByBank(ThostFtdcCancelAccountField pCancelAccount)
            {
            }

            ///银行发起变更银行账号通知
            public void OnRtnChangeAccountByBank(ThostFtdcChangeAccountField pChangeAccount)
            {
            }

            bool IsErrorRspInfo(ThostFtdcRspInfoField pRspInfo)
            {
                // 如果ErrorID != 0, 说明收到了错误的响应
                bool bResult = ((pRspInfo != null) && (pRspInfo.ErrorID != 0));
                if (bResult)
                    cMainForm.SetTDErrorRspInfo((object)pRspInfo);
                return bResult;
            }
        }

        /// <summary>
        /// 行情API实现类
        /// </summary>
        class CTPMDAPI
        {
            MainForm cMainForm = new MainForm();
            public CTPMDAPI(MainForm cMF)
            {
                cMainForm = cMF;
            }
            public void OnRspUserLogout(ThostFtdcUserLogoutField pUserLogout, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
            }
            public void OnRspUserLogin(ThostFtdcRspUserLoginField pRspUserLogin, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                    cMainForm.SetMDLoginState((object)"已连接");
                }
            }
            public void OnRspUnSubMarketData(ThostFtdcSpecificInstrumentField pSpecificInstrument, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
            }
            public void OnRspSubMarketData(ThostFtdcSpecificInstrumentField pSpecificInstrument, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }
            public void OnRspError(ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
            {
                if (!IsErrorRspInfo(pRspInfo))
                {
                }
            }
            public void OnHeartBeatWarning(int nTimeLapse)
            {
            }
            public void OnFrontDisconnected(int nReason)
            {
                cMainForm.SetMDConnState((object)"已断开");
            }
            public void OnFrontConnected()
            {
                cMainForm.SetMDConnState((object)"已连接");
            }
            bool IsErrorRspInfo(ThostFtdcRspInfoField pRspInfo)
            {
                // 如果ErrorID != 0, 说明收到了错误的响应
                bool bResult = ((pRspInfo != null) && (pRspInfo.ErrorID != 0));
                if (bResult)
                    cMainForm.SetTDErrorRspInfo((object)pRspInfo);
                return bResult;
            }
            public void OnRtnDepthMarketData(ThostFtdcDepthMarketDataField pDepthMarketData)
            {
                cMainForm.SetMDDepthMarketData((object)pDepthMarketData);
            }
        }
        #endregion 接口调用主要内容

        #region 回调接口,由CTP线程修改主窗体

        /// <summary>
        /// 委托方法,由线程访问主程序
        /// </summary>
        /// <param name="obj"></param>
        delegate void SetCallback(object obj);
        /// <summary>
        /// 行情接口->获取深度行情
        /// </summary>
        /// <param name="s">行情结构体,需强转</param>
        private void SetMDDepthMarketData(object s)
        {
            if (this.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetMDDepthMarketData);
                this.BeginInvoke(d, new object[] { s });
            }
            else
            {
                ThostFtdcDepthMarketDataField pDepthMarketData = (ThostFtdcDepthMarketDataField)s;
                QueueSendData sQueueSend = new QueueSendData();
                sQueueSend.QueueType = EnumQueueType.DepthMarketData;
                sQueueSend.QueueData = s;
                List_QueueSend.Add(sQueueSend);
                SignMainQueueSend.Set();

                DataRow DR_Find = this.DT_DeepInstrumentRSP.Rows.Find(pDepthMarketData.InstrumentID);
                DataRow dr = this.DT_DeepInstrumentRSP.NewRow();
                #region 实时行情更新赋值
                dr["叫买价"] = (pDepthMarketData.BidPrice1 != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.BidPrice1, 2).ToString() : null;
                dr["叫买价2"] = (pDepthMarketData.BidPrice2 != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.BidPrice2, 2).ToString() : null;
                dr["叫买价3"] = (pDepthMarketData.BidPrice3 != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.BidPrice3, 2).ToString() : null;
                dr["叫买价4"] = (pDepthMarketData.BidPrice4 != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.BidPrice4, 2).ToString() : null;
                dr["叫买价5"] = (pDepthMarketData.BidPrice5 != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.BidPrice5, 2).ToString() : null;
                dr["叫买量"] = pDepthMarketData.BidVolume1.ToString();
                dr["叫买量2"] = pDepthMarketData.BidVolume2.ToString();
                dr["叫买量3"] = pDepthMarketData.BidVolume3.ToString();
                dr["叫买量4"] = pDepthMarketData.BidVolume4.ToString();
                dr["叫买量5"] = pDepthMarketData.BidVolume5.ToString();
                dr["当日均价"] = (pDepthMarketData.AveragePrice != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.AveragePrice, 2).ToString() : null;
                dr["叫卖价"] = (pDepthMarketData.AskPrice1 != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.AskPrice1, 2).ToString() : null;
                dr["叫卖价2"] = (pDepthMarketData.AskPrice2 != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.AskPrice2, 2).ToString() : null;
                dr["叫卖价3"] = (pDepthMarketData.AskPrice3 != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.AskPrice3, 2).ToString() : null;
                dr["叫卖价4"] = (pDepthMarketData.AskPrice4 != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.AskPrice4, 2).ToString() : null;
                dr["叫卖价5"] = (pDepthMarketData.AskPrice5 != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.AskPrice5, 2).ToString() : null;
                dr["叫卖量"] = pDepthMarketData.AskVolume1.ToString();
                dr["叫卖量2"] = pDepthMarketData.AskVolume2.ToString();
                dr["叫卖量3"] = pDepthMarketData.AskVolume3.ToString();
                dr["叫卖量4"] = pDepthMarketData.AskVolume4.ToString();
                dr["叫卖量5"] = pDepthMarketData.AskVolume5.ToString();
                dr["收盘价"] = (pDepthMarketData.ClosePrice != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.ClosePrice, 2).ToString() : null;
                dr["虚实度"] = (pDepthMarketData.CurrDelta != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.CurrDelta, 2).ToString() : null;
                dr["最高价"] = (pDepthMarketData.HighestPrice != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.HighestPrice, 2).ToString() : null;
                dr["最新价"] = (pDepthMarketData.LastPrice != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.LastPrice, 2).ToString() : null;
                dr["跌停板价"] =
                    (pDepthMarketData.LowerLimitPrice != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.LowerLimitPrice, 2).ToString() : null;
                dr["最低价"] = (pDepthMarketData.LowestPrice != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.LowestPrice, 2).ToString() : null;
                dr["持仓量"] = (pDepthMarketData.OpenInterest != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.OpenInterest, 2).ToString() : null;
                dr["开盘价"] = (pDepthMarketData.OpenPrice != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.OpenPrice, 2).ToString() : null;
                dr["昨收盘"] =
                    (pDepthMarketData.PreClosePrice != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.PreClosePrice, 2).ToString() : null;
                dr["昨虚实度"] = (pDepthMarketData.PreDelta != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.PreDelta, 2).ToString() : null;
                dr["昨持仓"] =
                    (pDepthMarketData.PreOpenInterest != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.PreOpenInterest, 2).ToString() : null;
                dr["上次结算价"] =
                    (pDepthMarketData.PreSettlementPrice != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.PreSettlementPrice, 2).ToString() : null;
                dr["结算价"] =
                    (pDepthMarketData.SettlementPrice != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.SettlementPrice, 2).ToString() : null;
                dr["成交金额"] = (pDepthMarketData.Turnover != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.Turnover, 2).ToString() : null;
                dr["毫秒"] = pDepthMarketData.UpdateMillisec.ToString();
                dr["时间"] = pDepthMarketData.UpdateTime.ToString();
                dr["涨停板价"] =
                    (pDepthMarketData.UpperLimitPrice != Double.MaxValue) ? Function.GetRoundNum(pDepthMarketData.UpperLimitPrice, 2).ToString() : null;
                dr["数量"] = pDepthMarketData.Volume.ToString();
                dr["交易日"] = pDepthMarketData.TradingDay.ToString();
                dr["品种名称"] = pDepthMarketData.InstrumentID;
                dr["自然日"] = pDepthMarketData.ActionDay.ToString();
                #endregion
                if (DR_Find != null)
                {
                    DR_Find.ItemArray = dr.ItemArray;
                }
                else
                {
                    this.DT_DeepInstrumentRSP.Rows.Add(dr);
                }
            }
        }
        /// <summary>
        /// 交易接口->获取所有正在交易的合约
        /// </summary>
        /// <param name="s"></param>
        private void SetTDRspQryInstrument(object s)
        {
            if (this.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetTDRspQryInstrument);
                this.BeginInvoke(d, new object[] { s });
            }
            else
            {
                ThostFtdcInstrumentField pInstrument = (ThostFtdcInstrumentField)s;
                DataRow dr = this.DT_Instrument.Rows.Find(pInstrument.InstrumentID);
                if (dr == null)
                {
                    dr = this.DT_Instrument.NewRow();
                    dr["品种名称"] = pInstrument.InstrumentID;
                    dr[1] = pInstrument.ProductID;
                    dr[2] = pInstrument.InstrumentName;
                    dr[3] = pInstrument.ExchangeID;
                    this.DT_Instrument.Rows.Add(dr);
                }
                if (!this.comboBox_ProductID.Items.Contains(pInstrument.ProductID))
                {
                    this.comboBox_ProductID.Items.Add(pInstrument.ProductID);
                }
            }
        }
        /// <summary>
        /// 交易接口->成交通知
        /// </summary>
        /// <param name="s"></param>
        private void SetTDOnRtnTrade(object s)
        {
            if (this.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetTDOnRtnTrade);
                this.BeginInvoke(d, new object[] { s });
            }
            else
            {
                DT_InvestorPositionDetail.Clear();
                this.TDReqQryInvestorPositionDetail(false);
                GridView_InvestorPositionDetail.DataSource = DT_InvestorPositionDetail;
            }
        }
        /// <summary>
        /// 交易接口->获得报单回馈信息
        /// </summary>
        /// <param name="s"></param>
        private void SetTDOnRtnOrder(object s)
        {
            if (this.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetTDOnRtnOrder);
                this.BeginInvoke(d, new object[] { s });
            }
            else
            {
                ThostFtdcOrderField pOrder = (ThostFtdcOrderField)s;

                object[] objs = new object[] { pOrder.OrderRef, pOrder.SessionID, pOrder.FrontID };
                DataRow DR_Find = this.DT_RtnOrder.Rows.Find(objs);
                DataRow dr = this.DT_RtnOrder.NewRow();

                #region 报单回馈赋值更新
                //{ "报单引用", "会话标识", "前置机标识", "报单编号","交易所","品种名称", "买卖", "开平", "投机标志", "价格", "报单量", "今成交", "剩余量", "报单日期", "报单时间", "报单状态", "状态信息", "备注" };
                dr["报单引用"] = pOrder.OrderRef.ToString();
                dr["会话标识"] = pOrder.SessionID.ToString();
                dr["前置机标识"] = pOrder.FrontID.ToString();
                dr["报单编号"] = pOrder.OrderSysID.ToString();
                dr["品种名称"] = pOrder.InstrumentID.ToString();
                dr["交易所"] = pOrder.ExchangeID.ToString();
                dr["买卖"] = (pOrder.Direction == EnumDirectionType.Buy) ? "买  " : "  卖";
                switch (pOrder.CombOffsetFlag)
                {
                    case EnumOffsetFlagType.Close:
                    case EnumOffsetFlagType.CloseToday:
                    case EnumOffsetFlagType.CloseYesterday:
                        dr["开平"] = "  平";
                        break;
                    case EnumOffsetFlagType.Open:
                        dr["开平"] = "开";
                        break;
                    default:
                        dr["开平"] = pOrder.CombOffsetFlag.ToString();
                        break;
                }
                switch (pOrder.CombHedgeFlag)
                {
                    case EnumHedgeFlagType.Speculation:
                        dr["投机标志"] = "投机";
                        break;
                    case EnumHedgeFlagType.Arbitrage:
                        dr["投机标志"] = "套利";
                        break;
                    case EnumHedgeFlagType.Hedge:
                        dr["投机标志"] = "套保";
                        break;
                    default:
                        dr["投机标志"] = pOrder.CombHedgeFlag.ToString();
                        break;
                }
                dr["价格"] = pOrder.LimitPrice.ToString();
                dr["报单量"] = pOrder.VolumeTotalOriginal.ToString();
                dr["今成交"] = pOrder.VolumeTraded.ToString();
                dr["剩余量"] = pOrder.VolumeTotal.ToString();
                dr["报单日期"] = pOrder.InsertDate.ToString();
                dr["报单时间"] = pOrder.InsertTime.ToString();
                dr["报单状态"] = pOrder.OrderStatus.ToString();
                dr["状态信息"] = pOrder.StatusMsg.ToString();
                if (pOrder.SessionID != this.iSessionID || pOrder.FrontID != this.iFrontID)
                {
                    dr["备注"] = "非本机发单";
                }
                else
                {
                    dr["备注"] = "本机发单";
                }
                #endregion

                if (DR_Find != null)
                {
                    DR_Find.ItemArray = dr.ItemArray;
                }
                else
                {
                    this.DT_RtnOrder.Rows.Add(dr);
                }
            }
        }
        /// <summary>
        /// 行情接口->修改行情登录状态
        /// </summary>
        /// <param name="s"></param>
        private void SetMDLoginState(object s)
        {
            if (this.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetMDLoginState);
                this.BeginInvoke(d, new object[] { s });
            }
            else
            {
                this.TSS_MDLoginState.Text = (string)s;
            }
        }
        /// <summary>
        /// 行情接口->修改行情连接状态
        /// </summary>
        /// <param name="s"></param>
        private void SetMDConnState(object s)
        {
            if (this.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetMDConnState);
                this.BeginInvoke(d, new object[] { s });
            }
            else
            {
                this.TSS_MDConnState.Text = (string)s;
            }
        }
        /// <summary>
        /// 交易接口->修改交易登录状态
        /// </summary>
        /// <param name="s"></param>
        private void SetTDLoginState(object s)
        {
            if (this.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetTDLoginState);
                this.BeginInvoke(d, new object[] { s });
            }
            else
            {
                this.TSS_TDLoginState.Text = (string)s;
            }
        }
        /// <summary>
        /// 交易接口->修改交易连接状态
        /// </summary>
        /// <param name="s"></param>
        private void SetTDConnState(object s)
        {
            if (this.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetTDConnState);
                this.BeginInvoke(d, new object[] { s });
            }
            else
            {
                this.TSS_TDConnState.Text = (string)s;
            }
        }
        /// <summary>
        /// 交易接口->修改持仓
        /// </summary>
        /// <param name="s"></param>
        private void SetTDRspQryInvestorPosition(object s)
        {
            if (this.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetTDRspQryInvestorPosition);
                this.BeginInvoke(d, new object[] { s });
            }
            else
            {
                ThostFtdcInvestorPositionField pInvestorPositionDetail = (ThostFtdcInvestorPositionField)s;
                DataRow dr = this.DT_InvestorPositionDetail.NewRow();
                dr["合约代码"] = pInvestorPositionDetail.InstrumentID;
                dr["投机标志"] = pInvestorPositionDetail.HedgeFlag;
                dr["结算价"] = pInvestorPositionDetail.SettlementPrice;
                dr["平仓量"] = pInvestorPositionDetail.CloseVolume;
                dr["平仓金额"] = pInvestorPositionDetail.CloseAmount;
            }
        }
        /// <summary>
        /// 交易接口->修改持仓明细
        /// </summary>
        /// <param name="s"></param>
        private void SetTDRspQryInvestorPositionDetail(object s)
        {
            if (this.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetTDRspQryInvestorPositionDetail);
                this.BeginInvoke(d, new object[] { s });
            }
            else
            {
                ThostFtdcInvestorPositionDetailField pInvestorPositionDetail = (ThostFtdcInvestorPositionDetailField)s;
                DataRow dr = this.DT_InvestorPositionDetail.NewRow();
                if (pInvestorPositionDetail.OpenDate != pInvestorPositionDetail.TradingDay)
                {
                    dr["持仓类型"] = "昨仓";
                }
                else
                {
                    dr["持仓类型"] = "今仓";
                }
                dr["合约代码"] = pInvestorPositionDetail.InstrumentID;
                dr["开仓日期"] = pInvestorPositionDetail.OpenDate;
                dr["买卖"] = (pInvestorPositionDetail.Direction == EnumDirectionType.Buy) ? "买  " : "  卖";
                switch (pInvestorPositionDetail.HedgeFlag)
                {
                    case EnumHedgeFlagType.Speculation:
                        dr["投机标志"] = "投机";
                        break;
                    case EnumHedgeFlagType.Arbitrage:
                        dr["投机标志"] = "套利";
                        break;
                    case EnumHedgeFlagType.Hedge:
                        dr["投机标志"] = "套保";
                        break;
                    default:
                        dr["投机标志"] = pInvestorPositionDetail.HedgeFlag.ToString();
                        break;
                }
                dr["成交编号"] = pInvestorPositionDetail.TradeID;
                dr["数量"] = pInvestorPositionDetail.Volume;
                dr["开仓价"] = pInvestorPositionDetail.OpenPrice;
                dr["交易日"] = pInvestorPositionDetail.TradingDay;
                dr["结算编号"] = pInvestorPositionDetail.SettlementID;
                switch (pInvestorPositionDetail.TradeType)
                {
                    case EnumTradeTypeType.Common:
                        dr["成交类型"] = "普通成交";
                        break;
                    case EnumTradeTypeType.OptionsExecution:
                        dr["成交类型"] = "期权执行";
                        break;
                    case EnumTradeTypeType.OTC:
                        dr["成交类型"] = "OTC成交";
                        break;
                    case EnumTradeTypeType.EFPDerived:
                        dr["成交类型"] = "期转现成交";
                        break;
                    case EnumTradeTypeType.CombinationDerived:
                        dr["成交类型"] = "组合成交";
                        break;
                    default:
                        dr["成交类型"] = pInvestorPositionDetail.TradeType;
                        break;
                }
                dr["昨结算价"] = pInvestorPositionDetail.LastSettlementPrice;
                dr["结算价"] = pInvestorPositionDetail.SettlementPrice;
                dr["平仓量"] = pInvestorPositionDetail.CloseVolume;
                dr["平仓金额"] = pInvestorPositionDetail.CloseAmount;
                this.DT_InvestorPositionDetail.Rows.Add(dr);
            }
        }
        private void SetTDErrorRspInfo(object s)
        {
            if (this.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetTDErrorRspInfo);
                this.BeginInvoke(d, new object[] { s });
            }
            else
            {
                ThostFtdcRspInfoField pRspInfo = (ThostFtdcRspInfoField)s;
                switch (pRspInfo.ErrorID)
                {
                    case 42:
                        var Result = MessageBox.Show("投资结果未确认,是否立即确认?", "报单错误!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (Result == DialogResult.Yes)
                        {
                            //todo 确认投资者结算
                            this.TDReqSettlementInfoConfirm();
                        }
                        break;
                    default:
                        MessageBox.Show("收到错误,错误ID=" + pRspInfo.ErrorID.ToString() + "\n错误描述:" + pRspInfo.ErrorMsg);
                        break;
                }
            }
        }
        private void SetMDErrorRspInfo(object s)
        {
            if (this.InvokeRequired)
            {
                SetCallback d = new SetCallback(SetMDErrorRspInfo);
                this.BeginInvoke(d, new object[] { s });
            }
            else
            {
                ThostFtdcRspInfoField pRspInfo = (ThostFtdcRspInfoField)s;
                switch (pRspInfo.ErrorID)
                {
                    case 1:
                        break;
                    default:
                        MessageBox.Show("收到错误,错误ID=" + pRspInfo.ErrorID.ToString() + "\n错误描述:" + pRspInfo.ErrorMsg);
                        break;
                }
            }
        }
        #endregion

        #region 行情交易接口实现
        /// <summary>
        /// 行情接口->订阅品种
        /// </summary>
        /// <param name="sInstrument">需要订阅的行情种类</param>
        /// <param name="n">订阅的数量</param>
        public void MDSubscribeInstrument(string[] sInstrument, int n)
        {
            string[] sInst = new string[1];
            if (this.TSS_MDLoginState.Text == "已连接" || this.TSS_MDConnState.Text == "已连接")
            {
                for (int k = 0; k < n; k++)
                {
                    sInst[0] = sInstrument[k].ToString();
                    CtpMDApi.SubscribeMarketData(sInst);
                }
            }
            else
            {
                MessageBox.Show("程序未连接服务器!");
            }
        }


        /// <summary>
        /// 行情接口->取消订阅品种
        /// </summary>
        /// <param name="sInstrument">需要订阅的行情种类</param>
        /// <param name="n">订阅的数量</param>
        public void MDUnSubscribeInstrument(string[] sInstrument, int n)
        {
            string[] sInst = new string[1];
            if (this.TSS_MDLoginState.Text == "已连接" || this.TSS_MDConnState.Text == "已连接")
            {
                for (int k = 0; k < n; k++)
                {
                    sInst[0] = sInstrument[k].ToString();
                    CtpMDApi.UnSubscribeMarketData(sInst);
                }
            }
            else
            {
                MessageBox.Show("程序未连接服务器!");
            }
        }

        /// <summary>
        /// 行街接口->登录服务器
        /// </summary>
        /// <param name="reqLogin"></param>
        public void MDReqUserLogin(ThostFtdcReqUserLoginField reqLogin)
        {
            this.CtpMDApi.ReqUserLogin(reqLogin, ++nRequestID);
        }

        public void TDReqOrderAction(ThostFtdcInputOrderActionField OrderAction)
        {
            this.CtpTDApi.ReqOrderAction(OrderAction, ++nRequestID);
        }

        /// <summary>
        /// 交易接口->登录服务器
        /// </summary>
        /// <param name="reqLogin"></param>
        public void TDReqUserLogin(ThostFtdcReqUserLoginField reqLogin)
        {
            this.CtpTDApi.ReqUserLogin(reqLogin, ++nRequestID);
        }

        /// <summary>
        /// 行情接口->得到交易日
        /// </summary>
        public void MDGetTradingDay()
        {
            TSS_TRADERDAY.Text = "当前交易日:" + CtpMDApi.GetTradingDay();
        }


        /// <summary>
        /// 交易接口->查询所有品种
        /// </summary>
        public void TDReqQryInstrument()
        {
            ThostFtdcQryInstrumentField cQryInstrument = new ThostFtdcQryInstrumentField();
            int k = CtpTDApi.ReqQryInstrument(cQryInstrument, ++nRequestID);
            if (k == -3 || k == -2)
            {
                MessageBox.Show("大佬,你点的我好疼啊,小女子不堪重负啊,你等等在玩我吧~");
            }
            else if (k != 0)
            {
                MessageBox.Show("大佬,我脑袋秀逗了,你帮我看看是否我已经登录?");
            }
        }

        /// <summary>
        /// 交易接口->查询持仓明细
        /// </summary>
        public void TDReqQryInvestorPositionDetail(bool bShow)
        {
            ThostFtdcQryInvestorPositionDetailField pQryInvestorPositionDetail = new ThostFtdcQryInvestorPositionDetailField();
            pQryInvestorPositionDetail.BrokerID = sBrokerID;
            pQryInvestorPositionDetail.InvestorID = sUserID;
            int k = CtpTDApi.ReqQryInvestorPositionDetail(pQryInvestorPositionDetail, ++nRequestID);
            if ((k == -3 || k == -2) && bShow)
            {
                MessageBox.Show("大佬,你点的我好疼啊,小女子不堪重负啊,你等等在玩我吧~");
            }
            else if (k != 0 && bShow)
            {
                MessageBox.Show("大佬,我脑袋秀逗了,你帮我看看是否我已经登录?");
            }
        }

        /// <summary>
        /// 交易接口->发单操作
        /// </summary>
        /// <param name="pInputOrder"></param>
        /// <param name="bShow"></param>
        public void TDReqOrderInsert(ThostFtdcInputOrderField pInputOrder, bool bShow = false)
        {
            pInputOrder.BrokerID = this.sBrokerID;
            pInputOrder.InvestorID = this.sUserID;
            pInputOrder.BusinessUnit = null;
            if (pInputOrder.OrderRef == null)
            {
                pInputOrder.OrderRef = (iOrderRefID++).ToString();
            }
            if (pInputOrder.MinVolume < 1) pInputOrder.MinVolume = 1;

            int k = CtpTDApi.ReqOrderInsert(pInputOrder, ++nRequestID);
            if ((k == -3 || k == -2) && bShow)
            {
                MessageBox.Show("大佬,你点的我好疼啊,小女子不堪重负啊,你等等在玩我吧~");
            }
            else if (k != 0 && bShow)
            {
                MessageBox.Show("大佬,我脑袋秀逗了,你帮我看看是否我已经登录?");
            }
        }


        private void TDReqSettlementInfoConfirm()
        {
            ThostFtdcSettlementInfoConfirmField cReqSettlementInfoConfirm = new ThostFtdcSettlementInfoConfirmField();
            cReqSettlementInfoConfirm.BrokerID = this.sBrokerID;
            cReqSettlementInfoConfirm.InvestorID = this.sUserID;
            int resault = this.CtpTDApi.ReqSettlementInfoConfirm(cReqSettlementInfoConfirm, ++nRequestID);
        }

        #endregion 行情交易接口实现

        #region 任务栏改变事件
        /// <summary>
        /// 连接状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSS_MDConnState_TextChanged(object sender, EventArgs e)
        {
            if (this.TSS_MDConnState.Text == "已连接" && this.TSS_TDConnState.Text == "已连接")
            {
                this.Button_Login.Enabled = true;
                this.Button_Connect.Enabled = false;
                this.Button_Loginout.Enabled = true;
                this.Button_Edit.Enabled = false;
                this.radioButton_MemDB.Enabled = false;
                this.radioButton_FileDB.Enabled = false;
                this.comboBox_ResumeType.Enabled = false;
            }
            else
            {
                this.Button_Connect.Enabled = true;
                this.Button_Login.Enabled = false;
                this.Button_Edit.Enabled = true;
                this.radioButton_MemDB.Enabled = true;
                this.radioButton_FileDB.Enabled = true;
                this.comboBox_ResumeType.Enabled = true;
            }
        }


        /// <summary>
        /// 连接状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSS_TDConnState_TextChanged(object sender, EventArgs e)
        {
            if (this.TSS_MDConnState.Text == "已连接" && this.TSS_TDConnState.Text == "已连接")
            {
                this.Button_Login.Enabled = true;
                this.Button_Connect.Enabled = false;
                this.Button_Loginout.Enabled = true;
                this.Button_Edit.Enabled = false;
                this.radioButton_MemDB.Enabled = false;
                this.radioButton_FileDB.Enabled = false;
                this.comboBox_ResumeType.Enabled = false;
            }
            else
            {
                this.Button_Connect.Enabled = true;
                this.Button_Login.Enabled = false;
                this.Button_Edit.Enabled = true;
                this.radioButton_MemDB.Enabled = true;
                this.radioButton_FileDB.Enabled = true;
                this.comboBox_ResumeType.Enabled = true;
            }
        }


        /// <summary>
        /// 登录状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSS_MDLoginState_TextChanged(object sender, EventArgs e)
        {
            if (this.TSS_MDLoginState.Text == "已连接" && this.TSS_TDLoginState.Text == "已连接")
            {
                this.TDReqSettlementInfoConfirm();
                this.Button_Login.Enabled = false;
                this.Button_Connect.Enabled = false;
                this.Button_Loginout.Enabled = true;
                this.Button_Edit.Enabled = false;
                this.tabControl1.SelectTab("TabPage_RegistInstrument");
                this.TDReqQryInstrument();
            }
            else
            {
                this.Button_Login.Enabled = false;
                this.Button_Edit.Enabled = true;
            }
        }


        /// <summary>
        /// 登录状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TSS_TDLoginState_TextChanged(object sender, EventArgs e)
        {
            if (this.TSS_MDLoginState.Text == "已连接" && this.TSS_TDLoginState.Text == "已连接")
            {
                this.TDReqSettlementInfoConfirm();
                this.Button_Login.Enabled = false;
                this.Button_Connect.Enabled = false;
                this.Button_Loginout.Enabled = true;
                this.Button_Edit.Enabled = false;
                this.tabControl1.SelectTab("TabPage_RegistInstrument");
                this.TDReqQryInstrument();
            }
            else
            {
                this.Button_Login.Enabled = false;
                this.Button_Edit.Enabled = true;
            }
        }

        #endregion 任务栏改变事件

        #region 用户登录Tab界面

        /// <summary>
        /// 点击连接按钮连接前置机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Connect_Click(object sender, EventArgs e)
        {
            sTDAddress = this.TextBox_TDADDRESS.Text;
            sMDAddress = this.TextBox_MDADDRESS.Text;
            sBrokerID = this.TextBox_BrokerID.Text;
            sUserID = this.TextBox_UserID.Text;
            sPassword = this.TextBox_PassWord.Text;
            sTableName = string.Empty;
            #region 数据库初始化
            //内存数据库打开
            if (this.radioButton_MemDB.Checked && MemDB == null)
            {
                MemDB = new SQLiteBase.SQLiteBase();
            }
            else if (MemDB == null)
            {
                MemDB = new SQLiteBase.SQLiteBase("InstrmentDataBase.db");
            }
            MemDB.OpenDB();
            #endregion
            #region 交易初始化
            CtpMDApi = new CTPMDAdapter("MDAPI", false);
            CtpMDApi.OnFrontConnected += new FrontConnected(sCtpMdApi.OnFrontConnected);
            CtpMDApi.OnFrontDisconnected += new FrontDisconnected(sCtpMdApi.OnFrontDisconnected);
            CtpMDApi.OnHeartBeatWarning += new HeartBeatWarning(sCtpMdApi.OnHeartBeatWarning);
            CtpMDApi.OnRspError += new RspError(sCtpMdApi.OnRspError);
            CtpMDApi.OnRspSubMarketData += new RspSubMarketData(sCtpMdApi.OnRspSubMarketData);
            CtpMDApi.OnRspUnSubMarketData += new RspUnSubMarketData(sCtpMdApi.OnRspUnSubMarketData);
            CtpMDApi.OnRspUserLogin += new RspUserLogin(sCtpMdApi.OnRspUserLogin);
            CtpMDApi.OnRspUserLogout += new RspUserLogout(sCtpMdApi.OnRspUserLogout);
            CtpMDApi.OnRtnDepthMarketData += new RtnDepthMarketData(sCtpMdApi.OnRtnDepthMarketData);
            //注册前置机
            CtpMDApi.RegisterFront(sMDAddress);
            //初始化
            CtpMDApi.Init();
            #endregion 交易初始化
            #region 行情初始化
            CtpTDApi = new CTPTDAdapter("TDAPI");
            CtpTDApi.OnFrontConnected += new FrontConnected(sCtpTdApi.OnFrontConnected);
            CtpTDApi.OnFrontDisconnected += new FrontDisconnected(sCtpTdApi.OnFrontDisconnected);
            CtpTDApi.OnHeartBeatWarning += new HeartBeatWarning(sCtpTdApi.OnHeartBeatWarning);
            CtpTDApi.OnRspError += new RspError(sCtpTdApi.OnRspError);
            CtpTDApi.OnRspUserLogin += new RspUserLogin(sCtpTdApi.OnRspUserLogin);
            CtpTDApi.OnRspOrderAction += new RspOrderAction(sCtpTdApi.OnRspOrderAction);
            CtpTDApi.OnRspOrderInsert += new RspOrderInsert(sCtpTdApi.OnRspOrderInsert);
            CtpTDApi.OnRspQryInstrument += new RspQryInstrument(sCtpTdApi.OnRspQryInstrument);
            CtpTDApi.OnRspQryInvestorPosition += new RspQryInvestorPosition(sCtpTdApi.OnRspQryInvestorPosition);
            CtpTDApi.OnRspQryInvestorPositionDetail += new RspQryInvestorPositionDetail(sCtpTdApi.OnRspQryInvestorPositionDetail);
            CtpTDApi.OnRspQryTradingAccount += new RspQryTradingAccount(sCtpTdApi.OnRspQryTradingAccount);
            CtpTDApi.OnRspSettlementInfoConfirm += new RspSettlementInfoConfirm(sCtpTdApi.OnRspSettlementInfoConfirm);
            CtpTDApi.OnRtnOrder += new RtnOrder(sCtpTdApi.OnRtnOrder);
            CtpTDApi.OnRtnTrade += new RtnTrade(sCtpTdApi.OnRtnTrade);
            //注册流



            switch (comboBox_ResumeType.Text)
            {
                case "断线恢复":
                    CtpTDApi.SubscribePublicTopic(EnumTeResumeType.THOST_TERT_RESUME);					// 注册公有流
                    CtpTDApi.SubscribePrivateTopic(EnumTeResumeType.THOST_TERT_RESUME);					// 注册私有流
                    break;
                case "当天全部":
                    CtpTDApi.SubscribePublicTopic(EnumTeResumeType.THOST_TERT_RESTART);					// 注册公有流
                    CtpTDApi.SubscribePrivateTopic(EnumTeResumeType.THOST_TERT_RESTART);					// 注册私有流
                    break;
                default:
                    CtpTDApi.SubscribePublicTopic(EnumTeResumeType.THOST_TERT_QUICK);					// 注册公有流
                    CtpTDApi.SubscribePrivateTopic(EnumTeResumeType.THOST_TERT_QUICK);					// 注册私有流
                    break;

            }

            //注册前置机
            CtpTDApi.RegisterFront(sTDAddress);
            //初始化
            CtpTDApi.Init();
            #endregion 行情初始化
        }


        /// <summary>
        /// 登录按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Login_Click(object sender, EventArgs e)
        {
            //获取交易日
            this.MDGetTradingDay();
            ThostFtdcReqUserLoginField reqLogin = new ThostFtdcReqUserLoginField();
            reqLogin.BrokerID = sBrokerID;
            reqLogin.UserID = sUserID;
            reqLogin.Password = sPassword;
            this.MDReqUserLogin(reqLogin);
            this.TDReqUserLogin(reqLogin);
        }


        /// <summary>
        /// 修改按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Edit_Click(object sender, EventArgs e)
        {
            if (this.TextBox_TDADDRESS.Enabled)
            {
                string sDbType = string.Empty;
                SQLiteBase.SQLiteBase SQLiteRun = new SQLiteBase.SQLiteBase("ConfigDB.db");

                if (this.radioButton_MemDB.Checked == true)
                {
                    sDbType = "0";
                }
                else
                {
                    sDbType = "1";
                }
                string sSql = "REPLACE INTO CTP_LOGIN_INFO SELECT 1,'"
                    + this.TextBox_TDADDRESS.Text + "','"
                    + this.TextBox_MDADDRESS.Text + "','"
                    + this.TextBox_BrokerID.Text + "','"
                    + this.TextBox_UserID.Text + "','"
                    + this.TextBox_PassWord.Text + "','"
                    + sDbType + "'";
                //先尝试打开一下
                SQLiteRun.OpenDB();
                SQLiteRun.setSQL(sSql);
                SQLiteRun.Execute();
                SQLiteRun.Commit();
                SQLiteRun.CloseDB();

                this.TextBox_TDADDRESS.Enabled = false;
                this.TextBox_MDADDRESS.Enabled = false;
                this.TextBox_BrokerID.Enabled = false;
                this.TextBox_UserID.Enabled = false;
                this.TextBox_PassWord.Enabled = false;
                this.Button_Login.Enabled = true;
                this.Button_Connect.Enabled = true;
            }
            else
            {
                this.TextBox_TDADDRESS.Enabled = true;
                this.TextBox_MDADDRESS.Enabled = true;
                this.TextBox_BrokerID.Enabled = true;
                this.TextBox_UserID.Enabled = true;
                this.TextBox_PassWord.Enabled = true;
                this.Button_Login.Enabled = false;
                this.Button_Connect.Enabled = false;
            }
        }



        /// <summary>
        /// 注销按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Loginout_Click(object sender, EventArgs e)
        {
            ThostFtdcUserLogoutField pUserLogout = new ThostFtdcUserLogoutField();
            pUserLogout.BrokerID = sBrokerID;
            pUserLogout.UserID = sUserID;
            if (this.TSS_MDLoginState.Text == "已连接")
            {
                CtpMDApi.ReqUserLogout(pUserLogout, nRequestID++);
            }
            if (this.TSS_TDLoginState.Text == "已连接")
            {
                CtpMDApi.ReqUserLogout(pUserLogout, nRequestID++);
            }
            CtpMDApi.Release();
            CtpMDApi = null;
            CtpTDApi.Release();
            CtpTDApi = null;
            this.TSS_MDConnState.Text = "已断开";
            this.TSS_TDConnState.Text = "已断开";
            this.TSS_MDLoginState.Text = "已断开";
            this.TSS_TDLoginState.Text = "已断开";
            Button_Loginout.Enabled = false;
            MemDB.CloseDB();
            MemDB = null;
        }


        #endregion

        #region 行情管理Tab界面

        /// <summary>
        /// 行情注册按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Regedit_Click(object sender, EventArgs e)
        {
            ListBox x = new ListBox();
            int selectedCellCount = GridView_RegistInstrument_Data.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                for (int i = 0; i < selectedCellCount; i++)
                {
                    int rowID =
                    GridView_RegistInstrument_Data.SelectedCells[i].RowIndex;
                    string n =
                    GridView_RegistInstrument_Data.Rows[rowID].Cells[0].Value.ToString();
                    x.Items.Add(n);
                }
                for (int i = 0; i < x.Items.Count; i++)
                {
                    sInstrument[i] = x.Items[i].ToString();
                }
                this.MDSubscribeInstrument(sInstrument, x.Items.Count);
                // this.tabControl1.SelectTab("Tabpage_InstrumentShow");
            }
        }

        /// <summary>
        /// 根据合约过滤按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Filter_Click(object sender, EventArgs e)
        {
            if (comboBox_ProductID.Text == "")
            {
                this.GridView_RegistInstrument_Data.DataSource = this.DT_Instrument;
                return;
            }
            DataTable newTable = this.DT_Instrument.Clone();
            string expression;
            expression = "合约名称 = '" + comboBox_ProductID.Text + "'";
            DataRow[] drs = this.DT_Instrument.Select(expression);
            foreach (DataRow dr in drs)
            {
                object[] arr = dr.ItemArray;
                DataRow newrow = newTable.NewRow();
                for (int i = 0; i < arr.Length; i++)
                    newrow[i] = arr[i];
                newTable.Rows.Add(newrow);
            }
            GridView_RegistInstrument_Data.DataSource = newTable;
        }

        /// <summary>
        /// 行情数据表上面双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstrumentGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Left)
            {
                string sTableName = "tip_" + GridView_DeepInstrument.Rows[e.RowIndex].Cells["交易日"].Value.ToString();
                DeepInstrumentView f2 = new DeepInstrumentView(sTableName, GridView_DeepInstrument.Rows[e.RowIndex].Cells["品种名称"].Value.ToString(), MemDB);
                f2.Show();
            }
            else if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                GridView_DeepInstrument.Rows[e.RowIndex].Selected = true;
                sInstrument[0] = GridView_DeepInstrument.Rows[e.RowIndex].Cells["品种名称"].Value.ToString();
                this.MDUnSubscribeInstrument(sInstrument, 1);
                DataRow DR_Find = this.DT_DeepInstrumentRSP.Rows.Find(sInstrument[0]);
                DR_Find.Delete();
            }
            else if (e.RowIndex < 0)
            {
                TextBox_Trader_InstrumentName.Text = null;
            }
        }

        /// <summary>
        /// 行情数据表上面单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstrumentGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.Button == MouseButtons.Left)
            {
                string n = GridView_DeepInstrument.Rows[e.RowIndex].Cells[0].Value.ToString();
                TextBox_Trader_InstrumentName.Text = n;
                textBox_OrderPrice.Text = GridView_DeepInstrument.Rows[e.RowIndex].Cells["最新价"].Value.ToString();

            }
            else if (e.RowIndex >= 0 && e.Button == MouseButtons.Right)
            {
                GridView_DeepInstrument.Rows[e.RowIndex].Selected = true;
            }
            else if (e.RowIndex < 0)
            {
                TextBox_Trader_InstrumentName.Text = null;
            }
        }


        /// <summary>
        /// 刷新行情种类按钮点击(从服务器重新获取所有行情种类)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_reload_Click(object sender, EventArgs e)
        {
            this.TDReqQryInstrument();
        }

        /// <summary>
        /// 设置最小成交量等于发单量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SetMinVolumeEQOrderNum_Click(object sender, EventArgs e)
        {
            this.numericUpDown_MinVolume.Value = this.numericUpDown_OrderNumber.Value;
        }
        /// <summary>
        /// 重置发单
        /// </summary>
        private void RestSendOrderFiled()
        {
            this.TextBox_Trader_InstrumentName.Text = "";
            this.textBox_OrderPrice.Text = "";
            this.radioButton_Buy.Checked = Enabled;
            this.radioButton_Open.Checked = Enabled;
            this.radioButton_HedgeFlagSpeculation.Checked = Enabled;
            this.numericUpDown_OrderNumber.Value = 1;
            this.numericUpDown_MinVolume.Value = 1;
        }

        /// <summary>
        /// 发单按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_OrderInput_Click(object sender, EventArgs e)
        {
            if (TextBox_Trader_InstrumentName.Text == "")
            {
                MessageBox.Show("请输入合约名称!", "错误!");
                return;
            }
            ThostFtdcInputOrderField sInputOrder = new ThostFtdcInputOrderField();
            sInputOrder.InstrumentID = TextBox_Trader_InstrumentName.Text;
            iOrderRefID = iOrderRefID + 1;
            sInputOrder.BrokerID = sBrokerID;
            sInputOrder.InvestorID = sUserID;
            sInputOrder.OrderRef = (iOrderRefID).ToString();
            sInputOrder.BusinessUnit = null;
            sInputOrder.RequestID = nRequestID++;

            sInputOrder.UserForceClose = 0;
            sInputOrder.ForceCloseReason = EnumForceCloseReasonType.NotForceClose;
            sInputOrder.IsAutoSuspend = 0;

            #region 报单价格及价格条件
            if (radioButton_AnyPrice.Checked)
            {
                sInputOrder.OrderPriceType = EnumOrderPriceTypeType.AnyPrice;
                sInputOrder.LimitPrice = 0;
            }
            else if (radioButton_LimitePrice.Checked || this.textBox_OrderPrice.Text.ToString() != "")
            {
                sInputOrder.OrderPriceType = EnumOrderPriceTypeType.LimitPrice;
                try
                {
                    sInputOrder.LimitPrice = double.Parse(this.textBox_OrderPrice.Text.ToString());
                }
                catch (Exception ec)
                {
                    MessageBox.Show("限价单价格输入错误!\n\n错误信息:\n" + ec.Message, "错误!");
                    return;
                }
            }
            #endregion
            #region 开平按钮
            if (radioButton_Open.Checked)
            {
                sInputOrder.CombOffsetFlag = EnumOffsetFlagType.Open;
            }
            else if (radioButton_CloseALL.Checked)
            {
                sInputOrder.CombOffsetFlag = EnumOffsetFlagType.Close;
            }
            else if (radioButton_CloseToday.Checked)
            {
                sInputOrder.CombOffsetFlag = EnumOffsetFlagType.CloseToday;
            }
            else if (radioButton_CloseYestoday.Checked)
            {
                sInputOrder.CombOffsetFlag = EnumOffsetFlagType.CloseYesterday;
            }
            #endregion 开平按钮
            #region 买卖按钮
            if (radioButton_Buy.Checked)
            {
                sInputOrder.Direction = EnumDirectionType.Buy;
            }
            else if (radioButton_Sell.Checked)
            {
                sInputOrder.Direction = EnumDirectionType.Sell;
            }
            #endregion
            #region 投机套保按钮
            if (this.radioButton_HedgeFlagSpeculation.Checked)
            {
                sInputOrder.CombHedgeFlag = EnumHedgeFlagType.Speculation;
            }
            else if (this.radioButton_HedgeFlagArbitrage.Checked)
            {
                sInputOrder.CombHedgeFlag = EnumHedgeFlagType.Arbitrage;
            }
            else if (this.radioButton_HedgeFlagArbitrage.Checked)
            {
                sInputOrder.CombHedgeFlag = EnumHedgeFlagType.Hedge;
            }

            #endregion 投机套保按钮
            #region 成交量类型
            switch (this.comboBox_VolumeCondition.Text)
            {
                case "任意数量":
                    sInputOrder.VolumeCondition = EnumVolumeConditionType.AV;
                    break;
                case "最小数量":
                    sInputOrder.VolumeCondition = EnumVolumeConditionType.MV;
                    break;
                case "全部数量":
                    sInputOrder.VolumeCondition = EnumVolumeConditionType.CV;
                    break;
                default:
                    sInputOrder.VolumeCondition = EnumVolumeConditionType.AV;
                    break;

            }
            #endregion
            #region 触发条件
            switch (this.comboBox_ContingentCondition.Text)
            {
                case "立即":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.Immediately;
                    break;
                case "止损":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.Touch;
                    break;
                case "止赢":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.TouchProfit;
                    break;
                case "预埋单":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.ParkedOrder;
                    break;
                case "最新价大于条件价":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.LastPriceGreaterThanStopPrice;
                    break;
                case "最新价大于等于条件价":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.LastPriceGreaterEqualStopPrice;
                    break;
                case "最新价小于条件价":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.LastPriceLesserThanStopPrice;
                    break;
                case "最新价小于等于条件价":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.LastPriceLesserEqualStopPrice;
                    break;
                case "卖一价大于条件价":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.AskPriceGreaterThanStopPrice;
                    break;
                case "卖一价大于等于条件价":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.AskPriceGreaterEqualStopPrice;
                    break;
                case "卖一价小于条件价":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.AskPriceLesserThanStopPrice;
                    break;
                case "卖一价小于等于条件价":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.AskPriceLesserEqualStopPrice;
                    break;
                case "买一价大于条件价":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.BidPriceGreaterThanStopPrice;
                    break;
                case "买一价大于等于条件价":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.BidPriceGreaterEqualStopPrice;
                    break;
                case "买一价小于条件价":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.BidPriceLesserThanStopPrice;
                    break;
                case "买一价小于等于条件价":
                    sInputOrder.ContingentCondition = EnumContingentConditionType.BidPriceLesserEqualStopPrice;
                    break;
                default:
                    sInputOrder.ContingentCondition = EnumContingentConditionType.Immediately;
                    break;
            }
            #endregion
            #region 有效期限
            switch (this.comboBox_TimeCondition.Text)
            {
                case "立即完成":
                    sInputOrder.TimeCondition = EnumTimeConditionType.IOC;
                    break;
                case "本节有效":
                    sInputOrder.TimeCondition = EnumTimeConditionType.GFS;
                    break;
                case "当日有效":
                    sInputOrder.TimeCondition = EnumTimeConditionType.GFD;
                    break;
                case "指定日期前有效":
                    sInputOrder.TimeCondition = EnumTimeConditionType.GTD;
                    break;
                case "撤销前有效":
                    sInputOrder.TimeCondition = EnumTimeConditionType.GTC;
                    break;
                case "集合竞价有效":
                    sInputOrder.TimeCondition = EnumTimeConditionType.GFA;
                    break;
                default:
                    sInputOrder.TimeCondition = EnumTimeConditionType.IOC;
                    break;
            }
            #endregion
            #region 报单数量
            sInputOrder.VolumeTotalOriginal = (int)numericUpDown_OrderNumber.Value;
            sInputOrder.MinVolume = (int)numericUpDown_MinVolume.Value;
            #endregion 报单数量
            this.TDReqOrderInsert(sInputOrder, true);
            if (checkBox_ResetAfterSend.Checked)
                this.RestSendOrderFiled();
        }
        /// <summary>
        /// 重置发单区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OrderSendReset_Click(object sender, EventArgs e)
        {
            this.RestSendOrderFiled();
        }
        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_RtnOrder_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //"报单引用", "会话标识", "前置机标识", "品种名称", "买卖", "开平", "投机标志", "价格", "报单量", "今成交", "剩余量", "报单日期", "报单时间", "报单状态", "状态信息", "备注" };
            if (e.RowIndex >= 0)
            {
                ThostFtdcInputOrderActionField OrderAction = new ThostFtdcInputOrderActionField();
                var result = MessageBox.Show("是否撤单?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    OrderAction.BrokerID = this.sBrokerID;
                    OrderAction.ActionFlag = EnumActionFlagType.Delete;
                    OrderAction.FrontID = Int32.Parse(this.GridView_RtnOrder.Rows[e.RowIndex].Cells["前置机标识"].Value.ToString());
                    OrderAction.InstrumentID = this.GridView_RtnOrder.Rows[e.RowIndex].Cells["品种名称"].Value.ToString();
                    OrderAction.InvestorID = this.sUserID;
                    OrderAction.UserID = null;
                    OrderAction.OrderSysID = this.GridView_RtnOrder.Rows[e.RowIndex].Cells["报单编号"].Value.ToString();
                    OrderAction.ExchangeID = this.GridView_RtnOrder.Rows[e.RowIndex].Cells["交易所"].Value.ToString();
                    OrderAction.OrderRef = this.GridView_RtnOrder.Rows[e.RowIndex].Cells["报单引用"].Value.ToString();
                    OrderAction.SessionID = Int32.Parse(this.GridView_RtnOrder.Rows[e.RowIndex].Cells["会话标识"].Value.ToString());
                    this.TDReqOrderAction(OrderAction);
                }
            }
        }
        /// <summary>
        /// 持仓明细查询表格右键刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DT_InvestorPositionDetail.Clear();
            this.TDReqQryInvestorPositionDetail(true);
        }
        /// <summary>
        /// 限价单按钮选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_LimitePrice_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_LimitePrice.Checked == true)
            {
                textBox_OrderPrice.Enabled = true;
            }
            else
            {
                textBox_OrderPrice.Enabled = false;
            }
        }
        /// <summary>
        /// 自动筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_ProductID_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_ProductID.Text == "")
            {
                this.GridView_RegistInstrument_Data.DataSource = this.DT_Instrument;
                return;
            }
            DataTable newTable = this.DT_Instrument.Clone();
            string expression;
            expression = "合约名称 like  '" + comboBox_ProductID.Text + "%'";
            DataRow[] drs = this.DT_Instrument.Select(expression);
            foreach (DataRow dr in drs)
            {
                object[] arr = dr.ItemArray;
                DataRow newrow = newTable.NewRow();
                for (int i = 0; i < arr.Length; i++)
                    newrow[i] = arr[i];
                newTable.Rows.Add(newrow);
            }
            GridView_RegistInstrument_Data.DataSource = newTable;

        }

        #endregion

        #region 策略启动tab界面

        private void PolicyLogListRefresh()
        {
            this.listBox_PolicyLogList.Items.Clear();
            if (this.listBox_PolicyList.SelectedIndex >= 0)
            {
                int count = 0;
                switch (this.listBox_PolicyList.SelectedItem.ToString())
                {
                    case "Sqlite队列":
                        if (Queue_SQLite.bUse)
                        {
                            this.button_PolicyStart.Enabled = false;
                            this.button_PolicyStop.Enabled = false;
                            this.label_PolicyReceiveNum.Text = Queue_SQLite.m_lReceiveNum.ToString();
                            this.label_PolicyDropNum.Text = Queue_SQLite.m_lDropNum.ToString();
                            this.label_PolicyRunNum.Text = Queue_SQLite.m_lRunNum.ToString();
                            this.label_PolicyQueueNum.Text = Queue_SQLite.DataQ.Count.ToString();
                            count = Queue_SQLite.list_log.Count() - 1;
                            if (count < 0) return;
                            for (int i = count; i > -1; i--)
                            {
                                if (Queue_SQLite.list_log[i] != "")
                                {
                                    this.listBox_PolicyLogList.Items.Add(Queue_SQLite.list_log[i]);
                                }
                            }
                        }
                        break;
                    case "测试策略":
                        if (Queue_PolicySample.bUse)
                        {
                            this.button_PolicyStart.Enabled = false;
                            this.button_PolicyStop.Enabled = true;
                        }
                        else
                        {
                            this.button_PolicyStart.Enabled = true;
                            this.button_PolicyStop.Enabled = false;
                        }
                        this.label_PolicyQueueNum.Text = Queue_PolicySample.DataQ.Count.ToString();
                        this.label_PolicyReceiveNum.Text = Queue_PolicySample.m_lReceiveNum.ToString();
                        this.label_PolicyDropNum.Text = Queue_PolicySample.m_lDropNum.ToString();
                        this.label_PolicyRunNum.Text = Queue_PolicySample.m_lRunNum.ToString();
                        count = Queue_PolicySample.list_log.Count() - 1;
                        if (count < 0) return;
                        for (int i = count; i > -1; i--)
                        {
                            if (Queue_PolicySample.list_log[i] != "")
                            {
                                this.listBox_PolicyLogList.Items.Add(Queue_PolicySample.list_log[i]);
                            }

                        }
                        break;
                    default:
                        break;
                }
            }
        }
        private void PolicyStop()
        {
            this.listBox_PolicyLogList.Items.Clear();
            if (this.listBox_PolicyList.SelectedIndex >= 0)
            {
                switch (this.listBox_PolicyList.SelectedItem.ToString())
                {
                    case "Sqlite队列":
                        this.button_PolicyStart.Enabled = false;
                        this.button_PolicyStop.Enabled = false;
                        break;
                    case "测试策略":
                        if (Queue_PolicySample.bUse)
                        {
                            Queue_PolicySample.bUse = false;
                            Queue_PolicySample.DataQ.Clear();
                            this.button_PolicyStart.Enabled = true;
                            this.button_PolicyStop.Enabled = false;
                            this.label_PolicyReceiveNum.Text = Queue_PolicySample.m_lReceiveNum.ToString();
                            this.label_PolicyDropNum.Text = Queue_PolicySample.m_lDropNum.ToString();
                            this.label_PolicyRunNum.Text = Queue_PolicySample.m_lRunNum.ToString();
                            int count = Queue_PolicySample.list_log.Count() - 1;
                            if (count < 0) return;
                            for (int i = count; i > -1; i--)
                            {
                                if (Queue_PolicySample.list_log[i] != "")
                                {
                                    this.listBox_PolicyLogList.Items.Add(Queue_PolicySample.list_log[i]);
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void button_PolicyRefresh_Click(object sender, EventArgs e)
        {
            this.PolicyLogListRefresh();
        }
        private void button_PolicyStop_Click(object sender, EventArgs e)
        {
            this.PolicyStop();
        }

        private void listBox_PolicyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PolicyLogListRefresh();
        }

        /// <summary>
        /// 启动线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_PolicySample_Click(object sender, EventArgs e)
        {
            if (this.listBox_PolicyList.SelectedIndex < 0)
            {
                MessageBox.Show("请在右侧选择策略进行启动", "错误!");
                return;
            }
            switch (this.listBox_PolicyList.SelectedItem.ToString())
            {
                case "Sqlite队列":
                    if (Queue_SQLite.bUse)
                    {
                        this.label_PolicyReceiveNum.Text = Queue_SQLite.m_lReceiveNum.ToString();
                        this.label_PolicyDropNum.Text = Queue_SQLite.m_lDropNum.ToString();
                        this.label_PolicyRunNum.Text = Queue_SQLite.m_lRunNum.ToString();
                        this.label_PolicyQueueNum.Text = Queue_SQLite.DataQ.Count.ToString();
                        int count = Queue_SQLite.list_log.Count();
                        for (int i = 0; i < count; i++)
                        {
                            if (Queue_SQLite.list_log[i] != "")
                            {
                                this.listBox_PolicyLogList.Items.Add(Queue_SQLite.list_log[i]);
                            }
                        }
                    }
                    break;
                case "测试策略":
                    if (!Queue_PolicySample.bUse) //未使用
                    {
                        this.button_PolicyStart.Enabled = false;
                        this.button_PolicyStop.Enabled = true;
                        Queue_PolicySample.bUse = true;
                        Queue_PolicySample.t = new Thread(PolicySampleRUN);
                        Queue_PolicySample.t.IsBackground = true;
                        Queue_PolicySample.t.Start((object)this);
                    }
                    break;
                default:
                    break;
            }
        }

        #region 一个简单的策略例子


        private void PolicySampleRUN(object s)
        {
            MainForm cMainForm = (MainForm)s;
            ThostFtdcInputOrderField sInputOrder = new ThostFtdcInputOrderField();
            ThostFtdcDepthMarketDataField pDepthMarketData = new ThostFtdcDepthMarketDataField();
            QueueSendData Data = new QueueSendData();
            while (Queue_PolicySample.bUse)
            {
                if (Queue_PolicySample.DataQ.Count == 0)
                {
                    Queue_PolicySample.Are.WaitOne();
                    Queue_PolicySample.Are.Reset();
                }
                else
                {
                    Data = Queue_PolicySample.DataQ.Dequeue();
                    #region 这里写策略
                    switch (Data.QueueType)
                    {
                        case EnumQueueType.DepthMarketData:
                            Queue_PolicySample.m_lReceiveNum++;
                            pDepthMarketData = (ThostFtdcDepthMarketDataField)Data.QueueData;
                            if (pDepthMarketData.InstrumentID == "IF1309")
                            {
                                Queue_PolicySample.m_lRunNum++;
                                Queue_PolicySample.add_log("插入报单!触发单:" + pDepthMarketData.InstrumentID + " \n时间:" + pDepthMarketData.UpdateTime);
                                // cMainForm.TDReqOrderInsert(sInputOrder);
                            }
                            else
                            {
                                Queue_PolicySample.m_lDropNum++;
                            }
                            break;
                        case EnumQueueType.OnRtnOrder:
                            break;
                        case EnumQueueType.StopSign0:
                            Queue_PolicySample.bUse = false;
                            return;
                        default:
                            break;
                    }
                    #endregion
                }
            }
            Queue_PolicySample.bUse = false;
        }

        #endregion


        #endregion

        #region 数据队列发送线程结构体及实现方法
        //数据发送线程
        private void SendData()
        {
            //这里添加需要发送队列的线程
            PolicyDataQueueList.Add(this.Queue_PolicySample);
            PolicyDataQueueList.Add(this.Queue_SQLite);
            while (true)
            {
                while (this.List_QueueSend.Count == 0)
                {
                    this.SignMainQueueSend.WaitOne();
                }

                while (this.List_QueueSend.Count > 0)
                {
                    for (int i = 0; i < PolicyDataQueueList.Count; i++)
                    {
                        if (PolicyDataQueueList[i].bUse)
                        {
                            PolicyDataQueueList[i].DataQ.Enqueue(List_QueueSend[0]);
                            PolicyDataQueueList[i].Are.Set();
                        }
                    }
                    //循环发送
                    this.SignMainQueueSend.Reset();
                    List_QueueSend.Remove(List_QueueSend[0]);
                }
            }
        }

        //队列数据结构
        public enum EnumQueueType
        {
            //深度行情
            DepthMarketData = 1,
            //报单反馈
            OnRtnOrder = 2,
            //停止信号1
            StopSign1 = 9991,
            //停止信号2
            StopSign2 = 9992,
            //停止信号3
            StopSign3 = 9993,
            //停止信号4
            StopSign4 = 9994,
            //停止信号5
            StopSign5 = 9995,
            //停止信号6
            StopSign6 = 9996,
            //停止信号7
            StopSign7 = 9997,
            //停止信号8
            StopSign8 = 9998,
            //停止信号9
            StopSign9 = 9999,
            //停止信号0
            StopSign0 = 9990,
        }
        public class QueueSendData
        {
            public EnumQueueType QueueType;
            public object QueueData;
        }
        //一个队列的定义
        class PolicyDataQueue
        {
            /// <summary>
            /// 名称
            /// </summary>
            string name = "";
            public string Name
            {
                get { return name; }
            }

            public bool bUse = false;
            /// <summary>
            /// 外部插入数据的缓存队列
            /// </summary>
            Queue<QueueSendData> dataQ = new Queue<QueueSendData>();
            public Queue<QueueSendData> DataQ
            {
                get { return dataQ; }
                set { dataQ = value; }
            }
            /// <summary>
            /// 运行策略的线程
            /// </summary>
            public Thread t;
            /// <summary>
            /// 线程信号
            ///     用于在无数据时阻塞线程
            /// </summary>
            AutoResetEvent are = new AutoResetEvent(false);
            public AutoResetEvent Are
            {
                get { return are; }
                set { are = value; }
            }
            /// <summary>
            /// 构造函数
            ///     传入名称
            /// </summary>
            /// <param name="n"></param>
            public PolicyDataQueue(string n)
            {
                name = n;
            }

            private static int k = 0;
            public List<string> list_log = new List<string>();

            public void add_log(string s)
            {
                if (k == 100)
                {
                    list_log.Remove(list_log[0]);
                    k++;
                }
                s = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss     ") + s;
                list_log.Add(s);
                k++;
            }
            //收到数量
            public long m_lReceiveNum = 0;
            //处理数量
            public long m_lRunNum = 0;
            //丢弃数量
            public long m_lDropNum = 0;
        }

        #endregion

    }
}
