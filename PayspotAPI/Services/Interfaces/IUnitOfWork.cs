namespace PayspotAPI.Services.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Lead> Leads { get; }
    Task Save();
}