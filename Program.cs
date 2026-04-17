using System;
using GradeComputationAppServices;
using GradeComputationDataServices;

namespace GradeComputation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GradeData.LoadData();

            bool stayInProgram = true;

            while (stayInProgram)
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
                Console.WriteLine("4. VIEW HISTORY");
                Console.WriteLine("5. DELETE LOCAL HISTORY");
                Console.WriteLine("6. UPDATE GRADE RECORD"); // Added for your CRUD requirement
                Console.WriteLine("7. EXIT");

                Console.Write("ENTER CHOICE: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nMIDTERM COMPUTATION");
                        subjectName();
                        computeGrade();
                        GradeData.midtermGrade = calculateGrade();
                        GradeData.SaveData();
                        CheckContinue(ref stayInProgram);
                        break;

                    case "2":
                        Console.WriteLine("\nFINALS COMPUTATION");
                        subjectName();
                        computeGrade();
                        GradeData.finalsGrade = calculateGrade();
                        GradeData.SaveData();
                        CheckContinue(ref stayInProgram);
                        break;

                    case "3":
                        Console.WriteLine("\nFINAL-FINAL GRADE");
                        computeFinalFinalGrade();
                        CheckContinue(ref stayInProgram);
                        break;

                    case "4":
                        Console.WriteLine("\n--- SHOWING SAVED HISTORY ---");
                        GradeData.ViewHistory();
                        CheckContinue(ref stayInProgram);
                        break;

                    case "5":
                        Console.Write("\nAre you sure you want to delete local history(JSON FILE)? (Y/N): ");
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            GradeData.DeleteHistory();
                            Console.WriteLine("Local history has been cleared.");
                        }
                        CheckContinue(ref stayInProgram);
                        break;

                    case "6":
                        Console.WriteLine("\nUPDATE GRADE RECORD");
                        Console.Write("ENTER SUBJECT NAME TO UPDATE: ");
                        string sub = Console.ReadLine();
                        Console.Write("ENTER NEW MIDTERM GRADE: ");
                        double m = double.Parse(Console.ReadLine());
                        Console.Write("ENTER NEW FINALS GRADE: ");
                        double f = double.Parse(Console.ReadLine());

                        GradeData.SyncUpdate(sub, m, f);
                        Console.WriteLine("Records updated successfully!");
                        CheckContinue(ref stayInProgram);
                        break;

                    case "7":
                        Console.WriteLine("EXITING GOODBYE!!");
                        stayInProgram = false;
                        break;
                }
            }
        }

        static void CheckContinue(ref bool stay)
        {
            Console.Write("\nDo you want to compute for another grade? (Y/N): ");
            if (Console.ReadLine().ToUpper() != "Y")
            {
                Console.WriteLine("\nThank you for using the Grade Computation Page! Goodbye.");
                stay = false;
            }
        }

        static void subjectName()
        {
            Console.Write("ENTER SUBJECT NAME: ");
            GradeData.subjectName = Console.ReadLine();
        }

        static void computeGrade()
        {
            Console.Write("Enter SEATWORK 1 1/10: ");
            GradeData.sw1 = double.Parse(Console.ReadLine());
            Console.Write("Enter SEATWORK 2 1/10: ");
            GradeData.sw2 = double.Parse(Console.ReadLine());
            Console.Write("Enter QUIZ 1 1/10: ");
            GradeData.qz1 = double.Parse(Console.ReadLine());
            Console.Write("Enter QUIZ 2 1/10: ");
            GradeData.qz2 = double.Parse(Console.ReadLine());
            Console.Write("Enter ASSIGNMENT 1/10: ");
            GradeData.assign = double.Parse(Console.ReadLine());
            Console.Write("Enter LABORATORY 1/10: ");
            GradeData.lab = double.Parse(Console.ReadLine());
            Console.Write("Enter EXAM 1/50: ");
            GradeData.exam = double.Parse(Console.ReadLine());
        }

        static double calculateGrade()
        {
            double finalGrade = GradeCalculator.calculateGrade(
                GradeData.sw1, GradeData.sw2, GradeData.qz1, GradeData.qz2,
                GradeData.assign, GradeData.lab, GradeData.exam);

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Your computed grade is: " + finalGrade);
            Console.WriteLine("-------------------------------------------------------------------------------");


            Console.WriteLine("Equivalent Grade: " + GradeCalculator.GetEquivalent(finalGrade));

            return finalGrade;
        }

        static void computeFinalFinalGrade()
        {
            if (GradeData.midtermGrade == 0 || GradeData.finalsGrade == 0)
            {
                Console.WriteLine("Please compute both MIDTERM and FINALS first!");
                return;
            }

            double finalFinalGrade = GradeCalculator.calculateFinalFinalGrade(GradeData.midtermGrade, GradeData.finalsGrade);

            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("SUBJECT: " + GradeData.subjectName);
            Console.WriteLine("Your FINAL-FINAL grade is: " + finalFinalGrade);
            Console.WriteLine("-------------------------------------------------------------------------------");
        }
    }
}