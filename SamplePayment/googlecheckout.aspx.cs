using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GCheckout.Checkout;
using System.Text;
using GCheckout.OrderProcessing;

namespace SamplePayment
{
    public partial class googlecheckout : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            //GCheckoutButton1 = new GCheckoutButton();
            
            //CheckoutShoppingCartRequest Req = GCheckoutButton1.CreateRequest();
            //Req.AddItem("Snickers", "Packed with peanuts.", 0.75m, 2);
            //GCheckout.Util.GCheckoutResponse Resp = Req.Send();
            //Response.Redirect(Resp.RedirectUrl, true); 
            
            //GCheckout.Util.GCheckoutResponse responce = histroey.Send();
            


            

            //GCheckout.Checkout.CheckoutShoppingCartRequest sad = new GCheckout.Checkout.CheckoutShoppingCartRequest("417255259260942", "LzWjnZDmrxRiA0UlIUfeSg", GCheckout.EnvironmentType.Sandbox, "GBP", 10, false);

          GCheckout.Checkout.CheckoutShoppingCartRequest CheckoutShoppingCartRequest = new GCheckout.Checkout.CheckoutShoppingCartRequest("417255259260942", "LzWjnZDmrxRiA0UlIUfeSg", GCheckout.EnvironmentType.Sandbox, "GBP", 10, false);
            


          GCheckout.Checkout.ShoppingCartItem ShoppingCartItem = new GCheckout.Checkout.ShoppingCartItem();

          
            

          ShoppingCartItem.Description = "itsm one DEsc";
            
          ShoppingCartItem.Name = "item 01 ";
          ShoppingCartItem.Price = Convert.ToDecimal("10.00");
          ShoppingCartItem.Quantity = 1;
          ShoppingCartItem.MerchantPrivateItemData = "<Orderid>10</Orderid>";
        
            

            

          CheckoutShoppingCartRequest.AddItem(ShoppingCartItem); 
        


          GCheckout.Util.GCheckoutResponse Resp = CheckoutShoppingCartRequest.Send();
          Response.Redirect(Resp.RedirectUrl,true);


            //https://417255259260942:LzWjnZDmrxRiA0UlIUfeSg@sandbox.google.com/checkout/api/checkout/v2/requestForm/Merchant/417255259260942



          string serial = Request["serial-number"];

          // do my stuff


        
          var ack = new GCheckout.AutoGen.NotificationAcknowledgment();
          ack.serialnumber = serial;

          StringBuilder stb = new StringBuilder();
          stb.Append(GCheckout.Util.EncodeHelper.Serialize(ack));


//          Response.BinaryWrite(GCheckout.Util.EncodeHelper.Serialize(ack));
  ///        Response.StatusCode = 200;



        }
    }
}