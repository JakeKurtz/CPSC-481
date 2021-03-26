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
	/// Interaction logic for SpecialsPage.xaml
	/// </summary>
	public partial class SpecialsPage : Page
	{
		public SpecialsPage(List<MenuItem> specialsList)
		{
			InitializeComponent();

			try
			{
				// pass each MenuItem into a MenuItemControl
				MenuItem1.Content = new SpecialsControl(specialsList[0]);
				MenuItem2.Content = new SpecialsControl(specialsList[1]);
				MenuItem3.Content = new SpecialsControl(specialsList[2]);
				MenuItem4.Content = new SpecialsControl(specialsList[3]);

				Trace.WriteLine("FROM THE SPECIALS PAGE");

				// print out list of appys to test
				for (int i = 0; i < specialsList.Count; i++)
				{
					Trace.WriteLine(specialsList[i].Name);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("specialsList is empty");
			}
		}
	}
}
