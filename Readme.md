<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/393326815/21.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1019974)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# Dashboard for WinForms - How to Calculate Fiscal Functions from Date-Time Data Fields

This example shows how to create and register custom functions that calculate the fiscal year, quarter, and week from date-time data fields in a client mode. These custom functions implement the [ICustomFunctionOperatorBrowsable](https://docs.devexpress.com/CoreLibraries/DevExpress.Data.Filtering.ICustomFunctionOperatorBrowsable) interface. The interface allows you to create a function that can be used for custom calculations in [client mode](https://docs.devexpress.com/Dashboard/17083/basic-concepts-and-terminology/data-processing-modes). Refer to the [Custom Functions](https://docs.devexpress.com/WindowsForms/9947/common-features/expressions/implementing-custom-functions) article for more information.

<!-- default file list -->
## Files to Look At

* [Form1.cs](./CS/Dashboard_FiscalFunctions/Form1.cs) ([Form1.vb](./VB/Dashboard_FiscalFunctions/Form1.vb))
* [Fiscal Functions](./CS/Dashboard_FiscalFunctions/Fiscal%20Functions) (VB: [Fiscal Functions](./VB/Dashboard_FiscalFunctions/Fiscal%20Functions))
* [Program.cs](./CS/Dashboard_FiscalFunctions/Program.cs#L24-L26) ([Program.vb](./VB/Dashboard_FiscalFunctions/Program.vb#L24-L26))
<!-- default file list end -->

## Overview

In this example, the [Grid](https://docs.devexpress.com/Dashboard/15150/winforms-dashboard/winforms-designer/create-dashboards-in-the-winforms-designer/dashboard-item-settings/grid) dashboard item displays the fiscal year, quarter, and week for the corresponding date. 

![SalesDynamics](images/salesDynamisc.png)

The following expressions calculate fiscal values for the corresponding date:

| Calculated Field | Expression |
| --- | --- |
| Fiscal Year | ``` GetFiscalYear([OrderDate]) ``` |
| Fiscal Quarter | ``` GetFiscalQuarter([OrderDate]) ``` |
| Fiscal Week of Year | ``` GetFiscalWeekOfYear([OrderDate]) ``` |

Call the [CriteriaOperator.RegisterCustomFunction](https://docs.devexpress.com/CoreLibraries/DevExpress.Data.Filtering.CriteriaOperator.RegisterCustomFunction(DevExpress.Data.Filtering.ICustomFunctionOperator)) method to register custom functions in your project (see: [Program.cs](./CS/Dashboard_FiscalFunctions/Program.cs#L24-L26)/[Program.vb](./VB/Dashboard_FiscalFunctions/Program.vb#L24-L26)).  
 
## Documentation
- [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-5.0)
- [Expression Constants, Operators, and Functions](https://docs.devexpress.com/Dashboard/400122/common-features/advanced-analytics/expression-constants-operators-and-functions)
