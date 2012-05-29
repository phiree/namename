<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Department_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
部门名称<asp:TextBox  runat="server" ID="tbxDepart"></asp:TextBox>
<asp:Button runat="server" ID="btnAddDepart" Text="保存" OnClick="btnAddDepart_Click" />
</asp:Content>

