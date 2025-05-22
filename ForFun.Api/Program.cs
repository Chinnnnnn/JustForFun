using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace ForFun.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateSlimBuilder(args);

            builder.Services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
            });


            // 連接字串（可搬到 appsettings.json）
            var connectionString = builder.Configuration.GetConnectionString("mysql") ?? "";

            // 註冊 DbContext
            builder.Services.AddDbContext<OwnDevContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddScoped<Zhouyi>();

            var app = builder.Build();

            var sampleTodos = new Todo[] {
                new(1, "Walk the dog"),
                new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
                new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
                new(4, "Clean the bathroom"),
                new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
            };

            var todosApi = app.MapGroup("/todos");
            todosApi.MapGet("/", () => sampleTodos);
            todosApi.MapGet("/{id}", (int id) =>
                sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
                    ? Results.Ok(todo)
                    : Results.NotFound());

            var trigramApi = app.MapGroup("zhouyi/trigram");
            trigramApi.MapGet("/{num}", (int num, Zhouyi zhouyi) =>
            {
                var res = zhouyi.GetTrigram(num);
                var aaa = JsonConvert.SerializeObject(res);
                return (res.Num != -1) ? Results.Ok(res) : Results.BadRequest(res);
            });

            var hexgramApi = app.MapGroup("zhouyi/hexgram");
            hexgramApi.MapGet("/{up}&{bottom}", (int up, int bottom, Zhouyi zhouyi) =>
            {
                var res = zhouyi.GetHexagram(up, bottom);
                var aaa = JsonConvert.SerializeObject(res);
                return (!string.IsNullOrWhiteSpace(res.NumKey)) ? Results.Ok(res) : Results.BadRequest(res);
            });

            app.Run();
        }
    }

    public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

    [JsonSerializable(typeof(Todo[]))]
    internal partial class AppJsonSerializerContext : JsonSerializerContext
    {

    }
}
