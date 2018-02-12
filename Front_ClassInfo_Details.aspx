<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Front_ClassInfo_Details.aspx.cs" Inherits="shuangyulin.Front.Front_ClassInfo_Details" %>
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
    <div class="Body_Title">班级信息管理 》》查看班级信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   班级编号：</td>
                    <td width="650px;">
                       <asp:Literal ID="classNumber" runat="server" /></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    班级名称：</td>
                    <td width="650px;">
                         <asp:Literal ID="className" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    所属专业：</td>
                    <td width="650px;">
                         <asp:Literal ID="classSpecialFieldNumber" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    成立日期：</td>
                    <td width="650px;">
                         <asp:Literal ID="classBirthDate" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    班主任：</td>
                    <td width="650px;">
                         <asp:Literal ID="classTeacherCharge" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    联系电话：</td>
                    <td width="650px;">
                         <asp:Literal ID="classTelephone" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    附加信息：</td>
                    <td width="650px;">
                         <asp:Literal ID="classMemo" runat="server" /></td>
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

