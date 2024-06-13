using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_Pratico.Entities
{
    internal class Curso
    {
        private int id;
        private string nome;
        private int numVagas;
        private double notaCorte;
        private List<Candidato> candidatosSelecionados = new List<Candidato>();
        private FilaFlexivel filaEspera = new FilaFlexivel();

        public Curso() { }

        public double NotaCorte
        {
            get { return notaCorte; }
            set { notaCorte = value; }
        }

        public List<Candidato> CandidatosSelecionados
        {
            get { return candidatosSelecionados; }
            set { candidatosSelecionados = value; }
        }

        public FilaFlexivel FilaEspera
        {
            get { return filaEspera; }
            set { filaEspera = value; }
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

        public int NumVagas
        {
            get { return numVagas; }
            set { numVagas = value; }
        }


        public Curso(int id, string nome, int quantidadeAlunos)
        {
            this.id = id;
            this.nome = nome;
            this.numVagas = quantidadeAlunos;
        }

        public void Merge(List<Candidato> candidatos, int esq, int meio, int dir)
        {
            int nEsq = meio - esq + 1;
            int nDir = dir - meio;

            List<Candidato> listEsq = new List<Candidato>(nEsq + 1);
            List<Candidato> listDir = new List<Candidato>(nDir + 1);


            for (int j = 0; j <= nEsq; j++) listEsq.Add(new Candidato());
            for (int j = 0; j <= nDir; j++) listDir.Add(new Candidato());


            listEsq[nEsq].NotaMedia = int.MinValue;
            listDir[nDir].NotaMedia = int.MinValue;

            int iEsq, iDir, i;

            for (iEsq = 0; iEsq < nEsq; iEsq++)
            {
                listEsq[iEsq] = candidatos[esq + iEsq];
            }

            for (iDir = 0; iDir < nDir; iDir++)
            {
                listDir[iDir] = candidatos[meio + 1 + iDir];
            }

            for (i = esq, iEsq = iDir = 0; i <= dir; i++)
            {
                if (listEsq[iEsq].NotaMedia > listDir[iDir].NotaMedia || (listEsq[iEsq].NotaMedia == listDir[iDir].NotaMedia && listEsq[iEsq].NotaRed > listDir[iDir].NotaRed))
                {
                    candidatos[i] = listEsq[iEsq];
                    iEsq++;
                }
                else
                {
                    candidatos[i] = listDir[iDir];
                    iDir++;
                }

            }
        }

        public void MergeSort(List<Candidato> candidatos, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                MergeSort(candidatos, esq, meio);
                MergeSort(candidatos, meio + 1, dir);
                Merge(candidatos, esq, meio, dir);
            }
        }




        public string ConcatenarArquivo()
        {
            string arquivo = "";

            int posicao = CandidatosSelecionados.Count - 1;
            this.notaCorte = candidatosSelecionados[posicao].NotaMedia;

            arquivo += $"{this.nome} {this.notaCorte.ToString("N2")}\n";
            arquivo += "Selecionados\n";

            for (int i = 0; i < candidatosSelecionados.Count; i++)
            {
                arquivo += $"{candidatosSelecionados[i].NomeCandidato} {candidatosSelecionados[i].NotaMedia.ToString("N2")}\n";
            }

            arquivo += "Fila de Espera\n";
            filaEspera.GerarFila(ref arquivo);
            arquivo += "\n";

            return arquivo;
        }
    }



}
