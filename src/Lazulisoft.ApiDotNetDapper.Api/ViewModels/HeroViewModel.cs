using Lazulisoft.ApiDotNetDapper.Api.Enums;
using System.ComponentModel.DataAnnotations;

namespace Lazulisoft.ApiDotNetDapper.Api.ViewModels
{
    public class HeroViewModel
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Publisher Publisher { get; set; }

        [MaxLength(50)]
        public string AlterEgo { get; set; }

        public bool HasSuperPower { get; set; }

        [MaxLength(200)]
        public string Abilities { get; set; }
    }
}
