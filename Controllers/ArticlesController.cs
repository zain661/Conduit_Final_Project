using AutoMapper;
using Conduit.Services;
using Conduit1.Dtos;
using Conduit1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Conduit1.dd
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public ArticleController(IArticleRepository articleRepository, IMapper mapper, IUserRepository userRepository)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetArticle(int id)
        {
            var article = await _articleRepository.GetArticleAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            var articleDto = _mapper.Map<ArticleDto>(article);
            return Ok(articleDto);

        }

        [HttpGet("articles")]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetArticles()
        {


            var articles = await _articleRepository.GetAllAsync();
            var articleDtos = _mapper.Map<IEnumerable<ArticleDto>>(articles);
            return Ok(articleDtos);

        }
        [HttpGet("{id}/article")]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetAllForUser(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            if (user == null) return NotFound("Username not found");

            var articles = await _articleRepository.GetArticleAsync(id);
            var articleDtos = _mapper.Map<IEnumerable<ArticleDto>>(articles);

            return Ok(articleDtos);
        }
        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleCreateDto articleCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.Identity.Name;

            var user = await _userRepository.GetName(username);

            var article = _mapper.Map<Article>(articleCreate);
            article.Author = user;

            await _articleRepository.AddAsync(article);
            await _articleRepository.SaveAsync();

            var articleDto = _mapper.Map<ArticleDto>(article);
            return CreatedAtRoute("ArticleInfo", new { id = articleDto.ArticleId }, articleDto);
        }
    }
}