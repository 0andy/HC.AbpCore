

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using HC.AbpCore;
using HC.AbpCore.Contracts;


namespace HC.AbpCore.Contracts.DomainService
{
    /// <summary>
    /// Contract领域层的业务管理
    ///</summary>
    public class ContractManager :AbpCoreDomainServiceBase, IContractManager
    {
		
		private readonly IRepository<Contract,Guid> _repository;

		/// <summary>
		/// Contract的构造方法
		///</summary>
		public ContractManager(
			IRepository<Contract, Guid> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitContract()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
