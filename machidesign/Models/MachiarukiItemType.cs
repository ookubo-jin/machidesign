﻿using System;
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
    /// まち歩き項目内容を表すクラス・コントロール
    /// </summary>
    public class MachiarukiItemType
    {
        [Key]
        [DisplayName("イベントID")]
        public long EventsId { get; set; }

        [DisplayName("イベント情報")]
        public virtual Events Events { get; set; }

        [Key]
        [DisplayName("まち歩き項目ID")]
        public int MachiarukiItemId { get; set; }

        [DisplayName("まち歩き項目情報")]
        public virtual MachiarukiItem MachiarukiItem { get; set; }

        [Key]
        [DisplayName("まち歩き項目内容ID")]
        public int MachiarukiItemTypeId { get; set; }

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
        [DisplayName("まち歩き項目内容名")]
        public string TypeName { get; set; }

        [StringLength(4000)]
        [DisplayName("まち歩き項目内容概要")]
        [DataType(DataType.MultilineText)]
        public string TypeDescription { get; set; }

        [DisplayName("まち歩き項目内容順番")]
        public int TypeSort { get; set; }

    }
}