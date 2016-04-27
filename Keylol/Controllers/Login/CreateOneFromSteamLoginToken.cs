﻿using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Keylol.Models;
using Keylol.Models.DTO;
using Swashbuckle.Swagger.Annotations;

namespace Keylol.Controllers.Login
{
    public partial class LoginController
    {
        /// <summary>
        ///     使用 SteamLoginToken 登录
        /// </summary>
        /// <param name="steamLoginTokenId">SteamLoginToken ID</param>
        [AllowAnonymous]
        [Route("token/{steamLoginTokenId}")]
        [HttpPost]
        [SwaggerResponseRemoveDefaults]
        [SwaggerResponse(HttpStatusCode.Created, Type = typeof (LoginLogDto))]
        [SwaggerResponse(HttpStatusCode.Unauthorized, "指定 SteamLoginToken 无效或未经过授权")]
        public async Task<IHttpActionResult> CreateOneFromSteamLoginToken(string steamLoginTokenId)
        {
            var token = await _dbContext.SteamLoginTokens.FindAsync(steamLoginTokenId);

            if (token == null)
                return Unauthorized();
            if (token.SteamId == null)
                return Unauthorized();

            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.SteamId == token.SteamId);
            if (user == null)
                return Unauthorized();

//            await SignInManager.SignInAsync(user, true, true);

            var loginLog = new LoginLog
            {
                Ip = _owinContext.Request.RemoteIpAddress,
                User = user
            };
            _dbContext.LoginLogs.Add(loginLog);
            await _dbContext.SaveChangesAsync();
            return Created($"login/{loginLog.Id}", new LoginLogDto(loginLog));
        }
    }
}