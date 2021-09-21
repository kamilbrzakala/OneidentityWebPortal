# One identity Web Portal
One Identity frontend

This is a custom web portal interface developed in asp.net mvc 5 framework.

Prerequisities:

1. Install windows server (https://www.microsoft.com/en-US/evalcenter/evaluate-windows-server-2019?filetype=ISO)
2. Promote server to domain controller (https://www.manageengine.com/products/active-directory-audit/kb/how-to/how-to-add-a-domain-controller-to-an-existing-domain.html)
3. Install MS SQL Express (https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
4. Install Visual Studio Community (https://visualstudio.microsoft.com/pl/free-developer-offers/)
5. Install Packages as per below table

Package Name | WebPortal.Domain | WebPortal.WebUI | WebPortal.UnitTests 
| :--- | :---: | :---: | :---:
Ninject  |   | x | x
Ninject.Web.Common  |   | x | x
Ninject.Web.Common.Webhost  |   | x | x
Moq  |   | x | x
Microsoft.Aspnet.Mvc  | x |  | x
System.ComponentModel.Annotations  | x |  | 
EntityFramework  | x | x | 
bootstrap  | | x | 
PagedList  | | x | x
PagedList.Mvc  | | x | x
  
6. Setup dependencies by adding references:
WebPortal.Domain -> System.ComponentModel.DataAnnotations
WebPortal.WebUI -> WebPortal.Domain
WebPortal.UnitTests -> WebPortal.WebUI, System.Web, Microsoft.CSharp
7. Install One Identity Manager on the server
[optional]
8. Run Powershell script in order to populate a domain with a departments org structure: Prepare AD OU structure.ps1

