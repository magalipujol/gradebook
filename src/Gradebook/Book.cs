namespace Gradebook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public class NamedObject
    {
        public NamedObject(string student)
        {
            Student = student;
        }

        public string Student
        {
            get; set;
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistic ComputeStatistics();
        string Student { get;}
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject
    {
        protected Book(string student) : base(student)
        {
        }

        public abstract void AddGrade(double grade);
    }
    public class InMemoryBook : Book, IBook
    {

        public List<double> grades;
        // it can only be changed in the constructor
        // good practice: name in uppercase
        public const string CATEGORY = "";
        public InMemoryBook(string student) : base(student)
        {
            this.grades = new List<double>();
            Student = student;
        }

        // public string Student
        // {
        //     get;
        //     // set can be a private property, so it can only be set with the constructor
        //     // it's called a readonly property
        //     set;
        // }
        // * this is the long way to do the above code
        // private String student;
        // public string Student
        // {
        //     get
        //     {
        //         return student;
        //     }
        //     set
        //     {
        //         if (!String.IsNullOrEmpty(value))
        //         {
        //             student = value;
        //         }
        //     }
        // }

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
        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                // raising the event is invoking the delegate and handling the event
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            // TODO me da System.FormatException y no System.ArgumentException
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;

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

        public List<char> ComputeLetterGrades()
        {
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
    public class DiskBook : IBook
    {
        public string Student => throw new NotImplementedException();

        public event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);
        public Statistic ComputeStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
