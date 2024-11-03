using Saresp_2024.Models;
using Saresp_2024.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace Saresp_2024.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly string _conexaoMySql;
        public AlunoRepository(IConfiguration conf)
        {
            _conexaoMySql = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Aluno aluno)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("update Aluno set Nome=@NomeAluno, Telefone=@Telefone," +
                                                    "DataNascimento=@DataNasc, Turma=@Turma, Serie=@Serie, Email=@Email Where IdAluno=@IdAluno;", conexao);
                cmd.Parameters.Add("@NomeAluno", MySqlDbType.VarChar).Value = aluno.NomeAluno;
                cmd.Parameters.Add("@Telefone", MySqlDbType.Decimal).Value = aluno.Telefone;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = aluno.DataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@IdAluno", MySqlDbType.VarChar).Value = aluno.IdAluno;
                cmd.Parameters.Add("@Turma", MySqlDbType.VarChar).Value = aluno.Turma;
                cmd.Parameters.Add("@Serie", MySqlDbType.Decimal).Value = aluno.Serie;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = aluno.Email;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(Aluno aluno)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into Aluno(Nome, Telefone, DataNascimento, Turma, Serie, Email)" +
                                                    "values (@NomeAluno, @Telefone, STR_TO_DATE(@DataNasc,'%d/%m/%Y'), @Turma, @Serie, @Email)", conexao);

                cmd.Parameters.Add("@NomeAluno", MySqlDbType.VarChar).Value = aluno.NomeAluno;
                cmd.Parameters.Add("@Telefone", MySqlDbType.Decimal).Value = aluno.Telefone;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = aluno.DataNasc.ToString("dd/MM/yyyy");
                cmd.Parameters.Add("@Turma", MySqlDbType.VarChar).Value = aluno.Turma;
                cmd.Parameters.Add("@Serie", MySqlDbType.Decimal).Value = aluno.Serie;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = aluno.Email;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Excluir(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from Aluno where IdAluno=@IdAluno", conexao);
                cmd.Parameters.AddWithValue("@IdAluno", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Aluno ObterAluno(int Id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from Aluno " +
                                                    " where IdAluno =@IdAluno", conexao);
                cmd.Parameters.AddWithValue("@IdAluno", Id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Aluno aluno = new Aluno();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    aluno.IdAluno = Convert.ToInt32(dr["IdAluno"]);
                    aluno.NomeAluno = (string)dr["Nome"];
                    aluno.Telefone = Convert.ToUInt64(dr["Telefone"]);
                    aluno.DataNasc = Convert.ToDateTime(dr["DataNascimento"]);
                    aluno.Turma = (string)dr["Turma"];
                    aluno.Serie = Convert.ToInt32(dr["Serie"]);
                    aluno.Email = (string)dr["Email"];

                };
                return aluno;
            }
        }

        public IEnumerable<Aluno> ObterTodosAlunos()
        {
            List<Aluno> AlunoList = new List<Aluno>();
            using (var conexao = new MySqlConnection(_conexaoMySql))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Aluno", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);



                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    AlunoList.Add(
                        new Aluno
                        {
                            IdAluno = Convert.ToInt32(dr["IdAluno"]),
                            NomeAluno = (string)dr["Nome"],
                            Telefone = Convert.ToUInt64(dr["Telefone"]),
                            DataNasc = Convert.ToDateTime(dr["DataNascimento"]),
                            Turma = (string)dr["Turma"],
                            Serie = Convert.ToInt32(dr["Serie"]),
                            Email = (string)dr["Email"]
                });
                };
                return AlunoList;
            }
        }
    }
}
