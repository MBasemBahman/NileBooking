using Entities.EnumData;

namespace Entities.DBModels.PromoCodeModels;

public class PromoCodeDiscountType : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    public List<PromoCodeDiscountTypeLang> PromoCodeDiscountTypeLangs { get; set; }
    
    [DisplayName(nameof(PromoCodes))]
    public List<PromoCode> PromoCodes { get; set; }
}

public class PromoCodeDiscountTypeLang : AuditLangEntity<PromoCodeDiscountType>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }
}