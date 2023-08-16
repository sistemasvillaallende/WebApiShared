using WebApiShared.Services.CIDI;
using WebApiShared.Services;
using WebApiShared.Services.NOTIFICACIONES;
using WebApiShared.Services.LOGIN;

namespace WebApiShared
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
            services.AddControllers();
            services.AddSwaggerGen();

            // configure DI for application services
            services.AddScoped<IUsuariosServices, UsuariosService>();
            services.AddScoped<IRubrosService, RubrosService>();
            services.AddScoped<IComunicacionesService, ComunicacionesService>();
            services.AddScoped<IBarriosService, BarriosService>();
            services.AddScoped<ICallesService, CallesService>();
            services.AddScoped<INotificacion_digitalService, Notificacion_digitalService>();
            services.AddScoped<IUsuarioServices, UsuarioServices>();
            services.AddScoped<IUsuarioConOficina, UsuarioConOficina>();
            services.AddScoped<IResoluciones_multasService,Resoluciones_multasService>();
            services.AddScoped<IDet_notificacion_estado_proc_autoService, Det_notificacion_estado_proc_autoService>();
            services.AddScoped<IDet_notificacion_estado_proc_inmService, Det_notificacion_estado_proc_inmService>();
            services.AddScoped<IDet_notificacion_estado_proc_iycService, Det_notificacion_estado_proc_iycService>();
            services.AddScoped<INotificacion_estado_proc_autoService, Notificacion_estado_proc_autoService>();
            services.AddScoped<INotificacion_estado_proc_inmService, Notificacion_estado_proc_inmService>();
            services.AddScoped<INotificacion_estado_proc_iycService, Notificacion_estado_proc_iycService>();
            services.AddScoped<ITemplate_notificacionService, Template_notificacionService>();
            services.AddScoped<IEstados_procuracionService, Estados_procuracionService>();
            services.AddScoped<IPermisoServices,PermisoServices>();
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseStaticFiles();
                app.UseStaticFiles(new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers
                           .Add("X-Copyright", "Copyright 2016 - JMA");
                    }
                });
            }

            //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taskman API V1"); });

            app.UseRouting();
            // if (env.EnvironmentName == "Development")
            // {

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            Console.WriteLine(env.EnvironmentName);
            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
