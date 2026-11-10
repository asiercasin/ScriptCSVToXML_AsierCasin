using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualBasic.FileIO;


int caso;
int cont=0;
string archivo="acb2526.csv";
string archivoexp="";
string carpetaBase="examen";
string rutaArchivo = Path.Combine(carpetaBase, archivo);
string loqpide="";
string exportar="";
string[] nombre;
string[] contenido;


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


do
{    
    Console.WriteLine("Partidos Temporada 25-26");
    Console.WriteLine("1. Visualizar datos de 1 equipo");
    Console.WriteLine("2. Visualizar datos de 1 jornada");
    Console.WriteLine("3. Visualizar los primeros 3 MVPs");
    Console.WriteLine("4. Visualizar la clasificacion");
    Console.WriteLine("5. Exportar la informacion de todos los equipos");
    Console.WriteLine("6. Cerrar la aplicación.");
    caso = int.Parse(Console.ReadLine()!);
    switch (caso)
    {
        case 1:
        cont=0;
        Console.WriteLine("Que equipo quieres visualizar");
        loqpide = Console.ReadLine()!;
        Console.WriteLine("Quieres exportarlo?");
        exportar = Console.ReadLine()!;

            if (exportar == "No"  || exportar=="no")
            {
                string[] lines = File.ReadAllLines(rutaArchivo);
                Console.WriteLine("Los datos en los que aparece",loqpide," son");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                        
                foreach(String line in lines)
                {
                    if (cont == 0)
                    {
                        nombre = line.Split(',');
                        cont++;
                    }
                    else
                    {
                        contenido=line.Split(',');
                        if(contenido[1]==loqpide || contenido[2] == loqpide)
                        {
                            Console.WriteLine(line);
                        }
                    }  
                }
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\n"); 
            }
            else if(exportar=="Si" || exportar=="si")
            {
                Console.WriteLine("Como quieres llamar al archivo");
                archivoexp = Console.ReadLine()!;
                string rutaArchivoexportar = Path.Combine(carpetaBase, archivoexp);
                
                string[] lines = File.ReadAllLines(rutaArchivo);
                using (StreamWriter escritor = new StreamWriter(rutaArchivoexportar, append: true))
                {
                    escritor.WriteLine($"Los datos en los que aparece{loqpide} son");
                    escritor.WriteLine("---------------------------------------------------------------------------------------------------------------------");    
                    foreach(String line in lines)
                    {
                        if (cont == 0)
                        {
                            nombre = line.Split(',');
                            cont++;
                        }
                        else
                        {
                            contenido=line.Split(',');
                            if(contenido[1]==loqpide || contenido[2] == loqpide)
                            {
                                escritor.WriteLine(line);
                            }
                        } 
                    }
                    escritor.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Solo se puede escribir Si o No");
            }

        break;
        case 2:
        cont=0;
        Console.WriteLine("Que jornada quieres visualizar");
        loqpide = Console.ReadLine()!;
        Console.WriteLine("Quieres exportarla?");
        exportar = Console.ReadLine()!;
        if (exportar == "No"  || exportar=="no")
            {
                string[] lines = File.ReadAllLines(rutaArchivo);
                Console.WriteLine("Los datos de la",loqpide,"son");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");        
                foreach(String line in lines)
                {
                    if (cont == 0)
                    {
                        nombre = line.Split(',');
                        cont++;
                    }
                    else
                    {
                        contenido=line.Split(',');
                        if(contenido[0]==loqpide)
                        {
                            Console.WriteLine(line);
                        }
                        
                    }  
                }
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\n"); 
            }
            else if(exportar=="Si" || exportar=="si")
            {
                Console.WriteLine("Como quieres llamar al archivo");
                archivoexp = Console.ReadLine()!;
                string rutaArchivoexportar = Path.Combine(carpetaBase, archivoexp);
                
                string[] lines = File.ReadAllLines(rutaArchivo);
                using (StreamWriter escritor = new StreamWriter(rutaArchivoexportar, append: true))
                {
                    escritor.WriteLine($"Los datos de la {loqpide} son");
                    escritor.WriteLine("---------------------------------------------------------------------------------------------------------------------");    
                    foreach(String line in lines)
                    {
                        if (cont == 0)
                        {
                            nombre = line.Split(',');
                            cont++;
                        }
                        else
                        {
                            contenido=line.Split(',');
                            if(contenido[0]==loqpide)
                            {
                                escritor.WriteLine(line);
                            }
                        }  
                    }
                    escritor.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Solo se puede escribir Si o No");
            }

        break;
        case 3:
        List<string> jugadores=new List<string>{"Kendrick Perry"};
        List<int> puntos= new List<int>{0};
        int max1=0;
        int max2=0;
        int max3=0;
        int max1loc=0;
        int max2loc=0;
        int max3loc=0;
        Console.WriteLine("Quieres exportarla?");
        exportar = Console.ReadLine()!;
        if (exportar == "No"  || exportar=="no")
            {
                string[] lines = File.ReadAllLines(rutaArchivo);
                Console.WriteLine("Los 3 primeros MVPs son");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                        
                foreach(String line in lines)
                {
                    contenido=line.Split(',');
                    int indice=jugadores.IndexOf(contenido[4]);

                    if (indice != -1)
                    {
                        puntos[indice]++;
                    }
                    else
                    {
                        jugadores.Add(contenido[4]);
                        puntos.Add(1);
                    }
                }
                for(int i = 0; i < jugadores.Count; i++)
                {
                    if (puntos[i] > max1)
                    {
                        max3=max2;
                        max3loc=max2loc;
                        max2=max1;
                        max2loc=max1loc;
                        max1=puntos[i];
                        max1loc=i;
                    } else if (puntos[i] > max2)
                    {
                        max3=max2;
                        max3loc=max2loc;
                        max2=puntos[i];
                        max2loc=i;
                    }
                    else if (puntos[i]> max3)
                    {
                        max3=puntos[i];
                        max3loc=i;
                    }
                }
                Console.WriteLine($"El jugador con mas partidos MVP es {jugadores[max1loc]} con {puntos[max1loc]}");
                Console.WriteLine($"El segundo jugador con mas partidos MVP es {jugadores[max2loc]} con {puntos[max2loc]}");
                Console.WriteLine($"El tercer jugador con mas partidos MVP es {jugadores[max3loc]} con {puntos[max3loc]}");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\n"); 
            }
            else if(exportar=="Si" || exportar=="si")
            {
                Console.WriteLine("Como quieres llamar al archivo");
                archivoexp = Console.ReadLine()!;
                string rutaArchivoexportar = Path.Combine(carpetaBase, archivoexp);
                
                string[] lines = File.ReadAllLines(rutaArchivo);
                using (StreamWriter escritor = new StreamWriter(rutaArchivoexportar, append: true))
                {
                    escritor.WriteLine("Los 3 primeros MVPs son");
                    escritor.WriteLine("---------------------------------------------------------------------------------------------------------------------");    
                    foreach(String line in lines)
                {
                    contenido=line.Split(',');
                    int indice=jugadores.IndexOf(contenido[4]);

                    if (indice != -1)
                    {
                        puntos[indice]++;
                    }
                    else
                    {
                        jugadores.Add(contenido[4]);
                        puntos.Add(1);
                    }
                }
                for(int i = 0; i < jugadores.Count; i++)
                {
                    if (puntos[i] > max1)
                    {
                        max3=max2;
                        max3loc=max2loc;
                        max2=max1;
                        max2loc=max1loc;
                        max1=puntos[i];
                        max1loc=i;
                    } else if (puntos[i] > max2)
                    {
                        max3=max2;
                        max3loc=max2loc;
                        max2=puntos[i];
                        max2loc=i;
                    }
                    else if (puntos[i]> max3)
                    {
                        max3=puntos[i];
                        max3loc=i;
                    }
                }
                    escritor.WriteLine($"El equipo con mas partidos MVP es {jugadores[max1loc]} con {puntos[max1loc]}");
                    escritor.WriteLine($"El segundo equipo con mas partidos MVP es {jugadores[max2loc]} con {puntos[max2loc]}");
                    escritor.WriteLine($"El tercer equipo con mas partidos MVP es {jugadores[max3loc]} con {puntos[max3loc]}");
                    escritor.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Solo se puede escribir Si o No");
            }

        break;
        case 4:
        string[] equipo2={"Unicaja Baloncesto","FC Barcelona Baloncesto","Real Madrid Baloncesto","Valencia Basket","Saski Baskonia","UCAM Murcia Club de Baloncesto","Club Baloncesto Gran Canaria","Club Baloncesto Canarias","Bàsquet Manresa","Basket Zaragoza","Bilbao Basket","Club Joventut Badalona","Bàsquet Girona","Bàsquet Club Andorra","Club Baloncesto San Pablo Burgos","Club Baloncesto Breogán","Força Lleida Club Esportiu","Fundación Club Baloncesto Granada"};
        int[] resultado={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        int[] ganadas={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        int[] perdidas={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        int[] hecho={0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        string[] res;
        int max=0;
        int maxloc=0;
        Console.WriteLine("Quieres exportarla?");
        exportar = Console.ReadLine()!;
        if (exportar == "No"  || exportar=="no")
        {
            {
                string[] lines = File.ReadAllLines(rutaArchivo);
                Console.WriteLine("La clasificacion de equipos es");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                        
                foreach(String line in lines)
                {
                    contenido=line.Split(',');
                    res=contenido[3].Split('-');
                    for(int i = 0; i < equipo2.Length; i++)
                    {
                        if (equipo2[i] == contenido[1])
                        {
                            if (int.Parse(res[0]) > int.Parse(res[1]))
                            {
                                ganadas[i]++;
                            }
                            else if(int.Parse(res[1]) > int.Parse(res[0]))
                            {
                                perdidas[i]++;
                            }
                        } else if(equipo2[i] == contenido[2]){
                            if (int.Parse(res[1]) > int.Parse(res[0]))
                            {
                                ganadas[i]++;
                            }
                            else if(int.Parse(res[0]) > int.Parse(res[1]))
                            {
                                perdidas[i]++;
                            }   
                        }
                    }
                }
                Console.WriteLine("Resultado | Partidas ganadas | Partidas Perdidas | Equipo");
                for(int i=0;i<resultado.Length; i++)
                    {
                        resultado[i]=ganadas[i]-perdidas[i];
                    }
                for (int i = 0; i < equipo2.Length; i++)
                {
                    max=-1000;
                    maxloc=0;
                    
                    for (int j = 0; j < equipo2.Length; j++)
                    {
                        if(hecho[j]==0 && resultado[j] > max)
                            {
                                max=resultado[j];
                                maxloc=j;
                            }
                    }
                    hecho[maxloc]=1;
                    Console.WriteLine($"{resultado[maxloc]} | {ganadas[maxloc]} | {perdidas[maxloc]} | {equipo2[maxloc]}");

                    
                } 
            }
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\n"); 
            }
            else if(exportar=="Si" || exportar=="si")
            {
                Console.WriteLine("Como quieres llamar al archivo");
                archivoexp = Console.ReadLine()!;
                string rutaArchivoexportar = Path.Combine(carpetaBase, archivoexp);
                
                string[] lines = File.ReadAllLines(rutaArchivo);
                using (StreamWriter escritor = new StreamWriter(rutaArchivoexportar, append: true))
                {
                    escritor.WriteLine("La clasificacion de equipos es");
                    escritor.WriteLine("---------------------------------------------------------------------------------------------------------------------");    
                    foreach(String line in lines)
                    {
                        contenido=line.Split(',');
                        res=contenido[3].Split('-');
                        for(int i = 0; i < equipo2.Length; i++)
                        {
                            if (equipo2[i] == contenido[1])
                            {
                                if (int.Parse(res[0]) > int.Parse(res[1]))
                                {
                                    ganadas[i]++;
                                }
                                else if(int.Parse(res[1]) > int.Parse(res[0]))
                                {
                                    perdidas[i]++;
                                }
                            } else if(equipo2[i] == contenido[2]){
                                if (int.Parse(res[1]) > int.Parse(res[0]))
                                {
                                    ganadas[i]++;
                                }
                                else if(int.Parse(res[0]) > int.Parse(res[1]))
                                {
                                    perdidas[i]++;
                                }   
                            }
                        }
                    }
                escritor.WriteLine("Resultado | Partidas ganadas | Partidas Perdidas | Equipo");
                for(int i=0;i<resultado.Length; i++)
                    {
                        resultado[i]=ganadas[i]-perdidas[i];
                    }
                for (int i = 0; i < equipo2.Length; i++)
                {
                    max=-1000;
                    maxloc=0;
                    
                    for (int j = 0; j < equipo2.Length; j++)
                    {
                        if(hecho[j]==0 && resultado[j] > max)
                            {
                                max=resultado[j];
                                maxloc=j;
                            }
                    }
                    hecho[maxloc]=1;
                    escritor.WriteLine($"{resultado[maxloc]} | {ganadas[maxloc]} | {perdidas[maxloc]} | {equipo2[maxloc]}");

                    
                } 
                escritor.WriteLine("---------------------------------------------------------------------------------------------------------------------");    
                }
                
            }else{
                Console.WriteLine("Solo se puede escribir Si o No");
            }

        break;
        case 5:
        string[] equipo3={"Unicaja Baloncesto","FC Barcelona Baloncesto","Real Madrid Baloncesto","Valencia Basket","Saski Baskonia","UCAM Murcia Club de Baloncesto","Club Baloncesto Gran Canaria","Club Baloncesto Canarias","Bàsquet Manresa","Basket Zaragoza","Bilbao Basket","Club Joventut Badalona","Bàsquet Girona","Bàsquet Club Andorra","Club Baloncesto San Pablo Burgos","Club Baloncesto Breogán","Força Lleida Club Esportiu","Fundación Club Baloncesto Granada"};
        for(int i=0;i<equipo3.Length;i++){
            string rutaArchivoexportar=Path.Combine(carpetaBase, equipo3[i]);
            string[] lines = File.ReadAllLines(rutaArchivo);
            using (StreamWriter escritor = new StreamWriter(rutaArchivoexportar+".txt", append: true))
            {    
                escritor.WriteLine("El equipo",equipo3[i],"tiene estos resultados");
                escritor.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                foreach(String line in lines)
                {
                    if (cont == 0)
                    {
                        nombre = line.Split(',');
                        cont++;
                    }
                    else
                    {
                        contenido=line.Split(',');
                        if(contenido[1]==equipo3[i] || contenido[2] == equipo3[i])
                        {
                            escritor.WriteLine(line);
                        }
                    }
                }  
                escritor.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            }
        }
        Console.WriteLine("\n");
        Console.WriteLine("\n");
        break;
    }
}while(caso!=6);