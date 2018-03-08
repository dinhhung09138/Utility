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
    public static class Paging
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
        public static string Pagination(int currenPage, int totalRow, string url, Language lg)
        {
            if (totalRow == 0)
                return "";
            url = url + ".htm?page=";
            string strLabel = "<li><span class='page-label'>" +
                            (lg == Language.vn ? PageResource.VN : PageResource.EN) +
                        ":</span></li>";
            string _strNav = "";
            if (totalRow == 0 || totalRow <= ROW_PER_PAGE)
            {
                _strNav = "<li><span class='page-label'>" +
                            (lg == Language.vn ? PageResource.VN : PageResource.EN) +
                        ":</span></li>";
                _strNav += "<li class='active'><a href='#'>1<span class='sr-only'>(current)</span></a></li>";
                return _strNav;
            }
            int totalPage = 1;
            totalPage = totalRow % PAGINATION_PER_PAGE == 0 ? totalRow / PAGINATION_PER_PAGE : totalRow / PAGINATION_PER_PAGE + 1;
            int page = 1;
            page = totalPage % PAGINATION_PER_PAGE == 0 ? totalPage / PAGINATION_PER_PAGE : totalPage / PAGINATION_PER_PAGE + 1;
            int count = 1;
            if (totalPage <= PAGINATION_PER_PAGE)
            {
                while (count <= totalPage)
                {
                    if (count == currenPage)
                    {
                        _strNav += "<li class='active'><a href='#'>" + count + "<span class='sr-only'>(current)</span></a></li>";
                    }
                    else
                    {
                        _strNav += "<li><a href='" + url + count + "'>" + count + "</a></li>";
                    }
                    count++;
                }
            }
            else
            {
                if (currenPage <= PAGINATION_PER_PAGE)
                {
                    while (count <= PAGINATION_PER_PAGE)
                    {
                        if (count == currenPage)
                        {
                            _strNav += "<li class='active'><a href='#'>" + count + "<span class='sr-only'>(current)</span></a></li>";
                        }
                        else
                        {
                            _strNav += "<li><a href='" + url + count + "'>" + count + "</a></li>";
                        }
                        count++;
                    }
                    if (totalPage > 1)
                    {
                        _strNav += "<li class='three-dot'><a href='" + url + count + "'>...</a></li>";
                        _strNav += "<li class='page-next'><a href='" + url + totalPage + "'>>></a></li>";
                    }
                }
                else
                {
                    if (currenPage > (page - 1) * PAGINATION_PER_PAGE)
                    {
                        count = totalPage;
                        while (count > (page - 1) * PAGINATION_PER_PAGE)
                        {
                            if (count == currenPage)
                            {
                                _strNav = "<li class='active'><a href='#'>" + count + "<span class='sr-only'>(current)</span></a></li>" + _strNav;
                            }
                            else
                            {
                                _strNav = "<li><a href='" + url + count + "'>" + count + "</a></li>" + _strNav;
                            }
                            count--;
                        }
                        _strNav = "<li class='three-dot'><a href='" + url + count + "'>...</a></li>" + _strNav;
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
                        count = start;
                        _strNav += "<li class='page-prev'><a href='" + url + "1" + "'><<</a></li>";
                        _strNav += "<li class='three-dot'><a href='" + url + "" + (count - 1) + "'>...</a></li>";
                        while (count <= end)
                        {
                            if (count == currenPage)
                            {
                                _strNav += "<li class='active'><a href='#'>" + count + "<span class='sr-only'>(current)</span></a></li>";
                            }
                            else
                            {
                                _strNav += "<li><a href='" + url + count + "'>" + count + "</a></li>";
                            }
                            count++;
                        }
                        _strNav += "<li class='three-dot'><a href='" + url + "" + count + "'>...</a></li>";
                        _strNav += "<li class='page-next'><a href='" + url + "" + totalPage + "' >>></a></li>";
                    }
                }
            }
            return strLabel + _strNav;
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
        public static string Pagination(int currenPage, int totalRow, string url, Language lg, int maxRow)
        {
            int PAGINATION_PER_PAGE = maxRow;
            if (totalRow == 0)
                return "";
            url = url + ".htm?page=";
            string strLabel = "<li><span class='page-label'>" +
                            (lg == Language.vn ? PageResource.VN : PageResource.EN) +
                        ":</span></li>";
            string _strNav = "";
            if (totalRow == 0 || totalRow <= ROW_PER_PAGE)
            {
                _strNav = "<li><span class='page-label'>" +
                            (lg == Language.vn ? PageResource.VN : PageResource.EN) +
                        ":</span></li>";
                _strNav += "<li class='active'><a href='#'>1<span class='sr-only'>(current)</span></a></li>";
                return _strNav;
            }
            int totalPage = 1;
            totalPage = totalRow % PAGINATION_PER_PAGE == 0 ? totalRow / PAGINATION_PER_PAGE : totalRow / PAGINATION_PER_PAGE + 1;
            int page = 1;
            page = totalPage % PAGINATION_PER_PAGE == 0 ? totalPage / PAGINATION_PER_PAGE : totalPage / PAGINATION_PER_PAGE + 1;
            int count = 1;
            if (totalPage <= PAGINATION_PER_PAGE)
            {
                while (count <= totalPage)
                {
                    if (count == currenPage)
                    {
                        _strNav += "<li class='active'><a href='#'>" + count + "<span class='sr-only'>(current)</span></a></li>";
                    }
                    else
                    {
                        _strNav += "<li><a href='" + url + count + "'>" + count + "</a></li>";
                    }
                    count++;
                }
            }
            else
            {
                if (currenPage <= PAGINATION_PER_PAGE)
                {
                    while (count <= PAGINATION_PER_PAGE)
                    {
                        if (count == currenPage)
                        {
                            _strNav += "<li class='active'><a href='#'>" + count + "<span class='sr-only'>(current)</span></a></li>";
                        }
                        else
                        {
                            _strNav += "<li><a href='" + url + count + "'>" + count + "</a></li>";
                        }
                        count++;
                    }
                    if (totalPage > 1)
                    {
                        _strNav += "<li class='three-dot'><a href='" + url + count + "'>...</a></li>";
                        _strNav += "<li class='page-next'><a href='" + url + totalPage + "'>>></a></li>";
                    }
                }
                else
                {
                    if (currenPage > (page - 1) * PAGINATION_PER_PAGE)
                    {
                        count = totalPage;
                        while (count > (page - 1) * PAGINATION_PER_PAGE)
                        {
                            if (count == currenPage)
                            {
                                _strNav = "<li class='active'><a href='#'>" + count + "<span class='sr-only'>(current)</span></a></li>" + _strNav;
                            }
                            else
                            {
                                _strNav = "<li><a href='" + url + count + "'>" + count + "</a></li>" + _strNav;
                            }
                            count--;
                        }
                        _strNav = "<li class='three-dot'><a href='" + url + count + "'>...</a></li>" + _strNav;
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
                        count = start;
                        _strNav += "<li class='page-prev'><a href='" + url + "1" + "'><<</a></li>";
                        _strNav += "<li class='three-dot'><a href='" + url + "" + (count - 1) + "'>...</a></li>";
                        while (count <= end)
                        {
                            if (count == currenPage)
                            {
                                _strNav += "<li class='active'><a href='#'>" + count + "<span class='sr-only'>(current)</span></a></li>";
                            }
                            else
                            {
                                _strNav += "<li><a href='" + url + count + "'>" + count + "</a></li>";
                            }
                            count++;
                        }
                        _strNav += "<li class='three-dot'><a href='" + url + "" + count + "'>...</a></li>";
                        _strNav += "<li class='page-next'><a href='" + url + "" + totalPage + "'>>></a></li>";
                    }
                }
            }
            return strLabel + _strNav;
        }

    }
}
