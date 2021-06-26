using Directionary.Data.Infrastructure;
using Directionary.Data.Repositories;
using Directionary.Model.Models;
using Directionary.Service;
using Directionary.Web.Infrastructure.Core;
using Directionary.Web.Infrastructure.Extensions;
using Directionary.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Directionary.Web.Api
{
    [RoutePrefix("api/test")]
    public class TestController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public TestController(IErrorService errorService, IPostCategoryService postCategoryService) :
            base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listPostCategory = _postCategoryService.GetAll();
                var listPostCategoryVm = AutoMapper.Mapper.Map<List<PostCategoryViewModel>>(listPostCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPostCategoryVm);

                return response;
            });
        }

        [Route("getsstring")]
        public string Get(string str)
        {
            return str;
        }

        [Route("gettong")]
        public int Get(int a, int b)
        {
            return a + b;
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategory = new PostCategory();
                    postCategory.UpdatePostCategory(postCategoryVm);
                    var category = _postCategoryService.Add(postCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategory = _postCategoryService.GetById(postCategoryVm.ID);
                    postCategory.UpdatePostCategory(postCategoryVm);
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }


        [Route("getmenu")]
        public HttpResponseMessage GetMenu(HttpRequestMessage request)
        {

            MenuRepository _menuRepository;
            IDbFactory dbFactory;
            MenuService _menuSercive;
            IUnitOfWork _unitOfWork;
           
                dbFactory = new DbFactory();
                _menuRepository = new MenuRepository(dbFactory);
                _unitOfWork = new UnitOfWork(dbFactory);
                _menuSercive = new MenuService(_menuRepository, _unitOfWork);

            var model = _menuSercive.GetAllByGroupId(1);
                
          


            return CreateHttpResponse(request, () =>
            {
              


                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, model);

                return response;
            });
        }






       


    }
}