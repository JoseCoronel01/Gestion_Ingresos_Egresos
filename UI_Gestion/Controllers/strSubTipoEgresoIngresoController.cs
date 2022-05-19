using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using UI_Gestion.Models;
using pclDao = PCL_Gestion.dao;
using pclStr = PCL_Gestion.str;
using pclUtil = PCL_Gestion.util;

namespace UI_Gestion.Controllers
{
    public class strSubTipoEgresoIngresoController : Controller
    {
        // GET: strSubTipoEgresoIngreso
        public ActionResult Index()
        {
            pclDao.daoSubTipoEgresosIngresos dao = new pclDao.daoSubTipoEgresosIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            List<pclStr.strSubTipoEgresoIngreso> lista = dao.GetAll();

            List<strSubTipoEgresoIngreso> list = new List<strSubTipoEgresoIngreso>();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    list.Add(new strSubTipoEgresoIngreso()
                    {
                        Clave = item.Clave,
                        Clave_Tipo = item.Clave_Tipo,
                        Nombre = item.Nombre
                    });
                }
            }

            return View(list);
        }

        // GET: strSubTipoEgresoIngreso/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strSubTipoEgresoIngreso str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strSubTipoEgresoIngreso str1 = ConvertToViewModel(str);
            return View(str1);
        }

        private strSubTipoEgresoIngreso ConvertToViewModel(pclStr.strSubTipoEgresoIngreso str)
        {
            strSubTipoEgresoIngreso str1 = new strSubTipoEgresoIngreso();
            str1.Clave = str.Clave;
            str1.Clave_Tipo = str.Clave_Tipo;
            str1.Nombre = str.Nombre;
            return str1;
        }

        private pclStr.strSubTipoEgresoIngreso ConvertToStr(string id)
        {
            pclDao.daoSubTipoEgresosIngresos dao = new pclDao.daoSubTipoEgresosIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strSubTipoEgresoIngreso str = dao.GetObject(id);
            return str;
        }

        // GET: strSubTipoEgresoIngreso/Create
        public ActionResult Create()
        {
            CargarComboClave_Tipo();
            return View();
        }

        private void CargarComboClave_Tipo(string id = null)
        {
            pclDao.daoTipoEgresosIngresos dao = new pclDao.daoTipoEgresosIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            List<pclStr.strTipoEgresoIngreso> lista = dao.GetAll();
            List<pclUtil.ElementoComboBox> elementos = new List<pclUtil.ElementoComboBox>();
            if (lista != null)
                foreach (var item in lista)
                    elementos.Add(new pclUtil.ElementoComboBox() { value = item.Clave, text = item.ToString() });
            ViewBag.Clave_Tipo = new SelectList(elementos, "value", "text", id);
        }

        // POST: strSubTipoEgresoIngreso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Clave,Nombre,Clave_Tipo")] strSubTipoEgresoIngreso strSubTipoEgresoIngreso)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoSubTipoEgresosIngresos dao = new pclDao.daoSubTipoEgresosIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strSubTipoEgresoIngreso str = new pclStr.strSubTipoEgresoIngreso();
                str.Clave = strSubTipoEgresoIngreso.Clave;
                str.Clave_Tipo = strSubTipoEgresoIngreso.Clave_Tipo;
                str.Nombre = strSubTipoEgresoIngreso.Nombre;
                int save = dao.Insert(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strSubTipoEgresoIngreso);
            }

            return View(strSubTipoEgresoIngreso);
        }

        // GET: strSubTipoEgresoIngreso/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strSubTipoEgresoIngreso str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strSubTipoEgresoIngreso str1 = ConvertToViewModel(str);
            CargarComboClave_Tipo(str1.Clave_Tipo);
            return View(str1);
        }

        // POST: strSubTipoEgresoIngreso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Clave,Nombre,Clave_Tipo")] strSubTipoEgresoIngreso strSubTipoEgresoIngreso)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoSubTipoEgresosIngresos dao = new pclDao.daoSubTipoEgresosIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strSubTipoEgresoIngreso str = new pclStr.strSubTipoEgresoIngreso();
                str.Clave = strSubTipoEgresoIngreso.Clave;
                str.Clave_Tipo = strSubTipoEgresoIngreso.Clave_Tipo;
                str.Nombre = strSubTipoEgresoIngreso.Nombre;
                int save = dao.Update(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strSubTipoEgresoIngreso);
            }
            return View(strSubTipoEgresoIngreso);
        }

        // GET: strSubTipoEgresoIngreso/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strSubTipoEgresoIngreso str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strSubTipoEgresoIngreso str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strSubTipoEgresoIngreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            pclDao.daoSubTipoEgresosIngresos dao = new pclDao.daoSubTipoEgresosIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strSubTipoEgresoIngreso str2 = dao.GetObject(id);
            strSubTipoEgresoIngreso subTipoEgresoIngreso = ConvertToViewModel(str2);
            pclDao.daoIngresos dao1 = new pclDao.daoIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strIngreso str = dao1.ExisteSubtipo(id);
            pclDao.daoEgresos dao2 = new pclDao.daoEgresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strEgreso str1 = dao2.ExisteSubtipo(id);

            if (str == null && str1 == null)
            {
                int save = dao.Delete(id);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(subTipoEgresoIngreso);
            }
            else
                return View(subTipoEgresoIngreso);
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