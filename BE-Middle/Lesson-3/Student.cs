using System;
using System.ComponentModel.DataAnnotations;

namespace NamaProyek.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama harus diisi.")]
        public string Name { get; set; }

        [Range(10, 100, ErrorMessage = "Usia harus antara 10 dan 100.")]
        public int Age { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"^[A-Za-z]{2}[0-9]{6}$", ErrorMessage = "NIM harus terdiri dari 2 huruf diikuti oleh 6 digit angka.")]
        public string NIM { get; set; }
    }
}
