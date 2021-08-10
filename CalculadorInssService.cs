using INSS.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INSS
{
    public class CalculadorInssService : ICalculadorInss
    {
        //SIMULANDO DADOS QUE DEVERIAM PROVIR DE UM BANCO DE DADOS
        private readonly List<AliquotaAno> Aliquotas = new List<AliquotaAno>
            {
                new AliquotaAno { Ano = 2011,
                    TetoMaximo = 405.86M,
                    Faixas = new List<AliquotaAnoFaixa>
                    {
                        new AliquotaAnoFaixa { FaixaInicial = 0, FaixaFinal = 1106.90M, Porcentagem = 8 },
                        new AliquotaAnoFaixa { FaixaInicial = 1106.91M, FaixaFinal = 1844.83M, Porcentagem = 9 },
                        new AliquotaAnoFaixa { FaixaInicial = 1844.84M, FaixaFinal = 3689.66M, Porcentagem = 11 }
                    }
                },
                new AliquotaAno {
                    Ano = 2012,
                    TetoMaximo = 500M,
                    Faixas = new List<AliquotaAnoFaixa>
                    {
                        new AliquotaAnoFaixa { FaixaInicial = 0, FaixaFinal = 1000M, Porcentagem = 7 },
                        new AliquotaAnoFaixa { FaixaInicial = 1001.01M, FaixaFinal = 1500M, Porcentagem = 8 },
                        new AliquotaAnoFaixa { FaixaInicial = 1500.01M, FaixaFinal = 3000M, Porcentagem = 9 },
                        new AliquotaAnoFaixa { FaixaInicial = 3000.01M, FaixaFinal = 4000M, Porcentagem = 11 }
                    }
                },
            };

        public decimal CalcularDesconto(DateTime data, decimal salario)
        {
            AliquotaAno aliquota = Aliquotas.Where(c => c.Ano == data.Year).FirstOrDefault();

            if (aliquota == null)
                throw new Exception("A alíquota para o ano informado não está cadastrado. Verifique.");
            if(!aliquota.Faixas.Any())
                throw new Exception(string.Format("Nenhuma faixa salarial cadastrada para aliquota do ano{0}. Verifique.", data.Year));

            return salario > aliquota.Faixas.Max(c => c.FaixaFinal) ? aliquota.TetoMaximo 
                                                                    : aliquota.Faixas.Where(c => salario >= c.FaixaInicial && salario <= c.FaixaFinal)
                                                                                     .Min(c=>c.Porcentagem) /100 *salario;
        }
    }
}
