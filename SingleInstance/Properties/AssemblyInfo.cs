using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System;
using System.Resources;
using System.Security.Permissions;
using System.Security;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle ( "SingleInstance" )]
[assembly: AssemblyDescription ( "" )]
[assembly: AssemblyConfiguration ( "" )]
[assembly: AssemblyCompany ( "William McCormick" )]
[assembly: AssemblyProduct ( "SingleInstance" )]
[assembly: AssemblyCopyright ( "Copyright © 2006-2007, By William Edward McCormick" )]
[assembly: AssemblyTrademark ( "" )]
[assembly: AssemblyCulture ( "" )]

[assembly: AllowPartiallyTrustedCallers ()]
[assembly: IsolatedStorageFilePermission ( SecurityAction.RequestMinimum )]

// after reading a artical on CLS Compiants this is true
[assembly: CLSCompliant ( true )]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible ( false )]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: System.Runtime.InteropServices.Guid ( "8a8f70b3-2871-4ece-81bc-43a6096f47b9" )]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion ( "2.0.*" )]
