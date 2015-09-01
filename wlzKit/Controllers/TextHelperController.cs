using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using wlzCommon;

namespace wlzKit.Controllers
{
    public class TextHelperController : Controller
    {
        //
        // GET: /TextHelper/

        public ActionResult EncodingShow()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EncodingText(string text,string type,string encodingType)
        {
            string message = "";
            string exMesssage = "";
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(type))
            {
                Encoding e = null;
                switch (encodingType)
                {
                    case "g":
                        e = Encoding.GetEncoding("gb2312");
                        break;
                    default:
                        e = Encoding.UTF8;
                        break;

                }
                //中文变Gb2312
                if (type == "e")
                {
                    text=HttpUtility.UrlEncode(text, e);
                }
                else if (type == "d")
                {
                    text=HttpUtility.UrlDecode(text, e);
                }
                return Json(new
                {
                    state = StandardMessage.Success,
                    data = text
                });
            }
            return Json(new
            {
                state = StandardMessage.Error,
                message = message
            });
        }
    }
}
