/////////////////////////////////////////////////////////////////////////
/// 上期技术 CTP C++ ==> .Net Framework Adapter
/// Author:	shawn666.liu@gmail.com
/// Date: 20120420
/////////////////////////////////////////////////////////////////////////

#pragma once
#include "Util.h"

using namespace Native;

namespace  Native{
	class CMdSpi;
};


namespace CTP {

	/// <summary>
	/// 托管类,Marcket Data Adapter
	/// </summary>
	public ref class CTPMDAdapter
	{
	public:
		/// <summary>
		///创建CTPMDAdapter
		///存贮订阅信息文件的目录，默认为当前目录
		/// </summary>
		CTPMDAdapter(void);
		/// <summary>
		///创建CTPMDAdapter
		/// </summary>
		/// <param name="pszFlowPath">存贮订阅信息文件的目录，默认为当前目录</param>
		/// <param name="bIsUsingUdp">是否使用UDP协议</param>
		CTPMDAdapter(String^ pszFlowPath, bool bIsUsingUdp);
	private:
		~CTPMDAdapter(void);
		CThostFtdcMdApi* m_pApi;
		CMdSpi* m_pSpi;
	public:
		/// <summary>
		///删除接口对象本身
		///@remark 不再使用本接口对象时,调用该函数删除接口对象
		/// </summary>
		void Release(void);
		/// <summary>
		///初始化
		///@remark 初始化运行环境,只有调用后,接口才开始工作
		/// </summary>
		void Init(void);
		/// <summary>
		///等待接口线程结束运行
		///@return 线程退出代码
		/// </summary>
		void Join(void);
		/// <summary>
		///获取当前交易日
		///@remark 只有登录成功后,才能得到正确的交易日
		/// </summary>
		/// <returns>获取到的交易日</returns>
		String^ GetTradingDay();
		/// <summary>
		///注册前置机网络地址
		/// </summary>
		/// <param name="pszFrontAddress">
		/// 前置机网络地址
		/// 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:17001”。
		/// “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”17001”代表服务器端口号。
		/// </param>
		void RegisterFront(String^  pszFrontAddress);
		/// <summary>
		///注册名字服务器网络地址
		/// </summary>
		/// <param name="pszNsAddress">名字服务器网络地址。
		///@remark 网络地址的格式为：“protocol://ipaddress:port”，如：”tcp://127.0.0.1:12001”。 
		///@remark “tcp”代表传输协议，“127.0.0.1”代表服务器地址。”12001”代表服务器端口号。
		///@remark RegisterNameServer优先于RegisterFront
		/// </param>
		void RegisterNameServer(String^ pszNsAddress);
		/// <summary>
		///注册名字服务器用户信息
		/// </summary>
		/// <param name="pFensUserInfo">用户信息</param>
		void RegisterFensUserInfo(ThostFtdcFensUserInfoField^ pFensUserInfo);
		/// <summary>
		///订阅行情。
		/// </summary>
		/// <param name="ppInstrumentID">合约ID</param>
		int SubscribeMarketData(array<String^>^ ppInstrumentID);
		/// <summary>
		///	退订行情。
		/// </summary>
		/// <param name="ppInstrumentID">合约ID</param>
		int UnSubscribeMarketData(array<String^>^ ppInstrumentID);
		/// <summary>
		/// 用户登录请求
		/// </summary>
		int ReqUserLogin(ThostFtdcReqUserLoginField^ pReqUserLoginField,int nRequestID);
		/// <summary>
		/// 登出请求
		/// </summary>
		int ReqUserLogout(ThostFtdcUserLogoutField^ pUserLogout, int nRequestID);

		// Events
	public:
		/// <summary>
		/// 当客户端与交易后台建立起通信连接时（还未登录前），该方法被调用。
		/// </summary>
		event FrontConnected^ OnFrontConnected {
			void add(FrontConnected^ handler ) {
				OnFrontConnected_delegate += handler;
			}
			void remove(FrontConnected^ handler) {
				OnFrontConnected_delegate -= handler;
			}
			void raise() {
				if(OnFrontConnected_delegate)
					OnFrontConnected_delegate();
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
				OnFrontDisconnected_delegate += handler;
			}
			void remove(FrontDisconnected^ handler) {
				OnFrontDisconnected_delegate -= handler;
			}
			void raise(int nReason) {
				if(OnFrontDisconnected_delegate)
					OnFrontDisconnected_delegate(nReason);
			}
		}

		/// <summary>
		///心跳超时警告。当长时间未收到报文时，该方法被调用。
		///@param nTimeLapse 距离上次接收报文的时间
		/// </summary>
		event HeartBeatWarning^ OnHeartBeatWarning {
			void add(HeartBeatWarning^ handler ) {
				OnHeartBeatWarning_delegate += handler;
			}
			void remove(HeartBeatWarning^ handler) {
				OnHeartBeatWarning_delegate -= handler;
			}
			void raise(int nTimeLapse) {
				if(OnHeartBeatWarning_delegate)
					OnHeartBeatWarning_delegate(nTimeLapse);
			}
		}

		/// <summary>
		/// 登录请求响应
		/// </summary>
		event RspUserLogin^ OnRspUserLogin {
			void add(RspUserLogin^ handler ) {
				OnRspUserLogin_delegate += handler;
			}
			void remove(RspUserLogin^ handler) {
				OnRspUserLogin_delegate -= handler;
			}
			void raise(ThostFtdcRspUserLoginField^ pRspUserLogin, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) { 
				if(OnRspUserLogin_delegate)
					OnRspUserLogin_delegate(pRspUserLogin, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 登出请求响应
		/// </summary>
		event RspUserLogout^ OnRspUserLogout {
			void add(RspUserLogout^ handler ) {
				OnRspUserLogout_delegate += handler;
			}
			void remove(RspUserLogout^ handler) {
				OnRspUserLogout_delegate -= handler;
			}
			void raise(ThostFtdcUserLogoutField^ pUserLogout, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) { 
				if(OnRspUserLogout_delegate)
					OnRspUserLogout_delegate(pUserLogout, pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 错误应答
		/// </summary>
		event RspError^ OnRspError {
			void add(RspError^ handler ) {
				OnRspError_delegate += handler;
			}
			void remove(RspError^ handler) {
				OnRspError_delegate -= handler;
			}
			void raise(ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) { 
				if(OnRspError_delegate)
					OnRspError_delegate(pRspInfo, nRequestID, bIsLast);
			}
		}

		/// <summary>
		/// 订阅行情应答
		/// </summary>
		event RspSubMarketData^ OnRspSubMarketData {
			void add(RspSubMarketData^ handler ) {
				OnRspSubMarketData_delegate += handler;
			}
			void remove(RspSubMarketData^ handler) {
				OnRspSubMarketData_delegate -= handler;
			}
			void raise(ThostFtdcSpecificInstrumentField^ pSpecificInstrument, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) { 
				if(OnRspSubMarketData_delegate)
					OnRspSubMarketData_delegate(pSpecificInstrument, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 取消订阅行情应答
		/// </summary>
		event RspUnSubMarketData^ OnRspUnSubMarketData {
			void add(RspUnSubMarketData^ handler ) {
				OnRspUnSubMarketData_delegate += handler;
			}
			void remove(RspUnSubMarketData^ handler) {
				OnRspUnSubMarketData_delegate -= handler;
			}
			void raise(ThostFtdcSpecificInstrumentField^ pSpecificInstrument, ThostFtdcRspInfoField^ pRspInfo, int nRequestID, bool bIsLast) { 
				if(OnRspUnSubMarketData_delegate)
					OnRspUnSubMarketData_delegate(pSpecificInstrument, pRspInfo, nRequestID, bIsLast);
			}
		}
		/// <summary>
		/// 深度行情通知
		/// </summary>
		event RtnDepthMarketData^ OnRtnDepthMarketData {
			void add(RtnDepthMarketData^ handler ) {
				OnRtnDepthMarketData_delegate += handler;
			}
			void remove(RtnDepthMarketData^ handler) {
				OnRtnDepthMarketData_delegate -= handler;
			}
			void raise(ThostFtdcDepthMarketDataField^ pDepthMarketData) { 
				if(OnRtnDepthMarketData_delegate)
					OnRtnDepthMarketData_delegate(pDepthMarketData);
			}
		}

		// delegates
	private:
		FrontConnected^ OnFrontConnected_delegate;
		FrontDisconnected^ OnFrontDisconnected_delegate;
		HeartBeatWarning^ OnHeartBeatWarning_delegate;
		RspUserLogin^  OnRspUserLogin_delegate;
		RspUserLogout^ OnRspUserLogout_delegate;
		RspError^ OnRspError_delegate;
		RspSubMarketData^ OnRspSubMarketData_delegate;
		RspUnSubMarketData^ OnRspUnSubMarketData_delegate;
		RtnDepthMarketData^ OnRtnDepthMarketData_delegate;

#ifdef __CTP_MA__
		// Callbacks for MA
	private:
		void cbk_OnFrontConnected();
		void cbk_OnFrontDisconnected(int nReason);
		void cbk_OnHeartBeatWarning(int nTimeLapse);
		void cbk_OnRspUserLogin(CThostFtdcRspUserLoginField *pRspUserLogin, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspUserLogout(CThostFtdcUserLogoutField *pUserLogout, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspError(CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspSubMarketData(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRspUnSubMarketData(CThostFtdcSpecificInstrumentField *pSpecificInstrument, CThostFtdcRspInfoField *pRspInfo, int nRequestID, bool bIsLast);
		void cbk_OnRtnDepthMarketData(CThostFtdcDepthMarketDataField *pDepthMarketData);
		// 将所有回调函数地址传递给SPI
		void RegisterCallbacks();	
#endif

	};
}