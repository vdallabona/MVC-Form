using Repository;

namespace Model {
    public class Tarefa {
        public int idTarefa {get; set;}
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }

        //se chamar tafera sem parametro ele chama esse aqui, se chamar com valores ele chama o de baixo
        public Tarefa(){

        }
        public Tarefa(string nome, string data, string hora){
            Nome = nome;
            Data = data;
            Hora = hora;
            ListTarefa.tarefas.Add(this);
        }

        public static void Sincronizar(){
            ListTarefa.Sincronizar();
        }
        public static List<Tarefa> ListarTarefa() {
            return ListTarefa.tarefas;
        }

        public static void AlterarTarefa( int indice, string nome, string data, string hora){
            Tarefa work = ListTarefa.tarefas[indice];
            work.Nome = nome;
            work.Data = data;
            work.Hora = hora;

            ListTarefa.tarefas[indice] = work;
        }

        public static void DeletarTarefa(int indice) {
            ListTarefa.tarefas.RemoveAt(indice);
        }
    }
}