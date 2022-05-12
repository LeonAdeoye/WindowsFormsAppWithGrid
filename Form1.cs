using System;
using System.Windows.Forms;


namespace WindowsFormsAppWithGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            OrderInfoCollection orderInfoCollection = new OrderInfoCollection();

            sfDataGrid1.DataSource = orderInfoCollection.Orders;
        }
    }
}
