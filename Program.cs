using System;

namespace INSS
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************* INICIO DO PROGRAMA *****************");

            int ano;
            do
            {
                Console.WriteLine("Digite um ano para calculo:");

                if (!int.TryParse(Console.ReadLine(), out ano) || ano.ToString().Length > 4)
                {
                    Console.WriteLine("O ano deve possuir apenas 4 números inteiros.");
                }

            } while (ano == 0);

            decimal salario;
            do
            {
                Console.WriteLine("Digite o salário para cálculo:");

                if (!decimal.TryParse(Console.ReadLine(), out salario))
                {
                    Console.WriteLine("Salário deve possuir apenas números.");
                }

            } while (salario == 0);

            CalculadorInssService service = new CalculadorInssService();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(string.Format("Desconto calculado para o salário de {0}: {1}", salario.ToString(), service.CalcularDesconto(new DateTime(ano, 1, 1), salario)));
            Console.WriteLine("");
            Console.WriteLine("************* FIM DO PROGRAMA *****************");
            Console.ReadLine();
        }
    }
}
