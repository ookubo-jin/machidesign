using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace matidesign.Models
{
    /// <summary>
    /// まち歩き結果項目を格納するクラス・コントロール
    /// </summary>
    public class MachiarukiDataDetails
    {

        [Key]
        [DisplayName("イベントID")]
        public long EventsId { get; set; }

        [DisplayName("イベント情報")]
        public virtual Events Events { get; set; }

        [Key]
        [StringLength(100)]
        [DisplayName("アカウントID")]
        public string AccountId { get; set; }

        [DisplayName("アカウント情報")]
        public virtual Account Account { get; set; }

        [Key]
        [StringLength(13)]
        [DisplayName("作成キー")]
        public string CreateKey { get; set; }

        [Required()]
        [DisplayName("作成日時")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime InsDate { get; set; }

        [Required()]
        [DisplayName("更新日時")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
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

        [DisplayName("まち歩き項目ID")]
        public int MachiarukiDetailsId { get; set; }

        [DisplayName("まち歩き項目情報")]
        public virtual MachiarukiItem MachiarukiDetails { get; set; }

        [DisplayName("項目（数字）")]
        public double ItemNum { get; set; }

        [DisplayName("項目（文字）")]
        public string ItemStr { get; set; }

    }
}