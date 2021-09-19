using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQLAdvanced.Consumers;
using GraphQLAdvanced.Contracts;
using GraphQLAdvanced.Entities.Context;
using GraphQLAdvanced.GraphQL.GraphQLSchema;
using GraphQLAdvanced.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace GraphQLAdvanced
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("sqlConString")));

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            
            services.AddScoped<AppSchema>();

            services.AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped)
                .AddDataLoader();
            
            services.AddScoped<IGraphQLClient>(s => new GraphQLHttpClient(Configuration["GraphQLURI"], new NewtonsoftJsonSerializer()));
            services.AddScoped<OwnerConsumer>();

            services.AddControllers()
                .AddNewtonsoftJson(o => 
                    o.SerializerSettings.ReferenceLoopHandling = 
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseGraphQL<AppSchema>();
            app.UseGraphQLPlayground(options: new PlaygroundOptions());

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}