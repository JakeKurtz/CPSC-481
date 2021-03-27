using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	/// Interaction logic for BeerPage.xaml
	/// </summary>
	public partial class BeerPage : Page
	{
		public BeerPage(List<MenuItem> beerList)
		{
			InitializeComponent();
			try
			{
				// pass each MenuItem into a MenuItemControl
				//MenuItem1.Content = new MenuItemControl(beerList[0]);
				//MenuItem2.Content = new MenuItemControl(beerList[1]);
				//MenuItem3.Content = new MenuItemControl(beerList[2]);
				//MenuItem4.Content = new MenuItemControl(beerList[3]);

				Trace.WriteLine("BEER LIST:");

				// print out list of appys to test
				for (int i = 0; i < beerList.Count; i++)
				{
					Trace.WriteLine(beerList[i].Name);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("beerList is empty " + ex);
			}
		}
	}
}
