namespace LaborProtection.Calculation.Constants
{
    public class Limitations
    {
        public const double MINIMAL_AREA = 6.0; // Metters
        public const double MINIMAL_VOLUME = 20.0; // Metters

        public const double MINIMUM_TABLE_WIDTH = 60.0; // Santimetters
        public const double MAXIMUM_TABLE_WIDTH = 140.0; // Santimetters
        public const double MINIMUM_TABLE_LENGTH = 80.0; // Santimetters
        public const double MAXIMUM_TABLE_LENGTH = 100.0; // Santimetters

        public const double BETWEEN_TABLES = 1.2; // Metters
        public const double BETWEEB_MONITORS = 2.5; // Metters
    }

    public class LightReflection
    {
        public enum FloorReflection
        {
            _10 = 10,
            _30 = 30,
        }

        public enum WallReflection
        {
            _10 = 10,
            _30 = 30,
            _50 = 50,
        }

        public enum CellingReflection
        {
            _30 = 30,
            _50 = 50,
            _70 = 70,
        }
    }
}