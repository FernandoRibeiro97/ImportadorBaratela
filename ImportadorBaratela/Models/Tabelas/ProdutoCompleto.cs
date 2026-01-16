namespace ImportadorBaratela.Models.Tabelas
{
    public class ProdutoCompleto
    {
        public Produto TbProduto { get; set; } = new Produto();
        public ProdutoPreco TbPreco { get; set; } = new ProdutoPreco();
        public ProdutoEstoque TbEstoque { get; set; } = new ProdutoEstoque();
        public ProdutoTributacao TbTributacao { get; set; } = new ProdutoTributacao();
    }
}
