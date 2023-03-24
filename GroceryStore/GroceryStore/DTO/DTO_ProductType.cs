using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.DTO
{
    internal class DTO_ProductType
    {
        private string productTypeID;
        private string productTypeName;
        private string productDescription;

        public string ProductTypeID { get { return productTypeID; } set { productTypeID = value; } }
        public string ProductTypeName { get {  return productTypeName; } set { productTypeName = value; } } 
        public string ProductDescription { get {  return productDescription; } set { productDescription = value; } }    

        public DTO_ProductType(string id, string name, string descript)
        {
            this.productTypeID = id;
            this.productTypeName = name;
            this.productDescription = descript;
        }
    }
}
