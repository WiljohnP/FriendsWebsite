<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customerOrder.aspx.cs" Inherits="WebApplication1.customerOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div align="center">
        <h3>Table No: <asp:Label ID="lblTableNo" runat="server"></asp:Label></h3>
    </div>
    <asp:GridView ID="gvOrder" Width="70%" runat="server" RowStyle-Font-Bold="true" HeaderStyle-Font-Bold="true" OnRowCommand="gvOrder_RowCommand" BorderWidth="4px" BorderColor="#dbddff" AutoGenerateColumns="false" Height="100%" OnSelectedIndexChanged="gvOrder_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="menu" HeaderText="Menu" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="price" HeaderText="Price" HeaderStyle-Width="30%" />
                <asp:BoundField DataField="type" HeaderText="Type" HeaderStyle-Width="30%" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQty" runat="server" TextMode="Number" Width="20%"></asp:TextBox><br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtQty" ErrorMessage="Invalid quantity" Operator="GreaterThan" 
					        Type="Integer" ValueToCompare="0" ForeColor="Red" /><br />
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doAdd"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
     </asp:GridView>
    <br />
    <div align="center">
        <asp:Button ID="btnPayment" runat="server" Text="Payment" OnClick="btnPayment_Click" Width="25%"/>
        <asp:Button ID="btnCart" runat="server" Text="Cart" OnClick="btnCart_Click" Width="25%"/>
    </div>
</asp:Content>
