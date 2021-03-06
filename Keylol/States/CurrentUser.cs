﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Keylol.Identity;
using Keylol.Models;
using Keylol.Models.DAL;
using Keylol.Provider;
using Keylol.Provider.CachedDataProvider;

namespace Keylol.States
{
    /// <summary>
    /// 当前登录的用户
    /// </summary>
    public class CurrentUser
    {
        /// <summary>
        /// 创建 <see cref="CurrentUser"/>
        /// </summary>
        /// <param name="user">用户对象</param>
        /// <param name="userManager"><see cref="KeylolUserManager"/></param>
        /// <param name="dbContext"><see cref="KeylolDbContext"/></param>
        /// <param name="coupon"><see cref="CouponProvider"/></param>
        /// <param name="cachedData"><see cref="CachedDataProvider"/></param>
        /// <returns><see cref="CurrentUser"/></returns>
        public static async Task<CurrentUser> CreateAsync(KeylolUser user, KeylolUserManager userManager,
            KeylolDbContext dbContext, CouponProvider coupon, CachedDataProvider cachedData)
        {
            // 每日访问奖励
            if (DateTime.Now.Date > user.LastDailyRewardTime.Date)
            {
                user.LastDailyRewardTime = DateTime.Now;
                user.FreeLike = 5; // 免费认可重置
                try
                {
                    await dbContext.SaveChangesAsync();
                    await coupon.UpdateAsync(user, CouponEvent.每日访问);
                }
                catch (DbUpdateConcurrencyException)
                {
                }
            }

            // Steam 游戏记录更新
            SteamCrawlerProvider.UpdateUserSteamGameRecords(user.Id);

            // Steam 好友列表更新
            SteamCrawlerProvider.UpdateUserSteamFrineds(user.Id);

            return new CurrentUser
            {
                Id = user.Id,
                UserName = user.UserName,
                IdCode = user.IdCode,
                Roles = (await userManager.GetRolesAsync(user.Id)).ToList(),
                AvatarImage = user.AvatarImage,
                MessageCount = await cachedData.Messages.GetUserUnreadMessageCountAsync(user.Id),
                Coupon = user.Coupon,
                PreferredPointName = user.PreferredPointName,
                OpenInNewWindow = user.OpenInNewWindow
            };
        }

        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 用户名（昵称）
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 识别码
        /// </summary>
        public string IdCode { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public List<string> Roles { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string AvatarImage { get; set; }

        /// <summary>
        /// 未读邮政消息数
        /// </summary>
        public int MessageCount { get; set; }

        /// <summary>
        /// 文券
        /// </summary>
        public int Coupon { get; set; }

        /// <summary>
        /// 据点主显名称偏好
        /// </summary>
        public PreferredPointName PreferredPointName { get; set; }

        /// <summary>
        /// 是否在新窗打开
        /// </summary>
        public bool OpenInNewWindow { get; set; }
    }
}