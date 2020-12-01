using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Subcategoria
    {
        public static ML.Result AddEF(ML.Subcategoria subcategoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    ObjectParameter idSubcategoria = new ObjectParameter("IdSubcategoria", typeof(int));
                    var query = context.SubcategoriaAdd(subcategoria.Categoria.IdCategoria, subcategoria.Nombre, idSubcategoria);
                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo agregar la subcategoría";
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
        public static ML.Result DeleteEF(ML.Subcategoria subcategoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.SubcategoriaDelete(subcategoria.IdSubcategoria);
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
                    var query = context.SubcategoriaGetAll();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.Subcategoria subcategoria = new ML.Subcategoria();
                            subcategoria.Categoria = new ML.Categoria();
                            subcategoria.IdSubcategoria = obj.IdSubcategoria;
                            subcategoria.Nombre = obj.NombreSubcategoria;
                            subcategoria.Categoria.Nombre = obj.NombreCategoria;
                            result.Objects.Add(subcategoria);
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
        public static ML.Result GetByIdEF(ML.Subcategoria subcategoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.SubcategoriaGetById(subcategoria.IdSubcategoria).FirstOrDefault();
                    if (query != null)
                    {
                        subcategoria.IdSubcategoria = query.IdSubcategoria;
                        subcategoria.Nombre = query.NombreSubcategoria;
                        subcategoria.Categoria = new ML.Categoria();
                        subcategoria.Categoria.Nombre = query.NombreCategoria;
                        result.Object = subcategoria;
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
        public static ML.Result UpdateEF(ML.Subcategoria subcategoria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.ComercioEntities context = new DL_EF.ComercioEntities())
                {
                    var query = context.SubcategoriaUpdate(subcategoria.IdSubcategoria, subcategoria.Categoria.IdCategoria, subcategoria.Nombre);
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
