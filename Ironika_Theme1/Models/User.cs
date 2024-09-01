using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ironika_Theme1.Models
{
   

        public class UserCopen
        {
            [Required(ErrorMessage = "The Copen is Required")]
            public string Copen { get; set; }


        }
        public class FirstRegister
        {

            [Required(ErrorMessage = "وارد کردن موبایل اجباری است")]
            public string Mobile { get; set; }
            [Required(ErrorMessage = "وارد کردن کد تایید اجباری است")]
            public string Code { get; set; }

        }
        public class ReWards
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
            [Required(ErrorMessage = "وارد کردن عنوان اجباری است")]
            public string Title { get; set; }
            [Required(ErrorMessage = "وارد کردن مبلغ تعهد اجباری است")]
            public int PriceRewards { get; set; }
            [Required(ErrorMessage = "وارد کردن توضیحات اجباری است")]
            public string Description { get; set; }

        }
        public class UserClient
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
            [Required(ErrorMessage = "The Name is Required")]
            public string Name { get; set; }
            [Required(ErrorMessage = "The Lastname is Required")]
            public string LastName { get; set; }
            [Required(ErrorMessage = "The Tele is Required")]
            public string Mobile { get; set; }
            [Required(ErrorMessage = "The Password is Required")]
            [DataType(DataType.Password)]
            public string OldPassword { get; set; }
            [DataType(DataType.Password)]
            public string NewPassword { get; set; }
            [DataType(DataType.Password)]
            [Compare("NewPassword", ErrorMessage = "Not Equal Password in Duplicate")]
            public string ConfirmPassword { get; set; }
            [Required(ErrorMessage = "The Email Address is Required")]
            [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Not Valid Email Address")]
            [StringLength(200, ErrorMessage = "آدرس ایمیل وارد شده صحیح نیست.")]
            public string Email { get; set; }
            public DateTime DateRegister { get; set; }
            public string AboutMe { get; set; }
            public string Education { get; set; }
            public string Events { get; set; }
            public string Exhibitions { get; set; }
            public string Country { get; set; }
            [Required(ErrorMessage = "The City is Required")]
            public string City { get; set; }
            public string Region { get; set; }
            public string PostalCode { get; set; }
            public string Facebook { get; set; }
            public string Twitter { get; set; }
            public string Pinterest { get; set; }
            public string Tumblr { get; set; }
            public string Instagram { get; set; }
            public string GooglePlus { get; set; }
            public string MyWebsites { get; set; }

            public string ImageUrl { get; set; }
        }
        public class RegisterClient
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int UserId { get; set; }
            [Required(ErrorMessage = "وارد کردن نام اجباری است")]
            public string Name { get; set; }
            [Required(ErrorMessage = "وارد کردن نام خانوادگی اجباری است")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "وارد کردن نام کاربری اجباری است")]
            public string UserName { get; set; }

            public string Mobile { get; set; }

            public string Birthday { get; set; }
            [Required(ErrorMessage = "وارد کردن کد ملی اجباری است")]
            public string MelliCode { get; set; }
            [Required(ErrorMessage = "وارد کردن کلمه عبور اجباری است")]

            public string Password { get; set; }
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "کلمه عبور با تکرار آن مطابقت ندارد")]
            public string ConfirmPassword { get; set; }
            public string BirthPlace { get; set; }

            public string Meliyat { get; set; }
            public string Address { get; set; }
            public string MostarName { get; set; }
            public DateTime DateRegister { get; set; }
            public string Education { get; set; }
            public string PostalCode { get; set; }
            public string Job { get; set; }
            public string ImageProfile { get; set; }

            [Required(ErrorMessage = "وارد کردن شماره تلفن اجباری است")]
            public string Tele { get; set; }
            [Required(ErrorMessage = "وارد کردن آدرس ایمیل اجباری است")]
            [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "آدرس ایمیل به درستی وارد نشده است")]
            [StringLength(200, ErrorMessage = "وارد کردن آدرس ایمیل اجباری است")]
            public string Email { get; set; }
        }
        public class Login
        {
            [Required(ErrorMessage = "وارد کردن نام کاربری اجباری است")]
            [Display(Name = "Email")]
            public string Email { get; set; }
            [Required(ErrorMessage = "وارد کردن کلمه عبور اجباری است")]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

        }
        public class Contact
        {

            [Required(ErrorMessage = "لطفا آدرس ایمیل خود را وارد کنید.")]
            [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "لطفا یک ایمیل معتبر وارد کنید.")]
            [StringLength(200, ErrorMessage = "آدرس ایمیل وارد شده صحیح نیست.")]
            public string Email { get; set; }



        }
        public class People
        {

            [Required(ErrorMessage = "وارد کردن آدرس ایمیل اجباری است")]
            [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "آدرس ایمیل صحیح نیست")]
            [StringLength(200, ErrorMessage = "آدرس ایمیل صحیح نیست")]
            public string Email { get; set; }
            [Required(ErrorMessage = "وارد کردن نام اجباری است")]
            public string Name { get; set; }
            [Required(ErrorMessage = "The Subject is Required")]
            public string Subject { get; set; }
            public string Tele { get; set; }
            public string Message { get; set; }

        }
    public class Review
    {

        //[Required(ErrorMessage = "تعداد ستاره اجباری است")]
        public int RatingId { get; set; }
        
       
        public string Message { get; set; }

    }
    public class Search
        {
            public string Name { get; set; }

        }
        public class Address
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int AddressId { get; set; }
            [Required(ErrorMessage = "وارد کردن عنوان آدرس اجباری است")]
            public string Title { get; set; }
            [Required(ErrorMessage = "وارد کردن نام گیرنده اجباری است")]
           

            
            public string PersonName { get; set; }

            [Required(ErrorMessage = "وارد کردن تلفن اجباری است")]
            public string Tele { get; set; }
            [Required(ErrorMessage = "وارد کردن کد پستی اجباری است")]
            public string PostalCode { get; set; }
            [Required(ErrorMessage = "وارد کردن آدرس اجباری است")]
            public string AddressName { get; set; }

           

        }
        public class AddressFa
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int AddressId { get; set; }
            [Required(ErrorMessage = "عنوان آدرس اجباری است")]
            public string Name { get; set; }
            [Required(ErrorMessage = "انتخاب شهر اجباری است")]
            public int CityId { get; set; }
            [Required(ErrorMessage = "انتخاب استان اجباری است")]
            public int ProvinceId { get; set; }

            [Required(ErrorMessage = "نام تحویل گیرنده اجباری است")]
            public string PersonName { get; set; }

            [Required(ErrorMessage = "تلفن اجباری است")]
            public string Tele { get; set; }
            [Required(ErrorMessage = "آدرس اجباری است")]
            public string AddressName { get; set; }

            [Required(ErrorMessage = "کد پستی اجباری است")]
            public string PostalCode { get; set; }

        }
        public class Project
        {
            public string ID { get; set; }
            public string Name { get; set; }
            public string ManagerName { get; set; }
            public string Email { get; set; }
            public string Price { get; set; }
        }
        public class Product
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public string ImageUrl { get; set; }
            public int PriceNew { get; set; }
            public int PriceOld { get; set; }
            public int Rating { get; set; }
        }
    public class GroupShop
    {


        public int GroupId { get; set; }
        public string Name { get; set; }
        public int ?Parent { get; set; }
    }

    }