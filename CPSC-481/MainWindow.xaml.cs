using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
        {
			OrderHandler orderHandler = new OrderHandler();
			InitializeComponent();

			// Passing reference of the orderhandler to the itempage usercontrol
			ItemPage.orderHandler = orderHandler;

			// Set the food menu as default usercontrol
			Switcher.pageSwitcher = this;
			Switcher.Switch(new FoodMenu());

			// Example of a menu item. Used for testing out the itempage.
			List<Option> item1_options = new List<Option>();
			List<Addon> item1_addons = new List<Addon>();

			List<string> size_options = new List<string>();
			size_options.Add("6 oz Sirloin");
			size_options.Add("9 oz Sirloin");
			size_options.Add("6 oz Filet");
			Option size = new Option { Type = "Size", Options = size_options };

			List<string> side_options = new List<string>();
			side_options.Add("Fries");
			side_options.Add("Caesar Salad");
			side_options.Add("Kale Salad");
			Option side = new Option { Type = "Side", Options = side_options };

			item1_options.Add(size);
			item1_options.Add(side);

			Addon addon_1 = new Addon { Name = "Sauteed Mushrooms", Cost = 2.5f };
			Addon addon_2 = new Addon { Name = "Gravy", Cost = 2.0f };
			Addon addon_3 = new Addon { Name = "Steak Sauce", Cost = 2.0f };

			item1_addons.Add(addon_1);
			item1_addons.Add(addon_2);
			item1_addons.Add(addon_3);
			
			MenuItem item1 = new MenuItem {
				Name = "Steak Frites", 
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus integer feugiat scelerisque varius morbi enim. Tristique et egestas quis ipsum suspendisse ultrices gravida.",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/steak_dinner.jpg")),
				Addons = item1_addons, 
				Options = item1_options,
				Cost = 0
			};

			// Set the current item to the one we just made.
			orderHandler.setCurrentItem(item1);
		}

		public void Navigate(UserControl nextPage)
		{
			this.Content = nextPage;
		}
	}
}

// Handels the data moving bewteen the mainwindow and user controls.
public class OrderHandler
{
	List<OrderItem> orderCurrent = new List<OrderItem>();
	List<Order> orderHistory = new List<Order>();

	List<MenuItem> foodMenuItems = new List<MenuItem>();
	List<MenuItem> drinkMenuItems = new List<MenuItem>();

	MenuItem currentItem;

	public void setCurrentItem(MenuItem item)
	{
		currentItem = item;
	}

	public MenuItem getCurrentItem()
	{
		return currentItem;
	}

	public void AddToOrder(OrderItem item)
	{
		orderCurrent.Add(item);
	}
	public void GetTotal() { }
	public void CompleteOrder() { }
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

// class for items being displayed on the menu page
public class MenuItem
{
	public string Name { get; set; }
	public string Description { get; set; }
	public ImageSource ImageSrc { get; set; }
	public List<Addon> Addons { get; set; }
	public List<Option> Options { get; set; }
	public float Cost { get; set; }
}

// class for items being displayed on the order page
public class OrderItem
{
	public string Name { get; set; }
	public List<Addon> Addons { get; set; }
	public string Options { get; set; }
	public string SpecialRequest { get; set; }
	public float Cost { get; set; }
	public int Quantity { get; set; }
}

public class Order
{
	public OrderState State { get; set; }
	public DateTime Time { get; set; }
	public List<OrderItem> Items { get; set; }
}

public class Addon
{
	public string Name { get; set; }
	public float Cost { get; set; }
	public int Quantity { get; set; }
}

public class Option
{
	public string Type { get; set; }
	public List<string> Options { get; set; }
}