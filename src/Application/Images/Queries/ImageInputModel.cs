namespace CleanArchitecture.Application.Images.Queries;

public class ImageInputModel
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int IdPropriete { get; set; }
    public Stream Content { get; set; }
}