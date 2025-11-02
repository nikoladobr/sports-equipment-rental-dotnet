using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public interface IEntity
    {
        string TableName { get; }
        string Values { get; }
        List<string> JoinConditions { get; }
        List<string> JoinTableNames { get; }
        List<string> JoinColumnNames { get; }
        List<IEntity> GetReaderList(SqlDataReader reader);
    }
}
