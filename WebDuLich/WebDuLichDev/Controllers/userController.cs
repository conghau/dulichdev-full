using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebDuLichDev.Controllers
{
    public class UserController : ApiController
    {
        public string Index(int a)
        {
            return "userController" + a;
        }
    }
}
