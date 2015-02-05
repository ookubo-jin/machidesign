using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace matidesign.Models
{
    /// <summary>
    /// Jichitaiを表すクラス・コントロール
    /// </summary>
    public class Jichitai
    {
        public string JichitaiId { get; set; }

        [Required()]
        [StringLength(6)]
        [DisplayName("自治体コード")]
        public string JichitaiCode { get; set; }

        [Required()]
        [StringLength(80)]
        [DisplayName("自治体名")]
        public string JichitaiName { get; set; }

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

    }

}