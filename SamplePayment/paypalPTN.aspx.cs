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

namespace SamplePayment
{
    public partial class paypalPTN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Post back to either sandbox or live
            string strSandbox = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            string strLive = "https://www.paypal.com/cgi-bin/webscr";
            System.Net.HttpWebRequest req = (HttpWebRequest)WebRequest.Create(strSandbox);

            //Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
            string strRequest = Encoding.ASCII.GetString(param);
            string copy = strRequest;
            strRequest += "&cmd=_notify-validate";
            req.ContentLength = strRequest.Length;

            //for proxy
            //WebProxy proxy = new WebProxy(new Uri("http://url:port#"));
            //req.Proxy = proxy;

            //Send the request to PayPal and get the response
            StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            streamOut.Write(strRequest);
            streamOut.Close();
            StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream());
            string strResponse = streamIn.ReadToEnd();
            streamIn.Close();





            NameValueCollection these_argies = HttpUtility.ParseQueryString(copy);
            string user_email = these_argies["payer_email"];
            string pay_stat = these_argies["payment_status"];







            SqlConnection cn = new SqlConnection("Data Source=fbcmsdatabase.db.8886533.hostedresource.com;Initial Catalog=fbcmsdatabase;User ID=fbcmsdatabase;Password=H1v3bu1ld3r");
            cn.Open();
            SqlCommand cmd = new SqlCommand("insert into paypal values('"+DateTime.Now.ToString()+"','"+strResponse+"','"+"emal:"+user_email+copy+"')",cn);
            cmd.ExecuteNonQuery();
            cn.Close();


            string path =Server.MapPath("~/images/");
            System.IO.File.AppendAllText(path + "paypal.text.txt", "STR REQU=" + copy + "\n" + strResponse.ToString() + DateTime.Now.ToString() + "\n");
            if (strResponse == "VERIFIED")
            {
                
                Response.Write("payment sucess");
                //check the payment_status is Completed
                //check that txn_id has not been previously processed
                //check that receiver_email is your Primary PayPal email
                //check that payment_amount/payment_currency are correct
                //process payment
            }
            else if (strResponse == "INVALID")
            {
                Response.Write("ERRORE" + strResponse.ToString());
                //log for manual investigation
            }
            else
            {
                Response.Write("ERRORE" + strResponse.ToString());  //log response/ipn data for manual investigation
            }



            Response.Write("=====END");
        }
    }
}