using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_Pratico.Entities
{
    class FilaFlexivel
    {
        private Celula primeiro, ultimo;
        private int count;

        public int Count
        {
            get { return count; }
        }


        public FilaFlexivel()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }

        public void Inserir(Candidato x)
        {
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
            count++;
        }

        public void GerarFila(ref string arquivo)
        {
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                arquivo += $"{i.Elemento.NomeCandidato} {i.Elemento.NotaMedia.ToString("N2")}\n";
            }
        }
    }
}
