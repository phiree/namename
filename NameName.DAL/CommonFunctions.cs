﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NameName.DAL
{
   public  class CommonFunctions:DALBase<DateTime>
    {
       public DateTime GetServerTime()
       {
           DateTime dt = session.CreateSQLQuery("select getdate()").UniqueResult<DateTime>();

         return dt;
       }
    }
}
