using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RgPattern
    {
        public static string Username { get; } = @"^[a-z][a-z0-9]{5,}$";
        public static string PassWord { get; } = @"[\S]{6,}$";
        public static string DOB { get; } = @"";
        public static string Name { get; } = @"^[a-zA-Z][\D]{3,}$";
        public static string Khoi { get; } = @"[0-9]";

        public static string Lop{ get; } = @"[\S]{2,}$";

    }
}
