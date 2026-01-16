namespace ImportadorBaratela.Models.Tabelas
{
    public class ProdutoEstoque
    {
        public int IdProduto { get; set; }
        public int IdLoja { get; set; }
        public decimal EstoqueAtual { get; set; } = 0;
        public decimal EstoqueMinimo { get; set; } = 0;
    }
}
