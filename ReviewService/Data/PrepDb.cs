using Microsoft.EntityFrameworkCore;

namespace ReviewService.Data
{
    public static class PrepDb
    {
        public static void prepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
