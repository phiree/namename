<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="PurchaseList_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>要货单列表</div>

<asp:Repeater runat="server" ID="rptAskList">
<HeaderTemplate><table></HeaderTemplate>
<ItemTemplate>
<tr><td>门店</td><td>时间</td></tr>
</ItemTemplate>
<FooterTemplate></table></FooterTemplate>
</asp:Repeater>
</asp:Content>

