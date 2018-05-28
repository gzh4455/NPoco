using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;


namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabase db = new Database("NorthWind");

            //Model.User oUser = db.Query<Model.User>().Where(x => x.UserId == "001").SingleOrDefault();

            ////Model.User oUser = db.SingleById<Model.User>("001");

            //System.Console.WriteLine(oUser.UserId);
            //System.Console.Write(oUser.Permissions.AsQueryable().ToList().Count);

            Model.User oUser = db.Query<Model.User>().IncludeMany(p => p.Permissions).Where(x => x.UserId == "003").FirstOrDefault();
            System.Console.WriteLine(oUser.UserId);
            System.Console.WriteLine(oUser.Permissions.Count);


            foreach (var permission in oUser.Permissions)
            {
                System.Console.WriteLine("Level:"+permission.PermissionLevel);
            }

            System.Console.WriteLine("Done");
            System.Console.ReadKey();

        }
    }
}
