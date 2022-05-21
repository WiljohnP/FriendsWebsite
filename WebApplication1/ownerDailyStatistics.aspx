<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ownerDailyStatistics.aspx.cs" Inherits="WebApplication1.ownerDailyStatistics" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Button ID="btnYearly" runat="server" Text="Yearly Statistics" OnClick="btnYearly_Click" Width="25%"/>
        <asp:Button ID="btnMonthly" runat="server" Text="Monthly Statistics" OnClick="btnMonthly_Click" Width="25%"/>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h2>Statistics (Daily)</h2>
    </div>
    <br/>
    <div align="center">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h3>Date:
                    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" TextMode="Date" AutoPostBack="True"></asp:TextBox>
                </h3>
                    <asp:Chart ID="Chart1" runat="server" Height="500px" Width="900px" Visible="false">
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
                <div align="center">
                    <h3>Total Earnings: $ <asp:Label ID="lblTotalPrice" runat="server" Text="0.00"></asp:Label></h3>
                </div>
                </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
