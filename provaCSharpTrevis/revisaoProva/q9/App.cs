using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

public static class App
{
    private static List<Colaborador> data = new List<Colaborador>();
    
    static App()
    {
        data.Add(new Colaborador("Robertinho da Silva", "Estagiário", "ETS", "0123456"));
        data.Add(new Colaborador("Você do Tipo Você mesmo", "Aprendiz", "ETS", "1234567"));
        data.Add(new Colaborador("Seu Chefe", "Meio Oficial", "ETS", "2345678"));
        data.Add(new Colaborador("Chefe do Seu Chefe", "Instrutor", "ETS", "3456789"));
        data.Add(new Colaborador("Chefe do Chefe do Seu Chefe", "Gerente", "ETS", "4567890"));
        data.Add(new Colaborador("Marcos Engenheiro", "Engenheiro", "Engenharia", "0246810"));
        data.Add(new Colaborador("Emanuelly", "Aprendiz", "ETS", "7654321"));
        data.Add(new Colaborador("Thiago", "Aprendiz", "ETS", "8765432"));
        data.Add(new Colaborador("João", "Aprendiz", "ETS", "9876543"));
        data.Add(new Colaborador("Maitê", "Aprendiz", "ETS", "0987654"));
        data.Add(new Colaborador("Leonardo", "Aprendiz", "ETS", "1098765"));
        data.Add(new Colaborador("Kaiky", "Aprendiz", "ETS", "7171717"));
        data.Add(new Colaborador("Murilo", "Aprendiz", "ETS", "6161617"));
        data.Add(new Colaborador("Hemerson", "Aprendiz", "ETS", "5151517"));
        data.Add(new Colaborador("Bruno", "Aprendiz", "ETS", "4141417"));
        data.Add(new Colaborador("Nycollas", "Aprendiz", "ETS", "3131317"));
        data.Add(new Colaborador("Zé Maria", "Imortal", "Terceirizado", "0000001"));
        data.Add(new Colaborador("Robert Bosch", "Dono", "Bosch", "0000000"));
        data.Add(new Colaborador("Sem tempo para por mais gente", "Gerente", "Engenharia", "9898987"));
        data.Add(new Colaborador("2h da manhã bixo", "Realidade", "Batendo na porta", "-1"));
    }

    public static void Run()
    {
        Pesquisador pesq = new Pesquisador();

        ApplicationConfiguration.Initialize();

        var form = new Form();
        form.WindowState = FormWindowState.Maximized;

        DataGridView dgv = new DataGridView();
        dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.RowHeadersVisible = false;
        dgv.Columns.Add("Nome", "Nome");
        dgv.Columns.Add("Cargo", "Cargo");
        dgv.Columns.Add("Setor", "Setor");
        dgv.Columns.Add("EDV", "EDV");
        form.Controls.Add(dgv);

        TextBox txt = new TextBox();
        form.Controls.Add(txt);

        txt.TextChanged += delegate
        {
            load(pesq.Search(data, txt.Text));
        };

        form.Load += delegate
        {
            dgv.Location = new Point(10, 50);
            dgv.Width = form.Width - 35;
            dgv.Height = form.Height - 100;

            txt.Location = new Point(10, 10);
            txt.Width = 500;

            load(pesq.Search(data, txt.Text));
        };

        Application.Run(form);

        void load(IEnumerable<Colaborador> collab)
        {
            dgv.Rows.Clear();

            foreach (var x in collab)
            {
                dgv.Rows.Add(x.Nome, x.Cargo, x.Setor, x.Edv);
            }
        }
    }
}