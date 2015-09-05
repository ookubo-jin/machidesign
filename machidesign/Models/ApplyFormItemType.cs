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
    /// 申込みフォーム項目内容を表すクラス・コントロール
    /// </summary>
    public class ApplyFormItemType
    {
        [Key]
        [DisplayName("グループID")]
        public long GroupId { get; set; }

        [DisplayName("グループ情報")]
        public virtual Group Group { get; set; }

        [Key]
        [DisplayName("申込みフォーム項目ID")]
        public int ApplyFormItemId { get; set; }

        [DisplayName("申込みフォーム項目情報")]
        public virtual ApplyFormItem ApplyFormItem { get; set; }

        [Key]
        [DisplayName("申込みフォーム項目内容ID")]
        public int ApplyFormItemTypeId { get; set; }

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

        [Required()]
        [StringLength(400)]
        [DisplayName("申込みフォーム項目内容名")]
        public string TypeName { get; set; }

        [StringLength(4000)]
        [DisplayName("申込みフォーム項目内容概要")]
        [DataType(DataType.MultilineText)]
        public string TypeDescription { get; set; }

        [DisplayName("申込みフォーム項目内容順番")]
        public int TypeSort { get; set; }

    }
}