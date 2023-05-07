namespace LaborProtection.Common
{
    public class Localization
    {
        public enum LocalizationLanguage
        {
            UA,
            EN,
        }
    }

    public class Errors
    {
        public const string CULTURE_NOT_FOUND_ERROR = "Culture not found. Maybe you have not registered selected culture";
        public const string INVALID_LAMP_TYPE_ERROR = "Invalid lamp type";
        public const string WAS_CREATED_ERROR = "Was created";
        public const string NOT_FOUNT_ERROR = "Not found";
        public const string CAN_NOT_GET_PARENT_ERROR = "Can't to get the parent. Something went wrong";
        public const string INVALID_VALUE_ERROR = "Invalida value";
        public const string VALUE_MUST_BE_SELECTED_ERROR = "This value must be selected";
        public const string IMAGE_NOT_SELECTED_ERROR = "Image not selected";
        public const string TABLE_IS_SMALL_ERROR = "Table's sizes must be greater than work space sizes";
        public const string UNKNOWN_LAMP_TYPE_ERROR = "Unknown lamp type";
        public const string CAN_NOT_GET_VALUE_ERROR = "Can't get value";
        public const string INVALID_REFLECTION_VALUES_ERROR = "Can't get use coefficient by these values";
    }

    public class Messages
    {
        public const string CREATED_SUCCESSFULY_MESSAGE = "Created successfuly";
        public const string DELETED_SUCCESSFULT_MESSAGE = "Deleted successfuly";
    }
}