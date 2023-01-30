using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ClosedXML.Excel;
using System.IO;
using Microsoft.EntityFrameworkCore;


namespace Store.Domain
{
    public class ProductRepo
    {
        string connectionString = "DRIVER={SQL Server};" +
                                 "SERVER=store.c3shhznpmx8i.us-east-1.rds.amazonaws.com, 1433;" +
                                 "DATABASE=Store;" +
                                 "User ID=admin;" +
                                 "Password=12345678;";

        private readonly IConfiguration _config;
        private readonly AppDbContext context;

        public ProductRepo(AppDbContext context, IConfiguration config)
        {
            _config = config;
            this.context = context;
        }


        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public IQueryable<Product> GetAllProduct()
        {
            return context.product.OrderBy(x => x.Id);
        }

        public List<Product> GetAllProductExcele()
        {
            List<Product> products = new List<Product>();

            string path = "..\\Store\\wwwroot\\Bd.xlsx";


            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);


            //string xsltPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data"), fileName);

            var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RowsUsed();

            foreach (var row in rows)
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(row.Cell(1).Value.ToString());
                product.ProviderName = row.Cell(2).Value.ToString();
                product.Description = row.Cell(3).Value.ToString();
                product.CreationData = Convert.ToDateTime(row.Cell(4).Value.ToString());
                product.ModificationData = Convert.ToDateTime(row.Cell(5).Value.ToString());
                product.Manager = row.Cell(6).Value.ToString();
                product.Quantity = Convert.ToInt32(row.Cell(7).Value.ToString());
                product.Amount = Convert.ToInt32(row.Cell(8).Value.ToString());
                product.City = row.Cell(9).Value.ToString();

                products.Add(product);
            }
            stream.Close();
            //var s = (IQueryable<Product>)products.ToList();

