﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Data;
using Syncfusion.WinForms.Core;
using Syncfusion.WinForms.Core.Enums;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Styles;
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
            
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "CustomerName", HeaderText="Name of customer"});
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "City", HeaderText = "City of birth" });
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "Country", HeaderText = "Country of birth" });            
            sfDataGrid1.Columns.Add(new GridTextColumn { MappingName = "OrderId", HeaderText = "Order ID" });

            // SfDataGrid allows to resize the columns like in excel by resizing column header.
            // This can be enabled or disabled by setting SfDataGrid.AllowResizingColumns.
            this.sfDataGrid1.AllowResizingColumns = true;

            // The large amount of data can be loaded in less time by setting SfDataGrid.EnableDataVirtualization property to true.
            this.sfDataGrid1.EnableDataVirtualization = true;

            // // If the data source implements INotifyCollectionChanged interface,
            // then SfDataGrid control will automatically refresh the UI when item is added, removed or while list cleared.
            sfDataGrid1.DataSource = _orderInfoCollection.Orders;

            // Appearance of SfDataGrid can be changed by ThemeName of SfDataGrid.
            // this.sfDataGrid1.ThemeName = "Office2016Black";
            

            // By default, columns in a SfDataGrid can be manually sorted by clicking the column header.
            // Automatic at window startup sorting can be configured by setting SfDataGrid.SortColumnDescriptions property
            sfDataGrid1.SortColumnDescriptions.Add(new SortColumnDescription { ColumnName = "OrderId" });            
            // Sorting can be enabled or disabled for the particular column by setting the GridColumnBase.AllowSorting property.
            this.sfDataGrid1.Columns["City"].AllowSorting = false;

            // The editing can be enabled/disabled only for the particular columns by setting the GridColumn.AllowEditing property to true/false respectively.
            this.sfDataGrid1.Columns[0].AllowEditing = false;

            // Appearance of the record cells and columns can be customized by using the CellStyle property.
            this.sfDataGrid1.Style.CellStyle.BackColor = Color.AliceBlue;
            this.sfDataGrid1.Style.CellStyle.TextColor = Color.DarkBlue;
            this.sfDataGrid1.Columns["City"].CellStyle.BackColor = Color.PaleTurquoise;
            this.sfDataGrid1.Columns["City"].CellStyle.TextColor = Color.DarkRed;

            // SfDataGrid helps to provide gradient background appearance for the cells by using Interior property which is available in the StyleInfo properties of all the elements in the SfDataGrid.
            // The gradient background can be achieved by initializing the Interior property using BrushInfo object with GradientStyle and the necessary colors.
            // In the below example, gradient background is applied for the header cells and the record cells by providing the GradientStyle as Horizontal and the gradient start and end colors.
            //this.sfDataGrid1.Columns["OrderId"].HeaderStyle.Interior = new BrushInfo(GradientStyle.Horizontal, ColorTranslator.FromHtml("#5aff8d"), ColorTranslator.FromHtml("#12cb74"));
            this.sfDataGrid1.Columns["OrderId"].CellStyle.Interior = new BrushInfo(GradientStyle.Horizontal, ColorTranslator.FromHtml("#5aff8d"), ColorTranslator.FromHtml("#12cb74"));
            
            // The text alignment of the record cells can be changed by using CellStyle.HorizontalAlignment and CellStyle.VerticalAlignment properties respectively.
            this.sfDataGrid1.Columns["OrderId"].CellStyle.HorizontalAlignment = HorizontalAlignment.Right;

            this.sfDataGrid1.Style.BorderStyle = BorderStyle.Fixed3D;

            this.sfDataGrid1.CurrentCellEndEdit += DataGrid_CurrentCellEndEdit;

            ShowSummary();            
        }

        void DataGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
        {
            MessageBox.Show($"The editing is completed for the cell ({e.DataRow.RowIndex},{e.DataColumn.ColumnIndex})");
        }

        private void ShowSummary()
        {
            GridTableSummaryRow tableSummaryRow1 = new GridTableSummaryRow
            {
                Name = "TableSummary",
                ShowSummaryInRow = true,
                Title = "{CustomerCount}",
                Position = VerticalPosition.Bottom
            };

            GridSummaryColumn summaryColumn1 = new GridSummaryColumn
            {
                Name = "CustomerCount",
                SummaryType = SummaryType.CountAggregate,
                Format = "Total Customer Count: {Count}",
                MappingName = "OrderId"
            };

            // The appearance of the table summary can be customized by SfDataGrid.Style.TableSummaryRowStyle property
            this.sfDataGrid1.Style.TableSummaryRowStyle.BackColor = Color.LightSkyBlue;
            this.sfDataGrid1.Style.TableSummaryRowStyle.Borders.All = new GridBorder(Color.Black, GridBorderWeight.Medium);
            this.sfDataGrid1.Style.TableSummaryRowStyle.Font = new GridFontInfo(new Font("Arial", 10f, FontStyle.Bold));

            tableSummaryRow1.SummaryColumns.Add(summaryColumn1);
            this.sfDataGrid1.TableSummaryRows.Add(tableSummaryRow1);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PdfExportingOptions options = new PdfExportingOptions { AutoColumnWidth = true };
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

        private void button4_Click(object sender, EventArgs e)
        {
            // The highlighting color of the search text can be changed by using the SearchColor property.
            this.sfDataGrid1.SearchController.SearchColor = Color.LightGreen;
            // Search and highlight the text in SfDataGrid.
            this.sfDataGrid1.SearchController.Search(textBox1.Text);
            // Once done you can clear search: this.sfDataGrid1.SearchController.ClearSearch();
        }
    }
}
