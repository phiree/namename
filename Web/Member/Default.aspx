<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Member_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainNav">
        人员管理
    </div>
    <div class="ciline">
        <div class="cill">
            &nbsp;
        </div>
        <div class="cilr">
            <a href="/Department/edit.aspx">增加部门</a>
        </div>
        <div class="cilr">
            <a href="/Member/edit.aspx">增加用户</a>
        </div>
    </div>

    <div class="ciline">
        <div class="cill">
            &nbsp;
        </div>
        <div class="cilineforgridview">
            <asp:Table ID="tbUser" runat="server" CellPadding="0" CellSpacing="0" Width="99%"
                BorderStyle="Double" BorderWidth="1px" BorderColor="#AAAAAA" HorizontalAlign="Center">
            </asp:Table>
        </div>

    </div>
</asp:Content>
