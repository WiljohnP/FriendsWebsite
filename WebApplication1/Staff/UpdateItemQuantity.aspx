<%@ Page Title="" Language="C#" MasterPageFile="~/Staff/StaffLayout.Master" AutoEventWireup="true" CodeBehind="UpdateItemQuantity.aspx.cs" Inherits="WebApplication1.Staff.UpdateItemQuantity" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <br/>
 <div class="container">

     <div class="row">
         <div class="col-md-3"></div>
         <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-success text-white">
                    <div class="card-title">
                        <h5>Update Item Quantity</h5>
                    </div>
                </div>
                <div class="card-body">
                    
                 <div class="form-group row">
                     <asp:Label ID="lblOrderQuantity" runat="server" Text="Quantity" CssClass="form-control-label col-md-3" Font-Bold="true"></asp:Label>
                         <div class="col-md-9">
                             <asp:TextBox ID="txtItemQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                         </div>
           
                 </div>
                 <div class="form-group row mt-3">
                     <asp:Label ID="lblFulfilOrderMessage" runat="server" Font-Bold="true"></asp:Label>
                 </div>   

                  <div style="display:flex;justify-content:space-between" class="mt-3">
                    <asp:Button ID="btnUpdateOrderQuantity" runat="server" Text="Update"  CssClass="btn btn-success btn-block" OnClick="btnUpdateOrderQuantity_Click"/>
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
