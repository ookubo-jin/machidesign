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

        [Required()]
        [StringLength(400)]
        [DisplayName("アカウント名")]
        public string AccountName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("パスワード")]
        [StringLength(100, ErrorMessage = "{0} の長さは {2} 文字以上である必要があります。", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required()]
        [StringLength(100)]
        [DisplayName("性")]
        [RegularExpression("[^ -~｡-ﾟ]{1,100}", ErrorMessage = "{0}は全角文字で入力してください。")]
        public string LastName { get; set; }

        [Required()]
        [StringLength(100)]
        [DisplayName("名")]
        [RegularExpression("[^ -~｡-ﾟ]{1,100}", ErrorMessage = "{0}は全角文字で入力してください。")]
        public string FirstName { get; set; }

        [StringLength(100)]
        [DisplayName("性カナ")]
        public string LastNameK { get; set; }

        [StringLength(100)]
        [DisplayName("名カナ")]
        public string FirstNameK { get; set; }

    }
}