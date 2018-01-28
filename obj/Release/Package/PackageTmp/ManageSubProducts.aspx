<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageNews.aspx.cs" ValidateRequest="false" Inherits="PeraFin.ManageNews" Title="Manage News" %>--%>
<%@ Page Title="Manage Sub Products" Language="C#" MasterPageFile="~/Masters/SiteMaster.Master" AutoEventWireup="true"    CodeBehind="ManageSubProducts.aspx.cs" Inherits="KitchenOnMyPlate.Masters.ManageSubProducts" %>
<%@ Register src="~/FileUploadControl.ascx" tagname="FileUploadControl" tagprefix="uc1" %>
<%--<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>--%>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>



<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

   <div class="contact-form_grid" style="float:left; text-align:left">

<%--        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>


 
<script type="text/javascript" src="../Scripts/jsValidation.js"></script>

        <script type="text/javascript">


            $(function () {

                $('.footer').hide();

            });

//            function fileValidation(FileID) {
//                if ($('#' + FileID).val() == '') {
//                    alert("No File Choosen.");
//                    return false;
//                }
//                var ext = $('#' + FileID).val().match(/\.(.+)$/)[1];
//                ext = ext.toLowerCase();
//                switch (ext) {
//                    case 'jpg':
//                    case 'jpeg':
//                    case 'png':
//                    case 'ico':
//                    case 'gif':
//                        $('#buttonUpload').attr('disabled', false); $('#buttonUploadLogo').attr('disabled', false);
//                        break;
//                    default:
//                        $('#' + FileID).val('');
//                        alert('This is not an allowed file type.');
//                        return false;
//                }
//                return true;
//            }



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
            var Folders = "SubProduct";
            FolderName = "SubProduct";
        



    </script>
    <%--<link href="styles1.css" rel="stylesheet" type="text/css" />--%>

    
    
    <div class="CommonFont" style="width:100%;height:auto; margin:0 auto;"    >

      <div style="width:100%;font-size:25px;font-weight:bold;padding-top:10px;font-family:RobotoBold;color:#4b220c">Manage Sub Products</div>
      <asp:Label runat="server" ForeColor="Red" id="lblMsg"></asp:Label><br />

 

 <div style="width:50%; float:left; height:auto;">
  <div style="width:120px">Main Product</div>
  <div style="width:auto;height:12px;"></div>
    <asp:DropDownList ID="dropMainProducts" runat="server">
        </asp:DropDownList>

    <br />    <br />

    <div style="width:120px">Veg/Non-veg</div>
    <asp:DropDownList ID="drpVegNonVeg" runat="server">
    <asp:ListItem Value="-1">-Select Meal Type-</asp:ListItem>
    <asp:ListItem Value="1">Veg</asp:ListItem>
    <asp:ListItem Value="0">Non-Veg</asp:ListItem>
        </asp:DropDownList>
        <br />    <br />    
    

    
    <div style='clear:both' ></div>
    <div style="width:120px">Price</div>
    <asp:TextBox ID="txtNwsBy" runat="server" CssClass="NumberClass" Width="114px"></asp:TextBox>  <br />  
    <div style='clear:both' ></div>
    <%--<div style="width:120px">Picture Details</div>--%>
    <textarea id ="txtPicDetails" cols="50" rows="5" visible="false" runat="server" ></textarea>    

    <div style="width:120px">Active</div>
    <asp:DropDownList ID="drpActive" runat="server">    
    <asp:ListItem Value="1">Enabled</asp:ListItem>
    <asp:ListItem Value="0">Disabled</asp:ListItem>
        </asp:DropDownList>
        <br />   
 

 </div>

<div style="width:50%; float:left; height:auto;padding-left:30px">
<div style="width:auto">Header</div>
    <textarea id ="txtHeader" style="height:36px"  runat="server" ></textarea>    
    <br />    
    <div style="width:120px">Details</div>
    
    <textarea id ="txtDescription" cols="50" rows="5"  runat="server" ></textarea><br />  
    <div style='clear:both' ></div>

