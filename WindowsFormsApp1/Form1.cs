using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KataFunctions;
using System.Linq;

namespace WindowsFormsApp1
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
     List<Address> list = Helper.getAdresses();
      string test = Helper.printAddressFromFile();

      string tester = Helper.printAddress(3);

      string validate = Helper.isValid();
      
    }
  }
}
