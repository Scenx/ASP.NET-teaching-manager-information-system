<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditTeacher.aspx.cs" Inherits="shuangyulin.Admin.M_EditTeacher" %>
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
            var teacherNumber = document.getElementById("teacherNumber").value;
            if (teacherNumber == "") {
                alert("请输入教师编号...");
                document.getElementById("teacherNumber").focus();
                return false;
            }

            var teacherName = document.getElementById("teacherName").value;
            if (teacherName == "") {
                alert("请输入教师姓名...");
                document.getElementById("teacherName").focus();
                return false;
            }

            var teacherSex = document.getElementById("teacherSex").value;
            if (teacherSex == "") {
                alert("请输入性别...");
                document.getElementById("teacherSex").focus();
                return false;
            }

            var teacherBirthday = document.getElementById("teacherBirthday").value;
            if (teacherBirthday == "") {
                alert("请输入出生日期...");
                document.getElementById("teacherBirthday").focus();
                return false;
            }

            var teacherArriveDate = document.getElementById("teacherArriveDate").value;
            if (teacherArriveDate == "") {
                alert("请输入入职日期...");
                document.getElementById("teacherArriveDate").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">教师信息管理 》》编辑教师信息</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   教师编号：</td>
                    <td width="650px;">
                         <input id="teacherNumber" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入教师编号！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   教师姓名：</td>
                    <td width="650px;">
                         <input id="teacherName" type="text"   style="width:120px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入教师姓名！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   登录密码：</td>
                    <td width="650px;">
                         <input id="teacherPassword" type="text"   style="width:300px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   性别：</td>
                    <td width="650px;">
                         <input id="teacherSex" type="text"   style="width:20px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入性别！</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  出生日期：</td>
                    <td width="650px;">
                          <asp:TextBox ID="teacherBirthday"  runat="server" Width="112px"
                              onclick="javascript:HS_setDate(this);"></asp:TextBox></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  入职日期：</td>
                    <td width="650px;">
                          <asp:TextBox ID="teacherArriveDate"  runat="server" Width="112px"
                              onclick="javascript:HS_setDate(this);"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   身份证号：</td>
                    <td width="650px;">
                         <input id="teacherCardNumber" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   联系电话：</td>
                    <td width="650px;">
                         <input id="teacherPhone" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   教师照片：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         图片路径：<asp:TextBox ID="teacherPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         上传图片：<asp:FileUpload ID="TeacherPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_TeacherPhotoUpload" runat="server" Text="上传" OnClick="Btn_TeacherPhotoUpload_Click" /></td><td>
                         <asp:Image ID="TeacherPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   家庭地址：</td>
                    <td width="650px;">
                         <input id="teacherAddress" type="text"   style="width:1000px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   附加信息：</td>
                    <td width="650px;">
                         <input id="teacherMemo" type="text"   style="width:1000px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnTeacherSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnTeacherSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

