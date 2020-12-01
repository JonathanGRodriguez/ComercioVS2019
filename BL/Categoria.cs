using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Categoria
    {
        public static ML.Result AddEF(ML.Categoria categoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    ObjectParameter idCategoria = new ObjectParameter("IdCategoria", typeof(int));
                    var query = context.CategoriaAdd(categoria.Nombre, idCategoria);
                    if (query >= 1)
                    {
                        categoria.IdCategoria = (int)idCategoria.Value;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo agregar";
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
        public static ML.Result DeleteEF(ML.Categoria categoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.CategoriaDelete(categoria.IdCategoria);
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
                    var query = conetxt.CategoriaGetAll();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Categoria categoria = new ML.Categoria();

                            categoria.IdCategoria = obj.IdCategoria;
                            categoria.Nombre = obj.Nombre;

                            result.Objects.Add(categoria);

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
        public static ML.Result GetByIdEF(ML.Categoria categoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.CategoriaGetById(categoria.IdCategoria).FirstOrDefault();
                    if (query != null)
                    {
                        categoria.IdCategoria = query.IdCategoria;
                        categoria.Nombre = query.Nombre;

                        result.Object = categoria;
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
        public static ML.Result UpdateEF(ML.Categoria categoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.CategoriaUpdate(categoria.IdCategoria, categoria.Nombre);
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
