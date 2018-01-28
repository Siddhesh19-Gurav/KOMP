<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsControl.ascx.cs" Inherits="PeraFin.NewsControl" %>
<asp:Label ID="lblDate" CssClass="data" runat="server" Visible="false" Text="Label"></asp:Label><br />
<p ID="lblHeader" class="t01" runat="server"></p>   
<div ID="lblDescription" style="margin-left:20px;display:none" runat="server" ></div>
<p class="left">
<a onclick="GetNews('<%=ID%>');"  > 
    <asp:Label ID="lbh" runat="server" Text="..Show More"></asp:Label> </a>
 </p>

<div id="divNews" runat="server" style=" display:none; margin-left:305px;z-index:10; top:457px;height:auto;width:765px; background-color:#F2F2E1;position:absolute" >
     <div id="divResultInner" style=" width: 765px;height: auto; background-color:White ; height:auto; margin:0 auto;" > </div>
</div>

