using Pedidos.Domain.LojaContexto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pedidos.Domain.LojaContexto.Queries
{
    public class ListStatusQueryResult
    {
        public int Chave { get; set; }
        public string Valor { get; set; }
        public Dictionary<string, int> Status
        {
            get
            {
                List<ListStatusQueryResult> enums = ((EnumPedidoStatus[])Enum.GetValues(typeof(EnumPedidoStatus))).Select(c => new ListStatusQueryResult() { Chave = (int)c, Valor = c.ToString() }).ToList();

                // A list of Names only, does away with the need of EnumModel 
                List<string> MyNames = ((EnumPedidoStatus[])Enum.GetValues(typeof(EnumPedidoStatus))).Where(x => x.GetHashCode() == 1).Select(c => c.ToString()).ToList();

                // A list of Values only, does away with the need of EnumModel 
                List<int> myValues = ((EnumPedidoStatus[])Enum.GetValues(typeof(EnumPedidoStatus))).Select(c => (int)c).ToList();

                // A dictionnary of <string,int>
                Dictionary<string, int> myDic = ((EnumPedidoStatus[])Enum.GetValues(typeof(EnumPedidoStatus))).ToDictionary(k => k.ToString(), v => (int)v);


                return myDic;
            }
        }

    }
}
