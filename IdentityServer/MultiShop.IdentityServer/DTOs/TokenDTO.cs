﻿using System;

namespace MultiShop.IdentityServer.DTOs
{
	public class TokenDTO
	{
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
