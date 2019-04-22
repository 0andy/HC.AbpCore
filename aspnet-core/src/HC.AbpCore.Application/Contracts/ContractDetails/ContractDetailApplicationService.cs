
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
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using HC.AbpCore.Contracts.ContractDetails;
using HC.AbpCore.Contracts.ContractDetails.Dtos;
using HC.AbpCore.Contracts.ContractDetails.DomainService;



namespace HC.AbpCore.Contracts.ContractDetails
{
    /// <summary>
    /// ContractDetail应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ContractDetailAppService : AbpCoreAppServiceBase, IContractDetailAppService
    {
        private readonly IRepository<ContractDetail, Guid> _entityRepository;

        private readonly IContractDetailManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ContractDetailAppService(
        IRepository<ContractDetail, Guid> entityRepository
        ,IContractDetailManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取ContractDetail的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		 
        public async Task<PagedResultDto<ContractDetailListDto>> GetPaged(GetContractDetailsInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<ContractDetailListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<ContractDetailListDto>>();

			return new PagedResultDto<ContractDetailListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取ContractDetailListDto信息
		/// </summary>
		 
		public async Task<ContractDetailListDto> GetById(EntityDto<Guid> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<ContractDetailListDto>();
		}

		/// <summary>
		/// 获取编辑 ContractDetail
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task<GetContractDetailForEditOutput> GetForEdit(NullableIdDto<Guid> input)
		{
			var output = new GetContractDetailForEditOutput();
ContractDetailEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<ContractDetailEditDto>();

				//contractDetailEditDto = ObjectMapper.Map<List<contractDetailEditDto>>(entity);
			}
			else
			{
				editDto = new ContractDetailEditDto();
			}

			output.ContractDetail = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改ContractDetail的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task CreateOrUpdate(CreateOrUpdateContractDetailInput input)
		{

			if (input.ContractDetail.Id.HasValue)
			{
				await Update(input.ContractDetail);
			}
			else
			{
				await Create(input.ContractDetail);
			}
		}


		/// <summary>
		/// 新增ContractDetail
		/// </summary>
		
		protected virtual async Task<ContractDetailEditDto> Create(ContractDetailEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <ContractDetail>(input);
            var entity=input.MapTo<ContractDetail>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<ContractDetailEditDto>();
		}

		/// <summary>
		/// 编辑ContractDetail
		/// </summary>
		
		protected virtual async Task Update(ContractDetailEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除ContractDetail信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		
		public async Task Delete(EntityDto<Guid> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除ContractDetail的方法
		/// </summary>
		
		public async Task BatchDelete(List<Guid> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出ContractDetail为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


