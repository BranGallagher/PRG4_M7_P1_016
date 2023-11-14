using System.ComponentModel.DataAnnotations;

namespace PRG4_M7_P1_016.Models
{
    public class Anggota
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi.")]
        [MaxLength(100, ErrorMessage = "Nama maksimal 100 karakter.")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Nama hanya boleh berisi huruf.")]
        public string nama { get; set; }

        [Required(ErrorMessage = "Umur wajib diisi.")]
        public int umur { get; set; }

        [MaxLength(100, ErrorMessage = "Alamat maksimal 100 karakter.")]
        [Required(ErrorMessage = "Alamat wajib diisi.")]
        public string alamat { get; set; }

        [Required(ErrorMessage = "Nomor Telepon wajib diisi")]
        [RegularExpression(@"^\d{10,13}$", ErrorMessage = "Nomor telepon harus terdiri dari 10 hingga 13 digit angka.")]
        public string noHP { get; set; }

        public string nyobagit { get; set; }
    }
}
