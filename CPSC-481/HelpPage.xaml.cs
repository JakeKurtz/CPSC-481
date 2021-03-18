using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace CPSC_481
{
	/// <summary>
	/// Interaction logic for HelpPage.xaml
	/// </summary>
	public partial class HelpPage : UserControl
	{
		List<GettingStartedItem> GettingStartedList = new List<GettingStartedItem>();
		int GettingStartedList_Index = 0;

		public HelpPage()
		{
			InitializeComponent();

			//QA
			List<TextBlock> QnAList = new List<TextBlock>();
			List<String> QnAs = new List<String>();

			String question1 = "How do I add an item to an order?";
			QnAs.Add(question1);
			TextBlock Q1 = new TextBlock();
			QnAList.Add(Q1);

			String answer1 = "Navigate to the Menu, select a desired item, adjust your enabled options and enter any special requests, then select 'Add To Order'";
			QnAs.Add(answer1);
			TextBlock A1 = new TextBlock();
			QnAList.Add(A1);

			String question2 = "How do I order a refill?";
			QnAs.Add(question2);
			TextBlock Q2 = new TextBlock();
			QnAList.Add(Q2);

			String answer2 = "Navigate to order history, select a previously ordered item, then select 'Order Again'.";
			QnAs.Add(answer2);
			TextBlock A2 = new TextBlock();
			QnAList.Add(A2);

			String question3 = "How do I select a Filter?";
			QnAs.Add(question3);
			TextBlock Q3 = new TextBlock();
			QnAList.Add(Q3);

			String answer3 = "Navigate to the Menu, select the 'Filters' button at the top, then choose your filters.";
			QnAs.Add(answer3);
			TextBlock A3 = new TextBlock();
			QnAList.Add(A3);

			String question4 = "How do I ask a server for help?";
			QnAs.Add(question4);
			TextBlock Q4 = new TextBlock();
			QnAList.Add(Q4);

			String answer4 = "Open the 'Contact Server' menu below, then select the 'Request Server' button.";
			QnAs.Add(answer4);
			TextBlock A4 = new TextBlock();
			QnAList.Add(A4);

			String question5 = "How do I request my bill?";
			QnAs.Add(question5);
			TextBlock Q5 = new TextBlock();
			QnAList.Add(Q5);

			String answer5 = "Navigate to order history, then select 'Request Bill'.";
			QnAs.Add(answer5);
			TextBlock A5 = new TextBlock();
			QnAList.Add(A5);

			addQnA(QnAList, QnAs);

			_QnA.ItemsSource = QnAList;

			// getting started 
			// double ACL, double TCL, double TCT, string TV
			GettingStartedList.Add(new GettingStartedItem(0d, 80d, 390d, "Here you can browse the food menu", MenuButton.Food));
			GettingStartedList.Add(new GettingStartedItem(85d, 50d, 310d, "Here you can browse the drinks menu", MenuButton.Drink));
			GettingStartedList.Add(new GettingStartedItem(169d, 110d, 280d, "Here you can review and send your order to the kitchen", MenuButton.Order));
			GettingStartedList.Add(new GettingStartedItem(169d, 110d, 280d, "When you're finished your meal, you can also request the bill here", MenuButton.Order));
			GettingStartedList.Add(new GettingStartedItem(169d, 95d, 260d, "After you send your order to the kitchen, " +
				"you can place additional orders from here, until you request your bill", MenuButton.Order));
			GettingStartedList.Add(new GettingStartedItem(255d, 80d, 390d, "Here you can make requests to your server", MenuButton.Help));

		}

		private void addQnA(List<TextBlock> TB, List<String> S)
		{
			var QA = TB.Zip(S, (t, s) => new { blk = t, str = s });
			int count = 0;
			String ch;

			foreach (var ts in QA)
			{
				ts.blk.TextWrapping = TextWrapping.Wrap;
				if (count % 2 == 0) ch = "Q: ";
				else ch = "A: ";
				ts.blk.Inlines.Add(new Bold(new Run(ch)));
				ts.blk.Inlines.Add(new Run(ts.str));
				count++;
			}
		}

		private void NextGettingStartedItem(object sender, RoutedEventArgs e)
		{
			GettingStartedList_Index += 1;
			gettingStartedBackButton.Visibility = Visibility.Visible;

			if (GettingStartedList_Index == GettingStartedList.Count)
			{
				HighlightCorrespondingIcon(true);
				gettingStarted.IsExpanded = false;
				return;
			}
			else if (GettingStartedList_Index == GettingStartedList.Count - 1)
			{
				gettingStartedContinueText.Text = "Tap to finish";
			}

			MoveAssociatedGettingStartedItems();
		}
		private void LastGettingStartedItem(object sender, RoutedEventArgs e)
		{
			// since back button is hidden at index 0, it won't be called when index == 0
			GettingStartedList_Index -= 1;
			gettingStartedBackButton.Visibility = Visibility.Visible;

			if (GettingStartedList_Index == 0)
			{
				gettingStartedBackButton.Visibility = Visibility.Hidden;
			}
			else if (GettingStartedList_Index == GettingStartedList.Count - 2)
			{
				gettingStartedContinueText.Text = "Tap to continue";
			}

			MoveAssociatedGettingStartedItems();
		}

		private void MoveAssociatedGettingStartedItems()
		{
			gettingStartedArrow.SetCurrentValue(Canvas.LeftProperty, GettingStartedList[GettingStartedList_Index].ArrowCanvasLeft);
			gettingStartedDescription.SetCurrentValue(Canvas.LeftProperty, GettingStartedList[GettingStartedList_Index].TextCanvasLeft);
			gettingStartedDescription.SetCurrentValue(Canvas.TopProperty, GettingStartedList[GettingStartedList_Index].TextCanvasTop);
			gettingStartedDescription.SetCurrentValue(TextBlock.TextProperty, GettingStartedList[GettingStartedList_Index].TextValue);
			HighlightCorrespondingIcon(false);
		}

		private void resetButtonIconColor() {
			menu.SetButtonIconForground(Brushes.Gray, MenuButton.Food);
			menu.SetButtonIconForground(Brushes.Gray, MenuButton.Drink);
			menu.SetButtonIconForground(Brushes.Gray, MenuButton.Order);
			menu.SetButtonIconForground(Brushes.Gray, MenuButton.Help);
		}

		public void HighlightCorrespondingIcon(bool backToDefault)
		{
			resetButtonIconColor();

			if (backToDefault == true)
			{
				GettingStartedList_Index = 0;
				gettingStartedBackButton.Visibility = Visibility.Hidden;
				gettingStartedContinueText.Text = "Tap to continue";
				return;
			}

			// Highlight current button
			MenuButton button = GettingStartedList[GettingStartedList_Index].Button;
			menu.SetButtonIconForground(Brushes.DarkViolet, button);

		}

		private void onGettingStartedTabCollapse(object sender, RoutedEventArgs e)
		{
			HighlightCorrespondingIcon(true);
		}
		private void onGettingStartedTabExpand(object sender, RoutedEventArgs e)
		{
			HighlightCorrespondingIcon(false);
			MoveAssociatedGettingStartedItems();
		}
	}

	public class GettingStartedItem
	{
		public double ArrowCanvasLeft;
		public double TextCanvasLeft;
		public double TextCanvasTop;
		public string TextValue;
		public MenuButton Button;

		public GettingStartedItem(double ACL, double TCL, double TCT, string TV, MenuButton B)
		{
			this.TextValue = TV;
			this.ArrowCanvasLeft = ACL;
			this.TextCanvasLeft = TCL;
			this.TextCanvasTop = TCT;
			this.Button = B;
		}
	}
}
