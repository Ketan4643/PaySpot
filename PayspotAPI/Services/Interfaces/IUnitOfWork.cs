namespace PayspotAPI.Services.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Lead> Leads { get; }
    IGenericRepository<StateMaster> States { get; }
    Task Save();
}