# OneidentityWebPortal
OneIdentity frontend

This is a custom web portal interface developed in asp.net mvc5 framework.

Prerequisities:

1. Install windows server (https://www.microsoft.com/en-US/evalcenter/evaluate-windows-server-2019?filetype=ISO)
2. Promote server to domain controller (https://www.manageengine.com/products/active-directory-audit/kb/how-to/how-to-add-a-domain-controller-to-an-existing-domain.html)
3. Install MS SQL Express (https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
4. Install Visual Studio Community (https://visualstudio.microsoft.com/pl/free-developer-offers/)
4a. 
Install-Package Ninject -projectname WebPortal.WebUI
    Install-Package Ninject -projectname WebPortal.UnitTests
Install-Package Ninject.Web.Common -projectname WebPortal.WebUI
    Install-Package Ninject.Web.Common -projectname WebPortal.UnitTests
Install-Package Ninject.Web.Common.Webhost -projectname WebPortal.WebUI
    Install-Package Ninject.Web.Common.Webhost -projectname WebPortal.UnitTests
Install-Package Ninject.MVC5 -projectname WebPortal.WebUI
    Install-Package Ninject.MVC5 -projectname WebPortal.UnitTests   
Install-Package Moq -projectname WebPortal.WebUI
    Install-Package Moq -projectname WebPortal.UnitTests   
Install-Package Microsoft.Aspnet.Mvc -projectname WebPortal.Domain
    Install-Package Microsoft.Aspnet.Mvc -projectname WebPortal.UnitTests   
Install-Package System.ComponentModel.Annotations -projectname WebPortal.Domain
Install-Package EntityFramework -projectname WebPortal.Domain
Install-Package EntityFramework -projectname WebPortal.WebUI
Install-Package bootstrap -projectname WebPortal.WebUI
5. Setup dependencies by adding references:
WebPortal.Domain -> System.ComponentModel.DataAnnotations
WebPortal.WebUI -> WebPortal.Domain
WebPortal.UnitTests -> WebPortal.WebUI, System.Web, Microsoft.CSharp
7. Install One Identity Manager on the server
[optional]8. Run Powershell script in order to populate a domain with a departments org structure: Prepare AD OU structure.ps1
