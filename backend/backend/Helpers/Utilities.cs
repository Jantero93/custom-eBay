

using System.Drawing;

namespace backend.Helpers
{
    public static class Utilities
    {
        public static byte[]? ConvertIFormFileToBytes(IFormFile file)
        {
            using (var ms = new MemoryStream())

                if (file.Length > 0)
                {
                    file.CopyTo(ms);
                    return ms.ToArray();
                }

            return null;
        }

        public static string RoleEnumToString(UserRole role)
        {
            return role switch
            {
                UserRole.Normal => "Normal",
                UserRole.Admin => "Admin",
                UserRole.Root => "Root",
                UserRole.Banned => "Banned",
                _ => "Normal"
            };
        }

        public static UserRole StringToRoleEnum(string role)
        {
            return role switch
            {
                "Normal" => UserRole.Normal,
                "Admin" => UserRole.Admin,
                "Root" => UserRole.Root,
                "Banned" => UserRole.Banned,
                _ => UserRole.Normal
            };
        }
    }
}
