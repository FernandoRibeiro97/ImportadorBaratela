namespace ImportadorBaratela.Models.Tabelas
{
    public class ProdutoPreco
    {
        public int IdProduto { get; set; }
        public int IdLoja { get; set; } = 1;
        public decimal Custo { get; set; }
        public decimal CustoMedio { get; set; } = 0M;
        public decimal Venda1 { get; set; }
        public decimal Venda2 { get; set; } = 0M;
        public string DtInicioPromo { get; set; } = "2022-01-01";
        public string DtFinalPromo { get; set; } = "2022-01-01";
        public decimal Margem { get; set; } = 0M;
        public int IdFamilia { get; set; } = 0;
    }
}
