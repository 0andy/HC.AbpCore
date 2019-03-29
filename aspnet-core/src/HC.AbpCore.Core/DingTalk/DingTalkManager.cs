﻿using Abp.Domain.Repositories;
using HC.AbpCore.DingTalk.DingTalkConfigs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Senparc.CO2NET.HttpUtility;

namespace HC.AbpCore.DingTalk
{
    public class DingTalkManager : AbpCoreDomainServiceBase, IDingTalkManager
    {
        private readonly IRepository<DingTalkConfig> _dingTalkConfigRepository;

        public DingTalkManager(IRepository<DingTalkConfig> dingTalkConfigRepository)
        {
            _dingTalkConfigRepository = dingTalkConfigRepository;
        }

        public async Task<string> GetAccessTokenByAppAsync(DingDingAppEnum app)
        {
            var config = await GetDingDingConfigByAppAsync(app);
            DingAccessToken accessToken = Get.GetJson<DingAccessToken>(string.Format("https://oapi.dingtalk.com/gettoken?appkey={0}&appsecret={1}", config.Appkey, config.Appsecret));
            Logger.InfoFormat("AccessToken response errmsg:{0} body:{1}", accessToken.errmsg, accessToken.access_token);
            return accessToken.access_token;
        }

        public async Task<DingDingAppConfig> GetDingDingConfigByAppAsync(DingDingAppEnum app)
        {
            DingDingAppConfig config = new DingDingAppConfig();
            var configList = new List<DingTalkConfig>();
            switch (app)
            {
                case DingDingAppEnum.智能办公:
                    {
                        configList = await _dingTalkConfigRepository.GetAll()
                            .Where(d => d.Type == DingDingTypeEnum.公共配置 || d.Type == DingDingTypeEnum.智能办公)
                            .AsNoTracking()
                            .ToListAsync();
                    }
                    break;
                default:
                    break;
            }

            foreach (var item in configList)
            {
                if (item.Code == DingDingConfigCode.CorpId)
                {
                    config.CorpId = item.Value;
                }
                else if (item.Code == DingDingConfigCode.Appkey)
                {
                    config.Appkey = item.Value;
                }
                else if (item.Code == DingDingConfigCode.Appsecret)
                {
                    config.Appsecret = item.Value;
                }
                else if (item.Code == DingDingConfigCode.AgentID)
                {
                    int outAgenId = 0;
                    if (int.TryParse(item.Value, out outAgenId))
                    {
                        config.AgentID = outAgenId;
                    }
                }
            }

            return config;
        }
    }
}