using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DatabaseService
{
    public static class ExtentionsMethods
    {
        public static IDbDataParameter AddParameter(this IDbCommand command, string parametertype, DbType dbType, object value)
        {
            IDbDataParameter dataParameter = command.CreateParameter();
            dataParameter.DbType = dbType;
            dataParameter.ParameterName = parametertype;
            dataParameter.Value = value;
            command.Parameters.Add(dataParameter);
            return dataParameter;
        }
    }
}
