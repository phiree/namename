<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="password.aspx.cs" Inherits="Member_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainNav">
        修改密码
    </div>
    <div class="ciline">
        <div class="cill">
            原密码
        </div>
        <div class="cilr">
            <asp:TextBox ID="p1" runat="server" TextMode="Password"></asp:TextBox></div>
        <div class="cilr">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                ControlToValidate="p1"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            新密码
        </div>
        <div class="cilr">
            <asp:TextBox ID="p2" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="cilr">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                ControlToValidate="p2"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            确认新密码
        </div>
        <div class="cilr">
            <asp:TextBox ID="p3" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="cilr">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                ControlToValidate="p3"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            &nbsp;
        </div>
        <div class="cilr">
            <asp:Button ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
