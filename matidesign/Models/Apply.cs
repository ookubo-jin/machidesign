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
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime InsDate { get; set; }

        [Required()]
        [DisplayName("更新日時")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}")]
        public DateTime UpdDate { get; set; }

        [Required()]
        [StringLength(1)]
        [DisplayName("有効フラグ")]
        [Range(0, 1, ErrorMessage = "{0}は{1}～{2}の間で入力してください。")]
        public string YukoFlg { get; set; }

        [StringLength(6)]
        [DisplayName("自治体コード")]
        public string JichitaiId { get; set; }

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