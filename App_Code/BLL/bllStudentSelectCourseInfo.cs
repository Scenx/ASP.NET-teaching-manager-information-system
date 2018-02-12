using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*选课信息业务逻辑层*/
    public class bllStudentSelectCourseInfo{
        /*添加选课信息*/
        public static bool AddStudentSelectCourseInfo(ENTITY.StudentSelectCourseInfo studentSelectCourseInfo)
        {
            return DAL.dalStudentSelectCourseInfo.AddStudentSelectCourseInfo(studentSelectCourseInfo);
        }

        /*根据selectId获取某条选课信息记录*/
        public static ENTITY.StudentSelectCourseInfo getSomeStudentSelectCourseInfo(int selectId)
        {
            return DAL.dalStudentSelectCourseInfo.getSomeStudentSelectCourseInfo(selectId);
        }

        /*更新选课信息*/
        public static bool EditStudentSelectCourseInfo(ENTITY.StudentSelectCourseInfo studentSelectCourseInfo)
        {
            return DAL.dalStudentSelectCourseInfo.EditStudentSelectCourseInfo(studentSelectCourseInfo);
        }

        /*删除选课信息*/
        public static bool DelStudentSelectCourseInfo(string p)
        {
            return DAL.dalStudentSelectCourseInfo.DelStudentSelectCourseInfo(p);
        }

        /*根据条件分页查询选课信息*/
        public static System.Data.DataTable GetStudentSelectCourseInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalStudentSelectCourseInfo.GetStudentSelectCourseInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的选课信息*/
        public static System.Data.DataSet getAllStudentSelectCourseInfo()
        {
            return DAL.dalStudentSelectCourseInfo.getAllStudentSelectCourseInfo();
        }
    }
}
