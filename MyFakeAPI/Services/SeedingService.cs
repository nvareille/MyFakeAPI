using System.IO;

namespace MyFakeAPI.Services
{
    public class SeedingService
    {
        public SeedingService()
        {
            if (!Directory.Exists("Seeds/"))
                Directory.CreateDirectory("Seeds/");

        }
    }
}
