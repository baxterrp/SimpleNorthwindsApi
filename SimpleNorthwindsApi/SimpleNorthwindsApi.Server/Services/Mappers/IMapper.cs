namespace SimpleNorthwindsApi.Server.Services.Mappers
{
    public interface IMapper<T, TEntity>
    {
        T MapTo(TEntity entity);
        TEntity MapFrom(T poco);
    }
}
