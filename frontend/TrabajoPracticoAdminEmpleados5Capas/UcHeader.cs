using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrabajoPracticoAdminEmpleados5Capas
{
    public partial class UcHeader : UserControl
    {
        public UcHeader()
        {
            InitializeComponent();
            this.Height = 60;
        }

        [Category("UcHeader")]
        public string Titulo
        {
            get => lblTitulo.Text;
            set => lblTitulo.Text = value;
        }

        [Category("UcHeader")]
        public string Subtitulo
        {
            get => lblSubtitulo.Text;
            set => lblSubtitulo.Text = value;
        }

    }
}
