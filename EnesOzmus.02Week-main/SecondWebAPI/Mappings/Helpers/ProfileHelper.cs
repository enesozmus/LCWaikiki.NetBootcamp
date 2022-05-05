using AutoMapper;

namespace SecondWebAPI.Mappings.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new ProductProfile(),
                new CategoryProfile(),
                new CustomerProfile()
            };
        }
    }
}
