using System;
using System.Collections.Generic;
using System.Linq;


public abstract class Contenedor
{
    public int Peso { get; set; }

    public Contenedor(int peso)
    {
        Peso = peso;
    }

    public override string ToString()
    {
        return $"Peso: {Peso}";
    }
}

public class ContenedorNormal : Contenedor
{
    public ContenedorNormal(int peso) : base(peso)
    {
    }

    public override string ToString()
    {
        return $"Contenedor Normal, {base.ToString()}";
    }
}

public class ContenedorSeguridad : Contenedor
{
    public bool Alarma { get; set; }

    public ContenedorSeguridad(int peso) : base(peso)
    {
    }

    public override string ToString()
    {
           return $"Contenedor Seguridad, Alarma: {Alarma}, {base.ToString()}";
    }
}

public class ContenedorTemperatura : Contenedor
{
    public int Temperatura { get; set; }

    public ContenedorTemperatura(int peso) : base(peso)
    {
    }

    public override string ToString()
    {
        return $"Contenedor Refrigerado, Temperatura: {Temperatura}, {base.ToString()}";
    }
}

public interface IShow
{
    void MostrarContenedores();
}

public class PilaContenedores
{
    public Stack<Contenedor> Contenedores { get; set; } = new Stack<Contenedor>();
    public string Nombre { get; set; } = string.Empty;
    public int PesoPila { get; set; }

    public PilaContenedores(string nombre, int pesoPila)
    {
        Nombre = nombre;
        PesoPila = pesoPila;
    }

    public void AgregarContenedor(Contenedor contenedor) // Agregar contenedor a la pila
    {
        Contenedores.Push(contenedor); // Agregar contenedor a la pila
        PesoPila += contenedor.Peso;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, PesoPila: {PesoPila}";
    }
}


public class ColaCamiones
{
    public Queue<Camion> Camiones { get; set; } = new Queue<Camion>();
    public string Nombre { get; set; } = string.Empty;

    public ColaCamiones(string nombre)
    {
        Nombre = nombre;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}";
    }
}


public class Barco
{
    public PilaContenedores[] PilasContenedores { get; set; }

    public Barco(PilaContenedores[] pilasContenedores)
    {
        PilasContenedores = pilasContenedores;
    }
}

