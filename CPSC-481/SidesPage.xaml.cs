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
	/// Interaction logic for SidesPage.xaml
	/// </summary>
	public partial class SidesPage : Page
	{
		public SidesPage(List<MenuItem> sidesList)
		{
			InitializeComponent();

			// pass each MenuItem into a MenuItemControl
			MenuItem1.Content = new MenuItemControl(sidesList[0]);
			MenuItem2.Content = new MenuItemControl(sidesList[1]);
			MenuItem3.Content = new MenuItemControl(sidesList[2]);
			MenuItem4.Content = new MenuItemControl(sidesList[3]);
			MenuItem5.Content = new MenuItemControl(sidesList[4]);
			MenuItem6.Content = new MenuItemControl(sidesList[5]);
			MenuItem7.Content = new MenuItemControl(sidesList[6]);


			Trace.WriteLine("SIDES LIST FROM THE SIDE MENU PAGE");

			// print out list of appys to test
			for (int i = 0; i < sidesList.Count; i++)
			{
				Trace.WriteLine(sidesList[i].Name);
			}
		}
	}
}
