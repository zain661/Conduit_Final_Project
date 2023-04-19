using System.ComponentModel.DataAnnotations;

namespace Conduit1.Dtos
{
    public class ArticleCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }
    }
}
