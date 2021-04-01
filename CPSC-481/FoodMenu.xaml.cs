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
using System.ComponentModel;

namespace CPSC_481
{
	/// <summary>
	/// Interaction logic for FoodMenu.xaml
	/// </summary>
	public partial class FoodMenu : UserControl
	{
		// Get the MenuList from the MainWindow
		//public static Dictionary<Categories, List<MenuItem>> menuLists { get; set; }
		public static OrderHandler orderHandler { get; set; }

		public FoodMenu()
		{
			InitializeComponent();

			applyFilters();

			setupMenus(orderHandler.foodMenuLists_filtered[Categories.Special]);

			allergies_filter.ItemsSource = orderHandler.filterList;
			diet_filter.ItemsSource = orderHandler.dietFilterList;

			orderHandler.currentPage = Categories.Special;

			btnSelected(0);

			menuTitle.Text = "Specials";
		}

		private void specialsClick(object sender, RoutedEventArgs e)
		{
			setupMenus(orderHandler.foodMenuLists_filtered[Categories.Special]);
			btnSelected(0);
			orderHandler.currentPage = Categories.Special;
			applyFilters();
			menuTitle.Text = "Specials";
		}
		private void appetizerClick(object sender, RoutedEventArgs e)
		{
			setupMenus(orderHandler.foodMenuLists_filtered[Categories.Apps]);
			btnSelected(1);
			orderHandler.currentPage = Categories.Apps;
			applyFilters();
			menuTitle.Text = "Appies";
		}
		private void mainClick(object sender, RoutedEventArgs e)
		{
			setupMenus(orderHandler.foodMenuLists_filtered[Categories.Main]);
			btnSelected(2);
			orderHandler.currentPage = Categories.Main;
			applyFilters();
			menuTitle.Text = "Main";
		}
		private void sidesClick(object sender, RoutedEventArgs e)
		{
			setupMenus(orderHandler.foodMenuLists_filtered[Categories.Side]);
			btnSelected(3);
			orderHandler.currentPage = Categories.Side;
			applyFilters();
			menuTitle.Text = "Sides";
		}

		private void HandleCheck(object sender, RoutedEventArgs e)
		{
			KeyValuePair<string, bool> option = (KeyValuePair<string, bool>)(((sender as CheckBox)?.Tag as ListViewItem)?.DataContext);

			if (orderHandler.filterList.ContainsKey(option.Key)) orderHandler.filterList[option.Key] = !orderHandler.filterList[option.Key];
			else if (orderHandler.dietFilterList.ContainsKey(option.Key)) orderHandler.dietFilterList[option.Key] = !orderHandler.dietFilterList[option.Key];

			applyFilters();
			setupMenus(orderHandler.foodMenuLists_filtered[orderHandler.currentPage]);
		}

		private void Button_Ok_Filter(object sender, RoutedEventArgs e)
		{
			//refreshPage();
		}

		private void setupMenus(List<MenuItem> list) {
			var firstArray = list.Take(list.Count() / 2).ToArray();
			var secondArray = list.Skip(list.Count() / 2).ToArray();

			_items_column_1.ItemsSource = secondArray;
			_items_column_2.ItemsSource = firstArray;
		}

		private void applyFilters() {
			Categories i = 0;
			if (orderHandler.foodMenuLists_filtered == null) orderHandler.foodMenuLists_filtered = new Dictionary<Categories, List<MenuItem>>();
			else orderHandler.foodMenuLists_filtered.Clear();

			Dictionary<Categories, (int, int)> foobar = new Dictionary<Categories, (int, int)>();

			foreach (var menu in orderHandler.foodMenuLists) 
			{
				List<MenuItem> newMenu = new List<MenuItem>();

				int numberOfItems = 0;
				int numberofFilters = 0;

				foreach (var item in menu.Value)
				{
					bool flag = true;
					foreach (var filter in orderHandler.filterList) 
					{
						if (filter.Value && !item.FilterTags.ContainsKey(filter.Key))
						{
							flag = false;
							break;
						}
					}
					foreach (var filter in orderHandler.dietFilterList)
					{
						if (filter.Value && !item.FilterTags.ContainsKey(filter.Key))
						{
							flag = false;
							break;
						}
					}

					if (flag)
					{
						newMenu.Add(item);
						numberOfItems++;
					}
				}

				foreach (var filter in orderHandler.filterList)
				{
					if (filter.Value) numberofFilters++;
				}
				foreach (var filter in orderHandler.dietFilterList)
				{
					if (filter.Value) numberofFilters++;
				}

				foobar.Add(i, (numberOfItems, numberofFilters));

				if (orderHandler.foodMenuLists_filtered.ContainsKey(i)) 
				{
					orderHandler.foodMenuLists_filtered[i] = newMenu;
				} 
				else
				{
					orderHandler.foodMenuLists_filtered.Add(i, newMenu);
				}
				i++;
			}
			//return foobar;

			var _numberofItems = foobar[orderHandler.currentPage].Item1;
			var _numberofFilters = foobar[orderHandler.currentPage].Item2;

			if (_numberofFilters != 0) filterStats.Text = _numberofItems.ToString() + " Results (" + _numberofFilters.ToString() + " applied)";
			else filterStats.Text = "";
		}

		// switches the background colour of buttons based on the menu that's selected
		private void btnSelected(int n)
		{
			if (n == 0)
			{
				specialsFoodBtn.Background = Brushes.LightGray;
				appetizersBtn.Background = Brushes.White;
				mainBtn.Background = Brushes.White;
				sidesBtn.Background = Brushes.White;
			}
			else if (n == 1)
			{
				specialsFoodBtn.Background = Brushes.White;
				appetizersBtn.Background = Brushes.LightGray;
				mainBtn.Background = Brushes.White;
				sidesBtn.Background = Brushes.White;
			}
			else if (n == 2)
			{
				specialsFoodBtn.Background = Brushes.White;
				appetizersBtn.Background = Brushes.White;
				mainBtn.Background = Brushes.LightGray;
				sidesBtn.Background = Brushes.White;
			}
			else
			{
				specialsFoodBtn.Background = Brushes.White;
				appetizersBtn.Background = Brushes.White;
				mainBtn.Background = Brushes.White;
				sidesBtn.Background = Brushes.LightGray;
			}
		}
		private void selectItemClick(object sender, RoutedEventArgs e)
		{
			var item = ((sender as Button)?.Tag as ListViewItem)?.DataContext as MenuItem;
			orderHandler.currentItem = item;
			// switch to the Item Page to display this item
			Switcher.Switch(new ItemPage());
		}
	}
}
