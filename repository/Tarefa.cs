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
        public static void Delete(int index){
            InitConexao();
            string delete = "DELETE FROM tarefas WHERE idTarefa = @idTarefa";
            MySqlCommand command = new MySqlCommand(delete, conexao);
            command.Parameters.AddWithValue("@idTarefa", tarefas[index].idTarefa);

            int rowsAffected = command.ExecuteNonQuery();
            if(rowsAffected > 0){
                tarefas.RemoveAt(index);
                MessageBox.Show("Deletado com sucesso");
            }else{
                MessageBox.Show("Pessoa não encontrada");
            }
            CloseConexao();
        }
        public static void Add(string nome, string data, string hora){
            InitConexao();
            string adicionar = "INSERT INTO tarefas (idTarefa, nome, data, hora) VALUES ('', @nome, @data, @hora);";
            MySqlCommand command = new MySqlCommand(adicionar, conexao);
            command.Parameters.AddWithValue("@nome", nome);
            command.Parameters.AddWithValue("@data", data);
            command.Parameters.AddWithValue("@hora", hora);

            tarefas.Add();
            CloseConexao();
        }
    }
}










