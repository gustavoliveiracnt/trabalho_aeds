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

        public void Mergesort(Candidato[] array, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                Mergesort(array, esq, meio);
                Mergesort(array, meio + 1, dir);
                intercalar(array, esq, meio, dir);
            }
        }
        public void intercalar(Candidato[] array, int esq, int meio, int dir)
        {
            //Definir tamanho dos dois subarrays
            int nEsq = meio - esq + 1;
            int nDir = dir - meio;

            Candidato[] arrayEsq = new Candidato[nEsq + 1];
            Candidato[] arrayDir = new Candidato[nDir + 1];

            for (int j = 0; j <= nEsq; j++)
            {
                arrayEsq[j] = new Candidato();
            }

            for (int j = 0; j <= nDir; j++)
            {
                arrayDir[j] = new Candidato();
            }

            //Sentinela no final dos dois arrays
            arrayEsq[nEsq].NotaMedia = double.MaxValue;
            arrayDir[nDir].NotaMedia = double.MaxValue;
            int iEsq, iDir, i;

            //Inicializar primeiro subarray
            for (iEsq = 0; iEsq < nEsq; iEsq++)
            {
                arrayEsq[iEsq] = array[esq + iEsq];
            }
            //Inicializar segundo subarray
            for (iDir = 0; iDir < nDir; iDir++)
            {
                arrayDir[iDir] = array[(meio + 1) + iDir];
            }

            //Intercalacao propriamente dita
            for (iEsq = 0, iDir = 0, i = esq; i <= dir; i++)
            {
                if (arrayEsq[iEsq].NotaMedia < arrayDir[iDir].NotaMedia || arrayEsq[iEsq].NotaMedia == arrayDir[iDir].NotaMedia && arrayEsq[iEsq].NotaRed > arrayDir[iDir].NotaRed)
                {
                    array[i] = arrayEsq[iEsq];
                    iEsq++;
                }
                else
                {
                    array[i] = arrayDir[iDir];
                    iDir++;
                }
            }
        }

        public void Imprimir()
        {
            for(int i =0; i < contador; i++)
            {
                Console.WriteLine($"Nome:  {candidatos[i].NomeCandidato} - Nota:   {candidatos[i].NotaMedia}");
            }
        }
    }
}
