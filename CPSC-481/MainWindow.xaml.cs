﻿using System;
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
			FoodMenu.menuLists = foodMenuLists;

			DrinkMenu.orderHandler = orderHandler;
			DrinkMenu.menuLists = drinkMenuLists;

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
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus integer feugiat scelerisque varius morbi enim. Tristique et egestas quis ipsum suspendisse ultrices gravida.",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/steak_dinner.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 24
			};
			MenuItem item2 = new MenuItem
			{
				Name = "Chicken Club",
				Description = "Grilled chicken, crispy bacon, tomatoes, lettuce and mayo on bread of your choice",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/chickenClub.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 18
			};
			MenuItem item3 = new MenuItem
			{
				Name = "BBQ Ribs",
				Description = "Tender babyback ribs, handcut fries and cornbread",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/bbqRibs.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 28
			};
			MenuItem item4 = new MenuItem
			{
				Name = "Grilled Salmon Bowl",
				Description = "Grilled salmon, grilled asparagus, jasmine rice, carrots, peas and mushrooms",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/salmon.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 25
			};
			MenuItem item5 = new MenuItem
			{
				Name = "Fish n' Chips",
				Description = "North atlantic haddock, handcut fries, tartar sauce",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/fishChips.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 21
			};
			MenuItem item6 = new MenuItem
			{
				Name = "Bacon Cheddar Burger",
				Description = "Smoked bacon, tomatoes, onion, lettuce, pickles on a toasted bun",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/burger.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 20
			};
			MenuItem item7 = new MenuItem
			{
				Name = "Crispy Falafel Burger",
				Description = "Chickpea falafel, roasted peppers, spicy tzatziki and feta cheese on bread of your choice",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/falafelBurger.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
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
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
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
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
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
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 10
			};
			MenuItem appitem2 = new MenuItem
			{
				Name = "Crispy Brussels Sprouts",
				Description = "Fried brussels sprouts, roasted peppers, onions, garlic, vegan margarine",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/brusselsSprouts.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 14
			};
			MenuItem appitem3 = new MenuItem
			{
				Name = "Chicken Wings",
				Description = "Fried chicken wings of your choice, comes with carrot and celery sticks",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/wings.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 12
			};
			MenuItem appitem4 = new MenuItem
			{
				Name = "Nachos",
				Description = "Baked nachos topped with jalapenos, tomatoes, onions and aged cheddar. Comes with salsa and sour cream",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/nachos.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
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
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 12
			};
			MenuItem sideitem2 = new MenuItem
			{
				Name = "Kale Caesar Salad",
				Description = "Fresh kale salad with house caesar dressing",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/kale.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 6
			};
			MenuItem sideitem3 = new MenuItem
			{
				Name = "Garden Salad",
				Description = "Mixed greens, cucumbers, grape tomatoes, onions and croutons tossed in italian dressing",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/salad.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 4
			};
			MenuItem sideitem4 = new MenuItem
			{
				Name = "Garlic Bread",
				Description = "Garlic butter spread on freshly toasted bread",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/garlicBread.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 3
			};
			MenuItem sideitem5 = new MenuItem
			{
				Name = "Mashed Potatoes",
				Description = "Yukon gold potatoes, mashed with sour cream and house seasoning",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/mashedPotatoes.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 5
			};
			MenuItem sideitem6 = new MenuItem
			{
				Name = "Ceasar Salad",
				Description = "Crunchy romaine lettuce with house caesar and croutons",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/caesar.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 5
			};
			MenuItem sideitem7 = new MenuItem
			{
				Name = "Soup of the Day",
				Description = "Made with the chef's choice of fresh ingredients, ask your server for which soup is served today",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/soup.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
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
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
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
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
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
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
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
					("Sauteed Mushrooms", 2.5f),
					("Gravy", 2.0f),
					("Steak Sauce", 2.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Side", createNewOptionType("Side", new List<(string, float)> {
							("Fries", 1),
							("Caesar Salad", 1),
							("Kale Salad", 1) }) },
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("6 oz Sirloin", 1),
							("9 oz Sirloin", 1),
							("6 oz Filet", 1) }) }
					},
				Cost = 5,
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
				Name = "Local Beer",
				Description = "Choose from our premium selection of local draft beer",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Beers/beerLandscape.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 6
			};
			MenuItem beer2 = new MenuItem
			{
				Name = "Seasonal Beer",
				Description = "Choose from our premium selection of seasonal beer",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Beers/seasonalBeers.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 7
			};
			MenuItem beer3 = new MenuItem
			{
				Name = "Import Beer",
				Description = "Fancy import beer from faraway places",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Beers/importedBeers.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 9
			};
			MenuItem beer4 = new MenuItem
			{
				Name = "Generic Beer",
				Description = "The classics you know and love",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Beers/genericBeers.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
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
				Name = "White wine",
				Description = "Choose from our selection of white wines",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Wines/whiteWine.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 25
			};
			MenuItem Wine2 = new MenuItem
			{
				Name = "Red wine",
				Description = "Choose from our selection of red wines",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Wines/redWine.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 25
			};
			MenuItem Wine3 = new MenuItem
			{
				Name = "Champagne",
				Description = "Premium champagne imported from Italy",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Wines/champagne.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 95
			};
			MenuItem Wine4 = new MenuItem
			{
				Name = "Other wines",
				Description = "Browse through some unique wines",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Wines/otherWines.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 15
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
				Description = "A classic, sour martini",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Cocktails/martini.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 7
			};
			MenuItem drink2 = new MenuItem
			{
				Name = "Manhattan",
				Description = "A classic manhattan",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Cocktails/manhattan.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 7
			};
			MenuItem drink3 = new MenuItem
			{
				Name = "Bloody Mary",
				Description = "Clamato juice and alcohol",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/Cocktails/bloodyMary.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
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
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 15
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
				Name = "Generic Soda",
				Description = "Classic sodas",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/NonAlcoholic/sodas.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 2
			};
			MenuItem drink2 = new MenuItem
			{
				Name = "Craft sodas",
				Description = "Craft sodas with unique flavours",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/NonAlcoholic/craftSodas.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 5
			};
			MenuItem drink3 = new MenuItem
			{
				Name = "Shirley temple",
				Description = "Non-alcoholic cocktail",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/NonAlcoholic/shirleytemple.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 6
			};
			MenuItem drink4 = new MenuItem
			{
				Name = "Teas",
				Description = "Drink some calming, delicious teas",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/drink_items/NonAlcoholic/teas.jpg")),
				Addons = createNewAddonList(new List<(string, float)> {
					("Pickles", 5.0f),
					("Olives", 5.0f),
					("Cheese platter", 25.0f) }),
				Options = new Dictionary<string, OptionType>()
					{
						{ "Size", createNewOptionType("Size", new List<(string, float)> {
							("Piccolo 187.5ml", 5),
							("Demi 375ml", 10),
							("Jennie 500ml", 15),
							("Standard 750ml", 20),
							("Liter 1000ml", 25) }) }
					},
				Cost = 7
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
	Side,
	Apps,
	Special,
	Beer,
	Wine,
	Cocktails,
	NonAlch
}

// Handels the data moving bewteen the mainwindow and user controls.
public class OrderHandler
{
	public Dictionary<Guid, OrderItem> orderCurrent { get; set; }
	public List<Order> orderHistory { get; set; }

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
		other.ID = ID;
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