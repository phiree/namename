﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
using NHibernate;
namespace NameName.DAL
{
    public class DAShopSellList : DALBase<Shop_SellList>
    {
        public void SaveList(Shop_SellList currentList )
        {
            session.Save(currentList);
        }

    }
}