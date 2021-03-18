using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CPSC_481
{
	/// <summary>
	/// Interaction logic for ItemPage.xaml
	/// </summary>
	public partial class ItemPage : UserControl
	{
		// Reference to the orderhandler in the mainwindow
		public static OrderHandler orderHandler { get; set; }

		List<Addon> addons_selected = new List<Addon>();
		List<string> options_selected = new List<string>();
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

		private float getTotal(MenuItem item) {
			var total = item.Cost;

			foreach (var addon in addons_selected) {
				total += addon.Cost;
			}

			foreach (var option in options_selected)
			{
				//total += option.Cost;
			}

			return total;
		}

		private string BuildOptions(List<string> options)
		{
			if (options.Count == 0) return "";

			var output = "with ";
			for (int i = 0; i < options.Count; i++)
			{
				output += options[i];
				if (i != options.Count - 1) output += " and ";
			}
			return output;
		}
		void Button_Click_AddToOrder(object sender, RoutedEventArgs e)
		{
			var item = orderHandler.getCurrentItem();

			var _Cost = getTotal(item);
			var optionString = BuildOptions(options_selected);

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
