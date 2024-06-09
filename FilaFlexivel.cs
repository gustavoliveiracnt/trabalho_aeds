using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_Pratico.Entities
{
    class FilaFlexivel
    {
        private Celula primeiro, ultimo;

        public FilaFlexivel()
        {
            primeiro = new Celula();
            ultimo = primeiro;
        }

        public void Inserir(Candidato x)
        { 
            ultimo.Prox = new Celula(x);
            ultimo = ultimo.Prox;
        }

        public Candidato Remover()
        {
            if (primeiro == ultimo)
                throw new Exception("Erro!");
                Celula tmp = primeiro;
            primeiro = primeiro.Prox;
            Candidato elemento = primeiro.Elemento;
            tmp.Prox = null;
            tmp = null;
            return elemento;
        }
        public void Mostrar()
        {
            Console.Write("]");
            for (Celula i = primeiro.Prox; i != null; i = i.Prox)
            {
                Console.Write(i.Elemento + " ");
            }
            Console.WriteLine("]");
        }
    }
}
