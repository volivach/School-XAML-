using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoadAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadByReflection();
        }

        static void Load()
        {
            var DLL = Assembly.LoadFile(System.IO.Path.GetFullPath(@"../../Modules/FirstDll.dll"));

            int res;

            foreach (Type type in DLL.GetExportedTypes())
            {
                dynamic c = Activator.CreateInstance(type);
                res = c.GetSumm(100, 200);
            }

            Console.ReadLine();
        }

        static void LoadByReflection()
        {
            var DLL = Assembly.LoadFile(System.IO.Path.GetFullPath(@"../../Modules/FirstDll.dll"));
            int res;
            foreach (Type type in DLL.GetExportedTypes())
            {
                var c = Activator.CreateInstance(type);
                res = (int)type.InvokeMember("GetSumm", BindingFlags.InvokeMethod, null, c, new object[] { 100, 200 });
            }

            Console.ReadLine();
        }

        //static void WordCreate()
        //{
        //    // Function to format a field as Currency.
        //    dynamic formatPrice = (decimal x) => { return Strings.Format(x, "c2"); };

        //    // Map the Word column names to the entity column names.
        //    List<ColumnMapping> mapContent = new List<ColumnMapping>();
        //    mapContent.Add(new ColumnMapping("ProductID", "ProductID"));
        //    mapContent.Add(new ColumnMapping("ProductName", "ProductName"));
        //    mapContent.Add(new ColumnMapping("Description", "Description"));
        //    // Format the price as Currency using the Function created above.
        //    mapContent.Add(new ColumnMapping("CurrentPrice", "CurrentPrice", FormatDelegate: formatPrice));
        //    mapContent.Add(new ColumnMapping("ProductImage", "ProductImage"));

        //    // Define the document object.
        //    object doc = Word.GenerateDocument(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Product Catalog.docx", this.Products.SelectedItem, mapContent);
        //    // Export the document object to Word.
        //    Word.Export(doc, "Catalog", 2, false, this.Products, mapContent);
        //}
   
    }
}
