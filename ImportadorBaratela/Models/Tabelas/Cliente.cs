namespace ImportadorBaratela.Models.Tabelas
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fantasia { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int CodMunicipio { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public decimal Credito { get; set; }
        public decimal Limite { get; set; }
        public string DtNascimento { get; set; }
        public decimal Usado { get; set; }
        public string Obs { get; set; }
        public int EmpresaConvenio { get; set; }
        public int Loja { get; set; }
        public string Tipo { get; set; }
        public int TipoFidelidade { get; set; }
        public string CondicaoPagamento { get; set; }
        public string Fone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    }
}
