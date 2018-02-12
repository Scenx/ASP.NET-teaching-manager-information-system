<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;学院信息管理</div>
        <div class="MenuNote" style="display:none;" id="CollegeInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditCollegeInfo.aspx" target="main">添加学院信息</a></li>
                <li><a href="M_CollegeInfoList.aspx" target="main">学院信息查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;专业信息管理</div>
        <div class="MenuNote" style="display:none;" id="SpecialFieldInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditSpecialFieldInfo.aspx" target="main">添加专业信息</a></li>
                <li><a href="M_SpecialFieldInfoList.aspx" target="main">专业信息查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;班级信息管理</div>
        <div class="MenuNote" style="display:none;" id="ClassInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditClassInfo.aspx" target="main">添加班级信息</a></li>
                <li><a href="M_ClassInfoList.aspx" target="main">班级信息查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;学生信息管理</div>
        <div class="MenuNote" style="display:none;" id="StudentDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditStudent.aspx" target="main">添加学生信息</a></li>
                <li><a href="M_StudentList.aspx" target="main">学生信息查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;教师信息管理</div>
        <div class="MenuNote" style="display:none;" id="TeacherDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditTeacher.aspx" target="main">添加教师信息</a></li>
                <li><a href="M_TeacherList.aspx" target="main">教师信息查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;课程信息管理</div>
        <div class="MenuNote" style="display:none;" id="CourseInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditCourseInfo.aspx" target="main">添加课程信息</a></li>
                <li><a href="M_CourseInfoList.aspx" target="main">课程信息查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;选课信息管理</div>
        <div class="MenuNote" style="display:none;" id="StudentSelectCourseInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditStudentSelectCourseInfo.aspx" target="main">添加选课信息</a></li>
                <li><a href="M_StudentSelectCourseInfoList.aspx" target="main">选课信息查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;成绩信息管理</div>
        <div class="MenuNote" style="display:none;" id="ScoreInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditScoreInfo.aspx" target="main">添加成绩信息</a></li>
                <li><a href="M_ScoreInfoList.aspx" target="main">成绩信息查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;新闻信息管理</div>
        <div class="MenuNote" style="display:none;" id="NewsDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditNews.aspx" target="main">添加新闻信息</a></li>
                <li><a href="M_NewsList.aspx" target="main">新闻信息查询</a></li> 
            </ul>
        </div>
 

         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;客户信息管理</div>
        <div class="MenuNote" style="display:none;" id="Div2" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
          
                <li><a href="M_CusList.aspx" target="main">客户信息列表</a></li>  
            </ul>
        </div>
        
       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
           <li><a href="M_AddUsersInfo.aspx" target="main">添加管理员</a></li>
             <li><a href="M_UsersList.aspx" target="main">管理员列表</a></li>           
            </ul>
        </div>
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
