Imports System.Windows.Forms
Imports DevExpress.Demos.Navigator

Namespace DataNavigator
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			For i As Integer = 0 To 4
				dataTable1.Rows.Add(New Object() { "Item " & (i + 1).ToString() })
			Next i

			barManager1.ForceInitialize()
			CreateNavigator()
		End Sub

		Private Sub CreateNavigator()
			Dim navigator As XtraBarsDataNavigator
			navigator = New XtraBarsDataNavigator()
			navigator.BindingContext = Me.BindingContext
			navigator.DataSource = bindingSource1
			navigator.BarManager = barManager1

			' link buttons
			Dim link As ButtonLink
			link = navigator.Buttons.Add()
			link.ActionType = ActionType.First
			link.Button = BarButtonFirst
			link = navigator.Buttons.Add()
			link.ActionType = ActionType.Prev
			link.Button = BarButtonPrev
			link = navigator.Buttons.Add()
			link.ActionType = ActionType.Next
			link.Button = BarButtonNext
			link = navigator.Buttons.Add()
			link.ActionType = ActionType.Last
			link.Button = BarButtonLast
			link = navigator.Buttons.Add()
			link.ActionType = ActionType.Add
			link.Button = BarButtonAdd
			link = navigator.Buttons.Add()
			link.ActionType = ActionType.Delete
			link.Button = BarButtonDelete

			navigator.Label = barStaticItem1
			navigator.UpdateButtons()
		End Sub
	End Class
End Namespace
