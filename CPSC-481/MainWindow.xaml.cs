using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CPSC_481
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		Dictionary<Categories, List<MenuItem>> foodMenuLists = new Dictionary<Categories, List<MenuItem>>();
		Dictionary<Categories, List<MenuItem>> drinkMenuLists = new Dictionary<Categories, List<MenuItem>>();

		public MainWindow()
        {
			OrderHandler orderHandler = new OrderHandler();

			InitializeComponent();

			InitFoodMenu();
			InitDrinkMenu();

			// Passing references
			ItemPage.orderHandler = orderHandler;
			OrderPage.orderHandler = orderHandler;

			FoodMenu.orderHandler = orderHandler;
			orderHandler.foodMenuLists = foodMenuLists;

			DrinkMenu.orderHandler = orderHandler;
			orderHandler.drinkMenuLists = drinkMenuLists;

			FoodMenu foodMenu = new FoodMenu();
			OrderPage orderPage = new OrderPage();
			DrinkMenu drinkMenu = new DrinkMenu();

			MainMenu.foodMenu = foodMenu;
			MainMenu.drinkMenu = drinkMenu;
			MainMenu.orderPage = orderPage;

			// Set the food menu as default usercontrol
			Switcher.pageSwitcher = this;
			Switcher.Switch(foodMenu);
		}

		private void InitFoodMenu()
		{
			InitMainDishList();
			InitAppyDishList();
			InitSideDishList();
			InitSpecialList();
		}
		private void InitDrinkMenu()
		{
			InitBeerList();
			InitWineList();
			InitCocktailsList();
			InitNonAlcoholicList();
		}

		private void InitMainDishList() {
			MenuItem item1 = new MenuItem
			{
				Name = "Steak Frites",
				Description = "We proudly serve Canadian beef aged 45 days for superior tenderness. With French fries and confit garlic butter",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/steak_dinner.jpg")),
				TopPicks = new BitmapImage(new Uri("pack://application:,,,/Resources/images/star.png")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 0.0f),
							("Caesar Salad", 0.0f),
							("Kale Salad", 0.0f) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 0.0f),
							("9 oz Sirloin", 3.0f),
							("6 oz Filet", 9.0f) }) }
					},
				Cost = 27.50f,
				FilterTags = new Dictionary<string, bool>()
					{
						{ "Milk", false},
						{ "Mustard", false}
					}
			};
			MenuItem item2 = new MenuItem
			{
				Name = "Chicken Club",
				Description = "Grilled chicken, crispy bacon, tomatoes, lettuce and mayo on bread of your choice",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/chickenClub.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Extra bacon", 2.5f),
					("Cheese", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 0.0f),
							("Caesar Salad", 0.0f),
							("Kale Salad", 0.0f) }) }
					},
				Cost = 18
			};
			MenuItem item3 = new MenuItem
			{
				Name = "BBQ Ribs",
				Description = "Tender babyback ribs with cornbread",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/bbqRibs.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Extra BBQ Sauce", 1.0f),
					("Extra Cornbread", 2.0f),
					("Poutine", 3.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 0.0f),
							("Caesar Salad", 0.0f),
							("Kale Salad", 0.0f) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("1/3 Rack", 0.0f),
							("Half Rack", 5.0f),
							("Full Rack", 10.0f) }) }
					},
				Cost = 23
			};
			MenuItem item4 = new MenuItem
			{
				Name = "Grilled Salmon Bowl",
				Description = "Grilled salmon, grilled asparagus, jasmine rice, carrots, peas and mushrooms",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/salmon.jpg")),
				TopPicks = new BitmapImage(new Uri("pack://application:,,,/Resources/images/star.png")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Extra Rice", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 0.0f),
							("Caesar Salad", 0.0f),
							("Kale Salad", 0.0f) }) }
					},
				Cost = 25
			};
			MenuItem item5 = new MenuItem
			{
				Name = "Fish n' Chips",
				Description = "North atlantic haddock, handcut fries, tartar sauce",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/fishChips.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Extra tartar sauce", 2.0f),
					("Upgrade frieds to poutine", 3.0f)}),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("3 piece haddock", 0.0f),
							("5 piece haddock", 3.0f) }) }
					},
				Cost = 21
			};
			MenuItem item6 = new MenuItem
			{
				Name = "Bacon Cheddar Burger",
				Description = "Smoked bacon, tomatoes, onion, lettuce, pickles on a toasted bun",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/burger.jpg")),
				TopPicks = new BitmapImage(new Uri("pack://application:,,,/Resources/images/star.png")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Extra Bacon", 2.5f),
					("Upgrade bun to brioche", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 0.0f),
							("Caesar Salad", 0.0f),
							("Kale Salad", 0.0f) }) }
					},
				Cost = 20
			};
			MenuItem item7 = new MenuItem
			{
				Name = "Crispy Falafel Burger",
				Description = "Chickpea falafel, roasted peppers, spicy tzatziki and feta cheese",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/falafelBurger.jpg")),
				TopPicks = new BitmapImage(new Uri("pack://application:,,,/Resources/images/star.png")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Extra feta", 2.0f),
					("Upgrade to chicken", 3.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 0.0f),
							("Caesar Salad", 0.0f),
							("Kale Salad", 0.0f) }) },
						{ "Bread", createNewOptionType("Bread", new List<(string, float)> {
							("Pita", 0.0f),
							("Whole Wheat Pita", 0.0f) }) }
					},
				Cost = 17
			};
			MenuItem item8 = new MenuItem
			{
				Name = "Chicken Fettuccine Alfredo",
				Description = "Seasoned grilled chicken, mushrooms and fettuccine baked in cream sauce",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/chickenPasta.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Asparagus", 3.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 0.0f),
							("Caesar Salad", 0.0f),
							("Kale Salad", 0.0f) }) }
					},
				Cost = 22
			};
			MenuItem item9 = new MenuItem
			{
				Name = "Tofu Zen Bowl",
				Description = "Crispy tofu, edamame beans, cucumber, green cabbage, grape tomatoes, corn, quail eggs and romaine lettuce tossed in ginger sesame sauce",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/tofuBowl.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Grille chicken", 3.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 0.0f),
							("Caesar Salad", 0.0f),
							("Kale Salad", 0.0f) }) }
					},
				Cost = 16
			};

			List<MenuItem> MainList = new List<MenuItem>();
			MainList.Add(item1);
			MainList.Add(item2);
			MainList.Add(item3);
			MainList.Add(item4);
			MainList.Add(item5);
			MainList.Add(item6);
			MainList.Add(item7);
			MainList.Add(item8);
			MainList.Add(item9);

			foodMenuLists[Categories.Main] = MainList;
		}
		private void InitAppyDishList() {
			MenuItem appitem1 = new MenuItem
			{
				Name = "Garlic Fries",
				Description = "Crunchy fries with garlic seasoning",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/fries_landscape.jpg")),
				TopPicks = new BitmapImage(new Uri("pack://application:,,,/Resources/images/star.png")),
				Addons = createNewAddonList(new List<(string, float)> {
				}),
				Options = new Dictionary<string, OptionType>()
				{
				},
				Cost = 10,
				PopularItem = Visibility.Visible
			};
			MenuItem appitem2 = new MenuItem
			{
				Name = "Crispy Brussels Sprouts",
				Description = "Fried brussels sprouts, roasted peppers, onions, garlic, vegan margarine",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/brusselsSprouts.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
				}),
				Options = new Dictionary<string, OptionType>()
				{
				},
				Cost = 14
			};
			MenuItem appitem3 = new MenuItem
			{
				Name = "Chicken Wings",
				Description = "10 piece fried chicken wings of your choice, comes with carrot and celery sticks",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/wings.jpg")),
				TopPicks = new BitmapImage(new Uri("pack://application:,,,/Resources/images/star.png")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Double order", 4.0f),
					("Extra Ranch", 1.0f) }),
				Options = new Dictionary<string, OptionType>()
				{
					{ "Flavour", createNewOptionType("Flavour", new List<(string, float)> {
							("Salt & Pepper", 0.0f),
							("Hot", 0.0f),
							("BBQ", 0.0f),
							("Lemon Pepper", 0.0f),
							("Honey Garlic", 0.0f) })
					}
				},
				Cost = 12
			};
			MenuItem appitem4 = new MenuItem
			{
				Name = "Nachos",
				Description = "Baked nachos topped with jalapenos, tomatoes, onions and aged cheddar. Comes with salsa and sour cream",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/nachos.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Guacamole", 2.5f),
					("Cubed Steak", 4.0f),
					("Shredded Chicken", 3.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
					},
				Cost = 16
			};

			List<MenuItem> AppetizerList = new List<MenuItem>();
			AppetizerList.Add(appitem1);
			AppetizerList.Add(appitem2);
			AppetizerList.Add(appitem3);
			AppetizerList.Add(appitem4);

			foodMenuLists[Categories.Apps] = AppetizerList;
		}
		private void InitSideDishList() {
			MenuItem sideitem1 = new MenuItem
			{
				Name = "Handcut fries",
				Description = "Freshly cut fries, lightly salted and seasoned",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/friesSide.jpg")),
				TopPicks = new BitmapImage(new Uri("pack://application:,,,/Resources/images/star.png")),
				Addons = createNewAddonList(new List<(string, float)> {
				}),
				Options = new Dictionary<string, OptionType>()
				{
				},
				Cost = 12
			};
			MenuItem sideitem2 = new MenuItem
			{
				Name = "Kale Caesar Salad",
				Description = "Fresh kale salad with house caesar dressing",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/kale.jpg")),
				TopPicks = new BitmapImage(new Uri("pack://application:,,,/Resources/images/star.png")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Grilled Chicken", 3.0f) }),
				Options = new Dictionary<string, OptionType>()
				{
				},
				Cost = 6
			};
			MenuItem sideitem3 = new MenuItem
			{
				Name = "Garden Salad",
				Description = "Mixed greens, cucumbers, grape tomatoes, onions and croutons tossed in italian dressing",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/salad.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Grilled Chicken", 3.0f)}),
				Options = new Dictionary<string, OptionType>()
				{
				},
				Cost = 4
			};
			MenuItem sideitem4 = new MenuItem
			{
				Name = "Garlic Bread",
				Description = "Garlic butter spread on freshly toasted bread",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/garlicBread.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
				}),
				Options = new Dictionary<string, OptionType>()
				{
				},
				Cost = 3
			};
			MenuItem sideitem5 = new MenuItem
			{
				Name = "Mashed Potatoes",
				Description = "Yukon gold potatoes, mashed with sour cream and house seasoning",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/mashedPotatoes.jpg")),
				TopPicks = new BitmapImage(new Uri("pack://application:,,,/Resources/images/star.png")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Gravy", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
				{
				},
				Cost = 5
			};
			MenuItem sideitem6 = new MenuItem
			{
				Name = "Ceasar Salad",
				Description = "Crunchy romaine lettuce with house caesar and croutons",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/caesar.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Grilled Chicken", 3.0f) }),
				Options = new Dictionary<string, OptionType>()
				{
				},
				Cost = 5
			};
			MenuItem sideitem7 = new MenuItem
			{
				Name = "Soup of the Day",
				Description = "Made with the chef's choice of fresh ingredients, ask your server for which soup is served today",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/soup.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Toasted bun", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
				{
				},
				Cost = 4
			};

			List<MenuItem> SidesList = new List<MenuItem>();
			SidesList.Add(sideitem1);
			SidesList.Add(sideitem2);
			SidesList.Add(sideitem3);
			SidesList.Add(sideitem4);
			SidesList.Add(sideitem5);
			SidesList.Add(sideitem6);
			SidesList.Add(sideitem7);

			foodMenuLists[Categories.Side] = SidesList;
		}
		private void InitSpecialList() {
			MenuItem specialitem1 = new MenuItem
			{
				Name = "Wings Special",
				Description = "Crispy fried wings, tossed in sauce of your choice",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/wings_special.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Double order", 4.0f),
					("Extra Ranch", 1.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Flavour", createNewOptionType("Flavour", new List<(string, float)> {
							("Salt & Pepper", 0.0f),
							("Hot", 0.0f),
							("BBQ", 0.0f),
							("Lemon Pepper", 0.0f),
							("Honey Garlic", 0.0f) }) }
					},
				Cost = 8,
				TextFormatNormal = Visibility.Hidden,
				TextFormatSpecial = Visibility.Visible
			};
			MenuItem specialitem2 = new MenuItem
			{
				Name = "Draft Beer",
				Description = "Choose from our premium selection of local draft beer",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/beer.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
				}),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Brand", createNewOptionType("Brand", new List<(string, float)> {
							("Bud Light", 0.0f),
							("Miller Lite", 0.0f),
							("Steam Whilstle Pilsner", 0.0f),
							("Kokanee", 0.0f),
							("Molson Canadian", 0.0f) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("16 oz", 0),
							("20 oz", 2) }) }
					},
				Cost = 5,
				TextFormatNormal = Visibility.Hidden,
				TextFormatSpecial = Visibility.Visible
			};
			MenuItem specialitem3 = new MenuItem
			{
				Name = "Sushi Rolls",
				Description = "Crunchy seaweed, warm sushi rice with your choice of cucmber, spicy tuna, salmon or california roll",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/sushi_crop.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
				}),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
							("California", 0.0f),
							("Philadelphia", 0.0f),
							("Spicy Tuna", 2),
							("Spicy Salmon", 2) }) }
					},
				Cost = 10,
				TextFormatNormal = Visibility.Hidden,
				TextFormatSpecial = Visibility.Visible
			};
			MenuItem specialitem4 = new MenuItem
			{
				Name = "House Wine",
				Description = "Choose from our large selection of house wines",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/wine.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
				}),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
							("House Red", 0.0f),
							("House White", 0.0f) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz", 0.0f),
							("9 oz", 3.0f) }) }
					},
				Cost = 6,
				TextFormatNormal = Visibility.Hidden,
				TextFormatSpecial = Visibility.Visible
			};

			List<MenuItem> SpecialsList = new List<MenuItem>();
			SpecialsList.Add(specialitem1);
			SpecialsList.Add(specialitem2);
			SpecialsList.Add(specialitem3);
			SpecialsList.Add(specialitem4);

			foodMenuLists[Categories.Special] = SpecialsList;
		}

		private void InitBeerList()
		{
			// beer menu
			MenuItem beer1 = new MenuItem
			{
				Name = "Misty Mountain Hazy IPA",
				Description = "This lagered blonde was made to be a favourite for as long as the trail has been. Light in body and colour, with hints of stone fruit and grain.",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Beers/beerLandscape.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {}),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("14 oz.", 0.0f),
							("16 oz.", 2.0f),
							("20 oz.", 3.50f) }) }
					},
				Cost = 8.0f
			};
			MenuItem beer2 = new MenuItem
			{
				Name = "Seasonal Draft Beer",
				Description = "Choose from our premium selection of seasonal beer",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Beers/seasonalBeers.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
								("Raspberry Ale", 0.0f),
								("Mango Passionfruit Sour", 0.0f),
								("Tropical IPA", 0.0f),
								("Vanilla Stout", 0.0f) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
								("16 oz", 0.0f),
								("20 oz", 2.0f) }) }
					},
				Cost = 7
			};
			MenuItem beer3 = new MenuItem
			{
				Name = "Imported Draft Beer",
				Description = "Fancy import beer from faraway places",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Beers/importedBeers.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
							("Piccolo 187.5ml", 0.0f),
							("Demi 375ml", 0.0f),
							("Jennie 500ml", 0.0f),
							("Standard 750ml", 0.0f),
							("Liter 1000ml", 0.0f) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
								("16 oz", 0.0f),
								("20 oz", 2.0f) }) }
					},
				Cost = 9
			};
			MenuItem beer4 = new MenuItem
			{
				Name = "Draft Beer",
				Description = "The classics you know and love",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Beers/genericBeers.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
							("Bud Light", 0.0f),
							("Miller Lite", 0.0f),
							("Steam Whilstle Pilsner", 0.0f),
							("Kokanee", 0.0f),
							("Molson Canadian", 0.0f) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
								("16 oz", 0.0f),
								("20 oz", 2.0f) }) }
					},
				Cost = 5
			};

			List<MenuItem> BeerList = new List<MenuItem>();
			BeerList.Add(beer1);
			BeerList.Add(beer2);
			BeerList.Add(beer3);
			BeerList.Add(beer4);

			drinkMenuLists[Categories.Beer] = BeerList;
		}
		private void InitWineList()
		{
			MenuItem Wine1 = new MenuItem
			{
				Name = "White Wine",
				Description = "Choose from our selection of white wines",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Wines/whiteWine.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
							("Sawmill Creek Pinot Grigio", 0.0f),
							("Far Niente Chardonnay", 1.0f),
							("Abbazia di Novacella Pinot Grigio", 2.0f),
							("Crestwood Barrel Riesling", 3.0f),
							("Trois Noix Sauvignon Blanc", 4.0f) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz", 0.0f),
							("9 oz", 3.0f),
							("Bottle", 30.0f) }) }
					},
				Cost = 8
			};
			MenuItem Wine2 = new MenuItem
			{
				Name = "Red Wine",
				Description = "Choose from our selection of red wines",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Wines/redWine.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
							("Bonterra Merlot", 0.0f),
							("La Vieille Ferme Red", 1.0f),
							("Brady Vineyard Zinfandel", 2.0f),
							("Crios Malbec", 3.0f),
							("San Simeon Reserve Pinot Noir", 4.0f) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz", 0.0f),
							("9 oz", 3.0f),
							("Bottle", 30.0f) }) }
					},
				Cost = 8
			};
			MenuItem Wine3 = new MenuItem
			{
				Name = "Sparkling Wine",
				Description = "Premium sparkling wines imported from Italy, France and Spain",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Wines/champagne.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
							("Villa Marchesi Prosecco", 0.0f),
							("Saracco Moscato d'Asti", 2.0f),
							("Elyssia Pinot Noir Brut Cava", 2.0f),
							("Raymond Henriot Champagne", 3.0f),
							("Agusti Torello Mata Reserva", 3.0f) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("5 oz", 0.0f),
							("Bottle", 40.0f) }) }
					},
				Cost = 10
			};
			MenuItem Wine4 = new MenuItem
			{
				Name = "Other Wines",
				Description = "Browse through some of our unique wines",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Wines/otherWines.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
							("Oyster Bay Rose", 0.0f),
							("Hecht & Bannier Rose", 2.0f),
							("Borges Ruby Port Reserve", 3.0f),
							("Lakeview Cellars Vidal Icewine", 4.0f),
							("Hidalgo Faraon Oloroso Sherry", 5.0f) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz", 0.0f),
							("9 oz", 3.0f),
							("Bottle", 30.0f) }) }
					},
				Cost = 9
			};

			List<MenuItem> WineList = new List<MenuItem>();
			WineList.Add(Wine1);
			WineList.Add(Wine2);
			WineList.Add(Wine3);
			WineList.Add(Wine4);

			drinkMenuLists[Categories.Wine] = WineList;
		}
		private void InitCocktailsList()
		{
			MenuItem drink1 = new MenuItem
			{
				Name = "Martini",
				Description = "Chilled gin and dry vermouth, garnished with an olive",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Cocktails/martini.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
					},
				Cost = 13
			};
			MenuItem drink2 = new MenuItem
			{
				Name = "Manhattan",
				Description = "Bourbon, sweet vermouth and orange bitters",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Cocktails/manhattan.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
					},
				Cost = 15
			};
			MenuItem drink3 = new MenuItem
			{
				Name = "Bloody Mary",
				Description = "Vodka, tomato juice and spices, garnished with celery",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Cocktails/bloodyMary.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
					},
				Cost = 15
			};
			MenuItem drink4 = new MenuItem
			{
				Name = "Specials",
				Description = "Try something unique",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Cocktails/cocktails.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
							("Cosmopolitan", 0.0f),
							("Amaretto Sour", 0.0f),
							("Pina Colada", 2.0f),
							("Bellini", 2.0f),
							("Moscow Mule", 2.0f) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("1 oz", 0.0f),
							("2 oz", 3.0f)}) }
					},
				Cost = 12
			};

			List<MenuItem> CocktailList = new List<MenuItem>();
			CocktailList.Add(drink1);
			CocktailList.Add(drink2);
			CocktailList.Add(drink3);
			CocktailList.Add(drink4);

			drinkMenuLists[Categories.Cocktails] = CocktailList;
		}
		private void InitNonAlcoholicList()
		{
			MenuItem drink1 = new MenuItem
			{
				Name = "Soft Drinks",
				Description = "Classic sodas",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/NonAlcoholic/sodas.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
				}),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
							("Coke", 0.0f),
							("Sprite", 0.0f),
							("Gingerale", 0.0f),
							("Fanta", 0.0f),
							("Dr. Pepper", 0.0f) }) }
					},
				Cost = 3
			};
			MenuItem drink2 = new MenuItem
			{
				Name = "Craft Sodas",
				Description = "Craft sodas with unique flavours",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/NonAlcoholic/craftSodas.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
				}),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
							("Black Cherry Cola", 0.0f),
							("Ginger beer", 0.0f),
							("Orange Cream Soda", 0.0f),
							("Rootbeer", 0.0f),
							("Saskatoon Lemonade", 0.0f) }) }
					},
				Cost = 5
			};
			MenuItem drink3 = new MenuItem
			{
				Name = "Shirley Temple",
				Description = "Gingerale, orange juice and a splash of grenadine",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/NonAlcoholic/shirleytemple.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
				}),
				Options = new Dictionary<string, OptionType>()
					{
					},
				Cost = 6
			};
			MenuItem drink4 = new MenuItem
			{
				Name = "Teas",
				Description = "Delicious teas sourced from organic farms",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/NonAlcoholic/teas.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
				}),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Selection", createNewOptionType("Selection", new List<(string, float)> {
							("Green tea", 0.0f),
							("Black tea", 0.0f),
							("Chamomile tea", 0.0f),
							("Peppermint tea", 0.0f),
							("Roiboos tea", 0.0f) }) }
					},
				Cost = 3
			};

			List<MenuItem> NonAlcoholicList = new List<MenuItem>();
			NonAlcoholicList.Add(drink1);
			NonAlcoholicList.Add(drink2);
			NonAlcoholicList.Add(drink3);
			NonAlcoholicList.Add(drink4);

			drinkMenuLists[Categories.NonAlch] = NonAlcoholicList;
		}

		private OptionType createNewOptionType(string typeName, List<(string, float)> options) {
			List<Option> optionList = new List<Option>();
			Guid options_id = Guid.NewGuid();
			foreach (var o in options) {
				optionList.Add(new Option { ID = options_id, Name = o.Item1, Cost = o.Item2 });
			}
			OptionType optionType = new OptionType { Type = typeName, Options = optionList, Selected = false, Color = Colors.Black };
			return optionType;
		}
		private List<Addon> createNewAddonList(List<(string, float)> addons)
		{
			List<Addon> addonList = new List<Addon>();
			Guid options_id = Guid.NewGuid();
			foreach (var a in addons)
			{
				addonList.Add(new Addon { Name = a.Item1, Cost = a.Item2 });
			}
			return addonList;
		}

		public void Navigate(UserControl nextPage)
		{
			this.Content = nextPage;
		}
	}
}

