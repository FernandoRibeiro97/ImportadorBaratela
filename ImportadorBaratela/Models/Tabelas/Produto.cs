using System;

namespace ImportadorBaratela.Models.Tabelas
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public string DescricaoReduzida { get; set; }
        public decimal EmbEntrada { get; set; }
        public decimal EmbSaida { get; set; }
        public string UnidEntrada { get; set; }
        public string UnidSaida { get; set; }
        public string Obs { get; set; } = "IMPORTADO";
        public int Validade { get; set; }
        public int IdGrupo { get; set; }
        public int IdSubGrupo { get; set; }
        public int IdSubGrupo1 { get; set; }
        public int IdSituacao { get; set; }
        public DateTime DtCadastro { get; set; } =  DateTime.Now;
        public int PesoVariavel { get; set; }
        public int Etiqueta { get; set; } = 1;
        public string Ean { get; set; }
        public string ClassFiscal { get; set; }
        public string Cest { get; set; }
        public int Vasilhame { get; set; } = 0;
        public string Tipo { get; set; }
        public int IdFamilia { get; set; } = 0;
    }
}
