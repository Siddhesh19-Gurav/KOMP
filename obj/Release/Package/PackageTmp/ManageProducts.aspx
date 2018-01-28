<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageNews.aspx.cs" ValidateRequest="false" Inherits="PeraFin.ManageNews" Title="Manage News" %>--%>
<%@ Page Title="Manage Products" Language="C#" MasterPageFile="~/Masters/SiteMaster.Master" AutoEventWireup="true"    CodeBehind="ManageProducts.aspx.cs" Inherits="KitchenOnMyPlate.Masters.ManageProducts" %>
<%@ Register src="~/FileUploadControl.ascx" tagname="FileUploadControl" tagprefix="uc1" %>
<%--<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>--%>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>



<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<div class="contact-form_grid" style="float:left; text-align:left">

<asp:HiddenField ID="hdnImageNws" ClientIDMode="Static" runat="server" />

<%--        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>


 
<script type="text/javascript" src="../Scripts/jsValidation.js"></script>

        <script type="text/javascript">


            $(function () {

                $('.footer').hide();

            });

            function fileValidation(FileID) {
                if ($('#' + FileID).val() == '') {
                    alert("No File Choosen.");
                    return false;
                }
                var ext = $('#' + FileID).val().match(/\.(.+)$/)[1];
                ext = ext.toLowerCase();
                switch (ext) {
                    case 'jpg':
                    case 'jpeg':
                    case 'png':
                    case 'ico':
                    case 'gif':
                        $('#buttonUpload').attr('disabled', false); $('#buttonUploadLogo').attr('disabled', false);
                        break;
                    default:
                        $('#' + FileID).val('');
                        alert('This is not an allowed file type.');
                        return false;
                }
                return true;
            }



            ////Pic Upoload
            var PropertyPic = '';

            function PeraImage() {
                var Id;
                var Directory;
                var FileName;
                var Detail;
            }

            var FirstPic = '';
            var splitPic = PropertyPic.split("$");
            var PictureList = new Array();
            var Folders = "Product";
            FolderName = "Product";
        



    </script>
    <%--<link href="styles1.css" rel="stylesheet" type="text/css" />--%>

    
    
    <div class="CommonFont" style="width:100%;height:auto;"    >
    
      <div style="width:100%;font-size:25px;font-weight:bold;padding-top:10px;font-family:RobotoBold;color:#4b220c">Manage Products' Category</div>        
      <asp:Label runat="server" ForeColor="Red" id="lblMsg"></asp:Label><br />



<div style="width:50%; float:left; height:auto;">

 <div id="div1" style="float:left;width:100%;height:auto;" >   
    <div style="width:120px">Header</div>
    <textarea id ="txtHeader" style="height:36px"  runat="server" ></textarea>
    <div style='clear:both' ></div>    
    
 </div>

    
    <div style='clear:both' ></div>
    <br/>
    <div>Details</div>    
    <textarea id ="txtDescription" cols="50" rows="5"  runat="server" ></textarea><br /> 
    <div style='clear:both' ></div>

<div style="width:120px;float:left;height:auto">Show In</div>
<div style="width:320px;float:left;height:auto">
<asp:CheckBox ID="chkTiff" ClientIDMode="Static" runat="server" /> <label for="chkTiff">Tiffin/Dinner</label>
<asp:CheckBox ID="chkCust" ClientIDMode="Static" runat="server" onclick="if( $(this).is(':checked') ){ $('#divCustomized').show(); }else{$('#divCustomized').hide();}" Text="" /> <label for="chkCust">Customized</label>
</div>
<div style='clear:both;height:20px' ></div>        

<div style="width:120px;float:left;height:auto">Active</div>
<div style="width:320px;float:left;height:auto">
    <asp:DropDownList ID="drpActive" runat="server">    
    <asp:ListItem Value="1">Enabled</asp:ListItem>
    <asp:ListItem Value="0">Disabled</asp:ListItem>
        </asp:DropDownList>
        </div>
        
        <div style='clear:both' ></div>

<div id="divCustomized" runat="server" clientidmode="Static"  style="float:left;width:462px;height:auto;display:none" >   
<div style='clear:both;height:20px' ></div>        
    <div style="width:auto">Header for Customized</div>
    <textarea id ="txtHeaderDesc" cols="50" rows="5"  runat="server" ></textarea><br />    <br /><br />
    <div style='clear:both' ></div>    
    
    <div style="width:auto">Details Customized</div>
    <textarea id ="txtDescriptionCus" cols="50" rows="5"  runat="server" ></textarea><br />    <br /><br />
 </div>
 </div>
 <div style="width:50%; float:left; height:auto;padding-left:30px">
 <span style='font-weight:bold; margin-top:6px;' >Product Image <span style="font-size:12px">size : 299X290</span></span>
         <div style="background-color:#F5F5ED" id="ltrlImage"></div>
       <uc1:FileUploadControl ID="FileUploadControl1" UploadInFolder="Product"  runat="server" />       
 </div>
        <br /><br />

    
    
      

        <br style="clear:both"  />
        
        <asp:Button ID="btnSubmit" runat="server" CssClass="proceed" onclick="Button1_Click"   Text="Submit" />       
        <asp:Button ID="btnNew" runat="server" Visible="false" Text="Create New" 
            onclick="btnNew_Click" />
    <br style="clear:both"  />
    <br />

    <asp:GridView ID="GridNews" Width="100%"  runat="server"         
        onselectedindexchanging="GridNews_SelectedIndexChanging" AutoGenerateColumns="False" 
        onrowdatabound="GridNews_RowDataBound"
        onrowdeleting="GridNews_RowDeleting" BackColor="White" BorderColor="#DEDFDE" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
            GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            
            <asp:CommandField HeaderText="Select" ItemStyle-ForeColor="Red" 
                ShowSelectButton="True" >
<ItemStyle ForeColor="Red"></ItemStyle>
            </asp:CommandField>
            <asp:CommandField HeaderText="Delete" ItemStyle-ForeColor="Red" 
                ShowDeleteButton="True" >
<ItemStyle ForeColor="Red"></ItemStyle>
            </asp:CommandField>
            <asp:BoundField  DataField="Id" HeaderText="Id" />
            <asp:BoundField  DataField="Header" HeaderText="Header" />
            <asp:BoundField  DataField="IsActive" HeaderText="Is Active?" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView> 
    <asp:HiddenField ID="hdnID" runat="server" />    

     </div>

        <div style="width:662px;height:40px; margin:0 auto; margin-left:53px">
             <a href="Masters/CMS.aspx" style="margin:0 auto; color:Blue" >Cancel</a>
        </div>

        </div>
        
    
 </asp:Content>