using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistenteLigacoes
{
    class Principal
    {
        public static void notMain(string[] args)
        {
            Console.WriteLine("[ Testando a classe Telefone ]");

            Console.WriteLine("Digite o DDD: ");
            int ddd = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Prefixo: ");
            int prefixo = int.Parse(Console.ReadLine());



            Console.WriteLine("[ Testando a classe Ramal ]");


            Console.WriteLine("Digite o Sufixo: ");
            int sufixo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Data Inicial: ");
            string dataInicio = Console.ReadLine();

            Console.WriteLine("Digite a Data Final: ");
            string dataFim = Console.ReadLine();


            Ramal dados = new Ramal(sufixo,dataInicio,dataFim,ddd,prefixo);
            Console.WriteLine(dados);
            Console.Read();
            
           
        }

   }
}
