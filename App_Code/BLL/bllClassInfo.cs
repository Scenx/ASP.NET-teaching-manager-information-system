using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*班级信息业务逻辑层*/
    public class bllClassInfo{
        /*添加班级信息*/
        public static bool AddClassInfo(ENTITY.ClassInfo classInfo)
        {
            return DAL.dalClassInfo.AddClassInfo(classInfo);
        }

        /*根据classNumber获取某条班级信息记录*/
        public static ENTITY.ClassInfo getSomeClassInfo(string classNumber)
        {
            return DAL.dalClassInfo.getSomeClassInfo(classNumber);
        }

        /*更新班级信息*/
        public static bool EditClassInfo(ENTITY.ClassInfo classInfo)
        {
            return DAL.dalClassInfo.EditClassInfo(classInfo);
        }

        /*删除班级信息*/
        public static bool DelClassInfo(string p)
        {
            return DAL.dalClassInfo.DelClassInfo(p);
        }

        /*根据条件分页查询班级信息*/
        public static System.Data.DataTable GetClassInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalClassInfo.GetClassInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的班级信息*/
        public static System.Data.DataSet getAllClassInfo()
        {
            return DAL.dalClassInfo.getAllClassInfo();
        }
    }
}
