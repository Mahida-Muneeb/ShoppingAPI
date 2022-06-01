using ShoppingAPI.Models;

namespace ShoppingAPI.Data.Repositories
{
    public class shoppingRepository: ICrudRepository<shoppingItem,int>
    {
        private readonly shoppingContext _todoContext;

        public shoppingRepository(shoppingContext todoContext)

        {

            _todoContext = todoContext ?? throw new

            ArgumentNullException(nameof(todoContext));

        }

        public void Add(shoppingItem element)

        {

            _todoContext.shoppingItems.Add(element);

        }

        public void Delete(int id)

        {

            var item = Get(id);

            if (item is not null) _todoContext.shoppingItems.Remove(Get(id));

        }

        public bool Exists(int id)

        {

            return _todoContext.shoppingItems.Any(u => u.Id == id);

        }

        public shoppingItem Get(int id)

        {

            return _todoContext.shoppingItems.FirstOrDefault(u => u.Id == id);

        }

        public IEnumerable<shoppingItem> GetAll()

        {

            return _todoContext.shoppingItems.ToList();

        }

        public bool Save()

        {

            return _todoContext.SaveChanges() > 0;

        }

        public void Update(shoppingItem element)

        {

            _todoContext.Update(element);

        }
        public IEnumerable<string> GetJoinedData()
        {
            List<shoppingItem> shoppings = _todoContext.shoppingItems.ToList();
            List<productItem> products = _todoContext.productItems.ToList();

            var result = from item in shoppings
                         join product in products
                         on item.Id equals product.productId
                         select $"{item.Id} { product.productDescription}";
            return result;
        }
    }
}
