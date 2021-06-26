using System.Collections.Generic;
using Directionary.Data.Infrastructure;
using Directionary.Data.Repositories;
using Directionary.Model.Models;

namespace Directionary.Service
{
    public interface IMenuService
    {
        Menu Add(Menu menu);

        void Update(Menu menu);

        void Delete(int id);

        IEnumerable<Menu> GetAll();

        IEnumerable<Menu> GetAllByParentId(int parentId);
        IEnumerable<Menu> GetAllByGroupId(int groupId);

        Menu GetById(int id);
        void Save();
    }

    public class MenuService : IMenuService
    {
        private IMenuRepository _menuRepository;
        private IUnitOfWork _uintOfWork;

        public MenuService(IMenuRepository menuRepository, IUnitOfWork uintOfWork)
        {
            _menuRepository = menuRepository;
            _uintOfWork = uintOfWork;
        }

        public Menu Add(Menu menu)
        {
            return _menuRepository.Add(menu);
        }

        public void Delete(int id)
        {
            _menuRepository.Delete(id);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _menuRepository.GetAll();
        }

        public IEnumerable<Menu> GetAllByParentId(int parentId)
        {
            return _menuRepository.GetMulti(x => x.Status && x.ID == parentId);
        }

        public IEnumerable<Menu> GetAllByGroupId(int groupId)
        {
            return _menuRepository.GetMulti(x => x.Status && x.GroupID == groupId);
        }


        public Menu GetById(int id)
        {
            return _menuRepository.GetSingleById(id);
        }

        public void Update(Menu menu)
        {
            _menuRepository.Update(menu);
        }
        public void Save()
        {
            _uintOfWork.Commit();
        }
    }
}
