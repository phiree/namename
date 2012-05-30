<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Member_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainNav">
        人员信息
    </div>
    <div class="ciline">
        <div class="cill">
            用户名</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbUserName"></asp:TextBox>
        </div>
        <div class="cilr">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                ControlToValidate="tbUserName"></asp:RequiredFieldValidator>
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
            门店人员
        </div>
        <div class="cilr">
            <asp:CheckBox runat="server" ID="cbIsShopUser" />
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            权限</div>
        <div class="cilr">
            <asp:CheckBoxList runat="server" ID="cbxRights" RepeatDirection="Horizontal">
            </asp:CheckBoxList>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            <a href="/Member/Default.aspx">返回</a>
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnSave" Text="保存" OnClick="btnSave_Click" />
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnDelete" Text="删除" OnClick="btnDelete_Click" />
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnInitPwd" Text="初始化密码" OnClick="btnInitPwd_Click" />
        </div>
    </div>
</asp:Content>
