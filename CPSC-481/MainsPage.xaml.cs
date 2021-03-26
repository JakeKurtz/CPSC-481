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
	/// Interaction logic for MainPage.xaml
	/// </summary>
	public partial class MainPage : Page
	{
		public MainPage(List<MenuItem> mainList)
		{
			InitializeComponent();

			//Trace.WriteLine("MAIN LIST FROM THE MAINS PAGE");

			//// print out list of appys to test
			//for (int i = 0; i < mainList.Count; i++)
			//{
			//	Trace.WriteLine(mainList[i].Name);
			//}
			try
			{
				// pass each MenuItem into a MenuItemControl
				MenuItem1.Content = new MenuItemControl(mainList[0]);
				MenuItem2.Content = new MenuItemControl(mainList[1]);
				MenuItem3.Content = new MenuItemControl(mainList[2]);
				MenuItem4.Content = new MenuItemControl(mainList[3]);
				MenuItem5.Content = new MenuItemControl(mainList[4]);
				MenuItem6.Content = new MenuItemControl(mainList[5]);
				MenuItem7.Content = new MenuItemControl(mainList[6]);
				MenuItem8.Content = new MenuItemControl(mainList[7]);
				MenuItem9.Content = new MenuItemControl(mainList[8]);

			}
			catch (Exception ex)
			{
				Console.WriteLine("Mains list is empty");
			}


		}
	}
}
