<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Front_CollegeInfo_Details.aspx.cs" Inherits="shuangyulin.Front.Front_CollegeInfo_Details" %>
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
    <div class="Body_Title">学院信息管理 》》查看学院信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   学院编号：</td>
                    <td width="650px;">
                       <asp:Literal ID="collegeNumber" runat="server" /></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    学院名称：</td>
                    <td width="650px;">
                         <asp:Literal ID="collegeName" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    成立日期：</td>
                    <td width="650px;">
                         <asp:Literal ID="collegeBirthDate" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    院长姓名：</td>
                    <td width="650px;">
                         <asp:Literal ID="collegeMan" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    联系电话：</td>
                    <td width="650px;">
                         <asp:Literal ID="collegeTelephone" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    附加信息：</td>
                    <td width="650px;">
                         <asp:Literal ID="collegeMemo" runat="server" /></td>
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

