using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace DevExpress.Demos.Navigator
{
	public enum ActionType
	{
		None,
		First,
		Prev,
		Next,
		Last,
		Add,
		Delete,
		EndEdit,
		Custom
	};

	#region Abstract
	public class AbstractDataNavigator : Component
	{
		public AbstractDataNavigator()
		{
			buttonsValue = CreateButtonsCollection();
		}

		protected override void Dispose(bool disposing)
		{
			Buttons.Clear();
			base.Dispose(disposing);
		}

		BindingContext bindingContext;
		public BindingContext BindingContext
		{
			get
			{
				return bindingContext;
			}
			set
			{
				if ( bindingContext != value )
				{
					BindingChanging();
					bindingContext = value;
					BindingChanged();
				}
			}
		}

		string dataMember = string.Empty;
		public string DataMember
		{
			get
			{
				return dataMember;
			}
			set
			{
				if ( dataMember != value )
				{
					BindingChanging();
					dataMember = value;
					BindingChanged();
				}
			}
		}

		object dataSource;
		public object DataSource
		{
			get
			{
				return dataSource;
			}
			set
			{
				if ( dataSource != value )
				{
					BindingChanging();
					dataSource = value;
					BindingChanged();
				}
			}
		}

		protected BindingManagerBase CurrencyManager
		{
			get
			{
				try
				{
					return BindingContext[DataSource, DataMember];
				}
				catch
				{
					return null;
				}
			}
		}

		protected virtual void BindingChanging()
		{
			if ( CurrencyManager != null )
			{
				CurrencyManager.CurrentChanged -= new EventHandler(CurrencyManager_CurrentChanged);
				CurrencyManager.PositionChanged -= new EventHandler(CurrencyManager_PositionChanged);
			}
		}

		protected virtual void BindingChanged()
		{
			if ( CurrencyManager != null )
			{
				CurrencyManager.CurrentChanged += new EventHandler(CurrencyManager_CurrentChanged);
				CurrencyManager.PositionChanged += new EventHandler(CurrencyManager_PositionChanged);
			}
			UpdateButtons();
		}

		protected virtual void CurrencyManager_CurrentChanged(object sender, EventArgs e)
		{
			UpdateButtons();
		}

		protected virtual void CurrencyManager_PositionChanged(object sender, EventArgs e)
		{
			UpdateButtons();
		}

		public virtual void UpdateButtons()
		{
			foreach ( ButtonLink link in Buttons )
			{
				switch ( link.ActionType )
				{
					case ActionType.First:
					case ActionType.Prev:
						link.Enabled = (CurrencyManager != null) && (CurrencyManager.Position > 0);
						break;
					case ActionType.Next:
					case ActionType.Last:
						link.Enabled = (CurrencyManager != null) && (CurrencyManager.Position < CurrencyManager.Count - 1);
						break;
					case ActionType.Add:
						link.Enabled = CurrencyManager != null && DataSource as IBindingList != null && ((IBindingList)DataSource).AllowNew;
						break;
					case ActionType.Delete:
						link.Enabled = CurrencyManager != null && DataSource as IList != null && !((IList)DataSource).IsFixedSize && !((IList)DataSource).IsReadOnly && CurrencyManager.Position != -1;
						break;
				}
			}
		}

		public virtual void PerformAction(ActionType action)
		{
			if ( CurrencyManager == null || CurrencyManager.Count == 0 )
				return;

			switch ( action )
			{
				case ActionType.None:
					break;
				case ActionType.First:
					CurrencyManager.Position = 0;
					break;
				case ActionType.Prev:
					if ( CurrencyManager.Position > 0 )
						CurrencyManager.Position--;
					break;
				case ActionType.Next:
					if ( CurrencyManager.Position < CurrencyManager.Count - 1 )
						CurrencyManager.Position++;
					break;
				case ActionType.Last:
					CurrencyManager.Position = CurrencyManager.Count - 1;
					break;
				case ActionType.Add:
					CurrencyManager.AddNew();
					break;
				case ActionType.Delete:
					CurrencyManager.RemoveAt(CurrencyManager.Position);
					break;
				default:
					throw new NotSupportedException();
			}
		}

		protected ButtonsCollection buttonsValue;
		public ButtonsCollection Buttons
		{
			get
			{
				return buttonsValue;
			}
		}

		protected virtual ButtonsCollection CreateButtonsCollection()
		{
			return new ButtonsCollection(this);
		}
	}

	public class ButtonsCollection : CollectionBase
	{
		public ButtonsCollection(AbstractDataNavigator navigator)
		{
			navigatorValue = navigator;
		}

		protected AbstractDataNavigator navigatorValue;
		public AbstractDataNavigator Navigator
		{
			get
			{
				return navigatorValue;
			}
		}

		protected virtual ButtonLink CreateInstance()
		{
			return null;
		}

		public ButtonLink Add()
		{
			ButtonLink link = CreateInstance();
			if ( link != null )
				List.Add(link);
			return link;
		}

		protected override void OnClear()
		{
			foreach ( IDisposable item in this )
				item.Dispose();
			base.OnClear();
		}

		protected override void OnRemoveComplete(int index, object item)
		{
			base.OnRemoveComplete(index, item);
			(item as IDisposable).Dispose();
		}
	}

	public abstract class ButtonLink : IDisposable
	{
		protected ButtonsCollection ownerValue;
		public ButtonLink(ButtonsCollection owner)
			: this(owner, ActionType.None, null)
		{
		}

		public ButtonLink(ButtonsCollection owner, ActionType action, object button)
		{
			ownerValue = owner;
			actionType = action;
			this.button = button;
		}

		ActionType actionType;
		public ActionType ActionType
		{
			get
			{
				return actionType;
			}
			set
			{
				actionType = value;
			}
		}

		protected abstract void AttachEvent();

		protected virtual void BeforeDispose()
		{
			Button = null;
		}

		object button;
		public object Button
		{
			get
			{
				return button;
			}
			set
			{
				if ( button != value )
				{
					DetachEvent();
					button = value;
					AttachEvent();
				}
			}
		}

		protected virtual void Click()
		{
			ownerValue.Navigator.PerformAction(actionType);
		}
		protected abstract void DetachEvent();

		public abstract bool Enabled
		{
			get;
			set;
		}

		public abstract bool Visible
		{
			get;
			set;
		}

		void IDisposable.Dispose()
		{
			BeforeDispose();
		}
	}
	#endregion

	#region XtraBars Navigator
	public class XtraBarsDataNavigator : AbstractDataNavigator
	{
		protected override ButtonsCollection CreateButtonsCollection()
		{
			return new XtraBarsButtonsCollection(this);
		}

		BarManager manager;
		public BarManager BarManager
		{
			get
			{
				return manager;
			}
			set
			{
				manager = value;
			}
		}

		BarStaticItem label;
		public BarStaticItem Label
		{
			get
			{
				return label;
			}
			set
			{
				label = value;
			}
		}

		public override void UpdateButtons()
		{
			base.UpdateButtons();
			SetLabelText();
		}

		protected virtual void SetLabelText()
		{
			if ( Label != null )
			{
				Label.Caption = GetLabelText();
			}
		}

		private string GetLabelText()
		{
			if ( CurrencyManager == null )
				return string.Empty;
			return string.Format("[Record {0} of {1}]", CurrencyManager.Position + 1, CurrencyManager.Count);
		}
	}

	public class XtraBarsButtonsCollection : ButtonsCollection
	{
		public XtraBarsButtonsCollection(AbstractDataNavigator navigator)
			: base(navigator)
		{
		}
		protected override ButtonLink CreateInstance()
		{
			return new XtraBarsButtonLink(this);
		}
	}

	public class XtraBarsButtonLink : ButtonLink
	{
		public XtraBarsButtonLink(ButtonsCollection owner)
			: base(owner)
		{
		}
		public XtraBarsButtonLink(ButtonsCollection owner, ActionType action, DevExpress.XtraBars.BarButtonItem button)
			: base(owner, action, button)
		{
		}

		private void BarButtonItem_ItemClick(object sender, ItemClickEventArgs e)
		{
			Click();
		}

		protected override void AttachEvent()
		{
			if ( Button != null )
				Button.ItemClick += new ItemClickEventHandler(BarButtonItem_ItemClick);
		}

		public new BarButtonItem Button
		{
			get
			{
				return base.Button as BarButtonItem;
			}
			set
			{
				base.Button = value;
			}
		}

		public override bool Enabled
		{
			get
			{
				return (Button != null && Button.Enabled);
			}
			set
			{
				if ( Button != null )
					Button.Enabled = value;
			}
		}

		protected override void DetachEvent()
		{
			if ( Button != null )
				Button.ItemClick -= new ItemClickEventHandler(BarButtonItem_ItemClick);
		}

		public override bool Visible
		{
			get
			{
				return (Button != null && Button.Visibility == BarItemVisibility.Always);
			}
			set
			{
				if ( Button != null )
					Button.Visibility = value ? BarItemVisibility.Always : BarItemVisibility.OnlyInCustomizing;
			}
		}

	}
	#endregion
}