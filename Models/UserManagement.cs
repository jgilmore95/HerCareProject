public static class UserManagement
{
    public static string Username { get; set; }

    public static bool IsValidAdmin
    {
        get
        {
            return (string.IsNullOrEmpty(Username) == false);
        }
    }
}