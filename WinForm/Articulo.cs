using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm
{
    internal class Articulo
    {
        public Articulo() {
        
        //El constructor deberia agarrar el ultimo articulo, copiar su ID y sumarlo en 1 para guardarlo en
        //el nuevo articulo que se este creando. De esta forma no se pueden repetir IDs de Articulos
        //Por lo demas, hacer los "cin" necesarios para ya dejar el articulo todo cargado

        }

        int idArticulo = 0; // Unique, identity (1,1)
        string codigoArticulo = null; //Maximo 50 caracteres (en la tabla aparecen codigos de 3, ejemplo: SO1, MO2
        string nombre = null; //Maximo 50 caracteres
        string descripcion = null; //Maximo 50 caracteres
        Marca marca = null; // Clase de donde se puede linkear el IdMarca con el IdArticulo
        Categoria categoria = null; //Clase de donde se puede linkear el IdCategoria con el IdArticulo
        float precio = 0; // Que sea mayor a cero

        //Mas adelante va a haber que linkear con la imagen para que pueda traer todas las imagenes que tenga cada articulo
        //Vamos a tener que buscar la clase imagen cuyo IdImagen coincida con el IdArticulo.
    }
}
