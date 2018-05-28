using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Console
{
    public class Model
    {
        [TableName("Permission")]
        [PrimaryKey("Id")]
        [ExplicitColumns]
        public partial class Permission
        {
            [Column]
            public string PermissionId { get; set; }

            [Column]
            public string PermissionLevel { get; set; }

            [Column]
            public string Note { get; set; }

            [Column]
            public string UserId { get; set; }

            [Column]
            public int Id { get; set; }



        }

        [TableName("User")]
        [PrimaryKey("UserId", AutoIncrement = false)]
        [ExplicitColumns]
        public partial class User
        {
            public User()
            {
                Permissions = new List<Permission>();
            }
            [Column]
            public string UserId { get; set; }

            [Column]
            public string UserName { get; set; }

            [Column]
            public bool? Sex { get; set; }

            [Column]
            public string HomeAddress { get; set; }


            [Reference(ReferenceType.Many, ColumnName = "UserId", ReferenceMemberName = "UserId")]
            public List<Permission> Permissions { get; set; }
        }
    }
}
