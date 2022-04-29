<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customerUEN.aspx.cs" Inherits="WebApplication1.customerUEN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table id="tableStyle">
		<tr>
			<td>
				<h3>Please input UEN</h3>
			</td>
		</tr>
		<tr>
			<td>
				<asp:TextBox ID="txtUEN" runat="server" Width="100%"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="102%"/>
			</td>
		</tr>
	</table>
</asp:Content>