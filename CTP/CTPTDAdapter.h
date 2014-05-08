/////////////////////////////////////////////////////////////////////////
/// 上期技术 CTP C++ ==> .Net Framework Adapter
/// Author:	shawn666.liu@gmail.com
/// Date: 20120422
/////////////////////////////////////////////////////////////////////////

#pragma once


#include "Util.h"
#include "TdSpi.h"

using namespace Native;

namespace  Native{
	class CTdSpi;
};

namespace CTP {

	/// <summary>
	/// 托管类,TraderAPI Adapter
	/// </summary>
	public ref class CTPTDAdapter
	{
	public:
		/// <summary>
		///创建CTPTDAdapter
		///存贮订阅信息文件的目录，默认为当前目录
		/// </summary>
		CTPTDAdapter(void);
		/// <summary>
		///创建CTPTDAdapter
		/// </summary>
		/// <param name="pszFlowPath">存贮订阅信息文件的目录，默认为当前目录</param>
		CTPTDAdapter(String^ pszFlowPath);
	private:
		~CTPTDAdapter(void);
		CThostFtdcTraderApi* m_pApi;
		CTdSpi* m_pSpi;
	public:
		/// <summary>
		///删除接口对象本身
		///@remark 不再使用本接口对象时,调用该函数删除接口对象
		/// </summary>
		void Release();

		/// <summary>
		///初始化
		///@remark 初始化运行环境,只有调用后,接口才开始工作
		/// </summary>
		void Init();

		/// <summary>
		///等待接口线程结束运行
		///@return 线程退出代码
		/// </summary>
		int Join();

		/// <summary>
		///获取当前交易日
		///@remark 只有登录成功后,才能得到正确的交易日
		/// </summary>
		/// <returns>获取到的交易日</returns>
		String^ GetTradingDay();

		/// <summary>
		///注册前置机网络地址
		///@param pszFrontAddress：前置机网络地址。
		///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:17001”。 
		///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”17001”代表服务器端口号。
		/// </summary>
		void RegisterFront(String^ pszFrontAddress);

		/// <summary>
		///注册名字服务器网络地址
		///@param pszNsAddress：名字服务器网络地址。
		///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:12001”。 
		///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”12001”代表服务器端口号。
		///@remark RegisterNameServer优先于RegisterFront
		/// </summary>
		void RegisterNameServer(String^ pszNsAddress);

		///注册回调接口
		///@param pSpi 派生自回调接口类的实例
		/// void RegisterSpi(ThostFtdcTraderSpi^ pSpi);

		/// <summary>
		///订阅私有流。
		///@param nResumeType 私有流重传方式  
		///        THOST_TERT_RESTART:从本交易日开始重传
		///        THOST_TERT_RESUME:从上次收到的续传
		///        THOST_TERT_QUICK:只传送登录后私有流的内容
		///@remark 该方法要在Init方法前调用。若不调用则不会收到私有流的数据。
		/// </summary>
		void SubscribePrivateTopic(EnumTeResumeType nResumeType);

		/// <summary>
		///订阅公共流。
		///@param nResumeType 公共流重传方式  
		///        THOST_TERT_RESTART:从本交易日开始重传
		///        THOST_TERT_RESUME:从上次收到的续传
		///        THOST_TERT_QUICK:只传送登录后公共流的内容
		///@remark 该方法要在Init方法前调用。若不调用则不会收到公共流的数据。
		/// </summary>
		void SubscribePublicTopic(EnumTeResumeType nResumeType);

		/// <summary>
		///客户端认证请求
		/// </summary>
		int ReqAuthenticate(ThostFtdcReqAuthenticateField^ pReqAuthenticateField, int nRequestID);

		/// <summary>
		///用户登录请求
		/// </summary>
		int ReqUserLogin(ThostFtdcReqUserLoginField^ pReqUserLoginField, int nRequestID);

		/// <summary>
		///登出请求
		/// </summary>
		int ReqUserLogout(ThostFtdcUserLogoutField^ pUserLogout, int nRequestID);

		/// <summary>
		///用户口令更新请求
		/// </summary>
		int ReqUserPasswordUpdate(ThostFtdcUserPasswordUpdateField^ pUserPasswordUpdate, int nRequestID);

		/// <summary>
		///资金账户口令更新请求
		/// </summary>
		int ReqTradingAccountPasswordUpdate(ThostFtdcTradingAccountPasswordUpdateField^ pTradingAccountPasswordUpdate, int nRequestID);

		/// <summary>
		///报单录入请求
		/// </summary>
		int ReqOrderInsert(ThostFtdcInputOrderField^ pInputOrder, int nRequestID);

		/// <summary>
		///预埋单录入请求
		/// </summary>
		int ReqParkedOrderInsert(ThostFtdcParkedOrderField^ pParkedOrder, int nRequestID);

		/// <summary>
		///预埋撤单录入请求
		/// </summary>
		int ReqParkedOrderAction(ThostFtdcParkedOrderActionField^ pParkedOrderAction, int nRequestID);

		/// <summary>
		///报单操作请求
		/// </summary>
		int ReqOrderAction(ThostFtdcInputOrderActionField^ pInputOrderAction, int nRequestID);

		/// <summary>
		///查询最大报单数量请求
		/// </summary>
		int ReqQueryMaxOrderVolume(ThostFtdcQueryMaxOrderVolumeField^ pQueryMaxOrderVolume, int nRequestID);

		/// <summary>
		///投资者结算结果确认
		/// </summary>
		int ReqSettlementInfoConfirm(ThostFtdcSettlementInfoConfirmField^ pSettlementInfoConfirm, int nRequestID);

		/// <summary>
		///请求删除预埋单
		/// </summary>
		int ReqRemoveParkedOrder(ThostFtdcRemoveParkedOrderField^ pRemoveParkedOrder, int nRequestID);

		/// <summary>
		///请求删除预埋撤单
		/// </summary>
		int ReqRemoveParkedOrderAction(ThostFtdcRemoveParkedOrderActionField^ pRemoveParkedOrderAction, int nRequestID);

		/// <summary>
		///请求查询报单
		/// </summary>
		int ReqQryOrder(ThostFtdcQryOrderField^ pQryOrder, int nRequestID);

		/// <summary>
		///请求查询成交
		/// </summary>
		int ReqQryTrade(ThostFtdcQryTradeField^ pQryTrade, int nRequestID);

		/// <summary>
		///请求查询投资者持仓
		/// </summary>
		int ReqQryInvestorPosition(ThostFtdcQryInvestorPositionField^ pQryInvestorPosition, int nRequestID);

		/// <summary>
		///请求查询资金账户
		/// </summary>
		int ReqQryTradingAccount(ThostFtdcQryTradingAccountField^ pQryTradingAccount, int nRequestID);

		/// <summary>
		///请求查询投资者
		/// </summary>
		int ReqQryInvestor(ThostFtdcQryInvestorField^ pQryInvestor, int nRequestID);

		/// <summary>
		///请求查询交易编码
		/// </summary>
		int ReqQryTradingCode(ThostFtdcQryTradingCodeField^ pQryTradingCode, int nRequestID);

		/// <summary>
		///请求查询合约保证金率
		/// </summary>
		int ReqQryInstrumentMarginRate(ThostFtdcQryInstrumentMarginRateField^ pQryInstrumentMarginRate, int nRequestID);

		/// <summary>
		///请求查询合约手续费率
		/// </summary>
		int ReqQryInstrumentCommissionRate(ThostFtdcQryInstrumentCommissionRateField^ pQryInstrumentCommissionRate, int nRequestID);

		/// <summary>
		///请求查询交易所
		/// </summary>
		int ReqQryExchange(ThostFtdcQryExchangeField^ pQryExchange, int nRequestID);

		/// <summary>
		///请求查询合约
		/// </summary>
		int ReqQryInstrument(ThostFtdcQryInstrumentField^ pQryInstrument, int nRequestID);

		/// <summary>
		///请求查询行情
		/// </summary>
		int ReqQryDepthMarketData(ThostFtdcQryDepthMarketDataField^ pQryDepthMarketData, int nRequestID);

		/// <summary>
		///请求查询投资者结算结果
		/// </summary>
		int ReqQrySettlementInfo(ThostFtdcQrySettlementInfoField^ pQrySettlementInfo, int nRequestID);

		/// <summary>
		///请求查询转帐银行
		/// </summary>
		int ReqQryTransferBank(ThostFtdcQryTransferBankField^ pQryTransferBank, int nRequestID);

		/// <summary>
		///请求查询投资者持仓明细
		/// </summary>
		int ReqQryInvestorPositionDetail(ThostFtdcQryInvestorPositionDetailField^ pQryInvestorPositionDetail, int nRequestID);

		/// <summary>
		///请求查询客户通知
		/// </summary>
		int ReqQryNotice(ThostFtdcQryNoticeField^ pQryNotice, int nRequestID);

		/// <summary>
		///请求查询结算信息确认
		/// </summary>
		int ReqQrySettlementInfoConfirm(ThostFtdcQrySettlementInfoConfirmField^ pQrySettlementInfoConfirm, int nRequestID);

		/// <summary>
		///请求查询投资者持仓明细
		/// </summary>
		int ReqQryInvestorPositionCombineDetail(ThostFtdcQryInvestorPositionCombineDetailField^ pQryInvestorPositionCombineDetail, int nRequestID);

		/// <summary>
		///请求查询保证金监管系统经纪公司资金账户密钥
		/// </summary>
		int ReqQryCFMMCTradingAccountKey(ThostFtdcQryCFMMCTradingAccountKeyField^ pQryCFMMCTradingAccountKey, int nRequestID);

		/// <summary>
		///请求查询仓单折抵信息
		/// </summary>
		int ReqQryEWarrantOffset(ThostFtdcQryEWarrantOffsetField^ pQryEWarrantOffset, int nRequestID);

		/// <summary>
		///请求查询转帐流水
		/// </summary>
		int ReqQryTransferSerial(ThostFtdcQryTransferSerialField^ pQryTransferSerial, int nRequestID);

		/// <summary>
		///请求查询银期签约关系
		/// </summary>
		int ReqQryAccountregister(ThostFtdcQryAccountregisterField^ pQryAccountregister, int nRequestID);

		/// <summary>
		///请求查询签约银行
		/// </summary>
		int ReqQryContractBank(ThostFtdcQryContractBankField^ pQryContractBank, int nRequestID);

		/// <summary>
		///请求查询预埋单
		/// </summary>
		int ReqQryParkedOrder(ThostFtdcQryParkedOrderField^ pQryParkedOrder, int nRequestID);

		/// <summary>
		///请求查询预埋撤单
		/// </summary>
		int ReqQryParkedOrderAction(ThostFtdcQryParkedOrderActionField^ pQryParkedOrderAction, int nRequestID);

		/// <summary>
		///请求查询交易通知
		/// </summary>
		int ReqQryTradingNotice(ThostFtdcQryTradingNoticeField^ pQryTradingNotice, int nRequestID);

		/// <summary>
		///请求查询经纪公司交易参数
		/// </summary>
		int ReqQryBrokerTradingParams(ThostFtdcQryBrokerTradingParamsField^ pQryBrokerTradingParams, int nRequestID);

		/// <summary>
		///请求查询经纪公司交易算法
		/// </summary>
		int ReqQryBrokerTradingAlgos(ThostFtdcQryBrokerTradingAlgosField^ pQryBrokerTradingAlgos, int nRequestID);

		/// <summary>
		///期货发起银行资金转期货请求
		/// </summary>
		int ReqFromBankToFutureByFuture(ThostFtdcReqTransferField^ pReqTransfer, int nRequestID);

		/// <summary>
		///期货发起期货资金转银行请求
		/// </summary>
		int ReqFromFutureToBankByFuture(ThostFtdcReqTransferField^ pReqTransfer, int nRequestID);

		/// <summary>
		///期货发起查询银行余额请求
		/// </summary>
		int ReqQueryBankAccountMoneyByFuture(ThostFtdcReqQueryAccountField^ pReqQueryAccount, int nRequestID);

		// events
	public:
		/// <summary>
		/// 当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
		/// </summary>
		event FrontConnected^ OnFrontConnected {
			void add(FrontConnected^ handler ) {
				FrontConnected_delegate += handler;
			}
			void remove(FrontConnected^ handler) {
				FrontConnected_delegate -= handler;
			}
			void raise() {
				if(FrontConnected_delegate)
					FrontConnected_delegate();
			}
		}

		/// <summary>
		/// 当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
		/// 错误原因
		/// 0x1001 网络读失败
		/// 0x1002 网络写失败
		/// 0x2001 接收心跳超时
		/// 0x2002 发送心跳失败
		/// 0x2003 收到错误报文
		/// </summary>
		event FrontDisconnected^ OnFrontDisconnected {
			void add(FrontDisconnected^ handler ) {
				FrontDisconnected_delegate += handler;
			}
			void remove(FrontDisconnected^ handler) {
				FrontDisconnected_delegate -= handler;
			}
			void raise(int nReason) {
				if(FrontDisconnected_delegate)
					FrontDisconnected_delegate(nReason);
			}
		}

		/// <summary>
		///心跳超时警告。当长时间未收到报文时，该方法被调用。
		///@param nTimeLapse 距离上次接收报文的时间
		/// </summary>
		event HeartBeatWarning^ OnHeartBeatWarning {
			void add(HeartBeatWarning^ handler ) {
				HeartBeatWarning_delegate += handler;
			}
			void remove(HeartBeatWarning^ handler) {
				HeartBeatWarning_delegate -= handler;
			}
			void raise(int nTimeLapse) {
				if(HeartBeatWarning_delegate)
					HeartBeatWarning_delegate(nTimeLapse);
			}
		}

		/// <summary>
		/// 登录请求响应
		/// </summary>
		event RspUserLogin^ OnRspUserLogin {
			void add(RspUserLogin^ handler ) {
				RspUserLogin_delegate += handler;
			}
			void remove(RspUserLogin^ handler) {
				RspUserLogin_delegate -= handler;
			}
			void raise(ThostFtdcRspUserLoginField^ pRspUserLogin, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) { 
				if(RspUserLogin_delegate)
					RspUserLogin_delegate(pRspUserLogin, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 登出请求响应
		/// </summary>
		event RspUserLogout^ OnRspUserLogout {
			void add(RspUserLogout^ handler ) {RspUserLogout_delegate += handler;}
			void remove(RspUserLogout^ handler) {RspUserLogout_delegate -= handler;}
			void raise(ThostFtdcUserLogoutField^ pUserLogout, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) { 
				if(RspUserLogout_delegate) RspUserLogout_delegate(pUserLogout, pRspInfo, nRequestID, bIsLast); }
		}


		/// <summary>
		/// 客户端认证响应
		/// </summary>
		event RspAuthenticate^ OnRspAuthenticate{
			void add(RspAuthenticate^ handler) { RspAuthenticate_delegate += handler; }
			void remove(RspAuthenticate^ handler) { RspAuthenticate_delegate -= handler; }
			void raise(ThostFtdcRspAuthenticateField^ pRspAuthenticateField, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspAuthenticate_delegate) RspAuthenticate_delegate(pRspAuthenticateField, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 用户口令更新请求响应
		/// </summary>
		event RspUserPasswordUpdate^ OnRspUserPasswordUpdate{
			void add(RspUserPasswordUpdate^ handler) { RspUserPasswordUpdate_delegate += handler; }
			void remove(RspUserPasswordUpdate^ handler) { RspUserPasswordUpdate_delegate -= handler; }
			void raise(ThostFtdcUserPasswordUpdateField^ pUserPasswordUpdate, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspUserPasswordUpdate_delegate) RspUserPasswordUpdate_delegate(pUserPasswordUpdate, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 资金账户口令更新请求响应
		/// </summary>
		event RspTradingAccountPasswordUpdate^ OnRspTradingAccountPasswordUpdate{
			void add(RspTradingAccountPasswordUpdate^ handler) { RspTradingAccountPasswordUpdate_delegate += handler; }
			void remove(RspTradingAccountPasswordUpdate^ handler) { RspTradingAccountPasswordUpdate_delegate -= handler; }
			void raise(ThostFtdcTradingAccountPasswordUpdateField^ pTradingAccountPasswordUpdate, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspTradingAccountPasswordUpdate_delegate) RspTradingAccountPasswordUpdate_delegate(pTradingAccountPasswordUpdate, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 报单录入请求响应
		/// </summary>
		event RspOrderInsert^ OnRspOrderInsert{
			void add(RspOrderInsert^ handler) { RspOrderInsert_delegate += handler; }
			void remove(RspOrderInsert^ handler) { RspOrderInsert_delegate -= handler; }
			void raise(ThostFtdcInputOrderField^ pInputOrder, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspOrderInsert_delegate) RspOrderInsert_delegate(pInputOrder, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 预埋单录入请求响应
		/// </summary>
		event RspParkedOrderInsert^ OnRspParkedOrderInsert{
			void add(RspParkedOrderInsert^ handler) { RspParkedOrderInsert_delegate += handler; }
			void remove(RspParkedOrderInsert^ handler) { RspParkedOrderInsert_delegate -= handler; }
			void raise(ThostFtdcParkedOrderField^ pParkedOrder, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspParkedOrderInsert_delegate) RspParkedOrderInsert_delegate(pParkedOrder, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 预埋撤单录入请求响应
		/// </summary>
		event RspParkedOrderAction^ OnRspParkedOrderAction{
			void add(RspParkedOrderAction^ handler) { RspParkedOrderAction_delegate += handler; }
			void remove(RspParkedOrderAction^ handler) { RspParkedOrderAction_delegate -= handler; }
			void raise(ThostFtdcParkedOrderActionField^ pParkedOrderAction, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspParkedOrderAction_delegate) RspParkedOrderAction_delegate(pParkedOrderAction, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 报单操作请求响应
		/// </summary>
		event RspOrderAction^ OnRspOrderAction{
			void add(RspOrderAction^ handler) { RspOrderAction_delegate += handler; }
			void remove(RspOrderAction^ handler) { RspOrderAction_delegate -= handler; }
			void raise(ThostFtdcInputOrderActionField^ pInputOrderAction, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspOrderAction_delegate) RspOrderAction_delegate(pInputOrderAction, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 查询最大报单数量响应
		/// </summary>
		event RspQueryMaxOrderVolume^ OnRspQueryMaxOrderVolume{
			void add(RspQueryMaxOrderVolume^ handler) { RspQueryMaxOrderVolume_delegate += handler; }
			void remove(RspQueryMaxOrderVolume^ handler) { RspQueryMaxOrderVolume_delegate -= handler; }
			void raise(ThostFtdcQueryMaxOrderVolumeField^ pQueryMaxOrderVolume, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQueryMaxOrderVolume_delegate) RspQueryMaxOrderVolume_delegate(pQueryMaxOrderVolume, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 投资者结算结果确认响应
		/// </summary>
		event RspSettlementInfoConfirm^ OnRspSettlementInfoConfirm{
			void add(RspSettlementInfoConfirm^ handler) { RspSettlementInfoConfirm_delegate += handler; }
			void remove(RspSettlementInfoConfirm^ handler) { RspSettlementInfoConfirm_delegate -= handler; }
			void raise(ThostFtdcSettlementInfoConfirmField^ pSettlementInfoConfirm, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspSettlementInfoConfirm_delegate) RspSettlementInfoConfirm_delegate(pSettlementInfoConfirm, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 删除预埋单响应
		/// </summary>
		event RspRemoveParkedOrder^ OnRspRemoveParkedOrder{
			void add(RspRemoveParkedOrder^ handler) { RspRemoveParkedOrder_delegate += handler; }
			void remove(RspRemoveParkedOrder^ handler) { RspRemoveParkedOrder_delegate -= handler; }
			void raise(ThostFtdcRemoveParkedOrderField^ pRemoveParkedOrder, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspRemoveParkedOrder_delegate) RspRemoveParkedOrder_delegate(pRemoveParkedOrder, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 删除预埋撤单响应
		/// </summary>
		event RspRemoveParkedOrderAction^ OnRspRemoveParkedOrderAction{
			void add(RspRemoveParkedOrderAction^ handler) { RspRemoveParkedOrderAction_delegate += handler; }
			void remove(RspRemoveParkedOrderAction^ handler) { RspRemoveParkedOrderAction_delegate -= handler; }
			void raise(ThostFtdcRemoveParkedOrderActionField^ pRemoveParkedOrderAction, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspRemoveParkedOrderAction_delegate) RspRemoveParkedOrderAction_delegate(pRemoveParkedOrderAction, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询报单响应
		/// </summary>
		event RspQryOrder^ OnRspQryOrder{
			void add(RspQryOrder^ handler) { RspQryOrder_delegate += handler; }
			void remove(RspQryOrder^ handler) { RspQryOrder_delegate -= handler; }
			void raise(ThostFtdcOrderField^ pOrder, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryOrder_delegate) RspQryOrder_delegate(pOrder, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询成交响应
		/// </summary>
		event RspQryTrade^ OnRspQryTrade{
			void add(RspQryTrade^ handler) { RspQryTrade_delegate += handler; }
			void remove(RspQryTrade^ handler) { RspQryTrade_delegate -= handler; }
			void raise(ThostFtdcTradeField^ pTrade, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryTrade_delegate) RspQryTrade_delegate(pTrade, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询投资者持仓响应
		/// </summary>
		event RspQryInvestorPosition^ OnRspQryInvestorPosition{
			void add(RspQryInvestorPosition^ handler) { RspQryInvestorPosition_delegate += handler; }
			void remove(RspQryInvestorPosition^ handler) { RspQryInvestorPosition_delegate -= handler; }
			void raise(ThostFtdcInvestorPositionField^ pInvestorPosition, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryInvestorPosition_delegate) RspQryInvestorPosition_delegate(pInvestorPosition, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询资金账户响应
		/// </summary>
		event RspQryTradingAccount^ OnRspQryTradingAccount{
			void add(RspQryTradingAccount^ handler) { RspQryTradingAccount_delegate += handler; }
			void remove(RspQryTradingAccount^ handler) { RspQryTradingAccount_delegate -= handler; }
			void raise(ThostFtdcTradingAccountField^ pTradingAccount, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryTradingAccount_delegate) RspQryTradingAccount_delegate(pTradingAccount, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询投资者响应
		/// </summary>
		event RspQryInvestor^ OnRspQryInvestor{
			void add(RspQryInvestor^ handler) { RspQryInvestor_delegate += handler; }
			void remove(RspQryInvestor^ handler) { RspQryInvestor_delegate -= handler; }
			void raise(ThostFtdcInvestorField^ pInvestor, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryInvestor_delegate) RspQryInvestor_delegate(pInvestor, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询交易编码响应
		/// </summary>
		event RspQryTradingCode^ OnRspQryTradingCode{
			void add(RspQryTradingCode^ handler) { RspQryTradingCode_delegate += handler; }
			void remove(RspQryTradingCode^ handler) { RspQryTradingCode_delegate -= handler; }
			void raise(ThostFtdcTradingCodeField^ pTradingCode, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryTradingCode_delegate) RspQryTradingCode_delegate(pTradingCode, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询合约保证金率响应
		/// </summary>
		event RspQryInstrumentMarginRate^ OnRspQryInstrumentMarginRate{
			void add(RspQryInstrumentMarginRate^ handler) { RspQryInstrumentMarginRate_delegate += handler; }
			void remove(RspQryInstrumentMarginRate^ handler) { RspQryInstrumentMarginRate_delegate -= handler; }
			void raise(ThostFtdcInstrumentMarginRateField^ pInstrumentMarginRate, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryInstrumentMarginRate_delegate) RspQryInstrumentMarginRate_delegate(pInstrumentMarginRate, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询合约手续费率响应
		/// </summary>
		event RspQryInstrumentCommissionRate^ OnRspQryInstrumentCommissionRate{
			void add(RspQryInstrumentCommissionRate^ handler) { RspQryInstrumentCommissionRate_delegate += handler; }
			void remove(RspQryInstrumentCommissionRate^ handler) { RspQryInstrumentCommissionRate_delegate -= handler; }
			void raise(ThostFtdcInstrumentCommissionRateField^ pInstrumentCommissionRate, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryInstrumentCommissionRate_delegate) RspQryInstrumentCommissionRate_delegate(pInstrumentCommissionRate, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询交易所响应
		/// </summary>
		event RspQryExchange^ OnRspQryExchange{
			void add(RspQryExchange^ handler) { RspQryExchange_delegate += handler; }
			void remove(RspQryExchange^ handler) { RspQryExchange_delegate -= handler; }
			void raise(ThostFtdcExchangeField^ pExchange, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryExchange_delegate) RspQryExchange_delegate(pExchange, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询合约响应
		/// </summary>
		event RspQryInstrument^ OnRspQryInstrument{
			void add(RspQryInstrument^ handler) { RspQryInstrument_delegate += handler; }
			void remove(RspQryInstrument^ handler) { RspQryInstrument_delegate -= handler; }
			void raise(ThostFtdcInstrumentField^ pInstrument, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryInstrument_delegate) RspQryInstrument_delegate(pInstrument, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询行情响应
		/// </summary>
		event RspQryDepthMarketData^ OnRspQryDepthMarketData{
			void add(RspQryDepthMarketData^ handler) { RspQryDepthMarketData_delegate += handler; }
			void remove(RspQryDepthMarketData^ handler) { RspQryDepthMarketData_delegate -= handler; }
			void raise(ThostFtdcDepthMarketDataField^ pDepthMarketData, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryDepthMarketData_delegate) RspQryDepthMarketData_delegate(pDepthMarketData, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询投资者结算结果响应
		/// </summary>
		event RspQrySettlementInfo^ OnRspQrySettlementInfo{
			void add(RspQrySettlementInfo^ handler) { RspQrySettlementInfo_delegate += handler; }
			void remove(RspQrySettlementInfo^ handler) { RspQrySettlementInfo_delegate -= handler; }
			void raise(ThostFtdcSettlementInfoField^ pSettlementInfo, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQrySettlementInfo_delegate) RspQrySettlementInfo_delegate(pSettlementInfo, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询转帐银行响应
		/// </summary>
		event RspQryTransferBank^ OnRspQryTransferBank{
			void add(RspQryTransferBank^ handler) { RspQryTransferBank_delegate += handler; }
			void remove(RspQryTransferBank^ handler) { RspQryTransferBank_delegate -= handler; }
			void raise(ThostFtdcTransferBankField^ pTransferBank, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryTransferBank_delegate) RspQryTransferBank_delegate(pTransferBank, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询投资者持仓明细响应
		/// </summary>
		event RspQryInvestorPositionDetail^ OnRspQryInvestorPositionDetail{
			void add(RspQryInvestorPositionDetail^ handler) { RspQryInvestorPositionDetail_delegate += handler; }
			void remove(RspQryInvestorPositionDetail^ handler) { RspQryInvestorPositionDetail_delegate -= handler; }
			void raise(ThostFtdcInvestorPositionDetailField^ pInvestorPositionDetail, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryInvestorPositionDetail_delegate) RspQryInvestorPositionDetail_delegate(pInvestorPositionDetail, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询客户通知响应
		/// </summary>
		event RspQryNotice^ OnRspQryNotice{
			void add(RspQryNotice^ handler) { RspQryNotice_delegate += handler; }
			void remove(RspQryNotice^ handler) { RspQryNotice_delegate -= handler; }
			void raise(ThostFtdcNoticeField^ pNotice, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryNotice_delegate) RspQryNotice_delegate(pNotice, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询结算信息确认响应
		/// </summary>
		event RspQrySettlementInfoConfirm^ OnRspQrySettlementInfoConfirm{
			void add(RspQrySettlementInfoConfirm^ handler) { RspQrySettlementInfoConfirm_delegate += handler; }
			void remove(RspQrySettlementInfoConfirm^ handler) { RspQrySettlementInfoConfirm_delegate -= handler; }
			void raise(ThostFtdcSettlementInfoConfirmField^ pSettlementInfoConfirm, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQrySettlementInfoConfirm_delegate) RspQrySettlementInfoConfirm_delegate(pSettlementInfoConfirm, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询投资者持仓明细响应
		/// </summary>
		event RspQryInvestorPositionCombineDetail^ OnRspQryInvestorPositionCombineDetail{
			void add(RspQryInvestorPositionCombineDetail^ handler) { RspQryInvestorPositionCombineDetail_delegate += handler; }
			void remove(RspQryInvestorPositionCombineDetail^ handler) { RspQryInvestorPositionCombineDetail_delegate -= handler; }
			void raise(ThostFtdcInvestorPositionCombineDetailField^ pInvestorPositionCombineDetail, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryInvestorPositionCombineDetail_delegate) RspQryInvestorPositionCombineDetail_delegate(pInvestorPositionCombineDetail, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 查询保证金监管系统经纪公司资金账户密钥响应
		/// </summary>
		event RspQryCFMMCTradingAccountKey^ OnRspQryCFMMCTradingAccountKey{
			void add(RspQryCFMMCTradingAccountKey^ handler) { RspQryCFMMCTradingAccountKey_delegate += handler; }
			void remove(RspQryCFMMCTradingAccountKey^ handler) { RspQryCFMMCTradingAccountKey_delegate -= handler; }
			void raise(ThostFtdcCFMMCTradingAccountKeyField^ pCFMMCTradingAccountKey, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryCFMMCTradingAccountKey_delegate) RspQryCFMMCTradingAccountKey_delegate(pCFMMCTradingAccountKey, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询仓单折抵信息响应
		/// </summary>
		event RspQryEWarrantOffset^ OnRspQryEWarrantOffset{
			void add(RspQryEWarrantOffset^ handler) { RspQryEWarrantOffset_delegate += handler; }
			void remove(RspQryEWarrantOffset^ handler) { RspQryEWarrantOffset_delegate -= handler; }
			void raise(ThostFtdcEWarrantOffsetField^ pEWarrantOffset, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryEWarrantOffset_delegate) RspQryEWarrantOffset_delegate(pEWarrantOffset, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询转帐流水响应
		/// </summary>
		event RspQryTransferSerial^ OnRspQryTransferSerial{
			void add(RspQryTransferSerial^ handler) { RspQryTransferSerial_delegate += handler; }
			void remove(RspQryTransferSerial^ handler) { RspQryTransferSerial_delegate -= handler; }
			void raise(ThostFtdcTransferSerialField^ pTransferSerial, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryTransferSerial_delegate) RspQryTransferSerial_delegate(pTransferSerial, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询银期签约关系响应
		/// </summary>
		event RspQryAccountregister^ OnRspQryAccountregister{
			void add(RspQryAccountregister^ handler) { RspQryAccountregister_delegate += handler; }
			void remove(RspQryAccountregister^ handler) { RspQryAccountregister_delegate -= handler; }
			void raise(ThostFtdcAccountregisterField^ pAccountregister, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryAccountregister_delegate) RspQryAccountregister_delegate(pAccountregister, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 错误应答
		/// </summary>
		event RspError^ OnRspError {
			void add(RspError^ handler ) { RspError_delegate += handler; }
			void remove(RspError^ handler) {RspError_delegate -= handler; }
			void raise(ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) { if(RspError_delegate) RspError_delegate(pRspInfo, nRequestID, bIsLast); }
		}
		/// <summary>
		/// 报单通知
		/// </summary>
		event RtnOrder^ OnRtnOrder{
			void add(RtnOrder^ handler) { RtnOrder_delegate += handler; }
			void remove(RtnOrder^ handler) { RtnOrder_delegate -= handler; }
			void raise(ThostFtdcOrderField^ pOrder) {
				if(RtnOrder_delegate) RtnOrder_delegate(pOrder);
			}
		}
		/// <summary>
		/// 成交通知
		/// </summary>
		event RtnTrade^ OnRtnTrade{
			void add(RtnTrade^ handler) { RtnTrade_delegate += handler; }
			void remove(RtnTrade^ handler) { RtnTrade_delegate -= handler; }
			void raise(ThostFtdcTradeField^ pTrade) {
				if(RtnTrade_delegate) RtnTrade_delegate(pTrade);
			}
		}
		/// <summary>
		/// 报单录入错误回报
		/// </summary>
		event ErrRtnOrderInsert^ OnErrRtnOrderInsert{
			void add(ErrRtnOrderInsert^ handler) { ErrRtnOrderInsert_delegate += handler; }
			void remove(ErrRtnOrderInsert^ handler) { ErrRtnOrderInsert_delegate -= handler; }
			void raise(ThostFtdcInputOrderField^ pInputOrder, ThostFtdcRspInfoField^ pRspInfo) {
				if(ErrRtnOrderInsert_delegate) ErrRtnOrderInsert_delegate(pInputOrder, pRspInfo);
			}
		}
		/// <summary>
		/// 报单操作错误回报
		/// </summary>
		event ErrRtnOrderAction^ OnErrRtnOrderAction{
			void add(ErrRtnOrderAction^ handler) { ErrRtnOrderAction_delegate += handler; }
			void remove(ErrRtnOrderAction^ handler) { ErrRtnOrderAction_delegate -= handler; }
			void raise(ThostFtdcOrderActionField^ pOrderAction, ThostFtdcRspInfoField^ pRspInfo) {
				if(ErrRtnOrderAction_delegate) ErrRtnOrderAction_delegate(pOrderAction, pRspInfo);
			}
		}
		/// <summary>
		/// 合约交易状态通知
		/// </summary>
		event RtnInstrumentStatus^ OnRtnInstrumentStatus{
			void add(RtnInstrumentStatus^ handler) { RtnInstrumentStatus_delegate += handler; }
			void remove(RtnInstrumentStatus^ handler) { RtnInstrumentStatus_delegate -= handler; }
			void raise(ThostFtdcInstrumentStatusField^ pInstrumentStatus) {
				if(RtnInstrumentStatus_delegate) RtnInstrumentStatus_delegate(pInstrumentStatus);
			}
		}
		/// <summary>
		/// 交易通知
		/// </summary>
		event RtnTradingNotice^ OnRtnTradingNotice{
			void add(RtnTradingNotice^ handler) { RtnTradingNotice_delegate += handler; }
			void remove(RtnTradingNotice^ handler) { RtnTradingNotice_delegate -= handler; }
			void raise(ThostFtdcTradingNoticeInfoField^ pTradingNoticeInfo) {
				if(RtnTradingNotice_delegate) RtnTradingNotice_delegate(pTradingNoticeInfo);
			}
		}
		/// <summary>
		/// 提示条件单校验错误
		/// </summary>
		event RtnErrorConditionalOrder^ OnRtnErrorConditionalOrder{
			void add(RtnErrorConditionalOrder^ handler) { RtnErrorConditionalOrder_delegate += handler; }
			void remove(RtnErrorConditionalOrder^ handler) { RtnErrorConditionalOrder_delegate -= handler; }
			void raise(ThostFtdcErrorConditionalOrderField^ pErrorConditionalOrder) {
				if(RtnErrorConditionalOrder_delegate) RtnErrorConditionalOrder_delegate(pErrorConditionalOrder);
			}
		}
		/// <summary>
		/// 请求查询签约银行响应
		/// </summary>
		event RspQryContractBank^ OnRspQryContractBank{
			void add(RspQryContractBank^ handler) { RspQryContractBank_delegate += handler; }
			void remove(RspQryContractBank^ handler) { RspQryContractBank_delegate -= handler; }
			void raise(ThostFtdcContractBankField^ pContractBank, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryContractBank_delegate) RspQryContractBank_delegate(pContractBank, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询预埋单响应
		/// </summary>
		event RspQryParkedOrder^ OnRspQryParkedOrder{
			void add(RspQryParkedOrder^ handler) { RspQryParkedOrder_delegate += handler; }
			void remove(RspQryParkedOrder^ handler) { RspQryParkedOrder_delegate -= handler; }
			void raise(ThostFtdcParkedOrderField^ pParkedOrder, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryParkedOrder_delegate) RspQryParkedOrder_delegate(pParkedOrder, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询预埋撤单响应
		/// </summary>
		event RspQryParkedOrderAction^ OnRspQryParkedOrderAction{
			void add(RspQryParkedOrderAction^ handler) { RspQryParkedOrderAction_delegate += handler; }
			void remove(RspQryParkedOrderAction^ handler) { RspQryParkedOrderAction_delegate -= handler; }
			void raise(ThostFtdcParkedOrderActionField^ pParkedOrderAction, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryParkedOrderAction_delegate) RspQryParkedOrderAction_delegate(pParkedOrderAction, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询交易通知响应
		/// </summary>
		event RspQryTradingNotice^ OnRspQryTradingNotice{
			void add(RspQryTradingNotice^ handler) { RspQryTradingNotice_delegate += handler; }
			void remove(RspQryTradingNotice^ handler) { RspQryTradingNotice_delegate -= handler; }
			void raise(ThostFtdcTradingNoticeField^ pTradingNotice, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryTradingNotice_delegate) RspQryTradingNotice_delegate(pTradingNotice, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询经纪公司交易参数响应
		/// </summary>
		event RspQryBrokerTradingParams^ OnRspQryBrokerTradingParams{
			void add(RspQryBrokerTradingParams^ handler) { RspQryBrokerTradingParams_delegate += handler; }
			void remove(RspQryBrokerTradingParams^ handler) { RspQryBrokerTradingParams_delegate -= handler; }
			void raise(ThostFtdcBrokerTradingParamsField^ pBrokerTradingParams, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryBrokerTradingParams_delegate) RspQryBrokerTradingParams_delegate(pBrokerTradingParams, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 请求查询经纪公司交易算法响应
		/// </summary>
		event RspQryBrokerTradingAlgos^ OnRspQryBrokerTradingAlgos{
			void add(RspQryBrokerTradingAlgos^ handler) { RspQryBrokerTradingAlgos_delegate += handler; }
			void remove(RspQryBrokerTradingAlgos^ handler) { RspQryBrokerTradingAlgos_delegate -= handler; }
			void raise(ThostFtdcBrokerTradingAlgosField^ pBrokerTradingAlgos, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQryBrokerTradingAlgos_delegate) RspQryBrokerTradingAlgos_delegate(pBrokerTradingAlgos, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 银行发起银行资金转期货通知
		/// </summary>
		event RtnFromBankToFutureByBank^ OnRtnFromBankToFutureByBank{
			void add(RtnFromBankToFutureByBank^ handler) { RtnFromBankToFutureByBank_delegate += handler; }
			void remove(RtnFromBankToFutureByBank^ handler) { RtnFromBankToFutureByBank_delegate -= handler; }
			void raise(ThostFtdcRspTransferField^ pRspTransfer) {
				if(RtnFromBankToFutureByBank_delegate) RtnFromBankToFutureByBank_delegate(pRspTransfer);
			}
		}
		/// <summary>
		/// 银行发起期货资金转银行通知
		/// </summary>
		event RtnFromFutureToBankByBank^ OnRtnFromFutureToBankByBank{
			void add(RtnFromFutureToBankByBank^ handler) { RtnFromFutureToBankByBank_delegate += handler; }
			void remove(RtnFromFutureToBankByBank^ handler) { RtnFromFutureToBankByBank_delegate -= handler; }
			void raise(ThostFtdcRspTransferField^ pRspTransfer) {
				if(RtnFromFutureToBankByBank_delegate) RtnFromFutureToBankByBank_delegate(pRspTransfer);
			}
		}
		/// <summary>
		/// 银行发起冲正银行转期货通知
		/// </summary>
		event RtnRepealFromBankToFutureByBank^ OnRtnRepealFromBankToFutureByBank{
			void add(RtnRepealFromBankToFutureByBank^ handler) { RtnRepealFromBankToFutureByBank_delegate += handler; }
			void remove(RtnRepealFromBankToFutureByBank^ handler) { RtnRepealFromBankToFutureByBank_delegate -= handler; }
			void raise(ThostFtdcRspRepealField^ pRspRepeal) {
				if(RtnRepealFromBankToFutureByBank_delegate) RtnRepealFromBankToFutureByBank_delegate(pRspRepeal);
			}
		}
		/// <summary>
		/// 银行发起冲正期货转银行通知
		/// </summary>
		event RtnRepealFromFutureToBankByBank^ OnRtnRepealFromFutureToBankByBank{
			void add(RtnRepealFromFutureToBankByBank^ handler) { RtnRepealFromFutureToBankByBank_delegate += handler; }
			void remove(RtnRepealFromFutureToBankByBank^ handler) { RtnRepealFromFutureToBankByBank_delegate -= handler; }
			void raise(ThostFtdcRspRepealField^ pRspRepeal) {
				if(RtnRepealFromFutureToBankByBank_delegate) RtnRepealFromFutureToBankByBank_delegate(pRspRepeal);
			}
		}
		/// <summary>
		/// 期货发起银行资金转期货通知
		/// </summary>
		event RtnFromBankToFutureByFuture^ OnRtnFromBankToFutureByFuture{
			void add(RtnFromBankToFutureByFuture^ handler) { RtnFromBankToFutureByFuture_delegate += handler; }
			void remove(RtnFromBankToFutureByFuture^ handler) { RtnFromBankToFutureByFuture_delegate -= handler; }
			void raise(ThostFtdcRspTransferField^ pRspTransfer) {
				if(RtnFromBankToFutureByFuture_delegate) RtnFromBankToFutureByFuture_delegate(pRspTransfer);
			}
		}
		/// <summary>
		/// 期货发起期货资金转银行通知
		/// </summary>
		event RtnFromFutureToBankByFuture^ OnRtnFromFutureToBankByFuture{
			void add(RtnFromFutureToBankByFuture^ handler) { RtnFromFutureToBankByFuture_delegate += handler; }
			void remove(RtnFromFutureToBankByFuture^ handler) { RtnFromFutureToBankByFuture_delegate -= handler; }
			void raise(ThostFtdcRspTransferField^ pRspTransfer) {
				if(RtnFromFutureToBankByFuture_delegate) RtnFromFutureToBankByFuture_delegate(pRspTransfer);
			}
		}
		/// <summary>
		/// 系统运行时期货端手工发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
		/// </summary>
		event RtnRepealFromBankToFutureByFutureManual^ OnRtnRepealFromBankToFutureByFutureManual{
			void add(RtnRepealFromBankToFutureByFutureManual^ handler) { RtnRepealFromBankToFutureByFutureManual_delegate += handler; }
			void remove(RtnRepealFromBankToFutureByFutureManual^ handler) { RtnRepealFromBankToFutureByFutureManual_delegate -= handler; }
			void raise(ThostFtdcRspRepealField^ pRspRepeal) {
				if(RtnRepealFromBankToFutureByFutureManual_delegate) RtnRepealFromBankToFutureByFutureManual_delegate(pRspRepeal);
			}
		}
		/// <summary>
		/// 系统运行时期货端手工发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
		/// </summary>
		event RtnRepealFromFutureToBankByFutureManual^ OnRtnRepealFromFutureToBankByFutureManual{
			void add(RtnRepealFromFutureToBankByFutureManual^ handler) { RtnRepealFromFutureToBankByFutureManual_delegate += handler; }
			void remove(RtnRepealFromFutureToBankByFutureManual^ handler) { RtnRepealFromFutureToBankByFutureManual_delegate -= handler; }
			void raise(ThostFtdcRspRepealField^ pRspRepeal) {
				if(RtnRepealFromFutureToBankByFutureManual_delegate) RtnRepealFromFutureToBankByFutureManual_delegate(pRspRepeal);
			}
		}
		/// <summary>
		/// 期货发起查询银行余额通知
		/// </summary>
		event RtnQueryBankBalanceByFuture^ OnRtnQueryBankBalanceByFuture{
			void add(RtnQueryBankBalanceByFuture^ handler) { RtnQueryBankBalanceByFuture_delegate += handler; }
			void remove(RtnQueryBankBalanceByFuture^ handler) { RtnQueryBankBalanceByFuture_delegate -= handler; }
			void raise(ThostFtdcNotifyQueryAccountField^ pNotifyQueryAccount) {
				if(RtnQueryBankBalanceByFuture_delegate) RtnQueryBankBalanceByFuture_delegate(pNotifyQueryAccount);
			}
		}
		/// <summary>
		/// 期货发起银行资金转期货错误回报
		/// </summary>
		event ErrRtnBankToFutureByFuture^ OnErrRtnBankToFutureByFuture{
			void add(ErrRtnBankToFutureByFuture^ handler) { ErrRtnBankToFutureByFuture_delegate += handler; }
			void remove(ErrRtnBankToFutureByFuture^ handler) { ErrRtnBankToFutureByFuture_delegate -= handler; }
			void raise(ThostFtdcReqTransferField^ pReqTransfer, ThostFtdcRspInfoField^ pRspInfo) {
				if(ErrRtnBankToFutureByFuture_delegate) ErrRtnBankToFutureByFuture_delegate(pReqTransfer, pRspInfo);
			}
		}
		/// <summary>
		/// 期货发起期货资金转银行错误回报
		/// </summary>
		event ErrRtnFutureToBankByFuture^ OnErrRtnFutureToBankByFuture{
			void add(ErrRtnFutureToBankByFuture^ handler) { ErrRtnFutureToBankByFuture_delegate += handler; }
			void remove(ErrRtnFutureToBankByFuture^ handler) { ErrRtnFutureToBankByFuture_delegate -= handler; }
			void raise(ThostFtdcReqTransferField^ pReqTransfer, ThostFtdcRspInfoField^ pRspInfo) {
				if(ErrRtnFutureToBankByFuture_delegate) ErrRtnFutureToBankByFuture_delegate(pReqTransfer, pRspInfo);
			}
		}
		/// <summary>
		/// 系统运行时期货端手工发起冲正银行转期货错误回报
		/// </summary>
		event ErrRtnRepealBankToFutureByFutureManual^ OnErrRtnRepealBankToFutureByFutureManual{
			void add(ErrRtnRepealBankToFutureByFutureManual^ handler) { ErrRtnRepealBankToFutureByFutureManual_delegate += handler; }
			void remove(ErrRtnRepealBankToFutureByFutureManual^ handler) { ErrRtnRepealBankToFutureByFutureManual_delegate -= handler; }
			void raise(ThostFtdcReqRepealField^ pReqRepeal, ThostFtdcRspInfoField^ pRspInfo) {
				if(ErrRtnRepealBankToFutureByFutureManual_delegate) ErrRtnRepealBankToFutureByFutureManual_delegate(pReqRepeal, pRspInfo);
			}
		}
		/// <summary>
		/// 系统运行时期货端手工发起冲正期货转银行错误回报
		/// </summary>
		event ErrRtnRepealFutureToBankByFutureManual^ OnErrRtnRepealFutureToBankByFutureManual{
			void add(ErrRtnRepealFutureToBankByFutureManual^ handler) { ErrRtnRepealFutureToBankByFutureManual_delegate += handler; }
			void remove(ErrRtnRepealFutureToBankByFutureManual^ handler) { ErrRtnRepealFutureToBankByFutureManual_delegate -= handler; }
			void raise(ThostFtdcReqRepealField^ pReqRepeal, ThostFtdcRspInfoField^ pRspInfo) {
				if(ErrRtnRepealFutureToBankByFutureManual_delegate) ErrRtnRepealFutureToBankByFutureManual_delegate(pReqRepeal, pRspInfo);
			}
		}
		/// <summary>
		/// 期货发起查询银行余额错误回报
		/// </summary>
		event ErrRtnQueryBankBalanceByFuture^ OnErrRtnQueryBankBalanceByFuture{
			void add(ErrRtnQueryBankBalanceByFuture^ handler) { ErrRtnQueryBankBalanceByFuture_delegate += handler; }
			void remove(ErrRtnQueryBankBalanceByFuture^ handler) { ErrRtnQueryBankBalanceByFuture_delegate -= handler; }
			void raise(ThostFtdcReqQueryAccountField^ pReqQueryAccount, ThostFtdcRspInfoField^ pRspInfo) {
				if(ErrRtnQueryBankBalanceByFuture_delegate) ErrRtnQueryBankBalanceByFuture_delegate(pReqQueryAccount, pRspInfo);
			}
		}
		/// <summary>
		/// 期货发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
		/// </summary>
		event RtnRepealFromBankToFutureByFuture^ OnRtnRepealFromBankToFutureByFuture{
			void add(RtnRepealFromBankToFutureByFuture^ handler) { RtnRepealFromBankToFutureByFuture_delegate += handler; }
			void remove(RtnRepealFromBankToFutureByFuture^ handler) { RtnRepealFromBankToFutureByFuture_delegate -= handler; }
			void raise(ThostFtdcRspRepealField^ pRspRepeal) {
				if(RtnRepealFromBankToFutureByFuture_delegate) RtnRepealFromBankToFutureByFuture_delegate(pRspRepeal);
			}
		}
		/// <summary>
		/// 期货发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
		/// </summary>
		event RtnRepealFromFutureToBankByFuture^ OnRtnRepealFromFutureToBankByFuture{
			void add(RtnRepealFromFutureToBankByFuture^ handler) { RtnRepealFromFutureToBankByFuture_delegate += handler; }
			void remove(RtnRepealFromFutureToBankByFuture^ handler) { RtnRepealFromFutureToBankByFuture_delegate -= handler; }
			void raise(ThostFtdcRspRepealField^ pRspRepeal) {
				if(RtnRepealFromFutureToBankByFuture_delegate) RtnRepealFromFutureToBankByFuture_delegate(pRspRepeal);
			}
		}
		/// <summary>
		/// 期货发起银行资金转期货应答
		/// </summary>
		event RspFromBankToFutureByFuture^ OnRspFromBankToFutureByFuture{
			void add(RspFromBankToFutureByFuture^ handler) { RspFromBankToFutureByFuture_delegate += handler; }
			void remove(RspFromBankToFutureByFuture^ handler) { RspFromBankToFutureByFuture_delegate -= handler; }
			void raise(ThostFtdcReqTransferField^ pReqTransfer, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspFromBankToFutureByFuture_delegate) RspFromBankToFutureByFuture_delegate(pReqTransfer, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 期货发起期货资金转银行应答
		/// </summary>
		event RspFromFutureToBankByFuture^ OnRspFromFutureToBankByFuture{
			void add(RspFromFutureToBankByFuture^ handler) { RspFromFutureToBankByFuture_delegate += handler; }
			void remove(RspFromFutureToBankByFuture^ handler) { RspFromFutureToBankByFuture_delegate -= handler; }
			void raise(ThostFtdcReqTransferField^ pReqTransfer, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspFromFutureToBankByFuture_delegate) RspFromFutureToBankByFuture_delegate(pReqTransfer, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 期货发起查询银行余额应答
		/// </summary>
		event RspQueryBankAccountMoneyByFuture^ OnRspQueryBankAccountMoneyByFuture{
			void add(RspQueryBankAccountMoneyByFuture^ handler) { RspQueryBankAccountMoneyByFuture_delegate += handler; }
			void remove(RspQueryBankAccountMoneyByFuture^ handler) { RspQueryBankAccountMoneyByFuture_delegate -= handler; }
			void raise(ThostFtdcReqQueryAccountField^ pReqQueryAccount, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) {
				if(RspQueryBankAccountMoneyByFuture_delegate) RspQueryBankAccountMoneyByFuture_delegate(pReqQueryAccount, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 银行发起银期开户通知
		/// </summary>
		event RtnOpenAccountByBank^ OnRtnOpenAccountByBank{
			void add(RtnOpenAccountByBank^ handler) { RtnOpenAccountByBank_delegate += handler; }
			void remove(RtnOpenAccountByBank^ handler) { RtnOpenAccountByBank_delegate -= handler; }
			void raise(ThostFtdcOpenAccountField^ pOpenAccount) {
				if(RtnOpenAccountByBank_delegate) RtnOpenAccountByBank_delegate(pOpenAccount);
			}
		}
		/// <summary>
		/// 银行发起银期销户通知
		/// </summary>
		event RtnCancelAccountByBank^ OnRtnCancelAccountByBank{
			void add(RtnCancelAccountByBank^ handler) { RtnCancelAccountByBank_delegate += handler; }
			void remove(RtnCancelAccountByBank^ handler) { RtnCancelAccountByBank_delegate -= handler; }
			void raise(ThostFtdcCancelAccountField^ pCancelAccount) {
				if(RtnCancelAccountByBank_delegate) RtnCancelAccountByBank_delegate(pCancelAccount);
			}
		}
		/// <summary>
		/// 银行发起变更银行账号通知
		/// </summary>
		event RtnChangeAccountByBank^ OnRtnChangeAccountByBank{
			void add(RtnChangeAccountByBank^ handler) { RtnChangeAccountByBank_delegate += handler; }
			void remove(RtnChangeAccountByBank^ handler) { RtnChangeAccountByBank_delegate -= handler; }
			void raise(ThostFtdcChangeAccountField^ pChangeAccount) {
				if(RtnChangeAccountByBank_delegate) RtnChangeAccountByBank_delegate(pChangeAccount);
			}
		}
		
		// delegates
	private:
		FrontConnected^ FrontConnected_delegate;
		FrontDisconnected^ FrontDisconnected_delegate;
		HeartBeatWarning^ HeartBeatWarning_delegate;
		RspUserLogin^ RspUserLogin_delegate;
		RspUserLogout^ RspUserLogout_delegate;
		RspError^ RspError_delegate;

		RspAuthenticate^ RspAuthenticate_delegate;
		RspUserPasswordUpdate^ RspUserPasswordUpdate_delegate;
		RspTradingAccountPasswordUpdate^ RspTradingAccountPasswordUpdate_delegate;
		RspOrderInsert^ RspOrderInsert_delegate;
		RspParkedOrderInsert^ RspParkedOrderInsert_delegate;
		RspParkedOrderAction^ RspParkedOrderAction_delegate;
		RspOrderAction^ RspOrderAction_delegate;
		RspQueryMaxOrderVolume^ RspQueryMaxOrderVolume_delegate;
		RspSettlementInfoConfirm^ RspSettlementInfoConfirm_delegate;
		RspRemoveParkedOrder^ RspRemoveParkedOrder_delegate;
		RspRemoveParkedOrderAction^ RspRemoveParkedOrderAction_delegate;
		RspQryOrder^ RspQryOrder_delegate;
		RspQryTrade^ RspQryTrade_delegate;
		RspQryInvestorPosition^ RspQryInvestorPosition_delegate;
		RspQryTradingAccount^ RspQryTradingAccount_delegate;
		RspQryInvestor^ RspQryInvestor_delegate;
		RspQryTradingCode^ RspQryTradingCode_delegate;
		RspQryInstrumentMarginRate^ RspQryInstrumentMarginRate_delegate;
		RspQryInstrumentCommissionRate^ RspQryInstrumentCommissionRate_delegate;
		RspQryExchange^ RspQryExchange_delegate;
		RspQryInstrument^ RspQryInstrument_delegate;
		RspQryDepthMarketData^ RspQryDepthMarketData_delegate;
		RspQrySettlementInfo^ RspQrySettlementInfo_delegate;
		RspQryTransferBank^ RspQryTransferBank_delegate;
		RspQryInvestorPositionDetail^ RspQryInvestorPositionDetail_delegate;
		RspQryNotice^ RspQryNotice_delegate;
		RspQrySettlementInfoConfirm^ RspQrySettlementInfoConfirm_delegate;
		RspQryInvestorPositionCombineDetail^ RspQryInvestorPositionCombineDetail_delegate;
		RspQryCFMMCTradingAccountKey^ RspQryCFMMCTradingAccountKey_delegate;
		RspQryEWarrantOffset^ RspQryEWarrantOffset_delegate;
		RspQryTransferSerial^ RspQryTransferSerial_delegate;
		RspQryAccountregister^ RspQryAccountregister_delegate;
		RtnOrder^ RtnOrder_delegate;
		RtnTrade^ RtnTrade_delegate;
		ErrRtnOrderInsert^ ErrRtnOrderInsert_delegate;
		ErrRtnOrderAction^ ErrRtnOrderAction_delegate;
		RtnInstrumentStatus^ RtnInstrumentStatus_delegate;
		RtnTradingNotice^ RtnTradingNotice_delegate;
		RtnErrorConditionalOrder^ RtnErrorConditionalOrder_delegate;
		RspQryContractBank^ RspQryContractBank_delegate;
		RspQryParkedOrder^ RspQryParkedOrder_delegate;
		RspQryParkedOrderAction^ RspQryParkedOrderAction_delegate;
		RspQryTradingNotice^ RspQryTradingNotice_delegate;
		RspQryBrokerTradingParams^ RspQryBrokerTradingParams_delegate;
		RspQryBrokerTradingAlgos^ RspQryBrokerTradingAlgos_delegate;
		RtnFromBankToFutureByBank^ RtnFromBankToFutureByBank_delegate;
		RtnFromFutureToBankByBank^ RtnFromFutureToBankByBank_delegate;
		RtnRepealFromBankToFutureByBank^ RtnRepealFromBankToFutureByBank_delegate;
		RtnRepealFromFutureToBankByBank^ RtnRepealFromFutureToBankByBank_delegate;
		RtnFromBankToFutureByFuture^ RtnFromBankToFutureByFuture_delegate;
		RtnFromFutureToBankByFuture^ RtnFromFutureToBankByFuture_delegate;
		RtnRepealFromBankToFutureByFutureManual^ RtnRepealFromBankToFutureByFutureManual_delegate;
		RtnRepealFromFutureToBankByFutureManual^ RtnRepealFromFutureToBankByFutureManual_delegate;
		RtnQueryBankBalanceByFuture^ RtnQueryBankBalanceByFuture_delegate;
		ErrRtnBankToFutureByFuture^ ErrRtnBankToFutureByFuture_delegate;
		ErrRtnFutureToBankByFuture^ ErrRtnFutureToBankByFuture_delegate;
		ErrRtnRepealBankToFutureByFutureManual^ ErrRtnRepealBankToFutureByFutureManual_delegate;
		ErrRtnRepealFutureToBankByFutureManual^ ErrRtnRepealFutureToBankByFutureManual_delegate;
		ErrRtnQueryBankBalanceByFuture^ ErrRtnQueryBankBalanceByFuture_delegate;
		RtnRepealFromBankToFutureByFuture^ RtnRepealFromBankToFutureByFuture_delegate;
		RtnRepealFromFutureToBankByFuture^ RtnRepealFromFutureToBankByFuture_delegate;
		RspFromBankToFutureByFuture^ RspFromBankToFutureByFuture_delegate;
		RspFromFutureToBankByFuture^ RspFromFutureToBankByFuture_delegate;
		RspQueryBankAccountMoneyByFuture^ RspQueryBankAccountMoneyByFuture_delegate;
		RtnOpenAccountByBank^ RtnOpenAccountByBank_delegate;
		RtnCancelAccountByBank^ RtnCancelAccountByBank_delegate;
		RtnChangeAccountByBank^ RtnChangeAccountByBank_delegate;
#ifdef __CTP_MA__
		// callbacks for MA
	private:
		void cbk_OnFrontConnected();
		void cbk_OnFrontDisconnected(int nReason);
		void cbk_OnHeartBeatWarning(int nTimeLapse);
		void cbk_OnRspAuthenticate(CThostFtdcRspAuthenticateField *pRspAuthenticateField, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspUserLogin(CThostFtdcRspUserLoginField *pRspUserLogin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspUserLogout(CThostFtdcUserLogoutField *pUserLogout, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspUserPasswordUpdate(CThostFtdcUserPasswordUpdateField *pUserPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspTradingAccountPasswordUpdate(CThostFtdcTradingAccountPasswordUpdateField *pTradingAccountPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspOrderInsert(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspParkedOrderInsert(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspParkedOrderAction(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspOrderAction(CThostFtdcInputOrderActionField *pInputOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQueryMaxOrderVolume(CThostFtdcQueryMaxOrderVolumeField *pQueryMaxOrderVolume, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspSettlementInfoConfirm(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspRemoveParkedOrder(CThostFtdcRemoveParkedOrderField *pRemoveParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspRemoveParkedOrderAction(CThostFtdcRemoveParkedOrderActionField *pRemoveParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryOrder(CThostFtdcOrderField *pOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryTrade(CThostFtdcTradeField *pTrade, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryInvestorPosition(CThostFtdcInvestorPositionField *pInvestorPosition, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryTradingAccount(CThostFtdcTradingAccountField *pTradingAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryInvestor(CThostFtdcInvestorField *pInvestor, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryTradingCode(CThostFtdcTradingCodeField *pTradingCode, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryInstrumentMarginRate(CThostFtdcInstrumentMarginRateField *pInstrumentMarginRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryInstrumentCommissionRate(CThostFtdcInstrumentCommissionRateField *pInstrumentCommissionRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryExchange(CThostFtdcExchangeField *pExchange, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryInstrument(CThostFtdcInstrumentField *pInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryDepthMarketData(CThostFtdcDepthMarketDataField *pDepthMarketData, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQrySettlementInfo(CThostFtdcSettlementInfoField *pSettlementInfo, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryTransferBank(CThostFtdcTransferBankField *pTransferBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryInvestorPositionDetail(CThostFtdcInvestorPositionDetailField *pInvestorPositionDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryNotice(CThostFtdcNoticeField *pNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQrySettlementInfoConfirm(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryInvestorPositionCombineDetail(CThostFtdcInvestorPositionCombineDetailField *pInvestorPositionCombineDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryCFMMCTradingAccountKey(CThostFtdcCFMMCTradingAccountKeyField *pCFMMCTradingAccountKey, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryEWarrantOffset(CThostFtdcEWarrantOffsetField *pEWarrantOffset, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryTransferSerial(CThostFtdcTransferSerialField *pTransferSerial, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryAccountregister(CThostFtdcAccountregisterField *pAccountregister, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspError(CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRtnOrder(CThostFtdcOrderField *pOrder);
		void cbk_OnRtnTrade(CThostFtdcTradeField *pTrade);
		void cbk_OnErrRtnOrderInsert(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo);
		void cbk_OnErrRtnOrderAction(CThostFtdcOrderActionField *pOrderAction, CThostFtdcRspInfoField *pRspInfo);
		void cbk_OnRtnInstrumentStatus(CThostFtdcInstrumentStatusField *pInstrumentStatus);
		void cbk_OnRtnTradingNotice(CThostFtdcTradingNoticeInfoField *pTradingNoticeInfo);
		void cbk_OnRtnErrorConditionalOrder(CThostFtdcErrorConditionalOrderField *pErrorConditionalOrder);
		void cbk_OnRspQryContractBank(CThostFtdcContractBankField *pContractBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryParkedOrder(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryParkedOrderAction(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryTradingNotice(CThostFtdcTradingNoticeField *pTradingNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryBrokerTradingParams(CThostFtdcBrokerTradingParamsField *pBrokerTradingParams, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQryBrokerTradingAlgos(CThostFtdcBrokerTradingAlgosField *pBrokerTradingAlgos, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRtnFromBankToFutureByBank(CThostFtdcRspTransferField *pRspTransfer);
		void cbk_OnRtnFromFutureToBankByBank(CThostFtdcRspTransferField *pRspTransfer);
		void cbk_OnRtnRepealFromBankToFutureByBank(CThostFtdcRspRepealField *pRspRepeal);
		void cbk_OnRtnRepealFromFutureToBankByBank(CThostFtdcRspRepealField *pRspRepeal);
		void cbk_OnRtnFromBankToFutureByFuture(CThostFtdcRspTransferField *pRspTransfer);
		void cbk_OnRtnFromFutureToBankByFuture(CThostFtdcRspTransferField *pRspTransfer);
		void cbk_OnRtnRepealFromBankToFutureByFutureManual(CThostFtdcRspRepealField *pRspRepeal);
		void cbk_OnRtnRepealFromFutureToBankByFutureManual(CThostFtdcRspRepealField *pRspRepeal);
		void cbk_OnRtnQueryBankBalanceByFuture(CThostFtdcNotifyQueryAccountField *pNotifyQueryAccount);
		void cbk_OnErrRtnBankToFutureByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo);
		void cbk_OnErrRtnFutureToBankByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo);
		void cbk_OnErrRtnRepealBankToFutureByFutureManual(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo);
		void cbk_OnErrRtnRepealFutureToBankByFutureManual(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo);
		void cbk_OnErrRtnQueryBankBalanceByFuture(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo);
		void cbk_OnRtnRepealFromBankToFutureByFuture(CThostFtdcRspRepealField *pRspRepeal);
		void cbk_OnRtnRepealFromFutureToBankByFuture(CThostFtdcRspRepealField *pRspRepeal);
		void cbk_OnRspFromBankToFutureByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspFromFutureToBankByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspQueryBankAccountMoneyByFuture(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRtnOpenAccountByBank(CThostFtdcOpenAccountField *pOpenAccount);
		void cbk_OnRtnCancelAccountByBank(CThostFtdcCancelAccountField *pCancelAccount);
		void cbk_OnRtnChangeAccountByBank(CThostFtdcChangeAccountField *pChangeAccount);
		// 将所有回调函数地址传递给SPI
		void RegisterCallbacks();
#endif

	};
};