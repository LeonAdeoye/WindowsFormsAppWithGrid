using System;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGridConverter;


namespace WindowsFormsAppWithGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            OrderInfoCollection orderInfoCollection = new OrderInfoCollection();

            // By default, the SfDataGrid control generates the columns automatically when value assigned to SfDataGrid.DataSource property.
            // However, you can manually setting the column headers before you set the Datasource.
            // The automatic column generation can be prevented by setting SfDataGrid.AutoGenerateColumns property is false
            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "OrderId", HeaderText = "Order ID" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerName", HeaderText="Name of customer"});
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Country", HeaderText = "Country of birth" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "City", HeaderText = "City of birth" });

            sfDataGrid1.DataSource = orderInfoCollection.Orders;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfExportingOptions options = new PdfExportingOptions();
            options.AutoColumnWidth = true;
            var document = sfDataGrid1.ExportToPdf(options);
            document.Save("Sample.pdf");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var options = new ExcelExportingOptions();
            var excelEngine = sfDataGrid1.ExportToExcel(sfDataGrid1.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];
            workBook.SaveAs("Sample.xlsx");
        }
    }
}
