<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Stub.aspx.cs" Inherits="KitchenOnMyPlate.Stub" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:DropDownList ID="slPaymentMode" runat="server" >        
<asp:ListItem value="0">-Select- </asp:ListItem>
<asp:ListItem value="1">NetBanking</asp:ListItem>
<asp:ListItem value="2">Credi Card</asp:ListItem>
<asp:ListItem value="3">Debit Card</asp:ListItem>
<asp:ListItem value="4">CASH CARD</asp:ListItem>
<asp:ListItem value="5">MOBILE PAYMENT</asp:ListItem>
</asp:DropDownList>
    <asp:LinkButton ID="btnPayment" onclick="btnPayment_Click" runat="server">Pay</asp:LinkButton>    


</asp:Content>
