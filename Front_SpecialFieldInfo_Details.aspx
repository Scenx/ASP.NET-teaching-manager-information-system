<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Front_SpecialFieldInfo_Details.aspx.cs" Inherits="shuangyulin.Front.Front_SpecialFieldInfo_Details" %>
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
    <div class="Body_Title">专业信息管理 》》查看专业信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   专业编号：</td>
                    <td width="650px;">
                       <asp:Literal ID="specialFieldNumber" runat="server" /></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    专业名称：</td>
                    <td width="650px;">
                         <asp:Literal ID="specialFieldName" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    所在学院：</td>
                    <td width="650px;">
                         <asp:Literal ID="specialCollegeNumber" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    成立日期：</td>
                    <td width="650px;">
                         <asp:Literal ID="specialBirthDate" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    联系人：</td>
                    <td width="650px;">
                         <asp:Literal ID="specialMan" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    联系电话：</td>
                    <td width="650px;">
                         <asp:Literal ID="specialTelephone" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    附加信息：</td>
                    <td width="650px;">
                         <asp:Literal ID="specialMemo" runat="server" /></td>
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

