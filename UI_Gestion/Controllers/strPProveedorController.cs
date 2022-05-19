using System.Net;
using System.Web.Mvc;
using UI_Gestion.Models;
using pclStr = PCL_Gestion.str;
using pclDao = PCL_Gestion.dao;
using System.Collections.Generic;
using System;

namespace UI_Gestion.Controllers
{
    public class strPProveedorController : Controller
    {
        // GET: strBanco
        public ActionResult Index()
        {
            pclDao.daoPersonas dao = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());

            List<pclStr.strPersona> lista = dao.GetAll(pclStr.strPersona.eTipo.Proveedor);

            List<strPProveedor> cliente = new List<strPProveedor>();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    if (cliente == null) cliente = new List<strPProveedor>();
                    cliente.Add(new strPProveedor()
                    {
                        Id = item.Id,
                        Rfc = item.Rfc,
                        Estatus = ConvertTo(item.Estatus),
                        NombreComercial = item.NombreComercial,
                        RazonSocial = item.RazonSocial
                    });
                }
            }

            return View(cliente);
        }

        private strPProveedor.eEstatus ConvertTo(pclStr.strPersona.eEstatus estatus)
        {
            switch (estatus)
            {
                case pclStr.strPersona.eEstatus.ACTIVO:
                    {
                        return strPProveedor.eEstatus.ACTIVO;
                    }
                case pclStr.strPersona.eEstatus.INACTIVO:
                    {
                        return strPProveedor.eEstatus.INACTIVO;
                    }
                case pclStr.strPersona.eEstatus.BAJA:
                    {
                        return strPProveedor.eEstatus.BAJA;
                    }
                default:
                    {
                        return strPProveedor.eEstatus.SN;
                    }
            }
        }

        private pclStr.strPersona.eEstatus ConvertTo(strPProveedor.eEstatus estatus)
        {
            switch (estatus)
            {
                case strPProveedor.eEstatus.ACTIVO:
                    {
                        return pclStr.strPersona.eEstatus.ACTIVO;
                    }
                case strPProveedor.eEstatus.INACTIVO:
                    {
                        return pclStr.strPersona.eEstatus.INACTIVO;
                    }
                case strPProveedor.eEstatus.BAJA:
                    {
                        return pclStr.strPersona.eEstatus.BAJA;
                    }
                default:
                    {
                        return pclStr.strPersona.eEstatus.Error;
                    }
            }
        }

        // GET: strBanco/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strPersona str = ConvertToStr((long)id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strPProveedor str1 = ConvertToViewModel(str);
            return View(str1);
        }

        private strPProveedor ConvertToViewModel(pclStr.strPersona str)
        {
            strPProveedor str1 = new strPProveedor();
            str1.Id = str.Id;
            str1.Estatus = ConvertTo(str.Estatus);
            str1.Rfc = str.Rfc;
            str1.RazonSocial = str.RazonSocial;
            str1.NombreComercial = str.NombreComercial;
            return str1;
        }

        private pclStr.strPersona ConvertToStr(long id)
        {
            pclDao.daoPersonas dao = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strPersona str = dao.GetObject(id);
            return str;
        }

        // GET: strBanco/Create
        public ActionResult Create()
        {
            strPProveedor str = new strPProveedor();
            pclDao.daoPersonas dao = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            str.Id = dao.CreateId();

            return View(str);
        }

        // POST: strBanco/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Rfc,NombreComercial,RazonSocial,Estatus")] strPProveedor strPProveedor)
        {
            if (ModelState.IsValid)
            {
                pclStr.strPersona str = new pclStr.strPersona();
                pclDao.daoPersonas dao = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                str.Id = strPProveedor.Id;
                str.Rfc = strPProveedor.Rfc;
                str.NombreComercial = strPProveedor.NombreComercial;
                str.RazonSocial = strPProveedor.RazonSocial;
                str.Estatus = ConvertTo(strPProveedor.Estatus);
                str.FechaRegistro = DateTime.Now;
                str.Tipo = pclStr.strPersona.eTipo.Proveedor;
                int save = dao.Insert(str, pclStr.strPersona.eTipo.Proveedor);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strPProveedor);
            }

            return View(strPProveedor);
        }

        // GET: strBanco/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strPersona str = ConvertToStr((long)id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strPProveedor str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strBanco/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Rfc,NombreComercial,RazonSocial,Estatus")] strPProveedor strPProveedor)
        {
            if (ModelState.IsValid)
            {
                pclStr.strPersona str = new pclStr.strPersona();
                pclDao.daoPersonas dao = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                str.Id = strPProveedor.Id;
                str.Rfc = strPProveedor.Rfc;
                str.NombreComercial = strPProveedor.NombreComercial;
                str.RazonSocial = strPProveedor.RazonSocial;
                str.Estatus = ConvertTo(strPProveedor.Estatus);
                str.Tipo = pclStr.strPersona.eTipo.Proveedor;
                int save = dao.Update(str, pclStr.strPersona.eTipo.Proveedor);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(strPProveedor);
            }
            return View(strPProveedor);
        }

        // GET: strBanco/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pclStr.strPersona str = ConvertToStr((long)id);
            if (str == null)
            {
                return HttpNotFound();
            }
            strPProveedor str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strBanco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {
            pclDao.daoReferencias dao1 = new pclDao.daoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strReferencia str_ = dao1.ExistePersona((long)id);

            pclDao.daoEgresos dao = new pclDao.daoEgresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strEgreso str = dao.ExisteProveedor((long)id);

            pclDao.daoPersonas dao2 = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strPersona str1 = dao2.GetObject((long)id);
            strPProveedor pProveedor = ConvertToViewModel(str1);

            if (str_ == null && str == null)
            {
                int save = dao2.Delete((long)id);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(pProveedor);
            }
            else
                return View(pProveedor);
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