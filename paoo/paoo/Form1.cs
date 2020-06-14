using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace paoo
{
    public partial class Main : Form
    {
        DataTable search = new DataTable();
        DataTable search1 = new DataTable();
        DataTable search2 = new DataTable();
        String role;
        String user;
        String cs = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;  AttachDbFilename=C:\Users\aleex\source\repos\paoo\paoo\Catalog.mdf; Connect Timeout=30";

        public Main()
        {
            InitializeComponent();
            LoadGrid();
            LoadGrid2();
            LoadGrid3();
            LoadGrid4();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void textUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            textUser.Clear();
            textPass.Clear();
            textUser.Focus();

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (textUser.Text == "")
            {
                MessageBox.Show("Please enter user name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textUser.Focus();
                return;
            }
            if (textPass.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textPass.Focus();
                return;
            }
            try
            {
                SqlConnection myConnection = default(SqlConnection);
                myConnection = new SqlConnection(cs);

                SqlCommand myCommand = default(SqlCommand);             

                myCommand = new SqlCommand("SELECT username,password,role FROM users WHERE username = @Username AND password = @Password", myConnection);             

                SqlParameter uName = new SqlParameter("@Username", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@Password", SqlDbType.VarChar);
                user = textUser.Text;
                uName.Value = textUser.Text;
                uPassword.Value = textPass.Text;

                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);
                myCommand.Connection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);

                if (myReader.Read() == true)
                {
                    role = myReader.GetString(2);
                    MessageBox.Show("You have logged in successfully " + textUser.Text,"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    label19.Text = "Welcome " + user + " !";
                    label20.Text = "Drepturi utilizator: " + role;
                    label21.Text = label20.Text;
                    label22.Text = label19.Text;
                    label23.Text = label20.Text;
                    label24.Text = label19.Text;
                    loginButton.Visible = false;
                    textUser.Visible = false;
                    clearButton.Visible = false;
                    textPass.Visible = false;
                    passLabel.Visible = false;
                    userLabel.Visible = false;
                    tabControl.Visible = true;
                    if(role == "Student")
                    {
                        btnAdd.Visible = false;
                        btnClear.Visible = false;
                        btnDel.Visible = false;
                        btnMod.Visible = false;
                        tabControl.TabPages.Remove(tabStudent);
                        tabControl.TabPages.Remove(tabUser);
                        dataGridView3.DataSource = null;
                        LoadGridS();
                    }
                    if (role == "Moderator")
                    {
                        btnAdd.Visible = true;
                        btnClear.Visible = true;
                        btnDel.Visible = true;
                        btnMod.Visible = true;
                        tabControl.TabPages.Remove(tabStudent);
                        tabControl.TabPages.Add(tabStudent);
                        tabControl.TabPages.Remove(tabUser);

                    }
                    if (role == "Admin")
                    {
                        btnAdd.Visible = true;
                        btnClear.Visible = true;
                        btnDel.Visible = true;
                        btnMod.Visible = true;
                        tabControl.TabPages.Remove(tabStudent);
                        tabControl.TabPages.Remove(tabUser);
                        tabControl.TabPages.Add(tabStudent);
                        tabControl.TabPages.Add(tabUser);

                    }
                }


                else
                {
                    MessageBox.Show("Login Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textUser.Clear();
                    textPass.Clear();
                    textUser.Focus();

                }
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String query = "INSERT INTO dbo.Catalog(cods,rc,ip,bd,paoo,plf,paw,ia) VALUES (@Cods,@RC,@IP,@BD,@PAOO,@PLF,@PAW,@IA)";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Cods", textBox2.Text);
            cmd.Parameters.AddWithValue("@RC", textBox3.Text);
            cmd.Parameters.AddWithValue("@IP", textBox4.Text);
            cmd.Parameters.AddWithValue("@BD", textBox5.Text);
            cmd.Parameters.AddWithValue("@PAOO", textBox6.Text);
            cmd.Parameters.AddWithValue("@PLF", textBox7.Text);
            cmd.Parameters.AddWithValue("@PAW", textBox8.Text);
            cmd.Parameters.AddWithValue("@IA", textBox9.Text);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                MessageBox.Show("Data Saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
                LoadGrid();
                
            }
            else
            {
                MessageBox.Show("Command failed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tabCatalog_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox8.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox9.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();


        }

        public void LoadGrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(cs))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Catalog", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                search1 = dtbl;

                //method 1 - direct method
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dtbl;
            

            }


            }
        public void LoadGrid2()
        {
            using (SqlConnection sqlCon2 = new SqlConnection(cs))
            {
                sqlCon2.Open();
                SqlDataAdapter sqlDa2 = new SqlDataAdapter("SELECT * FROM Inmatriculare", sqlCon2);
                DataTable dtb2 = new DataTable();
                sqlDa2.Fill(dtb2);
                search = dtb2;
                //method 1 - direct method
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = dtb2;


            }
    


        }
        public void srch()
        {
            DataView s = new DataView(search);
            s.RowFilter = String.Format("Nume like '%{0}%'",textBox1.Text);
            dataGridView2.DataSource = s;
        }
        public void srch1()
        {
            DataView s = new DataView(search1);
            s.RowFilter = String.Format("convert(Cods, 'System.String') like '%{0}%'", textBox11.Text);
            dataGridView1.DataSource = s;
        }
        public void srch2()
        {
            DataView s = new DataView(search2);
            s.RowFilter = String.Format("Username like '%{0}%'", textBox10.Text);
            dataGridView4.DataSource = s;
        }

        public void LoadGrid3()
        {
            using (SqlConnection sqlCon3 = new SqlConnection(cs))
            {
                sqlCon3.Open();
                SqlDataAdapter sqlDa3 = new SqlDataAdapter("SELECT cods,nume,prenume FROM Inmatriculare", sqlCon3);
                DataTable dtb3 = new DataTable();
                sqlDa3.Fill(dtb3);

                //method 1 - direct method
                dataGridView3.AutoGenerateColumns = false;
                dataGridView3.DataSource = dtb3;


            }

        }

        public void LoadGrid4()
        {
            using (SqlConnection sqlCon4 = new SqlConnection(cs))
            {
                sqlCon4.Open();
                SqlDataAdapter sqlDa4 = new SqlDataAdapter("SELECT * from users", sqlCon4);
                DataTable dtb4 = new DataTable();
                sqlDa4.Fill(dtb4);
                search2 = dtb4;

                //method 1 - direct method
                dataGridView4.AutoGenerateColumns = false;
                dataGridView4.DataSource = dtb4;
                


            }

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox100.Text = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox101.Text = this.dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox102.Text = this.dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox103.Text = this.dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox104.Text = this.dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox105.Text = this.dataGridView2.CurrentRow.Cells[5].Value.ToString();
            textBox106.Text = this.dataGridView2.CurrentRow.Cells[6].Value.ToString();
            textBox107.Text = this.dataGridView2.CurrentRow.Cells[7].Value.ToString();
            textBox108.Text = this.dataGridView2.CurrentRow.Cells[8].Value.ToString();
            textBox109.Text = this.dataGridView2.CurrentRow.Cells[9].Value.ToString();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String query = "DELETE FROM dbo.Catalog where Cods = @Cods";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Cods", textBox2.Text);         
            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                MessageBox.Show("Data deleted","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
                LoadGrid();

            }
            else
            {
                MessageBox.Show("Command failed !", "Info",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "UPDATE  dbo.Catalog SET rc=@RC,ip=@IP,BD=@BD,PAOO=@PAOO,PLF=@PLF,PAW=@PAW,IA=@IA where cods=@Cods";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Cods", textBox2.Text);
            cmd.Parameters.AddWithValue("@RC", textBox3.Text);
            cmd.Parameters.AddWithValue("@IP", textBox4.Text);
            cmd.Parameters.AddWithValue("@BD", textBox5.Text);
            cmd.Parameters.AddWithValue("@PAOO", textBox6.Text);
            cmd.Parameters.AddWithValue("@PLF", textBox7.Text);
            cmd.Parameters.AddWithValue("@PAW", textBox8.Text);
            cmd.Parameters.AddWithValue("@IA", textBox9.Text);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                MessageBox.Show("Data modified", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
                LoadGrid();

            }
            else
            {
                MessageBox.Show("Command failed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String query = "INSERT INTO dbo.Inmatriculare(cods,nume,prenume,datan,cetatenie,an,grupa,bursa,facultate,domeniu) " +
                "VALUES (@Cods,@Nume,@Prenume,@Datan,@Cetatenie,@An,@Grupa,@Bursa,@Facultate,@Domeniu)";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Cods", textBox100.Text);
            cmd.Parameters.AddWithValue("@Nume", textBox101.Text);
            cmd.Parameters.AddWithValue("@Prenume", textBox102.Text);
            cmd.Parameters.AddWithValue("@Datan", textBox103.Text);
            cmd.Parameters.AddWithValue("@Cetatenie", textBox104.Text);
            cmd.Parameters.AddWithValue("@An", textBox105.Text);
            cmd.Parameters.AddWithValue("@Grupa", textBox106.Text);
            cmd.Parameters.AddWithValue("@Bursa", textBox107.Text);
            cmd.Parameters.AddWithValue("@Facultate", textBox108.Text);
            cmd.Parameters.AddWithValue("@Domeniu", textBox109.Text);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                MessageBox.Show("Data Saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView2.DataSource = null;
                LoadGrid2();
                LoadGrid3();

            }
            else
            {
                MessageBox.Show("Command failed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String query = "DELETE FROM dbo.Inmatriculare where cods=@Cods";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Cods", textBox100.Text);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                MessageBox.Show("Data deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView2.DataSource = null;
                LoadGrid();
                LoadGrid2();
                LoadGrid3();

            }
            else
            {
                MessageBox.Show("Command failed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String query = "UPDATE  dbo.Inmatriculare SET  nume=@Nume, prenume=@Prenume,datan=@Datan,cetatenie=@Cetatenie,an=@an," +
                "grupa=@Grupa,bursa=@Bursa,facultate=@Facultate,domeniu=@Domeniu where cods=@Cods";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Cods", textBox100.Text);
            cmd.Parameters.AddWithValue("@Nume", textBox101.Text);
            cmd.Parameters.AddWithValue("@Prenume", textBox102.Text);
            cmd.Parameters.AddWithValue("@Datan", textBox103.Text);
            cmd.Parameters.AddWithValue("@Cetatenie", textBox104.Text);
            cmd.Parameters.AddWithValue("@An", textBox105.Text);
            cmd.Parameters.AddWithValue("@Grupa", textBox106.Text);
            cmd.Parameters.AddWithValue("@Bursa", textBox107.Text);
            cmd.Parameters.AddWithValue("@Facultate", textBox108.Text);
            cmd.Parameters.AddWithValue("@Domeniu", textBox109.Text);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                MessageBox.Show("Data modified", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView2.DataSource = null;
                LoadGrid2();
                LoadGrid3();

            }
            else
            {
                MessageBox.Show("Command failed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox100.Text = "";
            textBox101.Text = "";
            textBox102.Text = "";
            textBox103.Text = "";
            textBox104.Text = "";
            textBox105.Text = "";
            textBox106.Text = "";
            textBox107.Text = "";
            textBox108.Text = "";
            textBox109.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            String query = "INSERT INTO dbo.users (id,username,password,role) VALUES (@Id,@Username,@Password,@Role)";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", textBox01.Text);
            cmd.Parameters.AddWithValue("@Username", textBox02.Text);
            cmd.Parameters.AddWithValue("@Password", textBox03.Text);
            cmd.Parameters.AddWithValue("@Role", textBox04.Text);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                MessageBox.Show("Data Saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView4.DataSource = null;
                LoadGrid4();
                

            }
            else
            {
                MessageBox.Show("Command failed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            String query = "DELETE FROM dbo.users where id = @Id";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", textBox01.Text);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                MessageBox.Show("Data Deleted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView4.DataSource = null;
                LoadGrid4();


            }
            else
            {
                MessageBox.Show("Command failed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String query = "UPDATE  dbo.users SET username=@Username,password=@Password,role=@Role where id=@Id";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", textBox01.Text);
            cmd.Parameters.AddWithValue("@Username", textBox02.Text);
            cmd.Parameters.AddWithValue("@Password", textBox03.Text);
            cmd.Parameters.AddWithValue("@Role", textBox04.Text);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            if (i != 0)
            {
                MessageBox.Show("Data modified", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView4.DataSource = null;
                LoadGrid4();


            }
            else
            {
                MessageBox.Show("Command failed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox01.Text = "";
            textBox02.Text = "";
            textBox03.Text = "";
            textBox04.Text = "";
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox01.Text = this.dataGridView4.CurrentRow.Cells[0].Value.ToString();
            textBox02.Text = this.dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox03.Text = this.dataGridView4.CurrentRow.Cells[2].Value.ToString();
            textBox04.Text = this.dataGridView4.CurrentRow.Cells[3].Value.ToString();
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            srch();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            srch1();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            srch2();
        }

        public void logout()
        {
            MessageBox.Show("Have a nice day!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loginButton.Visible = true;
            textUser.Visible = true;
            clearButton.Visible = true;
            textPass.Visible = true;
            passLabel.Visible = true;
            userLabel.Visible = true;
            tabControl.Visible = false;
            textUser.Clear();
            textPass.Clear();
            textUser.Focus();
        }

        private void tabUser_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            logout();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            logout();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            logout();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        public void LoadGridS()
        {
            using (SqlConnection sqlCon4 = new SqlConnection(cs))
            {
                sqlCon4.Open();
                SqlCommand Command = default(SqlCommand);
                Command = new SqlCommand("SELECT catalog.cods, catalog.rc,catalog.ip,catalog.bd,catalog.paoo,catalog.bd," +
                    "catalog.plf,catalog.paw,catalog.ia FROM Catalog,Inmatriculare where  catalog.cods=inmatriculare.cods and prenume=@User", sqlCon4);
                SqlParameter uName = new SqlParameter("@User", SqlDbType.VarChar);
                uName.Value = user;
                Command.Parameters.Add(uName);
                SqlDataAdapter sqlDa4 = new SqlDataAdapter(Command);
                DataTable dtb4 = new DataTable();
                sqlDa4.Fill(dtb4);

                //method 1 - direct method
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dtb4;


            }

        }

    }
}

