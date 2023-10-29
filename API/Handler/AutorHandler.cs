namespace API.Handler;
using API.Dto;

public class AutorHandler {
    private List<AutorDTO> _autor = new List<AutorDTO>();

    public AutorHandler (List<AutorDTO> autor){
        this._autor = autor;
    }

    public void createAutor(AutorDTO autor)
    {
        bool existeAutor = false;

        foreach (AutorDTO a in _autor)
        {
            if (a.id == autor.id)
            {
                existeAutor = true;
                break;
            }
        }

        if (existeAutor != true)
        {
            _autor.Add(autor);
        }
    }

    public List<AutorDTO> All(){
        return this._autor;
    }

   public AutorDTO getAutor(Guid id)
    {
        foreach (AutorDTO autor in _autor)
        {
            if (autor.id == id)
            {
                return autor;
            }
        }
        return null; 
    }

   public void updateAutor(AutorDTO autor, Guid id)
    {
        for (int i = 0; i < _autor.Count; i++)
        {
            if (_autor[i].id == id)
            {
                _autor[i] = autor;
                return;
            }
        }
    }

    public void deleteAutor(Guid id)
    {
        AutorDTO autorEliminar = null;

        foreach (AutorDTO autor in _autor)
        {
            if (autor.id == id)
            {
                autorEliminar = autor;
                break;
            }
        }

        if (autorEliminar != null)
        {
            _autor.Remove(autorEliminar);
        }
    }

}