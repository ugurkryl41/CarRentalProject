using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba bilgileri eklendi";
        public static string CarUpdated = "Araba bilgileri güncellendi";
        public static string CarDeleted = "Araba bilgileri silindi";

        public static string CarInvalidName = "İsim geçersiz";
        public static string ImagesAdded="resim eklendi";
        public static string FailAddedImageLimit="Resim limitine erişildi!";
        public static string CarRental="Araç Kiralandı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
        public static string CarImageUpdated="Araba resmi güncellendi";
    }
}
