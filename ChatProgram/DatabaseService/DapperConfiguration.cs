using Dapper.FluentMap;
using DatabaseService.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseService
{
    public static class DapperConfiguration
    {
        private static bool mapped;
        public static void Map()
        {
            if (mapped)
            {
                return;
            }
            FluentMapper.Initialize(config =>
            {
               config.AddMap(new UserMapper());
            });
        }

    }
}
