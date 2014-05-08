namespace CTP_TRADER
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TSS_TRADERDAY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSS_MDConnState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSS_MDLoginState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSS_TDConnState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSS_TDLoginState = new System.Windows.Forms.ToolStripStatusLabel();
            this.TabPage_Login = new System.Windows.Forms.TabPage();
            this.GroupBox_Login = new System.Windows.Forms.GroupBox();
            this.comboBox_ResumeType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.radioButton_FileDB = new System.Windows.Forms.RadioButton();
            this.radioButton_MemDB = new System.Windows.Forms.RadioButton();
            this.Button_Loginout = new System.Windows.Forms.Button();
            this.Button_Connect = new System.Windows.Forms.Button();
            this.TextBox_PassWord = new System.Windows.Forms.TextBox();
            this.TextBox_UserID = new System.Windows.Forms.TextBox();
            this.TextBox_BrokerID = new System.Windows.Forms.TextBox();
            this.TextBox_TDADDRESS = new System.Windows.Forms.TextBox();
            this.TextBox_MDADDRESS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_Login = new System.Windows.Forms.Button();
            this.Button_Edit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage_RegistInstrument = new System.Windows.Forms.TabPage();
            this.持仓管理 = new System.Windows.Forms.GroupBox();
            this.GridView_InvestorPositionDetail = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_InvestorPositionDetail = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.报单查看 = new System.Windows.Forms.GroupBox();
            this.GridView_RtnOrder = new System.Windows.Forms.DataGridView();
            this.手工交易 = new System.Windows.Forms.GroupBox();
            this.checkBox_ResetAfterSend = new System.Windows.Forms.CheckBox();
            this.button_OrderSendReset = new System.Windows.Forms.Button();
            this.button_SetMinVolumeEQOrderNum = new System.Windows.Forms.Button();
            this.numericUpDown_MinVolume = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox_TimeCondition = new System.Windows.Forms.ComboBox();
            this.comboBox_ContingentCondition = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_VolumeCondition = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioButton_HedgeFlagHedge = new System.Windows.Forms.RadioButton();
            this.radioButton_HedgeFlagSpeculation = new System.Windows.Forms.RadioButton();
            this.radioButton_HedgeFlagArbitrage = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown_OrderNumber = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.Button_OrderInput = new System.Windows.Forms.Button();
            this.品种名称 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton_CloseALL = new System.Windows.Forms.RadioButton();
            this.radioButton_CloseYestoday = new System.Windows.Forms.RadioButton();
            this.radioButton_Open = new System.Windows.Forms.RadioButton();
            this.radioButton_CloseToday = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButton_Buy = new System.Windows.Forms.RadioButton();
            this.radioButton_Sell = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_OrderPrice = new System.Windows.Forms.TextBox();
            this.radioButton_AnyPrice = new System.Windows.Forms.RadioButton();
            this.radioButton_LimitePrice = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.价格条件 = new System.Windows.Forms.Label();
            this.TextBox_Trader_InstrumentName = new System.Windows.Forms.TextBox();
            this.行情查看 = new System.Windows.Forms.GroupBox();
            this.GridView_DeepInstrument = new System.Windows.Forms.DataGridView();
            this.可供订阅的合约 = new System.Windows.Forms.GroupBox();
            this.Button_reload = new System.Windows.Forms.Button();
            this.Button_Regedit = new System.Windows.Forms.Button();
            this.GridView_RegistInstrument_Data = new System.Windows.Forms.DataGridView();
            this.选择合约种类 = new System.Windows.Forms.Label();
            this.Button_Filter = new System.Windows.Forms.Button();
            this.comboBox_ProductID = new System.Windows.Forms.ComboBox();
            this.tabPage_PolicyStart = new System.Windows.Forms.TabPage();
            this.队列日志 = new System.Windows.Forms.GroupBox();
            this.label_PolicyQueueNum = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button_PolicyRefresh = new System.Windows.Forms.Button();
            this.button_PolicyStop = new System.Windows.Forms.Button();
            this.listBox_PolicyLogList = new System.Windows.Forms.ListBox();
            this.label_PolicyDropNum = new System.Windows.Forms.Label();
            this.label_PolicyRunNum = new System.Windows.Forms.Label();
            this.label_PolicyReceiveNum = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button_PolicyStart = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.策略列表 = new System.Windows.Forms.GroupBox();
            this.listBox_PolicyList = new System.Windows.Forms.ListBox();
            this.statusStrip1.SuspendLayout();
            this.TabPage_Login.SuspendLayout();
            this.GroupBox_Login.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabPage_RegistInstrument.SuspendLayout();
            this.持仓管理.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView_InvestorPositionDetail)).BeginInit();
            this.contextMenuStrip_InvestorPositionDetail.SuspendLayout();
            this.报单查看.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView_RtnOrder)).BeginInit();
            this.手工交易.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinVolume)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_OrderNumber)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.行情查看.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView_DeepInstrument)).BeginInit();
            this.可供订阅的合约.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView_RegistInstrument_Data)).BeginInit();
            this.tabPage_PolicyStart.SuspendLayout();
            this.队列日志.SuspendLayout();
            this.策略列表.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSS_TRADERDAY,
            this.toolStripStatusLabel1,
            this.TSS_MDConnState,
            this.toolStripStatusLabel2,
            this.TSS_MDLoginState,
            this.toolStripStatusLabel3,
            this.TSS_TDConnState,
            this.toolStripStatusLabel4,
            this.TSS_TDLoginState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 712);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TSS_TRADERDAY
            // 
            this.TSS_TRADERDAY.Name = "TSS_TRADERDAY";
            this.TSS_TRADERDAY.Size = new System.Drawing.Size(119, 17);
            this.TSS_TRADERDAY.Text = "当前交易日: 未 知  ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel1.Text = "行情连接状态:";
            // 
            // TSS_MDConnState
            // 
            this.TSS_MDConnState.Name = "TSS_MDConnState";
            this.TSS_MDConnState.Size = new System.Drawing.Size(41, 17);
            this.TSS_MDConnState.Text = "未连接";
            this.TSS_MDConnState.TextChanged += new System.EventHandler(this.TSS_MDConnState_TextChanged);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel2.Text = "行情登录状态:";
            // 
            // TSS_MDLoginState
            // 
            this.TSS_MDLoginState.Name = "TSS_MDLoginState";
            this.TSS_MDLoginState.Size = new System.Drawing.Size(41, 17);
            this.TSS_MDLoginState.Text = "未登录";
            this.TSS_MDLoginState.TextChanged += new System.EventHandler(this.TSS_MDLoginState_TextChanged);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel3.Text = "交易连接状态:";
            // 
            // TSS_TDConnState
            // 
            this.TSS_TDConnState.Name = "TSS_TDConnState";
            this.TSS_TDConnState.Size = new System.Drawing.Size(41, 17);
            this.TSS_TDConnState.Text = "未连接";
            this.TSS_TDConnState.TextChanged += new System.EventHandler(this.TSS_TDConnState_TextChanged);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel4.Text = "交易登录状态:";
            // 
            // TSS_TDLoginState
            // 
            this.TSS_TDLoginState.Name = "TSS_TDLoginState";
            this.TSS_TDLoginState.Size = new System.Drawing.Size(41, 17);
            this.TSS_TDLoginState.Text = "未登录";
            this.TSS_TDLoginState.TextChanged += new System.EventHandler(this.TSS_TDLoginState_TextChanged);
            // 
            // TabPage_Login
            // 
            this.TabPage_Login.Controls.Add(this.GroupBox_Login);
            this.TabPage_Login.Location = new System.Drawing.Point(4, 21);
            this.TabPage_Login.Name = "TabPage_Login";
            this.TabPage_Login.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Login.Size = new System.Drawing.Size(1008, 684);
            this.TabPage_Login.TabIndex = 4;
            this.TabPage_Login.Text = "用户登录";
            this.TabPage_Login.UseVisualStyleBackColor = true;
            // 
            // GroupBox_Login
            // 
            this.GroupBox_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GroupBox_Login.AutoSize = true;
            this.GroupBox_Login.Controls.Add(this.comboBox_ResumeType);
            this.GroupBox_Login.Controls.Add(this.label11);
            this.GroupBox_Login.Controls.Add(this.label10);
            this.GroupBox_Login.Controls.Add(this.radioButton_FileDB);
            this.GroupBox_Login.Controls.Add(this.radioButton_MemDB);
            this.GroupBox_Login.Controls.Add(this.Button_Loginout);
            this.GroupBox_Login.Controls.Add(this.Button_Connect);
            this.GroupBox_Login.Controls.Add(this.TextBox_PassWord);
            this.GroupBox_Login.Controls.Add(this.TextBox_UserID);
            this.GroupBox_Login.Controls.Add(this.TextBox_BrokerID);
            this.GroupBox_Login.Controls.Add(this.TextBox_TDADDRESS);
            this.GroupBox_Login.Controls.Add(this.TextBox_MDADDRESS);
            this.GroupBox_Login.Controls.Add(this.label5);
            this.GroupBox_Login.Controls.Add(this.label4);
            this.GroupBox_Login.Controls.Add(this.label3);
            this.GroupBox_Login.Controls.Add(this.label2);
            this.GroupBox_Login.Controls.Add(this.label1);
            this.GroupBox_Login.Controls.Add(this.Button_Login);
            this.GroupBox_Login.Controls.Add(this.Button_Edit);
            this.GroupBox_Login.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GroupBox_Login.Location = new System.Drawing.Point(242, 133);
            this.GroupBox_Login.MaximumSize = new System.Drawing.Size(525, 390);
            this.GroupBox_Login.MinimumSize = new System.Drawing.Size(525, 390);
            this.GroupBox_Login.Name = "GroupBox_Login";
            this.GroupBox_Login.Size = new System.Drawing.Size(525, 390);
            this.GroupBox_Login.TabIndex = 24;
            this.GroupBox_Login.TabStop = false;
            this.GroupBox_Login.Text = "登录设置";
            // 
            // comboBox_ResumeType
            // 
            this.comboBox_ResumeType.FormattingEnabled = true;
            this.comboBox_ResumeType.Items.AddRange(new object[] {
            "登入以后",
            "断线恢复",
            "当天全部"});
            this.comboBox_ResumeType.Location = new System.Drawing.Point(196, 240);
            this.comboBox_ResumeType.Name = "comboBox_ResumeType";
            this.comboBox_ResumeType.Size = new System.Drawing.Size(198, 20);
            this.comboBox_ResumeType.TabIndex = 31;
            this.comboBox_ResumeType.Text = "登入以后";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(131, 243);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "通讯模式:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(131, 209);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "数据存储:";
            // 
            // radioButton_FileDB
            // 
            this.radioButton_FileDB.AutoSize = true;
            this.radioButton_FileDB.Location = new System.Drawing.Point(298, 207);
            this.radioButton_FileDB.Name = "radioButton_FileDB";
            this.radioButton_FileDB.Size = new System.Drawing.Size(47, 16);
            this.radioButton_FileDB.TabIndex = 28;
            this.radioButton_FileDB.TabStop = true;
            this.radioButton_FileDB.Text = "文件";
            this.radioButton_FileDB.UseVisualStyleBackColor = true;
            // 
            // radioButton_MemDB
            // 
            this.radioButton_MemDB.AutoSize = true;
            this.radioButton_MemDB.Location = new System.Drawing.Point(197, 207);
            this.radioButton_MemDB.Name = "radioButton_MemDB";
            this.radioButton_MemDB.Size = new System.Drawing.Size(47, 16);
            this.radioButton_MemDB.TabIndex = 27;
            this.radioButton_MemDB.TabStop = true;
            this.radioButton_MemDB.Text = "内存";
            this.radioButton_MemDB.UseVisualStyleBackColor = true;
            // 
            // Button_Loginout
            // 
            this.Button_Loginout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Loginout.Enabled = false;
            this.Button_Loginout.Location = new System.Drawing.Point(162, 331);
            this.Button_Loginout.Name = "Button_Loginout";
            this.Button_Loginout.Size = new System.Drawing.Size(75, 23);
            this.Button_Loginout.TabIndex = 25;
            this.Button_Loginout.Text = "注销";
            this.Button_Loginout.UseVisualStyleBackColor = true;
            this.Button_Loginout.Click += new System.EventHandler(this.Button_Loginout_Click);
            // 
            // Button_Connect
            // 
            this.Button_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Connect.Location = new System.Drawing.Point(162, 289);
            this.Button_Connect.Name = "Button_Connect";
            this.Button_Connect.Size = new System.Drawing.Size(75, 23);
            this.Button_Connect.TabIndex = 24;
            this.Button_Connect.Text = "连接";
            this.Button_Connect.UseVisualStyleBackColor = true;
            this.Button_Connect.Click += new System.EventHandler(this.Button_Connect_Click);
            // 
            // TextBox_PassWord
            // 
            this.TextBox_PassWord.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_PassWord.Enabled = false;
            this.TextBox_PassWord.Location = new System.Drawing.Point(196, 172);
            this.TextBox_PassWord.Name = "TextBox_PassWord";
            this.TextBox_PassWord.PasswordChar = '*';
            this.TextBox_PassWord.Size = new System.Drawing.Size(198, 21);
            this.TextBox_PassWord.TabIndex = 23;
            // 
            // TextBox_UserID
            // 
            this.TextBox_UserID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_UserID.Enabled = false;
            this.TextBox_UserID.Location = new System.Drawing.Point(196, 138);
            this.TextBox_UserID.Name = "TextBox_UserID";
            this.TextBox_UserID.Size = new System.Drawing.Size(198, 21);
            this.TextBox_UserID.TabIndex = 22;
            // 
            // TextBox_BrokerID
            // 
            this.TextBox_BrokerID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_BrokerID.Enabled = false;
            this.TextBox_BrokerID.Location = new System.Drawing.Point(196, 104);
            this.TextBox_BrokerID.Name = "TextBox_BrokerID";
            this.TextBox_BrokerID.Size = new System.Drawing.Size(198, 21);
            this.TextBox_BrokerID.TabIndex = 21;
            // 
            // TextBox_TDADDRESS
            // 
            this.TextBox_TDADDRESS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_TDADDRESS.Enabled = false;
            this.TextBox_TDADDRESS.Location = new System.Drawing.Point(196, 70);
            this.TextBox_TDADDRESS.Name = "TextBox_TDADDRESS";
            this.TextBox_TDADDRESS.Size = new System.Drawing.Size(198, 21);
            this.TextBox_TDADDRESS.TabIndex = 20;
            // 
            // TextBox_MDADDRESS
            // 
            this.TextBox_MDADDRESS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_MDADDRESS.Enabled = false;
            this.TextBox_MDADDRESS.Location = new System.Drawing.Point(196, 36);
            this.TextBox_MDADDRESS.Name = "TextBox_MDADDRESS";
            this.TextBox_MDADDRESS.Size = new System.Drawing.Size(198, 21);
            this.TextBox_MDADDRESS.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "交易密码:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "投资者ID:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "BrokerID:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "交易地址:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "行情地址:";
            // 
            // Button_Login
            // 
            this.Button_Login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Login.Enabled = false;
            this.Button_Login.Location = new System.Drawing.Point(288, 289);
            this.Button_Login.Name = "Button_Login";
            this.Button_Login.Size = new System.Drawing.Size(75, 23);
            this.Button_Login.TabIndex = 13;
            this.Button_Login.Text = "登录";
            this.Button_Login.UseVisualStyleBackColor = true;
            this.Button_Login.Click += new System.EventHandler(this.Button_Login_Click);
            // 
            // Button_Edit
            // 
            this.Button_Edit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Edit.Location = new System.Drawing.Point(288, 331);
            this.Button_Edit.Name = "Button_Edit";
            this.Button_Edit.Size = new System.Drawing.Size(75, 23);
            this.Button_Edit.TabIndex = 12;
            this.Button_Edit.Text = "修改";
            this.Button_Edit.UseVisualStyleBackColor = true;
            this.Button_Edit.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TabPage_Login);
            this.tabControl1.Controls.Add(this.TabPage_RegistInstrument);
            this.tabControl1.Controls.Add(this.tabPage_PolicyStart);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(1016, 709);
            this.tabControl1.TabIndex = 2;
            // 
            // TabPage_RegistInstrument
            // 
            this.TabPage_RegistInstrument.Controls.Add(this.持仓管理);
            this.TabPage_RegistInstrument.Controls.Add(this.报单查看);
            this.TabPage_RegistInstrument.Controls.Add(this.手工交易);
            this.TabPage_RegistInstrument.Controls.Add(this.行情查看);
            this.TabPage_RegistInstrument.Controls.Add(this.可供订阅的合约);
            this.TabPage_RegistInstrument.Location = new System.Drawing.Point(4, 21);
            this.TabPage_RegistInstrument.Name = "TabPage_RegistInstrument";
            this.TabPage_RegistInstrument.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_RegistInstrument.Size = new System.Drawing.Size(1008, 684);
            this.TabPage_RegistInstrument.TabIndex = 6;
            this.TabPage_RegistInstrument.Text = "行情管理";
            this.TabPage_RegistInstrument.ToolTipText = "在这里你可以选择你需要订阅的合约.";
            this.TabPage_RegistInstrument.UseVisualStyleBackColor = true;
            // 
            // 持仓管理
            // 
            this.持仓管理.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.持仓管理.Controls.Add(this.GridView_InvestorPositionDetail);
            this.持仓管理.Location = new System.Drawing.Point(305, 464);
            this.持仓管理.Name = "持仓管理";
            this.持仓管理.Size = new System.Drawing.Size(695, 214);
            this.持仓管理.TabIndex = 5;
            this.持仓管理.TabStop = false;
            this.持仓管理.Text = "持仓管理(右键刷新)";
            // 
            // GridView_InvestorPositionDetail
            // 
            this.GridView_InvestorPositionDetail.AllowUserToAddRows = false;
            this.GridView_InvestorPositionDetail.AllowUserToDeleteRows = false;
            this.GridView_InvestorPositionDetail.AllowUserToOrderColumns = true;
            this.GridView_InvestorPositionDetail.AllowUserToResizeRows = false;
            this.GridView_InvestorPositionDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GridView_InvestorPositionDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.GridView_InvestorPositionDetail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GridView_InvestorPositionDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridView_InvestorPositionDetail.ContextMenuStrip = this.contextMenuStrip_InvestorPositionDetail;
            this.GridView_InvestorPositionDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView_InvestorPositionDetail.Location = new System.Drawing.Point(3, 17);
            this.GridView_InvestorPositionDetail.MultiSelect = false;
            this.GridView_InvestorPositionDetail.Name = "GridView_InvestorPositionDetail";
            this.GridView_InvestorPositionDetail.ReadOnly = true;
            this.GridView_InvestorPositionDetail.RowHeadersVisible = false;
            this.GridView_InvestorPositionDetail.RowHeadersWidth = 25;
            this.GridView_InvestorPositionDetail.RowTemplate.Height = 23;
            this.GridView_InvestorPositionDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView_InvestorPositionDetail.Size = new System.Drawing.Size(689, 194);
            this.GridView_InvestorPositionDetail.TabIndex = 0;
            this.GridView_InvestorPositionDetail.TabStop = false;
            // 
            // contextMenuStrip_InvestorPositionDetail
            // 
            this.contextMenuStrip_InvestorPositionDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.contextMenuStrip_InvestorPositionDetail.Name = "contextMenuStrip_InvestorPositionDetail";
            this.contextMenuStrip_InvestorPositionDetail.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip_InvestorPositionDetail.Size = new System.Drawing.Size(95, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem2.Text = "刷新";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // 报单查看
            // 
            this.报单查看.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.报单查看.Controls.Add(this.GridView_RtnOrder);
            this.报单查看.Location = new System.Drawing.Point(305, 222);
            this.报单查看.Name = "报单查看";
            this.报单查看.Size = new System.Drawing.Size(695, 236);
            this.报单查看.TabIndex = 4;
            this.报单查看.TabStop = false;
            this.报单查看.Text = "报单查看(双击可撤单)";
            // 
            // GridView_RtnOrder
            // 
            this.GridView_RtnOrder.AllowUserToAddRows = false;
            this.GridView_RtnOrder.AllowUserToDeleteRows = false;
            this.GridView_RtnOrder.AllowUserToOrderColumns = true;
            this.GridView_RtnOrder.AllowUserToResizeRows = false;
            this.GridView_RtnOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GridView_RtnOrder.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GridView_RtnOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridView_RtnOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView_RtnOrder.Location = new System.Drawing.Point(3, 17);
            this.GridView_RtnOrder.MultiSelect = false;
            this.GridView_RtnOrder.Name = "GridView_RtnOrder";
            this.GridView_RtnOrder.ReadOnly = true;
            this.GridView_RtnOrder.RowHeadersVisible = false;
            this.GridView_RtnOrder.RowHeadersWidth = 25;
            this.GridView_RtnOrder.RowTemplate.Height = 23;
            this.GridView_RtnOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView_RtnOrder.Size = new System.Drawing.Size(689, 216);
            this.GridView_RtnOrder.TabIndex = 0;
            this.GridView_RtnOrder.TabStop = false;
            this.GridView_RtnOrder.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridView_RtnOrder_CellMouseDoubleClick);
            // 
            // 手工交易
            // 
            this.手工交易.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.手工交易.Controls.Add(this.checkBox_ResetAfterSend);
            this.手工交易.Controls.Add(this.button_OrderSendReset);
            this.手工交易.Controls.Add(this.button_SetMinVolumeEQOrderNum);
            this.手工交易.Controls.Add(this.numericUpDown_MinVolume);
            this.手工交易.Controls.Add(this.label15);
            this.手工交易.Controls.Add(this.label14);
            this.手工交易.Controls.Add(this.comboBox_TimeCondition);
            this.手工交易.Controls.Add(this.comboBox_ContingentCondition);
            this.手工交易.Controls.Add(this.label13);
            this.手工交易.Controls.Add(this.label12);
            this.手工交易.Controls.Add(this.comboBox_VolumeCondition);
            this.手工交易.Controls.Add(this.panel4);
            this.手工交易.Controls.Add(this.label9);
            this.手工交易.Controls.Add(this.numericUpDown_OrderNumber);
            this.手工交易.Controls.Add(this.label6);
            this.手工交易.Controls.Add(this.Button_OrderInput);
            this.手工交易.Controls.Add(this.品种名称);
            this.手工交易.Controls.Add(this.panel3);
            this.手工交易.Controls.Add(this.label8);
            this.手工交易.Controls.Add(this.panel2);
            this.手工交易.Controls.Add(this.panel1);
            this.手工交易.Controls.Add(this.label7);
            this.手工交易.Controls.Add(this.价格条件);
            this.手工交易.Controls.Add(this.TextBox_Trader_InstrumentName);
            this.手工交易.Location = new System.Drawing.Point(3, 222);
            this.手工交易.Name = "手工交易";
            this.手工交易.Size = new System.Drawing.Size(298, 459);
            this.手工交易.TabIndex = 3;
            this.手工交易.TabStop = false;
            this.手工交易.Text = "手工交易";
            // 
            // checkBox_ResetAfterSend
            // 
            this.checkBox_ResetAfterSend.AutoSize = true;
            this.checkBox_ResetAfterSend.Checked = true;
            this.checkBox_ResetAfterSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ResetAfterSend.Location = new System.Drawing.Point(112, 434);
            this.checkBox_ResetAfterSend.Name = "checkBox_ResetAfterSend";
            this.checkBox_ResetAfterSend.Size = new System.Drawing.Size(180, 16);
            this.checkBox_ResetAfterSend.TabIndex = 26;
            this.checkBox_ResetAfterSend.Text = "发完单后重置(避免多次发单)";
            this.checkBox_ResetAfterSend.UseVisualStyleBackColor = true;
            // 
            // button_OrderSendReset
            // 
            this.button_OrderSendReset.Location = new System.Drawing.Point(173, 402);
            this.button_OrderSendReset.Name = "button_OrderSendReset";
            this.button_OrderSendReset.Size = new System.Drawing.Size(75, 23);
            this.button_OrderSendReset.TabIndex = 17;
            this.button_OrderSendReset.Text = "重置";
            this.button_OrderSendReset.UseVisualStyleBackColor = true;
            this.button_OrderSendReset.Click += new System.EventHandler(this.button_OrderSendReset_Click);
            // 
            // button_SetMinVolumeEQOrderNum
            // 
            this.button_SetMinVolumeEQOrderNum.Location = new System.Drawing.Point(136, 358);
            this.button_SetMinVolumeEQOrderNum.Name = "button_SetMinVolumeEQOrderNum";
            this.button_SetMinVolumeEQOrderNum.Size = new System.Drawing.Size(24, 21);
            this.button_SetMinVolumeEQOrderNum.TabIndex = 14;
            this.button_SetMinVolumeEQOrderNum.Text = "=";
            this.button_SetMinVolumeEQOrderNum.UseVisualStyleBackColor = true;
            this.button_SetMinVolumeEQOrderNum.Click += new System.EventHandler(this.button_SetMinVolumeEQOrderNum_Click);
            // 
            // numericUpDown_MinVolume
            // 
            this.numericUpDown_MinVolume.Location = new System.Drawing.Point(231, 358);
            this.numericUpDown_MinVolume.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown_MinVolume.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_MinVolume.Name = "numericUpDown_MinVolume";
            this.numericUpDown_MinVolume.Size = new System.Drawing.Size(50, 21);
            this.numericUpDown_MinVolume.TabIndex = 15;
            this.numericUpDown_MinVolume.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(166, 362);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 22;
            this.label15.Text = "最小成交:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 321);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 21;
            this.label14.Text = "有效期限:";
            // 
            // comboBox_TimeCondition
            // 
            this.comboBox_TimeCondition.FormattingEnabled = true;
            this.comboBox_TimeCondition.Items.AddRange(new object[] {
            "立即完成",
            "本节有效",
            "当日有效",
            "指定日期前有效",
            "撤销前有效",
            "集合竞价有效"});
            this.comboBox_TimeCondition.Location = new System.Drawing.Point(71, 318);
            this.comboBox_TimeCondition.Name = "comboBox_TimeCondition";
            this.comboBox_TimeCondition.Size = new System.Drawing.Size(154, 20);
            this.comboBox_TimeCondition.TabIndex = 12;
            this.comboBox_TimeCondition.Text = "立即完成";
            // 
            // comboBox_ContingentCondition
            // 
            this.comboBox_ContingentCondition.FormattingEnabled = true;
            this.comboBox_ContingentCondition.Items.AddRange(new object[] {
            "立即",
            "止损",
            "止赢",
            "预埋单",
            "最新价大于条件价",
            "最新价大于等于条件价",
            "最新价小于条件价",
            "最新价小于等于条件价",
            "卖一价大于条件价",
            "卖一价大于等于条件价",
            "卖一价小于条件价",
            "卖一价小于等于条件价",
            "买一价大于条件价",
            "买一价大于等于条件价",
            "买一价小于条件价",
            "买一价小于等于条件价"});
            this.comboBox_ContingentCondition.Location = new System.Drawing.Point(71, 236);
            this.comboBox_ContingentCondition.Name = "comboBox_ContingentCondition";
            this.comboBox_ContingentCondition.Size = new System.Drawing.Size(154, 20);
            this.comboBox_ContingentCondition.TabIndex = 10;
            this.comboBox_ContingentCondition.Text = "立即";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 239);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 18;
            this.label13.Text = "触发条件:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 280);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 17;
            this.label12.Text = "成交数量:";
            // 
            // comboBox_VolumeCondition
            // 
            this.comboBox_VolumeCondition.FormattingEnabled = true;
            this.comboBox_VolumeCondition.Items.AddRange(new object[] {
            "任意数量",
            "最小数量",
            "全部数量"});
            this.comboBox_VolumeCondition.Location = new System.Drawing.Point(71, 277);
            this.comboBox_VolumeCondition.Name = "comboBox_VolumeCondition";
            this.comboBox_VolumeCondition.Size = new System.Drawing.Size(154, 20);
            this.comboBox_VolumeCondition.TabIndex = 11;
            this.comboBox_VolumeCondition.Text = "任意数量";
            // 
            // panel4
            // 
            this.panel4.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panel4.Controls.Add(this.radioButton_HedgeFlagHedge);
            this.panel4.Controls.Add(this.radioButton_HedgeFlagSpeculation);
            this.panel4.Controls.Add(this.radioButton_HedgeFlagArbitrage);
            this.panel4.Location = new System.Drawing.Point(71, 189);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(221, 30);
            this.panel4.TabIndex = 9;
            // 
            // radioButton_HedgeFlagHedge
            // 
            this.radioButton_HedgeFlagHedge.AutoSize = true;
            this.radioButton_HedgeFlagHedge.Location = new System.Drawing.Point(107, 6);
            this.radioButton_HedgeFlagHedge.Name = "radioButton_HedgeFlagHedge";
            this.radioButton_HedgeFlagHedge.Size = new System.Drawing.Size(47, 16);
            this.radioButton_HedgeFlagHedge.TabIndex = 4;
            this.radioButton_HedgeFlagHedge.Text = "套保";
            this.radioButton_HedgeFlagHedge.UseVisualStyleBackColor = true;
            // 
            // radioButton_HedgeFlagSpeculation
            // 
            this.radioButton_HedgeFlagSpeculation.AutoSize = true;
            this.radioButton_HedgeFlagSpeculation.Checked = true;
            this.radioButton_HedgeFlagSpeculation.Location = new System.Drawing.Point(3, 6);
            this.radioButton_HedgeFlagSpeculation.Name = "radioButton_HedgeFlagSpeculation";
            this.radioButton_HedgeFlagSpeculation.Size = new System.Drawing.Size(47, 16);
            this.radioButton_HedgeFlagSpeculation.TabIndex = 2;
            this.radioButton_HedgeFlagSpeculation.TabStop = true;
            this.radioButton_HedgeFlagSpeculation.Text = "投机";
            this.radioButton_HedgeFlagSpeculation.UseVisualStyleBackColor = true;
            // 
            // radioButton_HedgeFlagArbitrage
            // 
            this.radioButton_HedgeFlagArbitrage.AutoSize = true;
            this.radioButton_HedgeFlagArbitrage.Location = new System.Drawing.Point(55, 6);
            this.radioButton_HedgeFlagArbitrage.Name = "radioButton_HedgeFlagArbitrage";
            this.radioButton_HedgeFlagArbitrage.Size = new System.Drawing.Size(47, 16);
            this.radioButton_HedgeFlagArbitrage.TabIndex = 3;
            this.radioButton_HedgeFlagArbitrage.Text = "套利";
            this.radioButton_HedgeFlagArbitrage.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "投机套保:";
            // 
            // numericUpDown_OrderNumber
            // 
            this.numericUpDown_OrderNumber.Location = new System.Drawing.Point(71, 358);
            this.numericUpDown_OrderNumber.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.numericUpDown_OrderNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_OrderNumber.Name = "numericUpDown_OrderNumber";
            this.numericUpDown_OrderNumber.Size = new System.Drawing.Size(50, 21);
            this.numericUpDown_OrderNumber.TabIndex = 13;
            this.numericUpDown_OrderNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "报单数量:";
            // 
            // Button_OrderInput
            // 
            this.Button_OrderInput.Location = new System.Drawing.Point(51, 402);
            this.Button_OrderInput.Name = "Button_OrderInput";
            this.Button_OrderInput.Size = new System.Drawing.Size(75, 23);
            this.Button_OrderInput.TabIndex = 16;
            this.Button_OrderInput.Text = "发单";
            this.Button_OrderInput.UseVisualStyleBackColor = true;
            this.Button_OrderInput.Click += new System.EventHandler(this.Button_OrderInput_Click);
            // 
            // 品种名称
            // 
            this.品种名称.AutoSize = true;
            this.品种名称.Location = new System.Drawing.Point(6, 34);
            this.品种名称.Name = "品种名称";
            this.品种名称.Size = new System.Drawing.Size(59, 12);
            this.品种名称.TabIndex = 11;
            this.品种名称.Text = "品种名称:";
            // 
            // panel3
            // 
            this.panel3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.panel3.Controls.Add(this.radioButton_CloseALL);
            this.panel3.Controls.Add(this.radioButton_CloseYestoday);
            this.panel3.Controls.Add(this.radioButton_Open);
            this.panel3.Controls.Add(this.radioButton_CloseToday);
            this.panel3.Location = new System.Drawing.Point(71, 148);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(221, 30);
            this.panel3.TabIndex = 8;
            // 
            // radioButton_CloseALL
            // 
            this.radioButton_CloseALL.AutoSize = true;
            this.radioButton_CloseALL.Location = new System.Drawing.Point(55, 6);
            this.radioButton_CloseALL.Name = "radioButton_CloseALL";
            this.radioButton_CloseALL.Size = new System.Drawing.Size(47, 16);
            this.radioButton_CloseALL.TabIndex = 5;
            this.radioButton_CloseALL.TabStop = true;
            this.radioButton_CloseALL.Text = "平仓";
            this.radioButton_CloseALL.UseVisualStyleBackColor = true;
            // 
            // radioButton_CloseYestoday
            // 
            this.radioButton_CloseYestoday.AutoSize = true;
            this.radioButton_CloseYestoday.Location = new System.Drawing.Point(159, 6);
            this.radioButton_CloseYestoday.Name = "radioButton_CloseYestoday";
            this.radioButton_CloseYestoday.Size = new System.Drawing.Size(47, 16);
            this.radioButton_CloseYestoday.TabIndex = 4;
            this.radioButton_CloseYestoday.Text = "平昨";
            this.radioButton_CloseYestoday.UseVisualStyleBackColor = true;
            // 
            // radioButton_Open
            // 
            this.radioButton_Open.AutoSize = true;
            this.radioButton_Open.Checked = true;
            this.radioButton_Open.Location = new System.Drawing.Point(3, 6);
            this.radioButton_Open.Name = "radioButton_Open";
            this.radioButton_Open.Size = new System.Drawing.Size(47, 16);
            this.radioButton_Open.TabIndex = 2;
            this.radioButton_Open.TabStop = true;
            this.radioButton_Open.Text = "开仓";
            this.radioButton_Open.UseVisualStyleBackColor = true;
            // 
            // radioButton_CloseToday
            // 
            this.radioButton_CloseToday.AutoSize = true;
            this.radioButton_CloseToday.Location = new System.Drawing.Point(107, 6);
            this.radioButton_CloseToday.Name = "radioButton_CloseToday";
            this.radioButton_CloseToday.Size = new System.Drawing.Size(47, 16);
            this.radioButton_CloseToday.TabIndex = 3;
            this.radioButton_CloseToday.Text = "平今";
            this.radioButton_CloseToday.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "开平标识:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton_Buy);
            this.panel2.Controls.Add(this.radioButton_Sell);
            this.panel2.Location = new System.Drawing.Point(71, 108);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 30);
            this.panel2.TabIndex = 7;
            // 
            // radioButton_Buy
            // 
            this.radioButton_Buy.AutoSize = true;
            this.radioButton_Buy.Checked = true;
            this.radioButton_Buy.Location = new System.Drawing.Point(3, 6);
            this.radioButton_Buy.Name = "radioButton_Buy";
            this.radioButton_Buy.Size = new System.Drawing.Size(35, 16);
            this.radioButton_Buy.TabIndex = 7;
            this.radioButton_Buy.TabStop = true;
            this.radioButton_Buy.Text = "买";
            this.radioButton_Buy.UseVisualStyleBackColor = true;
            // 
            // radioButton_Sell
            // 
            this.radioButton_Sell.AutoSize = true;
            this.radioButton_Sell.Location = new System.Drawing.Point(55, 6);
            this.radioButton_Sell.Name = "radioButton_Sell";
            this.radioButton_Sell.Size = new System.Drawing.Size(35, 16);
            this.radioButton_Sell.TabIndex = 5;
            this.radioButton_Sell.Text = "卖";
            this.radioButton_Sell.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_OrderPrice);
            this.panel1.Controls.Add(this.radioButton_AnyPrice);
            this.panel1.Controls.Add(this.radioButton_LimitePrice);
            this.panel1.Location = new System.Drawing.Point(71, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 30);
            this.panel1.TabIndex = 6;
            // 
            // textBox_OrderPrice
            // 
            this.textBox_OrderPrice.Enabled = false;
            this.textBox_OrderPrice.Location = new System.Drawing.Point(107, 5);
            this.textBox_OrderPrice.Name = "textBox_OrderPrice";
            this.textBox_OrderPrice.Size = new System.Drawing.Size(99, 21);
            this.textBox_OrderPrice.TabIndex = 3;
            // 
            // radioButton_AnyPrice
            // 
            this.radioButton_AnyPrice.AutoSize = true;
            this.radioButton_AnyPrice.Checked = true;
            this.radioButton_AnyPrice.Location = new System.Drawing.Point(3, 6);
            this.radioButton_AnyPrice.Name = "radioButton_AnyPrice";
            this.radioButton_AnyPrice.Size = new System.Drawing.Size(47, 16);
            this.radioButton_AnyPrice.TabIndex = 6;
            this.radioButton_AnyPrice.TabStop = true;
            this.radioButton_AnyPrice.Text = "任意";
            this.radioButton_AnyPrice.UseVisualStyleBackColor = true;
            // 
            // radioButton_LimitePrice
            // 
            this.radioButton_LimitePrice.AutoSize = true;
            this.radioButton_LimitePrice.Location = new System.Drawing.Point(55, 6);
            this.radioButton_LimitePrice.Name = "radioButton_LimitePrice";
            this.radioButton_LimitePrice.Size = new System.Drawing.Size(47, 16);
            this.radioButton_LimitePrice.TabIndex = 2;
            this.radioButton_LimitePrice.Text = "限价";
            this.radioButton_LimitePrice.UseVisualStyleBackColor = true;
            this.radioButton_LimitePrice.CheckedChanged += new System.EventHandler(this.radioButton_LimitePrice_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "买卖方向:";
            // 
            // 价格条件
            // 
            this.价格条件.AutoSize = true;
            this.价格条件.Location = new System.Drawing.Point(6, 75);
            this.价格条件.Name = "价格条件";
            this.价格条件.Size = new System.Drawing.Size(59, 12);
            this.价格条件.TabIndex = 1;
            this.价格条件.Text = "价格条件:";
            // 
            // TextBox_Trader_InstrumentName
            // 
            this.TextBox_Trader_InstrumentName.Location = new System.Drawing.Point(71, 31);
            this.TextBox_Trader_InstrumentName.Name = "TextBox_Trader_InstrumentName";
            this.TextBox_Trader_InstrumentName.Size = new System.Drawing.Size(120, 21);
            this.TextBox_Trader_InstrumentName.TabIndex = 5;
            // 
            // 行情查看
            // 
            this.行情查看.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.行情查看.Controls.Add(this.GridView_DeepInstrument);
            this.行情查看.Location = new System.Drawing.Point(305, 6);
            this.行情查看.Name = "行情查看";
            this.行情查看.Size = new System.Drawing.Size(695, 210);
            this.行情查看.TabIndex = 2;
            this.行情查看.TabStop = false;
            this.行情查看.Text = "行情查看(左键双击查看明细,右键双击取消订阅)";
            // 
            // GridView_DeepInstrument
            // 
            this.GridView_DeepInstrument.AllowUserToAddRows = false;
            this.GridView_DeepInstrument.AllowUserToDeleteRows = false;
            this.GridView_DeepInstrument.AllowUserToOrderColumns = true;
            this.GridView_DeepInstrument.AllowUserToResizeRows = false;
            this.GridView_DeepInstrument.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GridView_DeepInstrument.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GridView_DeepInstrument.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridView_DeepInstrument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridView_DeepInstrument.Location = new System.Drawing.Point(3, 17);
            this.GridView_DeepInstrument.MultiSelect = false;
            this.GridView_DeepInstrument.Name = "GridView_DeepInstrument";
            this.GridView_DeepInstrument.ReadOnly = true;
            this.GridView_DeepInstrument.RowHeadersVisible = false;
            this.GridView_DeepInstrument.RowHeadersWidth = 25;
            this.GridView_DeepInstrument.RowTemplate.Height = 23;
            this.GridView_DeepInstrument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView_DeepInstrument.Size = new System.Drawing.Size(689, 190);
            this.GridView_DeepInstrument.TabIndex = 3;
            this.GridView_DeepInstrument.TabStop = false;
            this.GridView_DeepInstrument.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InstrumentGridView_CellMouseClick);
            this.GridView_DeepInstrument.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InstrumentGridView_CellMouseDoubleClick);
            // 
            // 可供订阅的合约
            // 
            this.可供订阅的合约.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.可供订阅的合约.Controls.Add(this.Button_reload);
            this.可供订阅的合约.Controls.Add(this.Button_Regedit);
            this.可供订阅的合约.Controls.Add(this.GridView_RegistInstrument_Data);
            this.可供订阅的合约.Controls.Add(this.选择合约种类);
            this.可供订阅的合约.Controls.Add(this.Button_Filter);
            this.可供订阅的合约.Controls.Add(this.comboBox_ProductID);
            this.可供订阅的合约.Location = new System.Drawing.Point(3, 6);
            this.可供订阅的合约.Name = "可供订阅的合约";
            this.可供订阅的合约.Size = new System.Drawing.Size(296, 210);
            this.可供订阅的合约.TabIndex = 0;
            this.可供订阅的合约.TabStop = false;
            this.可供订阅的合约.Text = "可供订阅的合约";
            // 
            // Button_reload
            // 
            this.Button_reload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_reload.Location = new System.Drawing.Point(29, 41);
            this.Button_reload.Name = "Button_reload";
            this.Button_reload.Size = new System.Drawing.Size(75, 23);
            this.Button_reload.TabIndex = 1;
            this.Button_reload.Text = "刷新";
            this.Button_reload.UseVisualStyleBackColor = true;
            this.Button_reload.Click += new System.EventHandler(this.Button_reload_Click);
            // 
            // Button_Regedit
            // 
            this.Button_Regedit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Regedit.Location = new System.Drawing.Point(193, 41);
            this.Button_Regedit.Name = "Button_Regedit";
            this.Button_Regedit.Size = new System.Drawing.Size(75, 23);
            this.Button_Regedit.TabIndex = 3;
            this.Button_Regedit.Text = "订阅";
            this.Button_Regedit.UseVisualStyleBackColor = true;
            this.Button_Regedit.Click += new System.EventHandler(this.Button_Regedit_Click);
            // 
            // GridView_RegistInstrument_Data
            // 
            this.GridView_RegistInstrument_Data.AllowUserToAddRows = false;
            this.GridView_RegistInstrument_Data.AllowUserToDeleteRows = false;
            this.GridView_RegistInstrument_Data.AllowUserToOrderColumns = true;
            this.GridView_RegistInstrument_Data.AllowUserToResizeRows = false;
            this.GridView_RegistInstrument_Data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GridView_RegistInstrument_Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridView_RegistInstrument_Data.BackgroundColor = System.Drawing.SystemColors.Window;
            this.GridView_RegistInstrument_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridView_RegistInstrument_Data.Location = new System.Drawing.Point(7, 70);
            this.GridView_RegistInstrument_Data.Name = "GridView_RegistInstrument_Data";
            this.GridView_RegistInstrument_Data.ReadOnly = true;
            this.GridView_RegistInstrument_Data.RowHeadersVisible = false;
            this.GridView_RegistInstrument_Data.RowHeadersWidth = 25;
            this.GridView_RegistInstrument_Data.RowTemplate.Height = 23;
            this.GridView_RegistInstrument_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridView_RegistInstrument_Data.Size = new System.Drawing.Size(283, 134);
            this.GridView_RegistInstrument_Data.TabIndex = 2;
            this.GridView_RegistInstrument_Data.TabStop = false;
            // 
            // 选择合约种类
            // 
            this.选择合约种类.AutoSize = true;
            this.选择合约种类.Location = new System.Drawing.Point(11, 17);
            this.选择合约种类.Name = "选择合约种类";
            this.选择合约种类.Size = new System.Drawing.Size(59, 12);
            this.选择合约种类.TabIndex = 3;
            this.选择合约种类.Text = "合约种类:";
            // 
            // Button_Filter
            // 
            this.Button_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Filter.Location = new System.Drawing.Point(111, 41);
            this.Button_Filter.Name = "Button_Filter";
            this.Button_Filter.Size = new System.Drawing.Size(75, 23);
            this.Button_Filter.TabIndex = 2;
            this.Button_Filter.Text = "筛选";
            this.Button_Filter.UseVisualStyleBackColor = true;
            this.Button_Filter.Click += new System.EventHandler(this.Button_Filter_Click);
            // 
            // comboBox_ProductID
            // 
            this.comboBox_ProductID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_ProductID.FormattingEnabled = true;
            this.comboBox_ProductID.ItemHeight = 12;
            this.comboBox_ProductID.Location = new System.Drawing.Point(71, 14);
            this.comboBox_ProductID.Name = "comboBox_ProductID";
            this.comboBox_ProductID.Size = new System.Drawing.Size(177, 20);
            this.comboBox_ProductID.TabIndex = 0;
            this.comboBox_ProductID.TextChanged += new System.EventHandler(this.comboBox_ProductID_TextChanged);
            // 
            // tabPage_PolicyStart
            // 
            this.tabPage_PolicyStart.Controls.Add(this.队列日志);
            this.tabPage_PolicyStart.Controls.Add(this.策略列表);
            this.tabPage_PolicyStart.Location = new System.Drawing.Point(4, 21);
            this.tabPage_PolicyStart.Name = "tabPage_PolicyStart";
            this.tabPage_PolicyStart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_PolicyStart.Size = new System.Drawing.Size(1008, 684);
            this.tabPage_PolicyStart.TabIndex = 7;
            this.tabPage_PolicyStart.Text = "策略启动";
            this.tabPage_PolicyStart.UseVisualStyleBackColor = true;
            // 
            // 队列日志
            // 
            this.队列日志.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.队列日志.Controls.Add(this.label_PolicyQueueNum);
            this.队列日志.Controls.Add(this.label20);
            this.队列日志.Controls.Add(this.button_PolicyRefresh);
            this.队列日志.Controls.Add(this.button_PolicyStop);
            this.队列日志.Controls.Add(this.listBox_PolicyLogList);
            this.队列日志.Controls.Add(this.label_PolicyDropNum);
            this.队列日志.Controls.Add(this.label_PolicyRunNum);
            this.队列日志.Controls.Add(this.label_PolicyReceiveNum);
            this.队列日志.Controls.Add(this.label18);
            this.队列日志.Controls.Add(this.label17);
            this.队列日志.Controls.Add(this.label16);
            this.队列日志.Controls.Add(this.button_PolicyStart);
            this.队列日志.Controls.Add(this.shapeContainer1);
            this.队列日志.Location = new System.Drawing.Point(326, 6);
            this.队列日志.Name = "队列日志";
            this.队列日志.Size = new System.Drawing.Size(676, 674);
            this.队列日志.TabIndex = 5;
            this.队列日志.TabStop = false;
            this.队列日志.Text = "队列日志";
            // 
            // label_PolicyQueueNum
            // 
            this.label_PolicyQueueNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_PolicyQueueNum.AutoSize = true;
            this.label_PolicyQueueNum.Location = new System.Drawing.Point(567, 110);
            this.label_PolicyQueueNum.Name = "label_PolicyQueueNum";
            this.label_PolicyQueueNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_PolicyQueueNum.Size = new System.Drawing.Size(11, 12);
            this.label_PolicyQueueNum.TabIndex = 13;
            this.label_PolicyQueueNum.Text = "0";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(458, 110);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 12;
            this.label20.Text = "队列量";
            // 
            // button_PolicyRefresh
            // 
            this.button_PolicyRefresh.Location = new System.Drawing.Point(292, 34);
            this.button_PolicyRefresh.Name = "button_PolicyRefresh";
            this.button_PolicyRefresh.Size = new System.Drawing.Size(122, 98);
            this.button_PolicyRefresh.TabIndex = 11;
            this.button_PolicyRefresh.Text = "刷新";
            this.button_PolicyRefresh.UseVisualStyleBackColor = true;
            this.button_PolicyRefresh.Click += new System.EventHandler(this.button_PolicyRefresh_Click);
            // 
            // button_PolicyStop
            // 
            this.button_PolicyStop.Location = new System.Drawing.Point(149, 34);
            this.button_PolicyStop.Name = "button_PolicyStop";
            this.button_PolicyStop.Size = new System.Drawing.Size(122, 98);
            this.button_PolicyStop.TabIndex = 10;
            this.button_PolicyStop.Text = "停止";
            this.button_PolicyStop.UseVisualStyleBackColor = true;
            this.button_PolicyStop.Click += new System.EventHandler(this.button_PolicyStop_Click);
            // 
            // listBox_PolicyLogList
            // 
            this.listBox_PolicyLogList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_PolicyLogList.FormattingEnabled = true;
            this.listBox_PolicyLogList.ItemHeight = 12;
            this.listBox_PolicyLogList.Location = new System.Drawing.Point(6, 138);
            this.listBox_PolicyLogList.Name = "listBox_PolicyLogList";
            this.listBox_PolicyLogList.Size = new System.Drawing.Size(662, 532);
            this.listBox_PolicyLogList.TabIndex = 9;
            // 
            // label_PolicyDropNum
            // 
            this.label_PolicyDropNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_PolicyDropNum.AutoSize = true;
            this.label_PolicyDropNum.Location = new System.Drawing.Point(567, 85);
            this.label_PolicyDropNum.Name = "label_PolicyDropNum";
            this.label_PolicyDropNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_PolicyDropNum.Size = new System.Drawing.Size(11, 12);
            this.label_PolicyDropNum.TabIndex = 7;
            this.label_PolicyDropNum.Text = "0";
            // 
            // label_PolicyRunNum
            // 
            this.label_PolicyRunNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_PolicyRunNum.AutoSize = true;
            this.label_PolicyRunNum.Location = new System.Drawing.Point(567, 60);
            this.label_PolicyRunNum.Name = "label_PolicyRunNum";
            this.label_PolicyRunNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_PolicyRunNum.Size = new System.Drawing.Size(11, 12);
            this.label_PolicyRunNum.TabIndex = 6;
            this.label_PolicyRunNum.Text = "0";
            // 
            // label_PolicyReceiveNum
            // 
            this.label_PolicyReceiveNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_PolicyReceiveNum.AutoSize = true;
            this.label_PolicyReceiveNum.Location = new System.Drawing.Point(567, 35);
            this.label_PolicyReceiveNum.Name = "label_PolicyReceiveNum";
            this.label_PolicyReceiveNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label_PolicyReceiveNum.Size = new System.Drawing.Size(11, 12);
            this.label_PolicyReceiveNum.TabIndex = 5;
            this.label_PolicyReceiveNum.Text = "0";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(458, 85);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 4;
            this.label18.Text = "丢弃量";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(458, 60);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 3;
            this.label17.Text = "处理量";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(458, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 2;
            this.label16.Text = "接收量";
            // 
            // button_PolicyStart
            // 
            this.button_PolicyStart.Location = new System.Drawing.Point(6, 34);
            this.button_PolicyStart.Name = "button_PolicyStart";
            this.button_PolicyStart.Size = new System.Drawing.Size(122, 98);
            this.button_PolicyStart.TabIndex = 1;
            this.button_PolicyStart.Text = "启动";
            this.button_PolicyStart.UseVisualStyleBackColor = true;
            this.button_PolicyStart.Click += new System.EventHandler(this.button_PolicySample_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 17);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape4,
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(670, 654);
            this.shapeContainer1.TabIndex = 8;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape4
            // 
            this.lineShape4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 432;
            this.lineShape4.X2 = 661;
            this.lineShape4.Y1 = 33;
            this.lineShape4.Y2 = 33;
            // 
            // lineShape3
            // 
            this.lineShape3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 432;
            this.lineShape3.X2 = 661;
            this.lineShape3.Y1 = 58;
            this.lineShape3.Y2 = 58;
            // 
            // lineShape2
            // 
            this.lineShape2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 432;
            this.lineShape2.X2 = 661;
            this.lineShape2.Y1 = 83;
            this.lineShape2.Y2 = 83;
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 432;
            this.lineShape1.X2 = 661;
            this.lineShape1.Y1 = 108;
            this.lineShape1.Y2 = 108;
            // 
            // 策略列表
            // 
            this.策略列表.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.策略列表.Controls.Add(this.listBox_PolicyList);
            this.策略列表.Location = new System.Drawing.Point(6, 5);
            this.策略列表.Name = "策略列表";
            this.策略列表.Size = new System.Drawing.Size(314, 675);
            this.策略列表.TabIndex = 2;
            this.策略列表.TabStop = false;
            this.策略列表.Text = "策略列表";
            // 
            // listBox_PolicyList
            // 
            this.listBox_PolicyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_PolicyList.FormattingEnabled = true;
            this.listBox_PolicyList.ItemHeight = 12;
            this.listBox_PolicyList.Items.AddRange(new object[] {
            "Sqlite队列",
            "测试策略"});
            this.listBox_PolicyList.Location = new System.Drawing.Point(6, 17);
            this.listBox_PolicyList.Name = "listBox_PolicyList";
            this.listBox_PolicyList.Size = new System.Drawing.Size(302, 652);
            this.listBox_PolicyList.TabIndex = 0;
            this.listBox_PolicyList.SelectedIndexChanged += new System.EventHandler(this.listBox_PolicyList_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "CTP_Trader-南京长发";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closeing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.TabPage_Login.ResumeLayout(false);
            this.TabPage_Login.PerformLayout();
            this.GroupBox_Login.ResumeLayout(false);
            this.GroupBox_Login.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabPage_RegistInstrument.ResumeLayout(false);
            this.持仓管理.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridView_InvestorPositionDetail)).EndInit();
            this.contextMenuStrip_InvestorPositionDetail.ResumeLayout(false);
            this.报单查看.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridView_RtnOrder)).EndInit();
            this.手工交易.ResumeLayout(false);
            this.手工交易.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinVolume)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_OrderNumber)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.行情查看.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridView_DeepInstrument)).EndInit();
            this.可供订阅的合约.ResumeLayout(false);
            this.可供订阅的合约.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridView_RegistInstrument_Data)).EndInit();
            this.tabPage_PolicyStart.ResumeLayout(false);
            this.队列日志.ResumeLayout(false);
            this.队列日志.PerformLayout();
            this.策略列表.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel TSS_MDConnState;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel TSS_MDLoginState;
        private System.Windows.Forms.ToolStripStatusLabel TSS_TRADERDAY;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel TSS_TDConnState;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel TSS_TDLoginState;
        private System.Windows.Forms.TabPage TabPage_Login;
        private System.Windows.Forms.TextBox TextBox_PassWord;
        private System.Windows.Forms.TextBox TextBox_UserID;
        private System.Windows.Forms.TextBox TextBox_BrokerID;
        private System.Windows.Forms.TextBox TextBox_TDADDRESS;
        private System.Windows.Forms.TextBox TextBox_MDADDRESS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Button_Login;
        private System.Windows.Forms.Button Button_Edit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox GroupBox_Login;
        private System.Windows.Forms.TabPage TabPage_RegistInstrument;
        private System.Windows.Forms.GroupBox 可供订阅的合约;
        private System.Windows.Forms.ComboBox comboBox_ProductID;
        private System.Windows.Forms.Button Button_Filter;
        private System.Windows.Forms.DataGridView GridView_RegistInstrument_Data;
        private System.Windows.Forms.Label 选择合约种类;
        private System.Windows.Forms.Button Button_Regedit;
        private System.Windows.Forms.GroupBox 行情查看;
        private System.Windows.Forms.DataGridView GridView_DeepInstrument;
        private System.Windows.Forms.GroupBox 手工交易;
        private System.Windows.Forms.TextBox TextBox_Trader_InstrumentName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton_LimitePrice;
        private System.Windows.Forms.RadioButton radioButton_AnyPrice;
        private System.Windows.Forms.Label 价格条件;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton_Buy;
        private System.Windows.Forms.RadioButton radioButton_Sell;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Button_reload;
        private System.Windows.Forms.Label 品种名称;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton radioButton_Open;
        private System.Windows.Forms.RadioButton radioButton_CloseToday;
        private System.Windows.Forms.Button Button_Connect;
        private System.Windows.Forms.Button Button_Loginout;
        private System.Windows.Forms.Button Button_OrderInput;
        private System.Windows.Forms.GroupBox 报单查看;
        private System.Windows.Forms.GroupBox 持仓管理;
        private System.Windows.Forms.DataGridView GridView_InvestorPositionDetail;
        private System.Windows.Forms.DataGridView GridView_RtnOrder;
        private System.Windows.Forms.TextBox textBox_OrderPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton_CloseYestoday;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_InvestorPositionDetail;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.NumericUpDown numericUpDown_OrderNumber;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radioButton_HedgeFlagHedge;
        private System.Windows.Forms.RadioButton radioButton_HedgeFlagSpeculation;
        private System.Windows.Forms.RadioButton radioButton_HedgeFlagArbitrage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButton_FileDB;
        private System.Windows.Forms.RadioButton radioButton_MemDB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage_PolicyStart;
        private System.Windows.Forms.Button button_PolicyStart;
        private System.Windows.Forms.ComboBox comboBox_ResumeType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton radioButton_CloseALL;
        private System.Windows.Forms.ComboBox comboBox_VolumeCondition;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_ContingentCondition;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox_TimeCondition;
        private System.Windows.Forms.Button button_SetMinVolumeEQOrderNum;
        private System.Windows.Forms.NumericUpDown numericUpDown_MinVolume;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button_OrderSendReset;
        private System.Windows.Forms.CheckBox checkBox_ResetAfterSend;
        private System.Windows.Forms.GroupBox 策略列表;
        private System.Windows.Forms.ListBox listBox_PolicyList;
        private System.Windows.Forms.GroupBox 队列日志;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label_PolicyDropNum;
        private System.Windows.Forms.Label label_PolicyRunNum;
        private System.Windows.Forms.Label label_PolicyReceiveNum;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.ListBox listBox_PolicyLogList;
        private System.Windows.Forms.Button button_PolicyStop;
        private System.Windows.Forms.Button button_PolicyRefresh;
        private System.Windows.Forms.Label label_PolicyQueueNum;
        private System.Windows.Forms.Label label20;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
    }
}

