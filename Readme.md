<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Dashboard_FiscalFunctions/Form1.cs) ([Form1.vb](./VB/Dashboard_FiscalFunctions/Form1.vb))
* [Fiscal Functions](./CS/Dashboard_FiscalFunctions/Fiscal%20Functions) (VB: [Fiscal Functions](./VB/Dashboard_FiscalFunctions/Fiscal%20Functions))
<!-- default file list end -->
# Dashboard for WinForms - How to Calculate Fiscal Functions from Date-Time Data Fields

This example shows how to create and register custom functions that calculate the fiscal year, quarter, and week from date-time data fields.

## Overview

In this example, the [Grid](https://docs.devexpress.com/Dashboard/15150/winforms-dashboard/winforms-designer/create-dashboards-in-the-winforms-designer/dashboard-item-settings/grid) dashboard item displays the fiscal year, quarter, and week for the corresponding date. 

![SalesDynamics](images/salesDynamisc.png)

The following expressions calculate fiscal values for the corresponding date:

| Calculated Field | Expression |
| --- | --- |
| Fiscal Year | ``` GetFiscalYear([OrderDate]) ``` |
| Fiscal Quarter | ``` GetFiscalQuarter([OrderDate]) ``` |
| Fiscal Week of Year | ``` GetFiscalWeekOfYear([OrderDate]) ``` |

The following code snippet shows how to register fiscal functions: 

[Program.cs](./CS/Dashboard_FiscalFunctions/Form1.cs):
```csharp
using System;
using System.Windows.Forms
using DevExpress.Data.Filtering;
using System.Globalization;

namespace Dashboard_FiscalFunctions {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
        // ...
            CriteriaOperator.RegisterCustomFunction(new GetFiscalYearFunction(1, 10));
            CriteriaOperator.RegisterCustomFunction(new GetFiscalQuarterFunction(1, 10));
            CriteriaOperator.RegisterCustomFunction(new GetFiscalWeekOfYearFunction(1, 10, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday));
            Application.Run(new Form1());  
        }
    }
}
```
[Program.vb](./CS/Dashboard_FiscalFunctions/Program.vb):
```vb
Imports DevExpress.Data.Filtering
Imports System.Globalization

Namespace Dashboard_FiscalFunctions
    Friend Module Program
	''' <summary>
	''' The main entry point for the application.
	''' </summary>
	<STAThread>
	Sub Main()
	' ...
	    CriteriaOperator.RegisterCustomFunction(New GetFiscalYearFunction(1, 10))
	    CriteriaOperator.RegisterCustomFunction(New GetFiscalQuarterFunction(1, 10))
	    CriteriaOperator.RegisterCustomFunction(New GetFiscalWeekOfYearFunction(1, 10, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
	    Application.Run(New Form1())
	End Sub
    End Module
End Namespace
```
 
## Documentation
- [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-5.0)
- [Expression Constants, Operators, and Functions](https://docs.devexpress.com/Dashboard/400122/common-features/advanced-analytics/expression-constants-operators-and-functions)
