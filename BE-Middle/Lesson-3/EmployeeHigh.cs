using System;
using System.ComponentModel.DataAnnotations;

namespace NamaProyek.Models
{
    public class EmployeeHigh
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama karyawan harus diisi.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Panjang nama karyawan harus antara 2 dan 100 karakter.")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Email harus memiliki format yang valid.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Nomor telepon harus memiliki format yang valid.")]
        public string PhoneNumber { get; set; }

        [Range(18, 65, ErrorMessage = "Usia karyawan harus antara 18 dan 65 tahun.")]
        public int Age { get; set; }

        [RegularExpression(@"^[A-Za-z0-9]{6,}$", ErrorMessage = "Password harus terdiri dari minimal 6 karakter alfanumerik.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Konfirmasi password tidak cocok.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Lahir")]
        public DateTime BirthDate { get; set; }

        [EnumDataType(typeof(Department), ErrorMessage = "Departemen yang dipilih tidak valid.")]
        public Department Department { get; set; }

        [CreditCard(ErrorMessage = "Nomor kartu kredit harus memiliki format yang valid.")]
        public string CreditCardNumber { get; set; }

        [Url(ErrorMessage = "URL harus memiliki format yang valid.")]
        public string PersonalWebsite { get; set; }

        [RegularExpression(@"^[0-9]{2}-[0-9]{3}$", ErrorMessage = "Format kode pos tidak valid.")]
        public string PostalCode { get; set; }
    }

    public enum Department
    {
        IT,
        Finance,
        HR,
        Marketing
    }
}
