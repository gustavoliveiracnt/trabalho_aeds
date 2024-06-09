using System;
using System.Collections.Generic;
using System.Text;

namespace TRABALHO_PRATICO_2.Entities
{
    class Celula
    {
        private Candidato elemento;
        private Celula prox;
        public Celula(Candidato elemento)
        {
            this.elemento = elemento;
            this.prox = null;
        }
        public Celula()
        {
            this.elemento = null;
            this.prox = null;
        }
        public Celula Prox
        {
            get { return prox; }
            set { prox = value; }
        }
        public Candidato Elemento
        {
            get { return elemento; }
            set { elemento = value; }
        }
    }
}
