Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.UserSkins
Imports DevExpress.Skins
Imports DevExpress.LookAndFeel
Imports DevExpress.Data.Filtering
Imports System.Globalization

Namespace Dashboard_FiscalFunctions
	Friend Module Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread>
		Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)

			BonusSkins.Register()
			SkinManager.EnableFormSkins()
			UserLookAndFeel.Default.SetSkinStyle("DevExpress Style")
			CriteriaOperator.RegisterCustomFunction(New GetFiscalYearFunction(1, 10))
			CriteriaOperator.RegisterCustomFunction(New GetFiscalQuarterFunction(1, 10))
			CriteriaOperator.RegisterCustomFunction(New GetFiscalWeekOfYearFunction(1, 10, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
			Application.Run(New Form1())

		End Sub
	End Module
End Namespace
