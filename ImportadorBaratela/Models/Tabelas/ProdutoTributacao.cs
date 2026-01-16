namespace ImportadorBaratela.Models.Tabelas
{
    public class ProdutoTributacao
    {
        public int IdProduto { get; set; }
        public int IdLoja { get; set; }
        public string OrigemProduto { get; set; } = "0 - NACIONAL";
        public string TipoProd { get; set; } = "00 - MERCADORIA PARA REVENDA";
        public int SitTribCompra { get; set; }
        public decimal IcmsCompra { get; set; }
        public decimal RedBase { get; set; }
        public string TabIcmsProdEntrada { get; set; }
        public int SitTrib { get; set; }
        public decimal Icms { get; set; }
        public decimal RedBaseVenda { get; set; }
        public string TabIcmsProd { get; set; }
        public string CodTrib { get; set; }
        public decimal Ipi { get; set; } = 0;
        public decimal Iva { get; set; } = 0;
        public string TipoPisCofins { get; set; }
        public string CstPis { get; set; }
        public string CstPisSaida { get; set; }
        public string CcsApurada { get; set; }
        public decimal CargaTributariaFederal { get; set; }
        public decimal CargaTributaria { get; set; }
        public string ChaveNCM { get; set; } = "M2L5P8";
        public string CstIpiSaida { get; set; }
        public string CstIpiEntrada { get; set; }
        public string TipoIva { get; set; } = "P";
        public string CalculaIvaAjustado { get; set; } = "N";
        public decimal Fecoep { get; set; } = 0;
        public decimal Pis { get; set; } = 0;
        public decimal Cofins { get; set; } = 0;
        public decimal PisEntrada { get; set; } = 0;
        public decimal CofinsEntrada { get; set; } = 0;
    }
}
