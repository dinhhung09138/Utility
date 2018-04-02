using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Pagination
{
    /// <summary>
    /// Pagination
    /// </summary>
    public static class PagingHelper
    {

        /// <summary>
        /// Row per page / default 5
        /// </summary>
        public static int ROW_PER_PAGE = 5;

        /// <summary>
        /// Pagination per page / default: 5
        /// </summary>
        public static int PAGINATION_PER_PAGE = 5;

        /// <summary>
        /// Language setting
        /// </summary>
        private static class PageResource
        {
            /// <summary>
            /// Vietnamese
            /// </summary>
            public static string VN = "Trang";

            /// <summary>
            /// English
            /// </summary>
            public static string EN = "Page";
        }
        
        /// <summary>
        /// Paging
        /// </summary>
        /// <param name="currenPage">number of current page</param>
        /// <param name="totalRow">Total data row count</param>
        /// <param name="url">url to move other page</param>
        /// <param name="lg">language</param>
        /// <returns>html string of pagination</returns>
        public static string Pagination(int currenPage, int totalRow, string url, LanguageHelper lg)
        {
            if (totalRow == 0)
                return "";
            url = url + ".htm?page=";
            string _strLabel = "<li><span class='page-label'>" +
                            (lg == LanguageHelper.vn ? PageResource.VN : PageResource.EN) +
                        ":</span></li>";
            string _strNav = "";
            if (totalRow == 0 || totalRow <= ROW_PER_PAGE)
            {
                _strNav = "<li><span class='page-label'>" +
                            (lg == LanguageHelper.vn ? PageResource.VN : PageResource.EN) +
                        ":</span></li>";
                _strNav += "<li class='active'><a href='#'>1<span class='sr-only'>(current)</span></a></li>";
                return _strNav;
            }
            int _totalPage = 1;
            _totalPage = totalRow % PAGINATION_PER_PAGE == 0 ? totalRow / PAGINATION_PER_PAGE : totalRow / PAGINATION_PER_PAGE + 1;
            int _page = 1;
            _page = _totalPage % PAGINATION_PER_PAGE == 0 ? _totalPage / PAGINATION_PER_PAGE : _totalPage / PAGINATION_PER_PAGE + 1;
            int _count = 1;
            if (_totalPage <= PAGINATION_PER_PAGE)
            {
                while (_count <= _totalPage)
                {
                    if (_count == currenPage)
                    {
                        _strNav += "<li class='active'><a href='#'>" + _count + "<span class='sr-only'>(current)</span></a></li>";
                    }
                    else
                    {
                        _strNav += "<li><a href='" + url + _count + "'>" + _count + "</a></li>";
                    }
                    _count++;
                }
            }
            else
            {
                if (currenPage <= PAGINATION_PER_PAGE)
                {
                    while (_count <= PAGINATION_PER_PAGE)
                    {
                        if (_count == currenPage)
                        {
                            _strNav += "<li class='active'><a href='#'>" + _count + "<span class='sr-only'>(current)</span></a></li>";
                        }
                        else
                        {
                            _strNav += "<li><a href='" + url + _count + "'>" + _count + "</a></li>";
                        }
                        _count++;
                    }
                    if (_totalPage > 1)
                    {
                        _strNav += "<li class='three-dot'><a href='" + url + _count + "'>...</a></li>";
                        _strNav += "<li class='page-next'><a href='" + url + _totalPage + "'>>></a></li>";
                    }
                }
                else
                {
                    if (currenPage > (_page - 1) * PAGINATION_PER_PAGE)
                    {
                        _count = _totalPage;
                        while (_count > (_page - 1) * PAGINATION_PER_PAGE)
                        {
                            if (_count == currenPage)
                            {
                                _strNav = "<li class='active'><a href='#'>" + _count + "<span class='sr-only'>(current)</span></a></li>" + _strNav;
                            }
                            else
                            {
                                _strNav = "<li><a href='" + url + _count + "'>" + _count + "</a></li>" + _strNav;
                            }
                            _count--;
                        }
                        _strNav = "<li class='three-dot'><a href='" + url + _count + "'>...</a></li>" + _strNav;
                        _strNav = "<li class='page-prev'><a href='" + url + 1 + "'><<</a></li>" + _strNav;
                    }
                    else
                    {
                        int start = 1, end = PAGINATION_PER_PAGE, i = 1;
                        while (currenPage < start || currenPage > end)
                        {
                            start = (i - 1) * PAGINATION_PER_PAGE + 1;
                            end = i * PAGINATION_PER_PAGE;
                            i++;
                        }
                        _count = start;
                        _strNav += "<li class='page-prev'><a href='" + url + "1" + "'><<</a></li>";
                        _strNav += "<li class='three-dot'><a href='" + url + "" + (_count - 1) + "'>...</a></li>";
                        while (_count <= end)
                        {
                            if (_count == currenPage)
                            {
                                _strNav += "<li class='active'><a href='#'>" + _count + "<span class='sr-only'>(current)</span></a></li>";
                            }
                            else
                            {
                                _strNav += "<li><a href='" + url + _count + "'>" + _count + "</a></li>";
                            }
                            _count++;
                        }
                        _strNav += "<li class='three-dot'><a href='" + url + "" + _count + "'>...</a></li>";
                        _strNav += "<li class='page-next'><a href='" + url + "" + _totalPage + "' >>></a></li>";
                    }
                }
            }
            return _strLabel + _strNav;
        }

        /// <summary>
        /// Paging
        /// </summary>
        /// <param name="currenPage">number of current page</param>
        /// <param name="totalRow">Total data row count</param>
        /// <param name="url">url to move other page</param>
        /// <param name="lg">language</param>
        /// <param name="maxRow">Max row in page</param>
        /// <returns>html string of pagination</returns>
        public static string Pagination(int currenPage, int totalRow, string url, LanguageHelper lg, int maxRow)
        {
            int _PAGINATION_PER_PAGE = maxRow;
            if (totalRow == 0)
                return "";
            url = url + ".htm?page=";
            string _strLabel = "<li><span class='page-label'>" +
                            (lg == LanguageHelper.vn ? PageResource.VN : PageResource.EN) +
                        ":</span></li>";
            string _strNav = "";
            if (totalRow == 0 || totalRow <= ROW_PER_PAGE)
            {
                _strNav = "<li><span class='page-label'>" +
                            (lg == LanguageHelper.vn ? PageResource.VN : PageResource.EN) +
                        ":</span></li>";
                _strNav += "<li class='active'><a href='#'>1<span class='sr-only'>(current)</span></a></li>";
                return _strNav;
            }
            int _totalPage = 1;
            _totalPage = totalRow % PAGINATION_PER_PAGE == 0 ? totalRow / PAGINATION_PER_PAGE : totalRow / PAGINATION_PER_PAGE + 1;
            int _page = 1;
            _page = _totalPage % PAGINATION_PER_PAGE == 0 ? _totalPage / PAGINATION_PER_PAGE : _totalPage / PAGINATION_PER_PAGE + 1;
            int _count = 1;
            if (_totalPage <= PAGINATION_PER_PAGE)
            {
                while (_count <= _totalPage)
                {
                    if (_count == currenPage)
                    {
                        _strNav += "<li class='active'><a href='#'>" + _count + "<span class='sr-only'>(current)</span></a></li>";
                    }
                    else
                    {
                        _strNav += "<li><a href='" + url + _count + "'>" + _count + "</a></li>";
                    }
                    _count++;
                }
            }
            else
            {
                if (currenPage <= PAGINATION_PER_PAGE)
                {
                    while (_count <= PAGINATION_PER_PAGE)
                    {
                        if (_count == currenPage)
                        {
                            _strNav += "<li class='active'><a href='#'>" + _count + "<span class='sr-only'>(current)</span></a></li>";
                        }
                        else
                        {
                            _strNav += "<li><a href='" + url + _count + "'>" + _count + "</a></li>";
                        }
                        _count++;
                    }
                    if (_totalPage > 1)
                    {
                        _strNav += "<li class='three-dot'><a href='" + url + _count + "'>...</a></li>";
                        _strNav += "<li class='page-next'><a href='" + url + _totalPage + "'>>></a></li>";
                    }
                }
                else
                {
                    if (currenPage > (_page - 1) * PAGINATION_PER_PAGE)
                    {
                        _count = _totalPage;
                        while (_count > (_page - 1) * PAGINATION_PER_PAGE)
                        {
                            if (_count == currenPage)
                            {
                                _strNav = "<li class='active'><a href='#'>" + _count + "<span class='sr-only'>(current)</span></a></li>" + _strNav;
                            }
                            else
                            {
                                _strNav = "<li><a href='" + url + _count + "'>" + _count + "</a></li>" + _strNav;
                            }
                            _count--;
                        }
                        _strNav = "<li class='three-dot'><a href='" + url + _count + "'>...</a></li>" + _strNav;
                        _strNav = "<li class='page-prev'><a href='" + url + 1 + "'><<</a></li>" + _strNav;
                    }
                    else
                    {
                        int start = 1, end = PAGINATION_PER_PAGE, i = 1;
                        while (currenPage < start || currenPage > end)
                        {
                            start = (i - 1) * PAGINATION_PER_PAGE + 1;
                            end = i * PAGINATION_PER_PAGE;
                            i++;
                        }
                        _count = start;
                        _strNav += "<li class='page-prev'><a href='" + url + "1" + "'><<</a></li>";
                        _strNav += "<li class='three-dot'><a href='" + url + "" + (_count - 1) + "'>...</a></li>";
                        while (_count <= end)
                        {
                            if (_count == currenPage)
                            {
                                _strNav += "<li class='active'><a href='#'>" + _count + "<span class='sr-only'>(current)</span></a></li>";
                            }
                            else
                            {
                                _strNav += "<li><a href='" + url + _count + "'>" + _count + "</a></li>";
                            }
                            _count++;
                        }
                        _strNav += "<li class='three-dot'><a href='" + url + "" + _count + "'>...</a></li>";
                        _strNav += "<li class='page-next'><a href='" + url + "" + _totalPage + "'>>></a></li>";
                    }
                }
            }
            return _strLabel + _strNav;
        }

    }
}
