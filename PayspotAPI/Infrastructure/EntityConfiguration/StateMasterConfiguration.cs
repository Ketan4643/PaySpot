using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PayspotAPI.Infrastructure.EntityConfiguration
{
    public class StateMasterConfiguration : IEntityTypeConfiguration<StateMaster>
    {
        public void Configure(EntityTypeBuilder<StateMaster> builder)
        {
            builder.HasData(
                new StateMaster { Id =  1, StateName = "Andaman and Nicobar Islands", StateCode = "AN", GstStateCode = 35 },
                new StateMaster { Id =  2, StateName = "Andhra Pradesh", StateCode = "AP", GstStateCode = 37 },
                new StateMaster { Id =  3, StateName = "Arunachal Pradesh", StateCode = "AR", GstStateCode = 12 },
                new StateMaster { Id =  4, StateName = "Assam", StateCode = "AS", GstStateCode = 18 },
                new StateMaster { Id =  5, StateName = "Bihar", StateCode = "BR", GstStateCode = 10 },
                new StateMaster { Id =  6, StateName = "Chandigarh", StateCode = "CH", GstStateCode = 4 },
                new StateMaster { Id =  7, StateName = "Chhattisgarh", StateCode = "CG", GstStateCode = 22 },
                new StateMaster { Id =  8, StateName = "Dadra and Nagar Haveli", StateCode = "DN", GstStateCode = 26 },
                new StateMaster { Id =  9, StateName = "Daman and Diu", StateCode = "DD", GstStateCode = 25 },
                new StateMaster { Id = 10, StateName = "Delhi", StateCode = "DL", GstStateCode = 7 },
                new StateMaster { Id = 11, StateName = "Goa", StateCode = "GA", GstStateCode = 30 },
                new StateMaster { Id = 12, StateName = "Gujarat", StateCode = "GJ", GstStateCode = 24 },
                new StateMaster { Id = 13, StateName = "Haryana", StateCode = "HR", GstStateCode = 6 },
                new StateMaster { Id = 14, StateName = "Himachal Pradesh", StateCode = "HP", GstStateCode = 2 },
                new StateMaster { Id = 15, StateName = "Jammu and Kashmir", StateCode = "JK", GstStateCode = 1 },
                new StateMaster { Id = 16, StateName = "Jharkhand", StateCode = "JH", GstStateCode = 20 },
                new StateMaster { Id = 17, StateName = "Karnataka", StateCode = "KA", GstStateCode = 29 },
                new StateMaster { Id = 18, StateName = "Kerala", StateCode = "KL", GstStateCode = 32 },
                new StateMaster { Id = 19, StateName = "Ladakh", StateCode = "LA", GstStateCode = 38 },
                new StateMaster { Id = 20, StateName = "Lakshadweep", StateCode = "LD", GstStateCode = 31 },
                new StateMaster { Id = 21, StateName = "Madhya Pradesh", StateCode = "MP", GstStateCode = 23 },
                new StateMaster { Id = 22, StateName = "Maharashtra", StateCode = "MH", GstStateCode = 27 },
                new StateMaster { Id = 23, StateName = "Manipur", StateCode = "MN", GstStateCode = 14 },
                new StateMaster { Id = 24, StateName = "Meghalaya", StateCode = "ML", GstStateCode = 17 },
                new StateMaster { Id = 25, StateName = "Mizoram", StateCode = "MZ", GstStateCode = 15 },
                new StateMaster { Id = 26, StateName = "Nagaland", StateCode = "NL", GstStateCode = 13 },
                new StateMaster { Id = 27, StateName = "Odisha", StateCode = "OR", GstStateCode = 21 },
                new StateMaster { Id = 28, StateName = "Other Territory", StateCode = "OT", GstStateCode = 97 },
                new StateMaster { Id = 29, StateName = "Puducherry", StateCode = "PY", GstStateCode = 34 },
                new StateMaster { Id = 30, StateName = "Punjab", StateCode = "PB", GstStateCode = 3 },
                new StateMaster { Id = 31, StateName = "Rajasthan", StateCode = "RJ", GstStateCode = 8 },
                new StateMaster { Id = 32, StateName = "Sikkim", StateCode = "SK", GstStateCode = 11 },
                new StateMaster { Id = 33, StateName = "Tamil Nadu", StateCode = "TN", GstStateCode = 33 },
                new StateMaster { Id = 34, StateName = "Telangana", StateCode = "TS", GstStateCode = 36 },
                new StateMaster { Id = 35, StateName = "Tripura", StateCode = "TR", GstStateCode = 16 },
                new StateMaster { Id = 36, StateName = "Uttar Pradesh", StateCode = "UP", GstStateCode = 9 },
                new StateMaster { Id = 37, StateName = "Uttarakhand", StateCode = "UA", GstStateCode = 5 },
                new StateMaster { Id = 38, StateName = "West Bengal", StateCode = "WB", GstStateCode = 19 },
                new StateMaster { Id = 39, StateName = "Foreign Country	", StateCode = "FC", GstStateCode = 96 }
            );
        }
    }
}