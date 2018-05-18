using System;
using System.ComponentModel.DataAnnotations;

namespace Utils.Database
{
    /// <summary>
    /// BaseModel
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// CreateBy
        /// </summary>
        [Display(Name = "Người tạo")]
        [Required(ErrorMessage = "Người tạo không được rỗng")]
        public Guid CreateBy { get; set; }


        /// <summary>
        /// CreateDate
        /// </summary>
        [Display(Name = "Ngày tạo")]
        [Required(ErrorMessage = "Ngày tạo không được rỗng")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }


        /// <summary>
        /// UpdateBy
        /// </summary>
        [Display(Name = "Người cập nhật")]
        public Guid UpdateBy { get; set; }


        /// <summary>
        /// UpdateDate
        /// </summary>
        [Display(Name = "Ngày cập nhật")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> UpdateDate { get; set; }


        /// <summary>
        /// Deleted
        /// </summary>
        [Display(Name = "Xóa")]
        [Required(ErrorMessage = "Trạng thái xóa không được rỗng")]
        public Boolean Deleted { get; set; }


        /// <summary>
        /// DeleteBy
        /// </summary>
        [Display(Name = "Người xóa")]
        public Guid DeleteBy { get; set; }


        /// <summary>
        /// DeleteDate
        /// </summary>
        [Display(Name = "Ngày xóa")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> DeleteDate { get; set; }

        /// <summary>
        /// True: Insert, false: Update
        /// </summary>
        [Display(Name = "Thêm")]
        public bool Insert { get; set; } = false;

        /// <summary>
        /// Publish
        /// </summary>
        [Display(Name = "Publish")]
        public bool Publish { get; set; } = false;

    }
}
