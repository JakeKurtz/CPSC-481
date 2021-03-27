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
		List<MenuItem> BeerList = new List<MenuItem>();

		public DrinkMenu()
		{
			InitializeComponent();
			initializeDrinkMenu();
			// pass the appetizer list into the constructor of the AppetizerPage
			Drinks.Content = new BeerPage(BeerList);
			drinkMenuTitle.Text = "Beer";
			btnSelected(0);
		}

		// button click methods
		private void beerClick(object sender, RoutedEventArgs e)
		{
			Drinks.Content = new BeerPage(BeerList);
			drinkMenuTitle.Text = "Beer";
			btnSelected(0);
		}
		private void wineClick(object sender, RoutedEventArgs e)
		{
			Trace.WriteLine("Wine button clicked");
			drinkMenuTitle.Text = "Wine";
			btnSelected(1);
		}

		private void cocktailClick(object sender, RoutedEventArgs e)
		{
			Trace.WriteLine("Cocktail button clicked");
			drinkMenuTitle.Text = "Cocktails";
			btnSelected(2);
		}

		private void nonAlcoholClick(object sender, RoutedEventArgs e)
		{
			Trace.WriteLine("Non alcoholic button clicked");
			drinkMenuTitle.Text = "Non-Alcoholic";
			btnSelected(3);
		}

		// switches the background colour of buttons based on the menu that's selected
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

		// create lists of menu item for each item category
		private void initializeDrinkMenu()
		{
			// copied from Main Window file, to use to test
			Dictionary<string, OptionType> item1_options = new Dictionary<string, OptionType>();
			List<Addon> item1_addons = new List<Addon>();

			List<Option> size_options = new List<Option>();
			Guid size_options_id = Guid.NewGuid();
			size_options.Add(new Option { ID = size_options_id, Name = "12 oz", Cost = 1 });
			size_options.Add(new Option { ID = size_options_id, Name = "16 oz Sirloin", Cost = 1 });
			size_options.Add(new Option { ID = size_options_id, Name = "20 oz Filet", Cost = 1 });
			OptionType size = new OptionType { Type = "Size", Options = size_options, Selected = false, Color = Colors.Black };

			List<Option> side_options = new List<Option>();
			Guid side_options_id = Guid.NewGuid();
			side_options.Add(new Option { ID = side_options_id, Name = "Fries", Cost = 1 });
			side_options.Add(new Option { ID = side_options_id, Name = "Caesar Salad", Cost = 1 });
			side_options.Add(new Option { ID = side_options_id, Name = "Kale Salad", Cost = 1 });
			OptionType side = new OptionType { Type = "Side", Options = side_options, Selected = false, Color = Colors.Black };

			item1_options[size.Type] = size;
			item1_options[side.Type] = side;

			Addon addon_1 = new Addon { Name = "None", Cost = 0.0f };

			item1_addons.Add(addon_1);

			// beer menu
			MenuItem beer1 = new MenuItem
			{
				Name = "Local Beer",
				Description = "Choose from our premium selection of local draft beer",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/beerLandscape.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 6
			};

			MenuItem beer2 = new MenuItem
			{
				Name = "Seasonal Beer",
				Description = "Choose from our premium selection of seasonal beer",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/beerLandscape.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 7
			};

			MenuItem beer3 = new MenuItem
			{
				Name = "Import Beer",
				Description = "Fancy import beer from faraway places",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/beerLandscape.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 100
			};

			MenuItem beer4 = new MenuItem
			{
				Name = "Generic Beer",
				Description = "Tastes like beer",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/beerLandscape.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 5
			};

			BeerList.Add(beer1);
			BeerList.Add(beer2);
			BeerList.Add(beer3);
			BeerList.Add(beer4);
		}
	}
}
