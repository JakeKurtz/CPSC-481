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

		List<MenuItem> MainList = menuLists.MainList;
		List<MenuItem> SideList = menuLists.SideList;

	public FoodMenu()
		{
			InitializeComponent();
			// pass the appetizer list into the constructor of the AppetizerPage
			Food.Content = new AppetizerPage(menuLists.AppetizerList);
			menuTitle.Text = "Appetizers";
		}

		private void specialsClick(object sender, RoutedEventArgs e)
		{
			Food.Content = new SpecialsPage();
			menuTitle.Text = "Today's Specials";
		}

		private void appetizerClick(object sender, RoutedEventArgs e)
		{
			// pass the appetizer list into the constructor of the AppetizerPage
			Food.Content = new AppetizerPage(menuLists.AppetizerList);
			menuTitle.Text = "Appetizers";
		}

		private void mainClick(object sender, RoutedEventArgs e)
		{
			Food.Content = new MainPage();
			menuTitle.Text = "Main Dishes";
		}

		private void sidesClick(object sender, RoutedEventArgs e)
		{
			Food.Content = new SidesPage();
			menuTitle.Text = "Sides";
		}
	}
}
