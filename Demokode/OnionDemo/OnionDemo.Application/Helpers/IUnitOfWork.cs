using System.Data;

namespace OnionDemo.Application.Helpers;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable);
}