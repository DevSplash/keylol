﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Keylol.Identity;
using Keylol.Models.DAL;
using Keylol.Provider.CachedDataProvider;
using Keylol.StateTreeManager;

namespace Keylol.States.Coupon.Store
{
    /// <summary>
    /// 文券商店页面
    /// </summary>
    public class StorePage
    {
        /// <summary>
        /// 获取文券商店页面
        /// </summary>
        /// <param name="dbContext"><see cref="KeylolDbContext"/></param>
        /// <param name="cachedData"><see cref="CachedDataProvider"/></param>
        /// <param name="userManager"></param>
        /// <returns><see cref="StorePage"/></returns>
        public static async Task<StorePage> Get([Injected] KeylolDbContext dbContext,
            [Injected] CachedDataProvider cachedData, [Injected] KeylolUserManager userManager)
        {
            return await CreateAsync(StateTreeHelper.GetCurrentUserId(), dbContext, cachedData, userManager);
        }

        /// <summary>
        /// 创建 <see cref="StorePage"/>
        /// </summary>
        /// <param name="currentUserId">当前登录用户 ID</param>
        /// <param name="dbContext"><see cref="KeylolDbContext"/></param>
        /// <param name="cachedData"><see cref="CachedDataProvider"/></param>
        /// <param name="userManager"><see cref="KeylolUserManager"/></param>
        /// <returns><see cref="StorePage"/></returns>
        public static async Task<StorePage> CreateAsync(string currentUserId, [Injected] KeylolDbContext dbContext,
            [Injected] CachedDataProvider cachedData, [Injected] KeylolUserManager userManager)
        {
            return new StorePage
            {
                Gifts = await CouponGiftList.CreateAsync(currentUserId, dbContext, cachedData, userManager)
            };
        }

        /// <summary>
        /// 商品列表
        /// </summary>
        public CouponGiftList Gifts { get; set; }
    }
}