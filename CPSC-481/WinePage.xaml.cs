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
	/// Interaction logic for WinePage.xaml
	/// </summary>
	public partial class WinePage : Page
	{
		public WinePage(List<MenuItem> wineList)
		{
			InitializeComponent();
			try
			{
				// pass each MenuItem into a MenuItemControl
				MenuItem1.Content = new MenuItemControl(wineList[0]);
				MenuItem2.Content = new MenuItemControl(wineList[1]);
				MenuItem3.Content = new MenuItemControl(wineList[2]);
				MenuItem4.Content = new MenuItemControl(wineList[3]);

				Trace.WriteLine("WINE LIST:");

				// print out list of appys to test
				for (int i = 0; i < wineList.Count; i++)
				{
					Trace.WriteLine(wineList[i].Name);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("wineList is empty " + ex);
			}
		}
	}
}
