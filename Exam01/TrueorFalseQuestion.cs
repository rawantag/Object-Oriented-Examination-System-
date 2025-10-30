using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    internal class TrueorFalseQuestion:Question
    {
        #region Constructors
        public TrueorFalseQuestion() { }

        public TrueorFalseQuestion(string? header, string? body, int mark) : base(header, body, mark)
        {

            bool isparsed;
            int id;
            Answerslist = new Answer[]
            {
                new Answer(1,"True"),
                new Answer(2,"False")
            };

            Console.Write("Please enter the correct answer id (1 for true // 2 for false ) : ");
            do
            {
                isparsed = int.TryParse(Console.ReadLine(), out id);
            } while (!isparsed);

            RightAnswer = new Answer(id, Answerslist[id - 1].AnswerTxt);

        }
        #endregion

        public override object Clone()
        {
            TrueorFalseQuestion TorFClone = new TrueorFalseQuestion
            {
                Header = this.Header,
                Body = this.Body,
                Mark = this.Mark,
            };

            if (Answerslist is not null)
            {
                for (int i = 0; i < Answerslist.Length; i++)
                {
                    TorFClone.Answerslist[i] = (Answer)Answerslist[i].Clone();
                }

            }
            TorFClone.RightAnswer = (Answer)this.RightAnswer.Clone();
            return TorFClone;
        }

        public override void DisplayQuestionDetails()
        {
            Console.WriteLine("True or False Question :");
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
