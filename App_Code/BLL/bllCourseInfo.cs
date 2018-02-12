using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*课程信息业务逻辑层*/
    public class bllCourseInfo{
        /*添加课程信息*/
        public static bool AddCourseInfo(ENTITY.CourseInfo courseInfo)
        {
            return DAL.dalCourseInfo.AddCourseInfo(courseInfo);
        }

        /*根据courseNumber获取某条课程信息记录*/
        public static ENTITY.CourseInfo getSomeCourseInfo(string courseNumber)
        {
            return DAL.dalCourseInfo.getSomeCourseInfo(courseNumber);
        }

        /*更新课程信息*/
        public static bool EditCourseInfo(ENTITY.CourseInfo courseInfo)
        {
            return DAL.dalCourseInfo.EditCourseInfo(courseInfo);
        }

        /*删除课程信息*/
        public static bool DelCourseInfo(string p)
        {
            return DAL.dalCourseInfo.DelCourseInfo(p);
        }

        /*根据条件分页查询课程信息*/
        public static System.Data.DataTable GetCourseInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCourseInfo.GetCourseInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的课程信息*/
        public static System.Data.DataSet getAllCourseInfo()
        {
            return DAL.dalCourseInfo.getAllCourseInfo();
        }
    }
}
