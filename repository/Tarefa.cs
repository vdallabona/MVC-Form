using Model;
using MySqlConnector;

namespace Repository {
    public class ListTarefa {
        private static MySqlConnection conexao;
        static public List<Tarefa> tarefas = new List<Tarefa>();

        public static void InitConexao(){
            conexao = new MySqlConnection("server=localhost;database=projetointegrador;user id=root;password=''");
            try{
                conexao.Open();
            }
            catch{
                MessageBox.Show("Não foi possível estabelecer conexão com banco de dados");
            }
        }
        public static void CloseConexao(){
            conexao.Close();
        }

        public static void Sincronizar(){
            InitConexao();
            string query = "SELECT *FROM tarefas";
            //copiar a query no mysql antes de executar, preparar ela pra executar
            MySqlCommand command = new MySqlCommand(query, conexao);
            //aqui a gente ajustaria parametros, como aplicar variaveis ou condições etc
            MySqlDataReader reader = command.ExecuteReader();
            //Agora nós vamos copiar as respostas do campo
            while(reader.Read()){
                Tarefa tarefa = new Tarefa();
                tarefa.idTarefa = Convert.ToInt32(reader["idTarefa"].ToString());
                tarefa.Nome = reader["nome"].ToString() ?? "";
                tarefa.Data = reader["data"].ToString() ?? "";
                tarefa.Hora = reader["hora"].ToString() ?? "";
                tarefas.Add(tarefa);
            }
            CloseConexao();
        }
    }
}










