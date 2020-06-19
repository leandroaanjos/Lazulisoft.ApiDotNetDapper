using System.ComponentModel;

namespace Lazulisoft.ApiDotNetDapper.Api.Enums
{
    public enum Publisher
    {
        [Description("Marvel Comics")]
        MarvelComics = 1,

        [Description("DC Comics")]
        DcComics = 2,

        [Description("Dark Horse Comics")]
        DarkHorseComics = 3,

        [Description("Image Comics")]
        ImageComics = 4
    }
}
