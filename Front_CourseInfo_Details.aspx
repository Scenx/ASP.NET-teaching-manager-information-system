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
    <div class="Body_Title">�γ���Ϣ���� �����鿴�γ���Ϣ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �γ̱�ţ�</td>
                    <td width="650px;">
                       <asp:Literal ID="courseNumber" runat="server" /></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �γ����ƣ�</td>
                    <td width="650px;">
                         <asp:Literal ID="courseName" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �Ͽ���ʦ��</td>
                    <td width="650px;">
                         <asp:Literal ID="courseTeacher" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �Ͽ�ʱ�䣺</td>
                    <td width="650px;">
                         <asp:Literal ID="courseTime" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �Ͽεص㣺</td>
                    <td width="650px;">
                         <asp:Literal ID="coursePlace" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �γ�ѧ�֣�</td>
                    <td width="650px;">
                         <asp:Literal ID="courseScore" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ������Ϣ��</td>
                    <td width="650px;">
                         <asp:Literal ID="courseMemo" runat="server" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <input type=button onclick="javascript:history.back();" value="����" /></td>
                </tr>
            </table
    </div>
    </form>
</body>
</html>

