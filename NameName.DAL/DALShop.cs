using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NameName.Model;
namespace NameName.DAL
{
    public class DALShopInfo : DALBase
    {
        public IList<ShopInfo> GetShops()
        {
            IList<ShopInfo> shops = Reposi.Find<ShopInfo>(x => x.DeleteFlag == false).OrderBy(x => x.ShopNo).ToList();

            return shops;
        }

        public IList<ShopInfo> GetShopsByAreaID(Guid areaid)
        {
            IList<ShopInfo> shops = Reposi.Find<ShopInfo>(x => x.AreaID == areaid && x.DeleteFlag == false).OrderBy(x => x.ShopNo).ToList();
            return shops;
        }

        public void Save(ShopInfo shopinfo)
        {
            if (shopinfo.ShopID == Guid.Empty)
            {
                shopinfo.ShopID = Guid.NewGuid();
                Reposi.Add(shopinfo);
            }
            else
            {
                Reposi.Update(shopinfo);
            }
        }
        public ShopInfo GetByShopID(Guid shopid)
        {
            return Reposi.Single<ShopInfo>(shopid);
        }

        public void Delete(Guid shopid)
        {
            ShopInfo shopinfo = GetByShopID(shopid);
            shopinfo.DeleteFlag = true;
            Save(shopinfo);
        }


    }
}
