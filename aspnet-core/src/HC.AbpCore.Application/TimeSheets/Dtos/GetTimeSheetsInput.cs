
using Abp.Runtime.Validation;
using HC.AbpCore.Dtos;
using HC.AbpCore.TimeSheets;
using System;

namespace HC.AbpCore.TimeSheets.Dtos
{
    public class GetTimeSheetsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

        /// <summary>
        /// 查询条件-所属项目
        /// </summary>
        public Guid? ProjectId
        {
            get;set;
        }

        /// <summary>
        /// 查询条件-所属员工
        /// </summary>
        public string EmployeeId
        {
            get; set;
        }

        /// <summary>
        /// 查询条件-状态
        /// </summary>
        public TimeSheetStatusEnum? Status { get; set; }

    }
}