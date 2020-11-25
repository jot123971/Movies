using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoviesforRent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Hp\Documents\Moviesforrent.mdf;Integrated Security=True;Connect Timeout=30;");

        private void Form1_Load(object sender, EventArgs e)
        {
            Getrentalrecordscustmer();
            Getrentalrecordsmovies();
            Getrentalrecords();
        }

        private void Cleartextbox()
        {
            CIDBox.Clear();
            CFNBox.Clear();
            CSNBox.Clear();
            CABox.Clear();
            CMBox.Clear();

            MIDBox.Clear();
            MNBox.Clear();
            MRBox.Clear();
            MGBox.Clear();
            MCBox.Clear();
            MPBox.Clear();
            MRentBox.Clear();
            MRDBox.Clear();

            RMIDBox.Clear();
            CRIDBox.Clear();
            MRIDBox.Clear();
            RentDBox.Clear();
            ReturnDBox.Clear();

            CIDBox.Focus();
        }

        private void Getrentalrecordscustmer()
        {
           

            SqlCommand cmd = new SqlCommand("Select * from Cdetail", con);

            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            con.Close();

            Cgridview.DataSource = dt;

        }

        private void Getrentalrecordsmovies()
        {


            SqlCommand cmd = new SqlCommand("Select * from Mdetail", con);

            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            con.Close();

            Mgridview.DataSource = dt;

        }

        private void Getrentalrecords()
        {


            SqlCommand cmd = new SqlCommand("Select * from Rdetail", con);

            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);

            con.Close();

            Rgridview.DataSource = dt;

        }

        private void CAddBtn_Click(object sender, EventArgs e)
        {
            if (IsValid())

            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Cdetail VALUES(@cid,@fname,@sname,@address,@mob)", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cid", CIDBox.Text);
                cmd.Parameters.AddWithValue("@fname", CFNBox.Text);
                cmd.Parameters.AddWithValue("@sname", CSNBox.Text);
                cmd.Parameters.AddWithValue("@address", CABox.Text);
                cmd.Parameters.AddWithValue("@mob", CMBox.Text);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Done");
                Getrentalrecordscustmer();
                Cleartextbox();
            }
        }

       

        private bool IsValid()
        {

            if (CIDBox.Text == string.Empty)
            { 
            MessageBox.Show("Fields are Empty");
            return false;
        }

        return true;

        }

        private void CDeleteBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Cdetail  WHERE CMRId=@cid", con);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@cid", CIDBox.Text);
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Done");
            Getrentalrecordscustmer();
            Cleartextbox();
        }

        private void CUpdateBtn_Click(object sender, EventArgs e)
        {
            if (CIDBox.Text != "")

            {
                SqlCommand cmd = new SqlCommand("UPDATE  Cdetail SET CMRId= @cid, FstName = @fname, Surname = @sname, AddressInfo= @address, Mob_no= @mob WHERE CMRId=@cid", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cid", CIDBox.Text);
                cmd.Parameters.AddWithValue("@fname", CFNBox.Text);
                cmd.Parameters.AddWithValue("@sname", CSNBox.Text);
                cmd.Parameters.AddWithValue("@address", CABox.Text);
                cmd.Parameters.AddWithValue("@mob", CMBox.Text);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Done");
                Getrentalrecordscustmer();
                Cleartextbox();
            }
            else
            {
                MessageBox.Show("Try Again");
            }
        }

        private void MAddBtn_Click(object sender, EventArgs e)
        {

            if (IsValidate())

            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Mdetail VALUES(@mid,@mname,@mrat,@mgen,@mcpy,@mplt,@mrent,@mrd)", con);
                
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@mid", MIDBox.Text);
                cmd.Parameters.AddWithValue("@mname", MNBox.Text);
                cmd.Parameters.AddWithValue("@mrat", MRBox.Text);
                cmd.Parameters.AddWithValue("@mgen", MGBox.Text);
                cmd.Parameters.AddWithValue("@mcpy", MCBox.Text);
                cmd.Parameters.AddWithValue("@mplt", MPBox.Text);
                cmd.Parameters.AddWithValue("@mrent", MRentBox.Text);
                cmd.Parameters.AddWithValue("@mrd", MRDBox.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
               
                MessageBox.Show("Done");
                Getrentalrecordsmovies();
                Cleartextbox();
            }
        }



        private bool IsValidate()
        {

            if (MIDBox.Text == string.Empty)
            {
                MessageBox.Show("Fields are Empty");
                return false;
            }

            return true;

        }

        private void MDeleteBtn_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Mdetail  WHERE MVSId=@mid", con);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@mid", MIDBox.Text);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Done");
            Getrentalrecordsmovies();
            Cleartextbox();
        }

        private void MUpdateBtn_Click(object sender, EventArgs e)
        {
            if (MIDBox.Text != "")

            {
SqlCommand cmd = new SqlCommand("UPDATE  Mdetail SET MVSId= @mid, MName= @mname, MRating= @mrat, MGenre= @mgen, Cavailable= @mcpy, MPlot= @mplt, CostForR= @mrent, MRelase_Date= @mrd WHERE MVSId=@mid", con);

cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@mid", MIDBox.Text);
                cmd.Parameters.AddWithValue("@mname", MNBox.Text);
                cmd.Parameters.AddWithValue("@mrat", MRBox.Text);
                cmd.Parameters.AddWithValue("@mgen", MGBox.Text);
                cmd.Parameters.AddWithValue("@mcpy", MCBox.Text);
                cmd.Parameters.AddWithValue("@mplt", MPBox.Text);
                cmd.Parameters.AddWithValue("@mrent", MRentBox.Text);
                cmd.Parameters.AddWithValue("@mrd", MRDBox.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Done");
                Getrentalrecordsmovies();
                Cleartextbox();
            }
            else
            {
                MessageBox.Show("Try Again");
            }
        }

        private void MIssueBtn_Click(object sender, EventArgs e)
        {

            if (IsValidR())

            {
SqlCommand cmd = new SqlCommand("INSERT INTO Rdetail VALUES(@rmid,@cridbox,@mridbox,@rentdbox,@retdbox)", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@rmid", RMIDBox.Text);
                cmd.Parameters.AddWithValue("@cridbox", CRIDBox.Text);
                cmd.Parameters.AddWithValue("@mridbox", MRIDBox.Text);
                cmd.Parameters.AddWithValue("@rentdbox", RentDBox.Text);
                cmd.Parameters.AddWithValue("@retdbox", ReturnDBox.Text);
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Done");
                Getrentalrecords();
                Cleartextbox();
            }
        }



        private bool IsValidR()
        {

            if (RMIDBox.Text == string.Empty)
            {
                MessageBox.Show("Fields are Empty");
                return false;
            }

            return true;

        }

        private void MReturnBtn_Click(object sender, EventArgs e)
        {
            if (RMIDBox.Text != "")

            {
SqlCommand cmd = new SqlCommand("UPDATE  Rdetail SET RMId= @rmid, Datereturn= @retdbox WHERE RMId=@rmid", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@rmid", RMIDBox.Text);                
                cmd.Parameters.AddWithValue("@retdbox", ReturnDBox.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Done");
                Getrentalrecords();
                Cleartextbox();
            }
            else
            {
                MessageBox.Show("Try Again");
            }
        }

        private void totalrmovies_CheckedChanged(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("Select RMId, FstName, AddressInfo, MName, CostForR, Daterent, Datereturn from Rdetail JOIN Cdetail ON Rdetail.CMRId = Cdetail.CMRId JOIN Mdetail ON Mdetail.MVSId=Rdetail.MVSId", con);

            sda.Fill(dt);
            Rgridview.DataSource = dt;
            con.Close();
        }

        private void presentlyout_CheckedChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select RMId, FstName, AddressInfo, MName, CostForR, Daterent, Datereturn from Rdetail JOIN Cdetail ON Rdetail.CMRId = Cdetail.CMRId JOIN Mdetail ON Mdetail.MVSId=Rdetail.MVSId where Rdetail.datereturn=''", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Rgridview.DataSource = dt;
        }

        private void HighRatedmovies_CheckedChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Mdetail Where MRating=(select max (MRating) from Mdetail)", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Mgridview.DataSource = dt;
        }
    }
}
