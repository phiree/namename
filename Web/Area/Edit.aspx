<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Area_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainNav">
        区域信息
    </div>
    <div class="ciline">
        <div class="cill">
            序号
        </div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbOrderNo"></asp:TextBox>
        </div>
        <div class="cilr">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                ControlToValidate="tbOrderNo"></asp:RequiredFieldValidator>
        </div>
        <div class="cilr">
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="序号范围:1-1000"
                MaximumValue="1000" MinimumValue="1" ControlToValidate="tbOrderNo" Type="Integer"></asp:RangeValidator>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            区域名称
        </div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbAreaName"></asp:TextBox>
        </div>
        <div class="cilr">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                ControlToValidate="tbAreaName"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ciline" runat="server" id="divSetPrice">
        <div class="cill">
            价格设置
        </div>
        <div class="cilr">
            <asp:DropDownList ID="ddlarea" runat="server">
            </asp:DropDownList>
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnSetPrice" Text="设置" 
                onclick="btnSetPrice_Click" />
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            <a href="/Shop/Default.aspx">返回</a>
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" />
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnDelete" Text="删除" OnClick="btnDelete_Click" />
        </div>
    </div>
</asp:Content>
