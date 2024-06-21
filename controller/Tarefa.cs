using Model;

namespace Controller {
    public class ControllerTarefa {
        public static void CriarTarefa( string nome, string data, string hora ) {
            new Tarefa( nome, data, hora );
        }
        public static List<Tarefa> ListarTarefa() {
            return Tarefa.ListarTarefa();
        }
        public static void AlterarTarefa(int indice, string nome, string data, string hora) {
            List<Tarefa> tarefas = ListarTarefa();
            if(indice >= 0 && indice < tarefas.Count){
                Tarefa.AlterarTarefa( indice, nome, data, hora );
                Console.WriteLine($"A tarefa {nome} de indice {indice} foi alterada com sucesso.");
            } else {
                Console.WriteLine("Esse indice não corresponde a nenhuma tarefa existente.");
            }
        }
        public static void DeletarTarefa(int indice) {
            Tarefa.DeletarTarefa(indice);
        }
        public static void ConcluirTarefa(int indice) {
            Tarefa.ConcluirTarefa(indice);
        }
    }
}