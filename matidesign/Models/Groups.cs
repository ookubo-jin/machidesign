using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace matidesign.Models
{
    public class Groups
    {
        [DisplayName("グループID")]
        public int GroupsId { get; set; }

        [Required()]
        [StringLength(6)]
        [DisplayName("自治体コード")]
        public string JichitaiCode { get; set; }

        [Required()]
        [StringLength(400)]
        [DisplayName("グループ名")]
        public string GroupsName { get; set; }

        [Required()]
        [StringLength(1)]
        [DisplayName("使用フラグ")]
        public string SiyoFlg { get; set; }

        [Required()]
        [DisplayName("作成日時")]
        public DateTime InsDate { get; set; }

        [Required()]
        [DisplayName("更新日時")]
        public DateTime UpdDate { get; set; }

        [Required()]
        [StringLength(8)]
        [DisplayName("開催日（開始）")]
        public string KaisaiDate_Start { get; set; }

    }
}