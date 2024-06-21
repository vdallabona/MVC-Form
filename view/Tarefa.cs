using Controller;
using Model;
namespace View;

public class ViewTarefa : Form
{
    private readonly Label labelNome;
    private readonly TextBox inputNome;
    private readonly Label labelData;
    private readonly TextBox inputData;
    private readonly Label labelHora;
    private readonly TextBox inputHora;

    private readonly Button buttonCadastrar;
    private readonly Button buttonAlterar;
    private readonly Button buttonDeletar;
    private readonly DataGridView DataGridListar;

    public ViewTarefa()
    {
        StartPosition = FormStartPosition.CenterScreen;
        Size = new Size(400, 500);

        labelNome = new Label {
            Text = "Nome: ",
            Location = new Point(50, 50)
        };

        inputNome = new TextBox {
            Size = new Size(200, 20),
            Location = new Point(150, 50)
        };

        labelData = new Label {
            Text = "Data: ",
            Location = new Point(50, 100)
        };

        inputData = new TextBox {
            Size = new Size(200, 20),
            Location = new Point(150, 100)
        };

        labelHora = new Label {
            Text = "Hora: ",
            Location = new Point(50, 150)
        };

        inputHora = new TextBox {
            Size = new Size(200, 20),
            Location = new Point(150, 150)
        };

        buttonCadastrar = new Button {
            Text = "CADASTRAR",
            Location = new Point(50, 200)
        };
        buttonCadastrar.Click += ClickCadastrar;

        buttonAlterar = new Button {
            Text = "ALTERAR",
            Location = new Point(150, 200)
        };
        buttonAlterar.Click += ClickAlterar;

        buttonDeletar = new Button {
            Text = "DELETAR",
            Location = new Point(250, 200)
        };
        buttonDeletar.Click += ClickDeletar;

        DataGridListar = new DataGridView {
            Location = new Point(0, 250),
            Size = new Size(400, 150)
        };

        Controls.Add(labelNome);
        Controls.Add(inputNome);
        Controls.Add(labelData);
        Controls.Add(inputData);
        Controls.Add(labelHora);
        Controls.Add(inputHora);
        Controls.Add(buttonCadastrar);
        Controls.Add(buttonAlterar);
        Controls.Add(buttonDeletar);
        Controls.Add(DataGridListar);
    }

    private void Listar() {
        List<Tarefa> tarefas = ControllerTarefa.ListarTarefa();
        DataGridListar.Columns.Clear();
        DataGridListar.AutoGenerateColumns = false;
        DataGridListar.DataSource = tarefas;

        DataGridListar.Columns.Add(new DataGridViewTextBoxColumn{
            HeaderText = "Nome",
            DataPropertyName = "Nome"
        });

        DataGridListar.Columns.Add(new DataGridViewTextBoxColumn{
            HeaderText = "Data",
            DataPropertyName = "Data"
        });

        DataGridListar.Columns.Add(new DataGridViewTextBoxColumn{
            HeaderText = "Hora",
            DataPropertyName = "Hora"
        });
    }

    private void ClickCadastrar(object? sender, EventArgs e){
        if(inputNome.Text.Length > 0 && inputData.Text.Length > 0 && inputHora.Text.Length > 0){
            ControllerTarefa.CriarTarefa(inputNome.Text, inputData.Text, inputHora.Text);
            Listar();
        }else{
            MessageBox.Show("Preencha todos os campos");
            return;
        }
    }
    private void ClickAlterar(object? sender, EventArgs e){
    }
    private void ClickDeletar(object? sender, EventArgs e){
        int index = DataGridListar.SelectedRows[0].Index;
        ControllerTarefa.DeletarTarefa(index);
        Listar();
    }
}