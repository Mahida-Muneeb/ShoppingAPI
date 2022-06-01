using ShoppingAPI.Models;

namespace ShoppingAPI.Data.Repositories
{
    public class productRepository : ICrudRepository<productItem, int>
    {
        private readonly shoppingContext _todoContext;

        public productRepository(shoppingContext todoContext)

        {

            _todoContext = todoContext ?? throw new

            ArgumentNullException(nameof(todoContext));

        }

        public void Add(productItem element)

        {

            _todoContext.productItems.Add(element);

        }

        public void Delete(int id)

        {

            var item = Get(id);

            if (item is not null) _todoContext.productItems.Remove(Get(id));

        }

        public bool Exists(int id)

        {

            return _todoContext.productItems.Any(u => u.productId == id);

        }

        public productItem Get(int id)

        {

            return _todoContext.productItems.FirstOrDefault(u => u.productId == id);

        }

        public IEnumerable<productItem> GetAll()

        {

            return _todoContext.productItems.ToList();

        }

        public bool Save()

        {

            return _todoContext.SaveChanges() > 0;

        }

        public void Update(productItem element)

        {

            _todoContext.Update(element);

        }
    }
}
