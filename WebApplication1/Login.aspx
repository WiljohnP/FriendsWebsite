<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            text-align: center;
            height: 40px;
        }
        .auto-style3 {
            height: 40px;
            text-align: left;
        }
        .auto-style4 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tableStyle">
		<tr>
			<td colspan="2">
				<h3>Login</h3>
			</td>
		</tr>
		<tr>
			<td class="auto-style2">
				Username:</td>
			<td class="auto-style3">
				<asp:TextBox ID="TextBox1" runat="server" Width="118px"></asp:TextBox>
			</td>
		</tr>
	    <tr>
			<td class="alignTxtMid">
				Password:</td>
			<td class="auto-style4">
				<asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="118px"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="alignTxtMid" colspan="2">
				<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
			</td>
		</tr>
	</table>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LoginConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT [Username], [Password] FROM [Table]"></asp:SqlDataSource>
</asp:Content>
