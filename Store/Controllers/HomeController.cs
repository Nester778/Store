using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        // сейчас в HomeController данные берутся из Excel файла. Я построил приложение таким образом что, для того
        // что бы получить данные надо поменять местами комментарии в 62, 90, 97, 105, 128, 140, 156, 167 строках
        // я так решил потому что если бы я создал новые контроллеры и представления для них они были бы копиями если не считать выше 
        // перечисленных строк, а так делать не желательно.


        private readonly ProductRepo _productRepo;
        
        public HomeController( ProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        
        public IActionResult Index(string sortOrder, int page)
        {
            ViewBag.IdSortParam = String.IsNullOrEmpty(sortOrder) ? "Id_desc" : "";
            ViewBag.ProviderNameSortParm = sortOrder == "ProviderName" ? "ProviderName_desc" : "ProviderName";
            ViewBag.DescriptionSortParm = sortOrder == "Description" ? "Description_desc" : "Description";
            ViewBag.CreationDataSortParm = sortOrder == "CreationData" ? "CreationData_desc" : "CreationData";
            ViewBag.ModificationDataSortParm = sortOrder == "ModificationData" ? "ModificationData_desc" : "ModificationData";
            ViewBag.ManagerSortParm = sortOrder == "Manager" ? "Manager_desc" : "Manager";
            ViewBag.QuantitySortParm = sortOrder == "Quantity" ? "Quantity_desc" : "Quantity";
            ViewBag.AmountSortParm = sortOrder == "Amount" ? "Amount_desc" : "Amount";
            ViewBag.CitySortParm = sortOrder == "City" ? "City_desc" : "City";

            

            int pageSize = 5;
            int pageSkip = 0;
            if (page > 1)
            {
                pageSize = 10;
                pageSkip += 5;
                if (page > 2)
                {
                    pageSize = 25;
                    pageSkip += 10;
                    if (page > 3)
                    {
                        pageSize = 50;
                        pageSkip += 25;
                        if (page > 4)
                        {
                            pageSize = 100;
                            pageSkip += 50;
                            if (page > 5)
                            {
                                pageSize = 100;
                                for (int i = 5; i < page; i++)
                                    pageSkip += 100;
                            }
                        }
                    }
                }
            }

            var products = _productRepo.GetAllProductExcele();
            //var products = _productRepo.GetAllProduct();
            var count = products.Count();

            var items = products.Skip(pageSkip).Take(pageSize).ToList();

            switch (sortOrder)
            {
                case "Id_desc":
                    items = items.OrderByDescending(s => s.Id).ToList();
                    break;

                case "ProviderName":
                    items = items.OrderBy(s => s.ProviderName).ToList();
                    break;

                case "ProviderName_desc":
                    items = items.OrderByDescending(s => s.ProviderName).ToList();
                    break;

                case "Description":
                    items = items.OrderBy(s => s.Description).ToList();
                    break;

                case "Description_desc":
                    items = items.OrderByDescending(s => s.Description).ToList();
                    break;

                case "CreationData":
                    items = items.OrderBy(s => s.CreationData).ToList();
                    break;

                case "CreationData_desc":
                    items = items.OrderByDescending(s => s.CreationData).ToList();
                    break;

                case "ModificationData":
                    items = items.OrderBy(s => s.ModificationData).ToList();
                    break;

                case "ModificationData_desc":
                    items = items.OrderByDescending(s => s.ModificationData).ToList();
                    break;

                case "Manager":
                    items = items.OrderBy(s => s.Manager).ToList();
                    break;

                case "Manager_desc":
                    items = items.OrderByDescending(s => s.Manager).ToList();
                    break;

                case "Quantity":
                    items = items.OrderBy(s => s.Quantity).ToList();
                    break;

                case "Quantity_desc":
                    items = items.OrderByDescending(s => s.Quantity).ToList();
                    break;

                case "Amount":
                    items = items.OrderBy(s => s.Amount).ToList();
                    break;

                case "Amount_desc":
                    items = items.OrderByDescending(s => s.Amount).ToList();
                    break;

                case "City":
                    items = items.OrderBy(s => s.City).ToList();
                    break;

                case "City_desc":
                    items = items.OrderByDescending(s => s.City).ToList();
                    break;

                default:
                    items = items.OrderBy(s => s.Id).ToList();
                    break;
            }

            

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Products = items
            };

            return View(viewModel);
        }

        

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult ExcelTest()
        {
            return View();
        }
        public IActionResult Edit()
        {
            //var item2 = _productRepo.GetAllProduct();
            var item2 = _productRepo.GetAllProductExcele();
            return View(item2);
        }

        public IActionResult EditElement()
        {
            //var item2 = _productRepo.GetProductById(int.Parse(Request.Query["id"]));
            var item2 = _productRepo.GetProductExcelById(int.Parse(Request.Query["id"]));
            return View(item2);
        }

        public IActionResult Delete()
        {
            List<ProductViewModel> pvm = new List<ProductViewModel>();
            //var items2 = _productRepo.GetAllProduct();
            var items2 = _productRepo.GetAllProductExcele();
            foreach (var item in items2)
            {
                pvm.Add(new ProductViewModel
                {
                    Id = item.Id,
                    ProviderName = item.ProviderName,
                    Description = item.Description,
                    CreationData = item.CreationData,
                    ModificationData = item.ModificationData,
                    Manager = item.Manager,
                    Quantity = item.Quantity,
                    Amount = item.Amount,
                    City = item.City
                });
            }
            return View(pvm);
        }

        [HttpPost]
        public IActionResult Edit(string searchString)
        {
            //var item2 = _productRepo.GetAllProduct().ToList();
            var item2 = _productRepo.GetAllProductExcele();
            if (searchString != null)
                item2 = item2.Where(s => s.ProviderName.Contains(searchString)).ToList();

            return View(item2);
        }

        
        [HttpPost]
        public IActionResult Add(Product model)
        {
            //_productRepo.SaveProduct(model);
            _productRepo.SaveProductExcel(model, _productRepo.GetAllProductExcele());
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(List<ProductViewModel> pvm)
        {
            foreach (var item in pvm)
            {
                if (item.Prods.Selected)
                {
                    //_productRepo.Delete(_productRepo.GetProductById(item.Id));
                    _productRepo.DeleteExcel(_productRepo.GetProductExcelById(item.Id));
                }
            }

            return RedirectToAction("Delete");
        }
        [HttpPost]
        public IActionResult EditElement(Product model)
        {
            model.ModificationData = DateTime.Now;
            //_productRepo.Modified(model);
            _productRepo.ModifiedExcel(model);
            return RedirectToAction("Edit");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }

}
