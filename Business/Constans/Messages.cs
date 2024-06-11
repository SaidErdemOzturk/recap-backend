using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarsListed = "Araçlar listelendi";
        public static string CarListedById = "Belirtilen id'ye göre araç listelendi";
        public static string CarsListedByBrand = "Markaya göre araçlar listelendi";
        public static string CarsListedByColor = "Renge göre araç listelendi";
        public static string CarsDetailListed = "Detaylı araç listelendi";


        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandListedById = "Belirtilen id'ye göre marka listelendi";


        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorListedById = "Belirtilen id'ye göre Renk listelendi";

        public static string RentalAddedSuccessful = "Araç kiralama başarılı";
        public static string RentalAddedUnsuccessful = "Araç kiralama başarısız";
        public static string? AuthorizationDenied = "Yetkisiz işlem";
        public static string UserAlreadyExists = "Bu email ile zaten bir kullanıcı mevcut.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string UserRegistered = "Kullanıcı oluşturuldu.";
        public static string PasswordError = "Şifre hatası.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
    }
}
