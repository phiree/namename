<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Area_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="cibody"   id="cibody">
    <div class="mainNav">
        区域信息
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
            区域名称
        </div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbAreaName"></asp:TextBox>
        </div>
        <div class="cilr">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                ControlToValidate="tbAreaName"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ciline" runat="server" id="divSetPrice">
        <div class="cill">
            价格设置
        </div>
        <div class="cilr">
            <asp:DropDownList ID="ddlarea" runat="server">
            </asp:DropDownList>
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnSetPrice" Text="设置" 
                onclick="btnSetPrice_Click" />
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
  <div class="ciline" runat="server" id="divAreaUser">
        <div class="cill">
            <a href="/Area/UserSelect.aspx?ShopID=XXX" runat="server" id="aSelect">选择采购员</a>
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
                                <a href="#" onclick='DeleteAreaUser("<%# Eval("UserName")%>",this)'>删除</a>
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
    </div>
     <script language="javascript" type="text/javascript" src="/js/jquery-1.4.1.js"></script>
    <script language="javascript" type="text/javascript">
        function DeleteAreaUser(username, btn) {
            $.get("/ajax/AreaUserDelete.ashx?username=" + username, function () {
                var currRowIndex = btn.parentNode.parentNode.rowIndex;
                btn.parentNode.parentNode.parentNode.deleteRow(currRowIndex);
            });
        }
      
        
    </script>
</asp:Content>
