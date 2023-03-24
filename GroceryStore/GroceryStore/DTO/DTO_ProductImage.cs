using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.DTO
{
    internal class DTO_ProductImage
    {
        private string productImageID;
        private string productImageName;
        private string productImageUrl;

        public string ProductImageID { get { return productImageID; } set {  productImageID = value; } }    
        public string ProductImageName { get {  return productImageName; } set {  ProductImageName = value; } } 
        public string ProductImageUrl { get {  return productImageUrl; } set { ProductImageUrl = value; } } 

        public DTO_ProductImage(string id, string name, string url) { 
            this.productImageID = id;
            this.productImageName = name;   
            this.productImageUrl = url;
        }
    }
}
