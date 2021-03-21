using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace CPSC_481
{
	/// <summary>
	/// Interaction logic for ItemPage.xaml
	/// </summary>
	public partial class ItemPage : UserControl
	{
		// Reference to the orderhandler in the mainwindow
		public static OrderHandler orderHandler { get; set; }

		Dictionary<Guid, Option> options_selected = new Dictionary<Guid, Option>();
		List<Addon> addons_selected = new List<Addon>();

		string _SpecialRequest = "";

		public ItemPage()
		{
			InitializeComponent();

			// get the current item that the user is looking at
			var item = orderHandler.currentItem;

			// update the user control with item info
			itemName.Text = item.Name;
			itemDescription.Text = item.Description;
			itemImageSrc.Source = item.ImageSrc;
			itemCost.Text = "  $" + item.Cost.ToString();
			itemOptions.ItemsSource = item.Options.Values;
			itemAddons.ItemsSource = item.Addons;
		}

		private void Button_Add_Addon(object sender, RoutedEventArgs e)
		{
			var item = ((sender as Button)?.Tag as ListViewItem)?.DataContext as Addon;
			item.Quantity += 1;
			itemCost.Text = "  $" + getTotal(orderHandler.currentItem).ToString();
		}
		private void Button_Remove_Addon(object sender, RoutedEventArgs e)
		{
			var item = ((sender as Button)?.Tag as ListViewItem)?.DataContext as Addon;
			if (item.Quantity != 0) item.Quantity -= 1;
			itemCost.Text = "  $" + getTotal(orderHandler.currentItem).ToString();
		}

		private void HandleCheck(object sender, RoutedEventArgs e)
		{
			var option = ((sender as RadioButton)?.Tag as ListViewItem)?.DataContext as Option;
			options_selected[option.ID] = option;
			var group = (sender as RadioButton).GroupName;

			orderHandler.currentItem.Options[group].Selected = true;
			orderHandler.currentItem.Options[group].Color = Colors.Black;
		}

		private float getTotal(MenuItem item) {
			var total = item.Cost;

			foreach (var addon in item.Addons) 
			{
				total += addon.Cost * addon.Quantity;
			}

			foreach (KeyValuePair<Guid, Option> ele in options_selected)
			{
				total += ele.Value.Cost;
			}

			return total;
		}

		private string BuildOptions()
		{
			if (options_selected.Count == 0) return "";

			var output = "with ";
			var i = 0;
			foreach (KeyValuePair<Guid, Option> ele in options_selected)
			{
				output += ele.Value.Name;
				if (i != options_selected.Count - 1) output += " and ";
				i++;
			}
			return output;
		}

		private bool verifyOptions() 
		{
			var item = orderHandler.currentItem;

			bool success = true;
			foreach (KeyValuePair<string, OptionType> ele in item.Options)
			{
				if (!ele.Value.Selected)
				{
					ele.Value.Color = Colors.Red;
					if (success) success = false;
				}
			}
			return success;
		}

		private bool clearOptionSelections()
		{
			var item = orderHandler.currentItem;

			bool success = true;
			foreach (KeyValuePair<string, OptionType> ele in item.Options)
			{
				ele.Value.Selected = false;
			}
			return success;
		}


		private bool sendit = false; 
		void Button_Click_AddToOrder(object sender, RoutedEventArgs e)
		{
			if (verifyOptions())
			{
				sendit = true;
				DialogContentTextBlock.Text = "Item has been added to your order!";
				var item = orderHandler.currentItem;

				var _Cost = getTotal(item);

				foreach (var a in item.Addons)
				{
					if (a.Quantity > 0)
					{
						var addon = a.Copy();
						addon.Cost *= addon.Quantity;
						addons_selected.Add(addon);
						a.Quantity = 0;
					}
				}
				var optionString = BuildOptions();

				OrderItem orderItem = new OrderItem
				{
					ID = Guid.NewGuid(),
					Name = item.Name,
					Addons = new List<Addon>(addons_selected),
					Options = optionString,
					SpecialRequest = _SpecialRequest,
					Cost = _Cost,
					Quantity = 1
				};

				orderHandler.AddToOrder(orderItem);

				addons_selected.Clear();
				options_selected.Clear();
				clearOptionSelections();
			} else
			{
				DialogContentTextBlock.Text = "Please select from the required options above";
			}
		}
		public void Button_Confirm_Order(object sender, RoutedEventArgs e)
		{
			if (sendit)
			{
				Switcher.Switch(new FoodMenu());
			}
		}
	}
}
