
using Abp.Runtime.Validation;
using HC.AbpCore.Dtos;
using HC.AbpCore.Companys.Accounts;

namespace HC.AbpCore.Companys.Accounts.Dtos
{
    public class GetAccountsInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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

    }
}
