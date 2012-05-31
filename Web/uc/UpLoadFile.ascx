<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UpLoadFile.ascx.cs" Inherits="uc_UpLoadFile" %>
<div style="width: 100%;">
    <div id="upload" runat="server" style="line-height: 35px; height: 35px; float: left;
        margin-right: 3px; overflow: hidden; width: 100px;">
        <div id="upfile" runat="server">
            <div style="float: left; line-height: 35px;">
                <asp:FileUpload ID="fp" runat="server" Width="95px" CssClass="cnewbutton" />
            </div>
        </div>
    </div>
    <div style="float: left; line-height: 30px; height: 35px; margin-right: 3px;">
        <asp:Button ID="btnUpLoad" runat="server" Text="上传" OnClick="btnUpLoad_Click" CssClass="cnewbutton" /></div>
    <div id="view" runat="server" visible="false" style="line-height: 35px; height: 35px;
        float: left">
        <asp:HyperLink ID="FileView" runat="server" Target="_blank">查看文件</asp:HyperLink>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">删除文件</asp:LinkButton>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    <div style="float: left; line-height: 35px; height: 35px; margin-right: 3px; float: left">
        <asp:Label ID="lb" runat="server" Text="Label"></asp:Label>
    </div>
    <div id="divViewSmall" runat="server" visible="false">
        <%--查看小图片--%>
        <img src="#" height='120px' width='160px' alt="" />
    </div>
</div>
