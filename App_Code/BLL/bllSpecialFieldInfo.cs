using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*专业信息业务逻辑层*/
    public class bllSpecialFieldInfo{
        /*添加专业信息*/
        public static bool AddSpecialFieldInfo(ENTITY.SpecialFieldInfo specialFieldInfo)
        {
            return DAL.dalSpecialFieldInfo.AddSpecialFieldInfo(specialFieldInfo);
        }

        /*根据specialFieldNumber获取某条专业信息记录*/
        public static ENTITY.SpecialFieldInfo getSomeSpecialFieldInfo(string specialFieldNumber)
        {
            return DAL.dalSpecialFieldInfo.getSomeSpecialFieldInfo(specialFieldNumber);
        }

        /*更新专业信息*/
        public static bool EditSpecialFieldInfo(ENTITY.SpecialFieldInfo specialFieldInfo)
        {
            return DAL.dalSpecialFieldInfo.EditSpecialFieldInfo(specialFieldInfo);
        }

        /*删除专业信息*/
        public static bool DelSpecialFieldInfo(string p)
        {
            return DAL.dalSpecialFieldInfo.DelSpecialFieldInfo(p);
        }

        /*根据条件分页查询专业信息*/
        public static System.Data.DataTable GetSpecialFieldInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalSpecialFieldInfo.GetSpecialFieldInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的专业信息*/
        public static System.Data.DataSet getAllSpecialFieldInfo()
        {
            return DAL.dalSpecialFieldInfo.getAllSpecialFieldInfo();
        }
    }
}
