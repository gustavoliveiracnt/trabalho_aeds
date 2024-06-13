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
            string listaDeImpressao = "";
            Console.WriteLine("Informe caminho do arquivo: ");
            string caminho = Console.ReadLine();
            StreamReader arquivo = new StreamReader($@"{caminho}", Encoding.UTF8);
            string[] dadosDaLinha;
            int qtdCursos, qtdCandidatos;
            Dictionary<int, Curso> dicionarioCursos = new Dictionary<int, Curso>();
            List<Candidato> candidatos = new List<Candidato>();
            try
            {
                string leitura = arquivo.ReadLine();
                dadosDaLinha = leitura.Split(';');
                qtdCursos = int.Parse(dadosDaLinha[0]);
                qtdCandidatos = int.Parse(dadosDaLinha[1]);
                int contador = 0;
                leitura = arquivo.ReadLine();
                do
                {
                    dadosDaLinha = leitura.Split(';');
                    if (contador < qtdCursos)
                    {
                        int id = int.Parse(dadosDaLinha[0]);
                        string nome = dadosDaLinha[1];
                        int qtdAunos = int.Parse(dadosDaLinha[2]);
                        dicionarioCursos.Add(id, new Curso(id, nome, qtdAunos));
                    }
                    else
                    {
                        string nome = dadosDaLinha[0];
                        int notaRed = int.Parse(dadosDaLinha[1]);
                        int notaMat = int.Parse(dadosDaLinha[2]);
                        int notaLing = int.Parse(dadosDaLinha[3]);
                        int cursoUm = int.Parse(dadosDaLinha[4]);
                        int cursoDois = int.Parse(dadosDaLinha[5]);
                        candidatos.Add(new Candidato(nome, notaRed, notaMat, notaLing, cursoUm, cursoDois));
                    }
                    contador++;
                    leitura = arquivo.ReadLine();
                } while (leitura != null);

                Curso cursoTemp = new Curso();
                cursoTemp.MergeSort(candidatos, 0, candidatos.Count - 1);

                for (int i = 0; i < candidatos.Count; i++)
                {
                    SelecaoDeAlunos(candidatos[i], dicionarioCursos);
                }

                for (int i = 1; i <= qtdCursos; i++)
                {
                    listaDeImpressao += dicionarioCursos[i].ConcatenarArquivo();
                }

                Console.WriteLine(listaDeImpressao);
                GerarArquivo(listaDeImpressao);




            }
            catch (IOException exception)
            {
                Console.WriteLine("Erro inesperado: " + exception.Message);
            }


            Console.ReadLine();
        }
        public static void SelecaoDeAlunos(Candidato candidato, Dictionary<int, Curso> cursos)

        {
            double notacandidato = candidato.NotaMedia;
            int id1 = candidato.CodCursoUm;
            int id2 = candidato.CodCursoDois;

            if (cursos[id1].CandidatosSelecionados.Count < cursos[id1].NumVagas)
            {

                cursos[id1].CandidatosSelecionados.Add(candidato);
            }

            else
            {
                cursos[id1].FilaEspera.Inserir(candidato);

                if (cursos[id2].CandidatosSelecionados.Count < cursos[id2].NumVagas)
                {
                    cursos[id2].CandidatosSelecionados.Add(candidato);
                }
                else
                {
                    cursos[id2].FilaEspera.Inserir(candidato);
                }
            }


        }

        public static void GerarArquivo(string lista)
        {
            string arq = @"C:\Users\gabri\OneDrive\Área de Trabalho\ArquivoSaida.txt";

            using (StreamWriter listaDeAprovados = new StreamWriter(arq))
            {
                listaDeAprovados.Write(lista);
            }

        }
    }
}