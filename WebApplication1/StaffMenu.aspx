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
        <h2>Order List</h2>
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
                <asp:BoundField DataField="tableNum" HeaderText="Table Number" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" HeaderStyle-Width="15%" />
                <asp:BoundField DataField="status" HeaderText="Status" HeaderStyle-Width="15%" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:Button ID="btnUpdate" runat="server" Text="Deliver" CommandArgument='<%# Eval("id") %>'   CommandName="doUpdate"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
     </asp:GridView>
    <br />
    <br />

</asp:Content>
