using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Product
    {
        double _total;
        double _price;

        public Product()
        {
            _total = 0;
            _price = 0;
        }

        public double Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }
    }
}
