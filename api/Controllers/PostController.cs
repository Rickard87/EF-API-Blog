using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Post;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace api.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IPostRepository _postRepo;
        public PostController(ApplicationDBContext context, IPostRepository postRepo)
        {
            _postRepo = postRepo;

            _context = context;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var posts = await _postRepo.GetAllAsync(query);
            var postDto = posts.Select(s => s.ToPostDto());

            return Ok(postDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var post = await _postRepo.GetByIdAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            return Ok(post.ToPostDto());
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreatePostRequestDto postDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Hämta userId från token
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // <-- NYTT
            Console.WriteLine($"{userId ?? "null"} Hello!!");

            // if (string.IsNullOrEmpty(userId))
            //     return Unauthorized(); // <-- NYTT: Token saknar userId

            var postModel = postDto.ToPostFromCreateDto(userId);
            await _postRepo.CreateAsync(postModel);
            return CreatedAtAction(nameof(GetById), new { id = postModel.Id }, postModel.ToPostDto());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePostRequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var postModel = await _postRepo.UpdateAsync(id, updateDto);
            if (postModel == null)
            {
                return NotFound();
            }

            return Ok(postModel.ToPostDto());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var postModel = await _postRepo.DeleteAsync(id);

            if (postModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetPostsByUserId([FromRoute] string userId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var posts = await _postRepo.GetPostsByUserIdAsync(userId);

            if (posts == null || !posts.Any())
                return NotFound($"No posts found for userId {userId}");

            var postDtos = posts.Select(p => p.ToPostDto());
            return Ok(postDtos);
        }
    }
}