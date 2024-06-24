namespace Core.Entites
{
    public class DateOfBirth
    {
        public DateOfBirth(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }
}
