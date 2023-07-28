using MagicCottage_CottageAPI.Models.Dto;

namespace MagicCottage_CottageAPI.Data
{
    public static class CottageStore
    {
        public static List<CottageDTO> cottageList = new List<CottageDTO>
        {
                new CottageDTO{Id=1, Name="Pool View", Sqft=100, Occupancy=4},
                new CottageDTO{Id=2, Name="Beach View", Sqft=100, Occupancy=5}
        };
    }
}
