namespace LaborProtection.Services.WorkSpaceServices.Helpers
{
    public class LengthConverter
    {
        public static double MettersToSantimetters(double metters)
        {
            return metters * 100.0;
        }

        public static double MettersToMillimetres(double metters)
        {
            return metters * 1000.0;
        }

        public static double SantimettersToMetters(double santimeters)
        {
            return santimeters / 100;
        }

        public static double SantimettersToMillimetre(double santimeters)
        {
            return santimeters * 10.0;
        }

        public static double MillimetreToSantimetters(double millimetres)
        {
            return millimetres / 10.0;
        }

        public static double MillimetreToMetters(double millimetres)
        {
            return millimetres / 1000.0;
        }
    }
}