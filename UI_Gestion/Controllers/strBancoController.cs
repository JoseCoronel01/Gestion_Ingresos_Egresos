using System.Net;
using System.Web.Mvc;
using UI_Gestion.Models;
using pclStr = PCL_Gestion.str;
using pclDao = PCL_Gestion.dao;
using System.Collections.Generic;

namespace UI_Gestion.Controllers
{
    public class strBancoController : Controller
    {
        // GET: strBanco
        public ActionResult Index()
        {
            pclDao.daoBancos dao = new pclDao.daoBancos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());

            List<pclStr.strBanco> lista = dao.GetAll();

            List<strBanco> banco = new List<strBanco>();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    if (banco == null) banco = new List<strBanco>();
                    banco.Add(new strBanco()
                    {
                        Clave = item.Clave,
                        Nombre = item.Nombre,
                        CtaBanco = item.CtaBanco
                    });
                }
            }

            return View(banco);
        }

        // GET: strBanco/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclDao.daoBancos dao = new pclDao.daoBancos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strBanco str = dao.GetObject(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strBanco str1 = new strBanco();
            str1.Clave = str.Clave;
            str1.Nombre = str.Nombre;
            str1.CtaBanco = str.CtaBanco;
            return View(str1);
        }

        // GET: strBanco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: strBanco/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Clave,Nombre,CtaBanco")] strBanco strBanco)
        {
            if (ModelState.IsValid)
            {
                pclStr.strBanco str_ = new pclStr.strBanco();
                pclDao.daoBancos dao = new pclDao.daoBancos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                str_.Clave = strBanco.Clave;
                str_.Nombre = strBanco.Nombre;
                str_.CtaBanco = strBanco.CtaBanco;
                int save = dao.Insert(str_);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strBanco);
            }

            return View(strBanco);
        }

        // GET: strBanco/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclDao.daoBancos dao = new pclDao.daoBancos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strBanco str = dao.GetObject(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strBanco str1 = new strBanco();
            str1.Clave = str.Clave;
            str1.Nombre = str.Nombre;
            str1.CtaBanco = str.CtaBanco;
            return View(str1);
        }

        // POST: strBanco/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Clave,Nombre,CtaBanco")] strBanco strBanco)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoBancos dao = new pclDao.daoBancos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strBanco str1 = new pclStr.strBanco();
                str1.Clave = strBanco.Clave;
                str1.Nombre = strBanco.Nombre;
                str1.CtaBanco = strBanco.CtaBanco;
                int save = dao.Update(str1);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strBanco);
            }
            return View(strBanco);
        }

        // GET: strBanco/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclDao.daoBancos dao = new pclDao.daoBancos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strBanco str = dao.GetObject(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strBanco str1 = new strBanco();
            str1.Clave = str.Clave;
            str1.Nombre = str.Nombre;
            str1.CtaBanco = str.CtaBanco;
            return View(str1);
        }

        // POST: strBanco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            pclDao.daoEgresos dao_0 = new pclDao.daoEgresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strEgreso str_ = dao_0.ExisteBanco(id);

            pclDao.daoBancos dao = new pclDao.daoBancos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strBanco str = dao.GetObject(id);

            strBanco str1 = new strBanco();
            str1.Clave = str.Clave;
            str1.Nombre = str.Nombre;
            str1.CtaBanco = str.CtaBanco;

            if (str_ == null)
            {
                pclDao.daoBancos dao_ = new pclDao.daoBancos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                int save = dao_.Delete(id);

                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(str1);
            }
            else
                return View(str1);
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