<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="UserEdit.aspx.cs" Inherits="Member_UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainNav">
        个人信息
    </div>
    <div class="ciline">
        <div class="cill">
            用户名
        </div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbusername" ReadOnly="true"></asp:TextBox>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            姓名</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbTrueName"></asp:TextBox>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            部门</div>
        <div class="cilr">
            <asp:DropDownList runat="server" ID="ddlDepart">
            </asp:DropDownList>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            电话</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbTel"></asp:TextBox>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            手机</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbMobile"></asp:TextBox>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            &nbsp;
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
