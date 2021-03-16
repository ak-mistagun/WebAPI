using Microsoft.Extensions.Configuration;

namespace WebAPI.Untils
{
    public static class Cfg
    {
        public static bool IsInMemoryDatabase(this IConfiguration cfg)
        {
            return cfg.GetValue<bool>("IsInMemoryDatabase");
        }

        public static bool IsAngularActive(this IConfiguration cfg)
        {
            return cfg.GetValue<bool>("IsAngularActive");
        }
        
    }
}