using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace caso_semana7

{

    internal class Program

    {

       

        static string[] nombres;

        static double[] notas;

        static int contador = 0;


        static void Titulo()

        {

            Console.WriteLine("****************************");

            Console.WriteLine("Sistema de notas");

            Console.WriteLine("****************************");

        }


        static void Pausa()

        {

            Console.WriteLine("\nPresiona una tecla para continuar...");

            Console.ReadKey();

        }


        // Lee una nota válida [0-20]

        static double LeerNota(string mensaje)

        {

            double nota;

            while (true)

            {

                Console.Write(mensaje);

                if (double.TryParse(Console.ReadLine(), out nota))

                {

                    if (nota >= 0 && nota <= 20)

                        return nota;

                    Console.WriteLine("Error: La nota debe estar entre 0 y 20.");

                }

                else

                {

                    Console.WriteLine("Error: Ingresa un valor numérico.");

                }

            }

        }


        static void Registrar_estudiante()

        {

            Console.WriteLine("Registro de estudiante nuevo: ");

            

            Console.Write("Ingresar nombre: ");

            string nombre = Console.ReadLine().Trim();

            if (nombre == "")

            {

                Console.WriteLine("El nombre no puede estar vacío");

                return;

            }

            double nota = LeerNota("Ingresar nota: ");


            nombres[contador] = nombre;

            notas[contador] = nota;

            contador++;

            Console.WriteLine("Estudiante registrado.");

        }


        static void MostrarArreglos(string[] n, double[] nt)

        {

            for (int i = 0; i < contador; i++)

            {

                Console.WriteLine((i + 1) + ".- " + n[i] + " - Nota: " + nt[i]);

            }

        }


        static void mostrar()

        {

            Console.WriteLine("******* Listado de Estudiantes *********");

            if (contador == 0)

            {

                Console.WriteLine("No hay datos por mostrar");

                return;

            }

            MostrarArreglos(nombres, notas);

        }


        static void buscar_estudiante()

        {

            Console.WriteLine("********** Buscar Estudiante **********");

            if (contador == 0)

            {

                Console.WriteLine("No hay estudiantes registrados");

                return;

            }

            Console.Write("Ingresar nombre a buscar: ");

            string nom_buscar = Console.ReadLine().Trim().ToLower();

            bool encontrado = false;

            for (int i = 0; i < contador; i++)

            {

                if (nombres[i].ToLower() == nom_buscar)

                {

                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);

                    encontrado = true;

                    break;

                }

            }

            if (!encontrado)

            {

                Console.WriteLine("Estudiante no encontrado");

            }

        }


        static void modificar_estudiante()

        {

            Console.WriteLine("********** Modificar Estudiante **********");

            if (contador == 0)

            {

                Console.WriteLine("No hay estudiantes registrados");

                return;

            }

            Console.Write("Ingresar nombre de estudiante: ");

            string nombre_buscar = Console.ReadLine().Trim().ToLower();

            for (int i = 0; i < contador; i++)

            {

                if (nombres[i].ToLower() == nombre_buscar)

                {

                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);

                    notas[i] = LeerNota("Ingresar la nueva nota: ");

                    Console.WriteLine("Nota modificada.....");

                    return;

                }

            }

            Console.WriteLine("Estudiante no encontrado");

        }


        // Copia los arreglos para ordenar sin alterar el orden original

        static void CopiarDatos(out string[] n, out double[] nt)

        {

            n = new string[contador];

            nt = new double[contador];

            Array.Copy(nombres, n, contador);

            Array.Copy(notas, nt, contador);

        }


        static void burbuja()

        {

            Console.WriteLine("********* Orden burbuja (ascendente) ***************");

            if (contador == 0)

            {

                Console.WriteLine("No hay datos por mostrar");

                return;

            }

            CopiarDatos(out string[] n, out double[] nt);


            for (int i = 0; i < contador - 1; i++)

            {

                for (int j = 0; j < contador - i - 1; j++)

                {

                    if (nt[j] > nt[j + 1])

                    {

                        double tempNota = nt[j];

                        nt[j] = nt[j + 1];

                        nt[j + 1] = tempNota;


                        string tempNombre = n[j];

                        n[j] = n[j + 1];

                        n[j + 1] = tempNombre;

                    }

                }

            }

            MostrarArreglos(n, nt);

        }


        static void seleccionDesc()

        {

            Console.WriteLine("********* Orden selección (descendente) ***************");

            if (contador == 0)

            {

                Console.WriteLine("No hay datos por mostrar");

                return;

            }

            CopiarDatos(out string[] n, out double[] nt);


            for (int i = 0; i < contador - 1; i++)

            {

                int posMax = i;

                for (int j = i + 1; j < contador; j++)

                {

                    if (nt[j] > nt[posMax])

                        posMax = j;

                }

                if (posMax != i)

                {

                    double tempNota = nt[i];

                    nt[i] = nt[posMax];

                    nt[posMax] = tempNota;


                    string tempNombre = n[i];

                    n[i] = n[posMax];

                    n[posMax] = tempNombre;

                }

            }

            MostrarArreglos(n, nt);

        }


        static void promedioYMaxima()

        {

            Console.WriteLine("********* Promedio y nota máxima ***************");

            if (contador == 0)

            {

                Console.WriteLine("No hay datos por mostrar");

                return;

            }

            double suma = 0;

            int posMax = 0;

            for (int i = 0; i < contador; i++)

            {

                suma += notas[i];

                if (notas[i] > notas[posMax])

                    posMax = i;

            }

            Console.WriteLine("Promedio: " + Math.Round(suma / contador, 2));

            Console.WriteLine("Nota máxima: " + notas[posMax] + " (" + nombres[posMax] + ")");

        }


        static void Main(string[] args)

        {

            int opc = 0;

            while (opc != 8)

            {

                Console.Clear();

                Titulo();

                Console.WriteLine("***** MENU PRINCIPAL ********");

                Console.WriteLine("[1] Registrar estudiante");

                Console.WriteLine("[2] Buscar estudiante");

                Console.WriteLine("[3] Modificar nota");

                Console.WriteLine("[4] Mostrar lista sin ordenar");

                Console.WriteLine("[5] Mostrar reporte ordenado por burbuja");

                Console.WriteLine("[6] Mostrar por selección DESC");

                Console.WriteLine("[7] Promedio y nota máxima");

                Console.WriteLine("[8] Salir");

                Console.Write("Ingresar opción: ");


                if (!int.TryParse(Console.ReadLine(), out opc))

                {

                    Console.WriteLine("Error, ingresa un valor numérico");

                    opc = 0;

                    Pausa();

                    continue;

                }


                Console.Clear();

                switch (opc)

                {

                    case 1: Registrar_estudiante(); break;

                    case 2: buscar_estudiante(); break;

                    case 3: modificar_estudiante(); break;

                    case 4: mostrar(); break;

                    case 5: burbuja(); break;

                    case 6: seleccionDesc(); break;

                    case 7: promedioYMaxima(); break;

                    case 8: Console.WriteLine("Gracias por usar el sistema"); break;

                    default: Console.WriteLine("Opción incorrecta..!!"); break;

                }

                if (opc != 8) Pausa();

            }

        }

    }

}