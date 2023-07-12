using Common.Library;

namespace Application.Library.Service
{
    public interface IGetProductForSiteService
    {
        ResultDTO<ResultProductForSiteDto> Execute(Ordering ordering,string SearchKey, int Page,int pageSize, long? CatId );
    }
    public enum Ordering
    {

        NotOrder=0,
        /// <summary>
        /// پربازدیدترین
        /// </summary>
        MostVisited=1,
        /// <summary>
        /// پرفروشترین
        /// </summary>
        Bestselling=2,
        /// <summary>
        /// محبوبترین
        /// </summary>
        MostPopular=3,
        /// <summary>
        /// جدیدترین
        /// </summary>
        theNewest=4,
        /// <summary>
        /// ارزانترین
        /// </summary>
        Cheapest=5,
        /// <summary>
        /// گرانترین
        /// </summary>
        theMostExpensive=6
    }
}
