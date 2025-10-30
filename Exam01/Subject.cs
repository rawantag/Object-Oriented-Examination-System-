using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam01
{
    internal class Subject
    {
        #region properties
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public Exam? Exam { get; set; }
        #endregion

        #region Constructors
        public Subject() { }
        public Subject(int id, String? name)
        {
            SubjectId = id;
            SubjectName = name;
            //Console.WriteLine("enter the type of exam enter 1 for Final exam / enter 2 for Practical exam ");
            //int num;
            //bool isparsed;
            //do
            //{
            //    isparsed = int.TryParse(Console.ReadLine(), out num);
            //} while (!isparsed);

            //if (num == 1)
            //{
            //    Exam = new FinalExam();
            //}
            //else
            //    Exam = new PracticslExam();
        }
        #endregion

        public void CreatingExam()
        {
            Console.WriteLine($"creating an exam for subject {SubjectName}...");

            Console.Write("Enter the type of exam (1 for final/2 for practical):");
            int num;
            bool isparsed;
            do
            {
                isparsed = int.TryParse(Console.ReadLine(), out num);
            } while (!isparsed);

            Console.Write("enter time of exam (in minutes):");
            int time;
            do
            {
                isparsed = int.TryParse(Console.ReadLine(), out time);
            } while (!isparsed);

            Console.Write("enter number of Questions in exam:");

            int numofquestion;

            do
            {
                isparsed = int.TryParse(Console.ReadLine(), out numofquestion);
            } while (!isparsed);


            if (num == 1)
            {
                Exam = new FinalExam(time, numofquestion);
            }
            else if (num == 2)
            {
                Exam = new PracticslExam(time,numofquestion);
            }

            Exam.CreateExam();
        }

        public void ShowExam()
        {
            Exam.ShowExam();
        }

        public override string ToString()
        {
            return $"Subject: {SubjectName} (ID: {SubjectId})";
        }
    }
 }

