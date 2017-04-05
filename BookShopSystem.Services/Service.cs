using BookShopSystem.Data;

namespace BookShopSystem.Services
{
    public abstract class Service
    {
        private BookShopContext context;

        public Service()
        {
            this.Context = new BookShopContext();
        }

        protected BookShopContext Context
        {
            get { return this.context; }
            set { this.context = value; }
        }
    }
}
