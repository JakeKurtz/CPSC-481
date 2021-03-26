using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;


namespace CPSC_481
{
	/// <summary>
	/// Interaction logic for MenuItemControl.xaml
	/// </summary>
	public partial class MenuItemControl : UserControl
	{
		MenuItem thisItem = new MenuItem();

		public MenuItemControl(MenuItem menuItem)
		{
			InitializeComponent();
			thisItem = menuItem;

			try
			{
				imageSrc.Source = menuItem.ImageSrc;
				itemName.Text = menuItem.Name;
				itemDesc.Text = menuItem.Description;
				itemPrice.Text = "$" + menuItem.Cost.ToString();
				itemPrice.Text = "$" + menuItem.Cost.ToString();
			}
			catch (Exception ex) {
				Trace.WriteLine("Menu item is empty" + ex);
			}
		}

		private void selectItemClick(object sender, RoutedEventArgs e)
		{
			OrderHandler orderHandler = new OrderHandler();

			ItemPage.orderHandler = orderHandler;

			orderHandler.currentItem = thisItem;

			// omg please work
			Switcher.Switch(new ItemPage());

			//if (thisItem != null) {
			//	Trace.WriteLine("clicked on " + thisItem.Name);
			//}
		}
	}
}
