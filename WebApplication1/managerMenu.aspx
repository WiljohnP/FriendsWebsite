<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="managerMenu.aspx.cs" Inherits="WebApplication1.managerMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div align="center">
        <asp:Button ID="btnUser" runat="server" Text="User List" OnClick="btnUser_Click" Width="25%"/>
    </div>
    <br />
    <div>
        <h2>Menu List</h2>
    </div>
    <br/>
    <asp:GridView ID="gvMenu" Width="70%" runat="server" RowStyle-Font-Bold="true" HeaderStyle-Font-Bold="true" OnRowCommand="gvMenu_RowCommand" BorderWidth="4px" BorderColor="#dbddff" AutoGenerateColumns="false" Height="100%">
            <Columns>
                <asp:BoundField DataField="menu" HeaderText="Menu" HeaderStyle-Width="30%" />
                <asp:BoundField DataField="price" HeaderText="Price ($)" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="type" HeaderText="Type" HeaderStyle-Width="15%" />
                <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="15%" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doUpdate"/>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Container.DataItemIndex %>'   CommandName="doDelete"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
     </asp:GridView>
    <br />
    <div align="center">
        <asp:Button ID="btnAddMenu" runat="server" Text="Add Menu" OnClick="btnAddMenu_Click" Width="25%"/>
    </div>
</asp:Content>
