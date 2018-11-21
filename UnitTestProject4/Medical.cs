using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject4
{
    public class Medical
    {
        public Medical(int year, string content)
        {
            Year = year;
            Content = content;
        }

        public int Year { get; }
        public string Content { get; }

        public bool IsValid()
        {
            var validators = new Dictionary<int, Func<string, bool>>
            {
                {106, this.Validator106 },
                {107, this.Validator107 },
            };

            return validators.ContainsKey(Year) && validators[Year](Content);
        }

        private bool Validator107(string content)
        {
            var numberList = Enumerable.Range(1, 14).Except(new[] { 2, 12 });
            var whiteList = numberList.Select(x => x.ToString()).Concat(new[] { "2a", "2b", "99" });
            return whiteList.Contains(content);
        }

        private bool Validator106(string content)
        {
            if (int.TryParse(content, out int value))
            {
                return (value >= 1 && value <= 11) || value == 99;
            }

            return false;
        }
    }
}