            return products;
        }
        public Product GetProductById(int id)
        {
            return context.product.Single(x => x.Id == id);
        }

        public Product GetProductExcelById(int id)
        {
            List<Product> products = new List<Product>();

            string path = "..\\Store\\wwwroot\\Bd.xlsx";


            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);


            //string xsltPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data"), fileName);

            var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RowsUsed();

            foreach (var row in rows)
            {
                Product product = new Product();
                product.Id = Convert.ToInt32(row.Cell(1).Value.ToString());
                product.ProviderName = row.Cell(2).Value.ToString();
                product.Description = row.Cell(3).Value.ToString();
                product.CreationData = Convert.ToDateTime(row.Cell(4).Value.ToString());
                product.ModificationData = Convert.ToDateTime(row.Cell(5).Value.ToString());
                product.Manager = row.Cell(6).Value.ToString();
                product.Quantity = Convert.ToInt32(row.Cell(7).Value.ToString());
                product.Amount = Convert.ToInt32(row.Cell(8).Value.ToString());
                product.City = row.Cell(9).Value.ToString();

                products.Add(product);
                if (product.Id == id)
                {
                    stream.Close();
                    return product;
                }
            }
            stream.Close();

            return products[0];
        }

        public void SaveProductExcel(Product product, List<Product> products)
        {
            string path = "..\\Store\\wwwroot\\Bd.xlsx";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite);



            //string xsltPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data"), fileName);

            var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheet(1);
            

            var a = products[products.Count-1].Id+1;
            var data = DateTime.Now;

            worksheet.Cell(a, 1).SetValue(a);
            worksheet.Cell(a, 2).SetValue(product.ProviderName);
            worksheet.Cell(a, 3).SetValue(product.Description);
            worksheet.Cell(a, 4).SetValue(data);
            worksheet.Cell(a, 5).SetValue(data);
            worksheet.Cell(a, 6).SetValue(product.Manager);
            worksheet.Cell(a, 7).SetValue(product.Quantity);
            worksheet.Cell(a, 8).SetValue(product.Amount);
            worksheet.Cell(a, 9).SetValue(product.City);

            workbook.Save();

            stream.Close();

            //Excel.Workbook WorkBook = excelApp.Workbooks.Open(path);
            //Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

            //return WorkSheet.Cells[1, 1];
        }

        public void SaveProduct(Product product)
        {
            product.CreationData = DateTime.Now;
            product.ModificationData = product.CreationData;

        //    string queryString =
        //"SET TRANSACTION ISOLATION LEVEL READ COMMITTED;\n" +
        //"BEGIN TRANSACTION\n" +
        //"INSERT INTO Product (ProviderName, Description, CreationData, ModificationData, Manager, Quantity, Amount, City)" +
        //"VALUES(('" + product.ProviderName + "'), ('" + product.Description + "'), " +
        //"('" + product.CreationData.Year.ToString() + "." + product.CreationData.Month.ToString() + "." + product.CreationData.Day.ToString() + " " + product.CreationData.TimeOfDay.ToString()+"'), " +
        //"('" + product.ModificationData.Year.ToString() + "." + product.ModificationData.Month.ToString() + "." + product.ModificationData.Day.ToString() + " " + product.ModificationData.TimeOfDay.ToString() + "'), " +
        //"('" + product.Manager + "'), ('" + product.Quantity + "'), ('" + product.Amount + "'), ('" + product.City + "'));\n" +
        //"COMMIT TRANSACTION";

        //    OdbcCommand command = new OdbcCommand(queryString);

        //    using (OdbcConnection connection = new OdbcConnection(connectionString))
        //    {
        //        command.Connection = connection;
        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }


            context.Entry(product).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(Product product)
        {

        //    string queryString =
        //"SET TRANSACTION ISOLATION LEVEL READ COMMITTED;\n" +
        //"BEGIN TRANSACTION\n" +
        //"DELETE from Product where ID = ('" + product.Id + "')\n" +
        //"COMMIT TRANSACTION";

        //    OdbcCommand command = new OdbcCommand(queryString);

        //    using (OdbcConnection connection = new OdbcConnection(connectionString))
        //    {
        //        command.Connection = connection;
        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }


            context.product.Remove(product);
            context.SaveChanges();
        }

        public void DeleteExcel(Product product)
        {
            string path = "..\\Store\\wwwroot\\Bd.xlsx";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite);



            //string xsltPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data"), fileName);

            var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheet(1);
            

            worksheet.Cell(product.Id, 1).SetValue("");
            worksheet.Cell(product.Id, 2).SetValue("");
            worksheet.Cell(product.Id, 3).SetValue("");
            worksheet.Cell(product.Id, 4).SetValue("");
            worksheet.Cell(product.Id, 5).SetValue("");
            worksheet.Cell(product.Id, 6).SetValue("");
            worksheet.Cell(product.Id, 7).SetValue("");
            worksheet.Cell(product.Id, 8).SetValue("");
            worksheet.Cell(product.Id, 9).SetValue("");

            workbook.Save();

            stream.Close();
        }
        
        public void Modified(Product product)
        { 
        //    string queryString =
        //"SET TRANSACTION ISOLATION LEVEL READ COMMITTED;\n" +
        //"BEGIN TRANSACTION\n" +
        //"UPDATE Product SET ProviderName = ('" + product.ProviderName + "'), Description = ('" + product.Description + "'), ModificationData = " +
        //"('" + product.ModificationData.Year.ToString() + "." + product.ModificationData.Month.ToString() + "." + product.ModificationData.Day.ToString() + " " + product.ModificationData.TimeOfDay.ToString() + "')," +
        //"Manager = ('" + product.Manager + "'), Quantity = ('" + product.Quantity + "'), Amount = ('" + product.Amount + "')," +
        //"City = ('" + product.City + "') WHERE ID = ('" + product.Id + "')\n" +
        //"COMMIT TRANSACTION";

        //    OdbcCommand command = new OdbcCommand(queryString);

        //    using (OdbcConnection connection = new OdbcConnection(connectionString))
        //    {
        //        command.Connection = connection;
        //        connection.Open();
        //        command.ExecuteNonQuery();
        //    }

            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void ModifiedExcel(Product product)
        {
            string path = "..\\Store\\wwwroot\\Bd.xlsx";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite);



            //string xsltPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data"), fileName);

            var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RowsUsed();
            var data = DateTime.Now;

            worksheet.Cell(product.Id, 1).SetValue(product.Id);
            worksheet.Cell(product.Id, 2).SetValue(product.ProviderName);
            worksheet.Cell(product.Id, 3).SetValue(product.Description);
            worksheet.Cell(product.Id, 4).SetValue(product.CreationData);
            worksheet.Cell(product.Id, 5).SetValue(data);
            worksheet.Cell(product.Id, 6).SetValue(product.Manager);
            worksheet.Cell(product.Id, 7).SetValue(product.Quantity);
            worksheet.Cell(product.Id, 8).SetValue(product.Amount);
            worksheet.Cell(product.Id, 9).SetValue(product.City);

            workbook.Save();

            stream.Close();
        }

    }
}
