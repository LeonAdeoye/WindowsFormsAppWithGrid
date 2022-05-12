using System;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGridConverter;


namespace WindowsFormsAppWithGrid
{
    public partial class Form1 : Form
    {
        private readonly OrderInfoCollection _orderInfoCollection = new OrderInfoCollection();
        public Form1()
        {
            InitializeComponent();
            // By default, the SfDataGrid control generates the columns automatically when value assigned to SfDataGrid.DataSource property.
            // However, you can manually setting the column headers before you set the Datasource.
            // The automatic column generation can be prevented by setting SfDataGrid.AutoGenerateColumns property is false
            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "OrderId", HeaderText = "Order ID" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "CustomerName", HeaderText="Name of customer"});
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Country", HeaderText = "Country of birth" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "City", HeaderText = "City of birth" });

            // SfDataGrid allows to resize the columns like in excel by resizing column header.
            // This can be enabled or disabled by setting SfDataGrid.AllowResizingColumns.
            this.sfDataGrid1.AllowResizingColumns = true;

            // // If the data source implements INotifyCollectionChanged interface,
            // then SfDataGrid control will automatically refresh the UI when item is added, removed or while list cleared.
            sfDataGrid1.DataSource = _orderInfoCollection.Orders;

            // By default, columns in a SfDataGrid can be manually sorted by clicking the column header.
            // Automatic at window startup sorting can be configured by setting SfDataGrid.SortColumnDescriptions property
            sfDataGrid1.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = "OrderId" });

            // Appearance of the record cells and columns can be customized by using the CellStyle property.
            this.sfDataGrid1.Style.CellStyle.BackColor = Color.AliceBlue;
            this.sfDataGrid1.Style.CellStyle.TextColor = Color.DarkBlue;
            this.sfDataGrid1.Columns["CustomerName"].CellStyle.BackColor = Color.PaleTurquoise;
            this.sfDataGrid1.Columns["CustomerName"].CellStyle.TextColor = Color.DarkRed;
            // The text alignment of the record cells can be changed by using CellStyle.HorizontalAlignment and CellStyle.VerticalAlignment properties respectively.
            this.sfDataGrid1.Columns["OrderId"].CellStyle.HorizontalAlignment = HorizontalAlignment.Right;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfExportingOptions options = new PdfExportingOptions() { AutoColumnWidth = true };
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

        private void button3_Click(object sender, EventArgs e)
        {
            // When an item is added / removed in ObservableCollection, SfDataGrid automatically refreshes the UI as ObservableCollection implements INotifyCollectionChanged.
            _orderInfoCollection.Orders.RemoveAt(0);
        }
    }
}
