﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Http;
using Angular2MVC.DBContext;

namespace Angular2MVC.Controllers
{
    public class UserAPIController : BaseAPIController
    {
        public HttpResponseMessage Get()
        {
            return ToJson(UserDB.TblUsers.AsEnumerable());
        }

        public HttpResponseMessage Post([FromBody]TblUser value)
        {
            UserDB.TblUsers.Add(value);
            return ToJson(UserDB.SaveChanges());
        }

        public HttpResponseMessage Put(int id, [FromBody]TblUser value)
        {
            UserDB.Entry(value).State = EntityState.Modified;
            return ToJson(UserDB.SaveChanges());
        }
        public HttpResponseMessage Delete(int id)
        {
            UserDB.TblUsers.Remove(UserDB.TblUsers.FirstOrDefault(x => x.Id == id));
            return ToJson(UserDB.SaveChanges());
        }
    }
}
