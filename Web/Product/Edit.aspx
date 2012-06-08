<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Edit.aspx.cs" Inherits="Product_Edit" %>

<%@ Register Src="../uc/UpLoadFile.ascx" TagName="UpLoadFile" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="mainNav">
        产品信息
    </div>
    <div class="ciline">
        <div class="cill">
            类别</div>
        <div class="cilr">
            <asp:DropDownList runat="server" ID="ddlProCate">
            </asp:DropDownList>
            <asp:TextBox runat="server" ID="tbProCate"></asp:TextBox>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            名称</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbName"></asp:TextBox>
        </div>
        <div class="cilr">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                ControlToValidate="tbName"></asp:RequiredFieldValidator>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            单位</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbUnit"></asp:TextBox>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            图片</div>
        <div class="cilr">
            <uc1:UpLoadFile ID="UpLoadFile1" runat="server" />
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            备注</div>
        <div class="cilr">
            <asp:TextBox runat="server" ID="tbMemo" TextMode="MultiLine" Height="90px" Width="261px"></asp:TextBox>
        </div>
    </div>
    <div class="ciline">
        <div class="cill">
            <a href="/Product/Default.aspx">返回</a>
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnSave" OnClick="btnSave_Click" Text="保存" />
        </div>
        <div class="cilr">
            <asp:Button runat="server" ID="btnDelete" Text="删除" OnClick="btnDelete_Click" />
        </div>
    </div>
    <!--价格-->
    <div runat="server" id="divPrice">
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
                            <asp:BoundField DataField="AreaName" HeaderText="区域" />
                            <asp:TemplateField HeaderText="价格">
                                <ItemTemplate>
                                    <asp:TextBox runat="server" ID="tbPrice" areaid='<%#Eval("AreaID") %>' Text='<%# GetPrice(Eval("AreaID")) %>'></asp:TextBox>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="范围：1-1000"
                                        MaximumValue="1000" MinimumValue="1" Type="Double" ControlToValidate="tbPrice"
                                        ValidationGroup="price"></asp:RangeValidator>
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
                &nbsp;
            </div>
            <div class="cilr">
                <asp:Button runat="server" ID="Button1" OnClick="btnSavePrice_Click" Text="保存" ValidationGroup="price" />
            </div>
        </div>
    </div>
    <!--库存上下限-->

      <div runat="server" id="divStoreLimit">
        <div class="ciline">
            <div class="cill">
                &nbsp;
            </div>
            <div class="cilr">
                <div class="cilineforgridview">
                    <asp:GridView ID="gvStoreLimit" runat="server" AutoGenerateColumns="False" BackColor="White"
                        GridLines="Vertical" BorderColor="#C2D3ED" CellPadding="3" BorderStyle="Solid"
                        BorderWidth="1px" HeaderStyle-Height="25" EmptyDataText="没有相关数据">
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <RowStyle Height="25px" BorderColor="#C2D3ED" BorderStyle="Solid" BorderWidth="1px"
                            Wrap="False" />
                        <Columns>
                            <asp:BoundField DataField="ShopName" HeaderText="门店" />
                            <asp:TemplateField HeaderText="价格">
                                <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hfShopID" Value='<%#Eval("ShopID") %>' />
                                   下限: <asp:TextBox runat="server" ID="tbLimitMin" ></asp:TextBox>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="范围：1-1000"
                                        MaximumValue="1000" MinimumValue="1" Type="Double" ControlToValidate="tbLimitMin"
                                        ValidationGroup="price"></asp:RangeValidator>
                                       上限:  <asp:TextBox runat="server" ID="tbLimitMax"></asp:TextBox>
                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="范围：1-1000"
                                        MaximumValue="1000" MinimumValue="1" Type="Double" ControlToValidate="tbLimitMax"
                                        ValidationGroup="price"></asp:RangeValidator>
                                <asp:CompareValidator  runat="server" ControlToValidate="tbLimitMax" ControlToCompare="tbLimitMin" 
                                Operator="GreaterThan" ErrorMessage="上限必须大于下限"></asp:CompareValidator>

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
                &nbsp;
            </div>
            <div class="cilr">
                <asp:Button runat="server" ID="btnLimitSave" OnClick="btnLimitSave_Click" Text="保存" ValidationGroup="price" />
            </div>
        </div>
    </div>

</asp:Content>
