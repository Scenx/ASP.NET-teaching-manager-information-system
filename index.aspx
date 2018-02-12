<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
<title>教务选课成绩管理系统-首页</title>
<link href="css/index.css" rel="stylesheet" type="text/css" /> 
 </head>
<body> 
    <div id="container">
	<div id="banner"><img src="images/logo.gif" /></div>
	<div id="globallink">
		<ul>
			<li><a href="index.aspx">首页</a></li>
			<li><a href="Front_CollegeInfo_List.aspx"  target="OfficeMain">学院信息</a></li>
			<li><a href="Front_SpecialFieldInfo_List.aspx"  target="OfficeMain">专业信息</a></li>
			<li><a href="Front_ClassInfo_List.aspx"  target="OfficeMain">班级信息</a></li>
			<li><a href="Front_Student_List.aspx"  target="OfficeMain">学生信息</a></li>
			<li><a href="Front_Teacher_List.aspx"  target="OfficeMain">教师信息</a></li>
			<li><a href="Front_CourseInfo_List.aspx"  target="OfficeMain">课程信息</a></li>
			<li><a href="Front_StudentSelectCourseInfo_List.aspx"  target="OfficeMain">选课信息</a></li>
			<li><a href="Front_ScoreInfo_List.aspx"  target="OfficeMain">成绩信息</a></li>
			<li><a href="Front_News_List.aspx"  target="OfficeMain">新闻信息</a></li>
		</ul>
		<br />
	</div> 
	<div id="main">
	 <iframe id="frame1" src="desk.aspx" name="OfficeMain" width="100%" height="100%" scrolling="yes" marginwidth=0 marginheight=0 frameborder=0 vspace=0 hspace=0 >
	 </iframe>
	</div>
	<div id="footer">
		<p>  &copy;版权所有 <a href="http://www.ncwuhz.cn:8080" target="_blank">官方网站</a>&nbsp;&nbsp;<a href="Admin/M_UserLogin.aspx" target="_top"><font color=red>系统登录</font></a></p>
	</div>
</div>
</body>
</html>
