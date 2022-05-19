using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using UI_Gestion.Models;
using pclDao = PCL_Gestion.dao;
using pclStr = PCL_Gestion.str;

namespace UI_Gestion.Controllers
{
    public class strTipoEgresoIngresoController : Controller
    {
        // GET: strTipoEgresoIngreso
        public ActionResult Index()
        {
            pclDao.daoTipoEgresosIngresos dao = new pclDao.daoTipoEgresosIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            List<pclStr.strTipoEgresoIngreso> lista = dao.GetAll();

            List<strTipoEgresoIngreso> list = new List<strTipoEgresoIngreso>();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    list.Add(new strTipoEgresoIngreso()
                    {
                        Clave = item.Clave,
                        Nombre = item.Nombre,
                        Tipo = ConvertTo(item.Tipo)
                    });
                }
            }

            return View(list);
        }

        private pclStr.strTipoEgresoIngreso.eTipo GetEnumType(int? id)
        {
            switch (id)
            {
                case 0:
                    {
                        return pclStr.strTipoEgresoIngreso.eTipo.Ingreso;
                    }
                case 1:
                    {
                        return pclStr.strTipoEgresoIngreso.eTipo.Egreso;
                    }
                default:
                    {
                        return pclStr.strTipoEgresoIngreso.eTipo.TipoC;
                    }
            }
        }

        private strTipoEgresoIngreso.eTipo ConvertTo(pclStr.strTipoEgresoIngreso.eTipo tipo)
        {
            switch (tipo)
            {
                case pclStr.strTipoEgresoIngreso.eTipo.Ingreso:
                    {
                        return strTipoEgresoIngreso.eTipo.Ingreso;
                    }
                case pclStr.strTipoEgresoIngreso.eTipo.Egreso:
                    {
                        return strTipoEgresoIngreso.eTipo.Egreso;
                    }
                default:
                    {
                        return strTipoEgresoIngreso.eTipo.TipoC;
                    }
            }
        }

        // GET: strTipoEgresoIngreso/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strTipoEgresoIngreso str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strTipoEgresoIngreso str1 = ConvertToViewModel(str);
            return View(str1);
        }

        private strTipoEgresoIngreso ConvertToViewModel(pclStr.strTipoEgresoIngreso str)
        {
            strTipoEgresoIngreso str1 = new strTipoEgresoIngreso();
            str1.Clave = str.Clave;
            str1.Nombre = str.Nombre;
            str1.Tipo = ConvertTo(str.Tipo);
            return str1;
        }

        private pclStr.strTipoEgresoIngreso ConvertToStr(string id)
        {
            pclDao.daoTipoEgresosIngresos dao = new pclDao.daoTipoEgresosIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strTipoEgresoIngreso str = dao.GetObject(id);
            return str;
        }

        // GET: strTipoEgresoIngreso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: strTipoEgresoIngreso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Clave,Nombre,Tipo")] strTipoEgresoIngreso strTipoEgresoIngreso)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoTipoEgresosIngresos dao = new pclDao.daoTipoEgresosIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strTipoEgresoIngreso str = new pclStr.strTipoEgresoIngreso();
                str.Clave = strTipoEgresoIngreso.Clave;
                str.Nombre = strTipoEgresoIngreso.Nombre;
                str.Tipo = ConvertToStr(strTipoEgresoIngreso.Tipo);
                int save = dao.Insert(str);
                if (save > 0)
                    return RedirectToAction("Index", new { id = str.Tipo });
                else
                    return View(strTipoEgresoIngreso);
            }

            return View(strTipoEgresoIngreso);
        }

        private pclStr.strTipoEgresoIngreso.eTipo ConvertToStr(strTipoEgresoIngreso.eTipo tipo)
        {
            switch (tipo)
            {
                case strTipoEgresoIngreso.eTipo.Ingreso:
                    {
                        return pclStr.strTipoEgresoIngreso.eTipo.Ingreso;
                    }
                case strTipoEgresoIngreso.eTipo.Egreso:
                    {
                        return pclStr.strTipoEgresoIngreso.eTipo.Egreso;
                    }
                default:
                    {
                        return pclStr.strTipoEgresoIngreso.eTipo.TipoC;
                    }
            }
        }

        // GET: strTipoEgresoIngreso/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strTipoEgresoIngreso str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strTipoEgresoIngreso str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strTipoEgresoIngreso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Clave,Nombre,Tipo")] strTipoEgresoIngreso strTipoEgresoIngreso)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoTipoEgresosIngresos dao = new pclDao.daoTipoEgresosIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strTipoEgresoIngreso str = new pclStr.strTipoEgresoIngreso();
                str.Clave = strTipoEgresoIngreso.Clave;
                str.Nombre = strTipoEgresoIngreso.Nombre;
                str.Tipo = ConvertToStr(strTipoEgresoIngreso.Tipo);
                int save = dao.Update(str);
                if (save > 0)
                    return RedirectToAction("Index", new { id = str.Tipo });
                else
                    return View(strTipoEgresoIngreso);
            }
            return View(strTipoEgresoIngreso);
        }

        // GET: strTipoEgresoIngreso/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strTipoEgresoIngreso str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strTipoEgresoIngreso str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strTipoEgresoIngreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            pclDao.daoTipoEgresosIngresos dao = new pclDao.daoTipoEgresosIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strTipoEgresoIngreso str = dao.GetObject(id);
            strTipoEgresoIngreso tipoEgresoIngreso = ConvertToViewModel(str);

            pclDao.daoIngresos dao1 = new pclDao.daoIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strIngreso str1 = dao1.ExisteTipo(id);

            pclDao.daoEgresos dao2 = new pclDao.daoEgresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strEgreso str2 = dao2.ExisteTipo(id);

            if (str1 == null && str2 == null)
            {
                int save = dao.Delete(id);
                if (save > 0)
                    return RedirectToAction("Index", new { id = str.Tipo });
                else
                    return View(tipoEgresoIngreso);
            }
            else
                return View(tipoEgresoIngreso);
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