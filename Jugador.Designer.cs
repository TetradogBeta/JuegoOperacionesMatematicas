namespace Operacions
{
    partial class Jugador
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelRedimensionable1 = new Operacions.PanelRedimensionable();
            this.nivellJugador1 = new Operacions.NivellJugador();
            this.fotoJugador1 = new Operacions.FotoJugador();
            this.vidaCircular1 = new Operacions.VidaCircular();
            this.panelRedimensionable1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRedimensionable1
            // 
            this.panelRedimensionable1.Controls.Add(this.nivellJugador1);
            this.panelRedimensionable1.Controls.Add(this.fotoJugador1);
            this.panelRedimensionable1.Controls.Add(this.vidaCircular1);
            this.panelRedimensionable1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRedimensionable1.Location = new System.Drawing.Point(0, 0);
            this.panelRedimensionable1.MantenirProporcionsControl = true;
            this.panelRedimensionable1.Name = "panelRedimensionable1";
            this.panelRedimensionable1.Size = new System.Drawing.Size(281, 215);
            this.panelRedimensionable1.TabIndex = 0;
            // 
            // nivellJugador1
            // 
            this.nivellJugador1.BackColor = System.Drawing.Color.Transparent;
            this.nivellJugador1.Location = new System.Drawing.Point(15, 14);
            this.nivellJugador1.Name = "nivellJugador1";
            this.nivellJugador1.Nivell = 0;
            this.nivellJugador1.Size = new System.Drawing.Size(85, 85);
            this.nivellJugador1.TabIndex = 2;
            // 
            // fotoJugador1
            // 
            this.fotoJugador1.Imatge = null;
            this.fotoJugador1.Location = new System.Drawing.Point(206, 27);
            this.fotoJugador1.Name = "fotoJugador1";
            this.fotoJugador1.Size = new System.Drawing.Size(62, 62);
            this.fotoJugador1.TabIndex = 1;
            // 
            // vidaCircular1
            // 
            this.vidaCircular1.BackColor = System.Drawing.Color.Transparent;
            this.vidaCircular1.Location = new System.Drawing.Point(146, 0);
            this.vidaCircular1.Name = "vidaCircular1";
            this.vidaCircular1.Size = new System.Drawing.Size(177, 109);
            this.vidaCircular1.TabIndex = 0;
            this.vidaCircular1.Vida = 100;
            // 
            // Jugador
            // 
            this.Controls.Add(this.panelRedimensionable1);
            this.Name = "Jugador";
            this.Size = new System.Drawing.Size(281, 215);
            this.panelRedimensionable1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelRedimensionable panelRedimensionable1;
        private NivellJugador nivellJugador1;
        private FotoJugador fotoJugador1;
        private VidaCircular vidaCircular1;




    }
}
