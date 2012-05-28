<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Member_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class='ciline'>
        <div class="cill">
            用户名</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbxUserName"></asp:TextBox>
        </div>
    </div>
    <div class='ciline'>
        <div class="cill">
            姓名</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox>
        </div>
    </div>
    <div class='ciline'>
        <div class="cill">
            部门</div>
        <div class="cilr">
            <asp:DropDownList runat="server" ID="ddlDepart">
            </asp:DropDownList>
        </div>
    </div>
    <div class='ciline'>
        <div class="cill">
            电话</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="TextBox3"></asp:TextBox>
        </div>
    </div>
    <div class='ciline'>
        <div class="cill">
            手机</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="TextBox4"></asp:TextBox>
        </div>
    </div>
    <div class='ciline'>
        <div class="cill">
            权限</div>
        <div class="cilr">
            <asp:CheckBoxList runat="server" ID="cbxRights">
            </asp:CheckBoxList>
        </div>
    </div>
    <div class='ciline'>
        <div class="cill">
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnSave" Text="保存" />
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnDelete" Text="删除" />
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnInitPwd" Text="初始化密码" />
        </div>
    </div>
</asp:Content>
