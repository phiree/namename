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
        <div>产品名称:<asp:TextBox ID="tbxProname" runat="server"></asp:TextBox><asp:Button runat="server" ID="btnSearch" Text="搜索" OnClick="btnSearch_Click" /></div>
        <div>
       <asp:RadioButton ClientIDMode="Predictable" AutoPostBack="true" OnCheckedChanged="rblCates_SelectedIndexChanged" GroupName="rblCates" runat="server" ID="cateAll" Text="全部"  /> 
       <asp:RadioButtonList runat="server" ID="rblCates"    RepeatLayout="Flow" AutoPostBack="true" 
                RepeatDirection="Horizontal" 
                onselectedindexchanged="rblCates_SelectedIndexChanged"></asp:RadioButtonList></div>
            <div class="cilineforgridview">
                <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" BackColor="White"
                    GridLines="Vertical" BorderColor="#C2D3ED" CellPadding="3" BorderStyle="Solid"
                    BorderWidth="1px" HeaderStyle-Height="25" EmptyDataText="没有相关数据">
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <RowStyle Height="25px" BorderColor="#C2D3ED" BorderStyle="Solid" BorderWidth="1px"
                        Wrap="False" />
                    <Columns>
                        <asp:BoundField DataField="ProCate" HeaderText="类别" />
                        <asp:HyperLinkField DataNavigateUrlFormatString="/product/edit.aspx?proid={0}"  DataNavigateUrlFields="ProID" DataTextField="Name" HeaderText="名称" />
                        <asp:BoundField DataField="Unit" HeaderText="单位" />
                        <asp:BoundField DataField="Memo" HeaderText="备注" />
                    </Columns>
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" CssClass="cigvp"
                        Font-Size="15px" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle Height="25px" BackColor="#EDF4FC" Font-Bold="True" ForeColor="Black"
                        HorizontalAlign="Center" Wrap="False"></HeaderStyle>
                    <AlternatingRowStyle BackColor="#EDF4FC" />
                </asp:GridView>
            </div>
        <uc:AspNetPager runat="server" ID="pager" onpagechanging="pager_PageChanging">
    </uc:AspNetPager>
        </div>
    </div>
</asp:Content>
