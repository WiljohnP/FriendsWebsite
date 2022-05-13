<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="managerUser.aspx.cs" Inherits="WebApplication1.managerUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div align="center">
        <asp:Button ID="btnMenu" runat="server" Text="Menu List" OnClick="btnMenu_Click" Width="25%"/>
    </div>
    <br />
    <div>
        <h2>User List</h2>
    </div>
    <br/>
    <asp:GridView ID="gvUser" Width="70%" runat="server" RowStyle-Font-Bold="true" HeaderStyle-Font-Bold="true" OnRowCommand="gvUser_RowCommand" OnRowDataBound="gvUser_RowDataBound" BorderWidth="4px" BorderColor="#dbddff" AutoGenerateColumns="false" Height="100%">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="Name" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="staffNumber" HeaderText="Staff No" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="phoneNumber" HeaderText="Contact No" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="10%" />
                <asp:BoundField DataField="roleType" HeaderText="Type" HeaderStyle-Width="10%" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument='<%# Eval("username") %>'  CommandName="doUpdate"/>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("username") %>'  CommandName="doDelete"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
     </asp:GridView>
    <br />
    <div align="center">
        <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" Width="25%"/>
    </div>
    <br />
    <p style="text-align: center;" width="100%" runat="server">
				<asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
	</p>
</asp:Content>
