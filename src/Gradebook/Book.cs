namespace Gradebook
{
    public class Book
    {
        private List<double> grades;
        public String Student;
        public Book()
        {
            this.Student = "";
            this.grades = new List<double>();
        }
        public Book(String student)
        {
            grades = new List<double>();
            this.Student = student;
        }
        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
        }

        public Double CalculateAverage(){
            return grades.Average();
        }

        public Double FindHigher(){
            return grades.Max();
        }

        public Double FindLower(){
            return grades.Min();
        }

        public Statistic ComputeStatistics() {
            return new Statistic(this.CalculateAverage(), this.FindHigher(), this.FindLower());
            }

    }
}