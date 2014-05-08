/////////////////////////////////////////////////////////////////////////
/// 上期技术 CTP C++ => .Net Framework Adapter
/// Author:	shawn666.liu@gmail.com
/// Date: 20120420
/////////////////////////////////////////////////////////////////////////
#pragma once

namespace CTP
{
	// common deleagats
	public delegate void FrontConnected();
	public delegate void FrontDisconnected(int nReason);
	public delegate void HeartBeatWarning(int nTimeLapse);
	public delegate void RspUserLogin(ThostFtdcRspUserLoginField^ pRspUserLogin, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspUserLogout(ThostFtdcUserLogoutField^ pUserLogout, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspError(ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);

	// marketdata 
	public delegate void RspSubMarketData(ThostFtdcSpecificInstrumentField^ pSpecificInstrument, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspUnSubMarketData(ThostFtdcSpecificInstrumentField^ pSpecificInstrument, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RtnDepthMarketData(ThostFtdcDepthMarketDataField^ pDepthMarketData);

	// trader
	public delegate void RspAuthenticate(ThostFtdcRspAuthenticateField^ pRspAuthenticateField, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspUserPasswordUpdate(ThostFtdcUserPasswordUpdateField^ pUserPasswordUpdate, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspTradingAccountPasswordUpdate(ThostFtdcTradingAccountPasswordUpdateField^ pTradingAccountPasswordUpdate, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspOrderInsert(ThostFtdcInputOrderField^ pInputOrder, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspParkedOrderInsert(ThostFtdcParkedOrderField^ pParkedOrder, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspParkedOrderAction(ThostFtdcParkedOrderActionField^ pParkedOrderAction, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspOrderAction(ThostFtdcInputOrderActionField^ pInputOrderAction, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQueryMaxOrderVolume(ThostFtdcQueryMaxOrderVolumeField^ pQueryMaxOrderVolume, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspSettlementInfoConfirm(ThostFtdcSettlementInfoConfirmField^ pSettlementInfoConfirm, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspRemoveParkedOrder(ThostFtdcRemoveParkedOrderField^ pRemoveParkedOrder, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspRemoveParkedOrderAction(ThostFtdcRemoveParkedOrderActionField^ pRemoveParkedOrderAction, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryOrder(ThostFtdcOrderField^ pOrder, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryTrade(ThostFtdcTradeField^ pTrade, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryInvestorPosition(ThostFtdcInvestorPositionField^ pInvestorPosition, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryTradingAccount(ThostFtdcTradingAccountField^ pTradingAccount, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryInvestor(ThostFtdcInvestorField^ pInvestor, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryTradingCode(ThostFtdcTradingCodeField^ pTradingCode, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryInstrumentMarginRate(ThostFtdcInstrumentMarginRateField^ pInstrumentMarginRate, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryInstrumentCommissionRate(ThostFtdcInstrumentCommissionRateField^ pInstrumentCommissionRate, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryExchange(ThostFtdcExchangeField^ pExchange, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryInstrument(ThostFtdcInstrumentField^ pInstrument, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryDepthMarketData(ThostFtdcDepthMarketDataField^ pDepthMarketData, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQrySettlementInfo(ThostFtdcSettlementInfoField^ pSettlementInfo, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryTransferBank(ThostFtdcTransferBankField^ pTransferBank, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryInvestorPositionDetail(ThostFtdcInvestorPositionDetailField^ pInvestorPositionDetail, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryNotice(ThostFtdcNoticeField^ pNotice, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQrySettlementInfoConfirm(ThostFtdcSettlementInfoConfirmField^ pSettlementInfoConfirm, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryInvestorPositionCombineDetail(ThostFtdcInvestorPositionCombineDetailField^ pInvestorPositionCombineDetail, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryCFMMCTradingAccountKey(ThostFtdcCFMMCTradingAccountKeyField^ pCFMMCTradingAccountKey, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryEWarrantOffset(ThostFtdcEWarrantOffsetField^ pEWarrantOffset, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryTransferSerial(ThostFtdcTransferSerialField^ pTransferSerial, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryAccountregister(ThostFtdcAccountregisterField^ pAccountregister, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RtnOrder(ThostFtdcOrderField^ pOrder);
	public delegate void RtnTrade(ThostFtdcTradeField^ pTrade);
	public delegate void ErrRtnOrderInsert(ThostFtdcInputOrderField^ pInputOrder, ThostFtdcRspInfoField^ pRspInfo);
	public delegate void ErrRtnOrderAction(ThostFtdcOrderActionField^ pOrderAction, ThostFtdcRspInfoField^ pRspInfo);
	public delegate void RtnInstrumentStatus(ThostFtdcInstrumentStatusField^ pInstrumentStatus);
	public delegate void RtnTradingNotice(ThostFtdcTradingNoticeInfoField^ pTradingNoticeInfo);
	public delegate void RtnErrorConditionalOrder(ThostFtdcErrorConditionalOrderField^ pErrorConditionalOrder);
	public delegate void RspQryContractBank(ThostFtdcContractBankField^ pContractBank, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryParkedOrder(ThostFtdcParkedOrderField^ pParkedOrder, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryParkedOrderAction(ThostFtdcParkedOrderActionField^ pParkedOrderAction, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryTradingNotice(ThostFtdcTradingNoticeField^ pTradingNotice, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryBrokerTradingParams(ThostFtdcBrokerTradingParamsField^ pBrokerTradingParams, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQryBrokerTradingAlgos(ThostFtdcBrokerTradingAlgosField^ pBrokerTradingAlgos, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RtnFromBankToFutureByBank(ThostFtdcRspTransferField^ pRspTransfer);
	public delegate void RtnFromFutureToBankByBank(ThostFtdcRspTransferField^ pRspTransfer);
	public delegate void RtnRepealFromBankToFutureByBank(ThostFtdcRspRepealField^ pRspRepeal);
	public delegate void RtnRepealFromFutureToBankByBank(ThostFtdcRspRepealField^ pRspRepeal);
	public delegate void RtnFromBankToFutureByFuture(ThostFtdcRspTransferField^ pRspTransfer);
	public delegate void RtnFromFutureToBankByFuture(ThostFtdcRspTransferField^ pRspTransfer);
	public delegate void RtnRepealFromBankToFutureByFutureManual(ThostFtdcRspRepealField^ pRspRepeal);
	public delegate void RtnRepealFromFutureToBankByFutureManual(ThostFtdcRspRepealField^ pRspRepeal);
	public delegate void RtnQueryBankBalanceByFuture(ThostFtdcNotifyQueryAccountField^ pNotifyQueryAccount);
	public delegate void ErrRtnBankToFutureByFuture(ThostFtdcReqTransferField^ pReqTransfer, ThostFtdcRspInfoField^ pRspInfo);
	public delegate void ErrRtnFutureToBankByFuture(ThostFtdcReqTransferField^ pReqTransfer, ThostFtdcRspInfoField^ pRspInfo);
	public delegate void ErrRtnRepealBankToFutureByFutureManual(ThostFtdcReqRepealField^ pReqRepeal, ThostFtdcRspInfoField^ pRspInfo);
	public delegate void ErrRtnRepealFutureToBankByFutureManual(ThostFtdcReqRepealField^ pReqRepeal, ThostFtdcRspInfoField^ pRspInfo);
	public delegate void ErrRtnQueryBankBalanceByFuture(ThostFtdcReqQueryAccountField^ pReqQueryAccount, ThostFtdcRspInfoField^ pRspInfo);
	public delegate void RtnRepealFromBankToFutureByFuture(ThostFtdcRspRepealField^ pRspRepeal);
	public delegate void RtnRepealFromFutureToBankByFuture(ThostFtdcRspRepealField^ pRspRepeal);
	public delegate void RspFromBankToFutureByFuture(ThostFtdcReqTransferField^ pReqTransfer, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspFromFutureToBankByFuture(ThostFtdcReqTransferField^ pReqTransfer, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RspQueryBankAccountMoneyByFuture(ThostFtdcReqQueryAccountField^ pReqQueryAccount, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast);
	public delegate void RtnOpenAccountByBank(ThostFtdcOpenAccountField^ pOpenAccount);
	public delegate void RtnCancelAccountByBank(ThostFtdcCancelAccountField^ pCancelAccount);
	public delegate void RtnChangeAccountByBank(ThostFtdcChangeAccountField^ pChangeAccount);
};

#ifdef __CTP_MA__

namespace Native
{
	delegate void Internal_FrontConnected();
	delegate void Internal_FrontDisconnected(int nReason);
	delegate void Internal_HeartBeatWarning(int nTimeLapse);
	delegate void Internal_RspUserLogin(CThostFtdcRspUserLoginField *pRspUserLogin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspUserLogout(CThostFtdcUserLogoutField *pUserLogout, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspError(CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

	delegate void Internal_RspSubMarketData(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspUnSubMarketData(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RtnDepthMarketData(CThostFtdcDepthMarketDataField *pDepthMarketData);

	delegate void Internal_RspAuthenticate(CThostFtdcRspAuthenticateField *pRspAuthenticateField, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspUserPasswordUpdate(CThostFtdcUserPasswordUpdateField *pUserPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspTradingAccountPasswordUpdate(CThostFtdcTradingAccountPasswordUpdateField *pTradingAccountPasswordUpdate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspOrderInsert(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspParkedOrderInsert(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspParkedOrderAction(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspOrderAction(CThostFtdcInputOrderActionField *pInputOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQueryMaxOrderVolume(CThostFtdcQueryMaxOrderVolumeField *pQueryMaxOrderVolume, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspSettlementInfoConfirm(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspRemoveParkedOrder(CThostFtdcRemoveParkedOrderField *pRemoveParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspRemoveParkedOrderAction(CThostFtdcRemoveParkedOrderActionField *pRemoveParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryOrder(CThostFtdcOrderField *pOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryTrade(CThostFtdcTradeField *pTrade, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryInvestorPosition(CThostFtdcInvestorPositionField *pInvestorPosition, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryTradingAccount(CThostFtdcTradingAccountField *pTradingAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryInvestor(CThostFtdcInvestorField *pInvestor, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryTradingCode(CThostFtdcTradingCodeField *pTradingCode, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryInstrumentMarginRate(CThostFtdcInstrumentMarginRateField *pInstrumentMarginRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryInstrumentCommissionRate(CThostFtdcInstrumentCommissionRateField *pInstrumentCommissionRate, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryExchange(CThostFtdcExchangeField *pExchange, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryInstrument(CThostFtdcInstrumentField *pInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryDepthMarketData(CThostFtdcDepthMarketDataField *pDepthMarketData, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQrySettlementInfo(CThostFtdcSettlementInfoField *pSettlementInfo, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryTransferBank(CThostFtdcTransferBankField *pTransferBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryInvestorPositionDetail(CThostFtdcInvestorPositionDetailField *pInvestorPositionDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryNotice(CThostFtdcNoticeField *pNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQrySettlementInfoConfirm(CThostFtdcSettlementInfoConfirmField *pSettlementInfoConfirm, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryInvestorPositionCombineDetail(CThostFtdcInvestorPositionCombineDetailField *pInvestorPositionCombineDetail, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryCFMMCTradingAccountKey(CThostFtdcCFMMCTradingAccountKeyField *pCFMMCTradingAccountKey, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryEWarrantOffset(CThostFtdcEWarrantOffsetField *pEWarrantOffset, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryTransferSerial(CThostFtdcTransferSerialField *pTransferSerial, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryAccountregister(CThostFtdcAccountregisterField *pAccountregister, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RtnOrder(CThostFtdcOrderField *pOrder);
	delegate void Internal_RtnTrade(CThostFtdcTradeField *pTrade);
	delegate void Internal_ErrRtnOrderInsert(CThostFtdcInputOrderField *pInputOrder, CThostFtdcRspInfoField *pRspInfo);
	delegate void Internal_ErrRtnOrderAction(CThostFtdcOrderActionField *pOrderAction, CThostFtdcRspInfoField *pRspInfo);
	delegate void Internal_RtnInstrumentStatus(CThostFtdcInstrumentStatusField *pInstrumentStatus);
	delegate void Internal_RtnTradingNotice(CThostFtdcTradingNoticeInfoField *pTradingNoticeInfo);
	delegate void Internal_RtnErrorConditionalOrder(CThostFtdcErrorConditionalOrderField *pErrorConditionalOrder);
	delegate void Internal_RspQryContractBank(CThostFtdcContractBankField *pContractBank, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryParkedOrder(CThostFtdcParkedOrderField *pParkedOrder, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryParkedOrderAction(CThostFtdcParkedOrderActionField *pParkedOrderAction, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryTradingNotice(CThostFtdcTradingNoticeField *pTradingNotice, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryBrokerTradingParams(CThostFtdcBrokerTradingParamsField *pBrokerTradingParams, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQryBrokerTradingAlgos(CThostFtdcBrokerTradingAlgosField *pBrokerTradingAlgos, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RtnFromBankToFutureByBank(CThostFtdcRspTransferField *pRspTransfer);
	delegate void Internal_RtnFromFutureToBankByBank(CThostFtdcRspTransferField *pRspTransfer);
	delegate void Internal_RtnRepealFromBankToFutureByBank(CThostFtdcRspRepealField *pRspRepeal);
	delegate void Internal_RtnRepealFromFutureToBankByBank(CThostFtdcRspRepealField *pRspRepeal);
	delegate void Internal_RtnFromBankToFutureByFuture(CThostFtdcRspTransferField *pRspTransfer);
	delegate void Internal_RtnFromFutureToBankByFuture(CThostFtdcRspTransferField *pRspTransfer);
	delegate void Internal_RtnRepealFromBankToFutureByFutureManual(CThostFtdcRspRepealField *pRspRepeal);
	delegate void Internal_RtnRepealFromFutureToBankByFutureManual(CThostFtdcRspRepealField *pRspRepeal);
	delegate void Internal_RtnQueryBankBalanceByFuture(CThostFtdcNotifyQueryAccountField *pNotifyQueryAccount);
	delegate void Internal_ErrRtnBankToFutureByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo);
	delegate void Internal_ErrRtnFutureToBankByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo);
	delegate void Internal_ErrRtnRepealBankToFutureByFutureManual(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo);
	delegate void Internal_ErrRtnRepealFutureToBankByFutureManual(CThostFtdcReqRepealField *pReqRepeal, CThostFtdcRspInfoField *pRspInfo);
	delegate void Internal_ErrRtnQueryBankBalanceByFuture(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo);
	delegate void Internal_RtnRepealFromBankToFutureByFuture(CThostFtdcRspRepealField *pRspRepeal);
	delegate void Internal_RtnRepealFromFutureToBankByFuture(CThostFtdcRspRepealField *pRspRepeal);
	delegate void Internal_RspFromBankToFutureByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspFromFutureToBankByFuture(CThostFtdcReqTransferField *pReqTransfer, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RspQueryBankAccountMoneyByFuture(CThostFtdcReqQueryAccountField *pReqQueryAccount, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
	delegate void Internal_RtnOpenAccountByBank(CThostFtdcOpenAccountField *pOpenAccount);
	delegate void Internal_RtnCancelAccountByBank(CThostFtdcCancelAccountField *pCancelAccount);
	delegate void Internal_RtnChangeAccountByBank(CThostFtdcChangeAccountField *pChangeAccount);
};

#endif

