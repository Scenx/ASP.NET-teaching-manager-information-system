<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Front_Student_Details.aspx.cs" Inherits="shuangyulin.Front.Front_Student_Details" %>
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
    <div class="Body_Title">学生信息管理 》》查看学生信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   学号：</td>
                    <td width="650px;">
                       <asp:Literal ID="studentNumber" runat="server" /></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    姓名：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentName" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    登录密码：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentPassword" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    性别：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentSex" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    所在班级：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentClassNumber" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    出生日期：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentBirthday" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    政治面貌：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentState" runat="server" /></td>
                </tr>
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   学生照片：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td>
                         <asp:Image ID="StudentPhotoImage" runat="server"   Width="200px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    联系电话：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentTelephone" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    学生邮箱：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentEmail" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    联系qq：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentQQ" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    家庭地址：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentAddress" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    附加信息：</td>
                    <td width="650px;">
                         <asp:Literal ID="studentMemo" runat="server" /></td>
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

