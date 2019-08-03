using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.BL
{
    public class PacientesBL
    {
        public BindingList<Paciente> ListaPacientes { get; set; } //BindingList nos permite crear una lista de pacientes
                                                                  // entre <> se puede poner el tipo de clase
        public PacientesBL() //ctor + 2 tab = creacion de construnctor //El () es el constructor
        {
            ListaPacientes = new BindingList<Paciente>();

            var paciente1 = new Paciente();
            paciente1.Id = 1;
            paciente1.Nombre = "Fidelio";
            paciente1.Sexo = "Masculino";
            paciente1.Edad = 30;
            paciente1.Peso = 150.00;
            paciente1.Talla = 180.00;
            paciente1.Activo = true;

            ListaPacientes.Add(paciente1);

            var paciente2 = new Paciente();
            paciente2.Id = 2;
            paciente2.Nombre = "Anastasia";
            paciente2.Sexo = "Femenino";
            paciente2.Edad = 25;
            paciente2.Peso = 90.00;
            paciente2.Talla = 160.00;
            paciente2.Activo = true;

            ListaPacientes.Add(paciente2);

            var paciente3 = new Paciente();
            paciente3.Id = 3;
            paciente3.Nombre = "Marcos";
            paciente3.Sexo = "Masculino";
            paciente3.Edad = 60;
            paciente3.Peso = 160.00;
            paciente3.Talla = 190.00;
            paciente3.Activo = true;

            ListaPacientes.Add(paciente3);


        }

        public BindingList<Paciente> ObtenerPacientes()
        {
            return ListaPacientes;
        }

        public Resultado GuardarPaciente(Paciente paciente) //para guardar paciente como parametro
        {
            var resultado = Validar(paciente); //Validacion desde la Funcion Resultado / Validar
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            if (paciente.Id == 0) //Siempre el identificador de un nuevo Paciente es 0 para el ID
            {
                paciente.Id = ListaPacientes.Max(item => item.Id) + 1; //Funcion de busqueda del maximo item y le suma 1 para un nuevo registro
            }

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarPaciente() //Funcion para agregar pacientes a la lista
        {
            var nuevoPaciente = new Paciente(); //Intancia de variable

            ListaPacientes.Add(nuevoPaciente); //Agregar a la lista
        }

        public bool ElimiarPaciente(int id) //Funcion para Eliminar Pacientes de la lista
        {
            foreach (var paciente in ListaPacientes) //forech -  para recorrer listas de objetos
            {
                if (paciente.Id == id) //definir si es el ID que deseamos eliminar
                {
                    ListaPacientes.Remove(paciente);
                    return true;
                }
            }

            return false;
        }

        private Resultado Validar(Paciente paciente)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;


            if (string.IsNullOrEmpty(paciente.Nombre) == true)
            {
                resultado.Mensaje = "Ingrese Nombre del Paciente";
                resultado.Exitoso = false;
            }
            else {
                if (paciente.Edad < 1)
                {
                    resultado.Mensaje = "Edad Incorrecta";
                    resultado.Exitoso = false;
                }
                else
                {
                    if (string.IsNullOrEmpty(paciente.Sexo) == true)
                    {
                        resultado.Mensaje = "Ingrese Sexo del Paciente";
                        resultado.Exitoso = false;
                    }
                }
            }
           
            return resultado;
        }
    }

    public class Paciente //Propiedades de Paciente
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public int Edad { get; set; }
        public String Sexo { get; set; }
        public double Talla { get; set; }
        public double Peso { get; set; }
        public bool Activo { get; set; }

    }

    public class Resultado //Clase de tipo reseultado con propiedades
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
    }

}
