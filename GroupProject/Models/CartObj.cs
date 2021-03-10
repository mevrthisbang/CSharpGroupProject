using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupProject.Models
{
    public class CartObj
    {
        public Dictionary<string, CartDTO> cart { get; set; }
        //public List<BagDTO> { get; set; }
        public string username { get; set; }
        public CartObj()
        {
            this.username = username;
            this.cart = new Dictionary<string, CartDTO>();
        }
        public CartObj(string username)
        {
            this.username = username;
            this.cart = new Dictionary<string, CartDTO>();
        }
        public void addToCart(CartDTO dto)
        {
            if (this.cart.ContainsKey(dto.id))
            {
                CartDTO bagCart = new CartDTO();
                if(this.cart.TryGetValue(dto.id, out bagCart))
                {
                    int quantity = bagCart.quantityCart + dto.quantityCart;
                    dto.quantityCart = quantity;
                }
            }
            this.cart.Add(dto.id, dto);
        }

    public void removeCart(string id)
    {
            if (this.cart.ContainsKey(id))
            {
                this.cart.Remove(id);
            }
        }


    public void updateCart(String id, int quantity)
    {
            CartDTO bagCart = new CartDTO();
            if (this.cart.TryGetValue(id, out bagCart))
            {
                bagCart.quantityCart = quantity;
            }   
        }

}
}