using Dapper.Contrib.Extensions;
using Lazulisoft.ApiDotNetDapper.Api.Models;
using System;

namespace Lazulisoft.ApiDotNetDapper.Api.App_Start
{
    public static class DapperConfig
    {
        public static void Init()
        {
            // TableNameMappers
            SqlMapperExtensions.TableNameMapper = entityType =>
            {
                if (entityType == typeof(Hero))
                {
                    return "Hero";
                }

                throw new Exception($"Not supported entity type {entityType}");
            };
        }
    }
}
