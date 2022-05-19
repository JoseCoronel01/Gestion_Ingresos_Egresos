using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using UI_Gestion.Models;
using pclDao = PCL_Gestion.dao;
using pclStr = PCL_Gestion.str;
using pclUtil = PCL_Gestion.util;

namespace UI_Gestion.Controllers
{
    public class strReferenciaController : Controller
    {
        // GET: strReferencia
        public ActionResult Index()
        {
            pclDao.daoTipoReferencias dao1 = new pclDao.daoTipoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclDao.daoPersonas dao2 = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());

            pclDao.daoReferencias dao = new pclDao.daoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            List<pclStr.strReferencia> lista = dao.GetAll();
            List<strReferencia> list = new List<strReferencia>();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    list.Add(new strReferencia()
                    {
                        Clave = item.Clave,
                        Persona = item.Persona,
                        Nombre = item.Nombre,
                        Tipo = item.Tipo,
                        PersonaNombre = dao2.GetObject(item.Persona).ToString(),
                        TipoNombre = dao1.GetObject(item.Tipo).ToString()
                    });
                }
            }

            return View(list);
        }

        // GET: strReferencia/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strReferencia str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strReferencia str1 = ConvertToViewModel(str);
            return View(str1);
        }

        private strReferencia ConvertToViewModel(pclStr.strReferencia str)
        {
            strReferencia str1 = new strReferencia();
            str1.Clave = str.Clave;
            str1.Persona = str.Persona;
            str1.Nombre = str.Nombre;
            str1.Tipo = str.Tipo;
            return str1;
        }

        private pclStr.strReferencia ConvertToStr(string id)
        {
            pclDao.daoReferencias dao = new pclDao.daoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strReferencia str = dao.GetObject(id);
            return str;
        }

        // GET: strReferencia/Create
        public ActionResult Create()
        {
            CargarCombos();
            return View();
        }

        private void CargarCombos(long? persona = null, int? tipo = null)
        {
            pclDao.daoTipoReferencias dao = new pclDao.daoTipoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            List<pclStr.strTipoReferencia> lista = dao.GetAll();
            if (lista != null)
            {
                if (tipo == null)
                    ViewBag.Tipo = new SelectList(lista, "Id", "Nombre");
                else
                    ViewBag.Tipo = new SelectList(lista, "Id", "Nombre", tipo);
            }
            else
                ViewBag.Tipo = new SelectList(new List<pclStr.strTipoReferencia>(), "Id", "Nombre");

            List<pclUtil.ElementoComboBox> elementos = new List<pclUtil.ElementoComboBox>();
            pclDao.daoPersonas dao1 = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            List<pclStr.strPersona> list = dao1.GetAll();
            if (list != null)
                foreach (var item in list)
                    elementos.Add(new pclUtil.ElementoComboBox() { value = item.Id, text = item.ToString() });

            if (persona == null)
                ViewBag.Persona = new SelectList(elementos, "value", "text");
            else
                ViewBag.Persona = new SelectList(elementos, "value", "text", persona);
        }

        // POST: strReferencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Clave,Persona,Nombre,Tipo")] strReferencia strReferencia)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoReferencias dao = new pclDao.daoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strReferencia str = new pclStr.strReferencia();
                str.Clave = strReferencia.Clave;
                str.Persona = strReferencia.Persona;
                str.Nombre = strReferencia.Nombre;
                str.Tipo = strReferencia.Tipo;
                int save = dao.Insert(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                {
                    CargarCombos(strReferencia.Persona, strReferencia.Tipo);
                    return View(strReferencia);
                }
            }

            CargarCombos(strReferencia.Persona, strReferencia.Tipo);
            return View(strReferencia);
        }

        // GET: strReferencia/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strReferencia str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strReferencia str1 = ConvertToViewModel(str);
            CargarCombos(str1.Persona, str1.Tipo);
            return View(str1);
        }

        // POST: strReferencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Clave,Persona,Nombre,Tipo")] strReferencia strReferencia)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoReferencias dao = new pclDao.daoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strReferencia str = new pclStr.strReferencia();
                str.Clave = strReferencia.Clave;
                str.Persona = strReferencia.Persona;
                str.Nombre = strReferencia.Nombre;
                str.Tipo = strReferencia.Tipo;
                int save = dao.Update(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                {
                    CargarCombos(strReferencia.Persona, strReferencia.Tipo);
                    return View(strReferencia);
                }
            }

            CargarCombos(strReferencia.Persona, strReferencia.Tipo);
            return View(strReferencia);
        }

        // GET: strReferencia/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strReferencia str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strReferencia str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strReferencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            pclDao.daoReferencias dao = new pclDao.daoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strReferencia str = dao.GetObject(id);
            strReferencia referencia = ConvertToViewModel(str);

            int save = dao.Delete(id);
            if (save > 0)
                return RedirectToAction("Index");
            else
                return View(referencia);
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