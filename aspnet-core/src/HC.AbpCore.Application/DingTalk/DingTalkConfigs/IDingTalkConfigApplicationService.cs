
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using HC.AbpCore.DingTalk.DingTalkConfigs.Dtos;
using HC.AbpCore.DingTalk.DingTalkConfigs;

namespace HC.AbpCore.DingTalk.DingTalkConfigs
{
    /// <summary>
    /// DingTalkConfig应用层服务的接口方法
    ///</summary>
    public interface IDingTalkConfigAppService : IApplicationService
    {
        /// <summary>
		/// 获取DingTalkConfig的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<DingTalkConfigListDto>> GetPaged(GetDingTalkConfigsInput input);


		/// <summary>
		/// 通过指定id获取DingTalkConfigListDto信息
		/// </summary>
		Task<DingTalkConfigListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetDingTalkConfigForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改DingTalkConfig的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateDingTalkConfigInput input);


        /// <summary>
        /// 删除DingTalkConfig信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除DingTalkConfig
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出DingTalkConfig为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
