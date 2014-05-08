
#include "StdAfx.h"
#include "MdSpi.h"
#include "CTPMDAdapter.h"
#include <memory.h>


namespace CTP
{

CTPMDAdapter::CTPMDAdapter(void)
{
	m_pApi = CThostFtdcMdApi::CreateFtdcMdApi();
	m_pSpi = new CMdSpi(this);
#ifdef __CTP_MA__
	RegisterCallbacks();
#endif
	m_pApi->RegisterSpi(m_pSpi);
}

CTPMDAdapter::CTPMDAdapter(String^ pszFlowPath, bool bIsUsingUdp)
{
	CAutoStrPtr asp(pszFlowPath);
	m_pApi = CThostFtdcMdApi::CreateFtdcMdApi(asp.m_pChar, bIsUsingUdp);
	m_pSpi = new CMdSpi(this);
#ifdef __CTP_MA__
	RegisterCallbacks();
#endif	
	m_pApi->RegisterSpi(m_pSpi);
}

CTPMDAdapter::~CTPMDAdapter(void)
{
	Release();
}

void CTPMDAdapter::Release(void)
{
	if(m_pApi)
	{
		m_pApi->RegisterSpi(0);
		m_pApi->Release();
		m_pApi = nullptr;
		delete m_pSpi;
		m_pSpi = nullptr;
	}
}

void CTPMDAdapter::RegisterFront(String^  pszFrontAddress)
{
	CAutoStrPtr asp = CAutoStrPtr(pszFrontAddress);
	m_pApi->RegisterFront(asp.m_pChar);
}

void CTPMDAdapter::RegisterNameServer(String^  pszNsAddress)
{
	CAutoStrPtr asp = CAutoStrPtr(pszNsAddress);
	m_pApi->RegisterNameServer(asp.m_pChar);
}

void CTPMDAdapter::RegisterFensUserInfo(ThostFtdcFensUserInfoField^ pFensUserInfo)
{
	CThostFtdcFensUserInfoField native;
	MNConv<ThostFtdcFensUserInfoField^, CThostFtdcFensUserInfoField>::M2N(pFensUserInfo, &native);
	m_pApi->RegisterFensUserInfo(&native);
}

void CTPMDAdapter::Init(void)
{
	m_pApi->Init();
}

void CTPMDAdapter::Join(void)
{
	m_pApi->Join();
}

String^ CTPMDAdapter::GetTradingDay()
{
	return gcnew String(m_pApi->GetTradingDay());
}

int CTPMDAdapter::ReqUserLogin(ThostFtdcReqUserLoginField^ pReqUserLoginField, int nRequestID)
{
	CThostFtdcReqUserLoginField native;
	MNConv<ThostFtdcReqUserLoginField^, CThostFtdcReqUserLoginField>::M2N(pReqUserLoginField, &native);
	return m_pApi->ReqUserLogin(&native, nRequestID);
}

int CTPMDAdapter::ReqUserLogout(ThostFtdcUserLogoutField^ pUserLogout, int nRequestID)
{
	CThostFtdcUserLogoutField native;
	MNConv<ThostFtdcUserLogoutField^, CThostFtdcUserLogoutField>::M2N(pUserLogout, &native);
	return m_pApi->ReqUserLogout(&native, nRequestID);
}

int CTPMDAdapter::SubscribeMarketData(array<String^>^ ppInstrumentID)
{
	if(ppInstrumentID == nullptr || ppInstrumentID->Length <= 0)
		return -1;

	int count = ppInstrumentID->Length;
	char** pp = new char*[count];
	CAutoStrPtr** asp = new CAutoStrPtr*[count];
	for(int i=0; i<count; i++)
	{
		CAutoStrPtr* ptr = new CAutoStrPtr(ppInstrumentID[i]);
		asp[i] = ptr;
		pp[i] = ptr->m_pChar;
	}

	int result = m_pApi->SubscribeMarketData(pp, count);

	// 释放所有分配的字符串内存
	for(int i=0; i<count; i++)
		delete asp[i];
	delete asp;
	delete pp;

	return result;
}

int CTPMDAdapter::UnSubscribeMarketData(array<String^>^ ppInstrumentID)
{
	if(ppInstrumentID == nullptr || ppInstrumentID->Length <= 0)
		return -1;

	int count = ppInstrumentID->Length;
	char** pp = new char*[count];
	CAutoStrPtr** asp = new CAutoStrPtr*[count];
	for(int i=0; i<count; i++)
	{
		CAutoStrPtr* ptr = new CAutoStrPtr(ppInstrumentID[i]);
		asp[i] = ptr;
		pp[i] = ptr->m_pChar;
	}

	int result = m_pApi->UnSubscribeMarketData(pp, count);

	// 释放所分配的字符串内存
	for(int i=0; i<count; i++)
		delete asp[i];
	delete asp;
	delete pp;

	return result;
}

#ifdef __CTP_MA__

// 将所有回调函数地址传递给SPI，并保存对delegate的引用
void CTPMDAdapter::RegisterCallbacks()
{
	m_pSpi->d_FrontConnected = gcnew Internal_FrontConnected(this, &CTPMDAdapter::cbk_OnFrontConnected);
	m_pSpi->p_OnFrontConnected = (Callback_OnFrontConnected)Marshal::GetFunctionPointerForDelegate(m_pSpi->d_FrontConnected).ToPointer();

	m_pSpi->d_FrontDisconnected = gcnew Internal_FrontDisconnected(this, &CTPMDAdapter::cbk_OnFrontDisconnected);
	m_pSpi->p_OnFrontDisconnected = (Callback_OnFrontDisconnected)Marshal::GetFunctionPointerForDelegate(m_pSpi->d_FrontDisconnected).ToPointer();

	m_pSpi->d_HeartBeatWarning = gcnew Internal_HeartBeatWarning(this, &CTPMDAdapter::cbk_OnHeartBeatWarning);
	m_pSpi->p_OnHeartBeatWarning = (Callback_OnHeartBeatWarning)Marshal::GetFunctionPointerForDelegate(m_pSpi->d_HeartBeatWarning).ToPointer();

	m_pSpi->d_RspUserLogin = gcnew Internal_RspUserLogin(this, &CTPMDAdapter::cbk_OnRspUserLogin);
	m_pSpi->p_OnRspUserLogin = (Callback_OnRspUserLogin)Marshal::GetFunctionPointerForDelegate(m_pSpi->d_RspUserLogin).ToPointer();

	m_pSpi->d_RspUserLogout = gcnew Internal_RspUserLogout(this, &CTPMDAdapter::cbk_OnRspUserLogout);
	m_pSpi->p_OnRspUserLogout = (Callback_OnRspUserLogout)Marshal::GetFunctionPointerForDelegate(m_pSpi->d_RspUserLogout).ToPointer();

	m_pSpi->d_RspError = gcnew Internal_RspError(this, &CTPMDAdapter::cbk_OnRspError);
	m_pSpi->p_OnRspError = (Callback_OnRspError)Marshal::GetFunctionPointerForDelegate(m_pSpi->d_RspError).ToPointer();

	m_pSpi->d_RspSubMarketData = gcnew Internal_RspSubMarketData(this, &CTPMDAdapter::cbk_OnRspSubMarketData);
	m_pSpi->p_OnRspSubMarketData = (Callback_OnRspSubMarketData)Marshal::GetFunctionPointerForDelegate(m_pSpi->d_RspSubMarketData).ToPointer();

	m_pSpi->d_RspUnSubMarketData = gcnew Internal_RspUnSubMarketData(this, &CTPMDAdapter::cbk_OnRspUnSubMarketData);
	m_pSpi->p_OnRspUnSubMarketData = (Callback_OnRspUnSubMarketData)Marshal::GetFunctionPointerForDelegate(m_pSpi->d_RspUnSubMarketData).ToPointer();

	m_pSpi->d_RtnDepthMarketData = gcnew Internal_RtnDepthMarketData(this, &CTPMDAdapter::cbk_OnRtnDepthMarketData);
	m_pSpi->p_OnRtnDepthMarketData = (Callback_OnRtnDepthMarketData)Marshal::GetFunctionPointerForDelegate(m_pSpi->d_RtnDepthMarketData).ToPointer();
}

// ------------------------------------ Callbacks ------------------------------------
void CTPMDAdapter::cbk_OnFrontConnected(){
	this->OnFrontConnected();
}
void CTPMDAdapter::cbk_OnFrontDisconnected(int nReason){
	this->OnFrontDisconnected(nReason);
}
void CTPMDAdapter::cbk_OnHeartBeatWarning(int nTimeLapse){
	this->OnHeartBeatWarning(nTimeLapse);
}
void CTPMDAdapter::cbk_OnRspUserLogin(CThostFtdcRspUserLoginField *pRspUserLogin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast){
	this->OnRspUserLogin(MNConv<ThostFtdcRspUserLoginField^, CThostFtdcRspUserLoginField>::N2M(pRspUserLogin), RspInfoField(pRspInfo), nRequestID, bIsLast);
}
void CTPMDAdapter::cbk_OnRspUserLogout(CThostFtdcUserLogoutField *pUserLogout, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast){
	this->OnRspUserLogout(MNConv<ThostFtdcUserLogoutField^, CThostFtdcUserLogoutField>::N2M(pUserLogout), RspInfoField(pRspInfo), nRequestID, bIsLast);
}
void CTPMDAdapter::cbk_OnRspError(CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast){
	this->OnRspError(RspInfoField(pRspInfo), nRequestID, bIsLast);
}
void CTPMDAdapter::cbk_OnRspSubMarketData(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast){
	this->OnRspSubMarketData(MNConv<ThostFtdcSpecificInstrumentField^, CThostFtdcSpecificInstrumentField>::N2M(pSpecificInstrument), RspInfoField(pRspInfo), nRequestID, bIsLast);
}
void CTPMDAdapter::cbk_OnRspUnSubMarketData(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast){
	this->OnRspUnSubMarketData(MNConv<ThostFtdcSpecificInstrumentField^, CThostFtdcSpecificInstrumentField>::N2M(pSpecificInstrument), RspInfoField(pRspInfo), nRequestID, bIsLast);
}
void CTPMDAdapter::cbk_OnRtnDepthMarketData(CThostFtdcDepthMarketDataField *pDepthMarketData){
	ThostFtdcDepthMarketDataField^ field = safe_cast<ThostFtdcDepthMarketDataField^>(Marshal::PtrToStructure(IntPtr(pDepthMarketData), ThostFtdcDepthMarketDataField::typeid));
	this->OnRtnDepthMarketData(field);
}
#endif


}// end of namespace