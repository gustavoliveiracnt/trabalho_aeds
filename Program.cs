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
            string path = Console.ReadLine();
            StreamReader arquivo = new StreamReader($@"{path}", Encoding.UTF8);
            string[] dados;
            int qtdCursos, qtdCandidatos;
            Dictionary<int, Curso> curso = new Dictionary<int, Curso>();
            List<Candidato> candidatos = new List<Candidato>();
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
                        candidatos.Add(new Candidato(nome, notaRed, notaMat, notaLing, cursoUm, cursoDois));
                    }
                    contador++;
                    leitura = arquivo.ReadLine();
                } while (leitura != null);

                Curso cursotemp = new Curso();
                cursotemp.MergeSort(candidatos, 0, candidatos.Count - 1);

                for (int i = 0; i < candidatos.Count; i++)
                {
                    SelecaoDeAlunos(candidatos[i], curso);
                }

                for (int i = 1; i <= qtdCursos; i++)
                {
                    listaDeImpressao += curso[i].Imprimir();
                }

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
