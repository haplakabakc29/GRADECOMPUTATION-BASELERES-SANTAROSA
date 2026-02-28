using System;

namespace GradeComputation
{
    internal class Program
    {
        static double sw1, sw2, qz1, qz2, assign, lab, exam;
        static double midtermGrade = 0, finalsGrade = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("-----------------------GRADE COMPUTATION AY: 2025-2026-------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("------------------WELCOME TO PUPSIS GRADE COMPUTATION PAGE!--------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("WHAT DO YOU WANT TO DO?");
            Console.WriteLine("1. COMPUTE FOR MIDTERM");
            Console.WriteLine("2. COMPUTE FOR FINALS");
            Console.WriteLine("3. VIEW FINAL-FINAL GRADE");
            Console.WriteLine("4. EXIT");

            Console.Write("ENTER CHOICE: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("MIDTERM COMPUTATION");
                    subjectName();
                    computeGrade();
                    midtermGrade = calculateGrade();
                    break;
                case "2":
                    Console.WriteLine("FINALS COMPUTATION");
                    subjectName();
                    computeGrade();
                    finalsGrade = calculateGrade();
                    break;
                case "3":
                    Console.WriteLine("FINAL-FINAL GRADE");
                    computeFinalFinalGrade();
                    break;
                case "4":
                    Console.WriteLine("EXITING GOODBYE!!");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void subjectName()
        {
            Console.Write("ENTER SUBJECT NAME: ");
            string name = Console.ReadLine();
        }

        static void computeGrade()
        {
            Console.Write("Enter SEATWORK 1 1/10: ");
            sw1 = double.Parse(Console.ReadLine());
            Console.Write("Enter SEATWORK 2 1/10: ");
            sw2 = double.Parse(Console.ReadLine());
            Console.Write("Enter QUIZ 1 1/10: ");
            qz1 = double.Parse(Console.ReadLine());
            Console.Write("Enter QUIZ 2 1/10: ");
            qz2 = double.Parse(Console.ReadLine());
            Console.Write("Enter ASSIGNMENT 1/10: ");
            assign = double.Parse(Console.ReadLine());
            Console.Write("Enter LABORATORY 1/10: ");
            lab = double.Parse(Console.ReadLine());
            Console.Write("Enter EXAM 1/50: ");
            exam = double.Parse(Console.ReadLine());
        }

        static double calculateGrade()
        {
            // Weighting for my own example only: Seatworks (20%), Quizzes (20%), Assignment (10%), Lab (10%), Exam (40%)
            double seatworks = ((sw1 + sw2) / 20.0) * 20;
            double quizzes = ((qz1 + qz2) / 20.0) * 20;
            double assignmentScore = (assign / 10.0) * 10;
            double labScore = (lab / 10.0) * 10;
            double examScore = (exam / 50.0) * 40;

            double finalGrade = seatworks + quizzes + assignmentScore + labScore + examScore;

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Your computed grade is: " + finalGrade);
            Console.WriteLine("-------------------------------------------------------------------------------");

            if (finalGrade >= 90)
                Console.WriteLine("Equivalent Grade: 1.0 (Excellent)");
            else if (finalGrade >= 80)
                Console.WriteLine("Equivalent Grade: 2.0 (Good)");
            else if (finalGrade >= 70)
                Console.WriteLine("Equivalent Grade: 3.0 (Fair)");
            else
                Console.WriteLine("Equivalent Grade: 5.0 (Failed)");

            return finalGrade;
        }

        static void computeFinalFinalGrade()
        {
            if (midtermGrade == 0 || finalsGrade == 0)
            {
                Console.WriteLine("Please compute both MIDTERM and FINALS first!");
                return;
            }

            double finalFinalGrade = (midtermGrade + finalsGrade) / 2.0;

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Your FINAL-FINAL grade is: " + finalFinalGrade);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }
    }
}

