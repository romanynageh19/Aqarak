using AqarakCore.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AqarakRepository.Data
{
    public class DataSeeding
    {
        public static async Task DataSeed(StoreContext _dbcontex)
        {


            //var usersJson = File.ReadAllText("C:\\Users\\hp\\source\\repos\\Aqarak\\AqarakRepository\\Data\\Data Seeding JSON Files\\users_only.json");

            //var userList = JsonSerializer.Deserialize<List<User>>(usersJson);

            //if (userList != null && userList.Any())
            //{
            //    foreach (var user in userList)
            //    {
            //        _dbcontex.Set<User>().Add(user);
            //    }

            //    await _dbcontex.SaveChangesAsync();
            //}








            //var propDta = File.ReadAllText("C:\\Users\\hp\\source\\repos\\Aqarak\\AqarakRepository\\Data\\Data Seeding JSON Files\\properties_only.json");
            //var properties = JsonSerializer.Deserialize<List<MyProperty>>(propDta);
            //if (properties?.Count() > 0)
            //{
            //    foreach (var prop in properties)
            //   {
            //      _dbcontex.Set<MyProperty>().Add(prop);
            //  }
            //   await _dbcontex.SaveChangesAsync();
            //}




           


        }
    }
}

