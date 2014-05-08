#include "stdafx.h"

using namespace System;
using namespace System::Reflection;
using namespace System::Runtime::CompilerServices;
using namespace System::Runtime::InteropServices;
using namespace System::Security::Permissions;

//
// 有关程序集的常规信息通过下列属性集
// 控制。更改这些属性值可修改
// 与程序集关联的信息。
//

#ifdef __CTP_MA__
[assembly:AssemblyTitleAttribute("CTP  MA版")];
[assembly:AssemblyDescriptionAttribute("CTP C++ ==> .Net Adapter MA版")];
[assembly:AssemblyConfigurationAttribute("")];
[assembly:AssemblyCompanyAttribute("")];
[assembly:AssemblyProductAttribute("CTP  MA版")];
[assembly:AssemblyCopyrightAttribute("Copyright (c) shawn666.liu@gmail.com 2012")];
[assembly:AssemblyTrademarkAttribute("")];
[assembly:AssemblyCultureAttribute("")];
#else
[assembly:AssemblyTitleAttribute("CTP")];
[assembly:AssemblyDescriptionAttribute("CTP C++ ==> .Net Adapter")];
[assembly:AssemblyConfigurationAttribute("")];
[assembly:AssemblyCompanyAttribute("")];
[assembly:AssemblyProductAttribute("CTP")];
[assembly:AssemblyCopyrightAttribute("Copyright (c) shawn666.liu@gmail.com 2012")];
[assembly:AssemblyTrademarkAttribute("")];
[assembly:AssemblyCultureAttribute("")];
#endif


//
// 程序集的版本信息由下面四个值组成:
//
//      主版本
//      次版本
//      内部版本号
//      修订号
//
// 您可以指定所有值，也可使用“修订号”和“内部版本号”的默认值，
// 方法是按如下所示使用“*”:

[assembly:AssemblyVersionAttribute("1.0.*")];

[assembly:ComVisible(false)];

[assembly:CLSCompliantAttribute(true)];

[assembly:SecurityPermission(SecurityAction::RequestMinimum, UnmanagedCode = true)];
