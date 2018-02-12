<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Front_CourseInfo_Details.aspx.cs" Inherits="shuangyulin.Front.Front_CourseInfo_Details" %>
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
    <div class="Body_Title">课程信息管理 》》查看课程信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   课程编号：</td>
                    <td width="650px;">
                       <asp:Literal ID="courseNumber" runat="server" /></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    课程名称：</td>
                    <td width="650px;">
                         <asp:Literal ID="courseName" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    上课老师：</td>
                    <td width="650px;">
                         <asp:Literal ID="courseTeacher" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    上课时间：</td>
                    <td width="650px;">
                         <asp:Literal ID="courseTime" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    上课地点：</td>
                    <td width="650px;">
                         <asp:Literal ID="coursePlace" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    课程学分：</td>
                    <td width="650px;">
                         <asp:Literal ID="courseScore" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    附加信息：</td>
                    <td width="650px;">
                         <asp:Literal ID="courseMemo" runat="server" /></td>
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

