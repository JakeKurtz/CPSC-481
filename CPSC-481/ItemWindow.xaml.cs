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
using System.Windows.Shapes;

namespace CPSC_481
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ItemWindow : Window
    {
        public ItemWindow()
        {
            InitializeComponent();

            List<Option> itemOptions = new List<Option>();
            List<Addon> itemAddons = new List<Addon>();
;
            List<string> size_options = new List<string>();
            size_options.Add("6 oz Sirloin");
            size_options.Add("9 oz Sirloin");
            size_options.Add("6 oz Filet");
            Option size = new Option { Type = "Size", Options = size_options };

            List<string> side_options = new List<string>();
            side_options.Add("Fries");
            side_options.Add("Caesar Salad");
            side_options.Add("Kale Salad");
            Option side = new Option { Type = "Side", Options = side_options};

            itemOptions.Add(size);
            itemOptions.Add(side);

            Addon addon_1 = new Addon { Name = "Sauteed Mushrooms", Cost = 2.5f};
            Addon addon_2 = new Addon { Name = "Gravy", Cost = 2.0f};
            Addon addon_3 = new Addon { Name = "Steak Sauce", Cost = 2.0f};

            itemAddons.Add(addon_1);
            itemAddons.Add(addon_2);
            itemAddons.Add(addon_3);

            _itemOptions.ItemsSource = itemOptions;
            _itemAddons.ItemsSource = itemAddons;

        }
    }
}

public class Option
{
    public string Type { get; set; }
    public List<string> Options { get; set; }
}