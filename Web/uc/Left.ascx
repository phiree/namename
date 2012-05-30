<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left.ascx.cs" Inherits="uc_left" %>
<div id="b1" class="cleftbox">
    <div class="cleftTit">
        <div id="b10t" class="cleftopen">
        </div>
        <div class="cleftTitText">
            <h3>
                门店销售</h3>
        </div>
    </div>
    <div id="b10">
        <ul>
            <li id="b1001" class="cli" onmouseover="LeftOnOver('b10','01');" onmouseout="LeftOnLeave('b10','01');">
                <a href="DutyBegin.aspx">当班</a></li>
        </ul>
    </div>
</div>
<div class="cleftupdownline">
</div>
<div id="b5" class="cleftbox">
    <div class="cleftTit">
        <div id="Div3" class="cleftopen">
        </div>
        <div class="cleftTitText">
            <h3>
                查询统计</h3>
        </div>
    </div>
    <div id="b50">
        <ul>
            <li id="b5003" class="cli" onmouseover="LeftOnOver('b50','03');" onmouseout="LeftOnLeave('b50','03');">
                <a href="DutyEndNull.aspx">未交班情况</a> </li>
        </ul>
    </div>
</div>
<div class="cleftupdownline">
</div>
<div id="b3" class="cleftbox">
    <div class="cleftTit">
        <div id="b30t" class="cleftopen">
        </div>
        <div class="cleftTitText">
            <h3>
                仓库管理</h3>
        </div>
    </div>
    <div id="b30">
        <ul>
            <li id="b3001" class="cli" onmouseover="LeftOnOver('b30','01');" onmouseout="LeftOnLeave('b30','01');">
                <a href="BillImport.aspx">入库</a> </li>
        </ul>
    </div>
</div>
<div class="cleftupdownline">
</div>
<div id="b4" class="cleftbox">
    <div class="cleftTit">
        <div id="b40t" class="cleftopen">
        </div>
        <div class="cleftTitText">
            <h3>
                系统管理</h3>
        </div>
    </div>
    <div id="b40">
        <ul>
            <li id="b4001" class="cli" onmouseover="LeftOnOver('b40','01');" onmouseout="LeftOnLeave('b40','01');">
                <a href="/Member/Default.aspx">人员管理</a> </li>
            <li id="b4002" class="cli" onmouseover="LeftOnOver('b40','02');" onmouseout="LeftOnLeave('b40','02');">
                <a href="/Shop/Default.aspx">门店管理</a> </li>
        </ul>
    </div>
</div>
<div class="cleftupdownline">
</div>
<div id="b2" class="cleftbox">
    <div class="cleftTit">
        <div id="b20t" class="cleftopen">
        </div>
        <div class="cleftTitText">
            <h3>
                用户信息</h3>
        </div>
    </div>
    <div id="b20">
        <ul>
            <li id="b2001" class="cli" onmouseover="LeftOnOver('b20','01');" onmouseout="LeftOnLeave('b20','01');">
                <a href="/Member/UserEdit.aspx">个人信息</a> </li>
            <li id="b2002" class="cli" onmouseover="LeftOnOver('b20','02');" onmouseout="LeftOnLeave('b20','02');">
                <a href="/Member/password.aspx">修改密码</a> </li>
        </ul>
    </div>
</div>
<div class="cleftupdownline">
</div>
<script language="javascript" type="text/javascript">
    function LeftOnOver(typeid, _id) {
        document.getElementById(typeid + _id).className = "clihover";
    }

    function LeftOnLeave(typeid, _id) {
        document.getElementById(typeid + _id).className = "cli";
    }
</script>
