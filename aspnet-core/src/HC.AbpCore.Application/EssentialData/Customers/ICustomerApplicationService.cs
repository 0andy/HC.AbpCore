
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


using HC.AbpCore.EssentialData.Customers.Dtos;
using HC.AbpCore.EssentialData.Customers;

namespace HC.AbpCore.EssentialData.Customers
{
    /// <summary>
    /// Customer应用层服务的接口方法
    ///</summary>
    public interface ICustomerAppService : IApplicationService
    {
        /// <summary>
		/// 获取Customer的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CustomerListDto>> GetPaged(GetCustomersInput input);


		/// <summary>
		/// 通过指定id获取CustomerListDto信息
		/// </summary>
		Task<CustomerListDto> GetById(EntityDto<int> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetCustomerForEditOutput> GetForEdit(NullableIdDto<int> input);


        /// <summary>
        /// 添加或者修改Customer的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateCustomerInput input);


        /// <summary>
        /// 删除Customer信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<int> input);


        /// <summary>
        /// 批量删除Customer
        /// </summary>
        Task BatchDelete(List<int> input);


		/// <summary>
        /// 导出Customer为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}