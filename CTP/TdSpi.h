/////////////////////////////////////////////////////////////////////////
/// 上期技术 CTP C++ => .Net Framework Adapter
/// Author:	shawn666.liu@gmail.com
/// Date: 20120422
/////////////////////////////////////////////////////////////////////////

#pragma once

#include "Util.h"
#include <vcclr.h>
#include "Callbacks.h"
#include "CTPTDAdapter.h"

namespace Native
{
	/// 非托管类
	class CTdSpi : public CThostFtdcTraderSpi
	{
	public:
		/// 构造函数
		CTdSpi(CTPTDAdapter^ pAdapter);

		///当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
		virtual void OnFrontConnected();
		
		///当客户端与交易后台通信连接断开时，该方法被调用。当发生这个情况后，API会自动重新连接，客户端可不做处理。
		///@param nReason 错误原因
		///        0x1001 网络读失败
		///        0x1002 网络写失败
		///        0x2001 接收心跳超时
		///        0x2002 发送心跳失败
		///        0x2003 收到错误报文
		virtual void OnFrontDisconnected(int nReason);
			
		///心跳超时警告。当长时间未收到报文时，该方法被调用。
		///@param nTimeLapse 距离上次接收报文的时间
		virtual void OnHeartBeatWarning(int nTimeLapse);
		
