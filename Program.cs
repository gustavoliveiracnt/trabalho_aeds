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
            Dictionary<int, string> dicionarioCursos = new Dictionary<int, string>();
            List<Candidato> candidato = new List<Candidato>();
            try
            {
                string leitura = arquivo.ReadLine();
                dados = leitura.Split(';');
                qtdCursos = int.Parse(dados[0]);
                qtdCandidatos = int.Parse(dados[1]);
                int contador = 0;
                do
                {
                    dados = leitura.Split(';');


                    if (dados.Length == 3)
                    {
                        int id = int.Parse(dados[0]);
                        string nome = dados[1];
                        dicionarioCursos[id] = nome;
                    }
                    if(dados.Length == 6)
                    {
                        string nome = dados[0];
                        int notaRed = int.Parse(dados[1]);
                        int notaMat = int.Parse(dados[2]);
                        int notaLing = int.Parse(dados[3]);
                        int cursoUm = int.Parse(dados[4]);
                        int cursoDois = int.Parse(dados[5]);
                        candidato.Add(new Candidato(nome, notaRed, notaMat, notaLing, cursoUm, cursoDois));
                    }
                    contador++;
                    leitura = arquivo.ReadLine();
                } while ((leitura = arquivo.ReadLine()) != null);
            }
            catch (IOException exception)
            {
                Console.WriteLine("Erro inesperado: " + exception.Message);
            }

            foreach (var c in dicionarioCursos)
            {
                Console.WriteLine($"\nId do Curso: {c.Key}\n Nome do curso: {c.Value}");
            }
            Console.WriteLine();
            foreach (Candidato c in candidato)
            {
                Console.WriteLine($"Nome: {c.NomeCandidato}\nNota média: {c.NotaMedia}\n");
            }


            Console.ReadLine();
        }
    }
}
