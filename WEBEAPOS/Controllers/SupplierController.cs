using System;
using System.Collections.Generic;
using WEBEAPOS.Models;
using System.Web;
using System.Web.Mvc;
using WEBEAPOS.DataAccess.BusinessLayer;
using WEBEAPOS.DataAccess.DataModels;

namespace WEBEAPOS.Controllers
{
    public class SupplierController : Controller
    {
        SupplierHelper helper = new SupplierHelper();
        // GET: Supplier
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            SupplierHelper k = new SupplierHelper();
            return View(k.GetAll());
        }

        [HttpGet]
        public ActionResult SupplierManageModal(int id)
        {
            SupplierHelper helper = new SupplierHelper();
            if (id == 0)
                return View(new SupplierModel());
                
            var model = helper.GetById(id);
            SupplierModel smodel = new SupplierModel();
            smodel.Name = model.Name;
            smodel.PhoneNumber = model.PhoneNumber;
            smodel.ContactName = model.ContactName;
            smodel.ContactTitle = model.ContactTitle;
            smodel.ContactPhone = model.ContactPhone;
            smodel.Description = model.Description;
            smodel.Email = model.Email;
            smodel.SupplierId = model.SupplierId;
            smodel.SupplierType = model.SupplierType;
            smodel.WebPage = model.WebPage;
            smodel.City = model.City;
            smodel.Address = model.Address;

            return PartialView(smodel);
        }

        public ActionResult Manage(TBL_SUPPLIERS model)
        {
            SupplierHelper helper = new SupplierHelper();
            var dbmodel = helper.GetById(model.SupplierId);
            if (dbmodel == null)
                helper.Add(model);
            else
                helper.Update(model);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int sId)
        {
            SupplierHelper helper = new SupplierHelper();
            helper.Delete(sId);
            return RedirectToAction("Index");
        }
    }
}