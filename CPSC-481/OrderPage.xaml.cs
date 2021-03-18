using System;
using System.Collections.Generic;
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
	/// Interaction logic for OrderPage.xaml
	/// </summary>
	public partial class OrderPage : UserControl
	{
		public OrderPage()
		{
			InitializeComponent();

			List<OrderItem> orderCurrent = new List<OrderItem>();

			List<Addon> item1_addons = new List<Addon>();
			List<Addon> item2_addons = new List<Addon>();
			List<Addon> item3_addons = new List<Addon>();

			List<String> item1_options = new List<String>();
			List<String> item2_options = new List<String>();
			List<String> item3_options = new List<String>();

			// ---- Current Order Data ---- //

			item1_options.Add("Blackened Chicken");
			item1_addons.Add(new Addon() { Name = "Artisan Garlic Bread", Cost = 2.00f, Quantity = 1 });

			item2_options.Add("3 oz Salmon");
			item2_addons.Add(new Addon() { Name = "Extra Sauce", Cost = 1.5f, Quantity = 1 });

			item3_options.Add("Fries");
			item3_options.Add("Lobster Tail");
			item3_addons.Add(new Addon() { Name = "Extra Prawns", Cost = 10.00f, Quantity = 1 });

			orderCurrent.Add(new OrderItem() { Name = "Chicken Fettuccine Alfredo", Addons = item1_addons, Options = BuildOptions(item1_options), Cost = 23.00f, Quantity = 1 });
			orderCurrent.Add(new OrderItem() { Name = "Salmon Zen Bowl", Addons = item2_addons, Cost = 28.50f, Options = BuildOptions(item2_options), Quantity = 1 });
			orderCurrent.Add(new OrderItem() { Name = "Surf and Turf 6 oz Filet", Addons = item3_addons, Options = BuildOptions(item3_options), Cost = 48.00f, Quantity = 1 });

			// ---- Order History Data ---- //

			List<Order> orderHistory = new List<Order>();
			List<OrderItem> order4_items = new List<OrderItem>();
			List<String> order4_item1_options = new List<String>();
			List<Addon> order4_item1_addons = new List<Addon>();

			List<OrderItem> order5_items = new List<OrderItem>();

			List<String> order5_item1_options = new List<String>();
			List<Addon> order5_item1_addons = new List<Addon>();

			List<String> order5_item2_options = new List<String>();
			List<Addon> order5_item2_addons = new List<Addon>();

			order4_item1_options.Add("Salt and pepper");
			order4_item1_addons.Add(new Addon() { Name = "Ranch", Cost = 2.00f, Quantity = 2 });
			order4_items.Add(new OrderItem() { Name = "Wings hot", Addons = order4_item1_addons, Options = BuildOptions(order4_item1_options), Cost = 33.00f, Quantity = 2 });

			order4_items.Add(new OrderItem() { Name = "Galic Fries", Addons = new List<Addon>(), Options = BuildOptions(new List<string>()), Cost = 8.00f, Quantity = 1 });

			order5_item1_options.Add("Fries");
			order5_item1_options.Add("Substituted lettuce for bun");
			order5_items.Add(new OrderItem() { Name = "Vegan Burger", Addons = order5_item1_addons, Options = BuildOptions(order5_item1_options), Cost = 21.7f, Quantity = 1 });

			order5_item2_addons.Add(new Addon() { Name = "Chicken", Cost = 6.00f, Quantity = 1 });
			order5_items.Add(new OrderItem() { Name = "Quinoa and Avocado Powerbowl", Addons = order5_item2_addons, Options = BuildOptions(order5_item2_options), Cost = 16.7f, Quantity = 1 });

			Order order4 = new Order() { State = OrderState.Delivered, Time = DateTime.Now, Items = order4_items };
			Order order5 = new Order() { State = OrderState.Processing, Time = DateTime.Now, Items = order5_items };

			orderHistory.Add(order4);
			orderHistory.Add(order5);

			// ---- Send it ---- //

			_orderCurrent.ItemsSource = orderCurrent;
			_orderHistory.ItemsSource = orderHistory;
		}

		// Builds a string out of the selected options.
		private String BuildOptions(List<String> options)
		{
			if (options.Count == 0) return "";

			var output = "with ";
			for (int i = 0; i < options.Count; i++)
			{
				output += options[i];
				if (i != options.Count - 1) output += " and ";
			}
			return output;
		}
	}

	public class StateColorSelector : IValueConverter
	{
		private readonly Color _processingColor = Colors.RoyalBlue;
		private readonly Color _deliveredColor = Colors.OliveDrab;

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is OrderState)
			{
				return (OrderState)value == OrderState.Processing ? new SolidColorBrush(_processingColor) : new SolidColorBrush(_deliveredColor);
			}

			return Binding.DoNothing;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
