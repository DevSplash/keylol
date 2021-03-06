﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Keylol.Models
{
    public class UserSteamGameRecord
    {
        public long Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual KeylolUser User { get; set; }

        [Required]
        [Index]
        public int SteamAppId { get; set; }

        [Index]
        public double TotalPlayedTime { get; set; } = 0;

        [Index]
        public double TwoWeekPlayedTime { get; set; } = 0;

        [Index]
        public DateTime LastPlayTime { get; set; } = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    }
}