namespace ScreenSound.Domain.Database;

public class DAL<T> where T: class
{
    protected readonly DatabaseContext _context;

    public DAL(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<T> List()
    {
        return _context.Set<T>().ToList();
    }
    public IEnumerable<T> ListBy(Func<T, bool> condicao)
    {
        return _context.Set<T>().Where(condicao);
    }

    public void Add(T objeto)
    {
        _context.Set<T>().Add(objeto);
    }

    public void Update(T objeto)
    {
        _context.Set<T>().Update(objeto);
    }

    public void Delete(T objeto)
    {
        _context.Set<T>().Remove(objeto);
    }

    public T? SelectBy(Func<T, bool> condicao)
    {        
        return _context.Set<T>().FirstOrDefault(condicao);
    }

    
}
