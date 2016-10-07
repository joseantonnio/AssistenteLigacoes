using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace AssistenteLigacoes
{

    class Principal
    {
        public static void Main(string[] args)
        {

            var json = new WebClient().DownloadString("https://raw.githubusercontent.com/joseantonnio/AssistenteLigacoes/master/exemploJson.json");
            var saida = JsonConvert.DeserializeObject<List<Ramal>>(json);

            foreach (Ramal s in saida)
            {
                Console.WriteLine(s.ToString());
            }

            Console.Read();

        }

   }

}
