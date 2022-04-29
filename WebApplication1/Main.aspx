<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WebApplication1.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
		<tr>
			<td colspan="2">
				<h3>Please choose</h3>
			</td>
		</tr>
		<tr>
			<td>
				<asp:LinkButton ID="lbtnCustomer" runat="server" style="text-decoration:none" OnClick="lbtnCustomer_Click" Font-Bold="true">
					<img class="btnImage" src="../Images/customer.png" alt="Customer"/>
					<div class="btnDiv">
						Customer
					</div>
				</asp:LinkButton>
			</td>
			<td>
				<asp:LinkButton ID="lbtnStaff" runat="server" style="text-decoration:none" Font-Bold="true">
					<img class="btnImage" src="../Images/staff.png" alt="Staff" />
					<div class="btnDiv">
						Staff
					</div>
				</asp:LinkButton>
			</td>
		</tr>
	</table>
</asp:Content>
