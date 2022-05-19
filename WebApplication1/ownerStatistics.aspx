<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ownerStatistics.aspx.cs" Inherits="WebApplication1.ownerStatistics" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Statistics</h2>
    </div>
    <br/>
    <div align="center">
        <h3>Year: <asp:DropDownList ID="YearDDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="YearDDL_SelectedIndexChanged"></asp:DropDownList></h3>
        <asp:Chart ID="Chart1" runat="server" Height="500px" Width="900px">
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" LegendStyle="Row"/>
            </Legends>
            <Series>
                <asp:Series Name="Default"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BorderWidth="0"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
</asp:Content>
