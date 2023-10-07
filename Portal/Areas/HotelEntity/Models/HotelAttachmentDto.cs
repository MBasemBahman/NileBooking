using Entities.CoreServicesModels.HotelModels;
using System.ComponentModel;

namespace Portal.Areas.HotelEntity.Models;

public class HotelAttachmentDto : HotelAttachmentModel
{
    [DisplayName(nameof(CreatedAt))]
    public new string CreatedAt { get; set; }
}
public class HotelAttachmentFilter : DtParameters
{
    public int Id { get; set; }
    public int Fk_Hotel { get; set; }
}