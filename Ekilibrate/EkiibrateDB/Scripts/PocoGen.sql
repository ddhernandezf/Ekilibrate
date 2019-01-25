/*SELECT 
'using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Ekilibrate.Data.EntityModel.Abstract;
using Ekilibrate.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Ekilibrate.Model.Entity.Proyecto
{
	[DataContract(Namespace = "Ekilibrate.Model.Entity.Proyecto")]
    public class clsGrupo : IEntityPOCO<Int32>
	{'
UNION ALL
SELECT 
'	[DataMember]
	public ' + a1.NewType + ' ' + a1.COLUMN_NAME + ' {get;set;}'
 FROM 
(
SELECT TOP 100 PERCENT
COLUMN_NAME,
DATA_TYPE,
IS_NULLABLE,
CASE 
    WHEN DATA_TYPE = 'varchar' THEN 'string'
    WHEN DATA_TYPE = 'datetime' AND IS_NULLABLE = 'NO' THEN 'DateTime'
    WHEN DATA_TYPE = 'datetime' AND IS_NULLABLE = 'YES' THEN 'DateTime?'
	WHEN DATA_TYPE = 'date' AND IS_NULLABLE = 'NO' THEN 'DateTime'
    WHEN DATA_TYPE = 'date' AND IS_NULLABLE = 'YES' THEN 'DateTime?'
	WHEN DATA_TYPE = 'time' AND IS_NULLABLE = 'NO' THEN 'TimeSpan'
    WHEN DATA_TYPE = 'time' AND IS_NULLABLE = 'YES' THEN 'TimeSpan?'
    WHEN DATA_TYPE = 'int' AND IS_NULLABLE = 'YES' THEN 'int?'
    WHEN DATA_TYPE = 'int' AND IS_NULLABLE = 'NO' THEN 'int'
    WHEN DATA_TYPE = 'smallint' AND IS_NULLABLE = 'NO' THEN 'Int16'
    WHEN DATA_TYPE = 'smallint' AND IS_NULLABLE = 'YES' THEN 'Int16?'
    WHEN DATA_TYPE = 'decimal' AND IS_NULLABLE = 'NO' THEN 'decimal'
    WHEN DATA_TYPE = 'decimal' AND IS_NULLABLE = 'YES' THEN 'decimal?'
    WHEN DATA_TYPE = 'numeric' AND IS_NULLABLE = 'NO' THEN 'decimal'
    WHEN DATA_TYPE = 'numeric' AND IS_NULLABLE = 'YES' THEN 'decimal?'
    WHEN DATA_TYPE = 'money' AND IS_NULLABLE = 'NO' THEN 'decimal'
    WHEN DATA_TYPE = 'money' AND IS_NULLABLE = 'YES' THEN 'decimal?'
    WHEN DATA_TYPE = 'bigint' AND IS_NULLABLE = 'NO' THEN 'long'
    WHEN DATA_TYPE = 'bigint' AND IS_NULLABLE = 'YES' THEN 'long?'
    WHEN DATA_TYPE = 'tinyint' AND IS_NULLABLE = 'NO' THEN 'byte'
    WHEN DATA_TYPE = 'tinyint' AND IS_NULLABLE = 'YES' THEN 'byte?'
    WHEN DATA_TYPE = 'char' THEN 'string'
	WHEN DATA_TYPE = 'nvarchar' THEN 'string'
    WHEN DATA_TYPE = 'timestamp' THEN 'byte[]'
    WHEN DATA_TYPE = 'varbinary' THEN 'byte[]'
    WHEN DATA_TYPE = 'bit' AND IS_NULLABLE = 'NO' THEN 'bool'
    WHEN DATA_TYPE = 'bit' AND IS_NULLABLE = 'YES' THEN 'bool?'
    WHEN DATA_TYPE = 'xml' THEN 'string'
END AS NewType
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'PR.Grupo'
ORDER BY ORDINAL_POSITION
) AS a1
UNION ALL
SELECT 
'	
	Int32 IEntityPOCO<Int32>.Key
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
	}
}'*/