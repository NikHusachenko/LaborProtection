namespace LaborProtection.Calculation.Constants
{
    public static class Limitations
    {
        public const double MINIMAL_AREA = 6.0; // Metters
        public const double MINIMAL_VOLUME = 20.0; // Metters
        public const double MINIMAL_WIDTH = 2.5; // Metters

        public const double MINIMUM_TABLE_WIDTH = 80.0; // Santimetters
        public const double MAXIMUM_TABLE_WIDTH = 100.0; // Santimetters
        public const double MINIMUM_TABLE_LENGTH = 60.0; // Santimetters
        public const double MAXIMUM_TABLE_LENGTH = 140.0; // Santimetters
        public const double MINIMUM_TABLE_HEIGHT = 68.0; // Santimetters
        public const double MAXIMUM_TABLE_HEIGHT = 80.0; // Santimetters

        public const double BETWEEN_TABLES = 1.2; // Metters
        public const double BETWEEN_MONITORS = 2.5; // Metters
    }

    public static class LightReflection
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