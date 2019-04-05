using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VtUygulama.ViewModel
{
    public class KayitModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Adı ve soyadı alanı boş geçilemez!")]
        [Display(Name ="Adı ve Soyadı")]
        [StringLength(50, ErrorMessage ="Adı ve Soyadı en fazla 50 karakter olmalı!")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "E-Posta adresi alanı boş geçilemez!")]
        [Display(Name = "E-Posta Adresi")]
        [StringLength(50, ErrorMessage = "E-Posta adresi an fazla 50 karakter olmalı!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Yaş alanı boş geçilemez!")]
        [Display(Name = "Yaş")]
        [Range(15, 35, ErrorMessage = "Yaş 15-35 arasında olmalıdır!")]
        public int Yas { get; set; }
    }
}