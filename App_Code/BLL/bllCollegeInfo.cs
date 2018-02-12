using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*学院信息业务逻辑层*/
    public class bllCollegeInfo{
        /*添加学院信息*/
        public static bool AddCollegeInfo(ENTITY.CollegeInfo collegeInfo)
        {
            return DAL.dalCollegeInfo.AddCollegeInfo(collegeInfo);
        }

        /*根据collegeNumber获取某条学院信息记录*/
        public static ENTITY.CollegeInfo getSomeCollegeInfo(string collegeNumber)
        {
            return DAL.dalCollegeInfo.getSomeCollegeInfo(collegeNumber);
        }

        /*更新学院信息*/
        public static bool EditCollegeInfo(ENTITY.CollegeInfo collegeInfo)
        {
            return DAL.dalCollegeInfo.EditCollegeInfo(collegeInfo);
        }

        /*删除学院信息*/
        public static bool DelCollegeInfo(string p)
        {
            return DAL.dalCollegeInfo.DelCollegeInfo(p);
        }

        /*根据条件分页查询学院信息*/
        public static System.Data.DataTable GetCollegeInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCollegeInfo.GetCollegeInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的学院信息*/
        public static System.Data.DataSet getAllCollegeInfo()
        {
            return DAL.dalCollegeInfo.getAllCollegeInfo();
        }
    }
}
