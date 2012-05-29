<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>么么</title>
    <link href="Css/Login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="login_body">
        <div id="login_div">
            <div id="login_form_div">
                <table width="300px" border="0">
                    <tr>
                        <td style="width: 200px">
                            <table style="text-align: center; margin: 20px 2px 0px 10px">
                                <tr>
                                    <td>
                                        用户名
                                    </td>
                                    <td style="width: 113px">
                                        <input runat="server" id="username" type="text" class="input" style="width: 93px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        密码
                                    </td>
                                    <td style="width: 113px">
                                        <input runat="server" id="password" type="password" class="input" style="width: 93px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left">
                            <asp:ImageButton ID="ImageButton1" runat="server" CssClass="login_btn" ImageUrl="images/login_btn.gif"
                                OnClick="ImageButton1_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="login_footer">
            么么 &copy; 2009 - 2010
        </div>
    </div>
    </form>
</body>
</html>
