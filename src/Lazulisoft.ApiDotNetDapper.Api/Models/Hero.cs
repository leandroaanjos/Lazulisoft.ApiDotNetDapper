using Lazulisoft.ApiDotNetDapper.Api.Enums;

namespace Lazulisoft.ApiDotNetDapper.Api.Models
{
    public class Hero
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Publisher Publisher { get; set; }

        public string AlterEgo { get; set; }

        public bool HasSuperPower { get; set; }

        public string Abilities { get; set; }
    }
}