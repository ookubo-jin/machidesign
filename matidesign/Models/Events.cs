using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace matidesign.Models
{
    /// <summary>
    /// イベントを表すクラス・コントロール
    /// </summary>
    public class Events
    {
        [Key]
        [DisplayName("イベントID")]
        public int EventId { get; set; }

        [Required()]
        [DisplayName("作成日時")]
        public DateTime InsDate { get; set; }

        [Required()]
        [DisplayName("更新日時")]
        public DateTime UpdDate { get; set; }

        [Required()]
        [StringLength(1)]
        [DisplayName("有効フラグ")]
        public string YukoFlg { get; set; }

        [Required()]
        [StringLength(6)]
        [DisplayName("自治体コード")]
        public string JichitaiId { get; set; }

        [Required()]
        [DisplayName("グループID")]
        public int GroupsId { get; set; }

        [Required()]
        [StringLength(400)]
        [DisplayName("イベント名")]
        public string EventName { get; set; }

        [Required()]
        [StringLength(8)]
        [DisplayName("開催日（開始）")]
        public string KaisaiDate_Start { get; set; }

        [Required()]
        [StringLength(4)]
        [DisplayName("開催時間（開始）")]
        public string KaisaiTime_Start { get; set; }

        [Required()]
        [StringLength(8)]
        [DisplayName("開催日（終了）")]
        public string KaisaiDate_End { get; set; }

        [Required()]
        [StringLength(4)]
        [DisplayName("開催時間（終了）")]
        public string KaisaiTime_End { get; set; }

        [Required()]
        [StringLength(4000)]
        [DisplayName("イベント概要")]
        [DataType(DataType.MultilineText)]
        public string EventDescription { get; set; }

        [Required()]
        [StringLength(4000)]
        [DisplayName("イベント詳細")]
        [DataType(DataType.MultilineText)]
        public string EventDetails { get; set; }

        [DisplayName("参加人数")]
        public int MaxNinzu { get; set; }

    }
}