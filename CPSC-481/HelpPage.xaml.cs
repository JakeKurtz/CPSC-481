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
    /// Interaction logic for HelpPage.xaml
    /// </summary>
    public partial class HelpPage : Window
    {
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
    }




}
