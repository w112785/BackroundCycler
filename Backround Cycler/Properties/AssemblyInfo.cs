/*
Copyright (c) 2006 - 2017, William Edward McCormick

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System.Reflection;
using System.Runtime.InteropServices;
using System.Resources;
using System;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Backround_Cycler")]
[assembly: AssemblyDescription("Special thanks to thease people:\r\n\r\n" +
   "To Mariusz Ficek for the ImageList Code\r\n " +
   "ImageList code Copyright © 2007 by Mariusz Ficek\r\n\r\n" +
   "To Microsoft's Coding4Fun site for the idea and Some of the code " +
   "http://msdn.microsoft.com/coding4fun/inthebox/wallpaper2/default.aspx \r\n\r\n" +
   "To The Code Project's single instance class which i moded into a DLL. from here" +
   " http://www.codeproject.com/csharp/singleinstance.asp \r\n\r\n" +
   "To the Tango Desktop Project for the Program icon" +
   " http://tango.freedesktop.org/Tango_Desktop_Project")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("William McCormick")]
[assembly: AssemblyProduct("Backround Cycler")]
[assembly: AssemblyCopyright("Copyright © 2006-2021, By William Edward McCormick")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// after reading a artical on CLS Compiants this is true
[assembly: CLSCompliant(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
//[assembly: System.Runtime.InteropServices.Guid ( "6f9f8c3d-81a8-4742-95d9-d10f3e7a2d2b" )]
[assembly: Guid(Backround_Cycler.Core.ApplicationInfo.programGuid)]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//

//[assembly: AssemblyVersion ( "3.8.2.0" )]
//[assembly: AssemblyFileVersion ( "3.8.2.0" )]

[assembly: AssemblyVersion(Backround_Cycler.Core.ApplicationInfo.programVersion)]
[assembly: AssemblyFileVersion(Backround_Cycler.Core.ApplicationInfo.programVersion)]

[assembly: NeutralResourcesLanguageAttribute("en-US")]
