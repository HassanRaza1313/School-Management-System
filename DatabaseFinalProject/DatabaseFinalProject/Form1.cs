using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace DatabaseFinalProject
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter adap;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'finalDataSet.marks' table. You can move, or remove it, as needed.
            this.marksTableAdapter.Fill(this.finalDataSet.marks);

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void TeacherLoginButton_Click(object sender, EventArgs e)
        {
            SqlConnection cn1;
            SqlCommand cmd1;
            SqlDataReader dr1;
            cn1 = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            cn1.Open();
            cmd1 = new SqlCommand("(select  teacherid,pass from teacher where teacherid = '" + UsernameBox.Text + "' and pass = '" + PasswordBox.Text + "') union (select studentid,pass from student where studentid = '" + UsernameBox.Text + "' and pass = '" + PasswordBox.Text + "') union (select username,password from admin where username = '" + UsernameBox.Text + "' and password = '" + PasswordBox.Text + "')", cn1);
            dr1 = cmd1.ExecuteReader();
            int count = 0;
            while (dr1.Read())
            {
                count += 1;
            }
            dr1.Close();
            if (count == 1)
            {
                if (LoginComboBox.Text == "Admin")
                {
                    MessageBox.Show("Admin Login Successful");
                    StudentPanel.Visible = false;
                    AdminPanel.Visible = true;
                    TeacherPanel.Visible = false;
                }
                else if (LoginComboBox.Text == "Teacher")
                {
                    MessageBox.Show("Teacher Login Successful");
                    StudentPanel.Visible = false;
                    AdminPanel.Visible = true;
                    TeacherPanel.Visible = true;
                }
                else if (LoginComboBox.Text == "Student")
                {
                    MessageBox.Show("Student Login Successful");
                    StudentPanel.Visible = true;
                    AdminPanel.Visible = true;
                    TeacherPanel.Visible = true;
                }
                else
                {
                    MessageBox.Show("Please select Login Status");
                }
            }

            else if (count > 1)
            {
                MessageBox.Show("Duplicate Username and Password");
            }

            else
            {
                MessageBox.Show("Incorrect Username or Password");
                UsernameBox.Clear();
                PasswordBox.Clear();
            }
        }


        private void AddAdminButton_Click(object sender, EventArgs e)
        {
            AddAdminPanel.Visible = true;
            AddStudentPanel.Visible = false;
            atp.Visible = false;
            acp.Visible = false;
            usp.Visible = false;
            utp.Visible = false;
            UpdateCoursePanel.Visible = false;
            GridPanel.Visible = false;
        }

        private void Aasb_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            string sql = null;

            connetionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";

            sql = "insert into admin values(@id,@pass)";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = aaub.Text;
                        cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = aapb.Text;

                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                        {
                            MessageBox.Show("Data Entered Successfully");
                            aaub.Clear();
                            aapb.Clear();
                        }

                        else
                        {
                            MessageBox.Show("Error!Data not inserted");
                            aaub.Clear();
                            aapb.Clear();
                        }



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }
        }

        private void AddTeacherButton_Click(object sender, EventArgs e)
        {
            AddAdminPanel.Visible = true;
            AddStudentPanel.Visible = false;
            atp.Visible = true;
            acp.Visible = false;
            usp.Visible = false;
            utp.Visible = false;
            UpdateCoursePanel.Visible = false;
            GridPanel.Visible = false;
        }

        private void Atb_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            string sql = null;

            connetionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";

            sql = "insert into teacher values(@id,@name,@department,@dob,@gender,@cnic,@email,@mobile,@city,@password)";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = atib.Text;
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = atnb.Text;
                        cmd.Parameters.Add("@department", SqlDbType.NVarChar).Value = atdb.Text;
                        cmd.Parameters.Add("@dob", SqlDbType.NVarChar).Value = atdobb.Text;
                        cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = atgb.Text;
                        cmd.Parameters.Add("@cnic", SqlDbType.NVarChar).Value = atcnb.Text;
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = ateb.Text;
                        cmd.Parameters.Add("@mobile", SqlDbType.NVarChar).Value = atmb.Text;
                        cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = atcb.Text;
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = atpb.Text;

                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                        {
                            MessageBox.Show("Data Entered Successfully");
                            atib.Clear();
                            atnb.Clear();
                            atdb.Clear();
                            atdobb.Clear();
                            atgb.Clear();
                            atcnb.Clear();
                            ateb.Clear();
                            atmb.Clear();
                            atcb.Clear();
                            atpb.Clear();
                        }

                        else
                        {
                            MessageBox.Show("Error!Data not inserted");
                            atib.Clear();
                            atnb.Clear();
                            atdb.Clear();
                            atdobb.Clear();
                            atgb.Clear();
                            atcnb.Clear();
                            ateb.Clear();
                            atmb.Clear();
                            atcb.Clear();
                            atpb.Clear();
                        }



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            AddAdminPanel.Visible = true;
            AddStudentPanel.Visible = true;
            atp.Visible = true;
            acp.Visible = false;
            usp.Visible = false;
            utp.Visible = false;
            UpdateCoursePanel.Visible = false;
            GridPanel.Visible = false;
        }

        private void Atp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Asb_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            string sql = null;

            connetionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";

            sql = "insert into student values(@id,@name,@current,@batch,@department,@dob,@gender,@cnic,@email,@mobile,@city,@password)";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = asib.Text;
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = asnb.Text;
                        cmd.Parameters.Add("@current", SqlDbType.NVarChar).Value = ascsb.Text;
                        cmd.Parameters.Add("@batch", SqlDbType.NVarChar).Value = asbb.Text;
                        cmd.Parameters.Add("@department", SqlDbType.NVarChar).Value = asdb.Text;
                        cmd.Parameters.Add("@dob", SqlDbType.NVarChar).Value = asdobb.Text;
                        cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = asgb.Text;
                        cmd.Parameters.Add("@cnic", SqlDbType.NVarChar).Value = ascnb.Text;
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = aseb.Text;
                        cmd.Parameters.Add("@mobile", SqlDbType.NVarChar).Value = asmb.Text;
                        cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = ascb.Text;
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = aspb.Text;

                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                        {
                            MessageBox.Show("Data Entered Successfully");
                            asib.Clear();
                            asnb.Clear();
                            ascsb.Clear();
                            asbb.Clear();
                            asdb.Clear();
                            asdobb.Clear();
                            asgb.Clear();
                            ascnb.Clear();
                            aseb.Clear();
                            asmb.Clear();
                            ascb.Clear();
                            aspb.Clear();
                        }

                        else
                        {
                            MessageBox.Show("Error!Data not inserted");
                            asib.Clear();
                            asnb.Clear();
                            ascsb.Clear();
                            asbb.Clear();
                            asdb.Clear();
                            asdobb.Clear();
                            asgb.Clear();
                            ascnb.Clear();
                            aseb.Clear();
                            asmb.Clear();
                            ascb.Clear();
                            aspb.Clear();
                        }



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }
        }

        private void AddCourseButton_Click(object sender, EventArgs e)
        {
            AddAdminPanel.Visible = true;
            AddStudentPanel.Visible = false;
            atp.Visible = true;
            acp.Visible = true;
            usp.Visible = false;
            utp.Visible = false;
            UpdateCoursePanel.Visible = false;
            GridPanel.Visible = false;
        }

        private void Acb_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            string sql = null;

            connetionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";

            sql = "insert into course values(@id,@name,@code,@hours,@semester)";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = acib.Text;
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = acnb.Text;
                        cmd.Parameters.Add("@code", SqlDbType.NVarChar).Value = accb.Text;
                        cmd.Parameters.Add("@hours", SqlDbType.NVarChar).Value = acchb.Text;
                        cmd.Parameters.Add("@semester", SqlDbType.NVarChar).Value = acsb.Text;

                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                        {
                            MessageBox.Show("Data Entered Successfully");
                            acib.Clear();
                            acnb.Clear();
                            accb.Clear();
                            acchb.Clear();
                            acsb.Clear();
                        }

                        else
                        {
                            MessageBox.Show("Error!Data not inserted");
                            acib.Clear();
                            acnb.Clear();
                            accb.Clear();
                            acchb.Clear();
                            acsb.Clear();
                        }



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }
        }

        private void Usbutton_Click(object sender, EventArgs e)
        {
            SqlConnection cn1;
            SqlCommand cmd1;
            SqlDataReader dr1;
            cn1 = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            cn1.Open();
            cmd1 = new SqlCommand("select * from student where studentid = '" + usbox.Text + " '", cn1);
            dr1 = cmd1.ExecuteReader();
            int count = 0;
            while (dr1.Read())
            {
                count += 1;
            }
            dr1.Close();
            if (count == 1)
            {
                MessageBox.Show("Student Data found");
                usitp.Visible = true;
            }

            else if (count > 1)
            {
                MessageBox.Show("Duplicate Username and Password");
            }

            else
            {
                MessageBox.Show("Student Data not found");
                UsernameBox.Clear();
                PasswordBox.Clear();
            }
        }

        private void UpdateStudentButton_Click(object sender, EventArgs e)
        {
            AddAdminPanel.Visible = true;
            AddStudentPanel.Visible = false;
            atp.Visible = true;
            acp.Visible = true;
            usp.Visible = true;
            utp.Visible = false;
            UpdateCoursePanel.Visible = false;
            GridPanel.Visible = false;
        }

        private void Usitb_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
                string Query = "update student set studentid='" + this.usib.Text + "',name='" + this.usnb.Text + "',current_semester='" + this.uscsb.Text + "',batch='" + this.usbb.Text + "',department='" + this.usdb.Text + "',dob='" + this.usdobb.Text + "',gender='" + this.usgb.Text + "',cnic='" + this.uscnb.Text + "',email='" + this.useb.Text + "',mobileno='" + this.usmb.Text + "',city='" + this.uscb.Text + "',pass='" + this.uspb.Text + "' where studentid='" + this.usbox.Text + "';";
                SqlConnection MyConn2 = new SqlConnection(MyConnection2);
                SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
                SqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Utbutton_Click(object sender, EventArgs e)
        {
            SqlConnection cn1;
            SqlCommand cmd1;
            SqlDataReader dr1;
            cn1 = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            cn1.Open();
            cmd1 = new SqlCommand("select * from teacher where teacherid = '" + utbutton.Text + " '", cn1);
            dr1 = cmd1.ExecuteReader();
            int count = 0;
            while (dr1.Read())
            {
                count += 1;
            }
            dr1.Close();
            if (count == 1)
            {
                MessageBox.Show("Teacher Data found");
                usitp.Visible = true;
            }

            else if (count > 1)
            {
                MessageBox.Show("Duplicate Username and Password");
                utitp.Visible = true;
            }

            else
            {
                MessageBox.Show("Teacher Data not found");
                UsernameBox.Clear();
                PasswordBox.Clear();
            }
        }


        private void UpdateTeacherButton_Click(object sender, EventArgs e)
        {
            AddAdminPanel.Visible = true;
            AddStudentPanel.Visible = false;
            atp.Visible = true;
            acp.Visible = true;
            usp.Visible = true;
            utp.Visible = true;
            UpdateCoursePanel.Visible = false;
            GridPanel.Visible = false;
        }

        private void Utp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Utbutton_Click_1(object sender, EventArgs e)
        {

        }

        private void Utbutton_Click_2(object sender, EventArgs e)
        {
            SqlConnection cn1;
            SqlCommand cmd1;
            SqlDataReader dr1;
            cn1 = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            cn1.Open();
            cmd1 = new SqlCommand("select * from teacher where teacherid = '" + utbox.Text + " '", cn1);
            dr1 = cmd1.ExecuteReader();
            int count = 0;
            while (dr1.Read())
            {
                count += 1;
            }
            dr1.Close();
            if (count == 1)
            {
                MessageBox.Show("Teacher Data found");
                utitp.Visible = true;
            }

            else if (count > 1)
            {
                MessageBox.Show("Duplicate Username and Password");
            }

            else
            {
                MessageBox.Show("Teacher Data not found");
                UsernameBox.Clear();
                PasswordBox.Clear();
            }
        }

        private void Utb_Click_1(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
                string Query = "update teacher set teacherid='" + this.utib.Text + "',name='" + this.utnb.Text + "',department='" + this.utdb.Text + "',dob='" + this.utdobb.Text + "',gender='" + this.utgb.Text + "',cnic='" + this.utcnb.Text + "',email='" + this.uteb.Text + "',mobileno='" + this.utmb.Text + "',city='" + this.utcb.Text + "',pass='" + this.utpb.Text + "' where teacherid='" + this.utbox.Text + "';";
                SqlConnection MyConn2 = new SqlConnection(MyConnection2);
                SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
                SqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewCoursesButton_Click(object sender, EventArgs e)
        {
            AddAdminPanel.Visible = true;
            AddStudentPanel.Visible = false;
            atp.Visible = true;
            acp.Visible = true;
            usp.Visible = true;
            utp.Visible = true;
            UpdateCoursePanel.Visible = true;
            GridPanel.Visible = false;
        }

        private void Ucbutton_Click(object sender, EventArgs e)
        {
            SqlConnection cn1;
            SqlCommand cmd1;
            SqlDataReader dr1;
            cn1 = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            cn1.Open();
            cmd1 = new SqlCommand("select * from course where coursecode = '" + ucbox.Text + " '", cn1);
            dr1 = cmd1.ExecuteReader();
            int count = 0;
            while (dr1.Read())
            {
                count += 1;
            }
            dr1.Close();
            if (count == 1)
            {
                MessageBox.Show("Course Data found");
                ucitp.Visible = true;
            }

            else if (count > 1)
            {
                MessageBox.Show("Duplicate Username and Password");
            }

            else
            {
                MessageBox.Show("Course Data not found");
                UsernameBox.Clear();
                PasswordBox.Clear();
            }
        }

        private void Ucb_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
                string Query = "update course set courseid='" + this.ucib.Text + "',coursename='" + this.ucnb.Text + "',coursecode='" + this.uccb.Text + "',credithours='" + this.ucchb.Text + "',semester='" + this.ucsb.Text + "' where coursecode='" + this.ucbox.Text + "';";
                SqlConnection MyConn2 = new SqlConnection(MyConnection2);
                SqlCommand MyCommand2 = new SqlCommand(Query, MyConn2);
                SqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewStudentButton_Click(object sender, EventArgs e)
        {
            AddAdminPanel.Visible = true;
            AddStudentPanel.Visible = true;
            atp.Visible = true;
            acp.Visible = true;
            usp.Visible = true;
            utp.Visible = true;
            UpdateCoursePanel.Visible = true;
            GridPanel.Visible = true;

            try
            {

                SqlConnection con = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from student", con);

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds, "ss");

                AdminGrid.DataSource = ds.Tables["ss"];

            }

            catch

            {

                MessageBox.Show("No Record Found");

            }
        }

        private void ViewTeacherButton_Click(object sender, EventArgs e)
        {
            AddAdminPanel.Visible = true;
            AddStudentPanel.Visible = false;
            atp.Visible = true;
            acp.Visible = true;
            usp.Visible = true;
            utp.Visible = true;
            UpdateCoursePanel.Visible = true;
            GridPanel.Visible = true;

            try
            {

                SqlConnection con = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from teacher", con);

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds, "ss");

                AdminGrid.DataSource = ds.Tables["ss"];

            }

            catch

            {

                MessageBox.Show("No Record Found");

            }
        }

        private void VCButton_Click(object sender, EventArgs e)
        {
            AddAdminPanel.Visible = true;
            AddStudentPanel.Visible = false;
            atp.Visible = true;
            acp.Visible = true;
            usp.Visible = true;
            utp.Visible = true;
            UpdateCoursePanel.Visible = true;
            GridPanel.Visible = true;

            try
            {

                SqlConnection con = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");

                con.Open();

                SqlCommand cmd = new SqlCommand("select * from course", con);

                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds, "ss");

                AdminGrid.DataSource = ds.Tables["ss"];

            }

            catch

            {

                MessageBox.Show("No Record Found");

            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            SqlCommand sc = new SqlCommand("select s.sectionname from assigned_teacher t,course c,section s where c.courseid=t.courseid and t.sectionid=s.sectionid and c.coursename = '" + ccbox.Text + "' and teacherid = '" + UsernameBox.Text + "'", conn);
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("sectionid", typeof(string));
            dt.Columns.Add("sectionname", typeof(string));
            dt.Load(reader);
            seccbox.ValueMember = "sectionid";
            seccbox.DisplayMember = "sectionname";
            seccbox.DataSource = dt;
            conn.Close();

            conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            sc = new SqlCommand("select c.courseid from course c where c.coursename = '" + ccbox.Text + "'", conn);
            reader = sc.ExecuteReader();
            dt = new DataTable();
            dt.Columns.Add("courseid", typeof(string));
            dt.Load(reader);
            icbox.ValueMember = "courseid";
            icbox.DisplayMember = "courseid";
            icbox.DataSource = dt;
            conn.Close();

        }

        private void SetWeightageButton_Click(object sender, EventArgs e)
        {
            SetWeightagePanel.Visible = true;
            mep.Visible = false;
            MarkAttendancePanel.Visible = false;
            ViewEvaluations.Visible = false;
            ViewGrades.Visible = false;

        }

        private void Sw_s_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            SqlCommand sc = new SqlCommand("select distinct c.coursename from assigned_teacher t,course c where c.courseid=t.courseid  and semester = " + scbox.Text + " and teacherid = '" + UsernameBox.Text + "'", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("courseid", typeof(string));
            dt.Columns.Add("coursename", typeof(string));
            dt.Load(reader);
            ccbox.ValueMember = "courseid";
            ccbox.DisplayMember = "coursename";
            ccbox.DataSource = dt;
            conn.Close();

            conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            sc = new SqlCommand("select s.sectionname from assigned_teacher t,course c,section s where c.courseid=t.courseid and t.sectionid=s.sectionid and c.coursename = '" + ccbox.Text + "' and teacherid = '" + UsernameBox.Text + "'", conn);
            reader = sc.ExecuteReader();
            dt = new DataTable();
            dt.Columns.Add("sectionid", typeof(string));
            dt.Columns.Add("sectionname", typeof(string));
            dt.Load(reader);
            seccbox.ValueMember = "sectionid";
            seccbox.DisplayMember = "sectionname";
            seccbox.DataSource = dt;
            conn.Close();
        }

        private void SetWeightagePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label74_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Swbutton_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            string sql = null;

            connetionString = @"Data Source=HASSAN\SQLSERVER2014;Initial Catalog=Final;Integrated Security=True";

            sql = "if not exists(select courseid from weightage where courseid=@c) insert into weightage values(@c,@a,@q,@m1,@m2,@p,@f) else update weightage set courseid=@c,a_weightage=@a,q_weightage=@q,m1_weightage=@m1,m2_weightage=@m2,project_weightage=@p,final_weightage=@f where courseid=@c ";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@c", SqlDbType.NVarChar).Value = icbox.Text;
                        cmd.Parameters.Add("@a", SqlDbType.NVarChar).Value = swab.Text;
                        cmd.Parameters.Add("@q", SqlDbType.NVarChar).Value = swqb.Text;
                        cmd.Parameters.Add("@m1", SqlDbType.NVarChar).Value = swm1b.Text;
                        cmd.Parameters.Add("@m2", SqlDbType.NVarChar).Value = swm2b.Text;
                        cmd.Parameters.Add("@p", SqlDbType.NVarChar).Value = swlb.Text;
                        cmd.Parameters.Add("@f", SqlDbType.NVarChar).Value = swfb.Text;

                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                        {
                            MessageBox.Show("Data Entered Successfully");
                            swab.Clear();
                            swqb.Clear();
                            swm1b.Clear();
                            swm2b.Clear();
                            swlb.Clear();
                            swfb.Clear();
                        }

                        else
                        {
                            MessageBox.Show("Error!Data not inserted");
                            swab.Clear();
                            swqb.Clear();
                            swm1b.Clear();
                            swm2b.Clear();
                            swlb.Clear();
                            swfb.Clear();
                        }



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }
        }

        private void Label71_Click(object sender, EventArgs e)
        {

        }

        private void Icbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MarkEvaluationsButton_Click(object sender, EventArgs e)
        {
            SetWeightagePanel.Visible = true;
            mep.Visible = true;
            MarkAttendancePanel.Visible = false;
            ViewEvaluations.Visible = false;
            ViewGrades.Visible = false;
            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
                con.Open();
                adap = new SqlDataAdapter("select marks.studentid,marks.courseid,marks.sectionid,a1,a2,a3,a4,q1,q2,q3,q4,m1,m2,project,final from assigned_students left join marks on assigned_students.studentid=marks.studentid where assigned_students.courseid= " + icbox.Text + " and (marks.courseid= " + icbox.Text + " or marks.courseid is null) and assigned_students.sectionid = " + sicb.Text, con);
                ds = new DataSet();
                adap.Fill(ds, "marks");
                megv.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {

            }
        }

        private void Seccbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            SqlCommand sc = new SqlCommand("select sectionid from section where sectionname = '" + seccbox.Text + "'", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("sectionid", typeof(string));
            dt.Load(reader);
            sicb.ValueMember = "sectionid";
            sicb.DisplayMember = "sectionid";
            sicb.DataSource = dt;
            conn.Close();
        }
        
        private void UpdateMarksGrid_Click(object sender, EventArgs e)
        {
            SqlDataAdapter b;
            b = new SqlDataAdapter("select * from marks where courseid = " + icbox.Text + "and sectionid = " + sicb.Text + " and studentid = '" + megv.SelectedCells[0].Value + "'", con);
            con = new SqlConnection();
            con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
            con.Open();
            SqlCommandBuilder cmdbl = new SqlCommandBuilder(b);
            b.Update(ds, "marks");
            MessageBox.Show("Data Updated Successfully");
        }

        private void MarkAttendanceButton_Click(object sender, EventArgs e)
        {
            SetWeightagePanel.Visible = true;
            mep.Visible = true;
            MarkAttendancePanel.Visible = true;
            ViewEvaluations.Visible = true;
            ViewGrades.Visible = false;

            try
            {
                con = new SqlConnection();
                con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
                con.Open();
                adap = new SqlDataAdapter("select * from attendance where attendance.courseid= " + icbox.Text + " and attendance.sectionid = " + sicb.Text + " and d= '" + datecombobox.Text + "'", con);
                ds = new DataSet();
                adap.Fill(ds, "marks");
                agv.DataSource = ds.Tables[0];

            }
            catch (Exception ex)
            {

            }
        }

        private void Mep_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Uab_Click(object sender, EventArgs e)
        {
            SqlDataAdapter b;
            b = new SqlDataAdapter("select * from attendance where courseid = " + icbox.Text + "and studentid = '" + agv.SelectedCells[0].Value + "'", con);
            con = new SqlConnection();
            con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
            con.Open();
            SqlCommandBuilder cmdbl = new SqlCommandBuilder(b);
            b.Update(ds, "marks");
            MessageBox.Show("Data Updated Successfully");
        }   

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewEvaluationsButton_Click(object sender, EventArgs e)
        {
            SetWeightagePanel.Visible = true;
            mep.Visible = true;
            MarkAttendancePanel.Visible = false;
            ViewEvaluations.Visible = true;
            ViewGrades.Visible = false;

            con = new SqlConnection();
            con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
            con.Open();
            adap = new SqlDataAdapter("select min(((m.a1*(a_weightage/4))/30)+((m.a2*(w.a_weightage/4))/30)+((m.a3*(w.a_weightage/4))/30)+((m.a4*(w.a_weightage/4))/30)+((m.q1*(w.q_weightage/4))/30)+((m.q2*(q_weightage/4))/30)+((m.q3*(q_weightage/4))/30)+((m.q4*(q_weightage/4))/30)+((m.m1*(m1_weightage))/50)+((m.m2*(m2_weightage))/50)+((m.project*project_weightage)/10)+((m.final*final_weightage)/100)) as Minimum, max(((m.a1*(a_weightage/4))/30)+((m.a2*(w.a_weightage/4))/30)+((m.a3*(w.a_weightage/4))/30)+((m.a4*(w.a_weightage/4))/30)+((m.q1*(w.q_weightage/4))/30)+((m.q2*(q_weightage/4))/30)+((m.q3*(q_weightage/4))/30)+((m.q4*(q_weightage/4))/30)+((m.m1*(m1_weightage))/50)+((m.m2*(m2_weightage))/50)+((m.project*project_weightage)/10)+((m.final*final_weightage)/100)) as Maximum, avg(((m.a1*(a_weightage/4))/30)+((m.a2*(w.a_weightage/4))/30)+((m.a3*(w.a_weightage/4))/30)+((m.a4*(w.a_weightage/4))/30)+((m.q1*(w.q_weightage/4))/30)+((m.q2*(q_weightage/4))/30)+((m.q3*(q_weightage/4))/30)+((m.q4*(q_weightage/4))/30)+((m.m1*(m1_weightage))/50)+((m.m2*(m2_weightage))/50)+((m.project*project_weightage)/10)+((m.final*final_weightage)/100)) as Average, 100 As Total from marks m,weightage w where m.courseid=w.courseid and m.courseid = " + icbox.Text + " and sectionid = " + sicb.Text, con);
            ds = new DataSet();
            adap.Fill(ds, "marks");
            agggview.DataSource = ds.Tables[0];


            con = new SqlConnection();
            con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
            con.Open();
            adap = new SqlDataAdapter("select m.studentid,m.courseid,((m.a1*(a_weightage/4))/30) as A1,((m.a2*(w.a_weightage/4))/30) as A2,((m.a3*(w.a_weightage/4))/30) as A3,((m.a4*(w.a_weightage/4))/30) as A4, ((m.q1*(w.q_weightage/4))/30) as Q1,((m.q2*(q_weightage/4))/30) as Q2,((m.q3*(q_weightage/4))/30) as Q3,((m.q4*(q_weightage/4))/30) as Q4,((m.m1*(m1_weightage))/50) as M1,((m.m2*(m2_weightage))/50) as M2,((m.project*project_weightage)/10) as Project,((m.final*final_weightage)/100) as Final,((m.a1*(a_weightage/4))/30)+((m.a2*(w.a_weightage/4))/30)+((m.a3*(w.a_weightage/4))/30)+((m.a4*(w.a_weightage/4))/30)+((m.q1*(w.q_weightage/4))/30)+((m.q2*(q_weightage/4))/30)+((m.q3*(q_weightage/4))/30)+((m.q4*(q_weightage/4))/30)+((m.m1*(m1_weightage))/50)+((m.m2*(m2_weightage))/50)+((m.project*project_weightage)/10)+((m.final*final_weightage)/100) as Total from marks m,weightage w where m.courseid=w.courseid and m.courseid = "  + icbox.Text + " and sectionid = " + sicb.Text, con);
            ds = new DataSet();
            adap.Fill(ds, "marks");
            evpanel.DataSource = ds.Tables[0];

        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            AdminPanel.Visible = false;
            TeacherPanel.Visible = false;
            AddStudentPanel.Visible = false;
            UsernameBox.Clear();
            PasswordBox.Clear();
        }

        private void TeacherPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            AdminPanel.Visible = false;
            TeacherPanel.Visible = false;
            StudentPanel.Visible = false;
            UsernameBox.Clear();
            PasswordBox.Clear();
        }

        private void ViewAttendanceButton_Click(object sender, EventArgs e)
        {
            SetWeightagePanel.Visible = true;
            mep.Visible = false;
            MarkAttendancePanel.Visible = false;
            ViewEvaluations.Visible = false;
            ViewGrades.Visible = false;

            con = new SqlConnection();
            con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
            con.Open();
            adap = new SqlDataAdapter("select m.studentid,m.courseid,((m.a1*(a_weightage/4))/30) as A1,((m.a2*(w.a_weightage/4))/30) as A2,((m.a3*(w.a_weightage/4))/30) as A3,((m.a4*(w.a_weightage/4))/30) as A4, ((m.q1*(w.q_weightage/4))/30) as Q1,((m.q2*(q_weightage/4))/30) as Q2,((m.q3*(q_weightage/4))/30) as Q3,((m.q4*(q_weightage/4))/30) as Q4,((m.m1*(m1_weightage))/50) as M1,((m.m2*(m2_weightage))/50) as M2,((m.project*project_weightage)/10) as Project,((m.final*final_weightage)/100) as Final,100 As Total from marks m,weightage w where m.courseid=w.courseid and m.courseid = " + icbox.Text + " and sectionid = " + sicb.Text, con);
            ds = new DataSet();
            adap.Fill(ds, "marks");
            evpanel.DataSource = ds.Tables[0];

        }

        private void ViewGrades_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewGradesButton_Click(object sender, EventArgs e)
        {
            SetWeightagePanel.Visible = true;
            mep.Visible = true;
            MarkAttendancePanel.Visible = true;
            ViewEvaluations.Visible = true;
            ViewGrades.Visible = true;

            con = new SqlConnection();
            con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
            con.Open();
            adap = new SqlDataAdapter("select studentid,coursegrade,gradepoint from grade where courseid = " + icbox.Text + " and sectionid = " + sicb.Text, con);
            ds = new DataSet();
            adap.Fill(ds, "marks");
            gview.DataSource = ds.Tables[0];
        }

        private void LO_Click(object sender, EventArgs e)
        {
            AdminPanel.Visible = false;
            TeacherPanel.Visible = false;
            StudentPanel.Visible = false;

            UsernameBox.Clear();
            PasswordBox.Clear();
        }

        private void Ssbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            SqlCommand sc = new SqlCommand("select distinct c.coursename from assigned_students t,course c where c.courseid=t.courseid  and semester = " + ssbox.Text + " and studentid = '" + UsernameBox.Text + "'", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("courseid", typeof(string));
            dt.Columns.Add("coursename", typeof(string));
            dt.Load(reader);
            scobox.ValueMember = "courseid";
            scobox.DisplayMember = "coursename";
            scobox.DataSource = dt;
            conn.Close();

            conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            sc = new SqlCommand("select s.sectionname from assigned_students t,course c,section s where c.courseid=t.courseid and t.sectionid=s.sectionid and c.coursename = '" + scobox.Text + "' and studentid = '" + UsernameBox.Text + "'", conn);
            reader = sc.ExecuteReader();
            dt = new DataTable();
            dt.Columns.Add("sectionid", typeof(string));
            dt.Columns.Add("sectionname", typeof(string));
            dt.Load(reader);
            ssecbox.ValueMember = "sectionid";
            ssecbox.DisplayMember = "sectionname";
            ssecbox.DataSource = dt;
            conn.Close();
        }

        private void Scobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            SqlCommand sc = new SqlCommand("select s.sectionname from assigned_students t,course c,section s where c.courseid=t.courseid and t.sectionid=s.sectionid and c.coursename = '" + scobox.Text + "' and studentid = '" + UsernameBox.Text + "'", conn);
            SqlDataReader reader;
            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("sectionid", typeof(string));
            dt.Columns.Add("sectionname", typeof(string));
            dt.Load(reader);
            ssidbox.ValueMember = "sectionid";
            ssidbox.DisplayMember = "sectionname";
            ssidbox.DataSource = dt;
            conn.Close();

            conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            sc = new SqlCommand("select c.courseid from course c where c.coursename = '" + scobox.Text + "'", conn);
            reader = sc.ExecuteReader();
            dt = new DataTable();
            dt.Columns.Add("courseid", typeof(string));
            dt.Load(reader);
            sidbox.ValueMember = "courseid";
            sidbox.DisplayMember = "courseid";
            sidbox.DataSource = dt;
            conn.Close();
        }

        private void Ssecbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            SqlCommand sc = new SqlCommand("select sectionid from section where sectionname = '" + ssecbox.Text + "'", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("sectionid", typeof(string));
            dt.Load(reader);
            ssidbox.ValueMember = "sectionid";
            ssidbox.DisplayMember = "sectionid";
            ssidbox.DataSource = dt;
            conn.Close();

        }

        private void StudentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewInfo_Click(object sender, EventArgs e)
        {
            SGPanel.Visible = true;
            SMPanel.Visible = false;
            acpanel.Visible = false;


            con = new SqlConnection();
            con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
            con.Open();
            adap = new SqlDataAdapter("select * from student where studentid = '" + UsernameBox.Text + "'", con);
            ds = new DataSet();
            adap.Fill(ds, "marks");
            SGrid.DataSource = ds.Tables[0];
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SGPanel.Visible = true;
            SMPanel.Visible = false;
            acpanel.Visible = false;
            con = new SqlConnection();
            con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
            con.Open();
            adap = new SqlDataAdapter("select studentid,d,status from attendance where studentid = '" + UsernameBox.Text + "' and courseid = " + sidbox.Text, con);
            ds = new DataSet();
            adap.Fill(ds, "marks");
            SGrid.DataSource = ds.Tables[0];
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SGPanel.Visible = true;
            SMPanel.Visible = true;
            acpanel.Visible = false;

            con = new SqlConnection();
            con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
            con.Open();
            adap = new SqlDataAdapter("select min(((m.a1*(a_weightage/4))/30)+((m.a2*(w.a_weightage/4))/30)+((m.a3*(w.a_weightage/4))/30)+((m.a4*(w.a_weightage/4))/30)+((m.q1*(w.q_weightage/4))/30)+((m.q2*(q_weightage/4))/30)+((m.q3*(q_weightage/4))/30)+((m.q4*(q_weightage/4))/30)+((m.m1*(m1_weightage))/50)+((m.m2*(m2_weightage))/50)+((m.project*project_weightage)/10)+((m.final*final_weightage)/100)) as Minimum, max(((m.a1*(a_weightage/4))/30)+((m.a2*(w.a_weightage/4))/30)+((m.a3*(w.a_weightage/4))/30)+((m.a4*(w.a_weightage/4))/30)+((m.q1*(w.q_weightage/4))/30)+((m.q2*(q_weightage/4))/30)+((m.q3*(q_weightage/4))/30)+((m.q4*(q_weightage/4))/30)+((m.m1*(m1_weightage))/50)+((m.m2*(m2_weightage))/50)+((m.project*project_weightage)/10)+((m.final*final_weightage)/100)) as Maximum, avg(((m.a1*(a_weightage/4))/30)+((m.a2*(w.a_weightage/4))/30)+((m.a3*(w.a_weightage/4))/30)+((m.a4*(w.a_weightage/4))/30)+((m.q1*(w.q_weightage/4))/30)+((m.q2*(q_weightage/4))/30)+((m.q3*(q_weightage/4))/30)+((m.q4*(q_weightage/4))/30)+((m.m1*(m1_weightage))/50)+((m.m2*(m2_weightage))/50)+((m.project*project_weightage)/10)+((m.final*final_weightage)/100)) as Average, 100 As Total from marks m,weightage w where m.courseid=w.courseid and m.courseid = " + sidbox.Text + " and sectionid = " + ssidbox.Text, con);
            ds = new DataSet();
            adap.Fill(ds, "marks");
            smtview.DataSource = ds.Tables[0];

            con = new SqlConnection();
            con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
            con.Open();
            adap = new SqlDataAdapter("select m.studentid,m.a1 as a1,((m.a1*(a_weightage/4))/30) as A1,m.a2 as a2,((m.a2*(w.a_weightage/4))/30) as A2,m.a3 as a3,((m.a3*(w.a_weightage/4))/30) as A3,m.a4 as a4,((m.a4*(w.a_weightage/4))/30) as A4,m.q1 as q1, ((m.q1*(w.q_weightage/4))/30) as Q1,m.q2 as q2,((m.q2*(q_weightage/4))/30) as Q2,m.q3 as q3,((m.q3*(q_weightage/4))/30) as Q3,m.q4 as q4,((m.q4*(q_weightage/4))/30) as Q4,m.m1 as m1,((m.m1*(m1_weightage))/50) as M1,m.m2 as m2,((m.m2*(m2_weightage))/50) as M2,m.a1 as project,((m.project*project_weightage)/10) as Project,m.final as final,((m.final*final_weightage)/100) as Final,((m.a1*(a_weightage/4))/30)+((m.a2*(w.a_weightage/4))/30)+((m.a3*(w.a_weightage/4))/30)+((m.a4*(w.a_weightage/4))/30)+((m.q1*(w.q_weightage/4))/30)+((m.q2*(q_weightage/4))/30)+((m.q3*(q_weightage/4))/30)+((m.q4*(q_weightage/4))/30)+((m.m1*(m1_weightage))/50)+((m.m2*(m2_weightage))/50)+((m.project*project_weightage)/10)+((m.final*final_weightage)/100) as Total from marks m,weightage w where m.courseid=w.courseid and m.courseid = " + sidbox.Text + " and sectionid = " + ssidbox.Text + " and studentid = '" + UsernameBox.Text + "'", con);
            ds = new DataSet();
            adap.Fill(ds, "marks");
            smiview.DataSource = ds.Tables[0];
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SGPanel.Visible = true;
            SMPanel.Visible = true;
            acpanel.Visible = false;

            con = new SqlConnection();
            con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
            con.Open();
            adap = new SqlDataAdapter("select g.studentid,(sum(g.gradepoint*c.credithours)/sum(c.credithours))as gpa from grade g,course c,student s where s.studentid=g.studentid and c.courseid=g.courseid and c.semester = " + ssbox.Text + " and g.studentid = '" + UsernameBox.Text +  "' group by g.studentid", con);
            ds = new DataSet();
            adap.Fill(ds, "marks");
            smtview.DataSource = ds.Tables[0];


            con = new SqlConnection();
            con.ConnectionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";
            con.Open();
            adap = new SqlDataAdapter("select studentid,coursegrade,gradepoint from  grade g where g.courseid = " + sidbox.Text + " and studentid = '" + UsernameBox.Text + "'", con);
            ds = new DataSet();
            adap.Fill(ds, "marks");
            smiview.DataSource = ds.Tables[0];
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            SGPanel.Visible = true;
            SMPanel.Visible = true;
            acpanel.Visible = true;

            SqlConnection conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            SqlCommand sc = new SqlCommand("select coursename from course where coursename not in (select c.coursename from assigned_students t, course c where t.courseid = c.courseid and studentid = '" + UsernameBox.Text + "')", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("courseid", typeof(string));
            dt.Columns.Add("coursename", typeof(string));
            dt.Load(reader);
            sacbox.ValueMember = "courseid";
            sacbox.DisplayMember = "coursename";
            sacbox.DataSource = dt;
            conn.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            string sql = null;

            connetionString = @"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True";

            sql = "insert into assigned_students values(@studentid,@courseid,@sectionid)";

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                try
                {
                    cnn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.Add("@studentid", SqlDbType.NVarChar).Value = UsernameBox.Text;
                        cmd.Parameters.Add("@courseid", SqlDbType.NVarChar).Value = ib.Text;
                        cmd.Parameters.Add("@sectionid", SqlDbType.NVarChar).Value = si.Text;
                        

                        int rowsAdded = cmd.ExecuteNonQuery();
                        if (rowsAdded > 0)
                        {
                            MessageBox.Show("Data Entered Successfully");
                            
                        }

                        else
                        {
                            
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:" + ex.Message);
                }
            }

        }

        private void Sacbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            SqlCommand sc = new SqlCommand("select c.courseid from course c where coursename = '" + sacbox.Text + "'" , conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("courseid", typeof(string));
            dt.Load(reader);
            ib.ValueMember = "courseid";
            ib.DisplayMember = "courseid";
            ib.DataSource = dt;
            conn.Close();
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = HASSAN\SQLSERVER2014; Initial Catalog = Final; Integrated Security = True");
            conn.Open();
            SqlCommand sc = new SqlCommand("select sectionid from section where sectionname = '" + sb.Text + "'", conn);
            SqlDataReader reader;

            reader = sc.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("sectionid", typeof(string));
            dt.Load(reader);
            si.ValueMember = "sectionid";
            si.DisplayMember = "sectionid";
            si.DataSource = dt;
            conn.Close();
        }

        private void Si_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