		///客户端认证响应
		virtual void OnRspAuthenticate(CThostFtdcRspAuthenticateField *pRspAuthenticateField, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///登录请求响应
		virtual void OnRspUserLogin(CThostFtdcRspUserLoginField *pRspUserLogin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///登出请求响应
		virtual void OnRspUserLogout(CThostFtdcUserLogoutField *pUserLogout, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///用户口令更新请求响应
		virtual void OnRspUserPasswordUpdate(CThostFtdcUserPasswordUpdateField *pUserPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///资金账户口令更新请求响应
		virtual void OnRspTradingAccountPasswordUpdate(CThostFtdcTradingAccountPasswordUpdateField *pTradingAccountPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///报单录入请求响应
		virtual void OnRspOrderInsert(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///预埋单录入请求响应
		virtual void OnRspParkedOrderInsert(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///预埋撤单录入请求响应
		virtual void OnRspParkedOrderAction(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///报单操作请求响应
		virtual void OnRspOrderAction(CThostFtdcInputOrderActionField *pInputOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///查询最大报单数量响应
		virtual void OnRspQueryMaxOrderVolume(CThostFtdcQueryMaxOrderVolumeField *pQueryMaxOrderVolume, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///投资者结算结果确认响应
		virtual void OnRspSettlementInfoConfirm(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///删除预埋单响应
		virtual void OnRspRemoveParkedOrder(CThostFtdcRemoveParkedOrderField *pRemoveParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///删除预埋撤单响应
		virtual void OnRspRemoveParkedOrderAction(CThostFtdcRemoveParkedOrderActionField *pRemoveParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询报单响应
		virtual void OnRspQryOrder(CThostFtdcOrderField *pOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询成交响应
		virtual void OnRspQryTrade(CThostFtdcTradeField *pTrade, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询投资者持仓响应
		virtual void OnRspQryInvestorPosition(CThostFtdcInvestorPositionField *pInvestorPosition, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询资金账户响应
		virtual void OnRspQryTradingAccount(CThostFtdcTradingAccountField *pTradingAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询投资者响应
		virtual void OnRspQryInvestor(CThostFtdcInvestorField *pInvestor, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询交易编码响应
		virtual void OnRspQryTradingCode(CThostFtdcTradingCodeField *pTradingCode, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询合约保证金率响应
		virtual void OnRspQryInstrumentMarginRate(CThostFtdcInstrumentMarginRateField *pInstrumentMarginRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询合约手续费率响应
		virtual void OnRspQryInstrumentCommissionRate(CThostFtdcInstrumentCommissionRateField *pInstrumentCommissionRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询交易所响应
		virtual void OnRspQryExchange(CThostFtdcExchangeField *pExchange, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询合约响应
		virtual void OnRspQryInstrument(CThostFtdcInstrumentField *pInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询行情响应
		virtual void OnRspQryDepthMarketData(CThostFtdcDepthMarketDataField *pDepthMarketData, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询投资者结算结果响应
		virtual void OnRspQrySettlementInfo(CThostFtdcSettlementInfoField *pSettlementInfo, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询转帐银行响应
		virtual void OnRspQryTransferBank(CThostFtdcTransferBankField *pTransferBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询投资者持仓明细响应
		virtual void OnRspQryInvestorPositionDetail(CThostFtdcInvestorPositionDetailField *pInvestorPositionDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询客户通知响应
		virtual void OnRspQryNotice(CThostFtdcNoticeField *pNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询结算信息确认响应
		virtual void OnRspQrySettlementInfoConfirm(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询投资者持仓明细响应
		virtual void OnRspQryInvestorPositionCombineDetail(CThostFtdcInvestorPositionCombineDetailField *pInvestorPositionCombineDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///查询保证金监管系统经纪公司资金账户密钥响应
		virtual void OnRspQryCFMMCTradingAccountKey(CThostFtdcCFMMCTradingAccountKeyField *pCFMMCTradingAccountKey, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询仓单折抵信息响应
		virtual void OnRspQryEWarrantOffset(CThostFtdcEWarrantOffsetField *pEWarrantOffset, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询转帐流水响应
		virtual void OnRspQryTransferSerial(CThostFtdcTransferSerialField *pTransferSerial, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询银期签约关系响应
		virtual void OnRspQryAccountregister(CThostFtdcAccountregisterField *pAccountregister, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///错误应答
		virtual void OnRspError(CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///报单通知
		virtual void OnRtnOrder(CThostFtdcOrderField *pOrder);

		///成交通知
		virtual void OnRtnTrade(CThostFtdcTradeField *pTrade);

		///报单录入错误回报
		virtual void OnErrRtnOrderInsert(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo);

		///报单操作错误回报
		virtual void OnErrRtnOrderAction(CThostFtdcOrderActionField *pOrderAction, CThostFtdcRspInfoField *pRspInfo);

		///合约交易状态通知
		virtual void OnRtnInstrumentStatus(CThostFtdcInstrumentStatusField *pInstrumentStatus);

		///交易通知
		virtual void OnRtnTradingNotice(CThostFtdcTradingNoticeInfoField *pTradingNoticeInfo);

		///提示条件单校验错误
		virtual void OnRtnErrorConditionalOrder(CThostFtdcErrorConditionalOrderField *pErrorConditionalOrder);

		///请求查询签约银行响应
		virtual void OnRspQryContractBank(CThostFtdcContractBankField *pContractBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询预埋单响应
		virtual void OnRspQryParkedOrder(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询预埋撤单响应
		virtual void OnRspQryParkedOrderAction(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询交易通知响应
		virtual void OnRspQryTradingNotice(CThostFtdcTradingNoticeField *pTradingNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询经纪公司交易参数响应
		virtual void OnRspQryBrokerTradingParams(CThostFtdcBrokerTradingParamsField *pBrokerTradingParams, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///请求查询经纪公司交易算法响应
		virtual void OnRspQryBrokerTradingAlgos(CThostFtdcBrokerTradingAlgosField *pBrokerTradingAlgos, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///银行发起银行资金转期货通知
		virtual void OnRtnFromBankToFutureByBank(CThostFtdcRspTransferField *pRspTransfer);

		///银行发起期货资金转银行通知
		virtual void OnRtnFromFutureToBankByBank(CThostFtdcRspTransferField *pRspTransfer);

		///银行发起冲正银行转期货通知
		virtual void OnRtnRepealFromBankToFutureByBank(CThostFtdcRspRepealField *pRspRepeal);

		///银行发起冲正期货转银行通知
		virtual void OnRtnRepealFromFutureToBankByBank(CThostFtdcRspRepealField *pRspRepeal);

		///期货发起银行资金转期货通知
		virtual void OnRtnFromBankToFutureByFuture(CThostFtdcRspTransferField *pRspTransfer);

		///期货发起期货资金转银行通知
		virtual void OnRtnFromFutureToBankByFuture(CThostFtdcRspTransferField *pRspTransfer);

		///系统运行时期货端手工发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
		virtual void OnRtnRepealFromBankToFutureByFutureManual(CThostFtdcRspRepealField *pRspRepeal);

		///系统运行时期货端手工发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
		virtual void OnRtnRepealFromFutureToBankByFutureManual(CThostFtdcRspRepealField *pRspRepeal);

		///期货发起查询银行余额通知
		virtual void OnRtnQueryBankBalanceByFuture(CThostFtdcNotifyQueryAccountField *pNotifyQueryAccount);

		///期货发起银行资金转期货错误回报
		virtual void OnErrRtnBankToFutureByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo);

		///期货发起期货资金转银行错误回报
		virtual void OnErrRtnFutureToBankByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo);

		///系统运行时期货端手工发起冲正银行转期货错误回报
		virtual void OnErrRtnRepealBankToFutureByFutureManual(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo);

		///系统运行时期货端手工发起冲正期货转银行错误回报
		virtual void OnErrRtnRepealFutureToBankByFutureManual(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo);

		///期货发起查询银行余额错误回报
		virtual void OnErrRtnQueryBankBalanceByFuture(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo);

		///期货发起冲正银行转期货请求，银行处理完毕后报盘发回的通知
		virtual void OnRtnRepealFromBankToFutureByFuture(CThostFtdcRspRepealField *pRspRepeal);

		///期货发起冲正期货转银行请求，银行处理完毕后报盘发回的通知
		virtual void OnRtnRepealFromFutureToBankByFuture(CThostFtdcRspRepealField *pRspRepeal);

		///期货发起银行资金转期货应答
		virtual void OnRspFromBankToFutureByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///期货发起期货资金转银行应答
		virtual void OnRspFromFutureToBankByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///期货发起查询银行余额应答
		virtual void OnRspQueryBankAccountMoneyByFuture(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///银行发起银期开户通知
		virtual void OnRtnOpenAccountByBank(CThostFtdcOpenAccountField *pOpenAccount);

		///银行发起银期销户通知
		virtual void OnRtnCancelAccountByBank(CThostFtdcCancelAccountField *pCancelAccount);

		///银行发起变更银行账号通知
		virtual void OnRtnChangeAccountByBank(CThostFtdcChangeAccountField *pChangeAccount);

#ifdef __CTP_MA__
	// 回调函数
	public:
		Callback_OnFrontConnected p_OnFrontConnected;
		Callback_OnFrontDisconnected p_OnFrontDisconnected;
		Callback_OnHeartBeatWarning p_OnHeartBeatWarning;
		Callback_OnRspAuthenticate p_OnRspAuthenticate;
		Callback_OnRspUserLogin p_OnRspUserLogin;
		Callback_OnRspUserLogout p_OnRspUserLogout;
		Callback_OnRspUserPasswordUpdate p_OnRspUserPasswordUpdate;
		Callback_OnRspTradingAccountPasswordUpdate p_OnRspTradingAccountPasswordUpdate;
		Callback_OnRspOrderInsert p_OnRspOrderInsert;
		Callback_OnRspParkedOrderInsert p_OnRspParkedOrderInsert;
		Callback_OnRspParkedOrderAction p_OnRspParkedOrderAction;
		Callback_OnRspOrderAction p_OnRspOrderAction;
		Callback_OnRspQueryMaxOrderVolume p_OnRspQueryMaxOrderVolume;
		Callback_OnRspSettlementInfoConfirm p_OnRspSettlementInfoConfirm;
		Callback_OnRspRemoveParkedOrder p_OnRspRemoveParkedOrder;
		Callback_OnRspRemoveParkedOrderAction p_OnRspRemoveParkedOrderAction;
		Callback_OnRspQryOrder p_OnRspQryOrder;
		Callback_OnRspQryTrade p_OnRspQryTrade;
		Callback_OnRspQryInvestorPosition p_OnRspQryInvestorPosition;
		Callback_OnRspQryTradingAccount p_OnRspQryTradingAccount;
		Callback_OnRspQryInvestor p_OnRspQryInvestor;
		Callback_OnRspQryTradingCode p_OnRspQryTradingCode;
		Callback_OnRspQryInstrumentMarginRate p_OnRspQryInstrumentMarginRate;
		Callback_OnRspQryInstrumentCommissionRate p_OnRspQryInstrumentCommissionRate;
		Callback_OnRspQryExchange p_OnRspQryExchange;
		Callback_OnRspQryInstrument p_OnRspQryInstrument;
		Callback_OnRspQryDepthMarketData p_OnRspQryDepthMarketData;
		Callback_OnRspQrySettlementInfo p_OnRspQrySettlementInfo;
		Callback_OnRspQryTransferBank p_OnRspQryTransferBank;
		Callback_OnRspQryInvestorPositionDetail p_OnRspQryInvestorPositionDetail;
		Callback_OnRspQryNotice p_OnRspQryNotice;
		Callback_OnRspQrySettlementInfoConfirm p_OnRspQrySettlementInfoConfirm;
		Callback_OnRspQryInvestorPositionCombineDetail p_OnRspQryInvestorPositionCombineDetail;
		Callback_OnRspQryCFMMCTradingAccountKey p_OnRspQryCFMMCTradingAccountKey;
		Callback_OnRspQryEWarrantOffset p_OnRspQryEWarrantOffset;
		Callback_OnRspQryTransferSerial p_OnRspQryTransferSerial;
		Callback_OnRspQryAccountregister p_OnRspQryAccountregister;
		Callback_OnRspError p_OnRspError;
		Callback_OnRtnOrder p_OnRtnOrder;
		Callback_OnRtnTrade p_OnRtnTrade;
		Callback_OnErrRtnOrderInsert p_OnErrRtnOrderInsert;
		Callback_OnErrRtnOrderAction p_OnErrRtnOrderAction;
		Callback_OnRtnInstrumentStatus p_OnRtnInstrumentStatus;
		Callback_OnRtnTradingNotice p_OnRtnTradingNotice;
		Callback_OnRtnErrorConditionalOrder p_OnRtnErrorConditionalOrder;
		Callback_OnRspQryContractBank p_OnRspQryContractBank;
		Callback_OnRspQryParkedOrder p_OnRspQryParkedOrder;
		Callback_OnRspQryParkedOrderAction p_OnRspQryParkedOrderAction;
		Callback_OnRspQryTradingNotice p_OnRspQryTradingNotice;
		Callback_OnRspQryBrokerTradingParams p_OnRspQryBrokerTradingParams;
		Callback_OnRspQryBrokerTradingAlgos p_OnRspQryBrokerTradingAlgos;
		Callback_OnRtnFromBankToFutureByBank p_OnRtnFromBankToFutureByBank;
		Callback_OnRtnFromFutureToBankByBank p_OnRtnFromFutureToBankByBank;
		Callback_OnRtnRepealFromBankToFutureByBank p_OnRtnRepealFromBankToFutureByBank;
		Callback_OnRtnRepealFromFutureToBankByBank p_OnRtnRepealFromFutureToBankByBank;
		Callback_OnRtnFromBankToFutureByFuture p_OnRtnFromBankToFutureByFuture;
		Callback_OnRtnFromFutureToBankByFuture p_OnRtnFromFutureToBankByFuture;
		Callback_OnRtnRepealFromBankToFutureByFutureManual p_OnRtnRepealFromBankToFutureByFutureManual;
		Callback_OnRtnRepealFromFutureToBankByFutureManual p_OnRtnRepealFromFutureToBankByFutureManual;
		Callback_OnRtnQueryBankBalanceByFuture p_OnRtnQueryBankBalanceByFuture;
		Callback_OnErrRtnBankToFutureByFuture p_OnErrRtnBankToFutureByFuture;
		Callback_OnErrRtnFutureToBankByFuture p_OnErrRtnFutureToBankByFuture;
		Callback_OnErrRtnRepealBankToFutureByFutureManual p_OnErrRtnRepealBankToFutureByFutureManual;
		Callback_OnErrRtnRepealFutureToBankByFutureManual p_OnErrRtnRepealFutureToBankByFutureManual;
		Callback_OnErrRtnQueryBankBalanceByFuture p_OnErrRtnQueryBankBalanceByFuture;
		Callback_OnRtnRepealFromBankToFutureByFuture p_OnRtnRepealFromBankToFutureByFuture;
		Callback_OnRtnRepealFromFutureToBankByFuture p_OnRtnRepealFromFutureToBankByFuture;
		Callback_OnRspFromBankToFutureByFuture p_OnRspFromBankToFutureByFuture;
		Callback_OnRspFromFutureToBankByFuture p_OnRspFromFutureToBankByFuture;
		Callback_OnRspQueryBankAccountMoneyByFuture p_OnRspQueryBankAccountMoneyByFuture;
		Callback_OnRtnOpenAccountByBank p_OnRtnOpenAccountByBank;
		Callback_OnRtnCancelAccountByBank p_OnRtnCancelAccountByBank;
		Callback_OnRtnChangeAccountByBank p_OnRtnChangeAccountByBank;

		// 回调函数对应的delegate，必须保持一份对该deleage的引用，否则GC会自动回收该deleage并导致上面的回调函数失效
		gcroot<Internal_FrontConnected^> d_FrontConnected;
		gcroot<Internal_FrontDisconnected^> d_FrontDisconnected;
		gcroot<Internal_HeartBeatWarning^> d_HeartBeatWarning;
		gcroot<Internal_RspUserLogin^> d_RspUserLogin;
		gcroot<Internal_RspUserLogout^> d_RspUserLogout;
		gcroot<Internal_RspError^> d_RspError;

		gcroot<Internal_RspAuthenticate^> d_RspAuthenticate;
		gcroot<Internal_RspUserPasswordUpdate^> d_RspUserPasswordUpdate;
		gcroot<Internal_RspTradingAccountPasswordUpdate^> d_RspTradingAccountPasswordUpdate;
		gcroot<Internal_RspOrderInsert^> d_RspOrderInsert;
		gcroot<Internal_RspParkedOrderInsert^> d_RspParkedOrderInsert;
		gcroot<Internal_RspParkedOrderAction^> d_RspParkedOrderAction;
		gcroot<Internal_RspOrderAction^> d_RspOrderAction;
		gcroot<Internal_RspQueryMaxOrderVolume^> d_RspQueryMaxOrderVolume;
		gcroot<Internal_RspSettlementInfoConfirm^> d_RspSettlementInfoConfirm;
		gcroot<Internal_RspRemoveParkedOrder^> d_RspRemoveParkedOrder;
		gcroot<Internal_RspRemoveParkedOrderAction^> d_RspRemoveParkedOrderAction;
		gcroot<Internal_RspQryOrder^> d_RspQryOrder;
		gcroot<Internal_RspQryTrade^> d_RspQryTrade;
		gcroot<Internal_RspQryInvestorPosition^> d_RspQryInvestorPosition;
		gcroot<Internal_RspQryTradingAccount^> d_RspQryTradingAccount;
		gcroot<Internal_RspQryInvestor^> d_RspQryInvestor;
		gcroot<Internal_RspQryTradingCode^> d_RspQryTradingCode;
		gcroot<Internal_RspQryInstrumentMarginRate^> d_RspQryInstrumentMarginRate;
		gcroot<Internal_RspQryInstrumentCommissionRate^> d_RspQryInstrumentCommissionRate;
		gcroot<Internal_RspQryExchange^> d_RspQryExchange;
		gcroot<Internal_RspQryInstrument^> d_RspQryInstrument;
		gcroot<Internal_RspQryDepthMarketData^> d_RspQryDepthMarketData;
		gcroot<Internal_RspQrySettlementInfo^> d_RspQrySettlementInfo;
		gcroot<Internal_RspQryTransferBank^> d_RspQryTransferBank;
		gcroot<Internal_RspQryInvestorPositionDetail^> d_RspQryInvestorPositionDetail;
		gcroot<Internal_RspQryNotice^> d_RspQryNotice;
		gcroot<Internal_RspQrySettlementInfoConfirm^> d_RspQrySettlementInfoConfirm;
		gcroot<Internal_RspQryInvestorPositionCombineDetail^> d_RspQryInvestorPositionCombineDetail;
		gcroot<Internal_RspQryCFMMCTradingAccountKey^> d_RspQryCFMMCTradingAccountKey;
		gcroot<Internal_RspQryEWarrantOffset^> d_RspQryEWarrantOffset;
		gcroot<Internal_RspQryTransferSerial^> d_RspQryTransferSerial;
		gcroot<Internal_RspQryAccountregister^> d_RspQryAccountregister;
		gcroot<Internal_RtnOrder^> d_RtnOrder;
		gcroot<Internal_RtnTrade^> d_RtnTrade;
		gcroot<Internal_ErrRtnOrderInsert^> d_ErrRtnOrderInsert;
		gcroot<Internal_ErrRtnOrderAction^> d_ErrRtnOrderAction;
		gcroot<Internal_RtnInstrumentStatus^> d_RtnInstrumentStatus;
		gcroot<Internal_RtnTradingNotice^> d_RtnTradingNotice;
		gcroot<Internal_RtnErrorConditionalOrder^> d_RtnErrorConditionalOrder;
		gcroot<Internal_RspQryContractBank^> d_RspQryContractBank;
		gcroot<Internal_RspQryParkedOrder^> d_RspQryParkedOrder;
		gcroot<Internal_RspQryParkedOrderAction^> d_RspQryParkedOrderAction;
		gcroot<Internal_RspQryTradingNotice^> d_RspQryTradingNotice;
		gcroot<Internal_RspQryBrokerTradingParams^> d_RspQryBrokerTradingParams;
		gcroot<Internal_RspQryBrokerTradingAlgos^> d_RspQryBrokerTradingAlgos;
		gcroot<Internal_RtnFromBankToFutureByBank^> d_RtnFromBankToFutureByBank;
		gcroot<Internal_RtnFromFutureToBankByBank^> d_RtnFromFutureToBankByBank;
		gcroot<Internal_RtnRepealFromBankToFutureByBank^> d_RtnRepealFromBankToFutureByBank;
		gcroot<Internal_RtnRepealFromFutureToBankByBank^> d_RtnRepealFromFutureToBankByBank;
		gcroot<Internal_RtnFromBankToFutureByFuture^> d_RtnFromBankToFutureByFuture;
		gcroot<Internal_RtnFromFutureToBankByFuture^> d_RtnFromFutureToBankByFuture;
		gcroot<Internal_RtnRepealFromBankToFutureByFutureManual^> d_RtnRepealFromBankToFutureByFutureManual;
		gcroot<Internal_RtnRepealFromFutureToBankByFutureManual^> d_RtnRepealFromFutureToBankByFutureManual;
		gcroot<Internal_RtnQueryBankBalanceByFuture^> d_RtnQueryBankBalanceByFuture;
		gcroot<Internal_ErrRtnBankToFutureByFuture^> d_ErrRtnBankToFutureByFuture;
		gcroot<Internal_ErrRtnFutureToBankByFuture^> d_ErrRtnFutureToBankByFuture;
		gcroot<Internal_ErrRtnRepealBankToFutureByFutureManual^> d_ErrRtnRepealBankToFutureByFutureManual;
		gcroot<Internal_ErrRtnRepealFutureToBankByFutureManual^> d_ErrRtnRepealFutureToBankByFutureManual;
		gcroot<Internal_ErrRtnQueryBankBalanceByFuture^> d_ErrRtnQueryBankBalanceByFuture;
		gcroot<Internal_RtnRepealFromBankToFutureByFuture^> d_RtnRepealFromBankToFutureByFuture;
		gcroot<Internal_RtnRepealFromFutureToBankByFuture^> d_RtnRepealFromFutureToBankByFuture;
		gcroot<Internal_RspFromBankToFutureByFuture^> d_RspFromBankToFutureByFuture;
		gcroot<Internal_RspFromFutureToBankByFuture^> d_RspFromFutureToBankByFuture;
		gcroot<Internal_RspQueryBankAccountMoneyByFuture^> d_RspQueryBankAccountMoneyByFuture;
		gcroot<Internal_RtnOpenAccountByBank^> d_RtnOpenAccountByBank;
		gcroot<Internal_RtnCancelAccountByBank^> d_RtnCancelAccountByBank;
		gcroot<Internal_RtnChangeAccountByBank^> d_RtnChangeAccountByBank;
#else
private:
		gcroot<CTPTDAdapter^> m_pAdapter;
#endif

	};

};