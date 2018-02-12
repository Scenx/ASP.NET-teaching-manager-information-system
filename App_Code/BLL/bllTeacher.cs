using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*教师信息业务逻辑层*/
    public class bllTeacher{
        /*添加教师信息*/
        public static bool AddTeacher(ENTITY.Teacher teacher)
        {
            return DAL.dalTeacher.AddTeacher(teacher);
        }

        /*根据teacherNumber获取某条教师信息记录*/
        public static ENTITY.Teacher getSomeTeacher(string teacherNumber)
        {
            return DAL.dalTeacher.getSomeTeacher(teacherNumber);
        }

        /*更新教师信息*/
        public static bool EditTeacher(ENTITY.Teacher teacher)
        {
            return DAL.dalTeacher.EditTeacher(teacher);
        }

        /*删除教师信息*/
        public static bool DelTeacher(string p)
        {
            return DAL.dalTeacher.DelTeacher(p);
        }

        /*根据条件分页查询教师信息*/
        public static System.Data.DataTable GetTeacher(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTeacher.GetTeacher(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的教师信息*/
        public static System.Data.DataSet getAllTeacher()
        {
            return DAL.dalTeacher.getAllTeacher();
        }
    }
}
