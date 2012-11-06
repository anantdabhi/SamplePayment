<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SamplePayment.paypal.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form method="post" action="https://www.sandbox.paypal.com/cgi-bin/webscr" name="Paypal"
    id="Paypal">
    <input type="hidden" value="_cart" name="cmd">
    <input type="hidden" value="1" name="upload">
    <!-- The following is for aggregated PayPal data instead of itemized -->
    <!--
			<input type="hidden" name="item_name" value="Aggregated Items" />
			<input type="hidden" name="amount" value="34.89" />
			-->
    <!-- The following is for itemized PayPal data instead of the aggregated version -->
    <input type="hidden" value="Product #1" name="item_name_1">
    <input type="hidden" value="13.00" name="amount_1">
    <input type="hidden" value="2" name="quantity_1">
    <input type="hidden" value="6.00" name="shipping_1">
    <input type="hidden" value="1.00" name="handling_1">
    <input type="hidden" value="1.89" name="tax_cart">
    <!-- STANDARD DATA -->
    <input type="hidden" value="johnsm_1339226956_biz@kreative-i.com" name="business">
    <input type="hidden" value="newinvoice04" name="invoice">
    <input type="hidden" value="0" name="no_note">
    <input type="hidden" value="USD" name="currency_code">
    <input type="hidden" value="US" name="lc">
    <input type="hidden" value="http://localhost/SamplePayment/paypalPTN.aspx" name="return">
    <input type="hidden" value="http://localhost/SamplePayment/paypalPTN.aspx" name="cancel_return">
    <input type="hidden" value="johnsm_1339226956_biz@kreative-i.com" name="email">
    <input type="hidden" value="How did you hear about us?" name="cn">
    <input type="submit" value="Submit Payment Info">
    </form>


    <form method='post' action='https://www.sandbox.paypal.com/cgi-bin/webscr' name='Paypal'
    id='Form1'>
    <input type='hidden' value='_cart' name='cmd'>
    <input type='hidden' value='1' name='upload'>
    <input type='hidden' value='test2' name='item_name_1'>
    <input type='hidden' value='21.23'name='amount_1'>
    <input type='hidden' value='2' name='quantity_1'>
    <input type='hidden' value='kljk' name='item_name_2'>
    <input type='hidden' value='7325.20' name='amount_2'>
    <input type='hidden' value='54' name='quantity_2'>
    <input type='hidden' value='test2' name='item_name_3'>
    <input type='hidden' value='21.50' name='amount_3'>
    <input type='hidden' value='2' name='quantity_3'>
    <input type='hidden' value='johnsm_1339226956_biz@kreative-i.com' name='business'>
    <input type='hidden' value='newinvoice04' name='invoice'>
    <input type='hidden' value='0' name='no_note'>
    <input type='hidden' value='USD' name='currency_code'>
    <input type='hidden' value='US' name='lc'>
    <input type='hidden' value='http://localhost/SamplePayment/paypalPTN.aspx' name='return'>
    <input type='hidden' value='http://localhost/SamplePayment/paypalPTN.aspx' name='cancel_return'>
    <input type='hidden' value='johnsm_1339226956_biz@kreative-i.com' name='email'>
    <input type='hidden' value='How did you hear about us?' name='cn'>
    <input type='submit' value='Submit Payment Info'>
    </form>
</body>
</html>
