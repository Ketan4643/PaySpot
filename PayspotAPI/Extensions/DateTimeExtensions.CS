namespace PayspotAPI.Extensions;
public static class DateTimeExtensions
{
    public static int DateTimeToUnixTimeStamp(this DateTime datetime) => 
        (int)(datetime.Subtract(new DateTime(1970,1,1)).TotalSeconds);

    public static DateTime UnixTimeStampToDateTime(this int unixTimestamp) => 
        new DateTime(1970,1,1).AddSeconds(unixTimestamp);

        public static int CaculateAge(this DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;
            if(dob.Date > today.AddYears(-age)) age--;
            return age;
        }
}