using AutoMapper;
using FTMS.DTOs;
using FTMS.models;
using FTMS.RepositoriesContracts;
using FTMS.ServiceContracts;
using FTMS.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Security.Claims;

namespace FTMS.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly FTMSContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PostRepository(FTMSContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetPostDto> CreatePostAsync(PostDto postDto)
        {
            if (postDto == null)
                throw new ArgumentNullException(nameof(postDto), "Post data cannot be null.");

            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            var post = new Post
            {
                Text = postDto.Text,
                GroupId = postDto.GroupId,
                TimeStamp = DateTime.UtcNow,
                UserId = userId
            };

            if (postDto.Image != null)
                post.Image = await ConvertFileToByteArrayAsync(postDto.Image);

            if (postDto.Video != null)
                post.Video = await ConvertFileToByteArrayAsync(postDto.Video);

            _context.posts.Add(post);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetPostDto>(post);
        }

        public async Task<GetPostDto> UpdatePostAsync(int postId, PostDto postDto)
        {
            var post = await _context.posts.FindAsync(postId);
            if (post == null)
                throw new KeyNotFoundException($"Post with ID {postId} not found.");

            post.Text = postDto.Text ?? post.Text;

            if (postDto.Image != null)
                post.Image = await ConvertFileToByteArrayAsync(postDto.Image);

            if (postDto.Video != null)
                post.Video = await ConvertFileToByteArrayAsync(postDto.Video);

            _context.posts.Update(post);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetPostDto>(post);
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            var post = await _context.posts.FindAsync(postId);
            if (post == null)
                throw new KeyNotFoundException($"Post with ID {postId} not found.");

            _context.posts.Remove(post);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<GetPostDto> GetPostByIdAsync(int postId)
        {
            var post = await _context.posts.FindAsync(postId);
            if (post == null)
                throw new KeyNotFoundException($"Post with ID {postId} not found.");

            return _mapper.Map<GetPostDto>(post);
        }

        public async Task<List<GetPostDto>> GetAllPostsAsync()
        {
            var posts = await _context.posts.ToListAsync();
            return _mapper.Map<List<GetPostDto>>(posts);
        }

        private async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }



}
