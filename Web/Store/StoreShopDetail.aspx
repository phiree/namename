<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StoreShopDetail.aspx.cs"
    Inherits="Store_ShopDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
               
                <asp:TemplateField HeaderText="门店">
                    <ItemTemplate>
                        <%#Eval("ShopInfo.ShopName") %></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CurrQty" HeaderText="库存" />
              
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
