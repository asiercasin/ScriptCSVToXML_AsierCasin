using System.IO;
using System.Threading.Tasks.Dataflow;

string carpetaBase = ("2.1");
string rutaArchivo="";
string archivo= "";
int caso= 0;

bool existiaAntes = Directory.Exists(carpetaBase);

try{
    if (existiaAntes)
    {
        Console.WriteLine($"La carpeta ya existía: {carpetaBase}");
    }
    else
    {
        Console.WriteLine($"Carpeta creada: {carpetaBase}");
        DirectoryInfo carpeta = Directory.CreateDirectory(carpetaBase);

    }
} catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

do{

    Console.WriteLine("1. Crear un nuevo fichero con el nombre que el usuario le pase por consola.");
    Console.WriteLine("2. Añadir registros en el fichero.");
    Console.WriteLine("3. Eliminar todos los registros del fichero.");
    Console.WriteLine("4. Eliminar el fichero.");
    Console.WriteLine("5. Visualizar los registros.");
    Console.WriteLine("6. Cerrar la aplicación.");
    caso = int.Parse(Console.ReadLine()!);



    switch (caso)
    {
        case 1:
            Console.WriteLine("Escriba el nombre del archivo");
            archivo= Console.ReadLine()!;
            rutaArchivo = Path.Combine(carpetaBase, archivo);

            try{
                if (File.Exists(rutaArchivo))
                {
                    Console.WriteLine("El archivo ya existía: no se vuelve a crear.");
                }
                else
                {
                    using (FileStream arch = File.Create(rutaArchivo)) { }
                    Console.WriteLine("Archivo creado exitosamente.");
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Thread.Sleep(1000);
            Console.Clear();
            break;
        case 2:
            Console.WriteLine("Escriba el nombre del archivo");
            archivo= Console.ReadLine()!;
            rutaArchivo = Path.Combine(carpetaBase, archivo);
            string texto = "";

            if (File.Exists(rutaArchivo))
                {
                    while (texto != "0"){
                        Console.WriteLine("Introduce el texto");
                        texto=Console.ReadLine()!;
                        if(texto!="0"){
                            using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
                            {
                                sw.WriteLine(texto);
                            }
                            Console.WriteLine("Para salir escriba 0");
                        } 
                    }
                }
                else
                {
                    
                    Console.WriteLine("El archivo ya existía");
                }

            Thread.Sleep(1000);
            Console.Clear();
            break;
        case 3:
            Console.WriteLine("Escriba el nombre del archivo");
            archivo= Console.ReadLine()!;
            rutaArchivo = Path.Combine(carpetaBase, archivo);

            File.WriteAllText(rutaArchivo,string.Empty);
            
            Thread.Sleep(1000);
            Console.Clear();
            break;
        case 4:
            Console.WriteLine("Escriba el nombre del archivo");
            archivo= Console.ReadLine()!;
            rutaArchivo = Path.Combine(carpetaBase, archivo); 

                if (File.Exists(rutaArchivo))
                {
                    try
                    {
                        File.Delete(rutaArchivo);
                        Console.Out.WriteLine("Fichero eliminado con éxito.");
                    }
                    catch (IOException ex)
                    {
                        Console.Out.WriteLine(ex.Message);
                    }
                }
                else
                {
                    
                    Console.WriteLine("El archivo ya existía");
                }

            Thread.Sleep(1000);
            Console.Clear();
            break;
        case 5:
            Console.WriteLine("Escriba el nombre del archivo");
            archivo= Console.ReadLine()!;
            rutaArchivo = Path.Combine(carpetaBase, archivo);

            if (File.Exists(rutaArchivo))
                {
                    string[] lineas = File.ReadAllLines(rutaArchivo);
                    foreach (string line in lineas)
                    {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine("\n");
                }
                else
                {
                    
                    Console.WriteLine("El archivo ya existía");
                }
            Thread.Sleep(3000);
            Console.Clear();
            break;
        default:
        break;
    }
} while (caso != 6);