<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffLayout.Master" AutoEventWireup="true" CodeBehind="ViewCustomerOrderDetails.aspx.cs" Inherits="WebApplication1.Staff.ViewCustomerOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<br/>

 <div class="container">

     <div class="row">
         <div class="col-md-3"></div>
         <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-success text-white">
                    <div class="card-title">
                        <h5>Customer Order Details</h5>
                    </div>
                </div>
                <div class="card-body">
                    <div class="mb-1">
                        <strong>OrderId:</strong>
                        <asp:Label ID="lblOrderId" runat="server"></asp:Label>
                    </div>

                    <div class="mb-1">
                        <strong>MenuOrderId:</strong>
                        <asp:Label ID="lblMenuOrderId" runat="server"></asp:Label>
                    </div>

                    <div class="mb-1">
                        <strong>UEN:</strong>
                        <asp:Label ID="lblUEN" runat="server"></asp:Label>
                    </div>

                     <div class="mb-1">
                        <strong>Category:</strong>
                        <asp:Label ID="lblCategory" runat="server"></asp:Label>
                    </div>
                     <div class="mb-1">
                        <strong>Menu:</strong>
                        <asp:Label ID="lblMenu" runat="server"></asp:Label>
                    </div>
                     <div class="mb-1">
                        <strong>Image:</strong>
                          <asp:Image ID="ImageUrl" runat="server"  Width="50px" Height="50px" />  
                     </div>

                    <div class="mb-1">
                        <strong>Price:</strong>
                        <asp:Label ID="lblPrice" runat="server"></asp:Label>
                    </div>

                    <div class="mb-1">
                        <strong>Quantity:</strong>
                        <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                    </div>

                    <div class="mb-1">
                        <strong>Created Date:</strong>
                        <asp:Label ID="lblCreatedDate" runat="server"></asp:Label>
                    </div>

                    <div class="mb-1">
                        <strong>Modified Date:</strong>
                        <asp:Label ID="lblModifiedDate" runat="server"></asp:Label>
                    </div>
                    <div class="mb-1">
                        <strong>Order Status:</strong>
                        <asp:Label ID="lblOrderState" runat="server"></asp:Label>
                    </div>

                  <div class="mt-2">
                    <a href="/Staff/ViewCustomerOrders.aspx" class="btn btn-primary">Go Back</a>  
                  </div>
                </div>
            </div>
         </div>
         <div class="col-md-3">
         </div>
     </div>

    </div>
</asp:Content>
