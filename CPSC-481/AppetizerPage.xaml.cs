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
using System.Diagnostics;


namespace CPSC_481
{
	/// <summary>
	/// Interaction logic for AppetizerPage.xaml
	/// </summary>
	public partial class AppetizerPage : Page
	{
		//public static List<MenuItem> appList;	

		public AppetizerPage(List<MenuItem> appList)
		{
			InitializeComponent();
			try
			{
				MenuItem1.Content = new MenuItemControl(appList[0]);
				MenuItem2.Content = new MenuItemControl(appList[1]);
				MenuItem3.Content = new MenuItemControl(appList[2]);
				MenuItem4.Content = new MenuItemControl(appList[3]);

				Trace.WriteLine("APPETIZER LIST FROM THE APPETIZER PAGE");

				// print out list of appys to test
				for (int i = 0; i < appList.Count; i++)
				{
					Trace.WriteLine(appList[i].Name);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("AppList is empty");
			}

			

		}
	}
}
