using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	/// Interaction logic for OrderPage.xaml
	/// </summary>
	public partial class OrderPage : UserControl
	{

		// Reference to the orderhandler in the mainwindow
		public static OrderHandler orderHandler { get; set; }

		public OrderPage()
		{
			InitializeComponent();

			_orderCurrent.ItemsSource = orderHandler?.orderCurrent.Values;
			_orderHistory.ItemsSource = orderHandler?.orderHistory;

			setProperTab();

			updateOrderCurrentInvoice();
			updateOrderHistoryInvoice();
		}
		private void setProperTab()
		{
			if (orderHandler?.orderCurrent.Values.Count > 0)
			{
				OrderCurrentTab.IsSelected = true;
			}
			else
			{
				OrderHistoryTab.IsSelected = true;
			}
		}
		private float getSubTotal(List<OrderItem> itemList) {

			var subTotal = 0.0f;
			foreach (var order in itemList)
			{
				subTotal += order.Cost;
			}

			return subTotal;

		}
		private float getGST(List<OrderItem> itemList) {
			return getSubTotal(itemList) * 0.05f;
		}
		private float getTotal(List<OrderItem> itemList) {
			return getSubTotal(itemList) * 1.05f;
		}

		private void updateOrderCurrentInvoice() {

			var itemList = new List<OrderItem>(orderHandler?.orderCurrent.Values);

			if (itemList.Count > 0)
			{
				OrderCurrentInvoice.Visibility = Visibility.Visible;
				OrderCurrentIsEmpty.Visibility = Visibility.Hidden;
			} else
			{
				OrderCurrentInvoice.Visibility = Visibility.Hidden;
				OrderCurrentIsEmpty.Visibility = Visibility.Visible;
			}

			oc_subTotal.Text = getSubTotal(itemList).ToString();
			oc_gst.Text = getGST(itemList).ToString();
			oc_total.Text = getTotal(itemList).ToString();
		}
		private void updateOrderHistoryInvoice() {

			var orderList = orderHandler?.orderHistory;
			var subTotal = 0.0f;
			var gst = 0.0f;
			var total = 0.0f;

			if (orderList.Count > 0)
			{
				OrderHistoryInvoice.Visibility = Visibility.Visible;
				OrderHistoryIsEmpty.Visibility = Visibility.Hidden;
			}
			else
			{
				OrderHistoryInvoice.Visibility = Visibility.Hidden;
				OrderHistoryIsEmpty.Visibility = Visibility.Visible;
			}

			foreach (var order in orderList) {

				var itemList = order.Items;

				subTotal += getSubTotal(itemList);
				gst += getGST(itemList);
				total += getTotal(itemList);
			}

			oh_subTotal.Text = subTotal.ToString();
			oh_gst.Text = gst.ToString();
			oh_total.Text = total.ToString();
		}

		public void Button_Send_Order(object sender, RoutedEventArgs e) {
			Dictionary<Guid, OrderItem> orderCurrent = new Dictionary<Guid, OrderItem>(orderHandler?.orderCurrent);
			orderHandler?.orderCurrent.Clear();
			orderHandler?.addToOrderHistory(orderCurrent);

			updateOrderCurrentInvoice();
			updateOrderHistoryInvoice();

			setProperTab();

			_orderCurrent.Items.Refresh();
			_orderHistory.Items.Refresh();

		}
		public void Button_Delete_Item(object sender, RoutedEventArgs e) {

			var item = ((sender as Button)?.Tag as ListViewItem)?.DataContext as OrderItem;
			orderHandler?.orderCurrent.Remove(item.ID);
			_orderCurrent.Items.Refresh();
			updateOrderCurrentInvoice();
		}
	}

	public class StateColorSelector : IValueConverter
	{
		private readonly Color _processingColor = Colors.RoyalBlue;
		private readonly Color _deliveredColor = Colors.OliveDrab;

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is OrderState)
			{
				return (OrderState)value == OrderState.Processing ? new SolidColorBrush(_processingColor) : new SolidColorBrush(_deliveredColor);
			}

			return Binding.DoNothing;
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}

	// Source: https://stackoverflow.com/questions/4449000/multiple-expander-have-to-collapse-if-one-is-expanded
}