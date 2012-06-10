<%@ Page Title="" Language="C#" MasterPageFile="~/m.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Store_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>
        门店:<asp:DropDownList AutoPostBack="true" runat="server" ID="ddlShops">
        </asp:DropDownList>
        <asp:TextBox runat="server" ID="tbxkeyword"></asp:TextBox>
        <asp:Button runat="server" OnClick="btnSearch_Click" ID="btnSearch" Text="搜索" />
    </div>
    <div>
        <asp:DataList runat="server" ID="dlShopStore" RepeatColumns="5" RepeatDirection="Horizontal">
            <ItemTemplate>
                <div style="margin:5px; padding:5px; border: 1px solid #555;">
                    <img alt="" style="height:100px;width:100px;" src='/propic/imgsmall/<%#Eval("ProInfo.PicName") %>' />
                    <div>
                   名称: <span style="color:Blue;cursor:pointer; " onclick='Open("<%#Eval("ProInfo.ProID") %>")'> <%#Eval("ShopInfo.ShopName") %></span> 
                    库存:<span style="font-size:large"><%#Eval("CurrQty") %></span> </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:Repeater runat="server" ID="rpt_ShopStore">
            <ItemTemplate>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <script  language="javascript" type="text/javascript">
        //不同查询类型的弹出链接不一样
        var detailType = '<%=DetailType %>';
        function Open(proid) {
            var targetUrl;
            if (detailType == "2") {
                targetUrl = "/store/StoreBillDetail.aspx?proid=" + proid;
            }
            else {
                targetUrl = "/store/StoreShopDetail.aspx?proid=" + proid;
            }
            window.open(targetUrl, "", "top=100, left=200, toolbar=no, menubar=no, scrollbars=no, resizable=no,location=no, status=no");
        }
    </script>
</asp:Content>
