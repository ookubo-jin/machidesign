using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace matidesign.Models
{
    /// <summary>
    /// グループを表すクラス・コントロール
    /// </summary>
    public class Group
    {
        [Key]
        [DisplayName("グループID")]
        public long GroupId { get; set; }

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
        [StringLength(400)]
        [DisplayName("グループ名")]
        public string GroupName { get; set; }
        
        [EmailAddress]
        [StringLength(500)]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [EmailAddress]
        [StringLength(2000)]
        [DisplayName("URL")]
        [DataType(DataType.Url)]
        public string HomePege { get; set; }

        [EmailAddress]
        [StringLength(2000)]
        [DisplayName("イメージ画像")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required()]
        [StringLength(4000)]
        [DisplayName("概要")]
        [DataType(DataType.MultilineText)]
        public string GroupDescription { get; set; }

    }
}