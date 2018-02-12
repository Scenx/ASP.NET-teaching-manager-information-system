<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Front_Student_List.aspx.cs" Inherits="shuangyulin.Front.Front_Student_List" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>学生信息列表</title>
    <link href="Admin/Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Admin/JavaScript/Jquery.js"></script>
   <script src="Admin/JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="Admin/JavaScript/calendar.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">学生信息管理 》》学生信息列表</div>
     <div class="Body_Search">
        学号&nbsp;&nbsp;<asp:TextBox ID="studentNumber" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        姓名&nbsp;&nbsp;<asp:TextBox ID="studentName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        所在班级&nbsp;&nbsp;<asp:DropDownList ID="studentClassNumber" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        出生日期&nbsp;&nbsp; <asp:TextBox ID="studentBirthday"  runat="server" Width="112px" onclick="setDay(this);"></asp:TextBox>&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /> 
    <asp:Repeater ID="RpStudent" runat="server">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>学号</th>
                        <th>姓名</th>
                        <th>性别</th>
                        <th>所在班级</th>
                        <th>出生日期</th>
                        <th>政治面貌</th>
                        <th>学生照片</th>
                        <th>联系电话</th>
                        <th>学生邮箱</th>
                        <th>联系qq</th>
                        <th>详情</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><%#Eval("studentNumber")%> </td>
                <td align="center"><%#Eval("studentName")%> </td>
                <td align="center"><%#Eval("studentSex")%> </td>
                  <td align="center"><%#GetClassInfostudentClassNumber(Eval("studentClassNumber").ToString())%></td>
                  <td align="center"><%# Convert.ToDateTime(Eval("studentBirthday")).ToShortDateString() %></td>
                <td align="center"><%#Eval("studentState")%> </td>
                <td align="center"><img src="Admin\<%#Eval("studentPhoto")%>" width="50px" height="50px" />
                <td align="center"><%#Eval("studentTelephone")%> </td>
                <td align="center"><%#Eval("studentEmail")%> </td>
                <td align="center"><%#Eval("studentQQ")%> </td>
                <td align="center"><a href="Front_Student_Details.aspx?studentNumber=<%#Eval("studentNumber") %>">查看</a>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[首页]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[上一页]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[下一页]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[尾页]</asp:LinkButton>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
    <asp:HiddenField ID="HPageSize" runat="server" Value="3"/>
    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
    </form>
</body>
</html>
