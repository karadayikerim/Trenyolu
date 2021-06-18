using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisUygulamasi
{
    public class Products
    {
        private string productName;
        private double productPrice;
        private string productImage;
        private string productCategory;
        private int productAmount;
        private int productID;
        private string productDetails;


        public string productname
        {
            get
            {
                return productName;
            }

            set
            {
                productName = value;
            }
        }

        public double productprice
        {
            get
            {
                return productPrice;
            }

            set
            {
                productPrice = value;
            }
        }

        public string productimage
        {
            get
            {
                return productImage;
            }

            set
            {
                productImage = value;
            }
        }

        public string productcategory
        {
            get
            {
                return productCategory;
            }

            set
            {
                productCategory = value;
            }
        }

        public string productdetails
        {
            get
            {
                return productDetails;
            }

            set
            {
                productDetails = value;
            }
        }

        public int productamount
        {
            get
            {
                return productAmount;
            }

            set
            {
                productAmount = value;
            }
        }

        public int productid
        {
            get
            {
                return productID;
            }

            set
            {
                productID = value;
            }
        }

        public void SetInfo(string productName, double productPrice, string productImage, string productCategory, int productAmount, string productDetails, int productID)
        {
            this.productName = productName;
            this.productPrice = productPrice;
            this.productImage = productImage;
            this.productCategory = productCategory;
            this.productAmount = productAmount;
            this.productDetails = productDetails;
            this.productID = productID;
        }

        public string GetInfo()
        {
            return productImage;
        }
            
    }
}