public enum OrderState
{
	Delivered,
	Processing
}
public enum MenuButton
{
	Food,
	Drink,
	Order,
	Help
}
public enum Categories
{
	Main,
	Apps,
	Side,
	Special,
	Beer,
	Wine,
	Cocktails,
	NonAlch
}
public enum FilterType { 
	Egg,
	Milk,
	Mustard,
	Peanuts,
	ShellFish,
	Fish,
	Sesame,
	Soy,
	Sulphites,
	TreeNuts,
	Vegan,
	Gluten,
	Dairy,
	Hala,
	Vegetarian,
	Paleo
}

// Handels the data moving bewteen the mainwindow and user controls.
public class OrderHandler
{
	public Dictionary<Guid, OrderItem> orderCurrent { get; set; }
	public List<Order> orderHistory { get; set; }

	public Dictionary<Categories, List<MenuItem>> foodMenuLists { get; set; }
	public Dictionary<Categories, List<MenuItem>> drinkMenuLists { get; set; }

	public Categories currentPage { get; set; }

	public Dictionary<Categories, List<MenuItem>> foodMenuLists_filtered { get; set; } = new Dictionary<Categories, List<MenuItem>>();
	public Dictionary<Categories, List<MenuItem>> drinkMenuLists_filtered { get; set; } = new Dictionary<Categories, List<MenuItem>>();

