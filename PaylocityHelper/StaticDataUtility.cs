using PaylocityHelper.ViewModel;

namespace PaylocityHelper
{
    public static class StaticDataUtility
    {
        public static string GetRoleName(string positionCode)
        {
            var pepsiRole = GetPepsiRoles().Where(p => p.RoleCode == positionCode).FirstOrDefault();
            var roleName = string.Empty;
            if (pepsiRole != null)
                roleName = pepsiRole.RoleName;
            else
                roleName = "Pepsi";

            return roleName;
        }

        private static IList<PepsiRole> GetPepsiRoles()
        {
            List<PepsiRole> pepsiRoles = new List<PepsiRole>();
            string pepsiRoleSource = "C:\\Users\\CebuDev15\\source\\repos\\Pepsi-Paylocity-Recognize\\Documents\\RecognizedRoles.csv";
            if (File.Exists(pepsiRoleSource))
            {
                string[] lines = File.ReadAllLines(pepsiRoleSource);

                foreach (string line in lines)
                {
                    var data = line.Split(",");
                    pepsiRoles.Add(new() { RoleCode = data[0], RoleName = data[1] });
                }
            }

            return pepsiRoles;
        }
    }
}
