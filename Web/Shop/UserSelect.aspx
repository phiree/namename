<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="UserSelect.aspx.cs" Inherits="Shop_UserSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainNav">
        人员选择
    </div>
    <div class="ciline">
        <div class="cill">
        </div>
        <div class="cilr">
            <div class="cilineforgridview">
                <asp:Table ID="tbUserSelect" runat="server" CellPadding="0" CellSpacing="0" Width="99%"
                    BorderStyle="Double" BorderWidth="1px" BorderColor="#AAAAAA" HorizontalAlign="Center">
                </asp:Table>
            </div>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            <a href="/Shop/Edit.aspx?shopid=XX" runat="server" id="aBack">返回</a>
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnSelect" Text="确定" onclick="btnSelect_Click" />
        </div>
    </div>
</asp:Content>
