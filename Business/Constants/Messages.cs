using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Utilities.Constant
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarNameInValid = "Araba ismi geçersiz.";
        public static string CarDailyPriceInValid = "Araba fiyatı geçersiz.";
        public static string CarListed = "Araba Listelendi.";
         

        public static string ColorAdded = "  eklendi.";
        public static string ColorDeleted = "  silindi.";
        public static string ColorUpdated = "  güncellendi.";
        public static string ColorNameInValid = "  ismi geçersiz.";
        public static string ColorListed = "  Listelendi.";
         

        public static string BrandAdded = "  eklendi.";
        public static string BrandDeleted = "  silindi.";
        public static string BrandUpdated = "  güncellendi.";
        public static string BrandNameInValid = "  ismi geçersiz.";
        public static string BrandListed = "  Listelendi.";
         

        public static string CustomerAdded = "  eklendi.";
        public static string CustomerDeleted = "  silindi.";
        public static string CustomerUpdated = "  güncellendi.";
        public static string CustomerListed = "  Listelendi.";


        public static string RentalAdded = "  eklendi.";
        public static string RentalDeleted = "  silindi.";
        public static string RentalUpdated = "  güncellendi.";
        public static string RentalListed = "  Listelendi.";
        public static string ControlReturnDate = "  Araç Dışarıda.";

        

        public static string UserAdded = "  eklendi.";
        public static string UserDeleted = "  silindi.";
        public static string UserUpdated = "  güncellendi.";
        public static string UserListed = "  Listelendi.";

        public static string CarImageLimitExceeded = " En fazla 5 adet eklenebilir.";

        public static string AuthorizationDenied = "Yetkin yok";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string UserRegistered="Kayıt oldu";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası"; 
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string AddTransactionalTest = "AddTransactional Test";
        public static string NotAdded = "NotAdded Test";
    }
}
