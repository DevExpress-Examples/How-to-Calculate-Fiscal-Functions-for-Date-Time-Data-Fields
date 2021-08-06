<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Dashboard_FiscalFunctions/Form1.cs)
* [Fiscal Functions](./CS/Dashboard_FiscalFunctions/Fiscal%20Functions)
<!-- default file list end -->
# Dashboard for WinForms - How to Count Fiscal Functions for DateTime Fields.

This example shows how to find the number of the fiscal year, quarter or week for input **DateTime**.

## Example Structure

In this example, the [Grid](https://docs.devexpress.com/Dashboard/15150/winforms-dashboard/winforms-designer/create-dashboards-in-the-winforms-designer/dashboard-item-settings/grid) dashboard item displays fiscal year, quarter and week for the corresponding date. Date fields (Date, and all fiscal values (were counted when fiscal year starts on the 1 of October)) are placed in the [Columns](https://docs.devexpress.com/Dashboard/15166/winforms-dashboard/winforms-designer/create-dashboards-in-the-winforms-designer/dashboard-item-settings/grid/columns) section, price and quantity fields are placed there too for more clarity.

![screenshot](./images/salesDynamisc.png)

The following expressions count the fiscal values for the corresponding date.

| Calculated Field | Expression |
| --- | --- |
| Fiscal Year | ``` GetFiscalYear([OrderDate]) ``` |
| Fiscal Quarter | ``` GetFiscalQuarter([OrderDate]) ``` |
| Fiscal Week of Year | ``` GetFiscalWeekOfYear([OrderDate]) ``` |

The final result you can see here:

![screenshot](./images/finalResult.jpg)

## Code Explanation
All Fiscal methods extend **GetFiscalDateFunction** and override _GetFiscal_ which is used to count fiscal values. 

### Fiscal Year
Returns the year of input **DateTime** if it comes before new fiscal year beginning date, otherwise returns the year plus 1.

### Fiscal Quarter
* If difference between input **DateTime** month and ```startMonth``` field not divisible by 3 returns the whole fraction of the difference by 3 plus 1 (considering the offset).
* Otherwise calculates the result for the previous or next month of given **DateTime** depending on whether input **DateTime** day is less or more, than ```startDay``` field.

### Fiscal Week
1. ``` DateTime Beginning(int currentYear) ``` defines the start date of the first week of the input year.
2. If start date is less, than input date ``` start = Beginning(current.Year) ```, otherwise ``` start = Beginning(current.Year - 1) ```.
3. The result calculates as difference between start and input dates plus start day of week offset from the first day of week divided by 7.
 
## Documentation
- [DateTime](https://docs.microsoft.com/ru-ru/dotnet/api/system.datetime?view=net-5.0)
- [Expression Constants, Operators, and Functions](https://docs.devexpress.com/Dashboard/400122/common-features/advanced-analytics/expression-constants-operators-and-functions)