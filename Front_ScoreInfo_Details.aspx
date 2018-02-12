<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Front_ScoreInfo_Details.aspx.cs" Inherits="shuangyulin.Front.Front_ScoreInfo_Details" %>
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
    <div class="Body_Title">成绩信息管理 》》查看成绩信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    学生对象：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentNumber" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    课程对象：</td>
                    <td width="650px;">
                         <asp:Literal ID="courseNumber" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    成绩得分：</td>
                    <td width="650px;">
                         <asp:Literal ID="scoreValue" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    学生评价：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentEvaluate" runat="server" /></td>
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

