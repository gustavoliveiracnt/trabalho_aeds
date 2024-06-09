using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TRABALHO_PRATICO_2.Entities;


namespace TRABALHO_PRATICO_2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Informe caminho do arquivo: ");
            string path = Console.ReadLine();
            StreamReader arquivo = new StreamReader($@"{path}", Encoding.UTF8);
            string[] dados;
            int qtdCursos, qtdCandidatos;
            Dictionary<int, Curso> curso = new Dictionary<int, Curso>();

            try
            {
                string leitura = arquivo.ReadLine();
                dados = leitura.Split(';');
                qtdCursos = int.Parse(dados[0]);
                qtdCandidatos = int.Parse(dados[1]);
                int contador = 0;
                leitura = arquivo.ReadLine();
                do
                {
                    dados = leitura.Split(';');
                    if (contador < qtdCursos)
                    {
                        int id = int.Parse(dados[0]);
                        string nome = dados[1];
                        int qtdAunos = int.Parse(dados[2]);
                        curso.Add(id, new Curso(id, nome, qtdAunos, qtdCandidatos));
                    }
                    else
                    {
                        string nome = dados[0];
                        int notaRed = int.Parse(dados[1]);
                        int notaMat = int.Parse(dados[2]);
                        int notaLing = int.Parse(dados[3]);
                        int cursoUm = int.Parse(dados[4]);
                        int cursoDois = int.Parse(dados[5]);
                        curso[cursoUm].AdicionarCandidato(new Candidato(nome, notaRed, notaMat, notaLing, cursoUm, cursoDois));
                    }
                    contador++;
                    leitura = arquivo.ReadLine();
                } while (leitura != null);

                Console.WriteLine("Antes de ordenar:");
                foreach (var imprimir in curso)
                {
                    imprimir.Value.Imprimir();
                }
                //curso[1].Imprimir();

                Merge MergeSort = new Merge();
                

                for (int i = 1; i < curso.Count; i++)
                {
                    if (i != 2)
                    {
                        MergeSort.Mergesort(curso[i].Candidatos, 0, curso[i].Candidatos.Length - 1);
                    }
                }


                Console.WriteLine("Depois de ordenar:");
                foreach (var imprimir in curso)
                {
                    imprimir.Value.Imprimir();
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
