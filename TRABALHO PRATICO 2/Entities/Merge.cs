using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRABALHO_PRATICO_2.Entities
{
    class Merge
    {
        public void Mergesort(Candidato[] array, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                Mergesort(array, esq, meio);
                Mergesort(array, meio + 1, dir);
                Intercalar(array, esq, meio, dir);
            }
        }

        public void Intercalar(Candidato[] array, int esq, int meio, int dir)
        {
            // Definir tamanho dos dois subarrays
            int nEsq = meio - esq + 1;
            int nDir = dir - meio;

            Candidato[] arrayEsq = new Candidato[nEsq + 1];
            Candidato[] arrayDir = new Candidato[nDir + 1];

            // Copiar dados para os subarrays
            Array.Copy(array, esq, arrayEsq, 0, nEsq);
            Array.Copy(array, meio + 1, arrayDir, 0, nDir);

            // Sentinela no final dos dois arrays
            arrayEsq[nEsq] = new Candidato { NotaMedia = double.MaxValue };
            arrayDir[nDir] = new Candidato { NotaMedia = double.MaxValue };

            int iEsq = 0, iDir = 0;

            // Intercalação propriamente dita
            for (int i = esq; i <= dir; i++)
            {
                if (arrayEsq[iEsq].NotaMedia < arrayDir[iDir].NotaMedia ||
                    (arrayEsq[iEsq].NotaMedia == arrayDir[iDir].NotaMedia && arrayEsq[iEsq].NotaRed > arrayDir[iDir].NotaRed))
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

    }
}
