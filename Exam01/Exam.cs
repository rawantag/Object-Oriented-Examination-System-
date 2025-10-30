using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    internal abstract class Exam
    {
        #region Properties
        public int Time_of_exam { get; set; }
        public int No_of_Question { get; set; } 
        public Question[] questionlist { get; set; }
        #endregion


        public abstract void CreateExam();
        public abstract void ShowExam();

    }
}
