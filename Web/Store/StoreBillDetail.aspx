<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StoreBillDetail.aspx.cs" Inherits="Store_ProDetail" %>

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
                <asp:BoundField DataField="BillNO" HeaderText="单据号" />
                <asp:BoundField DataField="BillDate" HeaderText="单据时间" />
                <asp:TemplateField>
                <ItemTemplate><%#Eval("ShopInfo.ShopName") %></ItemTemplate>
                
                </asp:TemplateField>
               
                <asp:BoundField DataField="CurrQty" HeaderText="当时库存" />
                <asp:BoundField DataField="ImpQty" HeaderText="入库" />
                <asp:BoundField DataField="ExpQty" HeaderText="出库" />
                <asp:BoundField DataField="ChkQty" HeaderText="盘点" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
