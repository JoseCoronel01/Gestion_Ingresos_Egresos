using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using UI_Gestion.Models;
using pclDao = PCL_Gestion.dao;
using pclStr = PCL_Gestion.str;

namespace UI_Gestion.Controllers
{
    public class strReciboController : Controller
    {
        // GET: strRecibo
        public ActionResult Index()
        {
            pclDao.daoRecibos dao = new pclDao.daoRecibos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());

            List<pclStr.strRecibo> lista = dao.GetAll();

            List<strRecibo> list = new List<strRecibo>();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    list.Add(new strRecibo()
                    {
                        Serie = item.Serie,
                        Folio = item.Folio,
                        Descripcion = item.Descripcion
                    });
                }
            }

            return View(list);
        }

        // GET: strRecibo/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strRecibo str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strRecibo str1 = ConvertToViewModel(str);
            return View(str1);
        }

        private strRecibo ConvertToViewModel(pclStr.strRecibo str)
        {
            strRecibo str1 = new strRecibo();
            str1.Serie = str.Serie;
            str1.Folio = str.Folio;
            str1.Descripcion = str.Descripcion;
            return str1;
        }

        private pclStr.strRecibo ConvertToStr(string id)
        {
            pclDao.daoRecibos dao = new pclDao.daoRecibos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strRecibo str = dao.GetObject(id);
            return str;
        }

        // GET: strRecibo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: strRecibo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Serie,Folio,Descripcion")] strRecibo strRecibo)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoRecibos dao = new pclDao.daoRecibos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strRecibo str = new pclStr.strRecibo();
                str.Serie = strRecibo.Serie;
                str.Folio = strRecibo.Folio;
                str.Descripcion = strRecibo.Descripcion;
                int save = dao.Insert(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strRecibo);
            }

            return View(strRecibo);
        }

        // GET: strRecibo/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strRecibo str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strRecibo str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strRecibo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Serie,Folio,Descripcion")] strRecibo strRecibo)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoRecibos dao = new pclDao.daoRecibos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strRecibo str = new pclStr.strRecibo();
                str.Serie = strRecibo.Serie;
                str.Folio = strRecibo.Folio;
                str.Descripcion = strRecibo.Descripcion;
                int save = dao.Update(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strRecibo);
            }
            return View(strRecibo);
        }

        // GET: strRecibo/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strRecibo str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strRecibo str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strRecibo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            pclDao.daoRecibos dao = new pclDao.daoRecibos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclDao.daoIngresos dao1 = new pclDao.daoIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strIngreso str = dao1.ExisteSerie(id);
            pclStr.strRecibo recibo = dao.GetObject(id);
            strRecibo recibo1 = ConvertToViewModel(recibo);

            if (str == null)
            {
                int save = dao.Delete(id);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(recibo1);
            }
            else
                return View(recibo1);
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