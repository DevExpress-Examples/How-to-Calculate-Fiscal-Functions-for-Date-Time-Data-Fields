Imports System
Imports System.Globalization
Imports System.Linq

Namespace Dashboard_FiscalFunctions
	Friend Class GetFiscalWeekOfYearFunction
		Inherits GetFiscalDateFunction

		Private rule As CalendarWeekRule
		Private firstDay As DayOfWeek

		Public Sub New(ByVal startDay As Integer, ByVal startMonth As Integer, ByVal rule As CalendarWeekRule, ByVal firstDay As DayOfWeek)
			MyBase.New(startDay, startMonth)
			Me.rule = rule
			Me.firstDay = firstDay
		End Sub

		Public Overrides ReadOnly Property Name() As String
			Get
				Return "GetFiscalWeekOfYear"
			End Get
		End Property

		Public Overrides ReadOnly Property Description() As String
			Get
				Return "GetFiscalWeek(DateTime) " & vbLf & " Extracts a fiscal week of the year from the defined DateTime"
			End Get
		End Property

		Private Function WeekCounts(ByVal current As Date, ByVal difference As Integer) As Integer
			For i As Integer = 1 To difference - 1
				If (CInt(current.DayOfWeek) + i + 7) Mod 7 = CInt(firstDay) Then
					Return i
				End If
			Next i
			Return -1
		End Function

		Private Function Beginning(ByVal currentYear As Integer) As Date
			Dim start As New Date(currentYear, startMonth, startDay)
			If rule = CalendarWeekRule.FirstDay Then
				Return start
			Else
				Dim range As Integer
				If rule = CalendarWeekRule.FirstFourDayWeek Then
					range = WeekCounts(start, 4)
				Else
					range = WeekCounts(start, 7)
				End If
				If range = -1 Then
					Return start
				Else
					Return start.AddDays(range)
				End If
			End If
		End Function

		Protected Overrides Function GetFiscal(ByVal current As Date) As Integer
			Dim start As Date = Beginning(current.Year)
			If current < start Then
				start = Beginning(current.Year - 1)
			End If
			Dim plus As Integer = (start.DayOfWeek - firstDay + 7) Mod 7
			Return (CInt(Math.Truncate((current.Subtract(start)).TotalDays)) + plus) \ 7 + 1
		End Function
	End Class
End Namespace
