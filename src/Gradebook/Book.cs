namespace Gradebook
{
    public class Book
    {
        public List<double> grades;
        public String Student;
        public Book()
        {
            this.Student = "";
            this.grades = new List<double>();
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;
                default:
                    break;
            }
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
            else
            // TODO me da System.FormatException y no System.ArgumentException
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public Double CalculateAverage()
        {
            return grades.Average();
        }

        public Double FindHigher()
        {
            return grades.Max();
        }

        public Double FindLower()
        {
            return grades.Min();
        }

        public Statistic ComputeStatistics()
        {
            return new Statistic(this.CalculateAverage(), this.FindHigher(), this.FindLower(), this.ComputeLetterGrades());
        }

        public List<char> ComputeLetterGrades() {
            var result = new List<char>();
            foreach (var grade in grades)
            {
             switch (grade)
                {
                    case var d when d >= 90:
                        result.Add('A');
                        break;
                    case var d when d >= 80:
                        result.Add('B');
                        break;
                    case var d when d >= 70:
                        result.Add('C');
                        break;
                    case var d when d >= 60:
                        result.Add('D');
                        break;
                    default:
                        result.Add('F');
                        break;
                }
            }
            return result;
        }

    }
}