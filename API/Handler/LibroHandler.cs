namespace API.Handler;
using API.Dto;

public class LibroHandler {

    private List<LibroDTO> _libro = new List<LibroDTO>();
    private List<AutorDTO> _autor;
    public LibroHandler (List<LibroDTO> libro, List<AutorDTO> autor){
        this._libro = libro;
        this._autor = autor;
    }

   
   public void createBook(LibroDTO libro)
    {
        bool existeLibro = false;
        bool existeAutor = false;

        foreach (LibroDTO l in _libro)
        {
            if (l.id == libro.id)
            {
                existeLibro = true;
                break;
            }
        }

        foreach (AutorDTO a in _autor)
        {
            if (a.id == libro.autorId)
            {
                existeAutor = true;
                break;
            }
        }

        if (existeLibro == false && existeAutor == true)
        {
            _libro.Add(libro);
        }
    }


    public List<LibroDTO> All(){
        return this._libro;
    }

   public LibroDTO getBook(Guid id)
    {
        foreach (LibroDTO libro in _libro)
        {
            if (libro.id == id)
            {
                return libro;
            }
        }
        return null; 
    }

   public void updateBook(LibroDTO libro, Guid id)
    {
        for (int i = 0; i < _libro.Count; i++)
        {
            if (_libro[i].id == id)
            {
                _libro[i] = libro;
                return;
            }
        }
    }

    public void deleteBook(Guid id)
    {
        LibroDTO libroEliminar = null;

        foreach (LibroDTO libro in _libro)
        {
            if (libro.id == id)
            {
                libroEliminar = libro;
                break;
            }
        }

        if (libroEliminar != null)
        {
            _libro.Remove(libroEliminar);
        }
    }

}
