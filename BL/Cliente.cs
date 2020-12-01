using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cliente
    {
        public static ML.Result AddEF(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    ObjectParameter idCliente = new ObjectParameter("IdCliente", typeof(int));
                    var query = context.ClienteAdd(cliente.Nombre, cliente.ApellidoPaterno, cliente.ApellidoMaterno, 
                        idCliente);
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
        public static ML.Result DeleteEF(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.ClienteDelete(cliente.IdCliente);
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
            catch (Exception e)
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
                using (DL_EF.ComercioEntities conetxt = new DL_EF.ComercioEntities())
                {
                    var query = conetxt.ClienteGetAll();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Cliente cliente = new ML.Cliente();

                            cliente.IdCliente = obj.IdCliente;
                            cliente.Nombre = obj.Nombre;
                            cliente.ApellidoPaterno = obj.ApellidoPaterno;
                            cliente.ApellidoMaterno = obj.ApellidoMaterno;

                            result.Objects.Add(cliente);

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
            catch (Exception e)
            {
                result.Correct = false;
                result.Message = e.Message;
            }
            return result;
        }
        public static ML.Result GetByIdEF(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.ClienteGetById(cliente.IdCliente).FirstOrDefault();
                    if (query != null)
                    {
                        cliente.Nombre = query.Nombre;
                        cliente.ApellidoPaterno = query.ApellidoPaterno;
                        cliente.ApellidoMaterno = query.ApellidoMaterno;

                        result.Object = cliente;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.Message = e.Message;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.ClienteUpdate(cliente.IdCliente,cliente.Nombre, cliente.ApellidoPaterno, 
                        cliente.ApellidoMaterno);
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
            catch (Exception e)
            {
                result.Correct = false;
                result.Message = e.Message;
            }
            return result;
        }

    }
}
