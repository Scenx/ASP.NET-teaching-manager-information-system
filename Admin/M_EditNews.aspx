<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditNews.aspx.cs" Inherits="shuangyulin.Admin.M_EditNews" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="JavaScript/date.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var newsTitle = document.getElementById("newsTitle").value;
            if (newsTitle == "") {
                alert("请输入新闻标题...");
                document.getElementById("newsTitle").focus();
                return false;
            }

            var newsContent = document.getElementById("newsContent").value;
            if (newsContent == "") {
                alert("请输入新闻内容...");
                document.getElementById("newsContent").focus();
                return false;
            }

            var newsDate = document.getElementById("newsDate").value;
            if (newsDate == "") {
                alert("请输入发布日期...");
                document.getElementById("newsDate").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">新闻信息管理 》》编辑新闻信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   新闻标题：</td>
                    <td width="650px;">
                         <input id="newsTitle" type="text"   style="width:500px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入新闻标题！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   新闻内容：</td>
                    <td width="650px;">
                       <textarea id="newsContent" rows="5" cols="80" runat="server"></textarea> <span class="WarnMes">*</span>请输入新闻内容！</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  发布日期：</td>
                    <td width="650px;">
                          <asp:TextBox ID="newsDate"  runat="server" Width="112px"
                              onclick="javascript:HS_setDate(this);"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   新闻图片：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         图片路径：<asp:TextBox ID="newsPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         上传图片：<asp:FileUpload ID="NewsPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_NewsPhotoUpload" runat="server" Text="上传" OnClick="Btn_NewsPhotoUpload_Click" /></td><td>
                         <asp:Image ID="NewsPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnNewsSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnNewsSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

