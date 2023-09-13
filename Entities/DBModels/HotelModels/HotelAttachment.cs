namespace Entities.DBModels.HotelModels;

public class HotelAttachment : AuditAttachmentEntity
{
    [DisplayName(nameof(Hotel))]
    [ForeignKey(nameof(Hotel))]
    public int Fk_Hotel { get; set; }

    [DisplayName(nameof(Hotel))]
    public Hotel Hotel { get; set; }
}