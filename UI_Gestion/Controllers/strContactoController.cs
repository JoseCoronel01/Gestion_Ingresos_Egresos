using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using UI_Gestion.Models;
using pclDao = PCL_Gestion.dao;
using pclStr = PCL_Gestion.str;
using pclUtil = PCL_Gestion.util;

namespace UI_Gestion.Controllers
{
    public class strContactoController : Controller
    {
        // GET: strContacto
        public ActionResult Index()
        {
            pclDao.daoPersonas dao1 = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclDao.daoContactos dao = new pclDao.daoContactos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            List<pclStr.strContacto> lista = dao.GetAll();
            List<strContacto> list = new List<strContacto>();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    list.Add(new strContacto()
                    {
                        Persona = item.Persona,
                        Direccion = item.Direccion,
                        TelefonoCasa = item.TelefonoCasa,
                        TelefonoCelular = item.TelefonoCelular,
                        TelefonoOficina = item.TelefonoOficina,
                        Correo = item.Correo,
                        CorreoAlt = item.CorreoAlt,
                        Nombre = dao1.GetObject(item.Persona).ToString()
                    });
                }
            }

            return View(list);
        }

        // GET: strContacto/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strContacto str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strContacto str1 = ConvertToViewModel(str);
            return View(str1);
        }

        private strContacto ConvertToViewModel(pclStr.strContacto str)
        {
            strContacto str1 = new strContacto();
            str1.Persona = str.Persona;
            str1.Direccion = str.Direccion;
            str1.TelefonoCasa = str.TelefonoCasa;
            str1.TelefonoCelular = str.TelefonoCelular;
            str1.TelefonoOficina = str.TelefonoOficina;
            str1.Correo = str.Correo;
            str1.CorreoAlt = str.CorreoAlt;
            return str1;
        }

        private pclStr.strContacto ConvertToStr(long? id)
        {
            pclDao.daoContactos dao = new pclDao.daoContactos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strContacto str = dao.GetObject((long)id);
            return str;
        }

        // GET: strContacto/Create
        public ActionResult Create()
        {
            CargarCombo();
            return View();
        }

        private void CargarCombo(long? id = null)
        {
            List<pclUtil.ElementoComboBox> elementos = new List<pclUtil.ElementoComboBox>();
            List<pclStr.strPersona> lista = null;
            pclDao.daoPersonas dao = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            lista = dao.GetAll();
            if (lista != null)
                foreach (var item in lista)
                    elementos.Add(new pclUtil.ElementoComboBox() { value = item.Id, text = item.ToString() });
            if (id == null)
                ViewBag.Persona = new SelectList(elementos, "value", "text");
            else
                ViewBag.Persona = new SelectList(elementos, "value", "text", id);
        }

        // POST: strContacto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Persona,Direccion,TelefonoCasa,TelefonoOficina,TelefonoCelular,Correo,CorreoAlt")] strContacto strContacto)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoContactos dao = new pclDao.daoContactos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strContacto str = new pclStr.strContacto();
                str.Persona = strContacto.Persona;
                str.Direccion = strContacto.Direccion;
                str.TelefonoCasa = strContacto.TelefonoCasa;
                str.TelefonoCelular = strContacto.TelefonoCelular;
                str.TelefonoOficina = strContacto.TelefonoOficina;
                str.Correo = strContacto.Correo;
                str.CorreoAlt = strContacto.CorreoAlt;
                int save = dao.Insert(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                {
                    CargarCombo(strContacto.Persona);
                    return View(strContacto);
                }
            }

            CargarCombo(strContacto.Persona);
            return View(strContacto);
        }

        // GET: strContacto/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strContacto str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strContacto str1 = ConvertToViewModel(str);
            CargarCombo(str1.Persona);
            return View(str1);
        }

        // POST: strContacto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Persona,Direccion,TelefonoCasa,TelefonoOficina,TelefonoCelular,Correo,CorreoAlt")] strContacto strContacto)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoContactos dao = new pclDao.daoContactos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strContacto str = new pclStr.strContacto();
                str.Persona = strContacto.Persona;
                str.Direccion = strContacto.Direccion;
                str.TelefonoCasa = strContacto.TelefonoCasa;
                str.TelefonoCelular = strContacto.TelefonoCelular;
                str.TelefonoOficina = strContacto.TelefonoOficina;
                str.Correo = strContacto.Correo;
                str.CorreoAlt = strContacto.CorreoAlt;
                int save = dao.Update(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                {
                    CargarCombo(strContacto.Persona);
                    return View(strContacto);
                }
            }

            CargarCombo(strContacto.Persona);
            return View(strContacto);
        }

        // GET: strContacto/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strContacto str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strContacto str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strContacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            pclDao.daoContactos dao = new pclDao.daoContactos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strContacto str = dao.GetObject(id);
            strContacto str1 = ConvertToViewModel(str);

            int save = dao.Delete(id);
            if (save > 0)
                return RedirectToAction("Index");
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