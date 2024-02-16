using Microsoft.EntityFrameworkCore;
using VRP.API.Models.Address;

namespace VRP.API.Seedings
{
    public static class LocationSeeding
    {
        public static void LocationData(this ModelBuilder builder)
        {
            builder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Hà Nội",
                    NumberIdentify = "29"
                },
                new City
                {
                    Id = 2,
                    Name = "Hải Dương",
                    NumberIdentify = "34"
                },
                new City
                {
                    Id = 3,
                    Name = "Hải Phòng",
                    NumberIdentify = "15"
                },
                new City
                {
                    Id = 4,
                    Name = "Hưng Yên",
                    NumberIdentify = "89"
                },
                new City
                {
                    Id = 5,
                    Name = "Nam Định",
                    NumberIdentify = "18"
                });

            builder.Entity<District>().HasData(
                new District
                {
                    Id = 1,
                    Name = "Quận Ba Đình",
                    CityId = 1,
                    NumberIdentify = "B1"
                }, new District
                {
                    Id = 2,
                    Name = "Quận Hoàn Kiếm",
                    CityId = 1,
                    NumberIdentify = "C1"
                }, new District
                {
                    Id = 3,
                    Name = "Quận Hai Bà Trưng",
                    CityId = 1,
                    NumberIdentify = "D1"
                }, new District
                {
                    Id = 4,
                    Name = "Quận Tây Hồ",
                    CityId = 1,
                    NumberIdentify = "F1"
                }, new District
                {
                    Id = 5,
                    Name = "Quận Cầu Giấy",
                    CityId = 1,
                    NumberIdentify = "P1"
                }, new District
                {
                    Id = 6,
                    Name = "Quận Hà Đông",
                    CityId = 1,
                    NumberIdentify = "T1"
                }, new District
                {
                    Id = 7,
                    Name = "Huyện Gia Lâm",
                    CityId = 1,
                    NumberIdentify = "N1"
                }, new District
                {
                    Id = 8,
                    Name = "Huyện Đông Anh",
                    CityId = 1,
                    NumberIdentify = "S1"
                }, new District
                {
                    Id = 9,
                    Name = "Huyện Thạch Thất",
                    CityId = 1,
                    NumberIdentify = "V5"
                }, new District
                {
                    Id = 10,
                    Name = "Huyện Hoài Đức",
                    CityId = 1,
                    NumberIdentify = "X5"
                });

            builder.Entity<Commune>().HasData(
                new Commune
                {
                    Id = 1,
                    Name = "Thị trấn Trạm Trôi",
                    DistrictId = 10,
                    NumberIdentify = string.Empty
                },
                new Commune
                {
                    Id = 2,
                    Name = "Xã An Khánh",
                    DistrictId = 10,
                    NumberIdentify = string.Empty
                },
                new Commune
                {
                    Id = 3,
                    Name = "Xã Lại Yên",
                    DistrictId = 10,
                    NumberIdentify = string.Empty
                },
                new Commune
                {
                    Id = 4,
                    Name = "Phường Vĩnh Phúc",
                    DistrictId = 1,
                    NumberIdentify = string.Empty
                },
                new Commune
                {
                    Id = 5,
                    Name = "Phường Trúc Bạch",
                    DistrictId = 1,
                    NumberIdentify = string.Empty
                }
                );
        }
    }
}
