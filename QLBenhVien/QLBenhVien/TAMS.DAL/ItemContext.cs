using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAMS.DAL
{
    public class ItemContext : BaseContext
    {
        private static ItemContext _instance;
        public static ItemContext Instance()
        {
            if (null == _instance)
            {
                _instance = new ItemContext();
            }
            return _instance;
        }

        public void Create(Entity.Item obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_Item")
               .Parameter("Name", obj.Name)
               .Parameter("Amount", obj.Amount)
               .Parameter("Description", obj.Description)
               .Parameter("CategoryId", obj.CategoryId)
               .Execute();

            }

        }
        public void Create1(Entity.Item obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_Item1")
               .Parameter("Name", obj.Name)
               .Parameter("Amount", obj.Amount)
               .Parameter("Description", obj.Description)
               .Parameter("CategoryName", obj.CategoryName)
               .Execute();

            }

        }
        public void DeleteDuplicateItem()
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Duplicate_Item")
                .Execute();
            }
        }
        public void Update(Entity.Item obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_Item")

                .Parameter("Id", obj.Id)
                 .Parameter("Name", obj.Name)
               .Parameter("Amount", obj.Amount)
               .Parameter("Description", obj.Description)
               .Parameter("CategoryId", obj.CategoryId)
                .Execute();

            }
        }


        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Item")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }
      
        public int Count1(int Id)
        {
            int num = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Count_Item1")
                      .Parameter("Id", Id)
                      .ParameterOut("Num", FluentData.DataTypes.Int32);
                cmd.Execute();
                num = cmd.ParameterValue<int>("num");
            }
            return num;
        }
        public int Count2(int Id)
        {
            int num = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Count_Item2")
                      .Parameter("Id", Id)
                      .ParameterOut("Num", FluentData.DataTypes.Int32);
                cmd.Execute();
                num = cmd.ParameterValue<int>("num");
            }
            return num;
        }
        public int Count3(int Id)
        {
            int num = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Count_Item3")
                      .Parameter("Id", Id)
                      .ParameterOut("Num", FluentData.DataTypes.Int32);
                cmd.Execute();
                num = cmd.ParameterValue<int>("num");
            }
            return num;
        }
        public int Count4(int Id)
        {
            int num = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Count_Item4")
                      .Parameter("Id", Id)
                      .ParameterOut("Num", FluentData.DataTypes.Int32);
                cmd.Execute();
                num = cmd.ParameterValue<int>("num");
            }
            return num;
        }
        public int Count5(int Id)
        {
            int num = 0;
            using (var context = MasterDBContext())
            {
                var cmd = context.StoredProcedure("dbo.Count_Item5")
                      .Parameter("Id", Id)
                      .ParameterOut("Num", FluentData.DataTypes.Int32);
                cmd.Execute();
                num = cmd.ParameterValue<int>("num");
            }
            return num;
        }
        public List<Entity.Item> GetItem(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_Item")
                    .Parameter("Id", Id)
                    .QueryMany<Entity.Item>();
            }
        }
        public List<Entity.Item> GetItems()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_Items")
                    .QueryMany<Entity.Item>();
            }
        }


        public Entity.Item GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdItem")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.Item>();
            }
        }
    }
}
