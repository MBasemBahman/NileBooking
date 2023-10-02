using Entities.CoreServicesModels.LocationModels;
using Entities.DBModels.LocationModels;
using Entities.EnumData;

namespace Portal.Areas.LocationEntity.Models
{
    public class AreaFilter : DtParameters
    {
        [DisplayName(nameof(Country))]
        public int Fk_Country { get; set; }
    }
    public class AreaDto : AreaModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }
    }

    public class AreaCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Country))]
        public int Fk_Country { get; set; }

        public List<AreaLangModel> AreaLangs { get; set; }
    }

    public class AreaLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }


}
