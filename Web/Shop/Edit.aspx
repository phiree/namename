<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Shop_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainNav">
        门店信息
    </div>
    <div class="ciline">
        <div class="cill">
            序号
        </div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbShopNo"></asp:TextBox>
        </div>
        <div class="cilr">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                ControlToValidate="tbShopNo"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            门店名称</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbShopName"></asp:TextBox>
        </div>
        <div class="cilr">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                ControlToValidate="tbShopName"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="cill">
        区域
    </div>
    <div class="cilr">
        <asp:DropDownList ID="ddlarea" runat="server">
        </asp:DropDownList>
    </div>
    <div class="ciline">
        <div class="cill">
            地址</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbAddress"></asp:TextBox>
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
            传真</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbFax"></asp:TextBox>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            总部仓库</div>
        <div class="cilr">
            <asp:CheckBox runat="server" ID="cbIsCenter" />
        </div>
    </div>
    <div class="ciline" runat="server" id="divShopUser">
        <div class="cill">
            <a href="/Shop/UserSelect.aspx?ShopID=XXX" runat="server" id="aSelect">选择店员</a>
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
                        <asp:BoundField DataField="Fax" HeaderText="手机" />
                        <asp:BoundField DataField="IsManage" HeaderText="店长" />
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
    <script language="javascript" type="text/javascript" src="/js/jquery-1.4.1.js" />
    <script language="javascript" type="text/javascript">
        function DeleteShopUser(username, btn) {
            $.get("/ajax/ShopUserDelete.ashx?username=" + username, function () {
                var currRowIndex = btn.parentNode.parentNode.rowIndex;
                btn.parentNode.parentNode.parentNode.deleteRow(currRowIndex);
            });
        }
    </script>
</asp:Content>