<div style="width:auto">Show in Customized/Non-Customized</div>
    <asp:DropDownList ID="drpCust" runat="server" AutoPostBack="true" 
         onselectedindexchanged="drpCust_SelectedIndexChanged" >
    <asp:ListItem Value="-1">-Select-</asp:ListItem>
    <asp:ListItem Value="1">Non-Customized</asp:ListItem>
    <asp:ListItem Value="0">Customized</asp:ListItem>
    <asp:ListItem Value="2">Both</asp:ListItem>
        </asp:DropDownList>
        <br />  <br />    

    <div style='clear:both' ></div>
    <div style="width:120px">Calories</div>
    <asp:TextBox ID="txtcalories" runat="server" Width="200px"></asp:TextBox>  <br />  

          <div runat="server" id="divCuct" visible="false" style="width:420px">
    <div style="width:120px">Availability</div>    
    Mon <input type="checkbox" runat="server" id="chk1" clientidmode="Static" value="Monday"/> <label for="chk1" ></label>
    Tue <input type="checkbox" runat="server" id="chk2" clientidmode="Static" value="Tuesday"/><label for="chk2" ></label>
    Wed <input type="checkbox" runat="server" id="chk3" clientidmode="Static" value="Wednesday"/><label for="chk3" ></label>
    Thu <input type="checkbox" runat="server" id="chk4" clientidmode="Static" value="Thursday"/><label for="chk4" ></label>
    Fri <input type="checkbox" runat="server" id="chk5" clientidmode="Static" value="Friday"/><label for="chk4" ></label>
    Sat <input type="checkbox" runat="server" id="chk6" clientidmode="Static" value="Saturday"/><label for="chk5" ></label>
    <input type="checkbox" runat="server" visible="false" id="chk7" clientidmode="Static" value="Sunday"/><label for="chk6" ></label>
    <br /><br />

    <div style="width:auto">Show in Customized list on Page?</div>    
    Show  <input type="checkbox" runat="server" id="chkShowCOP" checked="checked" clientidmode="Static" value="Show"/> <label for="chkShowCOP" ></label>
    <br /><br />
    <div style="width:auto">Varity</div>
    <textarea id="txtVarity" style="height:36px"  runat="server" ></textarea>    
    <br />    

    </div>    
           <div style='clear:both' ></div>
</div>

   
      <!--News Pic Start-->   
 <div id="divCompanyLogo" style="float:left;width:300px;height:300px;display:none" >
  <script type="text/javascript">

   
</script>
       <span style='font-weight:bold; margin-top:6px;' >Product Image</span>
         <div style="background-color:#F5F5ED" id="ltrlImage"></div>
       <uc1:FileUploadControl ID="FileUploadControl1" UploadInFolder="SubProduct"  runat="server" />

 </div>  
 <!--News Pic End--> 
    
    <div style='clear:both' ></div>
    <br/>
    

   
<%--    <CKEditor:CKEditorControl ID="txtDescription"  BasePath="~/ckeditor" runat="server" UIColor="#BFEE62" Language="de" EnterMode="BR">
</CKEditor:CKEditorControl>--%>




    
    <asp:HiddenField ID="hdnImageNws" ClientIDMode="Static" runat="server" />
      

        <br style="clear:both"  />
        <asp:Button ID="btnSubmit" runat="server" CssClass="proceed" onclick="Button1_Click"   Text="Submit" />        
        <asp:Button ID="btnNew" runat="server" Visible="false" Text="Create New" 
            onclick="btnNew_Click" />
    <br style="clear:both"  />
        
    
    <br /><br />

    <asp:GridView ID="GridNews" Width="100%"  runat="server"         
        onselectedindexchanging="GridNews_SelectedIndexChanging" 
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