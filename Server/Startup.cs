public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add controllers
        services.AddControllers();

        // Add Swagger for API documentation
        services.AddSwaggerGen();

        // Add CORS policy
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        // Add other services (e.g., DbContext, Identity, etc.)
        // services.AddDbContext<ApplicationDbContext>(options =>
        //     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            // Enable Swagger in development
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinic Management System API v1");
            });
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        // Enable CORS
        app.UseCors("AllowAll");

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}