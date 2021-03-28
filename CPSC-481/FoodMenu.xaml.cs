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
	/// Interaction logic for FoodMenu.xaml
	/// </summary>
	public partial class FoodMenu : UserControl
	{
		// Get the MenuList from the MainWindow
		public static Dictionary<Categories, List<MenuItem>> menuLists { get; set; }
		public static OrderHandler orderHandler { get; set; }

		public FoodMenu()
		{
			InitializeComponent();

			_items_column_1.ItemsSource = menuLists?[Categories.Special];
			_items_column_2.ItemsSource = menuLists?[Categories.Special];
			btnSelected(0);
		}

		private void specialsClick(object sender, RoutedEventArgs e)
		{
			_items_column_1.ItemsSource = menuLists?[Categories.Special];
			_items_column_2.ItemsSource = menuLists?[Categories.Special];
			btnSelected(0);
		}
		private void appetizerClick(object sender, RoutedEventArgs e)
		{
			_items_column_1.ItemsSource = menuLists[Categories.Apps];
			_items_column_2.ItemsSource = menuLists[Categories.Apps];
			btnSelected(1);
		}
		private void mainClick(object sender, RoutedEventArgs e)
		{
			_items_column_1.ItemsSource = menuLists[Categories.Main];
			_items_column_2.ItemsSource = menuLists?[Categories.Main];
			btnSelected(2);
		}
		private void sidesClick(object sender, RoutedEventArgs e)
		{
			_items_column_1.ItemsSource = menuLists[Categories.Side];
			_items_column_2.ItemsSource = menuLists[Categories.Side];
			btnSelected(3);
		}

		public void refreshPage() {
			_items_column_1.Items.Refresh();
			_items_column_2.Items.Refresh();
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
