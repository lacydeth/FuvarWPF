using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Fuvar
    {
        int taxiAzonosito;
        string indulas;
        int idotartam;
        float tav;
        float viteldij;
        float borravalo;
        string fizetes;

        public Fuvar(int taxiAzonosito, string indulas, int idotartam, float tav, float viteldij, float borravalo, string fizetes)
        {
            this.taxiAzonosito = taxiAzonosito;
            this.indulas = indulas;
            this.idotartam = idotartam;
            this.tav = tav;
            this.viteldij = viteldij;
            this.borravalo = borravalo;
            this.fizetes = fizetes;
        }

        public int TaxiAzonosito { get => taxiAzonosito;  }
        public string Indulas { get => indulas; }
        public int Idotartam { get => idotartam; }
        public float Tav { get => tav; }
        public float Viteldij { get => viteldij; }
        public float Borravalo { get => borravalo; }
        public string Fizetes { get => fizetes; }
    }
}
