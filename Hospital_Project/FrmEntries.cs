using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Project
{
    public partial class Frm_Entries : Form
    {
        public Frm_Entries()
        {
            InitializeComponent();
        }


        // bu butona tıklandığında hasta giriş paneline gider.
        private void btnPatient_Click(object sender, EventArgs e)
        {
            Frm_Patient_Login patientLogin = new Frm_Patient_Login();
            patientLogin.Show();
            this.Hide();
        }

        // bu butona tıklandığında doktor giriş paneline gider.
        private void btnDoctor_Click(object sender, EventArgs e)
        {
            Frm_DoctorLogin doctorLogin = new Frm_DoctorLogin();
            doctorLogin.Show();
            this.Hide();
        }

        // bu butona tıklandığında sekreter giriş paneline gider.
        private void btnSecretary_Click(object sender, EventArgs e)
        {
            frm_Secretary_Login secretaryLogin = new frm_Secretary_Login();
            secretaryLogin.Show();
            this.Hide();
        }
    }
}
