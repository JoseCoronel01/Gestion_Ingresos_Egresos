using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using UI_Gestion.Models;
using pclDao = PCL_Gestion.dao;
using pclStr = PCL_Gestion.str;

namespace UI_Gestion.Controllers
{
    public class strImpuestoController : Controller
    {
        // GET: strImpuesto
        public ActionResult Index()
        {
            pclDao.daoImpuestos dao = new pclDao.daoImpuestos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());

            List<pclStr.strImpuesto> lista = dao.GetAll();

            List<strImpuesto> list = new List<strImpuesto>();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    list.Add(new strImpuesto()
                    {
                        Clave = item.Clave,
                        Tasa = item.Tasa
                    });
                }
            }

            return View(list);
        }

        // GET: strImpuesto/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strImpuesto str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }

            return View(ConvertToModelView(str));
        }

        private strImpuesto ConvertToModelView(pclStr.strImpuesto str)
        {
            strImpuesto str1 = new strImpuesto();
            str1.Clave = str.Clave;
            str1.Tasa = str.Tasa;
            return str1;
        }

        private pclStr.strImpuesto ConvertToStr(string id)
        {
            pclDao.daoImpuestos dao = new pclDao.daoImpuestos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strImpuesto str = dao.GetObject(id);
            return str;
        }

        // GET: strImpuesto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: strImpuesto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Clave,Tasa")] strImpuesto strImpuesto)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoImpuestos dao = new pclDao.daoImpuestos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strImpuesto str = new pclStr.strImpuesto();
                str.Clave = strImpuesto.Clave;
                str.Tasa = strImpuesto.Tasa;
                int save = dao.Insert(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strImpuesto);
            }

            return View(strImpuesto);
        }

        // GET: strImpuesto/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strImpuesto str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            return View(ConvertToModelView(str));
        }

        // POST: strImpuesto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Clave,Tasa")] strImpuesto strImpuesto)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoImpuestos dao = new pclDao.daoImpuestos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strImpuesto str = new pclStr.strImpuesto();
                str.Clave = strImpuesto.Clave;
                str.Tasa = strImpuesto.Tasa;
                int save = dao.Update(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strImpuesto);
            }
            return View(strImpuesto);
        }

        // GET: strImpuesto/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strImpuesto str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            return View(ConvertToModelView(str));
        }

        // POST: strImpuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            pclDao.daoEgresos dao = new pclDao.daoEgresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclDao.daoIngresos dao1 = new pclDao.daoIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strEgreso str = dao.ExisteTasa(id);
            pclStr.strIngreso str1 = dao1.ExisteTasa(id);
            pclDao.daoImpuestos dao2 = new pclDao.daoImpuestos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());

            if (str == null && str1 == null)
            {
                int save = dao2.Delete(id);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(ConvertToModelView(dao2.GetObject(id)));
            }

            return View(ConvertToModelView(dao2.GetObject(id)));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}