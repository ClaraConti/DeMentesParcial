using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Nota
    {
        public string CodAlumno
        { get; set; }
        public string CodAsignatura
        { get; set; }
        public string Semestre
        { get; set; }
        public double Parcial1
        { get; set; }
        public double Parcial2
        { get; set; }
        public double NotaFinal
        { get; set; }
    }
}
