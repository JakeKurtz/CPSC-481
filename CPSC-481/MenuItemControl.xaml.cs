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
		public MenuItemControl(MenuItem menuItem)
		{
			InitializeComponent();
			// get the current item that the user is looking at
			//var item = orderHandler.currentItem;

			//// update the user control with item info
			//imageSrc.Source = item.ImageSrc;
			//itemName.Text = item.Name;
			//itemDesc.Text = item.Description;
			//itemPrice.Text = "  $" + item.Cost.ToString();

			try
			{
				Trace.WriteLine("MENU ITEM NAME: " + menuItem.Name);
				imageSrc.Source = menuItem.ImageSrc;
				itemName.Text = menuItem.Name;
				itemDesc.Text = menuItem.Description;
				itemPrice.Text = "  $" + menuItem.Cost.ToString();
			}
			catch (Exception ex) {
				Trace.WriteLine("Menu item is empty");
			}
		}
	}
}
