<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Product_Edit" %>

<%@ Register Src="../uc/UpLoadFile.ascx" TagName="UpLoadFile" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainNav">
        产品信息
    </div>
    <div class="ciline">
        <div class="cill">
            类别</div>
        <div class="cilr">
            <asp:DropDownList runat="server" ID="ddlProCate">
            </asp:DropDownList>
            <asp:TextBox runat="server" ID="tbProCate"></asp:TextBox>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            名称</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbName"></asp:TextBox>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            单位</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbUnit"></asp:TextBox>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            图片</div>
        <div class="cilr">
            <uc1:UpLoadFile ID="UpLoadFile1" runat="server" />
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            备注</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbMemo" TextMode="MultiLine" Height="90px" Width="261px"></asp:TextBox>
        </div>
    </div>
</asp:Content>
