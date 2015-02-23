using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace matidesign.Models
{
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

      var groups = new List<Groups> {

        new Groups {GroupId=1, 
                        //作成日時セット
                        InsDate = DateTime.Now,
                        //更新日時セット
                        UpdDate = DateTime.Now,
                        //有効フラグセット
                        YukoFlg = "1",
                        JichitaiId = "123456",
                        GroupName = "code for KORIYAMA",
                        GroupDescription = "code for KORIYAMA"
                        }
      };
      groups.ForEach(b => context.groups.Add(b));
      context.SaveChanges();
    }
  }
}