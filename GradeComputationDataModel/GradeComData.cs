namespace GradeComputationDataServices
{
    public class GradeModel
    {
        public string SubjectName { get; set; }
        public double Sw1 { get; set; }
        public double Sw2 { get; set; }
        public double Qz1 { get; set; }
        public double Qz2 { get; set; }
        public double Assign { get; set; }
        public double Lab { get; set; }
        public double Exam { get; set; }
        public double MidtermGrade { get; set; }
        public double FinalsGrade { get; set; }
    }
}