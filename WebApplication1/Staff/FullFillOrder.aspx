<%@ Page Language="C#" MasterPageFile="~/Staff/StaffLayout.Master" AutoEventWireup="true" CodeBehind="FullFillOrder.aspx.cs" Inherits="WebApplication1.Staff.FullFillOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <br/>

 <div class="container">

     <div class="row">
         <div class="col-md-3"></div>
         <div class="col-md-6">
            <div class="card">
                <div class="card-header bg-success text-white">
                    <div class="card-title">
                        <h5>Fullfill Customer Order</h5>
                    </div>
                </div>
                <div class="card-body">
                    
                 <div class="form-group row">
                     <asp:Label ID="lblOrderState" runat="server" Text="Select Order State" CssClass="form-control-label col-md-4" Font-Bold="true"></asp:Label>
                         <div class="col-md-8">
                            <asp:DropDownList ID="ddlOrderState" runat="server" CssClass="form-control"></asp:DropDownList>
                         </div>
           
                 </div>
                 <div class="form-group row mt-3">
                     <asp:Label ID="lblFullfillOrderMessage" runat="server" Font-Bold="true"></asp:Label>
                 </div>   

                  <div style="display:flex;justify-content:space-between" class="mt-3">
                    <asp:Button ID="btnUpdateOrderState" runat="server" Text="Update"  CssClass="btn btn-success btn-block" OnClick="btnFullFillOrder_Click"/>
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
