using Entities.EnumData;

namespace Entities.DBModels.PromoCodeModels;

public class PromoCode : ImageEntity
{
    [DisplayName(nameof(PromoCodeDiscountType))]
    [ForeignKey(nameof(PromoCodeDiscountType))]
    public int Fk_PromoCodeDiscountType { get; set; }

    [DisplayName(nameof(PromoCodeDiscountType))]
    public PromoCodeDiscountType PromoCodeDiscountType { get; set; }

    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName(nameof(Title))]
    public string Title { get; set; }

    [DisplayName(nameof(Description))]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName(nameof(Code))]
    public string Code { get; set; }

    [DisplayName(nameof(MinPrice))]
    public int? MinPrice { get; set; }

    [DisplayName(nameof(MaxDiscount))]
    public int? MaxDiscount { get; set; }

    [DisplayName(nameof(MaxUse))]
    public int? MaxUse { get; set; }

    [DisplayName(nameof(MaxUsePerUser))]
    public int? MaxUsePerUser { get; set; }

    [DisplayName(nameof(Discount))]
    public double? Discount { get; set; }

    [DisplayName(nameof(AppDiscount))]
    public int AppDiscount { get; set; }

    [DisplayName(nameof(IsActive))]
    public bool IsActive { get; set; }

    [DisplayName(nameof(ExpirationDate))]
    public DateTime ExpirationDate { get; set; }

    [DisplayName(nameof(Notes))]
    [DataType(DataType.MultilineText)]
    public string Notes { get; set; }

    // [DisplayName(nameof(IsOnlineOnly))]
    // [DefaultValue(false)]
    // public bool IsOnlineOnly { get; set; }

    [DisplayName(nameof(IsValid))]
    public bool IsValid => IsActive && !IsExpired;

    public bool IsExpired => !(ExpirationDate.Date >= DateTime.UtcNow.Date);
}