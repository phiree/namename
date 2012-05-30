<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Shop_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainNav">
        门店管理
    </div>
    <div class="ciline">
        <div class="cill">
            &nbsp;
        </div>
        <div class="cilr">
            <a href="/Area/edit.aspx">新增区域</a>
        </div>
        <div class="cilr">
            <a href="/Shop/edit.aspx">新增门店</a>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            &nbsp;
        </div>
        <div class="cilineforgridview">
            <asp:Table ID="tbShop" runat="server" CellPadding="0" CellSpacing="0" Width="99%"
                BorderStyle="Double" BorderWidth="1px" BorderColor="#AAAAAA" HorizontalAlign="Center">
            </asp:Table>
        </div>
    </div>
</asp:Content>
