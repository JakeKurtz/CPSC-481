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
		public static MenuLists menuLists { get; set; }

	public FoodMenu()
		{
			InitializeComponent();
			// pass the appetizer list into the constructor of the AppetizerPage
			Food.Content = new AppetizerPage(menuLists.AppetizerList);
			menuTitle.Text = "Appetizers";
			btnSelected(1);
		}

		private void specialsClick(object sender, RoutedEventArgs e)
		{
			Food.Content = new SpecialsPage(menuLists.SpecialsList);
			menuTitle.Text = "Today's Specials";
			btnSelected(0);
		}

		private void appetizerClick(object sender, RoutedEventArgs e)
		{
			// pass the appetizer list into the constructor of the AppetizerPage
			Food.Content = new AppetizerPage(menuLists.AppetizerList);
			menuTitle.Text = "Appetizers";
			btnSelected(1);
		}

		private void mainClick(object sender, RoutedEventArgs e)
		{
			Food.Content = new MainsPage(menuLists.MainList);
			menuTitle.Text = "Main Dishes";
			btnSelected(2);
		}

		private void sidesClick(object sender, RoutedEventArgs e)
		{
			Food.Content = new SidesPage(menuLists.SideList);
			menuTitle.Text = "Sides";
			btnSelected(3);
		}

		// switches the background colour of buttons based on the menu that's selected
		private void btnSelected(int n) {
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
	}
}
