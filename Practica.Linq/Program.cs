using Practica.Linq.Helpers;
using PracticaWinForms.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.Linq
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Listas de practica
            var UserList = new List<User>();
            var ProductList = new List<Product>();
            //Generar una lista de datos random.
            Validator validator= new Validator();
            validator.FillData(ref UserList, ref ProductList);
            /*
             * EJEMPLOS
             * Las condiciones siempre se pone primero la palabra que quieras usar de referencia, podes usar cualquiercosa lo estandar es usar algo que represente lo que estas
             * recorriendo, por ej si buscar usuarios (user => ... ) despues va la flecha con => y ahi ya podes escribir condiciones. Las podes hacer lo largas y complejas que
             * quieras pero no conviene hacerlas muy complejas. 
             */
            //Traer un usuario admin.
            //First Or default te trae el primer objeto de la lista que cumpla con las condiciones que le pones y si no encuentra nada devuelve Null
            var admin = UserList.FirstOrDefault(user => user.UserRole == Role.Administrator);
            //Este es lo mismo solo que no devuelve null si no encuentra con las condiciones rompe
            var admin2 = UserList.First(user => user.UserRole == Role.Administrator);
            //Este devuelve true o false si existe algun objeto que cumpla con las caracteristicas    
            var admin3 = UserList.Any(user => user.UserRole == Role.Administrator);
            //Este devuelve la lista de usuarios que tienen rol de admin. Si miras el tipo de dato de admin4 es un Ienumerable
            var admin4 = UserList.Where(user => user.UserRole == Role.Administrator);
            //para que "corra" la query tenes que agregar atras un metodo que lo corra como por ej .ToList o .ToArray
            var admin5 = UserList.Where(user => user.UserRole == Role.Administrator).ToList();
            //Condicion con 2 o mas sentencias. Igual que los condicionales en un IF, con el doble &&, || , & , |
            var admin6 = UserList.Where(user => user.UserName == "admin" && user.Password == "admin").ToList();
            //Podes aplicarles funciones una vez que tenes un objeto o una lista por ej:
            var cantidadAdmins = UserList.Where(u=> u.UserRole == Role.Administrator).ToList().Count;
            //OJO con este, porque si no existe un usuario admin rompe, pq estas accediendo a una propiedad de un null. Siempre mejor primero traer el obj y despues acceder a props
            var nombrePrimerAdmin = UserList.FirstOrDefault(u => u.UserRole == Role.Administrator).UserName; 

            /*
             * PRACTICA
             * Para completarlo, cambia donde dice null, por la sentencia y el validator se fija si esta bien lo que hiciste
             * NO mires el validator pq ahi esta como se hace la idea es que lo saques vos
             */
            //Trae el usuario que se llama Marcos (tene en cuenta que es case sensitive).            
            User practica1 = null;
            Console.WriteLine(validator.Mensaje("Practica 1", validator.Validar1(practica1, UserList)));
            
            //Trae Todos los usuarios que sean administrador            
            List<User> practica2 = null;
            Console.WriteLine(validator.Mensaje("Practica 2", validator.Validar2(practica2, UserList)));
            
            //Traer todos los productos con precios mayor a 50$
            List<Product> practica3 = null;
            Console.WriteLine(validator.Mensaje("Practica 3", validator.Validar3(practica3, ProductList)));
            
            //Traer todos los productos con stock menores a 20
            List<Product> practica4 = null;
            Console.WriteLine(validator.Mensaje("Practica 4", validator.Validar4(practica4, ProductList)));
            
            //Contar cuantos usuarios hay de tipo Administrador
            int practica5 = 0;
            Console.WriteLine(validator.Mensaje("Practica 5", validator.Validar5(practica5, UserList)));
            
            //Contar cuantos usuarios hay de tipo Usuario
            int practica6 = 0;
            Console.WriteLine(validator.Mensaje("Practica 6", validator.Validar6(practica6, UserList)));
            
            //Fin del programa.
            Console.ReadLine();
        }
    }
}
