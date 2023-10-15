using Entities.CoreServicesModels.HotelModels;

namespace Portal.Areas.HotelEntity.Models
{
    public class HotelExtraFilter : DtParameters
    {
        public int Fk_Hotel { get; set; }
    }
    public class HotelExtraDto : HotelExtraPriceModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }
    }

    public class HotelExtraCreateOrEditModel
    {
        [DisplayName(nameof(Fk_Hotel))]
        public int Fk_Hotel { get; set; }
        
        [DisplayName(nameof(Name))]
        public string Name { get; set; }
        
        [DisplayName(nameof(Price))]
        public double Price { get; set; }
        
        [DisplayName(nameof(HotelExtraPriceLangs))]
        public List<HotelExtraLangModel> HotelExtraPriceLangs { get; set; }
    }
    
    public class HotelExtraLangModel
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }
        
        [DisplayName(nameof(Language))]
        public LanguageEnum Language { get; set; }
    }
}
