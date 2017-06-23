using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBEAPOS.DataAccess.BusinessLayer;
using WEBEAPOS.DataAccess.DataModels;
using WEBEAPOS.Models;

namespace WEBEAPOS.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            BranchHelper k = new BranchHelper();
            return View(k.GetAll());
        }

        //[HttpGet]
        public ActionResult BranchManageModal(int id)
        {
            BranchHelper branchHelper = new BranchHelper();

            if (id == 0)
                return View(new BranchModel()
                {
                    
                });

            var model = branchHelper.GetById(id);

            Mapper.Initialize(cfg => {
                cfg.CreateMap<TBL_BRANCHES, BranchModel>();
            });

            BranchModel pmodel = Mapper.Map(model, new BranchModel());

            return PartialView(pmodel);
        }

        public ActionResult Manage(TBL_BRANCHES model)
        {
            BranchHelper helper = new BranchHelper();
            var dbmodel = helper.GetById(model.BranchId);
            if (dbmodel == null)
                helper.Add(model);
            else
                helper.Update(model);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            BranchHelper helper = new BranchHelper();
            helper.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}