Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.XtraBars

Namespace DevExpress.Demos.Navigator
	Public Enum ActionType
		None
		First
		Prev
		[Next]
		Last
		Add
		Delete
		EndEdit
		Custom
	End Enum

	#Region "Abstract"
	Public Class AbstractDataNavigator
		Inherits Component
		Public Sub New()
			buttonsValue = CreateButtonsCollection()
		End Sub

		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
			Buttons.Clear()
			MyBase.Dispose(disposing)
		End Sub

		Private bindingContext_Renamed As BindingContext
		Public Property BindingContext() As BindingContext
			Get
				Return bindingContext_Renamed
			End Get
			Set(ByVal value As BindingContext)
				If bindingContext_Renamed IsNot value Then
					BindingChanging()
					bindingContext_Renamed = value
					BindingChanged()
				End If
			End Set
		End Property

		Private dataMember_Renamed As String = String.Empty
		Public Property DataMember() As String
			Get
				Return dataMember_Renamed
			End Get
			Set(ByVal value As String)
				If dataMember_Renamed <> value Then
					BindingChanging()
					dataMember_Renamed = value
					BindingChanged()
				End If
			End Set
		End Property

		Private dataSource_Renamed As Object
		Public Property DataSource() As Object
			Get
				Return dataSource_Renamed
			End Get
			Set(ByVal value As Object)
				If dataSource_Renamed IsNot value Then
					BindingChanging()
					dataSource_Renamed = value
					BindingChanged()
				End If
			End Set
		End Property

		Protected ReadOnly Property CurrencyManager() As BindingManagerBase
			Get
				Try
					Return BindingContext(DataSource, DataMember)
				Catch
					Return Nothing
				End Try
			End Get
		End Property

		Protected Overridable Sub BindingChanging()
			If CurrencyManager IsNot Nothing Then
				RemoveHandler CurrencyManager.CurrentChanged, AddressOf CurrencyManager_CurrentChanged
				RemoveHandler CurrencyManager.PositionChanged, AddressOf CurrencyManager_PositionChanged
			End If
		End Sub

		Protected Overridable Sub BindingChanged()
			If CurrencyManager IsNot Nothing Then
				AddHandler CurrencyManager.CurrentChanged, AddressOf CurrencyManager_CurrentChanged
				AddHandler CurrencyManager.PositionChanged, AddressOf CurrencyManager_PositionChanged
			End If
			UpdateButtons()
		End Sub

		Protected Overridable Sub CurrencyManager_CurrentChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateButtons()
		End Sub

		Protected Overridable Sub CurrencyManager_PositionChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateButtons()
		End Sub

		Public Overridable Sub UpdateButtons()
			For Each link As ButtonLink In Buttons
				Select Case link.ActionType
					Case ActionType.First, ActionType.Prev
						link.Enabled = (CurrencyManager IsNot Nothing) AndAlso (CurrencyManager.Position > 0)
					Case ActionType.Next, ActionType.Last
						link.Enabled = (CurrencyManager IsNot Nothing) AndAlso (CurrencyManager.Position < CurrencyManager.Count - 1)
					Case ActionType.Add
						link.Enabled = CurrencyManager IsNot Nothing AndAlso TryCast(DataSource, IBindingList) IsNot Nothing AndAlso (CType(DataSource, IBindingList)).AllowNew
					Case ActionType.Delete
						link.Enabled = CurrencyManager IsNot Nothing AndAlso TryCast(DataSource, IList) IsNot Nothing AndAlso Not(CType(DataSource, IList)).IsFixedSize AndAlso Not(CType(DataSource, IList)).IsReadOnly AndAlso CurrencyManager.Position <> -1
				End Select
			Next link
		End Sub

		Public Overridable Sub PerformAction(ByVal action As ActionType)
			If CurrencyManager Is Nothing Or CurrencyManager.Count = 0 Then
				Return
			End If
			Select Case action
				Case ActionType.None
				Case ActionType.First
					CurrencyManager.Position = 0
				Case ActionType.Prev
					If CurrencyManager.Position > 0 Then
						CurrencyManager.Position -= 1
					End If
				Case ActionType.Next
					If CurrencyManager.Position < CurrencyManager.Count - 1 Then
						CurrencyManager.Position += 1
					End If
				Case ActionType.Last
					CurrencyManager.Position = CurrencyManager.Count - 1
				Case ActionType.Add
					CurrencyManager.AddNew()
				Case ActionType.Delete
					CurrencyManager.RemoveAt(CurrencyManager.Position)
				Case Else
					Throw New NotSupportedException()
			End Select
		End Sub

		Protected buttonsValue As ButtonsCollection
		Public ReadOnly Property Buttons() As ButtonsCollection
			Get
				Return buttonsValue
			End Get
		End Property

		Protected Overridable Function CreateButtonsCollection() As ButtonsCollection
			Return New ButtonsCollection(Me)
		End Function
	End Class

	Public Class ButtonsCollection
		Inherits CollectionBase
		Public Sub New(ByVal navigator As AbstractDataNavigator)
			navigatorValue = navigator
		End Sub

		Protected navigatorValue As AbstractDataNavigator
		Public ReadOnly Property Navigator() As AbstractDataNavigator
			Get
				Return navigatorValue
			End Get
		End Property

		Protected Overridable Function CreateInstance() As ButtonLink
			Return Nothing
		End Function

		Public Function Add() As ButtonLink
			Dim link As ButtonLink = CreateInstance()
			If link IsNot Nothing Then
				List.Add(link)
			End If
			Return link
		End Function

		Protected Overrides Sub OnClear()
			For Each item As IDisposable In Me
				item.Dispose()
			Next item
			MyBase.OnClear()
		End Sub

		Protected Overrides Sub OnRemoveComplete(ByVal index As Integer, ByVal item As Object)
			MyBase.OnRemoveComplete(index, item)
			TryCast(item, IDisposable).Dispose()
		End Sub
	End Class

	Public MustInherit Class ButtonLink
		Implements IDisposable
		Protected ownerValue As ButtonsCollection
		Public Sub New(ByVal owner As ButtonsCollection)
			Me.New(owner, ActionType.None, Nothing)
		End Sub

		Public Sub New(ByVal owner As ButtonsCollection, ByVal action As ActionType, ByVal button As Object)
			ownerValue = owner
			actionType_Renamed = action
			Me.button_Renamed = button
		End Sub

		Private actionType_Renamed As ActionType
		Public Property ActionType() As ActionType
			Get
				Return actionType_Renamed
			End Get
			Set(ByVal value As ActionType)
				actionType_Renamed = value
			End Set
		End Property

		Protected MustOverride Sub AttachEvent()

		Protected Overridable Sub BeforeDispose()
			Button = Nothing
		End Sub

		Private button_Renamed As Object
		Public Property Button() As Object
			Get
				Return button_Renamed
			End Get
			Set(ByVal value As Object)
				If button_Renamed IsNot value Then
					DetachEvent()
					button_Renamed = value
					AttachEvent()
				End If
			End Set
		End Property

		Protected Overridable Sub Click()
			ownerValue.Navigator.PerformAction(actionType_Renamed)
		End Sub
		Protected MustOverride Sub DetachEvent()

		Public MustOverride Property Enabled() As Boolean

		Public MustOverride Property Visible() As Boolean

		Private Sub Dispose() Implements IDisposable.Dispose
			BeforeDispose()
		End Sub
	End Class
	#End Region

	#Region "XtraBars Navigator"
	Public Class XtraBarsDataNavigator
		Inherits AbstractDataNavigator
		Protected Overrides Function CreateButtonsCollection() As ButtonsCollection
			Return New XtraBarsButtonsCollection(Me)
		End Function

		Private manager As BarManager
		Public Property BarManager() As BarManager
			Get
				Return manager
			End Get
			Set(ByVal value As BarManager)
				manager = value
			End Set
		End Property

		Private label_Renamed As BarStaticItem
		Public Property Label() As BarStaticItem
			Get
				Return label_Renamed
			End Get
			Set(ByVal value As BarStaticItem)
				label_Renamed = value
			End Set
		End Property

		Public Overrides Sub UpdateButtons()
			MyBase.UpdateButtons()
			SetLabelText()
		End Sub

		Protected Overridable Sub SetLabelText()
			If Label IsNot Nothing Then
				Label.Caption = GetLabelText()
			End If
		End Sub

		Private Function GetLabelText() As String
			If CurrencyManager Is Nothing Then
				Return String.Empty
			End If
			Return String.Format("[Record {0} of {1}]", CurrencyManager.Position + 1, CurrencyManager.Count)
		End Function
	End Class

	Public Class XtraBarsButtonsCollection
		Inherits ButtonsCollection
		Public Sub New(ByVal navigator As AbstractDataNavigator)
			MyBase.New(navigator)
		End Sub
		Protected Overrides Function CreateInstance() As ButtonLink
			Return New XtraBarsButtonLink(Me)
		End Function
	End Class

	Public Class XtraBarsButtonLink
		Inherits ButtonLink
		Public Sub New(ByVal owner As ButtonsCollection)
			MyBase.New(owner)
		End Sub
		Public Sub New(ByVal owner As ButtonsCollection, ByVal action As ActionType, ByVal button As DevExpress.XtraBars.BarButtonItem)
			MyBase.New(owner, action, button)
		End Sub

		Private Sub BarButtonItem_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
			Click()
		End Sub

		Protected Overrides Sub AttachEvent()
			If Button IsNot Nothing Then
				AddHandler Button.ItemClick, AddressOf BarButtonItem_ItemClick
			End If
		End Sub

		Public Shadows Property Button() As BarButtonItem
			Get
				Return TryCast(MyBase.Button, BarButtonItem)
			End Get
			Set(ByVal value As BarButtonItem)
				MyBase.Button = value
			End Set
		End Property

		Public Overrides Property Enabled() As Boolean
			Get
				Return (Button IsNot Nothing AndAlso Button.Enabled)
			End Get
			Set(ByVal value As Boolean)
				If Button IsNot Nothing Then
					Button.Enabled = value
				End If
			End Set
		End Property

		Protected Overrides Sub DetachEvent()
			If Button IsNot Nothing Then
				RemoveHandler Button.ItemClick, AddressOf BarButtonItem_ItemClick
			End If
		End Sub

		Public Overrides Property Visible() As Boolean
			Get
				Return (Button IsNot Nothing AndAlso Button.Visibility = BarItemVisibility.Always)
			End Get
			Set(ByVal value As Boolean)
				If Button IsNot Nothing Then
					Button.Visibility = If(value, BarItemVisibility.Always, BarItemVisibility.OnlyInCustomizing)
				End If
			End Set
		End Property

	End Class
	#End Region
End Namespace