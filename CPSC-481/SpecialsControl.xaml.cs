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
	/// Interaction logic for SpecialsControl.xaml
	/// </summary>
	public partial class SpecialsControl : UserControl
	{
		MenuItem thisItem = new MenuItem();

		public SpecialsControl(MenuItem menuItem)
		{
			InitializeComponent();
			thisItem = menuItem;

			try
			{
				imageSrc.Source = menuItem.ImageSrc;
				specialName.Text = menuItem.Name;
				specialPrice.Text = "$" + menuItem.Cost.ToString();
			}
			catch (Exception ex)
			{
				Trace.WriteLine("Special item is empty " + ex);
			}
		}

		private void specialBtnClick(object sender, RoutedEventArgs e)
		{
			OrderHandler orderHandler = new OrderHandler();

			ItemPage.orderHandler = orderHandler;

			orderHandler.currentItem = thisItem;

			// switch to the Item Page to display this item
			Switcher.Switch(new ItemPage());
		}
	}
}
