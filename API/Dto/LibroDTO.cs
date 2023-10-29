namespace API.Dto;

public class LibroDTO {
    public Guid id {get;set;}
    public string titulo {get;set;}
    public string resumen {get;set;}
    public Guid autorId {get;set;}
}