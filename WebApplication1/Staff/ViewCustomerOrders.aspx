<%@ Page Language="C#" MasterPageFile="~/Staff/StaffLayout.Master" AutoEventWireup="true" CodeBehind="ViewCustomerOrders.aspx.cs" Inherits="WebApplication1.Staff.ViewCustomerOrders" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br/>
    <div class="container">
         <div class="card">
    <div class="card-header bg-success text-white">
        <div class="card-title">
          <h5>Customer Orders</h5>
        </div>
    </div>
     <div class="row card-body">
         <div class="col-md-12" style="overflow-y:auto" >
               <asp:GridView ID="gvCustomerOrders" runat="server" CssClass="table table-responsive"
                    AutoGenerateColumns="false"
                    OnRowDataBound="OnRowDataBound"
                    OnRowCommand="OnRowCommand"
                    ShowHeaderWhenEmpty="True" EmptyDataText="No records Found"
                    >
                <Columns>
                    <asp:BoundField DataField="OrderId" HeaderText="OrderId" />
                    <asp:BoundField DataField="uen" HeaderText="UEN" />
                    <asp:BoundField DataField="category" HeaderText="Category" />
                    <asp:BoundField DataField="menu" HeaderText="Menu" />
                    <asp:BoundField DataField="price" HeaderText="Price"  />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
          <%--          <asp:BoundField DataField="orderState" HeaderText="Order State" /> --%>
                    <asp:HyperLinkField
                    HeaderText="FullFillOrder"
                    Text="Full Fill Order"
                    DataNavigateUrlFields="OrderId" 
                    DataNavigateUrlFormatString="/Staff/FullFillOrder.aspx?OrderId={0}" />


                    <asp:HyperLinkField
                    HeaderText="Details"
                    Text="Details" 
                    DataNavigateUrlFields="OrderId" 
                    DataNavigateUrlFormatString="/Staff/ViewCustomerOrderDetails.aspx?OrderId={0}"
                    />

                    <asp:HyperLinkField
                    HeaderText="Edit"
                    Text="Edit" 
                    DataNavigateUrlFields="OrderMenuId" 
                    DataNavigateUrlFormatString="/Staff/UpdateItemQuantity.aspx?OrderMenuId={0}" />
                

                 <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="0%" HeaderText="Delete">
                    <ItemTemplate >
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("OrderMenuId") %>'   CommandName="deleteOrder"/>
                    </ItemTemplate>
                </asp:TemplateField>
                
                </Columns>




            </asp:GridView>

         </div>
     </div>
 </div>
    </div>

</asp:Content>