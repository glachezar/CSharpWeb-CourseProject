namespace MyGarage.Common;

public class GeneralApplicationConstants
{
    public const int ReleaseYear = 2023;

    public const string AdminAreaName = "Admin";
    public const string AdminRoleName = "Administrator";
    public const string DeveloperAdminEmail = "admin@mcg.bg";

    public const string UsersCacheKey = "UsersCache";
    public const string RentsCacheKey = "RentsCache";
    public const int UsersCacheDurationMinutes = 5;
    public const int RentsCacheDurationMinutes = 10;

    public const string OnlineUsersCookieName = "IsOnline";
    public const int LastActivityBeforeOfflineMinutes = 10;
}
