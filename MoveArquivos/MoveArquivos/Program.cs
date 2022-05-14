using System;
using System.IO;

namespace MoveArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            string orig = @"c:\teste\";
            string dest = @"c:\teste\", fileName = "", destFile, destOri;
            double iQtdArq = 0.0, aux = 0.0;

            int i = 1;
            Console.Write("Caminho de Origem: ");
             orig = Console.ReadLine();

            Console.Write("Caminho de Destino: ");
            dest = Console.ReadLine();
            destOri = dest;

            Console.Write("Separar em quantos arquivos por pasta: ");
            iQtdArq = double.Parse(Console.ReadLine());

            if(!System.IO.Directory.Exists(dest))
            {
                System.IO.Directory.CreateDirectory(dest);
            }

            dest = System.IO.Path.Combine(dest, i.ToString());

            string[] files = System.IO.Directory.GetFiles(orig);
            foreach (string s in files)
            {
                // Use static Path methods to extract only the file name from the path.
                aux++;
                if (!System.IO.Directory.Exists(dest))
                {
                    System.IO.Directory.CreateDirectory(dest);
                }
                fileName = System.IO.Path.GetFileName(s);
                destFile = System.IO.Path.Combine(dest, fileName);
                System.IO.File.Move(s, destFile);
                if (aux == iQtdArq)
                {
                    i++;
                    dest = destOri;
                    dest = System.IO.Path.Combine(dest, i.ToString());
                    aux = 0;
                    if (!System.IO.Directory.Exists(dest))
                    {
                        System.IO.Directory.CreateDirectory(dest);
                    }
                }
            }

        }
    }
}
