<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
<title>����ѡ�γɼ�����ϵͳ-��ҳ</title>
<link href="css/index.css" rel="stylesheet" type="text/css" /> 
 </head>
<body> 
    <div id="container">
	<div id="banner"><img src="images/logo.gif" /></div>
	<div id="globallink">
		<ul>
			<li><a href="index.aspx">��ҳ</a></li>
			<li><a href="Front_CollegeInfo_List.aspx"  target="OfficeMain">ѧԺ��Ϣ</a></li>
			<li><a href="Front_SpecialFieldInfo_List.aspx"  target="OfficeMain">רҵ��Ϣ</a></li>
			<li><a href="Front_ClassInfo_List.aspx"  target="OfficeMain">�༶��Ϣ</a></li>
			<li><a href="Front_Student_List.aspx"  target="OfficeMain">ѧ����Ϣ</a></li>
			<li><a href="Front_Teacher_List.aspx"  target="OfficeMain">��ʦ��Ϣ</a></li>
			<li><a href="Front_CourseInfo_List.aspx"  target="OfficeMain">�γ���Ϣ</a></li>
			<li><a href="Front_StudentSelectCourseInfo_List.aspx"  target="OfficeMain">ѡ����Ϣ</a></li>
			<li><a href="Front_ScoreInfo_List.aspx"  target="OfficeMain">�ɼ���Ϣ</a></li>
			<li><a href="Front_News_List.aspx"  target="OfficeMain">������Ϣ</a></li>
		</ul>
		<br />
	</div> 
	<div id="main">
	 <iframe id="frame1" src="desk.aspx" name="OfficeMain" width="100%" height="100%" scrolling="yes" marginwidth=0 marginheight=0 frameborder=0 vspace=0 hspace=0 >
	 </iframe>
	</div>
	<div id="footer">
		<p>  &copy;��Ȩ���� <a href="http://www.ncwuhz.cn:8080" target="_blank">�ٷ���վ</a>&nbsp;&nbsp;<a href="Admin/M_UserLogin.aspx" target="_top"><font color=red>ϵͳ��¼</font></a></p>
	</div>
</div>
</body>
</html>
