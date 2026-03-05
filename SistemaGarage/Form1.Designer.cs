
namespace SistemaGarage
{
    partial class btnHistorial
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(btnHistorial));
            label1 = new Label();
            txtPlaca = new TextBox();
            button1 = new Button();
            dgvVehiculos = new DataGridView();
            label2 = new Label();
            txtPlacaSalida = new TextBox();
            btnSalida = new Button();
            button2 = new Button();
            lblGanancias = new Label();
            button3 = new Button();
            ticketImpresora = new System.Drawing.Printing.PrintDocument();
            vistaPrevia = new PrintPreviewDialog();
            dtpFecha = new DateTimePicker();
            btnExportar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 72);
            label1.Name = "label1";
            label1.Size = new Size(82, 15);
            label1.TabIndex = 0;
            label1.Text = "Ingrese Placa: ";
            label1.Click += label1_Click;
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(143, 70);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(100, 23);
            txtPlaca.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(249, 70);
            button1.Name = "button1";
            button1.Size = new Size(159, 23);
            button1.TabIndex = 2;
            button1.Text = "Registrar Entrada";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dgvVehiculos
            // 
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehiculos.Location = new Point(55, 117);
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.Size = new Size(735, 288);
            dgvVehiculos.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(431, 74);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 4;
            label2.Text = "Salida de Vehículo:";
            label2.Click += label2_Click;
            // 
            // txtPlacaSalida
            // 
            txtPlacaSalida.Location = new Point(542, 69);
            txtPlacaSalida.Name = "txtPlacaSalida";
            txtPlacaSalida.Size = new Size(100, 23);
            txtPlacaSalida.TabIndex = 5;
            // 
            // btnSalida
            // 
            btnSalida.Location = new Point(648, 69);
            btnSalida.Name = "btnSalida";
            btnSalida.Size = new Size(142, 23);
            btnSalida.TabIndex = 6;
            btnSalida.Text = "COBRAR / SALIDA";
            btnSalida.UseVisualStyleBackColor = true;
            btnSalida.Click += btnSalida_Click;
            // 
            // button2
            // 
            button2.Location = new Point(55, 415);
            button2.Name = "button2";
            button2.Size = new Size(206, 23);
            button2.TabIndex = 7;
            button2.Text = "Ver Historial de Hoy";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // lblGanancias
            // 
            lblGanancias.AutoSize = true;
            lblGanancias.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGanancias.Location = new Point(277, 420);
            lblGanancias.Name = "lblGanancias";
            lblGanancias.Size = new Size(116, 15);
            lblGanancias.TabIndex = 8;
            lblGanancias.Text = "Total Ganado: $0.00";
            // 
            // button3
            // 
            button3.Location = new Point(604, 416);
            button3.Name = "button3";
            button3.Size = new Size(186, 23);
            button3.TabIndex = 9;
            button3.Text = "Ver Autos en Garage";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ticketImpresora
            // 
            ticketImpresora.PrintPage += ticketImpresora_PrintPage;
            // 
            // vistaPrevia
            // 
            vistaPrevia.AutoScrollMargin = new Size(0, 0);
            vistaPrevia.AutoScrollMinSize = new Size(0, 0);
            vistaPrevia.ClientSize = new Size(400, 300);
            vistaPrevia.Document = ticketImpresora;
            vistaPrevia.Enabled = true;
            vistaPrevia.Icon = (Icon)resources.GetObject("vistaPrevia.Icon");
            vistaPrevia.Name = "vistaPrevia";
            vistaPrevia.Visible = false;
            vistaPrevia.Load += vistaPrevia_Load;
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(739, 2);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(99, 23);
            dtpFecha.TabIndex = 10;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(12, 4);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(148, 23);
            btnExportar.TabIndex = 11;
            btnExportar.Text = "Exportar a Excel";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // btnHistorial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(840, 450);
            Controls.Add(btnExportar);
            Controls.Add(dtpFecha);
            Controls.Add(button3);
            Controls.Add(lblGanancias);
            Controls.Add(button2);
            Controls.Add(btnSalida);
            Controls.Add(txtPlacaSalida);
            Controls.Add(label2);
            Controls.Add(dgvVehiculos);
            Controls.Add(button1);
            Controls.Add(txtPlaca);
            Controls.Add(label1);
            Name = "btnHistorial";
            Text = "Sistema Estacionamiento";
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label label1;
        private TextBox txtPlaca;
        private Button button1;
        private DataGridView dgvVehiculos;
        private Label label2;
        private TextBox txtPlacaSalida;
        private Button btnSalida;
        private Button button2;
        private Label lblGanancias;
        private Button button3;
        private System.Drawing.Printing.PrintDocument ticketImpresora;
        private PrintPreviewDialog vistaPrevia;
        private DateTimePicker dtpFecha;
        private Button btnExportar;
    }
}
