using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;
using Entities.EnumData;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Areas.HotelEntity.Models
{
    public class HotelFeatureFilter : DtParameters
    {        
        [DisplayName("HotelFeatureCategory")]
        public int Fk_HotelFeatureCategory { get; set; }
    }

    public class HotelFeatureDto : HotelFeatureModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }

        [DisplayName(nameof(HotelFeatureCategory))]
        public new HotelFeatureCategoryDto HotelFeatureCategory { get; set; }
    }

    public class HotelFeatureCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(HotelFeatureCategory))]
        [ForeignKey(nameof(HotelFeatureCategory))]
        public int Fk_HotelFeatureCategory { get; set; }

        public List<HotelFeatureLangModel> HotelFeatureLangs { get; set; }
    }

    public class HotelFeatureLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
