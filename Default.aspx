<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <script src="http://www.geoplugin.net/javascript.gp" type="text/javascript"></script>
<script src="http://www.google.com/jsapi" type="text/javascript"></script>
<script src="JqoeryScript/JScript.js" type="text/javascript"></script>
    <style type="text/css">
        #gp_amount
        {
            width: 164px;
        }
    </style>
</head>
<body style="background-color: #666633">
    <form id="form1" runat="server" >
    <br />
    <br />
 <div align="center" 
        style="border: thin solid #000080; width: 438px; height: 259px; background-color: #6666FF; position: relative; z-index: inherit; list-style-type: square; table-layout: fixed; border-collapse: inherit; border-spacing: inherit; empty-cells: hide; caption-side: inherit; top: auto;">
        <br />
        <br />
 <table>
 <tr>
 <td>
 Enter Amount:
 </td>
 <td><input type='text' id='gp_amount' size='4' /> </td>
 </tr>
 <tr>
 <td>
 From Currency:
 </td>
 <td><select id="gp_from"></select></td>
 </tr>
 <tr>
 <td>
 To  Currency
 </td>
 <td><select id="gp_to"></select></td>
 </tr>
 </table>
<p><input type='button' onClick='gp_convertIt()' value = 'Convert' /></p>
<div id="gp_converted" align="Center"></div>
 </div>
<script type="text/javascript">    gp_currencySymbols()</script>
    </form>
</body>
</html>
