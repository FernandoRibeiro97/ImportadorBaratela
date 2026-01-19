using ImportadorBaratela.Models.Tabelas;
using ImportadorBaratela.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ImportadorBaratela.Helpers
{
    public class HelperArvoreMercadologica
    {
        public List<Grupo> GruposInseridos { get; set; }
        public List<SubGrupo> SubGruposInseridos { get; set; }
        public List<SubGrupo1> SubGrupos1Inseridos { get; set; }

        public static string RetornarLinhaInserirGrupo(Grupo g)
        {
            StringBuilder sb = new StringBuilder("(");
            sb.Append($"{g.Id},");
            sb.Append($"'{g.Descricao}'");
            sb.Append(")");
            return sb.ToString();
        }
        public static string RetornarLinhaInserirSubGrupo(SubGrupo s)
        {
            StringBuilder sb = new StringBuilder("(");
            sb.Append($"{s.Id},");
            sb.Append($"{s.Id},");
            sb.Append($"'{s.Descricao}',");
            sb.Append($"{s.IdGrupo}");
            sb.Append(")");
            return sb.ToString();
        }
        public static string RetornarLinhaInserirSubGrupo1(SubGrupo1 s1)
        {
            StringBuilder sb = new StringBuilder("(");
            sb.Append($"{s1.Id},");
            sb.Append($"{s1.Id},");
            sb.Append($"'{s1.Descricao}',");
            sb.Append($"{s1.IdGrupo},");
            sb.Append($"{s1.IdSubGrupo}");
            sb.Append(")");
            return sb.ToString();
        }
        public void PreencherArvoreMercadologicaInserida(MySqlConnection connection)
        {
            try
            {
                ServiceDB service = new ServiceDB(connection);
                GruposInseridos = service.RetornarGrupos();
                SubGruposInseridos = service.RetornarSubGrupos();
                SubGrupos1Inseridos = service.RetornarSubGrupos1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível recuperar árvore mercadológica inserida");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
