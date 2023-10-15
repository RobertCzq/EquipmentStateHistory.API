using Lego.EquipmentStateHistory.API.Infrastructure.Data;
using Lego.EquipmentStateHistory.API.Infrastructure.Repository;
using Lego.EquipmentStateHistory.API.Services;
using System.Text.Json.Serialization;

namespace Lego.EquipmentStateHistory.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                            .AddJsonOptions(options =>
                            {
                                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<IDataContext, DataContext>();
            builder.Services.AddScoped<IStateHistoryRepository, StateHistoryRepository>();
            builder.Services.AddScoped<IStateToColorConvertor, StateToColorConvertor>();
            builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}