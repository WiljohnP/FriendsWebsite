<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="managerUserDetail.aspx.cs" Inherits="WebApplication1.managerUserDetail" %>
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
			  User Name:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Staff Number:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtStaffNo" runat="server"></asp:TextBox>
			  </div>
        </div>
        <div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Contact No:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Status:
          </div>
			<div class="col-50">
				<asp:dropdownlist runat="server" id="ddStatus"> 
					 <asp:listitem text="Active" value="1" Selected="True"></asp:listitem>
					 <asp:listitem text="Inactive" value="0"></asp:listitem>
				</asp:dropdownlist>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Type:
          </div>
			<div class="col-50">
				<asp:dropdownlist runat="server" id="ddlType"> 
					 <asp:listitem text="Staff" value="1" Selected="True"></asp:listitem>
					 <asp:listitem text="Manager" value="2"></asp:listitem>
				</asp:dropdownlist>
			  </div>
        </div>
		<div class="row">
          <div class="col-50"  style="text-align: right;" >
			  Password:
          </div>
			<div class="col-50">
				<asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
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
