using Application.Mapper;
using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MySpace.Application.User;
using MySpace.WebAPI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("DataAccess"));
    //UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



builder.Services.AddGrpc();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddMediatR(typeof(CreateUserRequest).Assembly);

var app = builder.Build();
app.UseRouting();
app.UseGrpcWeb(new GrpcWebOptions() { DefaultEnabled = true });
app.MapGrpcService<UsersService>();
app.MapGrpcService<CategoryService>();
app.MapGrpcService<SpaceService>();
app.MapGrpcService<NoteService>();
app.MapGrpcService<MembersService>();
app.MapGrpcService<FileService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapControllers();

app.Run();
