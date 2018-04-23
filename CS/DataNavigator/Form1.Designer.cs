namespace DataNavigator
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if ( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.dataSet1 = new System.Data.DataSet();
			this.dataTable1 = new System.Data.DataTable();
			this.dataColumn1 = new System.Data.DataColumn();
			this.dataColumn2 = new System.Data.DataColumn();
			this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
			this.bar1 = new DevExpress.XtraBars.Bar();
			this.BarButtonFirst = new DevExpress.XtraBars.BarButtonItem();
			this.BarButtonPrev = new DevExpress.XtraBars.BarButtonItem();
			this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
			this.BarButtonNext = new DevExpress.XtraBars.BarButtonItem();
			this.BarButtonLast = new DevExpress.XtraBars.BarButtonItem();
			this.BarButtonAdd = new DevExpress.XtraBars.BarButtonItem();
			this.BarButtonDelete = new DevExpress.XtraBars.BarButtonItem();
			this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
			this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.column1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.column2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1});
			// 
			// dataTable1
			// 
			this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2});
			this.dataTable1.TableName = "Table1";
			// 
			// dataColumn1
			// 
			this.dataColumn1.ColumnName = "Column1";
			// 
			// dataColumn2
			// 
			this.dataColumn2.ColumnName = "Column2";
			// 
			// bindingSource1
			// 
			this.bindingSource1.DataMember = "Table1";
			this.bindingSource1.DataSource = this.dataSet1;
			// 
			// barManager1
			// 
			this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
			this.barManager1.DockControls.Add(this.barDockControlTop);
			this.barManager1.DockControls.Add(this.barDockControlBottom);
			this.barManager1.DockControls.Add(this.barDockControlLeft);
			this.barManager1.DockControls.Add(this.barDockControlRight);
			this.barManager1.Form = this;
			this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BarButtonFirst,
            this.BarButtonNext,
            this.barStaticItem1,
            this.BarButtonPrev,
            this.BarButtonLast,
            this.BarButtonAdd,
            this.BarButtonDelete});
			this.barManager1.MaxItemId = 7;
			// 
			// bar1
			// 
			this.bar1.BarName = "Tools";
			this.bar1.DockCol = 0;
			this.bar1.DockRow = 0;
			this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
			this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonFirst),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonPrev),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonNext, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonLast),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonAdd, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.BarButtonDelete)});
			this.bar1.Text = "Tools";
			// 
			// BarButtonFirst
			// 
			this.BarButtonFirst.Caption = "First";
			this.BarButtonFirst.Id = 0;
			this.BarButtonFirst.Name = "BarButtonFirst";
			// 
			// BarButtonPrev
			// 
			this.BarButtonPrev.Caption = "Prev";
			this.BarButtonPrev.Id = 3;
			this.BarButtonPrev.Name = "BarButtonPrev";
			// 
			// barStaticItem1
			// 
			this.barStaticItem1.Caption = "[Records 0 of 1]";
			this.barStaticItem1.Id = 2;
			this.barStaticItem1.Name = "barStaticItem1";
			this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
			// 
			// BarButtonNext
			// 
			this.BarButtonNext.Caption = "Next";
			this.BarButtonNext.Id = 1;
			this.BarButtonNext.Name = "BarButtonNext";
			// 
			// BarButtonLast
			// 
			this.BarButtonLast.Caption = "Last";
			this.BarButtonLast.Id = 4;
			this.BarButtonLast.Name = "BarButtonLast";
			// 
			// BarButtonAdd
			// 
			this.BarButtonAdd.Caption = "Add";
			this.BarButtonAdd.Id = 5;
			this.BarButtonAdd.Name = "BarButtonAdd";
			// 
			// BarButtonDelete
			// 
			this.BarButtonDelete.Caption = "Delete";
			this.BarButtonDelete.Id = 6;
			this.BarButtonDelete.Name = "BarButtonDelete";
			// 
			// barDockControlTop
			// 
			this.barDockControlTop.CausesValidation = false;
			// 
			// barDockControlBottom
			// 
			this.barDockControlBottom.CausesValidation = false;
			// 
			// barDockControlLeft
			// 
			this.barDockControlLeft.CausesValidation = false;
			// 
			// barDockControlRight
			// 
			this.barDockControlRight.CausesValidation = false;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoGenerateColumns = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column1DataGridViewTextBoxColumn,
            this.column2DataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.bindingSource1;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 28);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(438, 293);
			this.dataGridView1.TabIndex = 4;
			// 
			// column1DataGridViewTextBoxColumn
			// 
			this.column1DataGridViewTextBoxColumn.DataPropertyName = "Column1";
			this.column1DataGridViewTextBoxColumn.HeaderText = "Column1";
			this.column1DataGridViewTextBoxColumn.Name = "column1DataGridViewTextBoxColumn";
			// 
			// column2DataGridViewTextBoxColumn
			// 
			this.column2DataGridViewTextBoxColumn.DataPropertyName = "Column2";
			this.column2DataGridViewTextBoxColumn.HeaderText = "Column2";
			this.column2DataGridViewTextBoxColumn.Name = "column2DataGridViewTextBoxColumn";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(438, 321);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.barDockControlLeft);
			this.Controls.Add(this.barDockControlRight);
			this.Controls.Add(this.barDockControlBottom);
			this.Controls.Add(this.barDockControlTop);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Data.DataSet dataSet1;
		private System.Data.DataTable dataTable1;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Windows.Forms.BindingSource bindingSource1;
		private DevExpress.XtraBars.BarManager barManager1;
		private DevExpress.XtraBars.Bar bar1;
		private DevExpress.XtraBars.BarDockControl barDockControlTop;
		private DevExpress.XtraBars.BarDockControl barDockControlBottom;
		private DevExpress.XtraBars.BarDockControl barDockControlLeft;
		private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn column1DataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn column2DataGridViewTextBoxColumn;
		private DevExpress.XtraBars.BarButtonItem BarButtonFirst;
		private DevExpress.XtraBars.BarButtonItem BarButtonNext;
		private DevExpress.XtraBars.BarStaticItem barStaticItem1;
		private DevExpress.XtraBars.BarButtonItem BarButtonPrev;
		private DevExpress.XtraBars.BarButtonItem BarButtonLast;
		private DevExpress.XtraBars.BarButtonItem BarButtonAdd;
		private DevExpress.XtraBars.BarButtonItem BarButtonDelete;
	}
}

