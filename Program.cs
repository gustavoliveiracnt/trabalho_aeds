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
            List<Curso> curso = new List<Curso>();
            List<Candidato> candidato = new List<Candidato>();
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
                        curso.Add(new Curso(id, nome, qtdAunos));
                    }
                    else
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
                } while (leitura != null);
            }
            catch (IOException exception)
            {
                Console.WriteLine("Erro inesperado: " + exception.Message);
            }


            foreach (Curso c in curso)
            {
                Console.WriteLine($"Id: {c.Id} \nNome curso: {c.Nome}\nQuantidade de candidatos: {c.QuantidadeAlunos}\n");
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
