namespace DayProgrammer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int year = 2016;
            Console.WriteLine($"{dayOfProgrammer(year)}");
        }




        public static string dayOfProgrammer(int year)
        {
            int dayOfYear = 256;

            DateTime date = new DateTime(year, 1, 1).AddDays(dayOfYear - 1);
            //Console.WriteLine(DateTime.IsLeapYear(year));
            if (year < 1918 )
            {
                return year % 4 == 0
                    ? $"13.09.{year}"
                    : $"12.09.{year}";
            }
            else if (year == 1918)
            {
                return $"{256-230}.09.{year}";
            }
            else if (DateTime.IsLeapYear(year) && dayOfYear > 59)
            {
                date = date.AddDays(1);
            }
            string formattedDate = date.ToString("dd.MM.yyyy");
            return formattedDate;
        }

    }
}