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
        private int codCursoOp1;
        private int codCursoOp2;
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

        public int CodCursoOp1
        {
            get { return codCursoOp1; }
            set { codCursoOp1 = value; }
        }

        public int CodCursoDois
		{
			get { return codCursoOp2; }
			set { codCursoOp2 = value; }
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
            this.codCursoOp1 = codCursoOp1;
            this.codCursoOp2 = codCursoOp2;

            notaMedia = Math.Round((notaLing + notaMat + notaRed) / 3.0, 2);
        }

        public Candidato() { }
	}
}
