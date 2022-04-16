namespace CleanArchitecture.Domain.Entities;

public class Photo : AuditableEntity
{
    public Photo() => Id = Guid.NewGuid();

    public Guid Id { get; set; }
    public string Folder { get; set; }
    public string OriginalFileName { get; set; }
    public string OriginalType { get; set; }
    public bool IsMain { get; set; }
    public bool IsValidated { get; set; }
    public string? Note { get; set; }
    public byte[]? OriginalContent { get; set; }
    public byte[]? ThumbnailContent { get; set; }
    public byte[]? ImageInListContent { get; set; }
    public byte[]? FullScreenContent { get; set; }
}

public class PhotoProperty : Photo
{
    public Propriete Propriete { get; set; }
}

public class PhotoNotaire : Photo
{
    public int NotaireId { get; set; }
    public Notaire Notaire { get; set; }
}