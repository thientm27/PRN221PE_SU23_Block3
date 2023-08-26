using System;
using System.Collections.Generic;

namespace DAOs.Models
{
    public partial class MemberAccount
    {
        public int MemberId { get; set; }
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? Email { get; set; }
        public int? Role { get; set; }
    }
}
