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
    /// 自治体を表すクラス・コントロール
    /// </summary>
    public class Jichitai
    {

        [Key]
        [StringLength(6)]
        [DisplayName("自治体コード")]
        [RegularExpression("[0-9]{6}", ErrorMessage = "{0}は数字6桁で入力してください。")]
        //[Remote("CheckJichitaiId", "jichitaiController", ErrorMessage = "既にこの{0}は使用されています。")]
        public string JichitaiId { get; set; }

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
        //[RegularExpression("[0-1]{1}", ErrorMessage = "{0}は0か1を入力してください。")]
        public string YukoFlg { get; set; }

        [Required()]
        [StringLength(200)]
        [DisplayName("自治体名")]
        //[RegularExpression("^[ 　][^ -~。-゜][ 　]*${1,200}", ErrorMessage = "{0}は全角文字で入力してください。")]
        //[RegularExpression("[^[ 　][^ -~。-゜][ 　]*$]{1,200}", ErrorMessage = "{0}は全角文字で入力してください。")]
        [RegularExpression("[^ -~｡-ﾟ]{1,200}", ErrorMessage = "{0}は全角文字で入力してください。")]
        public string JichitaiName { get; set; }

    }

}