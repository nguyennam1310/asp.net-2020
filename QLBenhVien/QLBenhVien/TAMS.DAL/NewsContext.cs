using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TAMS.DAL
{
    public class NewsContext : BaseContext
    {
        private static NewsContext _instance;
        public static NewsContext Instance()
        {
            if (null == _instance)
            {
                _instance = new NewsContext();
            }
            return _instance;
        }

        public void Create(Entity.News obj)
        {
            string _FileName = Path.GetFileName(obj.file.FileName);
            string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images"), _FileName);
            obj.file.SaveAs(_path);

            using (var context = MasterDBContext())
            {

                context.StoredProcedure("dbo.Create_news")
                   .Parameter("Title", obj.Title)
                   .Parameter("Sapo", obj.Sapo)                   
                   .Parameter("CreateDate", obj.CreateDate)
                   .Parameter("Avatar", _FileName)
                   .Parameter("Description", obj.Description)
                   .Parameter("Active", obj.Active)
                   .Parameter("ModifyDate", obj.ModifyDate)
                   .Execute();
            }
        }
        public void Create1(Entity.News obj)
        {


            using (var context = MasterDBContext())
            {

                context.StoredProcedure("dbo.Create_news1")
                   .Parameter("Title", obj.Title)
                   .Parameter("Sapo", obj.Sapo)              
                   .Parameter("CreateDate", obj.CreateDate)
                   .Parameter("Description", obj.Description)
                   .Parameter("Active", obj.Active)
                   .Parameter("ModifyDate", obj.ModifyDate)
                   .Execute();
            }
        }

        public void Update(Entity.News obj)
        {
            string _FileName = Path.GetFileName(obj.file.FileName);
            string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/Img"), _FileName);
            obj.file.SaveAs(_path);
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_news")
                .Parameter("Title", obj.Title)
                .Parameter("Sapo", obj.Sapo)             
                .Parameter("Id", obj.Id)
                .Parameter("Avatar", _FileName)
                .Parameter("Description", obj.Description)
                .Parameter("Active", obj.Active)
                .Parameter("ModifyDate", obj.ModifyDate)
                .Execute();
            }
        }
        public void Update1(Entity.News obj)
        {

            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_news1")
                .Parameter("Title", obj.Title)
                .Parameter("Sapo", obj.Sapo)
                .Parameter("Id", obj.Id)
                .Parameter("Description", obj.Description)
                .Parameter("Active", obj.Active)
                .Parameter("ModifyDate", obj.ModifyDate)
                .Execute();
            }
        }

        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_news")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }

        public List<Entity.News> GetNews()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_news")
                   
                    .QueryMany<Entity.News>();
            }
        }
  

        public Entity.News GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.ListNews")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.News>();
            }
        }
       
     

    }
}
