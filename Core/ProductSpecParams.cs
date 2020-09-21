using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
     public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1; // the page we are in ex: page 1 ..2 3 

        private int _pageSize = 6;
        public int PageSize // the number of items in each page !
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
                // this stops from returning more than 50 records
            }
        }

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }

        private string _keyWord;
        public string KeyWord
        {

            get
            {
                return _keyWord;
            }
            set
            {
                _keyWord = value.ToLower();
            }
        }
    }
}
