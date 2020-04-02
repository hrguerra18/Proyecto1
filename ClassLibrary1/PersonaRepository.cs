using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class PersonaRepository
    {
        private string ruta = "persona.Txt";

        public void Guardar(Persona persona)
        {
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine();
            escritor.Write($"{persona.Identificacion};{persona.Nombre};{persona.Sexo};{persona.Edad};{persona.Pulsacion}");
            escritor.Close();
            file.Close();
        }

        public List<Persona> Consultar()
        {
            List<Persona> personas = new List<Persona>();

            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader escritor = new StreamReader(file);

            string Linea = string.Empty;
            Linea = escritor.ReadLine();

            while ((Linea = escritor.ReadLine()) != null)
            {
                Persona persona = new Persona();
                persona = Map(Linea);

                personas.Add(persona);
            }

            escritor.Close();
            file.Close();

            return personas;
        }

        public void Eliminar (string Identifiacion)
        {
            List<Persona> personas = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();

            foreach (var item in personas)
            {

                if (Identifiacion != item.Identificacion)
                {
                    Guardar(item);
                }
                
            }
        }

        public void Modificar(string Identificacion, Persona PersonaNueva)
        {
            List<Persona> personas = Consultar();
            FileStream file = new FileStream(ruta, FileMode.Create);
            file.Close();

            foreach (var item in personas)
            {
                if (Identificacion.Equals(item.Identificacion))
                {
                    Guardar(PersonaNueva);
                }
                else
                {
                    Guardar(item);
                }
            }
        }

        public Persona Buscar(string Identificacion)
        {
            List<Persona> personas = new List<Persona>();
            personas = Consultar();
            Persona persona = new Persona();
            foreach (var item in personas)
            {
                if (item.Identificacion.Equals(Identificacion))
                {
                    return item;
                }
            }
            return null;
        }

        public Persona Map(string linea)
        {
            Persona persona = new Persona();
            char delimiter = ';';
            string[] MatrizPersona = linea.Split(delimiter);
            persona.Identificacion = MatrizPersona[0];
            persona.Nombre = MatrizPersona[1];
            persona.Sexo = MatrizPersona[2];
            persona.Edad = Convert.ToInt32(MatrizPersona[3]);
            
            persona.Pulsacion = Convert.ToInt32(MatrizPersona[4]);

            return persona;

        }

    }
} 

