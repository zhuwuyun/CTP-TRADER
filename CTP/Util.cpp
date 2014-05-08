#include "StdAfx.h"
#include "Util.h"

#include <string.h>
#include <memory.h>
#include <stdlib.h>

using namespace System::Runtime::InteropServices;

namespace Native
{
	CAutoStrPtr::CAutoStrPtr(String^ str)
	{
		if(str != nullptr)
		{
			m_pChar = (char*) Marshal::StringToHGlobalAnsi(str).ToPointer();
			//m_Length = strlen(m_pChar);
		}
		else
			 m_pChar = nullptr;
	}
	/*CAutoStrPtr::CAutoStrPtr(String^ str, void* pDst, int length)
	{
		if(str != nullptr && pDst!= nullptr)
		{
			m_pChar = (char*) Marshal::StringToHGlobalAnsi(str).ToPointer();
			m_Length = strlen(m_pChar);
			memcpy(pDst, m_pChar, __min(length, m_Length));
		}
		else
			 m_pChar = nullptr;
	}*/

	CAutoStrPtr::~CAutoStrPtr()
	{
		if(m_pChar != nullptr)
			Marshal::FreeHGlobal(IntPtr(m_pChar));
	}


	ThostFtdcRspInfoField^ RspInfoField(CThostFtdcRspInfoField *pRspInfo)
	{
		return safe_cast<ThostFtdcRspInfoField^>(Marshal::PtrToStructure(IntPtr(pRspInfo), ThostFtdcRspInfoField::typeid));
	}

}