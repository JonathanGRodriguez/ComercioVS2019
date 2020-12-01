using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Venta
    {
        public static ML.Result AddEF(ML.Venta venta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    ObjectParameter idVenta = new ObjectParameter("IdVenta", typeof(int));
                    var query = context.VentaAdd(venta.Cliente.IdCliente, venta.Monto, idVenta);
                    venta.IdVenta = Convert.ToInt32(idVenta);
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
        public static ML.Result DeleteEF(ML.Venta venta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context=new DL_EF.ComercioEntities())
                {
                    var query = context.VentaDelete(venta.IdVenta);
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
                    var query = context.VentaGetAll().ToList();
                    if (query != null)
                    {
                        foreach(object obj in query)
                        {
                            ML.Venta venta = new ML.Venta();
                            venta.IdVenta = ((ML.Venta)obj).IdVenta;
                            
                            venta.Cliente = new ML.Cliente();
                            venta.Cliente.IdCliente = ((ML.Venta)obj).Cliente.IdCliente;

                            venta.Fecha = ((ML.Venta)obj).Fecha;
                            venta.Monto = ((ML.Venta)obj).Monto;

                            result.Objects.Add(venta);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
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
        public static ML.Result GetByIdEF(ML.Venta venta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.VentaGetById(venta.IdVenta);
                    if (query != null)
                    {
                        object obj = query;
                        venta.Cliente = new ML.Cliente();
                        venta.Cliente.IdCliente=((ML.Venta)obj).Cliente.IdCliente;
                        venta.Fecha = ((ML.Venta)obj).Fecha;
                        venta.Monto = ((ML.Venta)obj).Monto;
                        result.Object = venta;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
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
        public static ML.Result UpdateEF(ML.Venta venta)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.VentaUpdate(venta.IdVenta, venta.Cliente.IdCliente, venta.Monto);
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
