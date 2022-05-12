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
            _orders.Add(new OrderInfo
            {
                CustomerName = "Horatio Adeoye",
                City = "Tokyo",
                Country = "Japan",
                OrderId = 20121223
            });
            _orders.Add(new OrderInfo
            {
                CustomerName = "Harper Adeoye",
                City = "Liverpool",
                Country = "United Kingdom",
                OrderId = 20120615
            });
            _orders.Add(new OrderInfo
            {
                CustomerName = "Saori Adeoye",
                City = "Yokohama",
                Country = "Japan",
                OrderId = 20121223
            });

        }
    }
}
