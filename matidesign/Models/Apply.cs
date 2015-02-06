using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace matidesign.Models
{
    /// <summary>
    /// 申し込みを表すクラス・コントロール（検討中）
    /// </summary>
    public class Apply
    {
        [Key]
        [DisplayName("イベントID")]
        public int EventsId { get; set; }
        
        [Key]
        [DisplayName("申し込みID")]
        public int ApplyId { get; set; }

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
        public string JichitaiCode { get; set; }

        [Required()]
        [StringLength(100)]
        [DisplayName("アカウントID")]
        public string AccountId { get; set; }

        [Required()]
        [DisplayName("申込日時")]
        public DateTime ApplyDate { get; set; }

        [Required()]
        [DisplayName("キャンセル日時")]
        public DateTime CancellDate { get; set; }
    
    
    }
}