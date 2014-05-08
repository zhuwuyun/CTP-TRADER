/////////////////////////////////////////////////////////////////////////
/// 上期技术 CTP C++ => .Net Framework Adapter
/// Author:	shawn666.liu@gmail.com
/// Date: 20120420
/////////////////////////////////////////////////////////////////////////

#pragma once

#include <vcclr.h>
#include "util.h"
#include "Callbacks.h"
#include "CTPMdAdapter.h"


namespace Native
{
	/// 非托管类
	class CMdSpi : public CThostFtdcMdSpi
	{
	public:
		/// 构造函数
		CMdSpi(CTPMDAdapter^ pAdapter);

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
		
		///登录请求响应
		virtual void OnRspUserLogin(CThostFtdcRspUserLoginField *pRspUserLogin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///登出请求响应
		virtual void OnRspUserLogout(CThostFtdcUserLogoutField *pUserLogout, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///错误应答
		virtual void OnRspError(CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///订阅行情应答
		virtual void OnRspSubMarketData(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///取消订阅行情应答
		virtual void OnRspUnSubMarketData(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);

		///深度行情通知
		virtual void OnRtnDepthMarketData(CThostFtdcDepthMarketDataField *pDepthMarketData);
	
#ifdef __CTP_MA__
	public:
		// 回调函数
		Callback_OnFrontConnected p_OnFrontConnected;
		Callback_OnFrontDisconnected p_OnFrontDisconnected;
		Callback_OnHeartBeatWarning p_OnHeartBeatWarning;
		Callback_OnRspUserLogin p_OnRspUserLogin;
		Callback_OnRspUserLogout p_OnRspUserLogout;
		Callback_OnRspError p_OnRspError;
		Callback_OnRspSubMarketData p_OnRspSubMarketData;
		Callback_OnRspUnSubMarketData p_OnRspUnSubMarketData;
		Callback_OnRtnDepthMarketData p_OnRtnDepthMarketData;

		// 回调函数对应的delegate，必须保持一份对该deleage的引用，否则GC会自动回收该deleage并导致上面的回调函数失效
		gcroot<Internal_FrontConnected^> d_FrontConnected;
		gcroot<Internal_FrontDisconnected^> d_FrontDisconnected;
		gcroot<Internal_HeartBeatWarning^> d_HeartBeatWarning;
		gcroot<Internal_RspUserLogin^> d_RspUserLogin;
		gcroot<Internal_RspUserLogout^> d_RspUserLogout;
		gcroot<Internal_RspError^> d_RspError;

		gcroot<Internal_RspSubMarketData^> d_RspSubMarketData;
		gcroot<Internal_RspUnSubMarketData^> d_RspUnSubMarketData;
		gcroot<Internal_RtnDepthMarketData^> d_RtnDepthMarketData;
#else
	private:
		gcroot<CTPMDAdapter^> m_pAdapter;
#endif

	};
};