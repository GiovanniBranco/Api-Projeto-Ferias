using System;
using System.Text;
using Api_Projeto_Ferias.Data;
using Api_Projeto_Ferias.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;


namespace Api_Projeto_Ferias
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<FeriasContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ConexaoSqlServer")));

            IdentityBuilder builder = services.AddIdentityCore<Usuario>(opcoes =>
            {
                opcoes.Password.RequireDigit = true;
                opcoes.Password.RequireUppercase = true;
                opcoes.Password.RequireLowercase = true;
                opcoes.Password.RequireNonAlphanumeric = false;
                opcoes.Password.RequiredLength = 8;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services)
                .AddEntityFrameworkStores<FeriasContext>()
                .AddSignInManager<SignInManager<Usuario>>()
                .AddRoleManager<RoleManager<Role>>()
                .AddRoleValidator<RoleValidator<Role>>();


            services.AddAuthentication(opcoes =>
            {
                opcoes.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opcoes.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opcoes =>
                {
                    opcoes.RequireHttpsMetadata = false;
                    opcoes.SaveToken = true;
                    opcoes.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["ChaveToken:SegredoJWT"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(c => c
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin());

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
