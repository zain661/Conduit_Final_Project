using Conduit1.Models;
using Conduit1.Services;

namespace Conduit1.dd
{
    public interface IArticleRepository: IGenericRepository<Article>
    {

        Task<Article> GetArticleAsync(int id);
        void Remove(Article article);
        void Update(Article article);
    }
}