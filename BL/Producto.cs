using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    ObjectParameter IdProducto = new ObjectParameter("IdProducto", typeof(int));
                    var query = context.ProductoAdd(producto.Subcategoria.IdSubcategoria, producto.Proveedor.IdProveedor,
                        producto.Nombre, producto.Descripcion, producto.Precio, producto.Piezas, IdProducto);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo agregar";
                    }
                }
            }
            catch(Exception e)
            {
                result.Correct = false;
                result.Message = e.Message;
            }
            return result;
        }
        public static ML.Result DeleteEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.ProductoDelete(producto.IdProducto);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo eliminar";
                    }
                }
            }
            catch(Exception e)
            {
                result.Correct = false;
                result.Message = e.Message;
            }
            return result;
        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.ProductoGetAll();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.Subcategoria = new ML.Subcategoria();
                            producto.Subcategoria.Categoria = new ML.Categoria();
                            producto.Proveedor = new ML.Proveedor();
                            
                            producto.IdProducto = obj.IdProducto;
                            producto.Descripcion = obj.Descripcion;
                            producto.Nombre = obj.NombreProducto;
                            producto.Piezas = obj.Piezas;
                            producto.Precio = obj.Precio;
                            producto.Proveedor.IdProveedor = obj.IdProveedor;
                            producto.Proveedor.Nombre = obj.NombreProveedor;
                            producto.Subcategoria.Categoria.IdCategoria = obj.IdCategoria;
                            producto.Subcategoria.Categoria.Nombre = obj.NombreCategoria;
                            producto.Subcategoria.IdSubcategoria = obj.IdSubcategoria;
                            producto.Subcategoria.Nombre = obj.NombreSubcategoria;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros.";
                    }
                }
            }
            catch(Exception e)
            {
                result.Correct = false;
                result.Message = e.Message;
            }
            return result;
        }
        public static ML.Result GetByIdEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.ProductoGetById(producto.IdProducto).FirstOrDefault();
                    if (query != null)
                    {
                        producto.Subcategoria = new ML.Subcategoria();
                        producto.Subcategoria.Categoria = new ML.Categoria();
                        producto.Proveedor = new ML.Proveedor();

                        producto.IdProducto = query.IdProducto;
                        producto.Descripcion = query.Descripcion;
                        producto.Nombre = query.NombreProducto;
                        producto.Piezas = query.Piezas;
                        producto.Precio = query.Precio;
                        producto.Proveedor.Nombre = query.NombreProveedor;
                        producto.Subcategoria.Nombre = query.NombreSubcategoria;

                        result.Object = producto;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontró ningún registro.";
                    }
                }
            }
            catch(Exception e)
            {
                result.Correct = false;
                result.Message = e.Message;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.ProductoUpdate(producto.IdProducto, producto.Subcategoria.IdSubcategoria,
                        producto.Proveedor.IdProveedor, producto.Nombre, producto.Descripcion, producto.Precio, 
                        producto.Piezas);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo actualizar";
                    }
                }
            }
            catch(Exception e)
            {
                result.Correct = false;
                result.Message = e.Message;
            }
            return result;
        }
    }
}
