using System.Collections.Generic;

namespace GradeComputationAppServices
{
    public class GradeCalculator
    {

        public static double calculateGrade(double sw1, double sw2, double qz1, double qz2, double assign, double lab, double exam)
        {
            double classStanding = (((sw1 + sw2) / 20) * 0.20) + (((qz1 + qz2) / 20) * 0.20) + ((assign / 10) * 0.10) + ((lab / 10) * 0.20);
            double examScore = (exam / 50) * 0.30;
            return (classStanding + examScore) * 100;
        }

        public static double calculateFinalFinalGrade(double m, double f)
        {
            return (m + f) / 2.0;
        }

        public static string GetEquivalent(double finalGrade)
        {
            if (finalGrade >= 90) return "1.0 (Excellent)";
            if (finalGrade >= 80) return "2.0 (Good)";
            if (finalGrade >= 70) return "3.0 (Fair)";
            return "5.0 (Failed)";
        }
    }
}