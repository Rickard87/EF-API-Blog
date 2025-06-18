using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Post;
using api.Models;

namespace api.Mappers
{
    public static class PostMappers
    {
        public static PostDto ToPostDto(this Post postModel)
        {
            return new PostDto
            {
                Id = postModel.Id,
                Title = postModel.Title,
                Body = postModel.Body,
                CreatedOn = postModel.CreatedOn,
                Comments = postModel.Comments.Select(c => c.ToCommentDto()).ToList(),
                AppUserId = postModel.AppUserId
            };
        }
        public static Post ToPostFromCreateDto(this CreatePostRequestDto postDto, string userId)
        {
            return new Post
            {
                Title = postDto.Title,
                Body = postDto.Body,
                CreatedOn = postDto.CreatedOn,
                AppUserId = userId
            };
        }
    }
}