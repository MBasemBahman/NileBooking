using Entities.CoreServicesModels.HotelModels;
using Entities.EnumData;
using System.ComponentModel;

namespace Portal.Areas.HotelEntity.Models
{
    public class HotelFeatureCategoryFilter : DtParameters
    {
    }

    public class HotelFeatureCategoryDto : HotelFeatureCategoryModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }
    }

    public class HotelFeatureCategoryCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        public List<HotelFeatureCategoryLangModel> HotelFeatureCategoryLangs { get; set; }
    }

    public class HotelFeatureCategoryLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}

