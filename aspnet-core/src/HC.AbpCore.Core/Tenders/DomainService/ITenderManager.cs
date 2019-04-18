

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using HC.AbpCore.Tenders;


namespace HC.AbpCore.Tenders.DomainService
{
    public interface ITenderManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitTender();



		 
      
         

    }
}
