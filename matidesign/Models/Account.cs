using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace matidesign.Models
{
    /// <summary>
    /// アカウントを表すクラス・コントロール（検討中）
    /// </summary
    public class Account
    {
        [Key]
        [StringLength(100)]
        [DisplayName("アカウントID")]
        public string AccountId { get; set; }

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
        [StringLength(400)]
        [DisplayName("アカウント名")]
        public string AccountName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} の長さは {2} 文字以上である必要があります。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [DisplayName("パスワード")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("電子メール")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required()]
        [StringLength(400)]
        [DisplayName("性")]
        public string LastName { get; set; }

        [Required()]
        [StringLength(400)]
        [DisplayName("名")]
        public string FirstName { get; set; }

        [StringLength(400)]
        [DisplayName("性カナ")]
        public string LastNameK { get; set; }

        [StringLength(400)]
        [DisplayName("名カナ")]
        public string FirstNameK { get; set; }

    }
}