﻿using System;
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
			OrderPage.orderHandler = orderHandler;

			// Set the food menu as default usercontrol
			Switcher.pageSwitcher = this;
			Switcher.Switch(new FoodMenu());

			// Example of a menu item. Used for testing out the itempage.
			List<OptionType> item1_options = new List<OptionType>();
			List<Addon> item1_addons = new List<Addon>();

			List<Option> size_options = new List<Option>();
			Guid size_options_id = Guid.NewGuid();
			size_options.Add(new Option { ID = size_options_id, Name = "6 oz Sirloin", Cost=1 });
			size_options.Add(new Option { ID = size_options_id, Name = "9 oz Sirloin", Cost=1 });
			size_options.Add(new Option { ID = size_options_id, Name = "6 oz Filet", Cost=1 });
			OptionType size = new OptionType { Type = "Size", Options = size_options };

			List<Option> side_options = new List<Option>();
			Guid side_options_id = Guid.NewGuid();
			side_options.Add(new Option { ID = side_options_id, Name = "Fries", Cost=1 });
			side_options.Add(new Option { ID = side_options_id, Name = "Caesar Salad", Cost=1 });
			side_options.Add(new Option { ID = side_options_id, Name = "Kale Salad", Cost=1 });
			OptionType side = new OptionType { Type = "Side", Options = side_options };

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
				Cost = 24
			};

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
	public List<OptionType> Options { get; set; }

	float _Cost;
	public float Cost
	{
		get => _Cost;
		set => SetField(ref _Cost, value, nameof(Cost));
	}
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

public class OptionType
{
	public string Type { get; set; }
	public List<Option> Options { get; set; }
	public Option Selected { get; set; }
}

public class Option
{
	public Guid ID { get; set; }
	public string Name { get; set; }
	public float Cost { get; set; }
}