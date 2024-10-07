using Exercicios.Interfaces;

namespace Exercicios.Implements
{
    class ECondicionaisQ11 : ICodingExercise
    {
        public ECondicionaisQ11() { }

        private class OlympicsCountry
        {
            public OlympicsCountry(string name, int golden, int silver, int bronze)
            {
                Name = name;
                GoldenMedals = golden;
                SilverMedals = silver;
                BronzeMedals = bronze;
            }

            public OlympicsCountry()
            {
                Name = "";
            }

            public string Name { get; set; }
            public int GoldenMedals { get; set; }
            public int GoldPoints { get; set; } = 3;
            public int SilverMedals { get; set; }
            public int SilverPoints { get; set; } = 2;
            public int BronzeMedals { get; set; }
            public int BronzePoints { get; set; } = 1;
            public int TotalPoints { get; set; } = 0;
        }

        public void TestCode()
        {
            // 11) Construa um algoritmo que seja capaz de dar a classificação olímpica
            // de 3 países informados. Para cada país é informado o nome, a quantidade
            // de medalhas de ouro, prata e bronze. Considere que cada medalha de ouro
            // tem peso 3, cada prata tem peso 2 e cada bronze, peso 1.

            var countries = GetListOfCountries();
            OrderCountriesByMedals(countries);
            PrintCountriesRanking(countries);
        }

        private OlympicsCountry[] GetListOfCountries()
        {
            var countries = new OlympicsCountry[3];

            for (var i = 0; i < countries.Length; i++)
            {
                var country = new OlympicsCountry();

                Console.WriteLine($"Please type the Name of the country #{i + 1}:");
                var input = Console.ReadLine();

                country.Name = input.ToUpper() ?? throw new InvalidDataException($"Country {i}'s name was null");

                Console.WriteLine($"Please type the number of Golden medals {country.Name} had:");
                country.GoldenMedals = int.Parse(Console.ReadLine() ?? "0");

                if (country.GoldPoints == 0)
                {
                    Console.WriteLine("What's the weight we should consider for golden medals in terms of ordering?");
                    country.GoldPoints = int.Parse(Console.ReadLine() ?? throw new InvalidDataException("Can't have a weight equal to 0"));
                }

                Console.WriteLine($"Please type the number of Silver medals {country.Name} had:");
                country.SilverMedals = int.Parse(Console.ReadLine() ?? "0");

                if (country.SilverPoints == 0)
                {
                    Console.WriteLine("What's the weight we should consider for silver medals in terms of ordering?");
                    country.SilverPoints = int.Parse(Console.ReadLine() ?? throw new InvalidDataException("Can't have a weight equal to 0"));
                }

                Console.WriteLine($"Please type the number of Bronze medals {country.Name} had:");
                country.BronzeMedals = int.Parse(Console.ReadLine() ?? "0");

                if (country.BronzePoints == 0)
                {
                    Console.WriteLine("What's the weight we should consider for bronze medals in terms of ordering?");
                    country.BronzePoints = int.Parse(Console.ReadLine() ?? throw new InvalidDataException("Can't have a weight equal to 0"));
                }
                country.TotalPoints = country.GoldenMedals * country.GoldPoints
                                    + country.SilverMedals * country.SilverPoints
                                    + country.BronzeMedals * country.BronzePoints;

                countries[i] = country;

                // just to separate one country from another
                Console.WriteLine("".PadRight(50, '='));
            }

            return countries;
        }

        private void OrderCountriesByMedals(OlympicsCountry[] countries)
        {
            countries.OrderByDescending(ct => ct.TotalPoints);
        }

        private void PrintCountriesRanking(OlympicsCountry[] countries)
        {
            Console.Clear();

            var biggestNameLen = GetBiggestCountryNameLength(countries);

            var header1 = "COUNTRY NAME";
            var header2 = "GOLDEN MEDALS";
            var header3 = "SILVER MEDALS";
            var header4 = "BRONZE MEDALS";
            var header5 = "TOTAL POINTS";

            if (header1.Length > biggestNameLen)
                biggestNameLen = header1.Length; // number of chars in string

            Console.WriteLine(
                header1.PadRight(biggestNameLen + 3) +
                header2.PadRight(header2.Length + 3) +
                header3.PadRight(header3.Length + 3) +
                header4.PadRight(header4.Length + 3) +
                header5.PadRight(header5.Length + 3)
            );
            foreach (var country in countries)
            {
                Console.WriteLine(
                    country.Name.PadRight(biggestNameLen + 3) +
                    country.GoldenMedals.ToString().PadRight(header2.Length + 3) +
                    country.SilverMedals.ToString().PadRight(header3.Length + 3) +
                    country.BronzeMedals.ToString().PadRight(header4.Length + 3) +
                    country.TotalPoints.ToString().PadRight(header5.Length + 3)
                );
            }
        }

        private int GetBiggestCountryNameLength(OlympicsCountry[] countries)
        {
            var biggestNameLen = 0;

            foreach (var ct in countries)
            {
                if (ct.Name.Length > biggestNameLen)
                    biggestNameLen = ct.Name.Length;
            }

            return biggestNameLen;
        }
    }
}