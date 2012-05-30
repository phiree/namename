<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Member_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <a href="/department/edit.aspx">增加部门</a> <a href="/member/edit.aspx">增加用户</a>
    </div>
    <div>
        <asp:Repeater runat="server" ID="rptDepart" 
            onitemdatabound="rptDepart_ItemDataBound">
            <HeaderTemplate>
                <table>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td colspan="3">
                        <a href='/department/edit.aspx?departmentid=<%#Eval("DepartId") %>'>
                            <%#Eval("DepartName") %></a>
                    </td>
                </tr>
                <asp:Repeater runat="server" ID="rptUsers">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <a href='/member/edit.aspx?userid=<%#Eval("username") %>'>
                                    <%#Eval("username") %></a>
                            </td>
                            <td>
                                <%#Eval("Truename") %>
                            </td>
                            <td>
                                <%#Eval("Mobile") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
