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
using System.Diagnostics;

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
			MenuLists menuLists = new MenuLists();

			InitializeComponent();

			// Passing reference of the orderhandler to the itempage usercontrol
			ItemPage.orderHandler = orderHandler;
			OrderPage.orderHandler = orderHandler;

			// Pass reference of the menu lists to the food menu page
			FoodMenu.menuLists = menuLists;

			// Set the food menu as default usercontrol
			Switcher.pageSwitcher = this;
			Switcher.Switch(new WelcomePage());

			// Example of a menu item. Used for testing out the itempage.
			Dictionary<string, OptionType> item1_options = new Dictionary<string, OptionType>();
			List<Addon> item1_addons = new List<Addon>();

			List<Option> size_options = new List<Option>();
			Guid size_options_id = Guid.NewGuid();
			size_options.Add(new Option { ID = size_options_id, Name = "6 oz Sirloin", Cost=1 });
			size_options.Add(new Option { ID = size_options_id, Name = "9 oz Sirloin", Cost=1 });
			size_options.Add(new Option { ID = size_options_id, Name = "6 oz Filet", Cost=1 });
			OptionType size = new OptionType { Type = "Size", Options = size_options, Selected=false,Color = Colors.Black };

			List<Option> side_options = new List<Option>();
			Guid side_options_id = Guid.NewGuid();
			side_options.Add(new Option { ID = side_options_id, Name = "Fries", Cost=1 });
			side_options.Add(new Option { ID = side_options_id, Name = "Caesar Salad", Cost=1 });
			side_options.Add(new Option { ID = side_options_id, Name = "Kale Salad", Cost=1 });
			OptionType side = new OptionType { Type = "Side", Options = side_options, Selected=false, Color=Colors.Black };

			item1_options[size.Type] = size;
			item1_options[side.Type] = side;

			Addon addon_1 = new Addon { Name = "Sauteed Mushrooms", Cost = 2.5f };
			Addon addon_2 = new Addon { Name = "Gravy", Cost = 2.0f };
			Addon addon_3 = new Addon { Name = "Steak Sauce", Cost = 2.0f };

			item1_addons.Add(addon_1);
			item1_addons.Add(addon_2);
			item1_addons.Add(addon_3);
			
			// mains menu
			MenuItem item1 = new MenuItem {
				Name = "Steak Frites", 
				Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Tellus integer feugiat scelerisque varius morbi enim. Tristique et egestas quis ipsum suspendisse ultrices gravida.",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/steak_dinner.jpg")),
				Addons = item1_addons, 
				Options = item1_options,
				Cost = 24
			};

			MenuItem item2 = new MenuItem
			{
				Name = "Chicken Club",
				Description = "Grilled chicken, crispy bacon, tomatoes, lettuce and mayo on bread of your choice",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/chickenClub.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 18
			};

			MenuItem item3 = new MenuItem
			{
				Name = "BBQ Ribs",
				Description = "Tender babyback ribs, handcut fries and cornbread",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/bbqRibs.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 28
			};

			MenuItem item4 = new MenuItem
			{
				Name = "Grilled Salmon Bowl",
				Description = "Grilled salmon, grilled asparagus, jasmine rice, carrots, peas and mushrooms",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/salmon.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 25
			};

			MenuItem item5 = new MenuItem
			{
				Name = "Fish n' Chips",
				Description = "North atlantic haddock, handcut fries, tartar sauce",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/fishChips.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 21
			};

			MenuItem item6 = new MenuItem
			{
				Name = "Bacon Cheddar Burger",
				Description = "Smoked bacon, tomatoes, onion, lettuce, pickles on a toasted bun",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/burger.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 20
			};

			MenuItem item7 = new MenuItem
			{
				Name = "Crispy Falafel Burger",
				Description = "Chickpea falafel, roasted peppers, spicy tzatziki and feta cheese on bread of your choice",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/falafelBurger.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 17
			};

			MenuItem item8 = new MenuItem
			{
				Name = "Chicken Fettuccine Alfredo",
				Description = "Seasoned grilled chicken, mushrooms and fettuccine baked in cream sauce",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/chickenPasta.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 22
			};

			MenuItem item9 = new MenuItem
			{
				Name = "Tofu Zen Bowl",
				Description = "Crispy tofu, edamame beans, cucumber, green cabbage, grape tomatoes, corn, quail eggs and romaine lettuce tossed in ginger sesame sauce",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/tofuBowl.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 16
			};

			// create a list of mains
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

			menuLists.MainList = MainList;


			// appetizers menu
			MenuItem appitem1 = new MenuItem
			{
				Name = "Garlic Fries",
				Description = "Crunchy fries with garlic seasoning",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/fries_landscape.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 10
			};

			//MenuItem appitem2 = new MenuItem
			//{
			//	Name = "Kale Caesar Salad",
			//	Description = "Fresh kale salad with house caesar dressing",
			//	ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/kale.jpg")),
			//	Addons = item1_addons,
			//	Options = item1_options,
			//	Cost = 14
			//};

			MenuItem appitem2 = new MenuItem
			{
				Name = "Crispy Brussels Sprouts",
				Description = "Fried brussels sprouts, roasted peppers, onions, garlic, vegan margarine",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/brusselsSprouts.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 14
			};

			MenuItem appitem3 = new MenuItem
			{
				Name = "Chicken Wings",
				Description = "Fried chicken wings of your choice, comes with carrot and celery sticks",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/wings.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 12
			};

			MenuItem appitem4 = new MenuItem
			{
				Name = "Nachos",
				Description = "Baked nachos topped with jalapenos, tomatoes, onions and aged cheddar. Comes with salsa and sour cream",
				ImageSrc = new BitmapImage(new Uri("pack://application:,,,/Resources/images/food_items/nachos.jpg")),
				Addons = item1_addons,
				Options = item1_options,
				Cost = 16
			};

			// create a list of Appetizers
			List<MenuItem> AppetizerList = new List<MenuItem>();
			AppetizerList.Add(appitem1);
			AppetizerList.Add(appitem2);
			AppetizerList.Add(appitem3);
			AppetizerList.Add(appitem4);

			// Set the appetizer list in the MenuList class
			menuLists.AppetizerList = AppetizerList;

			// Set the current item to the one we just made.
			orderHandler.currentItem = item1;
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