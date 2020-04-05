namespace BindingDemo
{
    partial class FormBindingText
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.btnChangeBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtStudentNameFilter = new System.Windows.Forms.TextBox();
            this.txtTeacherNameFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentStudent = new System.Windows.Forms.TextBox();
            this.txtCurrentTeacher = new System.Windows.Forms.TextBox();
            this.lstStudent = new System.Windows.Forms.ListBox();
            this.dgvTeacher = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnXmlSerialize = new System.Windows.Forms.Button();
            this.btnObjFromXml = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(171, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(171, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "UpdateSource";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Display Source";
            // 
            // btnChangeName
            // 
            this.btnChangeName.Location = new System.Drawing.Point(46, 30);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(103, 23);
            this.btnChangeName.TabIndex = 4;
            this.btnChangeName.Text = "ChangeName";
            this.btnChangeName.UseVisualStyleBackColor = true;
            this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
            // 
            // btnChangeBack
            // 
            this.btnChangeBack.Location = new System.Drawing.Point(171, 30);
            this.btnChangeBack.Name = "btnChangeBack";
            this.btnChangeBack.Size = new System.Drawing.Size(103, 23);
            this.btnChangeBack.TabIndex = 5;
            this.btnChangeBack.Text = "ChangeBack";
            this.btnChangeBack.UseVisualStyleBackColor = true;
            this.btnChangeBack.Click += new System.EventHandler(this.btnChangeBack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.btnChangeBack);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnChangeName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 182);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BasicTest";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtStudentNameFilter);
            this.groupBox2.Controls.Add(this.txtTeacherNameFilter);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCurrentStudent);
            this.groupBox2.Controls.Add(this.txtCurrentTeacher);
            this.groupBox2.Controls.Add(this.lstStudent);
            this.groupBox2.Controls.Add(this.dgvTeacher);
            this.groupBox2.Location = new System.Drawing.Point(363, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 351);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AdvanceTest";
            // 
            // txtStudentNameFilter
            // 
            this.txtStudentNameFilter.Location = new System.Drawing.Point(206, 161);
            this.txtStudentNameFilter.Name = "txtStudentNameFilter";
            this.txtStudentNameFilter.Size = new System.Drawing.Size(325, 21);
            this.txtStudentNameFilter.TabIndex = 10;
            this.txtStudentNameFilter.TextChanged += new System.EventHandler(this.txtStudentNameFilter_TextChanged);
            // 
            // txtTeacherNameFilter
            // 
            this.txtTeacherNameFilter.Location = new System.Drawing.Point(206, 20);
            this.txtTeacherNameFilter.Name = "txtTeacherNameFilter";
            this.txtTeacherNameFilter.Size = new System.Drawing.Size(325, 21);
            this.txtTeacherNameFilter.TabIndex = 9;
            this.txtTeacherNameFilter.TextChanged += new System.EventHandler(this.txtTeacherNameFilter_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "filter:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "filter:";
            // 
            // txtCurrentStudent
            // 
            this.txtCurrentStudent.Location = new System.Drawing.Point(14, 161);
            this.txtCurrentStudent.Name = "txtCurrentStudent";
            this.txtCurrentStudent.Size = new System.Drawing.Size(118, 21);
            this.txtCurrentStudent.TabIndex = 6;
            // 
            // txtCurrentTeacher
            // 
            this.txtCurrentTeacher.Location = new System.Drawing.Point(14, 20);
            this.txtCurrentTeacher.Name = "txtCurrentTeacher";
            this.txtCurrentTeacher.Size = new System.Drawing.Size(118, 21);
            this.txtCurrentTeacher.TabIndex = 5;
            // 
            // lstStudent
            // 
            this.lstStudent.FormattingEnabled = true;
            this.lstStudent.ItemHeight = 12;
            this.lstStudent.Location = new System.Drawing.Point(14, 193);
            this.lstStudent.Name = "lstStudent";
            this.lstStudent.Size = new System.Drawing.Size(517, 136);
            this.lstStudent.TabIndex = 4;
            // 
            // dgvTeacher
            // 
            this.dgvTeacher.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTeacher.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTeacher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeacher.Location = new System.Drawing.Point(14, 49);
            this.dgvTeacher.Name = "dgvTeacher";
            this.dgvTeacher.Size = new System.Drawing.Size(517, 107);
            this.dgvTeacher.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnObjFromXml);
            this.groupBox3.Controls.Add(this.btnXmlSerialize);
            this.groupBox3.Location = new System.Drawing.Point(13, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 158);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "XmlSerialize/UnXmlSerialize";
            // 
            // btnXmlSerialize
            // 
            this.btnXmlSerialize.Location = new System.Drawing.Point(45, 42);
            this.btnXmlSerialize.Name = "btnXmlSerialize";
            this.btnXmlSerialize.Size = new System.Drawing.Size(103, 23);
            this.btnXmlSerialize.TabIndex = 0;
            this.btnXmlSerialize.Text = "XmlSerialize";
            this.btnXmlSerialize.UseVisualStyleBackColor = true;
            this.btnXmlSerialize.Click += new System.EventHandler(this.btnXmlSerialize_Click);
            // 
            // btnObjFromXml
            // 
            this.btnObjFromXml.Location = new System.Drawing.Point(170, 42);
            this.btnObjFromXml.Name = "btnObjFromXml";
            this.btnObjFromXml.Size = new System.Drawing.Size(103, 23);
            this.btnObjFromXml.TabIndex = 1;
            this.btnObjFromXml.Text = "ObjFromXml";
            this.btnObjFromXml.UseVisualStyleBackColor = true;
            this.btnObjFromXml.Click += new System.EventHandler(this.btnObjFromXml_Click);
            // 
            // FormBindingText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 391);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormBindingText";
            this.Text = "FormBindingText";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeacher)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.Button btnChangeBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvTeacher;
        private System.Windows.Forms.ListBox lstStudent;
        private System.Windows.Forms.TextBox txtCurrentStudent;
        private System.Windows.Forms.TextBox txtCurrentTeacher;
        private System.Windows.Forms.TextBox txtStudentNameFilter;
        private System.Windows.Forms.TextBox txtTeacherNameFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnXmlSerialize;
        private System.Windows.Forms.Button btnObjFromXml;
    }
}

