using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dappersample2018.Models
{
    [Serializable]
    public class PageInfo
    {
        public const int DefaultPagesize = 5;

        public PageInfo()
        {
            PageSize = DefaultPagesize;
            PageNo = 1;
        }

        public PageInfo(int pageNo, int pageSize)
        {
            PageNo = pageNo;
            PageSize = pageSize;
        }

        /// <summary>
        /// 資料數量
        /// </summary>
        public int ResultCount { get; set; }

        /// <summary>
        /// 單頁資料SIZE
        /// </summary>
        public int PageSize { get; set; }

        public int PageCount
        {
            get
            {
                return ResultCount % PageSize == 0
                    ? ResultCount / PageSize
                    : ResultCount / PageSize + 1;
            }
        }

        public int PageNo { get; set; }

        public int PageIndex
        {
            get { return PageNo; }
            set { PageNo = value; }
        }
    }
}