using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using UI_Gestion.Models;
using pclDao = PCL_Gestion.dao;
using pclStr = PCL_Gestion.str;

namespace UI_Gestion.Controllers
{
    public class strTipoReferenciaController : Controller
    {
        // GET: strTipoReferencia
        public ActionResult Index()
        {
            pclDao.daoTipoReferencias dao = new pclDao.daoTipoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            List<pclStr.strTipoReferencia> lista = dao.GetAll();

            List<strTipoReferencia> list = new List<strTipoReferencia>();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    list.Add(new strTipoReferencia()
                    {
                        Id = item.Id,
                        Nombre = item.Nombre
                    });
                }
            }

            return View(list);
        }

        // GET: strTipoReferencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strTipoReferencia str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strTipoReferencia str1 = ConvertToViewModel(str);
            return View(str1);
        }

        private strTipoReferencia ConvertToViewModel(pclStr.strTipoReferencia str)
        {
            strTipoReferencia str1 = new strTipoReferencia();
            str1.Id = str.Id;
            str1.Nombre = str.Nombre;
            return str1;
        }

        private pclStr.strTipoReferencia ConvertToStr(int? id)
        {
            pclDao.daoTipoReferencias dao = new pclDao.daoTipoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strTipoReferencia str = (id != null) ? dao.GetObject((int)id) : null;
            return str;
        }

        // GET: strTipoReferencia/Create
        public ActionResult Create()
        {
            pclDao.daoTipoReferencias dao = new pclDao.daoTipoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            strTipoReferencia str = new strTipoReferencia();
            str.Id = dao.CreateId();
            return View(str);
        }

        // POST: strTipoReferencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] strTipoReferencia strTipoReferencia)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoTipoReferencias dao = new pclDao.daoTipoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strTipoReferencia str = new pclStr.strTipoReferencia();
                str.Id = strTipoReferencia.Id;
                str.Nombre = strTipoReferencia.Nombre;
                int save = dao.Insert(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strTipoReferencia);
            }

            return View(strTipoReferencia);
        }

        // GET: strTipoReferencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strTipoReferencia str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strTipoReferencia str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strTipoReferencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] strTipoReferencia strTipoReferencia)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoTipoReferencias dao = new pclDao.daoTipoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strTipoReferencia str = new pclStr.strTipoReferencia();
                str.Id = strTipoReferencia.Id;
                str.Nombre = strTipoReferencia.Nombre;
                int save = dao.Update(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strTipoReferencia);
            }
            return View(strTipoReferencia);
        }

        // GET: strTipoReferencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strTipoReferencia str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strTipoReferencia str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strTipoReferencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pclDao.daoTipoReferencias dao = new pclDao.daoTipoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strTipoReferencia str = dao.GetObject(id);
            strTipoReferencia tipoReferencia = ConvertToViewModel(str);
            pclDao.daoReferencias dao1 = new pclDao.daoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strReferencia str1 = dao1.ExisteTipo(id);

            if (str1 == null)
            {
                int save = dao.Delete(id);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(tipoReferencia);
            }
            else
                return View(tipoReferencia);
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