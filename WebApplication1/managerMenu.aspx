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
    <asp:GridView ID="gvMenu" Width="70%" runat="server" RowStyle-Font-Bold="true" HeaderStyle-Font-Bold="true" OnRowCommand="gvMenu_RowCommand" OnRowDataBound="gvMenu_RowDataBound" BorderWidth="4px" BorderColor="#dbddff" AutoGenerateColumns="false" Height="100%">
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="30%" HeaderText="Menu">
                    <ItemTemplate>
                        <div style="border: 1px solid black;display:inline-grid;text-align:center;width:120px;height:120px;" >
								<center><asp:Image runat="server" ID="imgRest" Width="100px" Height="100px" ImageUrl='<%#Eval("path") %>' />
									 </center>
								<asp:Label runat="server" ID="lblMenu" Text='<%#Eval("menu") %>'></asp:Label>
							</div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="price" HeaderText="Price ($)" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="category" HeaderText="Category" HeaderStyle-Width="15%" />
                <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="15%" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument='<%# Eval("id") %>'   CommandName="doUpdate"/>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("id") %>'   CommandName="doDelete"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
     </asp:GridView>
    <br />
    <div align="center">
        <asp:Button ID="btnAddMenu" runat="server" Text="Add Menu" OnClick="btnAddMenu_Click" Width="25%"/>
    </div>
    <br />
    <p style="text-align: center;" width="100%" runat="server">
				<asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
	</p>
</asp:Content>
