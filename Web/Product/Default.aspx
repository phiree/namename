<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Product_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainNav">
        产品信息
    </div>
    <div class="ciline">
        <div class="cill">
            &nbsp;
        </div>
        <div class="cilr">
            <a href="/Product/Edit.aspx">增加</a>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            &nbsp;
        </div>
        <div class="cilr">
            <div class="cilineforgridview">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                    GridLines="Vertical" BorderColor="#C2D3ED" CellPadding="3" BorderStyle="Solid"
                    BorderWidth="1px" HeaderStyle-Height="25" EmptyDataText="没有相关数据">
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <RowStyle Height="25px" BorderColor="#C2D3ED" BorderStyle="Solid" BorderWidth="1px"
                        Wrap="False" />
                    <Columns>
                        <asp:BoundField DataField="UserName" HeaderText="工号" />
                        <asp:BoundField DataField="TrueName" HeaderText="姓名" />
                        <asp:BoundField DataField="Tel" HeaderText="电话" />
                        <asp:BoundField DataField="Mobile" HeaderText="手机" />
                        <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <a href="#" onclick='DeleteShopUser(<%# Eval("UserName") %>,this)'>删除</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" CssClass="cigvp"
                        Font-Size="15px" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle Height="25px" BackColor="#EDF4FC" Font-Bold="True" ForeColor="Black"
                        HorizontalAlign="Center" Wrap="False"></HeaderStyle>
                    <AlternatingRowStyle BackColor="#EDF4FC" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
