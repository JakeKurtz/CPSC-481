using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CPSC_481
{
	/// <summary>
	/// Interaction logic for ItemPage.xaml
	/// </summary>
	public partial class ItemPage : UserControl
	{
		// Reference to the orderhandler in the mainwindow
		public static OrderHandler orderHandler { get; set; }

		Dictionary<int, Option> options_selected = new Dictionary<int, Option>();

		string _SpecialRequest = "";

		public ItemPage()
		{
			InitializeComponent();

			// get the current item that the user is looking at
			var item = orderHandler.getCurrentItem();

			// update the user control with item info
			itemName.Text = item.Name;
			itemDescription.Text = item.Description;
			itemImageSrc.Source = item.ImageSrc;
			//itemCost = item.Cost;
			itemOptions.ItemsSource = item.Options;
			itemAddons.ItemsSource = item.Addons;
		}

		private void Button_Add_Addon(object sender, RoutedEventArgs e)
		{
			var item = ((sender as Button)?.Tag as ListViewItem)?.DataContext as Addon;
			item.Quantity += 1;
		}
		private void Button_Remove_Addon(object sender, RoutedEventArgs e)
		{
			var item = ((sender as Button)?.Tag as ListViewItem)?.DataContext as Addon;
			if (item.Quantity != 0) item.Quantity -= 1;
		}

		private void HandleCheck(object sender, RoutedEventArgs e)
		{
			var option = ((sender as RadioButton)?.Tag as ListViewItem)?.DataContext as Option;
			options_selected[option.ID] = option;
		}

		private float getTotal(MenuItem item) {
			var total = item.Cost;

			//foreach (var addon in addons_selected) {
				//total += addon.Cost;
			//}

			//foreach (var option in options_selected)
			//{
				//total += option.Cost;
			//}

			return total;
		}

		private string BuildOptions(Dictionary<int, Option> options)
		{
			if (options.Count == 0) return "";

			var output = "with ";
			var i = 0;
			foreach (KeyValuePair<int, Option> ele in options)
			{
				output += ele.Value.Name;
				if (i != options.Count - 1) output += " and ";
				i++;
			}
			return output;
		}
		void Button_Click_AddToOrder(object sender, RoutedEventArgs e)
		{

			List<Addon> addons_selected = new List<Addon>();
			//List<string> options_selected = new List<string>();

			var item = orderHandler.getCurrentItem();

			var _Cost = getTotal(item);
			var optionString = BuildOptions(options_selected);

			foreach (var a in item.Addons)
			{
				if (a.Quantity > 0) addons_selected.Add(a);
			}

			OrderItem orderItem = new OrderItem { 
				Name = item.Name, 
				Addons = addons_selected, 
				Options = optionString, 
				SpecialRequest = _SpecialRequest, 
				Cost = _Cost, 
				Quantity = 1
			};

			orderHandler.AddToOrder(orderItem);
		}
	}
}
