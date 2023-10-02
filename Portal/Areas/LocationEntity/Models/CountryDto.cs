using Entities.CoreServicesModels.LocationModels;
using Entities.DBModels.LocationModels;
using Entities.EnumData;

namespace Portal.Areas.LocationEntity.Models
{
    public class CountryFilter : DtParameters
    {
    }
    public class CountryDto : CountryModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }
    }


    public class CountryCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

     
        public List<CountryLangModel> CountryLangs { get; set; }
    }

    public class CountryLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }

}
