using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4
{
    public class Product
    {
        public Product() { }
        public Product(string code, string description, string price) =>
            (this.Code, this.Description, this.Price) = (code, description, price);

        public string Code { get; set; } = "";

        public string Description { get; set; } = "";

        public string Price { get; set; } = "";

        public virtual string GetDisplayText(string sep) => $"{Code}{sep}${Price}{sep}{Description}";


    }
}
