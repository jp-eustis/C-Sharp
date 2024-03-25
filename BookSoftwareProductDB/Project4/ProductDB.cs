using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    internal class ProductDB
    {
        private const string dir = @"C:\Users\gabus\OneDrive\Desktop\COS141\Project4\";
        private const string path = dir + "Project4Products.txt";

        public static List<Product> GetProducts()
        {
            // if the directory doesn't exist, create it
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            // create the object for the input stream for a text file
            StreamReader textIn =
                new StreamReader(
                    new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));

            // create the list
            List<Product> products = new List<Product>();

            // read the data from the file and store it in the list
            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine() ?? "";
                string[] columns = row.Split('|');

                // YOU ARE TO WRITE THIS PART AS DOCUMENTED IN THE PROJECT FOUR DESCRIPTION
                if (columns[0] == "Book")
                {
                    Book b = new Book();
                    products.Add(GetBook(b, columns));
                }

                else if (columns[0] == "Software")
                {
                    Software s = new Software();
                    products.Add(GetSoftware(s, columns));
                }
            }
            textIn.Close();
            return products;
        }

        public static Book GetBook(Book b, string[] columns)
        {
            b = (Book)GetProduct(b, columns);
            b.Author = columns[4];
            return b;
        }

        public static Software GetSoftware(Software s, string[] columns)
        {
            s = (Software)GetProduct(s, columns);
            s.Version = columns[4];
            return s;
        }

        public static Product GetProduct(Product p, string[] columns)
        {
            p.Code = columns[1];
            p.Description = columns[2];
            p.Price = columns[3];
            return p;
        }

        public static void SaveProducts(List<Product> products)
        {
            // create the output stream for a text file that exists
            StreamWriter textOut =
                new StreamWriter(
                    new FileStream(path, FileMode.Create, FileAccess.Write));

            // write each product
            foreach (Product product in products)
            {
                if (product is Book b)
                {
                    WriteBook(b, textOut);
                }
                else if (product is Software s)
                {
                    WriteSoftware(s, textOut);
                }
                else
                {
                    textOut.Write("Product" + '|');
                    WriteProduct(product, textOut);
                    textOut.WriteLine();
                    textOut.WriteLine();
                }
            }
            // write the end of the document
            textOut.Close();
        }


        private static void WriteProduct(Product product,
            StreamWriter textOut)
        {
            textOut.Write(product.Code + "|");
            textOut.Write(product.Description + "|");
            textOut.Write(Convert.ToString(product.Price) + "|");
        }
        private static void WriteBook(Book book,
            StreamWriter textOut)
        {
            textOut.Write("Book" + "|");
            WriteProduct(book, textOut);
            textOut.WriteLine(book.Author);
        }

        private static void WriteSoftware(Software software, StreamWriter textOut)
        {
            textOut.Write("Software" + "|");
            WriteProduct(software, textOut);
            textOut.WriteLine(software.Version);

        }

    }
}
