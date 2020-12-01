using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DetalleVenta
    {
        public static ML.Result AddEF(ML.DetalleVenta detalleVenta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    ObjectParameter idDetalleVenta = new ObjectParameter("IdDetalleVenta", typeof(int));
                    var query = context.DetalleVentaAdd(detalleVenta.Producto.IdProducto, detalleVenta.Venta.IdVenta, 
                        detalleVenta.Piezas,idDetalleVenta);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo agregar.";
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
        public static ML.Result DeleteEF(ML.DetalleVenta detalleVenta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.DetalleVentaDelete(detalleVenta.IdDetalleVenta);
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
                using(DL_EF.ComercioEntities conetxt = new DL_EF.ComercioEntities())
                {
                    var query = conetxt.DetalleVentaGetAll();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(object obj in query)
                        {
                            ML.DetalleVenta detalleVenta = new ML.DetalleVenta();
                            detalleVenta.Producto = new ML.Producto();
                            detalleVenta.Venta = new ML.Venta();

                            detalleVenta.IdDetalleVenta = ((ML.DetalleVenta)obj).IdDetalleVenta;
                            detalleVenta.Producto.IdProducto = ((ML.DetalleVenta)obj).Producto.IdProducto;
                            detalleVenta.Venta.IdVenta = ((ML.DetalleVenta)obj).Venta.IdVenta;
                            detalleVenta.Piezas = ((ML.DetalleVenta)obj).Piezas;

                            result.Objects.Add(detalleVenta);
                            
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
        public static ML.Result GetByIdEF(ML.DetalleVenta detalleVenta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.DetalleVentaGetById(detalleVenta.IdDetalleVenta);
                    if (query != null)
                    {
                        object obj = query;
                        detalleVenta.Producto.IdProducto = ((ML.DetalleVenta)obj).Producto.IdProducto;
                        detalleVenta.Venta.IdVenta = ((ML.DetalleVenta)obj).Venta.IdVenta;
                        detalleVenta.Piezas = ((ML.DetalleVenta)obj).Piezas;

                        result.Object = detalleVenta;
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
        public static ML.Result UpdateEF(ML.DetalleVenta detalleVenta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.DetalleVentaUpdate(detalleVenta.IdDetalleVenta, detalleVenta.Producto.IdProducto,
                        detalleVenta.Venta.IdVenta, detalleVenta.Piezas);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo actualizar.";
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
