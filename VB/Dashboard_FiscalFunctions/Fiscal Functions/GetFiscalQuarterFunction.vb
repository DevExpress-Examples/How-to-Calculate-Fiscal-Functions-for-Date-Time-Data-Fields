Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Dashboard_FiscalFunctions
	Friend Class GetFiscalQuarterFunction
		Inherits GetFiscalDateFunction

		Public Sub New(ByVal startDay As Integer, ByVal startMonth As Integer)
			MyBase.New(startDay, startMonth)
		End Sub

		Public Overrides ReadOnly Property Name() As String
			Get
				Return "GetFiscalQuarter"
			End Get
		End Property

		Public Overrides ReadOnly Property Description() As String
			Get
				Return "GetFiscalQuarter(DateTime) " & vbLf & " Extracts a fiscal quarter from the defined DateTime."
			End Get
		End Property

		Protected Overrides Function GetFiscal(ByVal current As Date) As Integer
			Dim currentMonth As Integer = current.Month
			If (current.Month + 12 - startMonth) Mod 3 = 0 Then
				currentMonth += If(current.Day < startDay, -1, 1)
			End If
			Dim offset As Integer = If(currentMonth < startMonth, 12, 0)
			Return (currentMonth - startMonth + offset) \ 3 + 1
		End Function
	End Class
End Namespace
