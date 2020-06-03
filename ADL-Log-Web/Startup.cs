namespace ADL_Log_Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// The default program startup class. The typical dotnet core pattern.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">An injected configuration element. One of only a few default interfaces defined by Microsoft. Reads appSettings.json</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Store the configuration element for later reference
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">An injected service resolver. One of only a few default interfaces defined by Microsoft.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddMiniProfiler(options =>
            {
                // TODO: When 4.2.0 of the MP is released convert this to be fully asynx instead of this nonsense
                // To control authorization, you can use the Func<HttpRequest, bool> options:
                options.ResultsAuthorize = request => true;
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">An injected application builder. One of only a few default interfaces defined by Microsoft.</param>
        /// <param name="env">An injected hosting environment. One of only a few default interfaces defined by Microsoft.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable the mini profiler here so we can see it on the page
            // app.UseMiniProfiler();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
