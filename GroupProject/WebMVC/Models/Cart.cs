using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMVC.BagService;

namespace WebMVC.Models
{
    public class Cart
    {
        public Dictionary<string, Bag> cart { get; set; }
        //public List<BagDTO> { get; set; }
        public string username { get; set; }
        public double Total { get {
                double total=0;
                foreach(Bag bag in cart.Values)
                {
                    total += bag.Quantity * bag.Price;
                }
                return total;
            } }
        public Cart(string username)
        {
            this.username = username;
            this.cart = new Dictionary<string, Bag>();
        }
        public void addToCart(Bag dto)
        {
            if (this.cart.ContainsKey(dto.BagID))
            {
                int quantity = this.cart[dto.BagID].Quantity + 1;
                this.cart[dto.BagID].Quantity= quantity;
                
            }
            else {
                dto.Quantity = 1;
                this.cart.Add(dto.BagID, dto); }
        }

        public void removeCart(string id)
        {
            if (this.cart.ContainsKey(id))
            {
                this.cart.Remove(id);
            }
        }


        public void updateCart(Bag bag)
        {
            this.cart[bag.BagID].Quantity = bag.Quantity;
        }
    }
}