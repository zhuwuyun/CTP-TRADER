/////////////////////////////////////////////////////////////////////////
/// 上期技术 CTP C++ => .Net Framework Adapter
/// Author:	shawn666.liu@gmail.com
/// Date: 20121027
/////////////////////////////////////////////////////////////////////////
#pragma once

// CTP MA only
#ifdef __CTP_MA__

namespace Native
{
	// common 
	typedef void (__stdcall *Callback_OnFrontConnected)();
	typedef void (__stdcall *Callback_OnFrontDisconnected)(int nReason);
	typedef void (__stdcall *Callback_OnHeartBeatWarning)(int nTimeLapse);
	typedef void (__stdcall *Callback_OnRspUserLogin)(CThostFtdcRspUserLoginField *pRspUserLogin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspUserLogout)(CThostFtdcUserLogoutField *pUserLogout, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspError)(CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

	// marketdata
	typedef void (__stdcall *Callback_OnRspSubMarketData)(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspUnSubMarketData)(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRtnDepthMarketData)(CThostFtdcDepthMarketDataField *pDepthMarketData);

	// trader
	typedef void (__stdcall *Callback_OnRspAuthenticate)(CThostFtdcRspAuthenticateField *pRspAuthenticateField, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspUserPasswordUpdate)(CThostFtdcUserPasswordUpdateField *pUserPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspTradingAccountPasswordUpdate)(CThostFtdcTradingAccountPasswordUpdateField *pTradingAccountPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspOrderInsert)(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspParkedOrderInsert)(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspParkedOrderAction)(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspOrderAction)(CThostFtdcInputOrderActionField *pInputOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQueryMaxOrderVolume)(CThostFtdcQueryMaxOrderVolumeField *pQueryMaxOrderVolume, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspSettlementInfoConfirm)(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspRemoveParkedOrder)(CThostFtdcRemoveParkedOrderField *pRemoveParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspRemoveParkedOrderAction)(CThostFtdcRemoveParkedOrderActionField *pRemoveParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryOrder)(CThostFtdcOrderField *pOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryTrade)(CThostFtdcTradeField *pTrade, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryInvestorPosition)(CThostFtdcInvestorPositionField *pInvestorPosition, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryTradingAccount)(CThostFtdcTradingAccountField *pTradingAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryInvestor)(CThostFtdcInvestorField *pInvestor, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryTradingCode)(CThostFtdcTradingCodeField *pTradingCode, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryInstrumentMarginRate)(CThostFtdcInstrumentMarginRateField *pInstrumentMarginRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryInstrumentCommissionRate)(CThostFtdcInstrumentCommissionRateField *pInstrumentCommissionRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryExchange)(CThostFtdcExchangeField *pExchange, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryInstrument)(CThostFtdcInstrumentField *pInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryDepthMarketData)(CThostFtdcDepthMarketDataField *pDepthMarketData, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQrySettlementInfo)(CThostFtdcSettlementInfoField *pSettlementInfo, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryTransferBank)(CThostFtdcTransferBankField *pTransferBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryInvestorPositionDetail)(CThostFtdcInvestorPositionDetailField *pInvestorPositionDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryNotice)(CThostFtdcNoticeField *pNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQrySettlementInfoConfirm)(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryInvestorPositionCombineDetail)(CThostFtdcInvestorPositionCombineDetailField *pInvestorPositionCombineDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryCFMMCTradingAccountKey)(CThostFtdcCFMMCTradingAccountKeyField *pCFMMCTradingAccountKey, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryEWarrantOffset)(CThostFtdcEWarrantOffsetField *pEWarrantOffset, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryTransferSerial)(CThostFtdcTransferSerialField *pTransferSerial, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryAccountregister)(CThostFtdcAccountregisterField *pAccountregister, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);	
	typedef void (__stdcall *Callback_OnRtnOrder)(CThostFtdcOrderField *pOrder);
	typedef void (__stdcall *Callback_OnRtnTrade)(CThostFtdcTradeField *pTrade);
	typedef void (__stdcall *Callback_OnErrRtnOrderInsert)(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo);
	typedef void (__stdcall *Callback_OnErrRtnOrderAction)(CThostFtdcOrderActionField *pOrderAction, CThostFtdcRspInfoField *pRspInfo);
	typedef void (__stdcall *Callback_OnRtnInstrumentStatus)(CThostFtdcInstrumentStatusField *pInstrumentStatus);
	typedef void (__stdcall *Callback_OnRtnTradingNotice)(CThostFtdcTradingNoticeInfoField *pTradingNoticeInfo);
	typedef void (__stdcall *Callback_OnRtnErrorConditionalOrder)(CThostFtdcErrorConditionalOrderField *pErrorConditionalOrder);
	typedef void (__stdcall *Callback_OnRspQryContractBank)(CThostFtdcContractBankField *pContractBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryParkedOrder)(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryParkedOrderAction)(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryTradingNotice)(CThostFtdcTradingNoticeField *pTradingNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryBrokerTradingParams)(CThostFtdcBrokerTradingParamsField *pBrokerTradingParams, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQryBrokerTradingAlgos)(CThostFtdcBrokerTradingAlgosField *pBrokerTradingAlgos, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRtnFromBankToFutureByBank)(CThostFtdcRspTransferField *pRspTransfer);
	typedef void (__stdcall *Callback_OnRtnFromFutureToBankByBank)(CThostFtdcRspTransferField *pRspTransfer);
	typedef void (__stdcall *Callback_OnRtnRepealFromBankToFutureByBank)(CThostFtdcRspRepealField *pRspRepeal);
	typedef void (__stdcall *Callback_OnRtnRepealFromFutureToBankByBank)(CThostFtdcRspRepealField *pRspRepeal);
	typedef void (__stdcall *Callback_OnRtnFromBankToFutureByFuture)(CThostFtdcRspTransferField *pRspTransfer);
	typedef void (__stdcall *Callback_OnRtnFromFutureToBankByFuture)(CThostFtdcRspTransferField *pRspTransfer);
	typedef void (__stdcall *Callback_OnRtnRepealFromBankToFutureByFutureManual)(CThostFtdcRspRepealField *pRspRepeal);
	typedef void (__stdcall *Callback_OnRtnRepealFromFutureToBankByFutureManual)(CThostFtdcRspRepealField *pRspRepeal);
	typedef void (__stdcall *Callback_OnRtnQueryBankBalanceByFuture)(CThostFtdcNotifyQueryAccountField *pNotifyQueryAccount);
	typedef void (__stdcall *Callback_OnErrRtnBankToFutureByFuture)(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo);
	typedef void (__stdcall *Callback_OnErrRtnFutureToBankByFuture)(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo);
	typedef void (__stdcall *Callback_OnErrRtnRepealBankToFutureByFutureManual)(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo);
	typedef void (__stdcall *Callback_OnErrRtnRepealFutureToBankByFutureManual)(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo);
	typedef void (__stdcall *Callback_OnErrRtnQueryBankBalanceByFuture)(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo);
	typedef void (__stdcall *Callback_OnRtnRepealFromBankToFutureByFuture)(CThostFtdcRspRepealField *pRspRepeal);
	typedef void (__stdcall *Callback_OnRtnRepealFromFutureToBankByFuture)(CThostFtdcRspRepealField *pRspRepeal);
	typedef void (__stdcall *Callback_OnRspFromBankToFutureByFuture)(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspFromFutureToBankByFuture)(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRspQueryBankAccountMoneyByFuture)(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	typedef void (__stdcall *Callback_OnRtnOpenAccountByBank)(CThostFtdcOpenAccountField *pOpenAccount);
	typedef void (__stdcall *Callback_OnRtnCancelAccountByBank)(CThostFtdcCancelAccountField *pCancelAccount);
	typedef void (__stdcall *Callback_OnRtnChangeAccountByBank)(CThostFtdcChangeAccountField *pChangeAccount);
};
#endif

