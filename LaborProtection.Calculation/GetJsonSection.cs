﻿using LaborProtection.Calculation.Enums;
using Microsoft.Extensions.Configuration;

namespace LaborProtection.Calculation
{
    public static class GetJsonSection
    {
        private const string LSPPath = "LSPReflection.json";
        private const string LPOPath = "LPOReflection.json";

        public static int GetValue(string section, JsonSource source)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory);

            switch (source)
            {
                case JsonSource.LPO:
                    {
                        configBuilder.AddJsonFile(LPOPath);
                        break;
                    }
                case JsonSource.LSP:
                    {
                        configBuilder.AddJsonFile(LSPPath);
                        break;
                    }
            }

            IConfigurationRoot configuration = configBuilder.Build();

            string[] sectionQueryParts = section.Split(':');
            string last = sectionQueryParts.Last();

            string queryWithoutLastSection = string.Join(":", sectionQueryParts.SkipLast(1));
            IConfigurationSection values = configuration.GetSection(queryWithoutLastSection);

            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (var child in values.GetChildren())
            {
                dict.Add(child.Key, child.Value);
            }

            double lastAsDouble = double.Parse(last);

            if (lastAsDouble <= 0)
            {
                return -1;
            }

            try
            {
                lastAsDouble = RoundToNearest(lastAsDouble, dict.Select(x => double.Parse(x.Key)).ToList());
            }
            catch (Exception ex)
            {
                return -1;
            }

            last = lastAsDouble.ToString();
            if (!last.Contains(','))
            {
                last += ",0";
            }

            string fixedQuery = $"{queryWithoutLastSection}:{last}";
            string value = configuration.GetSection(fixedQuery).Value;

            return int.Parse(value);
        }

        public static double RoundToNearest(double number, List<double> values)
        {
            if (values == null || values.Count == 0)
            {
                throw new ArgumentException("The list of values cannot be null or empty.");
            }

            double nearestValue = values[0];

            foreach (double value in values)
            {
                if (Math.Abs(value - number) < Math.Abs(nearestValue - number))
                {
                    nearestValue = value;
                }
            }

            return nearestValue;
        }

    }
}