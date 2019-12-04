namespace lab4.Controllers
{
    internal class PageViewModel
    {
        private int count;
        private int page;
        private int pageSize;

        public PageViewModel(int count, int page, int pageSize)
        {
            this.count = count;
            this.page = page;
            this.pageSize = pageSize;
        }
    }
}