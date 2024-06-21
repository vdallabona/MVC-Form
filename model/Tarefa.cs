using Repository;

namespace Model {
    public class Tarefa {
        public string Nome { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Concluida { get; set; }

        public Tarefa(string nome, string data, string hora){
            Nome = nome;
            Data = data;
            Hora = hora;
            Concluida = "pendente.";
            ListTarefa.tarefas.Add(this);
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
        public static void ConcluirTarefa(int indice) {
            Tarefa work = ListTarefa.tarefas[indice];
            if(work.Concluida == "pendente."){
                work.Concluida = "concluída!";
            }else{
                work.Concluida = "pendente.";
            }
        }

        public void FinalizarTarefa() {
            Console.WriteLine($"Olá, eu sou a tarefa {Nome}, registrada com o dia {Data} e hora {Hora}. Eu estava {Concluida}");
        }
    }
}