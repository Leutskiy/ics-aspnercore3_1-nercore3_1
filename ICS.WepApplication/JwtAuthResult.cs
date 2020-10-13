﻿using System;
using System.Text.Json.Serialization;

namespace ICS.WebAppCore
{
    public class JwtAuthResult
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public RefreshToken RefreshToken { get; set; }

        [JsonPropertyName("expiresAt")]
        public DateTime? ExpiresAt { get; set; }
    }
}
