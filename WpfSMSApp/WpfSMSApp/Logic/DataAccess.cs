using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSMSApp.Model;

namespace WpfSMSApp.Logic
{
    public class DataAccess
    {
        public static List<User> GetUesrs()
        {
            List<User> users;

            using (var ctx = new SMSEntities())
            {
                users = ctx.User.ToList(); // SELECT * FROM user 와 동일하다
            }

            return users;
        }

        public static int SetUser(User user)
        {
            using (var ctx = new SMSEntities())
            {
                ctx.User.AddOrUpdate(user);
                return ctx.SaveChanges();    // commit
            }
        }

        public static List<Store> GetStores()
        {
            List<Store> stores;

            using (var ctx = new SMSEntities()) //ctx = 데이터 컨테스트
            {
                stores = ctx.Store.ToList(); // SELECT * FROM Store 와 동일하다
            }

            return stores;
        }

        public static List<Stock> GetStocks()
        {
            List<Stock> stocks;

            using (var ctx = new SMSEntities()) //ctx = 데이터 컨테스트
            {
                stocks = ctx.Stock.ToList(); // SELECT * FROM Stock 와 동일하다
            }

            return stocks;
        }

        public static int SetStore(Store store)
        {
            using (var ctx = new SMSEntities())
            {
                ctx.Store.AddOrUpdate(store);
                return ctx.SaveChanges();    // commit
            }
        }
    }
}
