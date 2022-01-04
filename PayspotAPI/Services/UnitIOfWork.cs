namespace PayspotAPI.Services;
public class UnitIOfWork : IUnitOfWork
{
    private readonly DataContext _context;
    private IGenericRepository<Lead> _leads;
    private IGenericRepository<StateMaster> _states;
    
    public UnitIOfWork(DataContext context)
    {
        _context = context;
    }

    public IGenericRepository<Lead> Leads => _leads ??= new GenericRepository<Lead>(_context);
    public IGenericRepository<StateMaster> States => _states ??= new GenericRepository<StateMaster>(_context);
    
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
