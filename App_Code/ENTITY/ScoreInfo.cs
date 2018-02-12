using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///ScoreInfo 的摘要说明：成绩信息实体
    /// </summary>

    public class ScoreInfo
    {
        /*记录编号*/
        private int _scoreId;
        public int scoreId
        {
            get { return _scoreId; }
            set { _scoreId = value; }
        }

        /*学生对象*/
        private string _studentNumber;
        public string studentNumber
        {
            get { return _studentNumber; }
            set { _studentNumber = value; }
        }

        /*课程对象*/
        private string _courseNumber;
        public string courseNumber
        {
            get { return _courseNumber; }
            set { _courseNumber = value; }
        }

        /*成绩得分*/
        private float _scoreValue;
        public float scoreValue
        {
            get { return _scoreValue; }
            set { _scoreValue = value; }
        }

        /*学生评价*/
        private string _studentEvaluate;
        public string studentEvaluate
        {
            get { return _studentEvaluate; }
            set { _studentEvaluate = value; }
        }

    }
}
