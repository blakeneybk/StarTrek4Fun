using OSA.Backend.CharacterApi.Client;
using OSA.Backend.StarshipApi.Client;
using OSA.FrontEnd.Api.Services;
using OSA.FrontEnd.Api.Services.Interface;

namespace OSA.FrontEnd.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Retrieve base addresses from configuration
            var backendOneBaseAddressConfig = builder.Configuration["CharacterApiService:OverrideBaseAddress"];
            var backendTwoBaseAddressConfig = builder.Configuration["StarshipApiService:OverrideBaseAddress"];

            // Register CharacterApi API client service
            builder.Services.AddCharacterApiClientService(
                !string.IsNullOrWhiteSpace(backendOneBaseAddressConfig) 
                    ? new Uri(backendOneBaseAddressConfig) 
                    : CharacterApiClientService.DefaultBaseAddress
            );

            // Register StarshipApi API client service
            builder.Services.AddStarshipApiClientService(
                !string.IsNullOrWhiteSpace(backendTwoBaseAddressConfig) 
                    ? new Uri(backendTwoBaseAddressConfig) 
                    : StarshipApiClientService.DefaultBaseAddress
            );

            //bind services
            builder.Services.AddSingleton<ICharacterService, CharacterApiService>();
            builder.Services.AddSingleton<IStarshipService, StarshipApiService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}