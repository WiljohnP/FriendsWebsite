<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customerReceipt.aspx.cs" Inherits="WebApplication1.customerReceipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div align="center">
        <h2>Receipt</h2>
    </div>
    <br />
    <div align="center">
        <h3>Table No: <asp:Label ID="lblTableNo" runat="server"></asp:Label></h3>
    </div>
    <asp:GridView ID="gvReceipt" Width="50%" runat="server" RowStyle-Font-Bold="true" HeaderStyle-Font-Bold="true" BorderWidth="4px" BorderColor="#dbddff" AutoGenerateColumns="false" Height="100%">
            <Columns>
                <asp:BoundField DataField="menu" HeaderText="Menu" HeaderStyle-Width="30%" />
                <asp:BoundField DataField="price" HeaderText="Unit Price ($)" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="quantity" HeaderText="Order Quantity" HeaderStyle-Width="15%" />
                <asp:BoundField DataField="totPrice" HeaderText="Total Price ($)" HeaderStyle-Width="15%" />
                <asp:BoundField DataField="orderState" HeaderText="Status" HeaderStyle-Width="20%" />
            </Columns>
     </asp:GridView>
    <br />
    <div align="center">
        <h3>Grand Total Price: $ <asp:Label ID="lblTotalPrice" runat="server"></asp:Label></h3>
    </div>
    <br />
    <div align="center">
        <asp:Button ID="btnMenu" runat="server" Text="Back to Menu" OnClick="btnMenu_Click" Width="25%"/>
        <asp:Button ID="btnPayment" runat="server" Text="Payment" OnClick="btnPayment_Click" Width="25%"/>
    </div>
    <br />
</asp:Content>
