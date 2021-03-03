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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

		public MainWindow()
        {
            InitializeComponent();

			List<Item> orderCurrent = new List<Item>();
			List<Item> orderHistory = new List<Item>();

			List<Addon> order1_addons = new List<Addon>();
			List<Addon> order2_addons = new List<Addon>();
			List<Addon> order3_addons = new List<Addon>();
			List<Addon> order4_addons = new List<Addon>();

			List<String> order1_options = new List<String>();
			List<String> order2_options = new List<String>();
			List<String> order3_options = new List<String>();
			List<String> order4_options = new List<String>();

			order1_options.Add("Blackened Chicken");
			order1_addons.Add(new Addon() { Name = "Artisan Garlic Bread", Cost = 2.00f, Quantity = 1 });

			order2_options.Add("3 oz Salmon");
			order2_addons.Add(new Addon() { Name = "Extra Sauce", Cost = 1.5f, Quantity = 1 });

			order3_options.Add("Fries");
			order3_options.Add("Lobster Tail");
			order3_addons.Add(new Addon() { Name = "Extra Prawns", Cost = 10.00f, Quantity = 1 });

			order4_options.Add("Salt and pepper");
			order4_addons.Add(new Addon() { Name = "Ranch", Cost = 2.00f, Quantity = 2 });

			orderCurrent.Add(new Item() { Name = "Chicken Fettuccine Alfredo", Addons = order1_addons, Options = BuildOptions(order1_options), Cost = 23.00f, Quantity = 1 });
			orderCurrent.Add(new Item() { Name = "Salmon Zen Bowl", Addons = order2_addons, Cost = 28.50f, Options = BuildOptions(order2_options), Quantity = 1 });
			orderCurrent.Add(new Item() { Name = "Surf and Turf 6 oz Filet", Addons = order3_addons, Options = BuildOptions(order3_options), Cost = 48.00f, Quantity = 1 });

			orderHistory.Add(new Item() { Name = "Wings hot", Addons = order4_addons, Options = BuildOptions(order4_options), Cost = 33.00f, Quantity = 2 });
			orderHistory.Add(new Item() { Name = "Galic Fries", Addons = new List<Addon>(), Options = BuildOptions(new List<string>()), Cost = 8.00f, Quantity = 1 });

			List<Order> orders = new List<Order>();
			orders.Add(new Order() { Name = "Current Order", Items = orderCurrent });
			orders.Add(new Order() { Name = "Order History", Items = orderHistory });
			_orderCurrent.ItemsSource = orderCurrent;
			_orderHistory.ItemsSource = orderHistory;
		}

		private String BuildOptions(List<String> options)
		{
			if (options.Count == 0) return "";

			var output = "with ";
			for (int i = 0; i < options.Count; i++)
			{
				output += options[i];
				if (i != options.Count-1) output += " and ";
			}
			return output;
		}
	}
}

public class Addon
{
	public string Name { get; set; }
	public float Cost { get; set; }
	public int Quantity { get; set; }
}

public class Item
{
	public string Name { get; set; }
	public List<Addon> Addons { get; set; }
	public String Options { get; set; }
	public float Cost { get; set; }
	public int Quantity { get; set; }
}
public class Order
{
	public string Name { get; set; }
	public List<Item> Items { get; set; }
}