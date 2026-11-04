using System;
using System.Text;
using System.Xml;
using Microsoft.VisualBasic.FileIO;

int caso =0;
string xmlarch="";
string csvarch="";
string[] nombre=null!;
string[] nom = new string[6]; 
string carpetaBase=@"bin\Debug\net10.0\2.2";
string rutaArchivoxml = "";
string rutaArchivocsv = "";
string genero = "";
string ano = "";
string lenguaje = "";
bool esigual=false;

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
            do{
                caso=1;
                Console.WriteLine("CSV a XML");
                Console.WriteLine("1. Exportar documento a XML");
                Console.WriteLine("2. Exportar por genero");
                Console.WriteLine("3. Exportar por año");
                Console.WriteLine("4. Exportar por lenguaje");
                Console.WriteLine("5. Cambiar a XML");
                Console.WriteLine("6. Cerrar la aplicación.");
                caso = int.Parse(Console.ReadLine()!);
                switch (caso)
                {
                    case 1:
                    int cont = 0;
                    Console.WriteLine("Introduce el archivo CSV");
                    csvarch = Console.ReadLine()!;
                    rutaArchivocsv = Path.Combine(carpetaBase, csvarch);
                    Console.WriteLine("Introduce el archivo XML");
                    xmlarch = Console.ReadLine()!;
                    rutaArchivoxml = Path.Combine(carpetaBase, xmlarch);

                    string[] lines = File.ReadAllLines(rutaArchivocsv);
                    
                    using (XmlWriter xmlWriter = XmlWriter.Create(rutaArchivoxml, new XmlWriterSettings { Indent = true }))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("Root");

                        foreach (string line in lines)
                        {
                            string[] fields = line.Split(',');
                            string[] fields2 = new string[fields.Length - 1];

                            if (cont == 0)
                            {
                                nombre = fields;
                            }
                            else
                            {
                                for (int i = 0; i < fields.Length; i++)
                                {
                                    if (i < 2)
                                    {
                                        fields2[i] = fields[i];
                                    }
                                    else if (i == 2)
                                    {
                                    }
                                    else if (i == 3)
                                    {
                                        fields2[2] = fields[2] + fields[i];
                                    }
                                    else
                                    {
                                        fields2[i - 1] = fields[i];
                                    }
                                }
                                xmlWriter.WriteStartElement("Row"); 
                                
                                for (int i = 0; i < nombre.Length; i++)
                                {
                                    string fieldValue = (i < fields2.Length) ? fields2[i] : string.Empty;

                                    string cleanTag = nombre[i].Trim().Replace(" ", "_");

                                    xmlWriter.WriteStartElement(cleanTag);
                                    xmlWriter.WriteString(fieldValue);
                                    xmlWriter.WriteEndElement();
                                }
                                
                                xmlWriter.WriteEndElement();
                            }
                            cont++; 
                        }

                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                    }

                    break;
                    case 2:
                    cont = 0;
                    Console.WriteLine("Introduce el archivo CSV");
                    csvarch = Console.ReadLine()!;
                    rutaArchivocsv = Path.Combine(carpetaBase, csvarch);

                    Console.WriteLine("Introduce el archivo XML");
                    xmlarch = Console.ReadLine()!;
                    rutaArchivoxml = Path.Combine(carpetaBase, xmlarch);

                    Console.WriteLine("Introduce el genero deseado");
                    genero = Console.ReadLine()!; 

                    lines = File.ReadAllLines(rutaArchivocsv);
                    int matchCount = 0;

                    using (XmlWriter xmlWriter = XmlWriter.Create(rutaArchivoxml, new XmlWriterSettings { Indent = true }))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("Root");

                        foreach (string line in lines)
                        {
                            string[] fields = line.Split(',');
                            string[] fields2 = new string[fields.Length - 1];

                            if (cont == 0)
                            {
                                nombre = fields;
                            }
                            else
                            {
                                for (int i = 0; i < fields.Length; i++)
                                {
                                    if (i < 2)
                                    {
                                        fields2[i] = fields[i];
                                    }
                                    else if (i == 2)
                                    {
                                    }
                                    else if (i == 3)
                                    {
                                        fields2[2] = fields[2] + fields[i];
                                    }
                                    else
                                    {
                                        fields2[i - 1] = fields[i];
                                    }
                                }
                                int indiceGenero = -1;
                                for (int j = 0; j < nombre.Length; j++)
                                {
                                    string headerLimpio = nombre[j].Trim().Replace("\"", "").ToLower();
                                    if (headerLimpio == "genre" || headerLimpio == "genero")
                                    {
                                        indiceGenero = j;
                                        break;
                                    }
                                }

                                if (indiceGenero != -1 && fields.Length > indiceGenero && 
                                    fields[indiceGenero].Trim().Equals(genero, StringComparison.OrdinalIgnoreCase))
                                {
                                    xmlWriter.WriteStartElement("Row"); 
                                    
                                    for (int i = 0; i < nombre.Length; i++)
                                    {
                                        string fieldValue = (i < fields2.Length) ? fields2[i] : string.Empty;
                                        string cleanTag = nombre[i].Trim().Replace(" ", "_");

                                        xmlWriter.WriteStartElement(cleanTag);
                                        xmlWriter.WriteString(fieldValue);
                                        xmlWriter.WriteEndElement();
                                    }
                                    
                                    xmlWriter.WriteEndElement(); 
                                    matchCount++;
                                }
                            }
                            cont++; 
                        }

                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                    }

                    break;
                    case 3:
                    cont = 0;
                    Console.WriteLine("Introduce el archivo CSV");
                    csvarch = Console.ReadLine()!;
                    rutaArchivocsv = Path.Combine(carpetaBase, csvarch);

                    Console.WriteLine("Introduce el archivo XML");
                    xmlarch = Console.ReadLine()!;
                    rutaArchivoxml = Path.Combine(carpetaBase, xmlarch);

                    Console.WriteLine("Introduce el año deseado");
                    ano = Console.ReadLine()!; 

                    lines = File.ReadAllLines(rutaArchivocsv);
                    matchCount = 0;

                    using (XmlWriter xmlWriter = XmlWriter.Create(rutaArchivoxml, new XmlWriterSettings { Indent = true }))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("Root");

                        foreach (string line in lines)
                        {
                            string[] fields = line.Split(',');
                            string[] fields2 = new string[fields.Length - 1];

                            if (cont == 0)
                            {
                                nombre = fields;
                            }
                            else
                            {
                                for (int i = 0; i < fields.Length; i++)
                                {
                                    if (i < 2)
                                    {
                                        fields2[i] = fields[i];
                                    }
                                    else if (i == 2)
                                    {
                                    }
                                    else if (i == 3)
                                    {
                                        fields2[2] = fields[2] + fields[i];
                                    }
                                    else
                                    {
                                        fields2[i - 1] = fields[i];
                                    }
                                }
                                if (fields2.Contains(ano))
                                {
                                    xmlWriter.WriteStartElement("Row");

                                    for (int i = 0; i < nombre.Length; i++)
                                    {
                                        
                                        string fieldValue = (i < fields2.Length) ? fields2[i] : string.Empty;
                                        string cleanTag = nombre[i].Trim().Replace(" ", "_");

                                        xmlWriter.WriteStartElement(cleanTag);
                                        xmlWriter.WriteString(fieldValue);
                                        xmlWriter.WriteEndElement();
                                    }

                                    xmlWriter.WriteEndElement();
                                    matchCount++;
                                }
                            }
                            cont++;
                        }

                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                    }

                    break;
                    case 4:
                    cont = 0;
                    Console.WriteLine("Introduce el archivo CSV");
                    csvarch = Console.ReadLine()!;
                    rutaArchivocsv = Path.Combine(carpetaBase, csvarch);

                    Console.WriteLine("Introduce el archivo XML");
                    xmlarch = Console.ReadLine()!;
                    rutaArchivoxml = Path.Combine(carpetaBase, xmlarch);

                    Console.WriteLine("Introduce el lenguaje deseado");
                    lenguaje = Console.ReadLine()!; 

                    lines = File.ReadAllLines(rutaArchivocsv);
                    matchCount = 0;

                    using (XmlWriter xmlWriter = XmlWriter.Create(rutaArchivoxml, new XmlWriterSettings { Indent = true }))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("Root");

                        foreach (string line in lines)
                        {
                            string[] fields = line.Split(',');
                            string[] fields2 = new string[fields.Length - 1];

                            if (cont == 0)
                            {
                                nombre = fields;
                            }
                            else
                            {
                                for (int i = 0; i < fields.Length; i++)
                                {
                                    if (i < 2)
                                    {
                                        fields2[i] = fields[i];
                                    }
                                    else if (i == 2)
                                    {
                                    }
                                    else if (i == 3)
                                    {
                                        fields2[2] = fields[2] + fields[i];
                                    }
                                    else
                                    {
                                        fields2[i - 1] = fields[i];
                                    }
                                }
                                if (fields2.Contains(lenguaje))
                                {
                                    xmlWriter.WriteStartElement("Row");

                                    for (int i = 0; i < nombre.Length; i++)
                                    {
                                        
                                        string fieldValue = (i < fields2.Length) ? fields2[i] : string.Empty;
                                        string cleanTag = nombre[i].Trim().Replace(" ", "_");

                                        xmlWriter.WriteStartElement(cleanTag);
                                        xmlWriter.WriteString(fieldValue);
                                        xmlWriter.WriteEndElement();
                                    }

                                    xmlWriter.WriteEndElement();
                                    matchCount++;
                                }
                            }
                            cont++;
                        }

                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                    }

                    break;

                }
            }while(caso!=5);
        

        do{
            caso=1;
            Console.WriteLine("XML a CSV");
            Console.WriteLine("1. Exportar documento a CSV");
            Console.WriteLine("2. Exportar por genero");
            Console.WriteLine("3. Exportar por año");
            Console.WriteLine("4. Exportar por lenguaje");
            Console.WriteLine("5. Cambiar a CSV");
            Console.WriteLine("6. Cerrar la aplicacion.");
            caso = int.Parse(Console.ReadLine()!);
            switch (caso)
            {
                case 1:
                int cont=0;
                int cont2=0;
                string res="";
                string res2="";
                Console.WriteLine("Introduce el archivo XML");
                xmlarch = Console.ReadLine()!;
                rutaArchivoxml = Path.Combine(carpetaBase, xmlarch);

                Console.WriteLine("Introduce el archivo CSV");
                csvarch = Console.ReadLine()!;
                rutaArchivocsv = Path.Combine(carpetaBase, csvarch);

                XmlReader xmlReader = XmlReader.Create(rutaArchivoxml);
                StringBuilder sb = new StringBuilder();

                while (xmlReader.Read()){
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name != "Row" && xmlReader.Name != "Root")
                    {
                        sb.Clear();
                        sb.Append(xmlReader.Name);

                        if(cont<6){
                        nom[cont]=sb.ToString();
                        }
                            
                        cont++;
                        cont2++;

                        if (cont == 6)
                            {
                            res=string.Join(",", nom);
                            File.AppendAllText(rutaArchivocsv, res + Environment.NewLine);
                            res = "";
                        }

                            sb.Clear();
                            sb.Append(xmlReader.ReadElementContentAsString());

                            if (string.IsNullOrEmpty(res2)) { res2 = sb.ToString(); }
                            else { res2 = res2 + "," + sb.ToString(); }

                        if (cont2 ==6)
                        {
                            File.AppendAllText(rutaArchivocsv, res2 + Environment.NewLine);
                            res2 = "";
                            cont2=0;
                        }
                    }
                }

                xmlReader.Close();

                break;
                case 2:
                cont=0;
                cont2=0;
                res="";
                res2="";
                Console.WriteLine("Introduce el archivo XML");
                xmlarch = Console.ReadLine()!;
                rutaArchivoxml = Path.Combine(carpetaBase, xmlarch);

                Console.WriteLine("Introduce el archivo CSV");
                csvarch = Console.ReadLine()!;
                rutaArchivocsv = Path.Combine(carpetaBase, csvarch);

                Console.WriteLine("Introduce el genero deseado");
                genero = Console.ReadLine()!; 

                xmlReader = XmlReader.Create(rutaArchivoxml);
                sb = new StringBuilder();

                while (xmlReader.Read()){
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name != "Row" && xmlReader.Name != "Root")
                    {
                        sb.Clear();
                        sb.Append(xmlReader.Name);

                        if(cont<6){
                        nom[cont]=sb.ToString();
                        }
                            
                        cont++;
                        cont2++;

                        if (cont == 6){
                            res=string.Join(",", nom);
                            File.AppendAllText(rutaArchivocsv, res + Environment.NewLine);
                            res = "";
                        }

                            sb.Clear();
                            sb.Append(xmlReader.ReadElementContentAsString());

                            if (string.IsNullOrEmpty(res2)) { res2 = sb.ToString(); }
                            else { res2 = res2 + "," + sb.ToString(); }
                            if(cont2==2 && sb.ToString()==genero){
                                esigual=true;
                            }


                        if (cont2 ==6){
                            if(esigual==true){
                                File.AppendAllText(rutaArchivocsv, res2 + Environment.NewLine);
                                esigual=false;
                            }
                            res2 = "";
                            cont2=0;
                        }
                    }
                }

                xmlReader.Close();

                break;
                case 3:
                cont=0;
                cont2=0;
                res="";
                res2="";
                Console.WriteLine("Introduce el archivo XML");
                xmlarch = Console.ReadLine()!;
                rutaArchivoxml = Path.Combine(carpetaBase, xmlarch);

                Console.WriteLine("Introduce el archivo CSV");
                csvarch = Console.ReadLine()!;
                rutaArchivocsv = Path.Combine(carpetaBase, csvarch);

                Console.WriteLine("Introduce el año deseado");
                ano = Console.ReadLine()!; 

                xmlReader = XmlReader.Create(rutaArchivoxml);
                sb = new StringBuilder();

                while (xmlReader.Read()){
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name != "Row" && xmlReader.Name != "Root")
                    {
                        sb.Clear();
                        sb.Append(xmlReader.Name);

                        if(cont<6){
                        nom[cont]=sb.ToString();
                        }
                            
                        cont++;
                        cont2++;

                        if (cont == 6){
                            res=string.Join(",", nom);
                            File.AppendAllText(rutaArchivocsv, res + Environment.NewLine);
                            res = "";
                        }

                            sb.Clear();
                            sb.Append(xmlReader.ReadElementContentAsString());

                            if (string.IsNullOrEmpty(res2)) { res2 = sb.ToString(); }
                            else { res2 = res2 + "," + sb.ToString(); }
                            if(cont2==3 && sb.ToString()==ano){
                                esigual=true;
                            }


                        if (cont2 ==6){
                            if(esigual==true){
                                File.AppendAllText(rutaArchivocsv, res2 + Environment.NewLine);
                                esigual=false;
                            }
                            res2 = "";
                            cont2=0;
                        }
                    }
                }

                xmlReader.Close();

                break;
                case 4:
                cont=0;
                cont2=0;
                res="";
                res2="";
                Console.WriteLine("Introduce el archivo XML");
                xmlarch = Console.ReadLine()!;
                rutaArchivoxml = Path.Combine(carpetaBase, xmlarch);

                Console.WriteLine("Introduce el archivo CSV");
                csvarch = Console.ReadLine()!;
                rutaArchivocsv = Path.Combine(carpetaBase, csvarch);

                Console.WriteLine("Introduce el lenguaje deseado");
                lenguaje = Console.ReadLine()!; 

                xmlReader = XmlReader.Create(rutaArchivoxml);
                sb = new StringBuilder();

                while (xmlReader.Read()){
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name != "Row" && xmlReader.Name != "Root")
                    {
                        sb.Clear();
                        sb.Append(xmlReader.Name);

                        if(cont<6){
                        nom[cont]=sb.ToString();
                        }
                            
                        cont++;
                        cont2++;

                        if (cont == 6){
                            res=string.Join(",", nom);
                            File.AppendAllText(rutaArchivocsv, res + Environment.NewLine);
                            res = "";
                        }

                            sb.Clear();
                            sb.Append(xmlReader.ReadElementContentAsString());

                            if (string.IsNullOrEmpty(res2)) { res2 = sb.ToString(); }
                            else { res2 = res2 + "," + sb.ToString(); }
                            if(cont2==6 && sb.ToString()==lenguaje){
                                esigual=true;
                            }


                        if (cont2 ==6){
                            if(esigual==true){
                                File.AppendAllText(rutaArchivocsv, res2 + Environment.NewLine);
                                esigual=false;
                            }
                            res2 = "";
                            cont2=0;
                        }
                    }
                }

                xmlReader.Close();

                break;
            }
        }while(caso!=5);
} while (caso!=6);