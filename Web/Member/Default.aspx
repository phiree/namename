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
<<<<<<< HEAD
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
=======
    <div class="ciline">
        <div class="cill">
            &nbsp;
        </div>
        <div class="cilineforgridview">
            <asp:Table ID="tbUser" runat="server" CellPadding="0" CellSpacing="0" Width="99%"
                BorderStyle="Double" BorderWidth="1px" BorderColor="#AAAAAA" HorizontalAlign="Center">
            </asp:Table>
        </div>
>>>>>>> 0105603c4939a7ef4c2fed520fd30f42c035e8a5
    </div>
</asp:Content>
