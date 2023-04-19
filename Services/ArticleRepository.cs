using Conduit1.Models;
using Conduit1.Services;
using Microsoft.EntityFrameworkCore;

namespace Conduit1.dd
{
    public class ArticleRepository : GenericRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ConduitContext context) : base(context)
        {
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            var art = await _context.Articles.Where(a => a.ArticleId == id).FirstOrDefaultAsync();
            return art;
        }

        public void Remove(Article article)
        {
            _context.Articles.Remove(article);
        }

        public void Update(Article article)
        {
            _context.Update(article);
        }



    }
}