	public Dictionary<string, bool> filterList = new Dictionary<string, bool>() {
		{"Milk", false},
		{"Mustard", false},
		{"Peanuts", false},
		{"Shell fish", false},
		{"Egg", false},
		{"Fish", false},
		{"Sesame seeds", false},
		{"Soy", false},
		{"Sulphites", false},
	};

	public Dictionary<string, bool> dietFilterList = new Dictionary<string, bool>() {
		{"Vegan", false},
		{"Gluten free", false},
		{"Dairy free", false},
		{"Hala", false},
		{"Vegetarian", false},
		{"Paleo", false}
	};

	public MenuItem currentItem { get; set; }

	public OrderHandler() {
		orderCurrent = new Dictionary<Guid, OrderItem>();
		orderHistory = new List<Order>();
	}

	public void AddToOrder(OrderItem item)
	{
		orderCurrent[item.ID] = item;
	}
	public void addToOrderHistory(Dictionary<Guid, OrderItem> currentOrder)
	{
		List<OrderItem> _orderitems = currentOrder.Values.ToList();
		Order order = new Order { State = OrderState.Processing, Time = DateTime.Now, Items = _orderitems};
		orderHistory.Add(order);
	}

}

// class for items being displayed on the menu page
public class MenuItem : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	protected void SetField<T>(ref T field, T value, string propertyName)
	{
		if (!EqualityComparer<T>.Default.Equals(field, value))
		{
			field = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public string Name { get; set; }
	public string Description { get; set; }
	public ImageSource ImageSrc { get; set; }
	public List<Addon> Addons { get; set; }
	public Dictionary<string, OptionType> Options { get; set; }
	public Visibility TextFormatNormal { get; set; } = Visibility.Visible;
	public Visibility TextFormatSpecial { get; set; } = Visibility.Hidden;
	public Visibility PopularItem { get; set; } = Visibility.Hidden;
	public Dictionary<string, bool> FilterTags { get; set; } = new Dictionary<string, bool>();
	public ImageSource TopPicks { get; set; }

float _Cost;
	public float Cost
	{
		get => _Cost;
		set => SetField(ref _Cost, value, nameof(Cost));
	}
}

// public class to keep a list of all food menu items
// work-around for passing data to the FoodMenu
public class MenuLists
{
	public List<MenuItem> AppetizerList { get; set; }
	public List<MenuItem> MainList { get; set; }
	public List<MenuItem> SideList { get; set; }
	public List<MenuItem> SpecialsList { get; set; }
}

public class Order
{
	public OrderState State { get; set; }
	public DateTime Time { get; set; }
	public List<OrderItem> Items { get; set; }
}

// class for items being displayed on the order page
public class OrderItem
{
	public Guid ID { get; set; }
	public string Name { get; set; }
	public List<Addon> Addons { get; set; }
	public string Options { get; set; }
	public string SpecialRequest { get; set; }
	public float Cost { get; set; }
	public int Quantity { get; set; }

	public OrderItem Copy()
	{
		OrderItem other = (OrderItem)this.MemberwiseClone();
		other.ID = Guid.NewGuid();
		other.Name = String.Copy(Name);
		other.Addons = Addons;
		other.SpecialRequest = String.Copy(SpecialRequest);
		other.Cost = Cost;
		other.Quantity = Quantity;
		return other;
	}
}

public class Addon : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	protected void SetField<T>(ref T field, T value, string propertyName)
	{
		if (!EqualityComparer<T>.Default.Equals(field, value))
		{
			field = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public string Name { get; set; }

	float _Cost;
	public float Cost
	{
		get => _Cost;
		set => SetField(ref _Cost, value, nameof(Cost));
	}

	int _Quantity;
	public int Quantity
	{
		get => _Quantity;
		set => SetField(ref _Quantity, value, nameof(Quantity));
	}

	public Addon Copy()
	{
		Addon other = (Addon)this.MemberwiseClone();
		other.Name = String.Copy(Name);
		other.Cost = Cost;
		other.Quantity = Quantity;
		return other;
	}
}

public class OptionType : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	protected void SetField<T>(ref T field, T value, string propertyName)
	{
		if (!EqualityComparer<T>.Default.Equals(field, value))
		{
			field = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public string Type { get; set; }
	public List<Option> Options { get; set; }
	public bool Selected { get; set; }

	Color _Color;
	public Color Color
	{
		get => _Color;
		set => SetField(ref _Color, value, nameof(Color));
	}
}

public class Option
{
	public Guid ID { get; set; }
	public string Name { get; set; }
	public float Cost { get; set; }
}