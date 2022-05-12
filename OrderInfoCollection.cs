using System.Collections.ObjectModel;

namespace WindowsFormsAppWithGrid
{
    public class OrderInfoCollection
    {
        private ObservableCollection<OrderInfo> _orders;

        public ObservableCollection<OrderInfo> Orders 
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public OrderInfoCollection()
        {
            Orders = new ObservableCollection<OrderInfo>();
            this.GenerateOrders();
        }

        private void GenerateOrders()
        {
            for(int i = 1; i <= 1000; i++)
            {
                _orders.Add(new OrderInfo
                {
                    CustomerName = "Horatio Adeoye",
                    City = "Tokyo",
                    Country = "Japan",
                    OrderId = string.Format("{0:D4}", i)
                });
                _orders.Add(new OrderInfo
                {
                    CustomerName = "Harper Adeoye",
                    City = "Liverpool",
                    Country = "United Kingdom",
                    OrderId = string.Format("{0:D4}", i)
                });
                _orders.Add(new OrderInfo
                {
                    CustomerName = "Saori Adeoye",
                    City = "Yokohama",
                    Country = "Japan",
                    OrderId = string.Format("{0:D4}", i)
                });
            }
        }
    }
}
