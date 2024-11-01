using Saresp_2024.Models;
using Saresp_2024.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;
namespace Saresp_2024.Repository
{
    public class ProfessorAplicadorRepository : IProfessorAplicadorRepository
    {
        private readonly string _conexaoMySql;

        public ProfessorAplicadorRepository(IConfiguration conf)
        {
            _conexaoMySql = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Cadastrar(ProfessorAplicador professorAplicador)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into ProfessorAplicador(Nome, Telefone, DataNascimento, RG, CPF)" +
                                                    "values (@NomeProf, @Telefone, STR_TO_DATE(@DataNasc,'%d/%m/%Y'), @RG, @CPF)", conexao);

                cmd.Parameters.Add("@NomeProf", MySqlDbType.VarChar).Value = professorAplicador.NomeProf;
                cmd.Parameters.Add("@Telefone", MySqlDbType.Decimal).Value = professorAplicador.Telefone;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = professorAplicador.DataNasc.ToString("dd/MM/yyyy");
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = professorAplicador.RG;
                cmd.Parameters.Add("@CPF", MySqlDbType.Decimal).Value = professorAplicador.CPF;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }

        }

        public void Atualizar(ProfessorAplicador professorAplicador)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("update ProfessorAplicador set Nome=@NomeProf, Telefone=@Telefone," +
                                                    "DataNascimento=@DataNasc, RG=@RG, CPF=@CPF Where IdProfessor=@IdProfessor;", conexao);
                cmd.Parameters.Add("@NomeProf", MySqlDbType.VarChar).Value = professorAplicador.NomeProf;
                cmd.Parameters.Add("@Telefone", MySqlDbType.Decimal).Value = professorAplicador.Telefone;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = professorAplicador.DataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@IdProfessor", MySqlDbType.VarChar).Value = professorAplicador.IdProfessor;
                cmd.Parameters.Add("@RG", MySqlDbType.VarChar).Value = professorAplicador.RG;
                cmd.Parameters.Add("@CPF", MySqlDbType.Decimal).Value = professorAplicador.CPF;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from ProfessorAplicador where IdProfessor=@IdProfessor", conexao);
                cmd.Parameters.AddWithValue("@IdProfessor", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<ProfessorAplicador> ObterTodosProfessoresAplicadores()
        {
            List<ProfessorAplicador> ProfessorAplicadorList = new List<ProfessorAplicador>();
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from ProfessorAplicador", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);



                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    ProfessorAplicadorList.Add(
                        new ProfessorAplicador
                        {
                            IdProfessor = Convert.ToInt32(dr["IdProfessor"]),
                            NomeProf = (string)dr["Nome"],
                            Telefone = Convert.ToUInt64(dr["Telefone"]),
                            DataNasc = Convert.ToDateTime(dr["DataNascimento"]),
                            RG = (string)dr["RG"],
                            CPF = Convert.ToUInt64(dr["CPF"])
                        });
                };
                return ProfessorAplicadorList;
            }
        }
        public ProfessorAplicador ObterProfessorAplicador(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from ProfessorAplicador " +
                                                    " where IdProfessor =@IdProfessor", conexao);
                cmd.Parameters.AddWithValue("@IdProfessor", Id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                ProfessorAplicador professorAplicador = new ProfessorAplicador();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    professorAplicador.IdProfessor = Convert.ToInt32(dr["IdProfessor"]);
                    professorAplicador.NomeProf = (string)dr["Nome"];
                    professorAplicador.Telefone = Convert.ToUInt64(dr["Telefone"]);
                    professorAplicador.DataNasc = Convert.ToDateTime(dr["DataNascimento"]);
                    professorAplicador.RG = (string)dr["RG"];
                    professorAplicador.CPF = Convert.ToUInt64(dr["CPF"]);
                };
                return professorAplicador;
            }
        }
    }
}

