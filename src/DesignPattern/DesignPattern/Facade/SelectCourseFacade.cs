using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Facade
{
    /// <summary>
    /// 选课外观模式（中间件）
    /// </summary>
    public class SelectCourseFacade
    {
        private SelectSystem selectSystem;
        private NotifySystem notifySystem;

        public SelectCourseFacade()
        {
            selectSystem = new SelectSystem();
            notifySystem = new NotifySystem();
        }

        /// <summary>
        /// 选课
        /// </summary>
        /// <param name="courseName"></param>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public bool SelectCourse(string courseName, string studentName)
        {
            if (!selectSystem.CheckAvailable(courseName))
            {
                return false;
            }

            return notifySystem.Notify(studentName);
        }
    }
}
