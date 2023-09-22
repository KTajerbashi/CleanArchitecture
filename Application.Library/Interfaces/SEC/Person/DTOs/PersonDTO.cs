using Common.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Interfaces.SEC.Person.DTOs
{
    public class PersonDTO : DTO
    {
        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// فامیلی
        /// </summary>
        public string Family { get; set; }
        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// رمز
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// تلفن
        /// </summary>
        public string Phone { get; set; }
    }
}
