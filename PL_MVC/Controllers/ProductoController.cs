using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetAllEF();
            producto.Productos = result.Objects;
            return View(producto);
        }
        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            producto.Proveedor = new ML.Proveedor();
            producto.Subcategoria = new ML.Subcategoria();
            producto.Subcategoria.Categoria = new ML.Categoria();
            ML.Result resultProveedores = BL.Proveedor.GetAllEF();
            ML.Result resultSubcategorias = BL.Subcategoria.GetAllEF();
            ML.Result resultCategorias = BL.Categoria.GetAllEF();
            producto.Proveedor.Proveedores = resultProveedores.Objects;
            producto.Subcategoria.Subcategorias = resultSubcategorias.Objects;
            producto.Subcategoria.Categoria.Categorias = resultCategorias.Objects;
            if (IdProducto == null)
            {
                ViewBag.Titulo = "Agregar producto nuevo";
                ViewBag.Accion = "Guardar";
            }
            else
            {
                ViewBag.Titulo = "Actualizar producto existente";
                ViewBag.Accion = "Actualizar";
            }
            return View(producto);
        }
        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            ML.Result result;
            if (producto.IdProducto == 0)
            {
                result = BL.Producto.AddEF(producto);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Agregado correctamente";
                    return PartialView("Validacion");
                }
                else
                {
                    ViewBag.Mensaje = result.Message;
                    return PartialView("Validacion");
                }
            }
            else
            {
                result = BL.Producto.UpdateEF(producto);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Actualizado correctamente";
                    return PartialView("Validacion");
                }
                else
                {
                    ViewBag.Mensaje = result.Message;
                    return PartialView("Validacion");
                }
            }
        }


        
    }
}