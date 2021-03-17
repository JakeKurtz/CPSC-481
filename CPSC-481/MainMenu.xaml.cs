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

namespace CPSC_481
{
	/// <summary>
	/// Interaction logic for MainMenu.xaml
	/// </summary>
	public partial class MainMenu : UserControl
	{

		public MainMenu()
		{
			InitializeComponent();
		}
		void Button_Click_0(object sender, RoutedEventArgs e)
		{
			Switcher.Switch(new FoodMenu());
		}
		
		void Button_Click_1(object sender, RoutedEventArgs e)
		{
			//Switcher.Switch(new DrinkMenu());
		}

		void Button_Click_2(object sender, RoutedEventArgs e)
		{
			Switcher.Switch(new OrderPage());
		}

		void Button_Click_3(object sender, RoutedEventArgs e)
		{
			Switcher.Switch(new HelpPage());
		}

		public void SetButtonIconForground(Brush color, MenuButton b)
		{
			switch (b)
			{
				case MenuButton.Food:
					FoodIcon.Foreground = color;
					FoodIconText.Foreground = color;
					break;
				case MenuButton.Drink:
					DrinkIcon.Foreground = color;
					DrinkIconText.Foreground = color;
					break;
				case MenuButton.Help:
					HelpIcon.Foreground = color;
					HelpIconText.Foreground = color;
					break;
				default:
					OrderIcon.Foreground = color;
					OrderIconText.Foreground = color;
					break;
			}
		}
	}
}
