using System.Text.RegularExpressions;

namespace SwEngHomework.DescriptiveStatistics
{
    public class StatsCalculator : IStatsCalculator
    {
        private double median;
        private double average;
        private double range;

        public Stats Calculate(string semicolonDelimitedContributions)
        {
            ContrubutionSeparation(semicolonDelimitedContributions);
            Stats stats = new Stats();
            stats.Median = median;
            stats.Average = average;
            stats.Range = range;
            return stats;

        }

        private void ContrubutionSeparation(string contributions)
        {

            List<double> numbers = new List<double>();
            string pattern = @"[\d,.]+";
            double valueNum;

            MatchCollection matches = Regex.Matches(contributions, pattern);
            foreach (Match match in matches)
            {

                string numberStr = match.Value;
                numberStr = numberStr.Replace(",", "");
                double.TryParse(numberStr, out valueNum);
                numbers.Add(valueNum);


                Console.WriteLine(numbers);
            }


            Statistics(numbers);
        }


        private void Statistics(List<double> numbers)
        {
            average = Average(numbers);
            median = Median(numbers);
            range = Ranger(numbers);
        }



        private double Average(List<double> numbers)
        {

            double average = numbers.Average();
            average = Math.Round(average, 2);

            Console.WriteLine("Average: " + average);
            return average;
        }

        private double Median(List<double> numbers)
        {


            numbers.Sort();

            int count = numbers.Count;
            int middle = count / 2;
            double median = numbers[middle];

            if (count % 2 == 0)
            {
                median = (median + numbers[middle - 1]) / 2;
            }

            median = Math.Round(median, 2);

            Console.WriteLine("Median: " + median);

            return median;
        }

        private double Ranger(List<double> numbers)
        {

            double range = numbers.Max() - numbers.Min();

            range = Math.Round(range, 2);

            Console.WriteLine("Range: " + range);

            return range;
        }


    }
}
