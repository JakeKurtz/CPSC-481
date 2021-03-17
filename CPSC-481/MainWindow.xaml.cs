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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		
		public MainWindow()
        {
            InitializeComponent();

			Switcher.pageSwitcher = this;
			Switcher.Switch(new MainMenu());

			Switcher.Switch(new FoodMenu());

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
	public OrderState State { get; set; }
	public DateTime Time { get; set; }
	public List<Item> Items { get; set; }
}