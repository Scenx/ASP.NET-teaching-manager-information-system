<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Front_CourseInfo_List.aspx.cs" Inherits="shuangyulin.Front.Front_CourseInfo_List" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>课程信息列表</title>
    <link href="Admin/Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Admin/JavaScript/Jquery.js"></script>
   <script src="Admin/JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="Admin/JavaScript/calendar.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">课程信息管理 》》课程信息列表</div>
     <div class="Body_Search">
        课程编号&nbsp;&nbsp;<asp:TextBox ID="courseNumber" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        课程名称&nbsp;&nbsp;<asp:TextBox ID="courseName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        上课老师&nbsp;&nbsp;<asp:DropDownList ID="courseTeacher" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" /> 
    <asp:Repeater ID="RpCourseInfo" runat="server">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>课程编号</th>
                        <th>课程名称</th>
                        <th>上课老师</th>
                        <th>上课时间</th>
                        <th>上课地点</th>
                        <th>课程学分</th>
                        <th>详情</th>
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><%#Eval("courseNumber")%> </td>
                <td align="center"><%#Eval("courseName")%> </td>
                  <td align="center"><%#GetTeachercourseTeacher(Eval("courseTeacher").ToString())%></td>
                <td align="center"><%#Eval("courseTime")%> </td>
                <td align="center"><%#Eval("coursePlace")%> </td>
                <td align="center"><%#Eval("courseScore")%> </td>
                <td align="center"><a href="Front_CourseInfo_Details.aspx?courseNumber=<%#Eval("courseNumber") %>">查看</a>
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
