﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CusIndex.aspx.cs" Inherits="WebSystem.Admin.CusIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>信息管理系统--信息管理平台</title>
</head>
<frameset rows="50,*"  frameborder="no" frameborder="1" framespacing="0">
	<frame src="Manage_Top.aspx" noresize="noresize" frameborder="NO" name="topFrame" scrolling="no" marginwidth="0" marginheight="0" target="tops" />
  <frameset cols="184,*"   id="frame">
	<frame src="Cus_Left.aspx" name="leftFrame" noresize="noresize" marginwidth="0" marginheight="0" frameborder="1" scrolling="no" target="lefts" />
	<frame src="Main.aspx" name="main" marginwidth="0" marginheight="0" frameborder="1" scrolling="auto" target="main" />
  </frameset>
<noframes>
  <body></body>
    </noframes>
</html>
