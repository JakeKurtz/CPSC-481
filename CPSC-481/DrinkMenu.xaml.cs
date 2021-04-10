using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CPSC_481
{
	/// <summary>
	/// Interaction logic for DrinkMenu.xaml
	/// </summary>
	public partial class DrinkMenu : UserControl
	{
		public static OrderHandler orderHandler { get; set; }

		public DrinkMenu()
		{
			InitializeComponent();

			applyFilters();
			setupMenus(orderHandler.drinkMenuLists_filtered[Categories.Beer]);
			btnSelected(0);
			orderHandler.currentPage = Categories.Beer;
			drinkMenuTitle.Text = "Beer";
		}

		// button click methods
		private void beerClick(object sender, RoutedEventArgs e)
		{
			setupMenus(orderHandler.drinkMenuLists_filtered[Categories.Beer]);
			btnSelected(0);
			orderHandler.currentPage = Categories.Beer;
			drinkMenuTitle.Text = "Beer";
		}
		private void wineClick(object sender, RoutedEventArgs e)
		{
			setupMenus(orderHandler.drinkMenuLists_filtered[Categories.Wine]);
			btnSelected(1);
			orderHandler.currentPage = Categories.Wine;
			drinkMenuTitle.Text = "Wine";
		}
		private void cocktailClick(object sender, RoutedEventArgs e)
		{
			setupMenus(orderHandler.drinkMenuLists_filtered[Categories.Cocktails]);
			btnSelected(2);
			orderHandler.currentPage = Categories.Cocktails;
			drinkMenuTitle.Text = "Cocktails";
		}
		private void nonAlcoholClick(object sender, RoutedEventArgs e)
		{
			setupMenus(orderHandler.drinkMenuLists_filtered[Categories.NonAlch]);
			btnSelected(3);
			orderHandler.currentPage = Categories.NonAlch;
			drinkMenuTitle.Text = "Non-Alcoholic";
		}

		private void selectItemClick(object sender, RoutedEventArgs e)
		{
			var item = ((sender as Button)?.Tag as ListViewItem)?.DataContext as MenuItem;
			orderHandler.currentItem = item;
			// switch to the Item Page to display this item
			Switcher.Switch(new ItemPage());
		}

		private void setupMenus(List<MenuItem> list)
		{
			var firstArray = list.Take(list.Count() / 2).ToArray();
			var secondArray = list.Skip(list.Count() / 2).ToArray();

			_items_column_1.ItemsSource = secondArray;
			_items_column_2.ItemsSource = firstArray;
		}

		private void applyFilters()
		{
			Categories i = Categories.Beer;
			orderHandler.drinkMenuLists_filtered.Clear();
			foreach (var menu in orderHandler.drinkMenuLists)
			{
				List<MenuItem> newMenu = new List<MenuItem>();
				foreach (var item in menu.Value)
				{
					bool flag = true;
					foreach (var filter in item.FilterTags)
					{
						if (!orderHandler.filterList.ContainsKey(filter.Key))
						{
							flag = false;
							break;
						}
					}
					if (flag) newMenu.Add(item);
				}

				if (orderHandler.drinkMenuLists_filtered.ContainsKey(i))
				{
					orderHandler.drinkMenuLists_filtered[i] = newMenu;
				}
				else
				{
					orderHandler.drinkMenuLists_filtered.Add(i, newMenu);
				}
				i++;
			}
		}

		private void btnSelected(int n)
		{
			if (n == 0)
			{
				beerBtn.Background = Brushes.LightGray;
				wineBtn.Background = Brushes.White;
				cocktailBtn.Background = Brushes.White;
				nonAlcoholBtn.Background = Brushes.White;
			}
			else if (n == 1)
			{
				beerBtn.Background = Brushes.White;
				wineBtn.Background = Brushes.LightGray;
				cocktailBtn.Background = Brushes.White;
				nonAlcoholBtn.Background = Brushes.White;
			}
			else if (n == 2)
			{
				beerBtn.Background = Brushes.White;
				wineBtn.Background = Brushes.White;
				cocktailBtn.Background = Brushes.LightGray;
				nonAlcoholBtn.Background = Brushes.White;
			}
			else
			{
				beerBtn.Background = Brushes.White;
				wineBtn.Background = Brushes.White;
				cocktailBtn.Background = Brushes.White;
				nonAlcoholBtn.Background = Brushes.LightGray;
			}
		}
	}
}
