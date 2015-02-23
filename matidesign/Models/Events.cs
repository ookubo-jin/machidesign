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
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime InsDate { get; set; }

        [Required()]
        [DisplayName("更新日時")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime UpdDate { get; set; }

        [StringLength(100)]
        [DisplayName("作成アカウントID")]
        public string InsAccountId { get; set; }

        [StringLength(100)]
        [DisplayName("更新アカウントID")]
        public string UpdAccountId { get; set; }

        [Required()]
        [StringLength(1)]
        [DisplayName("有効フラグ")]
        [Range(0, 1, ErrorMessage = "{0}は{1}～{2}の間で入力してください。")]
        public string YukoFlg { get; set; }

        [StringLength(6)]
        [DisplayName("自治体コード")]
        public string JichitaiId { get; set; }

        [DisplayName("自治体")]
        public virtual Jichitai Jichitai { get; set; }

        [Required()]
        [DisplayName("グループID")]
        public int GroupsId { get; set; }

        [DisplayName("グループ")]
        public virtual Groups Groups { get; set; }

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