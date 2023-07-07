﻿using Application.Library;
using Common.Library;

namespace Application.Library.Service
{
    public class GetUsersDto : IDTO
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
