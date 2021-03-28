using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CPSC_481
{
	/// <summary>
	/// Interaction logic for MainMenu.xaml
	/// </summary>
	public partial class MainMenu : UserControl
	{

		public static OrderHandler orderHandler { get; set; }
		public static FoodMenu foodMenu { get; set; }
		public static DrinkMenu drinkMenu { get; set; }
		public static OrderPage orderPage { get; set; }

		public MainMenu()
		{
			InitializeComponent();
		}

		void Button_Click_0(object sender, RoutedEventArgs e)
		{
			Switcher.Switch(foodMenu);
		}
		
		void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Switcher.Switch(drinkMenu);
		}

		void Button_Click_2(object sender, RoutedEventArgs e)
		{
			Switcher.Switch(orderPage);
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