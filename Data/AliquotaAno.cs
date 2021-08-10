using System.Collections.Generic;

namespace INSS.Data
{
    public class AliquotaAno
    {
        public int Ano { get; set; }
        public decimal TetoMaximo {get; set;}
        public List<AliquotaAnoFaixa> Faixas { get; set; }
    }
}
