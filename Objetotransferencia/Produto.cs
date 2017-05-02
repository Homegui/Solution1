using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetotransferencia
{
    public class Produto
    {
        public int idProduto { get; set; }
        public string nomeProduto { get; set; }
        public string descProduto { get; set; }
        public double precProduto { get; set; }
        public double descontoPromocao { get; set; }
        public int idCategoria { get; set; }
        public bool ativoProduto { get; set; }
        public int idUsuario { get; set; }
        public int qtdMinEstoque { get; set; }
        public string imagem { get; set; }


    }
}
