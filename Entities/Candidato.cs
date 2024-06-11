using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_Pratico.Entities
{
    internal class Candidato
    {
		private string nomeCandidato;
        private int notaRed;
        private int notaMat;
        private int notaLing;
        private int codCursoUm;
        private int codCursoDois;
        private double notaMedia;

        public string NomeCandidato
		{
			get { return nomeCandidato; }
			set { nomeCandidato = value; }
		}

		public int NotaRed
		{
			get { return notaRed; }
		}

        public int NotaMat
        {
            get { return notaMat; }
        }

        public int NotaLing
        {
            get { return notaLing; }
        }

        public int CodCursoUm
        {
            get { return codCursoUm; }
            set { codCursoUm = value; }
        }

        public int CodCursoDois
		{
			get { return codCursoDois; }
			set { codCursoDois = value; }
		}
        public double NotaMedia
        {
            get { return notaMedia; }
            set { notaMedia = value; }
        }

        public Candidato(string nomeCandidato, int notaRed, int notaMat, int notaLing, int codCursoOp1, int codCursoOp2)
        {
            this.nomeCandidato = nomeCandidato;
            this.notaRed = notaRed;
            this.notaMat = notaMat;
            this.notaLing = notaLing;
            this.codCursoUm = codCursoOp1;
            this.codCursoDois = codCursoOp2;

            notaMedia = (notaLing + notaMat + notaRed) / 3.0;
        }

        public Candidato() { }
	}
}
