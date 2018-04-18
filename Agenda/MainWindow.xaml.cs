using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Agenda
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        typeOperation operacao;

        public MainWindow()
        {
            InitializeComponent();
        }

        public enum typeOperation
        {
            VISUALIZAÇÃO, INSERÇÃO, ALTERAÇÃO
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (operacao == typeOperation.INSERÇÃO)
            {
                // contato com os dados da tela
                contato c = new contato();
                c.nome = txtNome.Text;
                c.email = txtEmail.Text;
                c.telefone = txtTelefone.Text;

                using (agendaEntities ctx = new agendaEntities())
                {
                    ctx.contatoes.Add(c);
                    ctx.SaveChanges();
                }
            }
            else if (operacao == typeOperation.ALTERAÇÃO)
            {
                using (agendaEntities ctx = new agendaEntities())
                {
                    contato c = ctx.contatoes.Find(Convert.ToInt32(txtID.Text));

                    if (c != null)
                    {
                        c.email = txtEmail.Text;
                        c.nome = txtNome.Text;
                        c.telefone = txtTelefone.Text;

                        ctx.SaveChanges();
                    }
                }
            }

            // recarregar os contatos
            this.loadContatos();

            operacao = typeOperation.VISUALIZAÇÃO;
            changeButtons();
            clearFields();
        }

        // muda estado dos botoes
        /// <summary>
        /// Método para mudar os estados dos botões a partir da opção CRUD escolhida.
        /// </summary>
        private void changeButtons()
        {
            btnAlterar.IsEnabled = false;
            btnInserir.IsEnabled = false;
            btnExcluir.IsEnabled = false;
            btnCancelar.IsEnabled = false;
            btnLocalizar.IsEnabled = false;
            btnSalvar.IsEnabled = false;

            switch (operacao)
            {
                case typeOperation.INSERÇÃO:
                    btnCancelar.IsEnabled = true;
                    btnSalvar.IsEnabled = true;
                    break;
                case typeOperation.ALTERAÇÃO:
                    btnAlterar.IsEnabled = true;
                    btnExcluir.IsEnabled = true;
                    break;
                default:
                    btnInserir.IsEnabled = true;
                    btnLocalizar.IsEnabled = true;
                    break;
            }

            /*switch (op)
            {
                // estado inicial dos botões
                case 1:
                    btnInserir.IsEnabled = true;
                    btnLocalizar.IsEnabled = true;
                    break;
                // inserir valores
                case 2:
                    btnCancelar.IsEnabled = true;
                    btnSalvar.IsEnabled = true;
                    break;

                default:
                    break;
            }*/
        }

        private void btnInserir_Click(object sender, RoutedEventArgs e)
        {
            operacao = typeOperation.INSERÇÃO;

            changeButtons();
            //txtID.IsEnabled = true;
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            btnSalvar.IsEnabled = true;
            btnAlterar.IsEnabled = false;

            //changeButtons();
        }

        // Limpar campos
        private void clearFields()
        {
            txtEmail.Text = "";
            txtNome.Text = "";
            txtTelefone.Text = "";
            txtID.Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.loadContatos();

            //changeButtons(1);
        }

        // Carrega todos os contatos
        private void loadContatos()
        {
            using (agendaEntities ctx = new agendaEntities())
            {
                int totalReg = ctx.contatoes.Count();

                lbTotalReg.Content = "Número de contatos existentes: " + totalReg.ToString();

                var consulta = ctx.contatoes.ToList();
                dgContatos.ItemsSource = consulta;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            operacao = typeOperation.VISUALIZAÇÃO;
            changeButtons();
            clearFields();
        }

        private void btnLocalizar_Click(object sender, RoutedEventArgs e)
        {
            if (txtID.Text.Trim().Count() > 0)
            {
                try
                {
                    int id = Convert.ToInt32(txtID.Text.Trim());
                    using (agendaEntities ctx = new agendaEntities())
                    {
                        contato c = ctx.contatoes.Find(id);

                        if (c != null)
                            dgContatos.ItemsSource = new contato[1] { c };
                        else
                            dgContatos.ItemsSource = new List<contato>();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Informe um ID válido!");
                }
            }
            else if (txtNome.Text.Trim().Count() > 0 || txtEmail.Text.Trim().Count() > 0 || txtTelefone.Text.Trim().Count() > 0)
            {
                using (agendaEntities ctx = new agendaEntities())
                {
                    var consulta = from c in ctx.contatoes
                                   where c.nome.Contains(txtNome.Text) &&
                                   c.email.Contains(txtEmail.Text) &&
                                   c.telefone.Contains(txtTelefone.Text)
                                   select c;

                    dgContatos.ItemsSource = consulta.ToList();
                }
            }
            else
            {
                loadContatos();
            }
        }

        private void dgContatos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgContatos.SelectedIndex >= 0)
            {
                contato c = (contato)dgContatos.SelectedItem;

                txtID.Text = c.id + "";
                txtNome.Text = c.nome;
                txtEmail.Text = c.email;
                txtTelefone.Text = c.telefone;

                //txtID.IsEnabled = false;
                operacao = typeOperation.ALTERAÇÃO;
                changeButtons();
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            using (agendaEntities ctx = new agendaEntities())
            {
                if (MessageBox.Show("Você deseja excluir este contato?", "Confirmação de exclusão", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    contato c = ctx.contatoes.Find(Convert.ToInt32(txtID.Text));

                    if (c != null)
                    {
                        try
                        {
                            ctx.contatoes.Remove(c);
                            ctx.SaveChanges();
                            loadContatos();

                            operacao = typeOperation.VISUALIZAÇÃO;
                            changeButtons();
                            clearFields();

                            MessageBox.Show("Contato de id: " + c.id + " Removido com sucesso!");
                        }
                        catch
                        {
                            MessageBox.Show("Ocorreu um erro na remoção deste contato, id: " + c.id);
                        }

                    }
                }
                
            }
        }
    }
}
