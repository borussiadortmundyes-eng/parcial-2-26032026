// See https://aka.ms/new-console-template for more information
using System.Timers;

Dictionary<int, Equipo> equipos = new Dictionary<int, Equipo>();
int opcion;
int id = 0;
do
{
    Console.Clear();
    Console.WriteLine("bienenido a Udeo");
    Console.WriteLine("1) Registrar equipo");
    Console.WriteLine("2) Modificar equipo");
    Console.WriteLine("3) Eliminar equipo");
    Console.WriteLine("4) Buscar equipo");
    Console.WriteLine("5) Mostrar todos los equipos");
    Console.WriteLine("6) Registrar prestamo");
    Console.WriteLine("7) Registrar devolucion");
    Console.WriteLine("8) Mostrar resumen general");
    Console.WriteLine("9) Mostrar equipos por estado");
    Console.WriteLine("10) Mostrar euipos por tipo");
    Console.WriteLine("11) Salir");
    opcion = int.Parse(Console.ReadLine());
    switch(opcion)
    {
        case 1:
            Console.WriteLine("escriba el Id del equipo que desee agregar a la existencia");
            id = int.Parse(Console.ReadLine());
            if (equipos.ContainsKey(id))
            {   Console.WriteLine("El codigo ya existe");
             
            }
            else { 
                Equipo E = new Equipo();
            E.Codigo = id;
            Console.WriteLine("Esciba nombre del equipo:"); E.NombreEquipo = Console.ReadLine();
            Console.WriteLine("Esciba Tipo del equipo:\r\nLaptop\r\nProyector\r\nBocina\r\nTablet"); E.TipoDeEquipo = Console.ReadLine();
                Console.WriteLine("Esciba costo del equipo por hora: Q "); E.Costo =double.Parse( Console.ReadLine());
                Console.WriteLine("Esciba el estado del equipo:\r\ndisponible\r\nprestado\r\nmantenimiento"); E.EstadoDelEquipo = Console.ReadLine();
                Console.WriteLine("Esciba el monto del recargo del equipo: \r\nLaptop: Q15\r\nProyector: Q20\r\nBocina: Q10\r\nTablet: Q12:"); E.Recargo =double.Parse( Console.ReadLine());
                equipos.Add(id, E);
            }

            Console.ReadKey();
            break;
            case 2:
            Console.WriteLine("Modificar equipo");
            Console.WriteLine("escriba el Id del equipo que desee modificar");
            id = int.Parse(Console.ReadLine());
            if (equipos.ContainsKey(id))
            {
                Equipo N = new Equipo();
                N.Codigo = id;
                Console.Write("Ingrese nuevo nombre del equipo: ");
                N.NombreEquipo = Console.ReadLine();
                Console.Write("Esciba Nuevo Tipo del equipo:\r\nLaptop\r\nProyector\r\nBocina\r\nTablet");
                N.TipoDeEquipo = Console.ReadLine();
                Console.Write("Esciba Nuevo costo del equipo por hora: Q ");
                double costo = double.Parse (Console.ReadLine());
                if (costo > 0) {
                    N.Costo = costo;
                } else {
                    Console.WriteLine("no se puede agregar un costo negativo");
                    Console.WriteLine("esciba de nuevo el costo del equipo por hora: Q");
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("Esciba Nuevo estado del equipo:\r\ndisponible\r\nprestado\r\nmantenimiento"); N.EstadoDelEquipo = Console.ReadLine();
        
                equipos[id] = (N);
               
                Console.WriteLine("se ha cambiado correctamente");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("El codigo no existe");

            }

            break;
        case 3:
            Console.WriteLine("Eliminar equipo");
            Console.WriteLine("escriba el Id del equipo que desee modificar");
            id = int.Parse(Console.ReadLine());
            if ( equipos.ContainsKey(id))
            {
                if (equipos[id].EstadoDelEquipo == "prestado") { Console.WriteLine("El dispositivo no se puede dar de baja ya que se encuentra en prestamo"); }
                else {
                    Console.WriteLine("Seguro que desea eliminar este equipoo? (si/no)");
                    string opcioneliminar = Console.ReadLine();
                    if (opcioneliminar == "si")
                    {
                        equipos.Remove(id);
                        Console.WriteLine("estudiante eliminado");
                        Console.ReadKey();
                    }
                    else { Console.WriteLine("estudiante no eliminado"); }
                }
            }else
            {
                Console.WriteLine("el equipo no existe en el inventario");
            }
            break;
        case 4:
            Console.Write("Ingrese clave  del equipo a buscar: ");
            id = int.Parse(Console.ReadLine());
            if (equipos.ContainsKey(id))
            {
                equipos[id].Datos();

                Console.ReadKey();
                break;
            }
            else
            {
                Console.WriteLine("ID no encontrado... pruebe de nuevo");
            }
            Console.ReadKey();
            break;
        case 5:
            Console.WriteLine("ustes ha escogido la opcion de mostrar todos los equipos");
            foreach (var kvp in equipos) { kvp.Value.Datos(); }
            Console.ReadKey();
            
            break;
        case 6:
            Console.WriteLine("Registrar Prestamo");
            Console.WriteLine("escriba el Id del equipo que desee registrar prestamo");
            id = int.Parse(Console.ReadLine());
            if (equipos.ContainsKey(id))
            {
                if (equipos[id].EstadoDelEquipo == "disponible") {
                    Console.WriteLine("ingrese la cantidad de horas que desee prestar");
                    double cantidadhorasprestamo=double.Parse(Console.ReadLine());
                    if (cantidadhorasprestamo > 0)
                    {
                        equipos[id].Horasprestadas = cantidadhorasprestamo;
                        Console.WriteLine($"prestamo exitoso, el dispositivo prestado fue: ");
                        equipos[id].EstadoDelEquipo = "prestado";
                        equipos[id].Datos();
                        Console.WriteLine($"el subtotal es de : Q{equipos[id].TotalApagar():F2}");
                        Console.WriteLine($"el recargo fue de: Q{equipos[id].Recargo:F2}");
                    }
                } else { Console.WriteLine($"el equipo no se puede prestar esta en : {equipos[id].EstadoDelEquipo}"); }

            }
            else
            {
                Console.WriteLine("El codigo no existe existe");
               
            }
            break;
        case 7:
            Console.WriteLine("escriba el Id del equipo que desee registrar devolucion");
            id = int.Parse(Console.ReadLine());
            if (equipos.ContainsKey(id))
            {
                if (equipos[id].EstadoDelEquipo == "prestado")
                {
                    equipos[id].Horasprestadas -= equipos[id].Horasprestadas;
                        Console.WriteLine($"Se ha registrado la devolucion del equipo: ");
                        equipos[id].EstadoDelEquipo = "disponible";
                        equipos[id].Datos();
                        Console.WriteLine($"el subtotal a pagar es de : Q{equipos[id].TotalApagar():F2}");
                        Console.WriteLine($"el recargo fue de: Q{equipos[id].Recargo:F2}");
                    
                }
                else { Console.WriteLine($"el equipo no se puede devolver esta en : {equipos[id].EstadoDelEquipo}"); }

            }
            else
            {
                Console.WriteLine("El codigo no existe existe");

            }
            break;
        case 8:
            break;
        case 9:
            break;
        case 10:
            break;
        case 11:
            Console.WriteLine("saliendo del program...");
            Console.ReadKey();
            break;
        default:
            Console.WriteLine("opcion invalida... intente de nuevo");
            break;

    }
} while (opcion != 11);
   
class Equipo
{
    public double Codigo;
    public string NombreEquipo;
    public string TipoDeEquipo;
    public double Costo;
    public double Horasprestadas;
    public string EstadoDelEquipo;
    public double Recargo;
    public void Datos()
    {
        Console.WriteLine($"Datos del equipo:| Clave {Codigo}| Nombre del equipo: {NombreEquipo}| Tipo del Equipo: {TipoDeEquipo}| Costo por hora del equipo Q{Costo}| Horas prestadas del equipo| {Horasprestadas}| Estado del equipo: {EstadoDelEquipo}");
    }
  
    public double TotalApagar()
    {
        return (Horasprestadas * Costo)+ Recargo;
    }
}

