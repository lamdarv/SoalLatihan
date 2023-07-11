using System;
using System.ComponentModel.DataAnnotations;

namespace NamaProyek.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nama harus diisi.")]
        public string Name { get; set; }

        [Range(18, 65, ErrorMessage = "Usia harus antara 18 dan 65.")]
        public int Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}