public class Camion : IShow
{
    public List<Contenedor> Contenedores { get; set; } // Contenedores en el camión
    public int NumMaximoContenedores { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public Camion(List<Contenedor> contenedores, int numMaximoContenedores, string nombre)
    {
        Contenedores = contenedores;
        NumMaximoContenedores = numMaximoContenedores;
        Nombre = nombre;
    }

    public void MostrarContenedores()
    {
        foreach (var contenedor in Contenedores)
        {
            if (contenedor is ContenedorNormal)
            {
                Console.WriteLine($"    Tipo: ContenedorNormal, Peso: {contenedor.Peso}");
            }
            else if (contenedor is ContenedorSeguridad)
            {
                Console.WriteLine($"    Tipo: ContenedorSeguridad, Alarma: {((ContenedorSeguridad)contenedor).Alarma}, Peso: {contenedor.Peso}");
            }
            else if (contenedor is ContenedorTemperatura)
            {
                Console.WriteLine($"    Tipo: ContenedorRefrigerado, Temperatura: {((ContenedorTemperatura)contenedor).Temperatura}, Peso: {contenedor.Peso}");
            }
        }
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, NumMaximoContenedores: {NumMaximoContenedores}";
    }
}


public class Program
{
    static void Main(string[] args)
    {
        Barco barco = new Barco(new PilaContenedores[5]);

        for (int i = 0; i < 5; i++)
        {
            barco.PilasContenedores[i] = new PilaContenedores($"Pila {i + 1}", 0);

        }

        /*
        // Agregar contenedores
        barco.PilasContenedores[0].Contenedores.Push(new ContenedorNormal(100));
        barco.PilasContenedores[0].Contenedores.Push(new ContenedorNormal(130));
        barco.PilasContenedores[1].Contenedores.Push(new ContenedorTemperatura (200));
        barco.PilasContenedores[2].Contenedores.Push(new ContenedorTemperatura (50));
        barco.PilasContenedores[2].Contenedores.Push(new ContenedorSeguridad (100));
        barco.PilasContenedores[2].Contenedores.Push(new ContenedorNormal (400));
        barco.PilasContenedores[3].Contenedores.Push(new ContenedorSeguridad (100));
        barco.PilasContenedores[4].Contenedores.Push(new ContenedorSeguridad (100));
        */

        barco.PilasContenedores[0].AgregarContenedor(new ContenedorNormal(100));
        barco.PilasContenedores[0].AgregarContenedor(new ContenedorNormal(130));
        barco.PilasContenedores[1].AgregarContenedor(new ContenedorTemperatura(200));
        barco.PilasContenedores[2].AgregarContenedor(new ContenedorTemperatura(50));
        barco.PilasContenedores[2].AgregarContenedor(new ContenedorSeguridad(100));
        barco.PilasContenedores[2].AgregarContenedor(new ContenedorNormal(400));
        barco.PilasContenedores[3].AgregarContenedor(new ContenedorSeguridad(100));
        barco.PilasContenedores[4].AgregarContenedor(new ContenedorSeguridad(100));

        ColaCamiones colaCamiones = new ColaCamiones("Cola de Camiones");


        for (int i = 0; i < 6; i++)
        {
            colaCamiones.Camiones.Enqueue(new Camion(new List<Contenedor>(), 2, "Nombre del camión"));
        }

        colaCamiones.Camiones.ElementAt(4).Contenedores.Add(new ContenedorNormal (100));
        colaCamiones.Camiones.ElementAt(5).Contenedores.Add(new ContenedorTemperatura (150));


        // Menú
        while (true)
        {
            Console.WriteLine("************ BARCO ********************");
            Console.WriteLine("1. Mostrar Contenedores");
            Console.WriteLine("2. Mostrar Contenedores Peso");
            Console.WriteLine("3. Activar Seguridad");
            Console.WriteLine("4. Activar Temperatura 7 grados");
            Console.WriteLine("5. Mostrar Contenedores Ordenados Peso Pila");
            Console.WriteLine("************* CAMIONES *******************");
            Console.WriteLine("6. Mostrar Cola Camiones");
            Console.WriteLine("************** OPERACIONES ******************");
            Console.WriteLine("7. Mostrar Pila de Contenedores Maxima");
            Console.WriteLine("8. Descargar Contenedores al primer Camión");
            Console.WriteLine("9. Mostrar Cola Camiones con contenedores");
            Console.WriteLine("10. Sacar camion de cola");
            Console.WriteLine("********************************");
            Console.WriteLine("11. Salir");
            Console.Write("Seleccione una opción: ");

            string input = Console.ReadLine();
            int opcion = input != null ? int.Parse(input) : 0;


            switch (opcion)
            {
                case 1:
                    // Mostrar Contenedores
                    MostrarContenedores(barco);
                    break;
                case 2:
                    // Mostrar Contenedores Peso
                    MostrarPesoContenedores(barco);
                    break;
                case 3:
                    // Activar Seguridad
                    ActivarSeguridad(barco);
                    break;
                case 4:
                    // Activar Temperatura 7 grados
                    ActivarTemperatura(barco);
                    break;
                case 5:
                    // Mostrar Contenedores Ordenados Peso Pila
                    MostrarContenedoresOrdenadosPeso(barco);
                    break;
                case 6:
                    // Mostrar Cola Camiones
                    MostrarColaCamiones(colaCamiones);
                    break;
                case 7:
                    // Mostrar Pila de Contenedores Maxima
                    MostrarPilaContenedoresMaxima(barco);
                    break;
                case 8:
                    // Descargar Contenedores al primer Camión
                    DescargarContenedores(barco, colaCamiones);
                    break;
                case 9:
                    // Mostrar Cola Camiones con contenedores
                    MostrarEstadoInicialCamiones(colaCamiones);
                    break;
                case 10:
                    // Sacar camion de cola
                    QuitarCamionCola(colaCamiones);
                    break;
                case 11:
                    // Salir
                    Console.WriteLine("Saliendo...");
                    return;
            }
        }

        static void MostrarContenedores(Barco barco)
        {
            for (int i = 0; i < barco.PilasContenedores.Length; i++)
            {
                Console.WriteLine($"Pila A{i}: Peso Pila: {barco.PilasContenedores[i].PesoPila}");
                foreach (var contenedor in barco.PilasContenedores[i].Contenedores)
                {
                    if (contenedor is ContenedorNormal)
                    {
                        Console.WriteLine($"     Tipo: ContenedorNormal Peso: {contenedor.Peso}");
                    }
                    else if (contenedor is ContenedorSeguridad)
                    {
                        Console.WriteLine($"     Tipo: ContenedorSeguridad Alarma: {((ContenedorSeguridad)contenedor).Alarma} Peso: {contenedor.Peso}");
                    }
                    else if (contenedor is ContenedorTemperatura)
                    {
                        Console.WriteLine($"     Tipo: ContenedorRefrigerado Temperatura: {((ContenedorTemperatura)contenedor).Temperatura} Peso: {contenedor.Peso}");
                    }
                }
            }
        }

        static void MostrarPesoContenedores(Barco barco)
        {
            for (int i = 0; i < barco.PilasContenedores.Length; i++)
            {
                Console.WriteLine($"Pila A{i}: Peso Pila: {barco.PilasContenedores[i].PesoPila}");
            }
        }

        static void ActivarSeguridad(Barco barco)
        {
            for (int i = 0; i < barco.PilasContenedores.Length; i++)
            {
                foreach (var contenedor in barco.PilasContenedores[i].Contenedores)
                {
                    if (contenedor is ContenedorSeguridad)
                    {
                        ((ContenedorSeguridad)contenedor).Alarma = true;
                    }
                }
            }
            Console.WriteLine("Seguridad activada.");
        }

        static void ActivarTemperatura(Barco barco)
        {
            for (int i = 0; i < barco.PilasContenedores.Length; i++)
            {
                foreach (var contenedor in barco.PilasContenedores[i].Contenedores)
                {
                    if (contenedor is ContenedorTemperatura)
                    {
                        ((ContenedorTemperatura)contenedor).Temperatura = 7;
                    }
                }
            }
            Console.WriteLine("Temperatura activada a 7 grados.");
        }

        static void MostrarContenedoresOrdenadosPeso(Barco barco)
        {
            var pilasOrdenadas = barco.PilasContenedores.OrderBy(pila => pila.PesoPila).ToArray(); // Ordenar las pilas por peso
            for (int i = 0; i < pilasOrdenadas.Length; i++)
            {
                Console.WriteLine($"Pila A{i}: Peso Pila: {pilasOrdenadas[i].PesoPila}");
                foreach (var contenedor in pilasOrdenadas[i].Contenedores)
                {
                    if (contenedor is ContenedorNormal)
                    {
                        Console.WriteLine($"     Tipo: ContenedorNormal Peso: {contenedor.Peso}");
                    }
                    else if (contenedor is ContenedorSeguridad)
                    {
                        Console.WriteLine($"     Tipo: ContenedorSeguridad Alarma: {((ContenedorSeguridad)contenedor).Alarma} Peso: {contenedor.Peso}");
                    }
                    else if (contenedor is ContenedorTemperatura)
                    {
                        Console.WriteLine($"     Tipo: ContenedorRefrigerado Temperatura: {((ContenedorTemperatura)contenedor).Temperatura} Peso: {contenedor.Peso}");
                    }
                }
            }
        }

        static void MostrarColaCamiones(ColaCamiones colaCamiones)
        {
            int i = 1;
            foreach (var camion in colaCamiones.Camiones)
            {
                Console.WriteLine($"Camion Camion {i++}:");
            }
        }

        static void MostrarPilaContenedoresMaxima(Barco barco)
        {
            var pilaMaxima = barco.PilasContenedores.OrderByDescending(pila => pila.PesoPila).First(); // Pila con el peso máximo
            int indice = Array.IndexOf(barco.PilasContenedores, pilaMaxima);
            Console.WriteLine($"Pila de Contenedores con Peso Máximo:");
            Console.WriteLine($"   Pila: A{indice}     Peso:  {pilaMaxima.PesoPila}:");
            foreach (var contenedor in pilaMaxima.Contenedores)
            {
                if (contenedor is ContenedorNormal)
                {
                    Console.WriteLine($"     Tipo: ContenedorNormal Peso: {contenedor.Peso}");
                }
                else if (contenedor is ContenedorSeguridad)
                {
                    Console.WriteLine($"     Tipo: ContenedorSeguridad Alarma: {((ContenedorSeguridad)contenedor).Alarma} Peso: {contenedor.Peso}");
                }
                else if (contenedor is ContenedorTemperatura)
                {
                    Console.WriteLine($"     Tipo: ContenedorRefrigerado Temperatura: {((ContenedorTemperatura)contenedor).Temperatura} Peso: {contenedor.Peso}");
                }
            }
        }

        static void DescargarContenedores(Barco barco, ColaCamiones colaCamiones)
        {
            // Estado inicial de los camiones
            Console.WriteLine("A. Estado inicial de los camiones, antes de descargar del barco ningún contenedor");
            MostrarEstadoCamiones(colaCamiones);

            // Estado inicial del barco
            Console.WriteLine("A. Estado Inicial del barco antes de descargar");
            MostrarContenedores(barco);

            // Primera descarga
            Console.WriteLine("B. Primera Descarga");
            DescargarContenedor(barco, colaCamiones);

            // Estado de los camiones después de la primera descarga
            Console.WriteLine("B. Estado de los camiones después de la primera descarga");
            MostrarEstadoCamiones(colaCamiones);

            // Segunda descarga
            Console.WriteLine("C. Segunda Descarga");
            DescargarContenedor(barco, colaCamiones);

            // Estado de los camiones después de la segunda descarga
            Console.WriteLine("C. Estado de los camiones después de la segunda descarga");
            MostrarEstadoCamiones(colaCamiones);

            // Tercera descarga
            Console.WriteLine("D. Tercera Descarga");
            DescargarContenedor(barco, colaCamiones);

            // Estado de los camiones después de la tercera descarga
            Console.WriteLine("D. Estado de los camiones después de la tercera descarga");
            MostrarEstadoCamiones(colaCamiones);

            // Estado del barco después de la tercera descarga
            Console.WriteLine("E. Estado del barco después de la tercera descarga");
            MostrarContenedores(barco);
        }

        static void DescargarContenedor(Barco barco, ColaCamiones colaCamiones)
        {
            // Comprobar si hay contenedores en el barco
            if (barco.PilasContenedores.Any(pila => pila.Contenedores.Count > 0))
            {
                // Seleccionar el primer contenedor de la primera pila con contenedores
                var pilaConContenedores = barco.PilasContenedores.First(pila => pila.Contenedores.Count > 0);
                var contenedor = pilaConContenedores.Contenedores.Pop();

                // Comprobar si hay camiones en la cola
                if (colaCamiones.Camiones.Count > 0)
                {
                    // Agregar el contenedor al primer camión en la cola
                    var camion = colaCamiones.Camiones.Peek();
                    if (camion.Contenedores.Count < camion.NumMaximoContenedores)
                    {
                        camion.Contenedores.Add(contenedor);
                        Console.WriteLine("Contenedor descargado del barco al camión.");
                    }
                    else
                    {
                        Console.WriteLine("El camión ya está lleno. No se puede descargar el contenedor.");
                    }
                }
                else
                {
                    Console.WriteLine("No hay camiones en la cola. No se puede descargar el contenedor.");
                }
            }
            else
            {
                Console.WriteLine("No hay contenedores en el barco para descargar.");
            }
        }

        static void MostrarEstadoCamiones(ColaCamiones colaCamiones)
        {
            int i = 1;
            foreach (var camion in colaCamiones.Camiones) 
            {
                Console.WriteLine($"Camion {i} Peso Contenedores :{camion.Contenedores.Sum(contenedor => contenedor.Peso)}"); // Suma de los pesos de los contenedores
                foreach (var contenedor in camion.Contenedores)
                {
                    if (contenedor is ContenedorNormal)
                    {
                        Console.WriteLine($"    Tipo: ContenedorNormal, Peso: {contenedor.Peso}");
                    }
                    else if (contenedor is ContenedorSeguridad)
                    {
                        Console.WriteLine($"    Tipo: ContenedorSeguridad, Alarma: {((ContenedorSeguridad)contenedor).Alarma}, Peso: {contenedor.Peso}");
                    }
                    else if (contenedor is ContenedorTemperatura)
                    {
                        Console.WriteLine($"    Tipo: ContenedorRefrigerado, Temperatura: {((ContenedorTemperatura)contenedor).Temperatura}, Peso: {contenedor.Peso}");
                    }
                }
                i++;
            }
        }

        static void MostrarEstadoInicialCamiones(ColaCamiones colaCamiones)
        {
            int i = 1;
            foreach (var camion in colaCamiones.Camiones)
            {
                int pesoTotalContenedores = camion.Contenedores.Sum(contenedor => contenedor.Peso); // Suma de los pesos de los contenedores
                Console.WriteLine($"Camion {i} Peso Contenedores :{pesoTotalContenedores}");
                foreach (var contenedor in camion.Contenedores)
                {
                    if (contenedor is ContenedorNormal)
                    {
                        Console.WriteLine($"    Tipo: ContenedorNormal, Peso: {contenedor.Peso}");
                    }
                    else if (contenedor is ContenedorSeguridad)
                    {
                        Console.WriteLine($"    Tipo: ContenedorSeguridad, Alarma: {((ContenedorSeguridad)contenedor).Alarma}, Peso: {contenedor.Peso}");
                    }
                    else if (contenedor is ContenedorTemperatura)
                    {
                        Console.WriteLine($"    Tipo: ContenedorRefrigerado, Temperatura: {((ContenedorTemperatura)contenedor).Temperatura}, Peso: {contenedor.Peso}");
                    }
                }
                i++;
            }
        }

        static void QuitarCamionCola(ColaCamiones colaCamiones)
        {
            var camionQuitado = colaCamiones.Camiones.Dequeue(); // Sacar el primer camión de la cola
            Console.WriteLine($"Se quitó el {camionQuitado.Nombre} de la cola.");
        }
    }
}
