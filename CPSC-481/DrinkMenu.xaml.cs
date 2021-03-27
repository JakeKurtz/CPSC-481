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
		List<MenuItem> WineList = new List<MenuItem>();
		List<MenuItem> CocktailList = new List<MenuItem>();
		List<MenuItem> NonAlcoholicList = new List<MenuItem>();

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
			Drinks.Content = new WinePage(WineList);
			drinkMenuTitle.Text = "Wine";
			btnSelected(1);
		}

		private void cocktailClick(object sender, RoutedEventArgs e)
		{
			Drinks.Content = new CocktailPage(CocktailList);
			drinkMenuTitle.Text = "Cocktails";
			btnSelected(2);
		}

		private void nonAlcoholClick(object sender, RoutedEventArgs e)
		{
			Drinks.Content = new NonAlcoholicPage(NonAlcoholicList);
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

			List<Option> drink_options = new List<Option>();
			Guid drink_options_id = Guid.NewGuid();
			drink_options.Add(new Option { ID = drink_options_id, Name = "Buena Vista", Cost = 25 });
			drink_options.Add(new Option { ID = drink_options_id, Name = "Leyeth Estate", Cost = 35 });
			drink_options.Add(new Option { ID = drink_options_id, Name = "Raymond Vineyards", Cost = 15 });
			OptionType drink = new OptionType { Type = "Drink", Options = drink_options, Selected = false, Color = Colors.Black };

			List<Option> size_options = new List<Option>();
			Guid size_options_id = Guid.NewGuid();
			size_options.Add(new Option { ID = size_options_id, Name = "Piccolo 187.5ml", Cost = 5 });
			size_options.Add(new Option { ID = size_options_id, Name = "Demi 375ml", Cost = 10 });
			size_options.Add(new Option { ID = size_options_id, Name = "Jennie 500ml", Cost = 15 });
			size_options.Add(new Option { ID = size_options_id, Name = "Standard 750ml", Cost = 20 });
			size_options.Add(new Option { ID = size_options_id, Name = "Liter 1000ml", Cost = 25 });
			OptionType size = new OptionType { Type = "Size", Options = size_options, Selected = false, Color = Colors.Black };

			List<Option> side_options = new List<Option>();
			Guid side_options_id = Guid.NewGuid();
			side_options.Add(new Option { ID = side_options_id, Name = "None", Cost = 0 });
			side_options.Add(new Option { ID = side_options_id, Name = "Pickle", Cost = 1 });
			side_options.Add(new Option { ID = side_options_id, Name = "Olives", Cost = 1 });
			side_options.Add(new Option { ID = side_options_id, Name = "Cheese platter", Cost = 10 });
			side_options.Add(new Option { ID = side_options_id, Name = "Bread platter", Cost = 10 });
			side_options.Add(new Option { ID = side_options_id, Name = "Meat platter", Cost = 10 });
			side_options.Add(new Option { ID = side_options_id, Name = "Charcuterie board", Cost = 30 });
			OptionType side = new OptionType { Type = "Side", Options = side_options, Selected = false, Color = Colors.Black };

			item1_options[drink.Type] = drink;
			item1_options[size.Type] = size;
			item1_options[side.Type] = side;

			Addon addon_1 = new Addon { Name = "None", Cost = 0.0f };

			item1_addons.Add(addon_1);

			InitializeBeerList(item1_addons, item1_options);
			InitializeWineList(item1_addons, item1_options);
			InitializeCocktailsList(item1_addons, item1_options);
			InitializeNonAlcoholicList(item1_addons, item1_options);
		}

		private void InitializeBeerList(List<Addon> item1_addons, Dictionary<string, OptionType> item1_options)
		{
			// beer menu
			MenuItem beer1 = new MenuItem
			{
				Name = "Local Beer",
				Description = "Choose from our premium selection of local draft beer",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Beers/beerLandscape.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 6
			};

			MenuItem beer2 = new MenuItem
			{
				Name = "Seasonal Beer",
				Description = "Choose from our premium selection of seasonal beer",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Beers/seasonalBeers.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 7
			};

			MenuItem beer3 = new MenuItem
			{
				Name = "Import Beer",
				Description = "Fancy import beer from faraway places",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Beers/importedBeers.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 9
			};

			MenuItem beer4 = new MenuItem
			{
				Name = "Generic Beer",
				Description = "The classics you know and love",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Beers/genericBeers.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 5
			};

			BeerList.Add(beer1);
			BeerList.Add(beer2);
			BeerList.Add(beer3);
			BeerList.Add(beer4);
		}

		private void InitializeWineList(List<Addon> item1_addons, Dictionary<string, OptionType> item1_options)
		{
			MenuItem Wine1 = new MenuItem
			{
				Name = "White wine",
				Description = "Choose from our selection of white wines",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Wines/whiteWine.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 25
			};

			MenuItem Wine2 = new MenuItem
			{
				Name = "Red wine",
				Description = "Choose from our selection of red wines",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Wines/redWine.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 25
			};

			MenuItem Wine3 = new MenuItem
			{
				Name = "Champagne",
				Description = "Premium champagne imported from Italy",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Wines/champagne.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 95
			};

			MenuItem Wine4 = new MenuItem
			{
				Name = "Other wines",
				Description = "Browse through some unique wines",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Wines/otherWines.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 15
			};

			WineList.Add(Wine1);
			WineList.Add(Wine2);
			WineList.Add(Wine3);
			WineList.Add(Wine4);
		}

		private void InitializeCocktailsList(List<Addon> item1_addons, Dictionary<string, OptionType> item1_options)
		{
			MenuItem drink1 = new MenuItem
			{
				Name = "Martini",
				Description = "A classic, sour martini",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Cocktails/martini.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 7
			};

			MenuItem drink2 = new MenuItem
			{
				Name = "Manhattan",
				Description = "A classic manhattan",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Cocktails/manhattan.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 7
			};

			MenuItem drink3 = new MenuItem
			{
				Name = "Bloody Mary",
				Description = "Clamato juice and alcohol",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Cocktails/bloodyMary.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 15
			};

			MenuItem drink4 = new MenuItem
			{
				Name = "Specials",
				Description = "Try something unique",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Cocktails/cocktails.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 15
			};

			CocktailList.Add(drink1);
			CocktailList.Add(drink2);
			CocktailList.Add(drink3);
			CocktailList.Add(drink4);
		}

		private void InitializeNonAlcoholicList(List<Addon> item1_addons, Dictionary<string, OptionType> item1_options)
		{
			MenuItem drink1 = new MenuItem
			{
				Name = "Generic Soda",
				Description = "Classic sodas",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/NonAlcoholic/sodas.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 2
			};

			MenuItem drink2 = new MenuItem
			{
				Name = "Craft sodas",
				Description = "Craft sodas with unique flavours",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/NonAlcoholic/craftSodas.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 5
			};

			MenuItem drink3 = new MenuItem
			{
				Name = "Shirley temple",
				Description = "Non-alcoholic cocktail",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/NonAlcoholic/shirleytemple.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 6
			};

			MenuItem drink4 = new MenuItem
			{
				Name = "Teas",
				Description = "Drink some calming, delicious teas",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/NonAlcoholic/teas.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 7
			};

			NonAlcoholicList.Add(drink1);
			NonAlcoholicList.Add(drink2);
			NonAlcoholicList.Add(drink3);
			NonAlcoholicList.Add(drink4);
		}

		
	}
}
