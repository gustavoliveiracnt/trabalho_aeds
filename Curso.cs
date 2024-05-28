using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_Pratico.Entities
{
    internal class Curso
    {
        private int id;
        private string nome;
        private int quantidadeAlunos;

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


        public Curso(int id, string nome, int quantidadeAlunos)
        {
            this.id = id;
            this.nome = nome;
            this.quantidadeAlunos = quantidadeAlunos;
        }

    }
}
