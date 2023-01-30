using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Store.Domain;
using System.Data;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductRepo _productRepo;

        public HomeController(ProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public IActionResult Index(string sortOrder, int page, string dataType)
        {
            
            if (page == 0)
                page = 1;
            ViewBag.IdSortParam = String.IsNullOrEmpty(sortOrder) ? "Id_desc" : "";
            ViewBag.ProviderNameSortParm = sortOrder == "ProviderName" ? "ProviderName_desc" : "ProviderName";
            ViewBag.DescriptionSortParm = sortOrder == "Description" ? "Description_desc" : "Description";
            ViewBag.CreationDataSortParm = sortOrder == "CreationData" ? "CreationData_desc" : "CreationData";
            ViewBag.ModificationDataSortParm = sortOrder == "ModificationData" ? "ModificationData_desc" : "ModificationData";
            ViewBag.ManagerSortParm = sortOrder == "Manager" ? "Manager_desc" : "Manager";
            ViewBag.QuantitySortParm = sortOrder == "Quantity" ? "Quantity_desc" : "Quantity";
            ViewBag.AmountSortParm = sortOrder == "Amount" ? "Amount_desc" : "Amount";
            ViewBag.CitySortParm = sortOrder == "City" ? "City_desc" : "City";

            List<Product> products;

            if (dataType == null || dataType == "MSSQL")
                products = _productRepo.GetAllProduct().ToList();
            else
                products = _productRepo.GetAllProductExcele();

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
                                for (int i = 5; i < page; i++)
                                    pageSkip += 100;
                            }
                        }
                    }
                }
            }

            var remainingProd = products.Skip(pageSkip + pageSize).ToList();
            bool nextPage = true;

            if (remainingProd.Count == 0)
                nextPage = false;

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

            PageViewModel pageViewModel = new PageViewModel(page, nextPage);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Products = items,
                DataType = dataType
            };

            return View(viewModel);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddViewModel addViewModel)
        {

            if (addViewModel.DataType == null || addViewModel.DataType == "MSSQL")
                _productRepo.SaveProduct(addViewModel.product);
            else
                _productRepo.SaveProductExcel(addViewModel.product, _productRepo.GetAllProductExcele());


            return RedirectToAction("Index");
        }

        public IActionResult Edit(string dataType, string searchString)
        {
            EditViewModel editViewModel = new EditViewModel();
            if (dataType == null || dataType == "MSSQL")
                editViewModel.products = _productRepo.GetAllProduct().ToList();
            else
                editViewModel.products = _productRepo.GetAllProductExcele();
            if (!String.IsNullOrEmpty(searchString))
            {
                editViewModel.products = editViewModel.products.Where(s => s.ProviderName.Contains(searchString)
                                       || s.ProviderName.Contains(searchString)).ToList();
            }

            editViewModel.DataType = dataType;

            return View(editViewModel);
        }

        public IActionResult EditElement()
        {
            EditViewModel editViewModel = new EditViewModel();
            string dataType = Request.Query["dataType"];

            if (dataType == null || dataType == "MSSQL" || dataType == "")
                editViewModel.product = _productRepo.GetProductById(int.Parse(Request.Query["id"]));
            else
                editViewModel.product = _productRepo.GetProductExcelById(int.Parse(Request.Query["id"]));

            editViewModel.DataType = dataType;
            return View(editViewModel);
        }

        [HttpPost]
        public IActionResult EditElement(EditViewModel editViewModel)
        {
            editViewModel.product.ModificationData = DateTime.Now;

            if (editViewModel.DataType == null || editViewModel.DataType == "MSSQL")
                _productRepo.Modified(editViewModel.product);
            else
                _productRepo.ModifiedExcel(editViewModel.product);

            return RedirectToAction("Edit");
        }

        public IActionResult Delete(string dataType, string searchString)
        {
            DeleteViewModel deleteViewModel = new DeleteViewModel();
            List<ProductViewModel> pvm = new List<ProductViewModel>();
            List<Product> products;
            if (dataType == null || dataType == "MSSQL")
                products = _productRepo.GetAllProduct().ToList();
            else
                products = _productRepo.GetAllProductExcele();

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.ProviderName.Contains(searchString)
                                       || s.ProviderName.Contains(searchString)).ToList();
            }

            foreach (var item in products)
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

            deleteViewModel.productViewModel = pvm;
            deleteViewModel.DataType = dataType;

            return View(deleteViewModel);
        }

        [HttpPost]
        public IActionResult Delete(DeleteViewModel deleteViewModel)
        {
            if (deleteViewModel.productViewModel != null)
            {
                foreach (var item in deleteViewModel.productViewModel)
                {
                    if (item.Prods.Selected)
                    {
                        if (deleteViewModel.DataType == null || deleteViewModel.DataType == "MSSQL")
                            _productRepo.Delete(_productRepo.GetProductById(item.Id));
                        else
                            _productRepo.DeleteExcel(_productRepo.GetProductExcelById(item.Id));
                    }
                }
                return RedirectToAction("Delete");
            }
            else 
            {
                return RedirectToAction("Delete", new { dataType = deleteViewModel.DataType, searchString = deleteViewModel.SearchString });
            }
        }
        public IActionResult HttpStatusCodeHendler()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error(int code)
        {
            return View(code);
        }


    }
}
