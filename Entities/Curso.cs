﻿using System;
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
        private List<Candidato> candidatosSelecionados = new List<Candidato>();
        private FilaFlexivel filaEspera = new FilaFlexivel();

        public List<Candidato> CandidatosSelecionados
        {
            get { return candidatosSelecionados; }
            set { candidatosSelecionados = value; }
        }


        public Candidato[] Candidatos
        {
            get { return candidatos; }
            set { candidatos = value; }
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


        public Curso(int id, string nome, int quantidadeAlunos)
        {
            this.id = id;
            this.nome = nome;
            this.quantidadeAlunos = quantidadeAlunos;
        }

        public void Merge(Candidato[] array, int esq, int meio, int dir)
        {
            int nEsq = meio - esq + 1;
            int nDir = dir - meio;

            Candidato[] arrayEsq = new Candidato[nEsq + 1];
            Candidato[] arrayDir = new Candidato[nDir + 1];

            for (int j = 0; j <= nEsq; j++) arrayEsq[j] = new Candidato();
            for (int j = 0; j <= nDir; j++) arrayDir[j] = new Candidato();


            arrayEsq[nEsq].NotaMedia = int.MinValue;
            arrayDir[nDir].NotaMedia = int.MinValue;

            int iEsq, iDir, i; 

            for (iEsq = 0; iEsq < nEsq; iEsq++)
            {
                arrayEsq[iEsq] = array[esq + iEsq];
            }

            for (iDir = 0; iDir < nDir; iDir++)
            {
                arrayDir[iDir] = array[meio + 1 + iDir];
            }

            for (i = esq, iEsq = iDir = 0; i <= dir; i++)
            {
                if (arrayEsq[iEsq].NotaMedia > arrayDir[iDir].NotaMedia || (arrayEsq[iEsq].NotaMedia == arrayDir[iDir].NotaMedia && arrayEsq[iEsq].NotaRed > arrayDir[iDir].NotaRed))
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

        public void MergeSort(Candidato[] array, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                MergeSort(array, esq, meio);
                MergeSort(array, meio + 1, dir);
                Merge(array, esq, meio, dir);
            }
        }


        public void Imprimir()
        {
            for (int i = 0; i < candidatosSelecionados.Count; i++)
            {
                Console.WriteLine($"Nome:  {candidatos[i].NomeCandidato} - Nota:   {candidatos[i].NotaMedia}");
            }
        }
    }

}