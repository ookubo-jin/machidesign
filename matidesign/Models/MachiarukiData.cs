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
    /// まち歩き結果を格納するクラス・コントロール
    /// </summary>
    public class MachiarukiData
    {
        [Key]
        [DisplayName("まち歩き結果ID")]
        public double MachiarukiDataId { get; set; }

        //[Key]
        //[DisplayName("イベントID")]
        //public long EventsId { get; set; }

        //[Key]
        //[StringLength(100)]
        //[DisplayName("アカウントID")]
        //public string AccountId { get; set; }

        //[Key]
        //[StringLength(13)]
        //[DisplayName("作成キー")]
        //public string CreateKey { get; set; }

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

        [DisplayName("イベントID")]
        public long EventsId { get; set; }

        [DisplayName("イベント情報")]
        public virtual Events Events { get; set; }

        [StringLength(100)]
        [DisplayName("アカウントID")]
        public string AccountId { get; set; }

        [DisplayName("アカウント情報")]
        public virtual Account Account { get; set; }

        [DisplayName("緯度")]
        public double Latitude { get; set; }

        [DisplayName("経度")]
        public double Longitude { get; set; }

        [DisplayName("高度")]
        public double Altitude { get; set; }

        [DisplayName("緯度、経度の精度")]
        public double Accuracy { get; set; }

        [DisplayName("高度の精度")]
        public double AltitudeAccuracy { get; set; }

        [DisplayName("方角（度）")]
        public double Heading { get; set; }

        [DisplayName("速度（ｍ/S）")]
        public double Speed { get; set; }

    }
}