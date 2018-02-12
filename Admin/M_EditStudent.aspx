<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditStudent.aspx.cs" Inherits="shuangyulin.Admin.M_EditStudent" %>
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
            var studentNumber = document.getElementById("studentNumber").value;
            if (studentNumber == "") {
                alert("请输入学号...");
                document.getElementById("studentNumber").focus();
                return false;
            }

            var studentName = document.getElementById("studentName").value;
            if (studentName == "") {
                alert("请输入姓名...");
                document.getElementById("studentName").focus();
                return false;
            }

            var studentPassword = document.getElementById("studentPassword").value;
            if (studentPassword == "") {
                alert("请输入登录密码...");
                document.getElementById("studentPassword").focus();
                return false;
            }

            var studentSex = document.getElementById("studentSex").value;
            if (studentSex == "") {
                alert("请输入性别...");
                document.getElementById("studentSex").focus();
                return false;
            }

            var studentBirthday = document.getElementById("studentBirthday").value;
            if (studentBirthday == "") {
                alert("请输入出生日期...");
                document.getElementById("studentBirthday").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">学生信息管理 》》编辑学生信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   学号：</td>
                    <td width="650px;">
                         <input id="studentNumber" type="text"   style="width:300px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入学号！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   姓名：</td>
                    <td width="650px;">
                         <input id="studentName" type="text"   style="width:120px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入姓名！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   登录密码：</td>
                    <td width="650px;">
                         <input id="studentPassword" type="text"   style="width:300px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入登录密码！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   性别：</td>
                    <td width="650px;">
                         <input id="studentSex" type="text"   style="width:20px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入性别！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    所在班级：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="studentClassNumber" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  出生日期：</td>
                    <td width="650px;">
                          <asp:TextBox ID="studentBirthday"  runat="server" Width="112px"
                              onclick="javascript:HS_setDate(this);"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   政治面貌：</td>
                    <td width="650px;">
                         <input id="studentState" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   学生照片：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         图片路径：<asp:TextBox ID="studentPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         上传图片：<asp:FileUpload ID="StudentPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_StudentPhotoUpload" runat="server" Text="上传" OnClick="Btn_StudentPhotoUpload_Click" /></td><td>
                         <asp:Image ID="StudentPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   联系电话：</td>
                    <td width="650px;">
                         <input id="studentTelephone" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   学生邮箱：</td>
                    <td width="650px;">
                         <input id="studentEmail" type="text"   style="width:300px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   联系qq：</td>
                    <td width="650px;">
                         <input id="studentQQ" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   家庭地址：</td>
                    <td width="650px;">
                         <input id="studentAddress" type="text"   style="width:1000px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   附加信息：</td>
                    <td width="650px;">
                         <input id="studentMemo" type="text"   style="width:1000px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnStudentSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnStudentSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

