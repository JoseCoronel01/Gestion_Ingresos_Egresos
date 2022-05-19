using System.Net;
using System.Web.Mvc;
using UI_Gestion.Models;
using pclStr = PCL_Gestion.str;
using pclDao = PCL_Gestion.dao;
using System.Collections.Generic;
using System;
using pclUtil = PCL_Gestion.util;

namespace UI_Gestion.Controllers
{
    public class strPClienteController : Controller
    {
        // GET: strBanco
        public ActionResult Index()
        {
            pclDao.daoPersonas dao = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());

            List<pclStr.strPersona> lista = dao.GetAll(pclStr.strPersona.eTipo.Cliente);

            List<strPCliente> cliente = new List<strPCliente>();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    if (cliente == null) cliente = new List<strPCliente>();
                    cliente.Add(new strPCliente()
                    {
                        Id = item.Id,
                        ApellidoPaterno = item.ApellidoPaterno,
                        ApellidoMaterno = item.ApellidoMaterno,
                        Nombre = item.Nombre,
                        Curp = item.Curp,
                        Rfc = item.Rfc,
                        FechaNacimiento = item.FechaNacimiento,
                        Sexo = item.Sexo,
                        Estatus = ConvertTo(item.Estatus)
                    });
                }
            }

            return View(cliente);
        }

        private strPCliente.eEstatus ConvertTo(pclStr.strPersona.eEstatus estatus)
        {
            switch (estatus)
            {
                case pclStr.strPersona.eEstatus.ACTIVO:
                    {
                        return strPCliente.eEstatus.ACTIVO;
                    }
                case pclStr.strPersona.eEstatus.INACTIVO:
                    {
                        return strPCliente.eEstatus.INACTIVO;
                    }
                case pclStr.strPersona.eEstatus.BAJA:
                    {
                        return strPCliente.eEstatus.BAJA;
                    }
                default:
                    {
                        return strPCliente.eEstatus.SN;
                    }
            }
        }

        private pclStr.strPersona.eEstatus ConvertTo(strPCliente.eEstatus estatus)
        {
            switch (estatus)
            {
                case strPCliente.eEstatus.ACTIVO:
                    {
                        return pclStr.strPersona.eEstatus.ACTIVO;
                    }
                case strPCliente.eEstatus.INACTIVO:
                    {
                        return pclStr.strPersona.eEstatus.INACTIVO;
                    }
                case strPCliente.eEstatus.BAJA:
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
            strPCliente str1 = ConvertToViewModel(str);
            return View(str1);
        }

        private strPCliente ConvertToViewModel(pclStr.strPersona str)
        {
            strPCliente str1 = new strPCliente();
            str1.Id = str.Id;
            str1.ApellidoMaterno = str.ApellidoMaterno;
            str1.ApellidoPaterno = str.ApellidoPaterno;
            str1.Curp = str.Curp;
            str1.Estatus = ConvertTo(str.Estatus);
            str1.FechaNacimiento = str.FechaNacimiento;
            str1.Nombre = str.Nombre;
            str1.Rfc = str.Rfc;
            str1.Sexo = str.Sexo;
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
            List<pclUtil.ElementoComboBox> elementos = pclUtil.Util.Genero();
            ViewBag.Sexo = new SelectList(elementos, "value", "text");

            strPCliente str = new strPCliente();
            pclDao.daoPersonas dao = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            str.Id = dao.CreateId();

            return View(str);
        }

        // POST: strBanco/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ApellidoPaterno,ApellidoMaterno,Nombre,FechaNacimiento,Sexo,Curp,Rfc,Estatus")] strPCliente strPCliente)
        {
            List<pclUtil.ElementoComboBox> elementos = pclUtil.Util.Genero();
            if (ModelState.IsValid)
            {
                pclStr.strPersona str = new pclStr.strPersona();
                pclDao.daoPersonas dao = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                str.Id = strPCliente.Id;
                str.ApellidoPaterno = strPCliente.ApellidoPaterno;
                str.ApellidoMaterno = strPCliente.ApellidoMaterno;
                str.Nombre = strPCliente.Nombre;
                str.FechaNacimiento = strPCliente.FechaNacimiento;
                str.Sexo = strPCliente.Sexo;
                str.Curp = strPCliente.Curp;
                str.Rfc = strPCliente.Rfc;
                str.Estatus = ConvertTo(strPCliente.Estatus);
                str.FechaRegistro = DateTime.Now;
                str.Tipo = pclStr.strPersona.eTipo.Cliente;
                int save = dao.Insert(str, pclStr.strPersona.eTipo.Cliente);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.Sexo = new SelectList(elementos, "value", "text", strPCliente.Sexo);
                    return View(strPCliente);
                }
            }

            ViewBag.Sexo = new SelectList(elementos, "value", "text", strPCliente.Sexo);
            return View(strPCliente);
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
            strPCliente str1 = ConvertToViewModel(str);
            List<pclUtil.ElementoComboBox> elementos = pclUtil.Util.Genero();
            ViewBag.Sexo = new SelectList(elementos, "value", "text", str1.Sexo);
            ViewBag.FechaNacimiento = str1.FechaNacimiento.ToShortDateString();
            return View(str1);
        }

        // POST: strBanco/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ApellidoPaterno,ApellidoMaterno,Nombre,FechaNacimiento,Sexo,Curp,Rfc,Estatus")] strPCliente strPCliente)
        {
            List<pclUtil.ElementoComboBox> elementos = pclUtil.Util.Genero();
            if (ModelState.IsValid)
            {
                pclStr.strPersona str = new pclStr.strPersona();
                pclDao.daoPersonas dao = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
                str.Id = strPCliente.Id;
                str.ApellidoPaterno = strPCliente.ApellidoPaterno;
                str.ApellidoMaterno = strPCliente.ApellidoMaterno;
                str.Nombre = strPCliente.Nombre;
                str.FechaNacimiento = strPCliente.FechaNacimiento;
                str.Sexo = strPCliente.Sexo;
                str.Curp = strPCliente.Curp;
                str.Rfc = strPCliente.Rfc;
                str.Estatus = ConvertTo(strPCliente.Estatus);
                str.Tipo = pclStr.strPersona.eTipo.Cliente;
                int save = dao.Update(str, pclStr.strPersona.eTipo.Cliente);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.Sexo = new SelectList(elementos, "value", "text", strPCliente.Sexo);
                    return View(strPCliente);
                }
            }

            ViewBag.Sexo = new SelectList(elementos, "value", "text", strPCliente.Sexo);
            return View(strPCliente);
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
            strPCliente str1 = ConvertToViewModel(str);
            return View(str1);
        }

        // POST: strBanco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long? id)
        {
            pclDao.daoReferencias dao1 = new pclDao.daoReferencias(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strReferencia str_ = dao1.ExistePersona((long)id);

            pclDao.daoIngresos dao = new pclDao.daoIngresos(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strIngreso str = dao.ExisteCliente((long)id);

            pclDao.daoPersonas dao2 = new pclDao.daoPersonas(System.Web.HttpContext.Current.Session["GetStringConnection"].ToString());
            pclStr.strPersona str1 = dao2.GetObject((long)id);
            strPCliente pCliente = ConvertToViewModel(str1);

            if (str_ == null && str == null)
            {
                int save = dao2.Delete((long)id);
                if (save > 0)
                    return RedirectToAction("Index");
                else
                    return View(pCliente);
            }
            else
                return View(pCliente);
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