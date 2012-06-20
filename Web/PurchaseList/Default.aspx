<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="PurchaseList_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="/js/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="/js/WdatePicker.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    $(function () {

        setdivDateState();
        //选择未 审核时, 时间选择隐藏
        $("#rbl input").click(
        function (e) {
            setdivDateState();
        }
        );
        function setdivDateState() {
            var selectedValue = $("#rbl input:checked").val();
            if (selectedValue == "0") {
                $("#divDate").hide();
            }
            else {
                $("#divDate").show();
            }
        }
    });
</script>
    <div class="cibody" id="cibody">
        <div class="mainNav">
            采购单列表</div>
        <div class="ciline">
            <div class="cill">
                审核状态</div>
            <div class="cilr">
                <asp:RadioButtonList runat="server" ID="rbl" RepeatDirection="Horizontal"  ClientIDMode="Static">
                    <asp:ListItem Value="0" Selected="True">未审核</asp:ListItem>
                    <asp:ListItem Value="1">已审核</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="ciline" id="divDate"  style="display:none;">
            <div class="cill">
                时间范围：
            </div>
            <div class="cilr">
                <input id="BeginDate" runat="server" class="ctextboxdate" name="tbPublishDate" onclick="WdatePicker({el:'ctl00_ContentPlaceHolder1_BeginDate',dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    readonly="readonly" style="width: 145px" type="text" /></div>
            <div class="clinerightdate">
                <img alt="date" onclick="WdatePicker({el:'ctl00_ContentPlaceHolder1_BeginDate',dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    src="/images/date.png" style="cursor: pointer" />
            </div>
            <div class="cilr">
                至</div>
            <div class="cilr">
                <input id="EndDate" runat="server" class="ctextboxdate" name="tbPublishDate" onclick="WdatePicker({el:'ctl00_ContentPlaceHolder1_EndDate',dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    readonly="readonly" style="width: 145px" type="text" /></div>
            <div class="clinerightdate">
                <img alt="date" onclick="WdatePicker({el:'ctl00_ContentPlaceHolder1_EndDate',dateFmt:'yyyy-MM-dd HH:mm:ss'})"
                    src="/images/date.png" style="cursor: pointer" />
            </div>
        </div>
        <div class="ciline">
            <div class="cill">
                &nbsp;</div>
            <div class="cilr">
       <asp:LinkButton runat="server" ID="lbAdd" Text="新增"  OnClick="lbAdd_Click"></asp:LinkButton>     <asp:Button ID="btn" runat="server" Text="确定" OnClick="btn_Click" />
            </div>
        </div>
        <div class="ciline">
            <div class="cill">
                &nbsp;</div>
            <div class="cilr">
                <asp:Repeater runat="server" ID="rptPurList">
                    <HeaderTemplate>
                        <table  style="width:100%" ><tr>
                            <td>
                                采购单号
                            </td>
                            <td>
                                创建时间
                            </td>
                            <td></td>  <td></td>
                            <td>
                                创建者
                            </td>
                            <td>
                                状态
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#Eval("PurBillNo")%>
                            </td>
                            <td>
                              <%#Eval("CrtDate") %>
                            </td>
                            <td><a href="EditAskList.aspx">合并要货单</a></td>
                             <td><a href="EditProduct.aspx">修改产品数量</a></td>
                            <td>
                               <%#Eval("PurUser.TrueName") %>
                            </td>
                             <td>
                               <%#(NameName.Model.Enums.PurchaseState)Eval("State")%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table></FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        </div>
</asp:Content>
