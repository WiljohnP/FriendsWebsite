<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="customerCart.aspx.cs" Inherits="WebApplication1.customerCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Confirm your orders?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
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
    <asp:GridView ID="gvCart" Width="70%" runat="server" RowStyle-Font-Bold="true" HeaderStyle-Font-Bold="true" OnRowCommand="gvCart_RowCommand" BorderWidth="4px" BorderColor="#dbddff" AutoGenerateColumns="false" Height="100%">
            <Columns>
                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="30%" HeaderText="Menu">
                    <ItemTemplate>
                        <div style="display:inline-grid;text-align:center;width:150px;height:150px;" >
								<center><asp:Image runat="server" ID="imgRest" Width="130px" Height="130px" ImageUrl='<%#Eval("path") %>' />
									 </center>
								<asp:Label runat="server" ID="lblMenu" Text='<%#Eval("menu") %>'></asp:Label>
							</div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="category" HeaderText="Category" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="price" HeaderText="Unit Price ($)" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="totPrice" HeaderText="Total Price ($)" HeaderStyle-Width="20%" />
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                    <ItemTemplate>
                        <asp:TextBox ID="txtQty" runat="server" Text='<%# Eval("quantity") %>' TextMode="Number" Width="50%"></asp:TextBox><br />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtQty" ErrorMessage="Invalid quantity" Operator="GreaterThan" 
					        Type="Integer" ValueToCompare="0" ForeColor="Red" /><br />
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandArgument='<%#Eval("foodid") %>'   CommandName="doUpdate"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%">
                    <ItemTemplate>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandArgument='<%#Eval("foodid") %>'   CommandName="doCancel"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
     </asp:GridView>
    <br />
    <div align="center">
        <h3>Grand Total Price: $ <asp:Label ID="lblTotalPrice" runat="server"></asp:Label></h3>
    </div>
    <br />
    <div align="center">
        <asp:Button ID="btnMenu" runat="server" Text="Menu" OnClick="btnMenu_Click" Width="25%"/>
        <asp:Button ID="btnConfirm" runat="server" Text="Confirm Order" OnClick="btnConfirm_Click" OnClientClick="Confirm()" Width="25%"/>
    </div>
    <br />
    <p style="text-align: center;" width="100%" runat="server">
				<asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
			</p>
</asp:Content>
