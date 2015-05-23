using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.WebUI.Models;

namespace SportStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int _pageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * _pageSize).Take(_pageSize),
                PagingInfo = new PagingInfo { 
                    CurrentPage = page,
                    TotalItems = repository.Products.Count(),
                    ItemsPerPage = _pageSize
                }
            };
            return View(model);
        }
    }
}
