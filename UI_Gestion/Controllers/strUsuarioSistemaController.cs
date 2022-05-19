using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using UI_Gestion.Models;
using pclDao = PCL_Gestion.dao;
using pclStr = PCL_Gestion.str;

namespace UI_Gestion.Controllers
{
    public class strUsuarioSistemaController : Controller
    {
        // GET: strUsuarioSistema
        public ActionResult Index()
        {
            pclDao.daoUsuariosSistema dao = new pclDao.daoUsuariosSistema(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            List<pclStr.strUsuarioSistema> str = dao.GetAll();
            List<strUsuarioSistema> list = new List<Models.strUsuarioSistema>();
            if (str != null)
            {
                foreach (var item in str)
                {
                    list.Add(new strUsuarioSistema()
                    {
                        Usuario = item.Usuario,
                        Password = item.Password,
                        Tipo = ConvertToModelView(item.Tipo)
                    });
                }
            }

            return View(list);
        }

        private strUsuarioSistema.eTipo ConvertToModelView(pclStr.strUsuarioSistema.eTipo tipo)
        {
            switch (tipo)
            {
                case pclStr.strUsuarioSistema.eTipo.SUPERVISOR:
                    {
                        return strUsuarioSistema.eTipo.SUPERVISOR;
                    }
                case pclStr.strUsuarioSistema.eTipo.OPERADOR:
                    {
                        return strUsuarioSistema.eTipo.OPERADOR;
                    }
                default:
                    {
                        return strUsuarioSistema.eTipo.AUDITOR;
                    }
            }
        }

        private pclStr.strUsuarioSistema.eTipo ConvertToModelStr(strUsuarioSistema.eTipo tipo)
        {
            switch (tipo)
            {
                case strUsuarioSistema.eTipo.SUPERVISOR:
                    {
                        return pclStr.strUsuarioSistema.eTipo.SUPERVISOR;
                    }
                case strUsuarioSistema.eTipo.OPERADOR:
                    {
                        return pclStr.strUsuarioSistema.eTipo.OPERADOR;
                    }
                default:
                    {
                        return pclStr.strUsuarioSistema.eTipo.AUDITOR;
                    }
            }
        }

        // GET: strUsuarioSistema/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strUsuarioSistema str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strUsuarioSistema str1 = ConvertToViewModel(str);
            return View(str1);
        }

        private strUsuarioSistema ConvertToViewModel(pclStr.strUsuarioSistema str)
        {
            strUsuarioSistema str1 = new strUsuarioSistema();
            str1.Usuario = str.Usuario;
            str1.Password = str.Password;
            str1.Tipo = ConvertToModelView(str.Tipo);
            return str1;
        }

        private pclStr.strUsuarioSistema ConvertToStr(string id)
        {
            pclDao.daoUsuariosSistema dao = new pclDao.daoUsuariosSistema(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strUsuarioSistema str = dao.GetObject(id);
            return str;
        }

        // GET: strUsuarioSistema/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: strUsuarioSistema/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Usuario,Password,Tipo")] strUsuarioSistema strUsuarioSistema)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoUsuariosSistema dao = new pclDao.daoUsuariosSistema(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strUsuarioSistema str = new pclStr.strUsuarioSistema();
                str.Usuario = strUsuarioSistema.Usuario;
                str.Password = strUsuarioSistema.Password;
                str.Tipo = ConvertToModelStr(strUsuarioSistema.Tipo);
                int save = dao.Insert(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strUsuarioSistema);
            }

            return View(strUsuarioSistema);
        }

        // GET: strUsuarioSistema/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strUsuarioSistema str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strUsuarioSistema str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strUsuarioSistema/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Usuario,Password,Tipo")] strUsuarioSistema strUsuarioSistema)
        {
            if (ModelState.IsValid)
            {
                pclDao.daoUsuariosSistema dao = new pclDao.daoUsuariosSistema(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                pclStr.strUsuarioSistema str = new pclStr.strUsuarioSistema();
                str.Usuario = strUsuarioSistema.Usuario;
                str.Password = strUsuarioSistema.Password;
                str.Tipo = ConvertToModelStr(strUsuarioSistema.Tipo);
                int save = dao.Update(str);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strUsuarioSistema);
            }
            return View(strUsuarioSistema);
        }

        // GET: strUsuarioSistema/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strUsuarioSistema str = ConvertToStr(id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strUsuarioSistema str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strUsuarioSistema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            pclDao.daoUsuariosSistema dao = new pclDao.daoUsuariosSistema(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strUsuarioSistema str = dao.GetObject(id);
            strUsuarioSistema usuarioSistema = new strUsuarioSistema();

            if (str != null)
            {
                usuarioSistema = ConvertToViewModel(str);

                int save = dao.Delete(str.Usuario);

                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(usuarioSistema);
            }
            else
                return View(usuarioSistema);
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