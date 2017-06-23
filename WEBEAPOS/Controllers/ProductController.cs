using System;
using System.Collections.Generic;
using WEBEAPOS.Models;
using System.Web;
using System.Web.Mvc;
using WEBEAPOS.DataAccess.BusinessLayer;
using WEBEAPOS.DataAccess.DataModels;
using AutoMapper;
using System.Linq;

namespace WEBEAPOS.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ProductHelper k = new ProductHelper();
            return View(k.GetAll());
        }

        //[HttpGet]
        public ActionResult ProductManageModal(int id)
        {
            SupplierHelper supHelper = new SupplierHelper();
            BranchHelper branchHelper = new BranchHelper();
            ProductBranchHelper pbhelper = new ProductBranchHelper();
            ProductHelper helper = new ProductHelper();
            if (id == 0)
            {
                
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<TBL_PRODUCTS, ProductModel>();
                });

                List<BranchProductModel> k0 = new List<BranchProductModel>();

                foreach (var branch in branchHelper.GetAll())
                {
                    k0.Add(new BranchProductModel()
                    {
                        Branch = branch,
                        BranchId = branch.BranchId,
                        //ProductId = pmodel0.ProductId
                    });
                }


                return View(new ProductModel()
                {
                    SupplierList = supHelper.GetAll(),
                    BuyDate = DateTime.Today,
                BranchsProducts = k0
                });
            }
            var model = helper.GetById(id);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TBL_PRODUCTS, ProductModel>();
            });

            List<BranchProductModel> k = new List<BranchProductModel>();
            ProductModel pmodel = Mapper.Map(model, new ProductModel());
            pmodel.SupplierList = supHelper.GetAll();
            pmodel.Branches = branchHelper.GetAll();
            pmodel.ProductInBranches = pbhelper.GetAll();
            foreach (var branch in branchHelper.GetAll())
            {
                k.Add(new BranchProductModel()
                {
                    Branch = branch,
                    BranchId = branch.BranchId,
                    ProductId = pmodel.ProductId,
                    Quantity = pbhelper.GetById(branch.BranchId, pmodel.ProductId) == null ? 0: pbhelper.GetById(branch.BranchId, pmodel.ProductId).Quantity
                });
            }
            pmodel.BuyDate = DateTime.Today;
            pmodel.BranchsProducts = k;
            return PartialView(pmodel);
        }

        public ActionResult Manage(ProductModel model)
        {
            ProductHelper helper = new ProductHelper();
            ProductBranchHelper pbHelper = new ProductBranchHelper();
            var dbmodel = helper.GetById(model.ProductId);

            Mapper.Initialize(cfg => {
                cfg.CreateMap<ProductModel, TBL_PRODUCTS>();
            });
            TBL_PRODUCTS pmodel = Mapper.Map(model, new TBL_PRODUCTS());
            pmodel.CreatedBy = Session["UserID"].ToString();
            if (dbmodel == null)
            {
                helper.Add(pmodel);
                var last = helper.GetAll().Last();
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<BranchProductModel, TBL_BRANCH_PRODUCTS>();
                });
                foreach (var item in model.BranchsProducts)
                {
                    TBL_BRANCH_PRODUCTS pbmodel = Mapper.Map(item, new TBL_BRANCH_PRODUCTS());
                    pbmodel.ProductId = last.ProductId;
                    pbHelper.Save(pbmodel);
                }
            }
            else
            {
                helper.Update(pmodel);

                foreach (var item in model.BranchsProducts)
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<BranchProductModel, TBL_BRANCH_PRODUCTS>();
                    });
                    TBL_BRANCH_PRODUCTS pbmodel = Mapper.Map(item, new TBL_BRANCH_PRODUCTS());
                    pbHelper.Save(pbmodel);
                }
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int pId)
        {
            ProductHelper helper = new ProductHelper();
            helper.Delete(pId);
            return RedirectToAction("Index");
        }
    }
}