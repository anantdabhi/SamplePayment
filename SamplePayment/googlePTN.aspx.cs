using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using System.Collections.Specialized;

using System.Xml;
using GCheckout.OrderProcessing;
using GCheckout.Util;
using GCheckout.AutoGen;


namespace SamplePayment
{
    public partial class googlePTN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string serial = Request["serial-number"];
            serial = serial.Replace("serial-number=", "");

            GCheckout.OrderProcessing.NotificationHistorySerialNumber ser = new GCheckout.OrderProcessing.NotificationHistorySerialNumber(serial);
            GCheckout.OrderProcessing.NotificationHistoryRequest histroey = new GCheckout.OrderProcessing.NotificationHistoryRequest("417255259260942", "LzWjnZDmrxRiA0UlIUfeSg", GCheckout.EnvironmentType.Sandbox.ToString(), ser);
            
            GCheckout.Util.GCheckoutResponse responce = histroey.Send();

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responce.ResponseXml);
    
            SqlConnection cn = new SqlConnection("Data Source=fbcmsdatabase.db.8886533.hostedresource.com;Initial Catalog=fbcmsdatabase;User ID=fbcmsdatabase;Password=H1v3bu1ld3r");
            cn.Open();
            SqlCommand cmd = new SqlCommand("insertpaypal", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@date", DateTime.Now.ToString()));
            cmd.Parameters.Add(new SqlParameter("@text", responce.ResponseXml));
            cmd.Parameters.Add(new SqlParameter("@respond", Context.Request.ServerVariables["REMOTE_ADDR"].ToString()));
            cmd.ExecuteNonQuery();
            cn.Close();
           
            var ack = new GCheckout.AutoGen.NotificationAcknowledgment();
            ack.serialnumber = serial;
            Response.BinaryWrite(GCheckout.Util.EncodeHelper.Serialize(ack));
            Response.StatusCode = 200;
            Response.End();
        }


        public void GetXMLAsString(string RequestXml)
        {

 switch (EncodeHelper.GetTopElement(RequestXml))
        {
            case "new-order-notification":
                GCheckout.AutoGen.NewOrderNotification N1 =(GCheckout.AutoGen.NewOrderNotification)EncodeHelper.Deserialize(RequestXml,typeof(GCheckout.AutoGen.NewOrderNotification));
                string OrderNumber1 = N1.googleordernumber;
                string ShipToName = N1.buyershippingaddress.contactname;
                string ShipToAddress1 = N1.buyershippingaddress.address1;
                string ShipToAddress2 = N1.buyershippingaddress.address2;
                string ShipToCity = N1.buyershippingaddress.city;
                string ShipToState = N1.buyershippingaddress.region;
                string ShipToZip = N1.buyershippingaddress.postalcode;
               
                string OID = "";
                string Name = "";
                int Quantity = 0;
                decimal Price = 0;
                foreach (GCheckout.AutoGen.Item ThisItem in N1.shoppingcart.items)
                {
                     Name = ThisItem.itemname;
                     Quantity = ThisItem.quantity;
                    Price = ThisItem.unitprice.Value;
                    OID = ThisItem.merchantitemid;
                }
                if (N1.shoppingcart.merchantprivatedata != null && N1.shoppingcart.merchantprivatedata.Any != null && N1.shoppingcart.merchantprivatedata.Any.Length > 0)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(N1.shoppingcart.merchantprivatedata.Any[0].OuterXml);
                    XmlNodeList OrderIDVal = doc.GetElementsByTagName("Orderid");
                    //MerasathiOrderID = OrderIDVal[0].InnerText;
                }

               
               // ObjDA.InertGoogleOrder(MerasathiOrderID);
                break;

            case "risk-information-notification":
                RiskInformationNotification N2 =(RiskInformationNotification)EncodeHelper.Deserialize(RequestXml,typeof(RiskInformationNotification));
                // This notification tells us that Google has authorized theorder and it has passed the fraud check.
                // Use the data below to determine if you want to accept theorder, then start processing it.
                string OrderNumber2 = N2.googleordernumber;
                string AVS = N2.riskinformation.avsresponse;
                string CVN = N2.riskinformation.cvnresponse;
                bool SellerProtection =N2.riskinformation.eligibleforprotection;
                break;
            case "order-state-change-notification":
                OrderStateChangeNotification N3 =(OrderStateChangeNotification)EncodeHelper.Deserialize(RequestXml,typeof(OrderStateChangeNotification));
                // The order has changed either financial or fulfillmentstate in Google's system.
                string OrderNumber3 = N3.googleordernumber;
                string NewFinanceState =N3.newfinancialorderstate.ToString();
                string NewFulfillmentState =N3.newfulfillmentorderstate.ToString();
                string PrevFinanceState =N3.previousfinancialorderstate.ToString();
                string PrevFulfillmentState =N3.previousfulfillmentorderstate.ToString();
                //Google.Insert(OrderNumber3, NewFinanceState,NewFulfillmentState, PrevFinanceState, PrevFulfillmentState);
                break;
            case "charge-amount-notification":
                ChargeAmountNotification N4 =(ChargeAmountNotification)EncodeHelper.Deserialize(RequestXml,typeof(ChargeAmountNotification));
                // Google has successfully charged the customer's creditcard.
                string OrderNumber4 = N4.googleordernumber;
                decimal ChargedAmount = N4.latestchargeamount.Value;
                //GoogelNewOrder.UpdateChargedAmount(ChargedAmount,OrderNumber4);
                //string OrderID =GoogelNewOrder.GetOIDByGoogleOrderNo(OrderNumber4).ToString();
                //Orders.UpdatePaymentStatus("Payment Received fromGoogleCheckout", int.Parse(OrderID));
                break;
            case "refund-amount-notification":
                RefundAmountNotification N5 =(RefundAmountNotification)EncodeHelper.Deserialize(RequestXml,typeof(RefundAmountNotification));
                // Google has successfully refunded the customer's creditcard.
                string OrderNumber5 = N5.googleordernumber;
                decimal RefundedAmount = N5.latestrefundamount.Value;
                //GoogelNewOrder.UpdateRefundAmt(RefundedAmount,OrderNumber5);
                break;
            case "chargeback-amount-notification":
                ChargebackAmountNotification N6 =(ChargebackAmountNotification)EncodeHelper.Deserialize(RequestXml,typeof(ChargebackAmountNotification));
                // A customer initiated a chargeback with his credit cardcompany to get her money back.
                string OrderNumber6 = N6.googleordernumber;
                decimal ChargebackAmount = N6.latestchargebackamount.Value;
                //GoogelNewOrder.UpdateChargeBackAmt(ChargebackAmount,OrderNumber6);
                break;
            default:
                break;
        }
 
     
    }
        }


    
}