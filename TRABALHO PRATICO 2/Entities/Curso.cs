using System;
using System.Collections.Generic;
using System.Text;

namespace TRABALHO_PRATICO_2.Entities
{
    internal class Curso
    {
        private int id;
        private string nome;
        private int quantidadeAlunos;
        private Candidato[] candidatos;
        private int contador;
        private List<Candidato> candidatosSelecionados = new List<Candidato>();
        private FilaFlexivel filaEspera = new FilaFlexivel();

        public Candidato[] Candidatos
        {
            get { return candidatos; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int QuantidadeAlunos
        {
            get { return quantidadeAlunos; }
            set { quantidadeAlunos = value; }
        }


        public Curso(int id, string nome, int quantidadeAlunos, int qtdCandidatos)
        {
            this.id = id;
            this.nome = nome;
            this.quantidadeAlunos = quantidadeAlunos;
            this.candidatos = new Candidato[qtdCandidatos];
            contador = 0;
        }

        public void AdicionarCandidato(Candidato candidato)
        {
            this.candidatos[contador] = candidato;
            contador++;
        }


        public void Imprimir()
        {
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"Nome:  {candidatos[i].NomeCandidato} - Nota:   {candidatos[i].NotaMedia}");
            }
        }
    }
}
