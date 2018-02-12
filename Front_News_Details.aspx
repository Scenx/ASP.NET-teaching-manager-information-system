<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Front_News_Details.aspx.cs" Inherits="shuangyulin.Front.Front_News_Details" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Admin/Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Admin/JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="Admin/JavaScript/Admin.js"></script>
    <script type="text/javascript" src="Admin/JavaScript/date.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">新闻信息管理 》》查看新闻信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    新闻标题：</td>
                    <td width="650px;">
                         <asp:Literal ID="newsTitle" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    新闻内容：</td>
                    <td width="650px;">
                         <asp:Literal ID="newsContent" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    发布日期：</td>
                    <td width="650px;">
                         <asp:Literal ID="newsDate" runat="server" /></td>
                </tr>
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   新闻图片：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td>
                         <asp:Image ID="NewsPhotoImage" runat="server"   Width="200px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <input type=button onclick="javascript:history.back();" value="返回" /></td>
                </tr>
            </table
    </div>
    </form>
</body>
</html>

