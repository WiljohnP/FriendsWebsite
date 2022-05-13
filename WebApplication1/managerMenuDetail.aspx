<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="managerMenuDetail.aspx.cs" Inherits="WebApplication1.managerMenuDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div align="center">
        <asp:Button ID="btnMenu" runat="server" Text="Menu List" OnClick="btnMenu_Click" Width="25%"/>
        <asp:Button ID="btnUser" runat="server" Text="User List" OnClick="btnUser_Click" Width="25%"/>
    </div>
    <div>
        <h2>User</h2>
    </div>
    <br/>
    <div class="container">
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Menu Name:
          </div>
			<div class="col-50">
				<asp:HiddenField ID="hfId" runat="server" />
				<asp:TextBox ID="txtMenuName" runat="server"></asp:TextBox>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Image:
          </div>
			<div class="col-50">
				<asp:FileUpload runat="server" ID="FileUpload" />
			  </div>
        </div>
		
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Category:
          </div>
			<div class="col-50">
				<asp:dropdownlist runat="server" id="ddlCategory" Width="100px"> 
					 <asp:listitem text="Main" value="Main" Selected="True"></asp:listitem>
					 <asp:listitem text="Side Dish" value="Side Dish"></asp:listitem>
					 <asp:listitem text="Beverage" value="Beverage"></asp:listitem>
					 <asp:listitem text="Dessert" value="Dessert"></asp:listitem>
				</asp:dropdownlist>
			  </div>
        </div>
        <div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Price ($):
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
				<asp:RegularExpressionValidator ID="TotalCostRegularExpression" runat="server"
                                ErrorMessage="Invalid amount" ControlToValidate="txtPrice"  ForeColor="Red"
								ValidationExpression="^\s*\$?\s*\d{1,3}((,\d{3})*|\d*)(\.\d{2})?\s*$"
					></asp:RegularExpressionValidator>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Status:
          </div>
			<div class="col-50">
				<asp:dropdownlist runat="server" id="ddlStatus" Width="100px"> 
					 <asp:listitem text="Available" value="Available" Selected="True"></asp:listitem>
					 <asp:listitem text="Out of Stock" value="Out of Stock"></asp:listitem>
				</asp:dropdownlist>
			  </div>
        </div>
		<div class="row">
			<div class="col-100" style="text-align: center;">
				<asp:Button ID="btnSubmit"  CssClass="textWidth" OnClick="btnSubmit_Click" runat="server"  Width="50%" Text="Create" />
			</div>
			<p style="text-align: center;" width="100%" runat="server">
				<asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
			</p>
		</div>
   </div>
</asp:Content>
