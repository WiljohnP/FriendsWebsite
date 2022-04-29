<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customerPayment.aspx.cs" Inherits="WebApplication1.customerPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div align="center">
        <h3>Table No: <asp:Label ID="lblTableNo" runat="server"></asp:Label></h3>
    </div>
    <asp:GridView ID="gvPayment" Width="70%" runat="server" RowStyle-Font-Bold="true" HeaderStyle-Font-Bold="true" OnRowCommand="gvPayment_RowCommand" BorderWidth="4px" BorderColor="#dbddff" AutoGenerateColumns="false" Height="100%">
            <Columns>
                <asp:BoundField DataField="menu" HeaderText="Menu" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="type" HeaderText="Type" HeaderStyle-Width="30%" />
                <asp:BoundField DataField="price" HeaderText="Unit Price ($)" HeaderStyle-Width="30%" />
                <asp:BoundField DataField="quantity" HeaderText="Order Quantity" HeaderStyle-Width="10%" />
                <asp:BoundField DataField="totPrice" HeaderText="Price ($)" HeaderStyle-Width="30%" />
            </Columns>
     </asp:GridView>
    <br />
    <div align="center">
        <h3>Total Price: $ <asp:Label ID="lblTotalPrice" runat="server"></asp:Label></h3>
    </div>
    <br />
    <div align="center">
        <asp:Button ID="btnMenu" runat="server" Text="Back to Menu" OnClick="btnMenu_Click" Width="25%"/>
    </div>
    <br />
    <div class="container">
        <div class="row">
			<div class="col-50" style="text-align: right;">
				<asp:Label ID="Label4" runat="server" Text="Payment Method:"></asp:Label>
			</div>
          <div class="col-50">
			  <asp:DropDownList ID="ddlPayment" runat="server">
                        <asp:ListItem Value="Credit Card">Credit Card</asp:ListItem>
                        <asp:ListItem Value="Debit Card">Debit Card</asp:ListItem>
                    </asp:DropDownList>
			  </div>
		</div>
        <div class="row">
			<div class="col-50" style="text-align: right;">
				<asp:Label ID="Label2" runat="server" Text="Card Type:"></asp:Label>
			</div>
          <div class="col-50">
			  <asp:DropDownList ID="ddlCardType" runat="server">
                        <asp:ListItem Value="Visa">Visa</asp:ListItem>
                        <asp:ListItem Value="Master">Master</asp:ListItem>
                    </asp:DropDownList>
			  </div>
		</div>
        <div class="row">
			<div class="col-50" style="text-align: right;">
				<asp:Label ID="Label1" runat="server" Text="Card No:"></asp:Label>
			</div>
          <div class="col-50">
              <asp:TextBox ID="txtCardNo" runat="server"></asp:TextBox>
		    </div>
		</div>
        <div class="row">
          <div align="center" class="col-100">
              <asp:Button ID="btnPay" Width="50%" Height="80%" runat="server" OnClick="btnPay_Click" Text="Pay" />
		    </div>
		</div>
        <div class="row">
          <div class="col-100">
              <p id="errorText" width="100%" runat="server" style="display:none;">
				Invalid Card
			</p>
		    </div>
		</div>
    </div>
</asp:Content>
