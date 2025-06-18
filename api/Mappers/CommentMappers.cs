using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Body = commentModel.Body,
                CreatedOn = commentModel.CreatedOn,
                PostId = commentModel.PostId,
                AppUserId = commentModel.AppUserId
            };
        }
        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int postId, string userId)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Body = commentDto.Body,
                PostId = postId,
                AppUserId = userId
            };
        }
        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Body = commentDto.Body,
            };
        }
    }
}