using System.ComponentModel.DataAnnotations.Schema;

namespace SharedFiles.Entities
{
    [NotMapped]
    public static class Roles
    {
        public const string User = "User";
    }
}