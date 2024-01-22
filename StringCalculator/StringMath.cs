namespace StringCalculator
{
    public static class StringMath
    {
        public static int Add(string numbers)
        {
            var delimiters = new List<string> { ",", "\n" };

            if (numbers.StartsWith("//"))
            {
                var sections = numbers.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                delimiters.Add(sections.FirstOrDefault().Replace("//", ""));
                numbers = sections.LastOrDefault();
            }

            var splitNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var sum = 0;
            string negatives = "";
            foreach (var n in splitNumbers)
            {
                if (int.Parse(n) < 0)
                {
                    negatives += n+",";
                }
                if(int.Parse(n) < 1000)
                {
                    sum += int.Parse(n);
                }

            }
            negatives = negatives.Trim(',');
            if (negatives.Length > 0)
            { 
                throw new Exception("negatives not allowed "+negatives);
            }
            else
            {
                return sum;
            }


        }
    }
}
