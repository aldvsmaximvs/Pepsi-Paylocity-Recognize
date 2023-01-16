namespace PaylocityHelper
{
    public static class StringUtility
    {
        public static string GetRoleNameFromPositionCode(string positionCode)
        {
            var roleName = string.Empty;

            if (!string.IsNullOrWhiteSpace(positionCode))
                roleName = StaticDataUtility.GetRoleName(positionCode);

            return roleName;
        }

        public static string GetTeamNameFromLocation(string location)
        {
            var teamName = string.Empty;
            if (!string.IsNullOrWhiteSpace(location))
                teamName = location.Replace("Gillette Pepsi ", "");

            return teamName;
        }
    }
}