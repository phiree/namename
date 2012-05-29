<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hint.aspx.cs" Inherits="Hint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="Stylesheet" href="css/hint.css" />
</head>
<body onload="ResetSize();" onresize="ResetSize();">
    <form id="form1" runat="server">
    <div id="toph" style="width: 100%;">
    </div>
    <div class="clogin">
        <div class="ctitle">
            提示信息
        </div>
        <div class="ccontent">
            <div class="cctitle">
                <div runat="server" id="flagimg" class="cctpic">
                </div>
                <div id="mst" runat="server" class="cctt">
                </div>
            </div>
            <div id="question" runat="server" class="ccb">
            </div>
            <div id="yesno" runat="server" class="clink ccbcenter">
                <asp:Button ID="btnYes" runat="server" Text="是" OnClick="btnYes_Click" Width="50px" />
                &nbsp;&nbsp;
                <asp:Button ID="btnNo" runat="server" Text="否" OnClick="btnNo_Click" Width="50px" />
            </div>
            <div id="wrong" runat="server" class="ccb">
            </div>
            <div id="right" runat="server" class="ccb">
            </div>
            <div id="backlink" runat="server" class="clink">
            </div>
        </div>
        
    </div>

    <script language="javascript" type="text/javascript">
        window.onload = function() {
            setInterval("redirect();", 3000);
            ResetSize();
        }
        function redirect() {
            var flag = '<%=flag %>';
            if (flag == "wrong") {
                window.history.back();
            }
            else if (flag == "login") {
                window.location.href = '<%=urlreferrer %>';
            }
            else {
                window.location.href = '<%=urlreferrer %>';
            }
        }

        //当窗口变化时，界面相应调整
        function ResetSize() {
            toph.style.height = (document.documentElement.clientHeight / 2 - 200) + "px";
        }
    </script>

    </form>
</body>
</html>
