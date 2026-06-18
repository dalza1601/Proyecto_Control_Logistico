
namespace Proyecto_Control_Logistico.Infrastructure.Mongo.Repositories.Interfaces
{
    public interface IMongoUnitOfWork
    {
        IMongoCategoryRepository MongoCategoryRepository { get; }
    }
}
