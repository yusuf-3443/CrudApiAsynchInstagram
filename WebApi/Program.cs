using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Services;
using Infrastructure.Services.CommentService;
using Infrastructure.Services.MetaService;
using Infrastructure.Services.PostCategoryService;
using Infrastructure.Services.PostService;
using Infrastructure.Services.PostTagService;
using Infrastructure.Services.TagService;
using Infrastructure.Services.UserService;

var builder=WebApplication.CreateBuilder();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IMetaService, MetaService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostCategoryService, PostCategoryService>();
builder.Services.AddScoped<IPostTagService, PostTagService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<DapperContext>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app=builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();