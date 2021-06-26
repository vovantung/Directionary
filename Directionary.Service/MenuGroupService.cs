using System.Collections.Generic;
using Directionary.Data.Infrastructure;
using Directionary.Data.Repositories;
using Directionary.Model.Models;

namespace Directionary.Service
{
    public interface IMenuGroupService
    {
        MenuGroup Add(MenuGroup menuGroup);

        void Update(MenuGroup menuGroup);

        void Delete(int id);

        IEnumerable<MenuGroup> GetAll();

        IEnumerable<MenuGroup> GetAllByParentId(int parentId);
        MenuGroup GetById(int id);
        void Save();
    }

    public class MenuGroupService : IMenuGroupService
    {
        private IMenuGroupRepository _menuGroupRepository;
        private IUnitOfWork _uintOfWork;

        public MenuGroupService(IMenuGroupRepository menuGroupRepository, IUnitOfWork uintOfWork)
        {
            _menuGroupRepository = menuGroupRepository;
            _uintOfWork = uintOfWork;
        }

        public MenuGroup Add(MenuGroup menuGroup)
        {
            return _menuGroupRepository.Add(menuGroup);
        }

        public void Delete(int id)
        {
            _menuGroupRepository.Delete(id);
        }

        public IEnumerable<MenuGroup> GetAll()
        {
            return _menuGroupRepository.GetAll();
        }

        public IEnumerable<MenuGroup> GetAllByParentId(int parentId)
        {
            return _menuGroupRepository.GetMulti( x=>x.ID == parentId);
        }

    


        public MenuGroup GetById(int id)
        {
            return _menuGroupRepository.GetSingleById(id);
        }

        public void Update(MenuGroup menuGroup)
        {
            _menuGroupRepository.Update(menuGroup);
        }
        public void Save()
        {
            _uintOfWork.Commit();
        }
    }
}
