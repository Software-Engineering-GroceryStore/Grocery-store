using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.DTO
{
    internal class DTO_User
    {
        private string idUser;
        private string nameUser;
        private string passwordUser;
        private DTO_ListProduct purchaseHistoryUser;
        private DTO_Cart cart;

        public DTO_User(string idUser, string nameUser, string passwordUser, DTO_ListProduct purchaseHistoryUser, DTO_Cart cart)
        {
            this.idUser = idUser;
            this.nameUser = nameUser;
            this.passwordUser = passwordUser;
            this.purchaseHistoryUser = purchaseHistoryUser;
            this.cart = cart;
        }

        public string IdUser { get {  return idUser; } set { idUser = value; } }

        public string NameUser { get { return nameUser; } set {  nameUser = value; } }  
        public string PasswordUser { get { return passwordUser; } set {  passwordUser = value; } }  
        public DTO_ListProduct PurchaseHistoryUser { get { return purchaseHistoryUser; } set {  purchaseHistoryUser = value; } }    
        public DTO_Cart Cart { get {  return cart; } set { cart = value; } }
    }
}
