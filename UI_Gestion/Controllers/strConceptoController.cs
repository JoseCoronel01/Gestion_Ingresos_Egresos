using System.Net;
using System.Web.Mvc;
using UI_Gestion.Models;
using pclStr = PCL_Gestion.str;
using pclDao = PCL_Gestion.dao;
using System.Collections.Generic;

namespace UI_Gestion.Controllers
{
    public class strConceptoController : Controller
    {
        // GET: strConcepto
        public ActionResult Index()
        {
            pclDao.daoConceptos dao = new pclDao.daoConceptos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());

            List<pclStr.strConcepto> lista = dao.GetAll();

            List<strConcepto> list = new List<strConcepto>();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    if (list == null) list = new List<strConcepto>();
                    list.Add(new strConcepto()
                    {
                        Clave = item.Clave,
                        Descripcion = item.Descripcion
                    });
                }
            }

            return View(list);
        }

        // GET: strConcepto/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strConcepto str = ConvertToPcl(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            return View(ConvertToModelView(str));
        }

        private pclStr.strConcepto ConvertToPcl(string id)
        {
            pclDao.daoConceptos dao = new pclDao.daoConceptos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strConcepto str = dao.GetObject(id);
            return str;
        }

        private strConcepto ConvertToModelView(pclStr.strConcepto str)
        {
            strConcepto str1 = new strConcepto();
            str1.Clave = str.Clave;
            str1.Descripcion = str.Descripcion;
            return str1;
        }

        // GET: strConcepto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: strConcepto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Clave,Descripcion")] strConcepto strConcepto)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoConceptos dao = new pclDao.daoConceptos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strConcepto str = new pclStr.strConcepto();
                str.Clave = strConcepto.Clave;
                str.Descripcion = strConcepto.Descripcion;
                int save = dao.Insert(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strConcepto);
            }

            return View(strConcepto);
        }

        // GET: strConcepto/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strConcepto str = ConvertToPcl(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            return View(ConvertToModelView(str));
        }

        // POST: strConcepto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Clave,Descripcion")] strConcepto strConcepto)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoConceptos dao = new pclDao.daoConceptos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strConcepto str = new pclStr.strConcepto();
                str.Clave = strConcepto.Clave;
                str.Descripcion = strConcepto.Descripcion;
                int save = dao.Update(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strConcepto);
            }
            return View(strConcepto);
        }

        // GET: strConcepto/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strConcepto str = ConvertToPcl(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            return View(ConvertToModelView(str));
        }

        // POST: strConcepto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            pclDao.daoEgresos dao_1 = new pclDao.daoEgresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strEgreso str_1 = dao_1.ExisteConcepto(id);

            pclDao.daoIngresos dao_0 = new pclDao.daoIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strIngreso str_0 = dao_0.ExisteConcepto(id);

            pclDao.daoConceptos dao = new pclDao.daoConceptos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strConcepto str = dao.GetObject(id);
            strConcepto strConcepto = ConvertToModelView(str);

            if (str_1 == null && str_0 == null)
            {
                pclDao.daoConceptos dao_ = new pclDao.daoConceptos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                int save = dao_.Delete(id);

                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strConcepto);
            }
            else
                return View(strConcepto);
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