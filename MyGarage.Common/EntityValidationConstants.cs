namespace MyGarage.Common
{
    public static class EntityValidationConstants
    {
        public static class Vehicle
        {
            public const int VinMinLength = 11;
            public const int VinMaxLength = 17;

            public const int MakeMaxLength = 50;
            public const int MakeMinLength = 1;

            public const int ModelNameMaxLength = 100;
            public const int ModelNameMinLength = 1;

            public const int EngineNumberMaxLength = 8;
            public const int EngineNumberMinLength = 8;

            public const int RegistrationPlateMaxLength = 10;
            public const int RegistrationPlateMinLength = 1;

            public const int YearMadeMaxLength = 4;
            public const int YearMadeMinLength = 4;

            public const int MileageMaxLength = 11;
            public const int MileageMinLength = 1;
        }

        public static class Customer
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;

            public const int SurnameMaxLength = 50;
            public const int SurnameMinLength = 2;

            public const int EgnMaxLength = 10;
            public const int EgnMinLength = 10;

            public const int AddressMaxLength = 200;
            public const int AddressMinLength = 5;

            public const int EmailMaxLength = 255;
            public const int EmailMinLength = 4;

            public const int PhoneNumberMaxLength = 13;
            public const int PhoneNumberMinLength = 10;

        }

        public static class Part
        {
            public const int NameMaxLength = 200;
            public const int NameMinLength = 3;

            public const int NumberMaxLength = 20;
            public const int NumberMinLength = 1;

            public const string PriceMaxValue = "10000";
            public const string PriceMinValue = "0.50";
        }

        public static class Job
        {
            public const int NameMaxLength = 150;
            public const int NameMinLength = 5;

            public const string PriceMaxValue = "500";
            public const string PriceMinValue = "10";
        }

        public static class User
        {
            public const int PasswordMaxLength = 100;
            public const int PasswordMinLength = 6;

            public const int FirstNameMaxLength = 50;
            public const int FirstNameMinLength = 2;

            public const int LastNameMaxLength = 50;
            public const int LastNameMinLength = 2;
        }

        public static class Mechanic
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;

            public const int SurnameMaxLength = 50;
            public const int SurnameMinLength = 2;

            public const int PhoneNumberMaxLength = 13;
            public const int PhoneNumberMinLength = 10;
        }
    }
}