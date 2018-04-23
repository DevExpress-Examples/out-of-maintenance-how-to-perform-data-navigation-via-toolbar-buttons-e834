Imports Microsoft.VisualBasic
Imports System
Namespace DataNavigator
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.dataSet1 = New System.Data.DataSet()
			Me.dataTable1 = New System.Data.DataTable()
			Me.dataColumn1 = New System.Data.DataColumn()
			Me.dataColumn2 = New System.Data.DataColumn()
			Me.bindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
			Me.barManager1 = New DevExpress.XtraBars.BarManager(Me.components)
			Me.bar1 = New DevExpress.XtraBars.Bar()
			Me.BarButtonFirst = New DevExpress.XtraBars.BarButtonItem()
			Me.BarButtonPrev = New DevExpress.XtraBars.BarButtonItem()
			Me.barStaticItem1 = New DevExpress.XtraBars.BarStaticItem()
			Me.BarButtonNext = New DevExpress.XtraBars.BarButtonItem()
			Me.BarButtonLast = New DevExpress.XtraBars.BarButtonItem()
			Me.BarButtonAdd = New DevExpress.XtraBars.BarButtonItem()
			Me.BarButtonDelete = New DevExpress.XtraBars.BarButtonItem()
			Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
			Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
			Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
			Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
			Me.dataGridView1 = New System.Windows.Forms.DataGridView()
			Me.column1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
			Me.column2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.barManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' dataSet1
			' 
			Me.dataSet1.DataSetName = "NewDataSet"
			Me.dataSet1.Tables.AddRange(New System.Data.DataTable() { Me.dataTable1})
			' 
			' dataTable1
			' 
			Me.dataTable1.Columns.AddRange(New System.Data.DataColumn() { Me.dataColumn1, Me.dataColumn2})
			Me.dataTable1.TableName = "Table1"
			' 
			' dataColumn1
			' 
			Me.dataColumn1.ColumnName = "Column1"
			' 
			' dataColumn2
			' 
			Me.dataColumn2.ColumnName = "Column2"
			' 
			' bindingSource1
			' 
			Me.bindingSource1.DataMember = "Table1"
			Me.bindingSource1.DataSource = Me.dataSet1
			' 
			' barManager1
			' 
			Me.barManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() { Me.bar1})
			Me.barManager1.DockControls.Add(Me.barDockControlTop)
			Me.barManager1.DockControls.Add(Me.barDockControlBottom)
			Me.barManager1.DockControls.Add(Me.barDockControlLeft)
			Me.barManager1.DockControls.Add(Me.barDockControlRight)
			Me.barManager1.Form = Me
			Me.barManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.BarButtonFirst, Me.BarButtonNext, Me.barStaticItem1, Me.BarButtonPrev, Me.BarButtonLast, Me.BarButtonAdd, Me.BarButtonDelete})
			Me.barManager1.MaxItemId = 7
			' 
			' bar1
			' 
			Me.bar1.BarName = "Tools"
			Me.bar1.DockCol = 0
			Me.bar1.DockRow = 0
			Me.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
			Me.bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonFirst), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonPrev), New DevExpress.XtraBars.LinkPersistInfo(Me.barStaticItem1, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonNext, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonLast), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonAdd, True), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonDelete)})
			Me.bar1.Text = "Tools"
			' 
			' BarButtonFirst
			' 
			Me.BarButtonFirst.Caption = "First"
			Me.BarButtonFirst.Id = 0
			Me.BarButtonFirst.Name = "BarButtonFirst"
			' 
			' BarButtonPrev
			' 
			Me.BarButtonPrev.Caption = "Prev"
			Me.BarButtonPrev.Id = 3
			Me.BarButtonPrev.Name = "BarButtonPrev"
			' 
			' barStaticItem1
			' 
			Me.barStaticItem1.Caption = "[Records 0 of 1]"
			Me.barStaticItem1.Id = 2
			Me.barStaticItem1.Name = "barStaticItem1"
			Me.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near
			' 
			' BarButtonNext
			' 
			Me.BarButtonNext.Caption = "Next"
			Me.BarButtonNext.Id = 1
			Me.BarButtonNext.Name = "BarButtonNext"
			' 
			' BarButtonLast
			' 
			Me.BarButtonLast.Caption = "Last"
			Me.BarButtonLast.Id = 4
			Me.BarButtonLast.Name = "BarButtonLast"
			' 
			' BarButtonAdd
			' 
			Me.BarButtonAdd.Caption = "Add"
			Me.BarButtonAdd.Id = 5
			Me.BarButtonAdd.Name = "BarButtonAdd"
			' 
			' BarButtonDelete
			' 
			Me.BarButtonDelete.Caption = "Delete"
			Me.BarButtonDelete.Id = 6
			Me.BarButtonDelete.Name = "BarButtonDelete"
			' 
			' barDockControlTop
			' 
			Me.barDockControlTop.CausesValidation = False
			' 
			' barDockControlBottom
			' 
			Me.barDockControlBottom.CausesValidation = False
			' 
			' barDockControlLeft
			' 
			Me.barDockControlLeft.CausesValidation = False
			' 
			' barDockControlRight
			' 
			Me.barDockControlRight.CausesValidation = False
			' 
			' dataGridView1
			' 
			Me.dataGridView1.AutoGenerateColumns = False
			Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
			Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() { Me.column1DataGridViewTextBoxColumn, Me.column2DataGridViewTextBoxColumn})
			Me.dataGridView1.DataSource = Me.bindingSource1
			Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.dataGridView1.Location = New System.Drawing.Point(0, 28)
			Me.dataGridView1.Name = "dataGridView1"
			Me.dataGridView1.Size = New System.Drawing.Size(438, 293)
			Me.dataGridView1.TabIndex = 4
			' 
			' column1DataGridViewTextBoxColumn
			' 
			Me.column1DataGridViewTextBoxColumn.DataPropertyName = "Column1"
			Me.column1DataGridViewTextBoxColumn.HeaderText = "Column1"
			Me.column1DataGridViewTextBoxColumn.Name = "column1DataGridViewTextBoxColumn"
			' 
			' column2DataGridViewTextBoxColumn
			' 
			Me.column2DataGridViewTextBoxColumn.DataPropertyName = "Column2"
			Me.column2DataGridViewTextBoxColumn.HeaderText = "Column2"
			Me.column2DataGridViewTextBoxColumn.Name = "column2DataGridViewTextBoxColumn"
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(438, 321)
			Me.Controls.Add(Me.dataGridView1)
			Me.Controls.Add(Me.barDockControlLeft)
			Me.Controls.Add(Me.barDockControlRight)
			Me.Controls.Add(Me.barDockControlBottom)
			Me.Controls.Add(Me.barDockControlTop)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.dataSet1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataTable1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.bindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.barManager1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private dataSet1 As System.Data.DataSet
		Private dataTable1 As System.Data.DataTable
		Private dataColumn1 As System.Data.DataColumn
		Private dataColumn2 As System.Data.DataColumn
		Private bindingSource1 As System.Windows.Forms.BindingSource
		Private barManager1 As DevExpress.XtraBars.BarManager
		Private bar1 As DevExpress.XtraBars.Bar
		Private barDockControlTop As DevExpress.XtraBars.BarDockControl
		Private barDockControlBottom As DevExpress.XtraBars.BarDockControl
		Private barDockControlLeft As DevExpress.XtraBars.BarDockControl
		Private barDockControlRight As DevExpress.XtraBars.BarDockControl
		Private dataGridView1 As System.Windows.Forms.DataGridView
		Private column1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
		Private column2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
		Private BarButtonFirst As DevExpress.XtraBars.BarButtonItem
		Private BarButtonNext As DevExpress.XtraBars.BarButtonItem
		Private barStaticItem1 As DevExpress.XtraBars.BarStaticItem
		Private BarButtonPrev As DevExpress.XtraBars.BarButtonItem
		Private BarButtonLast As DevExpress.XtraBars.BarButtonItem
		Private BarButtonAdd As DevExpress.XtraBars.BarButtonItem
		Private BarButtonDelete As DevExpress.XtraBars.BarButtonItem
	End Class
End Namespace

