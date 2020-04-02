
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL
{
    public class PersonaService
    {

        private PersonaRepository personaRepository;
        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }


        public void CalcularPulsacion(Persona persona)
        {
            
                if (persona.Sexo.Equals("f"))
                {
                    persona.Pulsacion = (220 - persona.Edad) / 10;

                }
                else if (persona.Sexo.Equals("m"))
                {
                    persona.Pulsacion = (210 - persona.Edad) / 10;

                }
                

        }

        public void Guardar(Persona persona)
        {
            if (personaRepository.Buscar(persona.Identificacion) == null)
            {
                personaRepository.Guardar(persona);
                Console.WriteLine( $"\nLos datos han sido guardados satisfactoriamente");
            }
            else
            {
                Console.WriteLine($"\nLa persona con Identificacion {persona.Identificacion} ya se encuentra registrada....");
            }
            
        }

        public List<Persona> Consultar()
        {
         
            return personaRepository.Consultar();
            
        }

        public string Eliminar(string Identificacion)
        {
            if (personaRepository.Buscar(Identificacion) != null)
            {
                personaRepository.Eliminar(Identificacion);
                return $"\nLa persona se ha eliminado correctamente";
            }
            return $"\nLa persona con identificacion {Identificacion} no se encuentra registrada";
        }

        public string Modificar(string Identificacion, Persona PersonaNueva) 
        {
            if (personaRepository.Buscar(Identificacion)!= null)
            {
                personaRepository.Modificar(Identificacion, PersonaNueva);
                return $"La persona se ha modificado correctamente";
            }

            return $"La persona con Identificacion {Identificacion} no se encuentra registrada";
        }
    }
}
