namespace CleanArchitectureBlazor.Core.ApplicationService.BaseCoreApplication.Patterns;

public interface IQueryDapper
{

    Task Execute(string query, object parameters);
    Task<Model> Execute<Model>(string query, object parameters);

    Task<TModel> ReadFirstAsync<TModel>(string query, object parameters);
    Task<TModel> ReadFirstBySpAsync<TModel>(string spName, object parameters);

    Task<IEnumerable<TModel>> ReadListAsync<TModel>(string query, object parameters);
    Task<IEnumerable<TModel>> ReadListBySpAsync<TModel>(string spName, object parameters);
}

