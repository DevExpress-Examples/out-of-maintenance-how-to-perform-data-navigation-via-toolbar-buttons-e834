using System.Windows.Forms;
using DevExpress.Demos.Navigator;

namespace DataNavigator
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			for ( int i = 0; i < 5; i++ )
				dataTable1.Rows.Add(new object[] { "Item " + (i + 1).ToString() });

			barManager1.ForceInitialize();
			CreateNavigator();
		}

		private void CreateNavigator()
		{
			XtraBarsDataNavigator navigator;
			navigator = new XtraBarsDataNavigator();
			navigator.BindingContext = this.BindingContext;
			navigator.DataSource = bindingSource1;
			navigator.BarManager = barManager1;

			// link buttons
			ButtonLink link;
			link = navigator.Buttons.Add();
			link.ActionType = ActionType.First;
			link.Button = BarButtonFirst;
			link = navigator.Buttons.Add();
			link.ActionType = ActionType.Prev;
			link.Button = BarButtonPrev;
			link = navigator.Buttons.Add();
			link.ActionType = ActionType.Next;
			link.Button = BarButtonNext;
			link = navigator.Buttons.Add();
			link.ActionType = ActionType.Last;
			link.Button = BarButtonLast;
			link = navigator.Buttons.Add();
			link.ActionType = ActionType.Add;
			link.Button = BarButtonAdd;
			link = navigator.Buttons.Add();
			link.ActionType = ActionType.Delete;
			link.Button = BarButtonDelete;

			navigator.Label = barStaticItem1;
			navigator.UpdateButtons();
		}
	}
}
