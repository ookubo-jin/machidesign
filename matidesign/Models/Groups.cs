﻿using System;
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
    public class Groups
    {
        [Key]
        [DisplayName("グループID")]
        public int GroupId { get; set; }

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
        [DisplayName("グループ名")]
        public string GroupName { get; set; }


    }
}