using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    internal class MCQQuestion:Question
    {
        #region Constructors
        public MCQQuestion() { }
        public MCQQuestion(String? header, string? body, int mark, int No_of_answers) : base(header, body, mark)
        {
            Answerslist = new Answer[No_of_answers];
            for (int i = 0; i < No_of_answers; i++)
            {
                Console.Write($"please enter answer {i + 1} :");
                string? answer = Console.ReadLine();
                if (answer is not null)
                {
                    Answerslist[i] = new Answer(i + 1, answer);
                }
                answer = null;
            }

            bool isparsed, exists;
            int id;

            do
            {
                Console.Write("please enter the correct answer id :");
                isparsed = int.TryParse(Console.ReadLine(), out id);
                exists = Array.Exists(Answerslist, a => a.AnswerId == id);
            } while (!isparsed || !exists);


            RightAnswer = new Answer(id, Answerslist[id - 1].AnswerTxt);

        }

        #endregion


        public override object Clone()
        {
            MCQQuestion MCQClone = new MCQQuestion
            {
                Header = this.Header,
                Body = this.Body,
                Mark = this.Mark,
            };

            if (Answerslist is not null)
            {
                for (int i = 0; i < Answerslist.Length; i++)
                {
                    MCQClone.Answerslist[i] = (Answer)Answerslist[i].Clone();
                }

            }
            MCQClone.RightAnswer = (Answer)this.RightAnswer.Clone();
            return MCQClone;
        }

        public override void DisplayQuestionDetails()
        {
            Console.WriteLine("---------------------MCQ Question-------------------");
            Console.WriteLine($"Header: {Header}");
            Console.WriteLine($"Body: {Body}");
            Console.WriteLine($"Mark : {Mark}");
            foreach (Answer answer in Answerslist)
            {
                if (answer != null)
                {
                    Console.WriteLine(answer.ToString());
                }
            }
           
        }
    }
}
