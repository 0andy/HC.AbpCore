
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using HC.AbpCore.Purchases;

namespace  HC.AbpCore.Purchases.Dtos
{
    public class PurchaseEditDto : FullAuditedEntityDto<Guid?>
    {       

        
		/// <summary>
		/// Code
		/// </summary>
		public string Code { get; set; }



		/// <summary>
		/// ProjectId
		/// </summary>
		public Guid? ProjectId { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public PurchaseTypeEnum Type { get; set; }


        /// <summary>
        /// EmployeeId
        /// </summary>
        public string EmployeeId { get; set; }



		/// <summary>
		/// PurchaseDate
		/// </summary>
		public DateTime? PurchaseDate { get; set; }



		/// <summary>
		/// Desc
		/// </summary>
		public string Desc { get; set; }




    }
}