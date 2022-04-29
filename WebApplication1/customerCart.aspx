<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customerCart.aspx.cs" Inherits="WebApplication1.customerCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div align="center">
        <h3>Table No: <asp:Label ID="lblTableNo" runat="server"></asp:Label></h3>
    </div>
    <asp:GridView ID="gvCart" Width="70%" runat="server" RowStyle-Font-Bold="true" HeaderStyle-Font-Bold="true" OnRowCommand="gvOrder_RowCommand" BorderWidth="4px" BorderColor="#dbddff" AutoGenerateColumns="false" Height="100%">
            <Columns>
                <asp:BoundField DataField="menu" HeaderText="Menu" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="type" HeaderText="Type" HeaderStyle-Width="30%" />
                <asp:BoundField DataField="price" HeaderText="Unit Price ($)" HeaderStyle-Width="30%" />
                <asp:BoundField DataField="totPrice" HeaderText="Price ($)" HeaderStyle-Width="30%" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQty" runat="server" Text='<%# Eval("quantity") %>' TextMode="Number" Width="50%"></asp:TextBox><br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtQty" ErrorMessage="Invalid quantity" Operator="GreaterThan" 
					        Type="Integer" ValueToCompare="0" ForeColor="Red" /><br />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doUpdate"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doCancel"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
     </asp:GridView>
    <br />
    <div align="center">
        <h3>Total Price: $ <asp:Label ID="lblTotalPrice" runat="server"></asp:Label></h3>
    </div>
    <br />
    <div align="center">
        <asp:Button ID="btnMenu" runat="server" Text="Menu" OnClick="btnMenu_Click" Width="25%"/>
        <asp:Button ID="btnConfirm" runat="server" Text="Confirm Order" OnClick="btnConfirm_Click" Width="25%"/>
    </div>
</asp:Content>
