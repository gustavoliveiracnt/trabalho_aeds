using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Trabalho_Pratico.Entities;

namespace Trabalho_Pratico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader arquivo = new StreamReader(@"C:\Users\ooliv\OneDrive\Documentos\entrada.txt", Encoding.UTF8);
            string[] dados;
            int qtdCursos, qtdCandidatos;
            List<Curso> curso = new List<Curso>();
            try
            {
                string leitura = arquivo.ReadLine();
                dados = leitura.Split(';');
                qtdCursos = int.Parse(dados[0]);
                qtdCandidatos = int.Parse(dados[1]);
                int contador = 0;
                while (leitura != null)
                {
                    dados = leitura.Split(';');
                    if (contador <= qtdCursos)
                    {
                        int id = int.Parse(dados[0]);
                        string nome = dados[1];
                        int qtdAunos = int.Parse(dados[2]);
                        curso.Add(new Curso(id, nome, qtdAunos));
                    }
                    else
                    {

                    }
                    contador++;
                    leitura = arquivo.ReadLine();
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine("Erro inesperado: " + exception.Message);
            }

            Console.ReadLine();
        }
    }
}
