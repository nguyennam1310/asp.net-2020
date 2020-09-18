using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TAMS.DAL
{
    public class AttachmentContext : BaseContext
    {
        private static AttachmentContext _instance;
        public static AttachmentContext Instance()
        {
            if (null == _instance)
            {
                _instance = new AttachmentContext();
            }
            return _instance;
        }

        public void Create(Entity.Attachment obj)
        {
            string _FileName = Path.GetFileName(obj.file.FileName);
            string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images"), _FileName);
            obj.file.SaveAs(_path);
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_Attachment")
               .Parameter("Type", obj.Type)
               .Parameter("Name", _FileName)
               .Parameter("Url", obj.Url)
               .Parameter("DetailRecordId", obj.DetailRecordId)
               .Execute();

            }

        }


        public void Update(Entity.Attachment obj)
        {
            string _FileName = Path.GetFileName(obj.file.FileName);
            string _path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images"), _FileName);
            obj.file.SaveAs(_path);
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_Attachment")

                .Parameter("Id", obj.Id)
                .Parameter("Type", obj.Type)
               .Parameter("Name", _FileName)
               .Parameter("Url", obj.Url)
                .Execute();

            }
        }
        public void Create1(Entity.Attachment obj)
        {
            
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Create_Attachment1")
               .Parameter("Type", obj.Type)
            
               .Parameter("DetailRecordId", obj.DetailRecordId)
               .Execute();

            }

        }


        public void Update1(Entity.Attachment obj)
        {
            
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Update_Attachment1")

                .Parameter("Id", obj.Id)
                .Parameter("Type", obj.Type)
              
                .Execute();

            }
        }

        public void Delete(int Id)
        {
            using (var context = MasterDBContext())
            {
                context.StoredProcedure("dbo.Delete_Attachment")
                     .Parameter("Id", Id)
                     .Execute();
            }
        }

        public List<Entity.Attachment> GetAttachment(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_Attachment")
                    .Parameter("Id", Id)
                    .QueryMany<Entity.Attachment>();
            }
        }

        public List<Entity.Attachment> GetAttachments()
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.Read_Attachments")
            
                    .QueryMany<Entity.Attachment>();
            }
        }
        public Entity.Attachment GetById(int Id)
        {
            using (var context = MasterDBContext())
            {
                return context.StoredProcedure("dbo.GetByIdAttachment")
                    .Parameter("Id", Id)
                    .QuerySingle<Entity.Attachment>();
            }
        }

    }
}
