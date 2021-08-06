Imports DevExpress.Data.Filtering
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Dashboard_FiscalFunctions
	Friend MustInherit Class GetFiscalDateFunction
		Implements ICustomFunctionOperatorBrowsable

		Protected startDay As Integer
		Protected startMonth As Integer

		Protected Sub New(ByVal startDay As Integer, ByVal startMonth As Integer)
			Me.startDay = startDay
			Me.startMonth = startMonth
		End Sub

		Protected MustOverride Function GetFiscal(ByVal current As Date) As Integer
		Public ReadOnly Property MinOperandCount() As Integer Implements ICustomFunctionOperatorBrowsable.MinOperandCount
			Get
				Return 1
			End Get
		End Property

		Public ReadOnly Property MaxOperandCount() As Integer Implements ICustomFunctionOperatorBrowsable.MaxOperandCount
			Get
				Return 1
			End Get
		End Property

		Public MustOverride ReadOnly Property Description() As String Implements ICustomFunctionOperatorBrowsable.Description

		Public ReadOnly Property Category() As FunctionCategory Implements ICustomFunctionOperatorBrowsable.Category
			Get
				Return FunctionCategory.DateTime
			End Get
		End Property

		Public MustOverride ReadOnly Property Name() As String Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Name

		Public Function Evaluate(ParamArray ByVal operands() As Object) As Object Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Evaluate
			Return GetFiscal(DirectCast(operands(0), Date))
		End Function

		Public Function IsValidOperandCount(ByVal count As Integer) As Boolean Implements ICustomFunctionOperatorBrowsable.IsValidOperandCount
			Return count = 1
		End Function

		Public Function IsValidOperandType(ByVal operandIndex As Integer, ByVal operandCount As Integer, ByVal type As Type) As Boolean Implements ICustomFunctionOperatorBrowsable.IsValidOperandType
			Return type Is GetType(Date) AndAlso operandCount = 1 AndAlso operandIndex = 0
		End Function

		Public Function ResultType(ParamArray ByVal operands() As Type) As Type Implements DevExpress.Data.Filtering.ICustomFunctionOperator.ResultType
			Return GetType(Integer)
		End Function
	End Class
End Namespace
