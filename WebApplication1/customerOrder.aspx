<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customerOrder.aspx.cs" Inherits="WebApplication1.customerOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div align="center">
        <h3>Table No: <asp:Label ID="lblTableNo" runat="server"></asp:Label></h3>
    </div>
    <asp:GridView ID="gvOrder" Width="70%" runat="server" RowStyle-Font-Bold="true" HeaderStyle-Font-Bold="true" OnRowCommand="gvOrder_RowCommand" BorderWidth="4px" BorderColor="#dbddff" AutoGenerateColumns="false" Height="100%">
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="40%" HeaderText="Menu">
                    <ItemTemplate>
                        <div style="display:inline-grid;text-align:center;width:250px;height:150px;" >
								<center><asp:Image runat="server" ID="imgRest" Width="130px" Height="130px" ImageUrl='<%#Eval("path") %>' />
									 </center>
								<asp:Label runat="server" ID="lblMenu" Text='<%#Eval("menu") %>'></asp:Label>
							</div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="category" HeaderText="Category" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="price" HeaderText="Price" HeaderStyle-Width="20%" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQty" runat="server" TextMode="Number" Width="20%"></asp:TextBox><br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtQty" ErrorMessage="Invalid quantity" Operator="GreaterThan" 
					        Type="Integer" ValueToCompare="0" ForeColor="Red" /><br />
                        <asp:Button ID="btnAdd" runat="server" Text="Add to Cart" CommandArgument='<%# Eval("id") %>'   CommandName="doAdd"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
     </asp:GridView>
    <br />
    <div align="center">
        <asp:Button ID="btnReceipt" runat="server" Text="View Receipt" OnClick="btnReceipt_Click" Width="25%"/>
        <asp:Button ID="btnCart" runat="server" Text="Cart" OnClick="btnCart_Click" Width="25%"/>
    </div>
    <br />
    <p style="text-align: center;" width="100%" runat="server">
				<asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
			</p>
</asp:Content>
