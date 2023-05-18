using Newtonsoft.Json;
using SwEngHomework.Commission;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

namespace SwEngHomework.Commissions
{
    public class CommissionCalculator : ICommissionCalculator
    {
        public IDictionary<string, double> CalculateCommissionsByAdvisor(string jsonInput)
        {
            var listOfAdvisorsAccounts = JsonConvert.DeserializeObject<CommisionList>(jsonInput);

            var commissionReport = StartCalculations(listOfAdvisorsAccounts);
            IDictionary<string, double> finalReport = new Dictionary<string, double>();

            foreach (CommissionReport report in commissionReport)
            {
                finalReport[report.Advisor] = (double)report.Commission;
            }

            return finalReport;


        }

        private List<CommissionReport> StartCalculations(CommisionList listOfAdvisorsAccounts)
        {
            var commissionReport = new ConcurrentBag<CommissionReport>();

            Parallel.ForEach(listOfAdvisorsAccounts.Advisors, advisor =>
            {
                var advisorAccounts = listOfAdvisorsAccounts.Accounts.Where(a => a.Advisor == advisor.Name);
                var commission = CalculateCommission(advisorAccounts, advisor.Level);
                commissionReport.Add(new CommissionReport
                {
                    Advisor = advisor.Name,
                    Commission = commission
                });
            });

            return commissionReport.ToList();
        }

        private decimal CalculateCommission(IEnumerable<CommissionAccounts> accounts, string advisorLevel)
        {
            var commissionRate = GetRate(advisorLevel);
            decimal totalCommission = 0;

            foreach (var account in accounts)
            {
                var accountFee = CalculateFee(account.PresentValue);
                var commission = accountFee * commissionRate;
                totalCommission += commission;
            }

            return Math.Round(totalCommission, 2);
        }

        private decimal GetRate(string advisorLevel)
        {
            switch (advisorLevel)
            {
                case "Senior":
                    return 1.00m;
                case "Experienced":
                    return 0.50m;
                case "Junior":
                    return 0.25m;
                default:
                    return 0.00m;
            }
        }

        private decimal CalculateFee(decimal presentValue)
        {
            if (presentValue < 50000)
                return presentValue * 0.0005m;
            else if (presentValue < 100000)
                return presentValue * 0.0006m;
            else
                return presentValue * 0.0007m;
        }



    }
}
