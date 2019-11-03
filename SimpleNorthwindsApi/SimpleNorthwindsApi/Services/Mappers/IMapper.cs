namespace SimpleNorthwindsApi.Services.Mappers
{
    public interface IMapper<T, TEntity>
    {
        public T MapTo(TEntity entity);
        public TEntity MapFrom(T poco);
    }
}
