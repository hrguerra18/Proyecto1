using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;
namespace Pulsaciones
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>();
            PersonaService personaService = new PersonaService();
            Persona persona = new Persona();
            string Identificacion;

            int Opcion=0;

            do
            {
                
                Console.WriteLine("================ MENU ===============");
                Console.WriteLine("1. Guardar");
                Console.WriteLine("2. Consultar");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Modificar");
                Console.WriteLine("5. Salir");

                Console.WriteLine("\nQUE OPCION DESEA HACER...");

                Opcion = Convert.ToInt32(Console.ReadLine());

                switch (Opcion)
                {
                    case 1:
                        string Seguir;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Ingrese su Identificacion: ");
                            persona.Identificacion = Console.ReadLine();
                            Console.WriteLine("Ingrese su Nombre: ");
                            persona.Nombre = Console.ReadLine();
                            Console.WriteLine("Ingrese su Edad: ");
                            persona.Edad = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese su sexo[f/m]: ");
                            persona.Sexo = Console.ReadLine();

                          
                            personaService.CalcularPulsacion(persona);
                            Console.WriteLine($"Su pulsacion es de: {persona.Pulsacion} ");
                            personaService.Guardar(persona);

                            Console.WriteLine("DESEA SEGUIR INGRESANDO DATOS??? ");
                            Seguir = Console.ReadLine();

                            Console.ReadKey();

                        } while (Seguir.ToUpper().Equals("S"));
                        break;

                    case 2:
                        Console.Clear();
                        personas = personaService.Consultar();
                        foreach (var item in personas)
                        {
                            
                          Console.WriteLine($"Identificacion: {item.Identificacion} -- Nombre: {item.Nombre} -- Sexo: {item.Sexo} --" +
                          $" Edad: {item.Edad} -- Pulsaciones: {item.Pulsacion}");

                        }
                        
                        Console.WriteLine("");
                        
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Digite la Identificacion a eliminar");
                        Identificacion = Console.ReadLine();
                        string respuesta = personaService.Eliminar(Identificacion);

                        Console.WriteLine(respuesta);
                        break;

                    case 4:
                        Persona PersonaNueva = new Persona();
                        Console.WriteLine("Digite la Identificacion que desea modificar");
                        Identificacion = Console.ReadLine();
                        PersonaNueva.Identificacion = Identificacion;
                        Console.WriteLine("Digite el nombre:");
                        PersonaNueva.Nombre = Console.ReadLine();
                        Console.WriteLine("Digite el edad:");
                        PersonaNueva.Edad = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite el sexo:");
                        PersonaNueva.Sexo = Console.ReadLine();
                        personaService.CalcularPulsacion(PersonaNueva);
                        Console.WriteLine($"Su pulsacion es de: {PersonaNueva.Pulsacion} ");

                        personaService.Modificar(Identificacion,PersonaNueva);
                    
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.WriteLine("\nGracias por utilizar el programa!");
                        Console.ReadKey();
                        break;


                    default: Console.WriteLine( $"Esa {Opcion} no es valida");
                        break;
                }
            } while (Opcion != 5);


            Console.ReadKey();
        }
    }
}
