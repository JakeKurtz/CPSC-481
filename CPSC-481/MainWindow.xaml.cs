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

			orderCurrent.Add(new Item()  {Main = "Main 1", Side = "side 1", Cost = 1.99f, Quantity = 1 });
			orderCurrent.Add(new Item() { Main = "Main 2", Side = "side 2", Cost = 2.99f, Quantity = 1 });

			orderHistory.Add(new Item() { Main = "Main 3", Side = "side 4", Cost = 3.99f, Quantity = 1 });
			orderHistory.Add(new Item() { Main = "Main 4", Side = "side 4", Cost = 4.99f, Quantity = 1 });

			List<Order> orders = new List<Order>();
			orders.Add(new Order() { Name = "Current Order", Items = orderCurrent });
			orders.Add(new Order() { Name = "Order History", Items = orderHistory });
			orderList.ItemsSource = orders;
		}
    }
}

public class Item
{
	public string Main { get; set; }
	public string Side { get; set; }
	public float Cost { get; set; }
	public int Quantity { get; set; }
}

public class Order
{
	public string Name { get; set; }
	public List<Item> Items { get; set; }

}
