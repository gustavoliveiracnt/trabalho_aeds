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
                        curso.Add(id, new Curso(id, nome, qtdAunos));
                    }
                    else
                    {
                        string nome = dados[0];
                        int notaRed = int.Parse(dados[1]);
                        int notaMat = int.Parse(dados[2]);
                        int notaLing = int.Parse(dados[3]);
                        int cursoUm = int.Parse(dados[4]);
                        int cursoDois = int.Parse(dados[5]);
                        curso[cursoUm].CandidatosSelecionados.Add(new Candidato(nome, notaRed, notaMat, notaLing, cursoUm, cursoDois));
                    }
                    contador++;
                    leitura = arquivo.ReadLine();
                } while (leitura != null);

                for (int i = 1; i <= qtdCursos; i++)
                {
                    curso[i].Candidatos = curso[i].CandidatosSelecionados.ToArray();
                }
                
                for(int i = 1; i <= qtdCursos; i++)
                {
                    Console.WriteLine($"\nCurso {i}:");
                    curso[i].MergeSort(curso[i].Candidatos, 0, curso[i].Candidatos.Length - 1);
                    curso[i].Imprimir();
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine("Erro inesperado: " + exception.Message);
            }

            //foreach(KeyValuePair<int, Curso> imprimir in curso)
            //{
            //    Console.WriteLine("Chave: "+imprimir.Key + "Valor: "+imprimir.Value);
            //}

            Console.ReadLine();
        }
    }
}
