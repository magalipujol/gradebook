namespace Gradebook
{
    public class Statistic {
        public double Average;
        public double Highest;
        public double Lowest;
        public List<char> Letters;


        public Statistic(double Average, double Highest, double Lowest, List<char> Letters) {
            this.Average = Average;
            this.Highest = Highest;
            this.Lowest = Lowest;
            this.Letters = Letters;
        }
    }

}