using HrAdm.Enums;
using HrAdm.Models;
using HrAdm.Services;

namespace HrAdm.Controllers
{
    //[XgProgAuth]
    public class CmsMsgController : XpCmsController
    {
        //constructor
        public CmsMsgController()
        {
            ProgName = "最新消息維護";
            CmsType = CmsTypeEstr.Msg;
            DirUpload = _Xp.DirCmsType(CmsType);
            EditDto = new CmsEditDto()
            {
                Title = "主旨",
                Text = "內容",
                //Html = "Html",
                Note = "備註",
                FileName = "上傳檔案",
                StartTime = "發佈起日",
                EndTime = "發佈迄日",
            };
        }

    }//class
}