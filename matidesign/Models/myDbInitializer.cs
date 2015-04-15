using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace matidesign.Models
{
    //public class myDbInitializer: DropCreateDatabaseAlways<machidesignDBContext>  
    public class myDbInitializer: DropCreateDatabaseIfModelChanges<machidesignDBContext>  
  {
    protected override void Seed(machidesignDBContext context)  
    {
        //初期データ作成 Jichitai

        var jichitai = new List<Jichitai> {

        new Jichitai { JichitaiId = "123456",
                        //作成日時セット
                        InsDate = DateTime.Now,
                        //更新日時セット
                        UpdDate = DateTime.Now,
                        //有効フラグセット
                        YukoFlg = "1",
                        JichitaiName = "郡山市"
                        },
        new Jichitai { JichitaiId = "888888",
                        //作成日時セット
                        InsDate = DateTime.Now,
                        //更新日時セット
                        UpdDate = DateTime.Now,
                        //有効フラグセット
                        YukoFlg = "1",
                        JichitaiName = "世界"
                        },
        new Jichitai { JichitaiId = "999999",
                        //作成日時セット
                        InsDate = DateTime.Now,
                        //更新日時セット
                        UpdDate = DateTime.Now,
                        //有効フラグセット
                        YukoFlg = "1",
                        JichitaiName = "全国"
                        }
      };
      jichitai.ForEach(b => context.jichitai.Add(b));
      context.SaveChanges();

      //初期データ作成 Groups

      var group = new List<Group> {

        new Group {GroupId=1, 
                        //作成日時セット
                        InsDate = DateTime.Now,
                        //更新日時セット
                        UpdDate = DateTime.Now,
                        //有効フラグセット
                        YukoFlg = "1",
                        JichitaiId = "123456",
                        GroupName = "code for KORIYAMA",
                        GroupDescription = "code for KORIYAMA"
                        },
        new Group {GroupId=2, 
                        //作成日時セット
                        InsDate = DateTime.Now,
                        //更新日時セット
                        UpdDate = DateTime.Now,
                        //有効フラグセット
                        YukoFlg = "1",
                        JichitaiId = "999999",
                        GroupName = "エフスタ",
                        GroupDescription = "エフスタ"
                        }

      };
      group.ForEach(b => context.group.Add(b));
      context.SaveChanges();

      //初期データ作成 Account

      var account = new List<Account> {

        new Account {AccountId="code4koriyama", 
                        //作成日時セット
                        InsDate = DateTime.Now,
                        //更新日時セット
                        UpdDate = DateTime.Now,
                        //有効フラグセット
                        YukoFlg = "1",
                        AccountName = "エフスタ君",
                        Password = "code4koriyama",
                        Email = "code4koriyama@gmail.com",
                        LastName = "大久保",
                        FirstName = "仁",
                        LastNameK = "ｵｵｸﾎﾞ",
                        FirstNameK = "ｼﾞﾝ"
                        }

      };
      account.ForEach(b => context.account.Add(b));
      context.SaveChanges();

      //初期データ作成 Events

      var events = new List<Events> {

        new Events {EventsId=1, 
                        //作成日時セット
                        InsDate = DateTime.Now,
                        //更新日時セット
                        UpdDate = DateTime.Now,
                        //有効フラグセット
                        YukoFlg = "1",
                        GroupId =1,
                        EventName = "まち歩き",
                        KaisaiDate_Start =  DateTime.Now,
                        KaisaiTime_Start = "10:00",
                        KaisaiDate_End =  DateTime.Now,
                        KaisaiTime_End = "18:00",
                        EventDescription = "まち歩き",
                        EventDetails = "まち歩き",
                        MaxNinzu = 20,
                        Kaihi = 500
                        }

      };
      events.ForEach(b => context.events.Add(b));
      context.SaveChanges();
    }
  }
}