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

                //for (int i = 1; i <= qtdCursos; i++)
                //{
                //    curso[i].Candidatos = curso[i].CandidatosSelecionados.ToArray();
                //}
                Candidato[] canditemp = candidatos.ToArray();
                Curso cursotemp = new Curso();
                cursotemp.MergeSort(canditemp, 0, canditemp.Length-1);

                //for(int i = 1; i <= qtdCursos; i++)
                //{
                //    Console.WriteLine($"\nCurso {i}:");
                //    curso[i].MergeSort(candidatos.ToArray(), 0, candidatos.ToArray().Length - 1);
                //}

                for(int i = 0; i < canditemp.Length; i++)
                {
                    SelecaoDeAlunos(canditemp[i], curso);
                }

                for (int i = 1; i <= qtdCursos; i++)
                {
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
        public static void SelecaoDeAlunos(Candidato candidato, Dictionary<int, Curso> cursos)

        //Metodo insere os candidatos nas respectivas lista de aprovados e fila de espera dos dois cursos 
        {
            double notacandidato = candidato.NotaMedia;
            int id1 = candidato.CodCursoUm;
            int id2 = candidato.CodCursoDois;

            // A ultima nota media é a nota de corte do curso, como está ordenado isso vai acontecer sempre


            // O If verifica se a nota de corte é menor e se tem vaga na lista de aprovados 

            if (cursos[id1].CandidatosSelecionados.Count < cursos[id1].NumVagas)
            {

                cursos[id1].CandidatosSelecionados.Add(candidato);
            }

            // O else adiciona o candidato na fila de espera automaticamente se ele não entrar na lista de aprovados

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

    }
}
