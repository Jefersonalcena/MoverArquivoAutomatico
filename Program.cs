using System;
using System.IO;
using System.Threading;

namespace MoverArquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o diretório que deseja que eu organize!");
            string path = Console.ReadLine();
            
            // listar os arquivos do diretório informado.
            var files = Directory.EnumerateFiles(path);
            // percorrendo os itens da lista acima
            foreach (string item in files)
            {   
                // Tranforma a string do nome do arquivo em um arquivo de verdade e ainda me passa as (informações desse arquivo)
                FileInfo file = new FileInfo(item);
                // capturando a extensão do arquivo
                string extension = file.Extension;
                string newPath = $@"{path}\Arquivos - {extension}".Replace(".","");
                if (extension != ".ini")
                {
                    if (Directory.Exists(newPath))
                    {
                        File.Move($@"{path}\{file.Name}",$@"{newPath}\{file.Name}");

                    }else
                    {
                        Directory.CreateDirectory(newPath); 
                        File.Move($@"{path}\{file.Name}",$@"{newPath}\{file.Name}");
                    }
                }
            }            

            Console.WriteLine("Fiz seu trabalho, preguiçoso");
            Thread.Sleep(10000);            
        }
    }
}
