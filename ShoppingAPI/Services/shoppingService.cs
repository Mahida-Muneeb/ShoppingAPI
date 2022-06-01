using ShoppingAPI.Data.Repositories;
using ShoppingAPI.Models;

namespace ShoppingAPI.Services
{
    public class shoppingService: ICrudService<shoppingItem,int>
    {
        private readonly ICrudRepository<shoppingItem, int> _todoRepository;

        public shoppingService(ICrudRepository<shoppingItem, int> todoRepository)

        {

            _todoRepository = todoRepository;

        }

        public void Add(shoppingItem element)

        {

            _todoRepository.Add(element);

            _todoRepository.Save();

        }

        public void Delete(int id)

        {

            _todoRepository.Delete(id);

            _todoRepository.Save();

        }

        public shoppingItem Get(int id)

        {

            return _todoRepository.Get(id);

        }

        public IEnumerable<shoppingItem> GetAll()

        {

            return _todoRepository.GetAll();

        }

        public void Update(shoppingItem old, shoppingItem newT)

        {

            old.Description = newT.Description;

            old.Status = newT.Status;

            _todoRepository.Update(old);

            _todoRepository.Save();

        }
        public IEnumerable<string> GetJoinedData()
        {
            return ((shoppingRepository)_todoRepository).GetJoinedData();
        }
    }
}
