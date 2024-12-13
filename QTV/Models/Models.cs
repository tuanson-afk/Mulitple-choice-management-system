using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QTV.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime TaoBanGhi { get; set; } = DateTime.Now;

        [Required]
        public DateTime CapNhatBanGhi { get; set; } = DateTime.Now;
    }

    public class QTV : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaQTV { get; set; }

        [Required, StringLength(512)]
        public string MkQTV { get; set; }

        [Required, StringLength(256)]
        public string TenQTV { get; set; }
    }

    public class GiangVien : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaGV { get; set; }

        [Required, StringLength(512)]
        public string MkGV { get; set; }

        [Required, StringLength(256)]
        public string TenGV { get; set; }

        [Required, StringLength(256), EmailAddress]
        public string MailGV { get; set; }

        public virtual ICollection<LopHP> LopHPs { get; set; }
        public virtual ICollection<NHCauHoi> NHCauHois { get; set; }
        public virtual ICollection<BaiThi> BaiThis { get; set; }
    }

    public class SinhVien : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaSV { get; set; }

        [Required, StringLength(512)]
        public string MkSV { get; set; }

        [Required, StringLength(256)]
        public string TenSV { get; set; }

        [Required, StringLength(256), EmailAddress]
        public string MailSV { get; set; }

        public virtual ICollection<BaiLam> BaiLams { get; set; }
        public virtual ICollection<ChiTietBaiLam> ChiTietBaiLams { get; set; }
    }

    public class MonHoc : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaMon { get; set; }

        [Required, StringLength(256)]
        public string TenMon { get; set; }

        public virtual ICollection<LopHP> LopHPs { get; set; }
        public virtual ICollection<NHCauHoi> NHCauHois { get; set; }
        public virtual ICollection<Chuong> Chuongs { get; set; }
        public virtual ICollection<CauHoi> CauHois { get; set; }
    }

    public class LopHP : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaLHP { get; set; }

        [Required, StringLength(256)]
        public string TenLHP { get; set; }

        public string MaGV { get; set; }
        public string MaMon { get; set; }

        [ForeignKey("MaGV")]
        public virtual GiangVien GiangVien { get; set; }

        [ForeignKey("MaMon")]
        public virtual MonHoc MonHoc { get; set; }

        public virtual ICollection<BaiThi> BaiThis { get; set; }
    }

    public class DeThi : BaseEntity
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string MaDeThi { get; set; }

        // Tên đề thi
        [Required]
        [StringLength(256)]
        public string TenDeThi { get; set; }

        // Foreign Key: Mã giáo viên
        [Required]
        public string MaGiaoVien { get; set; }

        // Foreign Key: Mã môn học
        [Required]
        public string MaMon { get; set; }

        // Navigation Property: Liên kết đến bảng GiangVien
        [ForeignKey("MaGiaoVien")]
        public virtual GiangVien GiangVien { get; set; }

        public string MaChuong { get; set; }

        public string MaMucDo {  get; set; }

        public List<string> DanhSachMaCauHoiDaChon { get; set; }

        // Navigation Property: Liên kết đến bảng MonHoc
        [ForeignKey("MaMon")]
        public virtual MonHoc MonHoc { get; set; }
    }

    public class NHCauHoi : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaNHCauHoi { get; set; }

        [Required, StringLength(512)]
        public string TenNHCauHoi { get; set; }

        public string MaGV { get; set; }
        public string MaMon { get; set; }

        [ForeignKey("GiangVien_id")]
        public virtual GiangVien GiangVien { get; set; }

        [ForeignKey("MonHoc_id")]
        public virtual MonHoc MonHoc { get; set; }

        public virtual ICollection<NH_CauHoi> NH_CauHois { get; set; }
    }

    public class Chuong : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaChuong { get; set; }

        [Required, StringLength(1024)]
        public string TenChuong { get; set; }

        public int MonHoc_id { get; set; }

        [ForeignKey("MonHoc_id")]
        public virtual MonHoc MonHoc { get; set; }

        public virtual ICollection<CauHoi> CauHois { get; set; }

        public override string ToString()
        {
            return TenChuong;
        }
    }

    public class MucDo : BaseEntity
    {
        [Required, StringLength(64)]

        public string MaMucDo { get; set; }
        public string TenMucDo { get; set; }

        public virtual ICollection<CauHoi> CauHois { get; set; }

        public override string ToString()
        {
            return TenMucDo;
        }
    }

    public class CauHoi : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaCauHoi { get; set; }

        [Required]
        public string NoiDung { get; set; }

        public int MonHoc_id { get; set; }
        public int Chuong_id { get; set; }
        public int MucDo_id { get; set; }

        [ForeignKey("MonHoc_id")]
        public virtual MonHoc MonHoc { get; set; }

        [ForeignKey("Chuong_id")]
        public virtual Chuong Chuong { get; set; }

        [ForeignKey("MucDo_id")]
        public virtual MucDo MucDo { get; set; }

        public virtual ICollection<NH_CauHoi> NH_CauHois { get; set; }
        public virtual ICollection<PhuongAn> PhuongAns { get; set; }
        public virtual ICollection<ChiTietBaiLam> ChiTietBaiLams { get; set; }
    }

    public class NH_CauHoi : BaseEntity
    {
        public int NHCauHoi_id { get; set; }
        public int CauHoi_id { get; set; }

        [ForeignKey("NHCauHoi_id")]
        public virtual NHCauHoi NHCauHoi { get; set; }

        [ForeignKey("CauHoi_id")]
        public virtual CauHoi CauHoi { get; set; }
    }

    public class PhuongAn : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaPhuongAn { get; set; }
        public string MaCauHoi { get; set; }

        [Required]
        public string NoiDung { get; set; }

        public int CauHoi_id { get; set; }
        public int DungSai { get; set; }

        [ForeignKey("CauHoi_id")]
        public virtual CauHoi CauHoi { get; set; }

        public virtual ICollection<ChiTietBaiLam> ChiTietBaiLams { get; set; }
    }

    public class BaiThi : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaBaiThi { get; set; }

        [Required, StringLength(512)]
        public string TenBaiThi { get; set; }

        public string MoTa { get; set; }

        public string MaDeThi { get; set; }

        [Required]
        public DateTime TGBatDau { get; set; }

        [Required]
        public DateTime TGKetThuc { get; set; }

        [Required]
        public int ThoiLuong { get; set; }

        public string MaGV { get; set; }
        public string LopHP { get; set; }
        
        public string TenGiangVien { get; set; }
        public string TenLopHP { get; set; }

        public int HienThi { get; set; }
        public int XemLai { get; set; }
        public int XaoTron { get; set; }

        public int SoCauHoi { get; set; }

        [ForeignKey("GiangVien_id")]
        public virtual GiangVien GiangVien { get; set; }
        

        [ForeignKey("LopHP_id")]

        public virtual ICollection<BaiLam> BaiLams { get; set; }
        public virtual ICollection<ChiTietBaiLam> ChiTietBaiLams { get; set; }
    }

    public class TrangThai : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaTrangThai { get; set; }

        [Required, StringLength(256)]
        public string TenTrangThai { get; set; }

        public virtual ICollection<BaiLam> BaiLams { get; set; }
    }

    public class BaiLam : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaBaiLam { get; set; }

        public string MaSV { get; set; }
        public string MaBaiThi { get; set; }

        public DateTime BatDau { get; set; } = DateTime.Now;
        public DateTime? KetThuc { get; set; }

        public string MaTrangThai { get; set; }
        public short SoCauNop { get; set; }
        public short SoCauDung { get; set; }
        public short SoCauSai { get; set; }
        public float Diem { get; set; }

        [ForeignKey("MaSinhVien")]
        public virtual SinhVien SinhVien { get; set; }

        [ForeignKey("MaBaiThi")]
        public virtual BaiThi BaiThi { get; set; }

        [ForeignKey("MaTrangThai")]
        public virtual TrangThai TrangThai { get; set; }
    }

    public class ChiTietBaiLam : BaseEntity
    {
        [Required, StringLength(50)]
        public string MaChiTiet { get; set; }

        public int BaiThi_id { get; set; }
        public int CauHoi_id { get; set; }
        public int SinhVien_id { get; set; }
        public int PhuongAn_id { get; set; }

        public bool KetQua { get; set; }
        public DateTime TGTraLoi { get; set; } = DateTime.Now;

        [ForeignKey("BaiThi_id")]
        public virtual BaiThi BaiThi { get; set; }

        [ForeignKey("CauHoi_id")]
        public virtual CauHoi CauHoi { get; set; }

        [ForeignKey("SinhVien_id")]
        public virtual SinhVien SinhVien { get; set; }

        [ForeignKey("PhuongAn_id")]
        public virtual PhuongAn PhuongAn { get; set; }
    }

}
