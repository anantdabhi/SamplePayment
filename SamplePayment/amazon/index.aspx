<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="SamplePayment.amazon.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <%-- <form id="form1" runat="server">
    <div>
    
    </div>
    </form>--%>
    <form action="https://authorize.payments-sandbox.amazon.com/pba/paypipeline" method="post">
  <input type="hidden" name="returnUrl" value="http://localhost/SamplePayment/amazon/sucess.aspx" >
  <input type="hidden" name="ipnUrl" value="http://thehivebuilder.com/paypalPTN.aspx" >
  <input type="hidden" name="processImmediate" value="1" >
  <input type="hidden" name="signatureMethod" value="HmacSHA256" >
  <input type="hidden" name="accessKey" value="11SEM03K88SD016FS1G2" >
  <input type="hidden" name="collectShippingAddress" value="1" >
  <input type="hidden" name="isDonationWidget" value="0" >
  <input type="hidden" name="amazonPaymentsAccountId" value="BYFNYPHVANYJ5CX65X1CKDHEJE9SMFJGSS7L22" >
  <input type="hidden" name="referenceId" value="ref item" >
  <input type="hidden" name="cobrandingStyle" value="logo" >
  <input type="hidden" name="immediateReturn" value="1" >
  <input type="hidden" name="amount" value="USD 10" >
  <input type="hidden" name="description" value="item desc" >
  <input type="hidden" name="abandonUrl" value="http://localhost/SamplePayment/amazon/cancel.aspx" >
  <input type="hidden" name="signatureVersion" value="2" >
  <input type="hidden" name="signature" value="xoqBBCX+QCMtqAnNAsS4ASKp1SVaVh+gkheOs5Q5fTE=" >
  <input type="image" src="http://g-ecx.images-amazon.com/images/G/01/asp/beige_small_paynow_withmsg_whitebg.gif" border="0">
</form>
</body>
</html>
