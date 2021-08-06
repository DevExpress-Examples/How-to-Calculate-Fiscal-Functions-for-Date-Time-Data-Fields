Imports DevExpress.Data.Filtering
Imports System
Imports System.Linq

Namespace Dashboard_FiscalFunctions
	Friend Class GetFiscalYearFunction
		Inherits GetFiscalDateFunction

		Public Sub New(ByVal startDay As Integer, ByVal startMonth As Integer)
			MyBase.New(startDay, startMonth)
		End Sub

		Protected Overrides Function GetFiscal(ByVal current As Date) As Integer
			If current.Month > startMonth Then
				Return current.Year + 1
			ElseIf current.Month < startMonth Then
				Return current.Year
			Else
				If current.Day >= startDay Then
					Return current.Year + 1
				Else
					Return current.Year
				End If
			End If
		End Function

		Public Overrides ReadOnly Property Description() As String
			Get
				Return "GetFiscalYear(DateTime) " & vbLf & " Extracts a fiscal year from the defined DateTime"
			End Get
		End Property

		Public Overrides ReadOnly Property Name() As String
			Get
				Return "GetFiscalYear"
			End Get
		End Property
	End Class
End Namespace
