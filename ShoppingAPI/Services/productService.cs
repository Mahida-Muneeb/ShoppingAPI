using ShoppingAPI.Data.Repositories;
using ShoppingAPI.Models;

namespace ShoppingAPI.Services
{
    public class productService : ICrudService<productItem, int>
    {
        private readonly ICrudRepository<productItem, int> _todoRepository;

        public productService(ICrudRepository<productItem, int> todoRepository)

        {

            _todoRepository = todoRepository;

        }

        public void Add(productItem element)

        {

            _todoRepository.Add(element);

            _todoRepository.Save();

        }

        public void Delete(int id)

        {

            _todoRepository.Delete(id);

            _todoRepository.Save();

        }

        public productItem Get(int id)

        {

            return _todoRepository.Get(id);

        }

        public IEnumerable<productItem> GetAll()

        {

            return _todoRepository.GetAll();

        }

        public void Update(productItem old, productItem newT)

        {

            old.productDescription = newT.productDescription;

            //old.Status = newT.Status;

            _todoRepository.Update(old);

            _todoRepository.Save();

        }
    }
}
