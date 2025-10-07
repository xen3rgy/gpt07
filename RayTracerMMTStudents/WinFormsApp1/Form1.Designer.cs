namespace WinFormsApp1
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBoxLookFrom = new TextBox();
            textBoxLookAt = new TextBox();
            textBoxLookUp = new TextBox();
            treeView1 = new TreeView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItemMesh = new ToolStripMenuItem();
            sphereToolStripMenuItem = new ToolStripMenuItem();
            lightToolStripMenuItem = new ToolStripMenuItem();
            pointToolStripMenuItem = new ToolStripMenuItem();
            directionalToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            labelObject = new Label();
            labelPosition = new Label();
            labelRotation = new Label();
            textBoxPosition = new TextBox();
            textBoxRotation = new TextBox();
            textBoxName = new TextBox();
            labelName = new Label();
            labelColor = new Label();
            labelSpecular = new Label();
            textBoxColor = new TextBox();
            textBoxSpecular = new TextBox();
            labelMaterial = new Label();
            labelScene = new Label();
            labelLight = new Label();
            labelLightColor = new Label();
            labelLightIntensity = new Label();
            textBoxLightColor = new TextBox();
            textBoxLightIntensity = new TextBox();
            labelLightDirection = new Label();
            textBoxLightDirection = new TextBox();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            labelRadius = new Label();
            textBoxRadius = new TextBox();
            labelFoV = new Label();
            textBoxFoV = new TextBox();
            labelScale = new Label();
            textBoxScale = new TextBox();
            labelReflective = new Label();
            textBoxReflective = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(1384, 925);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(143, 67);
            button1.TabIndex = 0;
            button1.Text = "Render";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(247, 111);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1280, 720);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(247, 898);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(1107, 114);
            textBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(1583, 64);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(76, 25);
            label1.TabIndex = 6;
            label1.Text = "Camera";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1583, 111);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(93, 25);
            label2.TabIndex = 7;
            label2.Text = "LookFrom";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1583, 153);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(69, 25);
            label3.TabIndex = 8;
            label3.Text = "LookAt";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1583, 201);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(35, 25);
            label4.TabIndex = 9;
            label4.Text = "Up";
            // 
            // textBoxLookFrom
            // 
            textBoxLookFrom.Location = new Point(1719, 103);
            textBoxLookFrom.Margin = new Padding(4, 3, 4, 3);
            textBoxLookFrom.Name = "textBoxLookFrom";
            textBoxLookFrom.Size = new Size(155, 31);
            textBoxLookFrom.TabIndex = 10;
            // 
            // textBoxLookAt
            // 
            textBoxLookAt.Location = new Point(1719, 150);
            textBoxLookAt.Margin = new Padding(4, 3, 4, 3);
            textBoxLookAt.Name = "textBoxLookAt";
            textBoxLookAt.Size = new Size(155, 31);
            textBoxLookAt.TabIndex = 11;
            // 
            // textBoxLookUp
            // 
            textBoxLookUp.Location = new Point(1719, 198);
            textBoxLookUp.Margin = new Padding(4, 3, 4, 3);
            textBoxLookUp.Name = "textBoxLookUp";
            textBoxLookUp.Size = new Size(155, 31);
            textBoxLookUp.TabIndex = 12;
            // 
            // treeView1
            // 
            treeView1.ContextMenuStrip = contextMenuStrip1;
            treeView1.Location = new Point(15, 111);
            treeView1.Margin = new Padding(4, 3, 4, 3);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(202, 901);
            treeView1.TabIndex = 13;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItemMesh, lightToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(135, 100);
            // 
            // toolStripMenuItemMesh
            // 
            toolStripMenuItemMesh.DropDownItems.AddRange(new ToolStripItem[] { sphereToolStripMenuItem });
            toolStripMenuItemMesh.Name = "toolStripMenuItemMesh";
            toolStripMenuItemMesh.Size = new Size(134, 32);
            toolStripMenuItemMesh.Text = "Mesh";
            // 
            // sphereToolStripMenuItem
            // 
            sphereToolStripMenuItem.Name = "sphereToolStripMenuItem";
            sphereToolStripMenuItem.Size = new Size(169, 34);
            sphereToolStripMenuItem.Text = "Sphere";
            sphereToolStripMenuItem.Click += sphereToolStripMenuItem_Click;
            // 
            // lightToolStripMenuItem
            // 
            lightToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pointToolStripMenuItem, directionalToolStripMenuItem });
            lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            lightToolStripMenuItem.Size = new Size(134, 32);
            lightToolStripMenuItem.Text = "Light";
            // 
            // pointToolStripMenuItem
            // 
            pointToolStripMenuItem.Name = "pointToolStripMenuItem";
            pointToolStripMenuItem.Size = new Size(198, 34);
            pointToolStripMenuItem.Text = "Point";
            pointToolStripMenuItem.Click += pointToolStripMenuItem_Click;
            // 
            // directionalToolStripMenuItem
            // 
            directionalToolStripMenuItem.Name = "directionalToolStripMenuItem";
            directionalToolStripMenuItem.Size = new Size(198, 34);
            directionalToolStripMenuItem.Text = "Directional";
            directionalToolStripMenuItem.Click += directionalToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(134, 32);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // labelObject
            // 
            labelObject.AutoSize = true;
            labelObject.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelObject.Location = new Point(1583, 312);
            labelObject.Margin = new Padding(4, 0, 4, 0);
            labelObject.Name = "labelObject";
            labelObject.Size = new Size(68, 25);
            labelObject.TabIndex = 14;
            labelObject.Text = "Object";
            // 
            // labelPosition
            // 
            labelPosition.AutoSize = true;
            labelPosition.Location = new Point(1583, 407);
            labelPosition.Margin = new Padding(4, 0, 4, 0);
            labelPosition.Name = "labelPosition";
            labelPosition.Size = new Size(75, 25);
            labelPosition.TabIndex = 15;
            labelPosition.Text = "Position";
            // 
            // labelRotation
            // 
            labelRotation.AutoSize = true;
            labelRotation.Location = new Point(1583, 467);
            labelRotation.Margin = new Padding(4, 0, 4, 0);
            labelRotation.Name = "labelRotation";
            labelRotation.Size = new Size(89, 25);
            labelRotation.TabIndex = 16;
            labelRotation.Text = "(Rotation)";
            // 
            // textBoxPosition
            // 
            textBoxPosition.Location = new Point(1719, 407);
            textBoxPosition.Margin = new Padding(4, 3, 4, 3);
            textBoxPosition.Name = "textBoxPosition";
            textBoxPosition.Size = new Size(155, 31);
            textBoxPosition.TabIndex = 17;
            // 
            // textBoxRotation
            // 
            textBoxRotation.Location = new Point(1719, 463);
            textBoxRotation.Margin = new Padding(4, 3, 4, 3);
            textBoxRotation.Name = "textBoxRotation";
            textBoxRotation.Size = new Size(155, 31);
            textBoxRotation.TabIndex = 18;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(1719, 352);
            textBoxName.Margin = new Padding(4, 3, 4, 3);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(155, 31);
            textBoxName.TabIndex = 19;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(1583, 360);
            labelName.Margin = new Padding(4, 0, 4, 0);
            labelName.Name = "labelName";
            labelName.Size = new Size(59, 25);
            labelName.TabIndex = 20;
            labelName.Text = "Name";
            // 
            // labelColor
            // 
            labelColor.AutoSize = true;
            labelColor.Location = new Point(1583, 670);
            labelColor.Margin = new Padding(4, 0, 4, 0);
            labelColor.Name = "labelColor";
            labelColor.Size = new Size(55, 25);
            labelColor.TabIndex = 21;
            labelColor.Text = "Color";
            // 
            // labelSpecular
            // 
            labelSpecular.AutoSize = true;
            labelSpecular.Location = new Point(1583, 722);
            labelSpecular.Margin = new Padding(4, 0, 4, 0);
            labelSpecular.Name = "labelSpecular";
            labelSpecular.Size = new Size(79, 25);
            labelSpecular.TabIndex = 22;
            labelSpecular.Text = "Specular";
            // 
            // textBoxColor
            // 
            textBoxColor.Location = new Point(1713, 665);
            textBoxColor.Margin = new Padding(4, 3, 4, 3);
            textBoxColor.Name = "textBoxColor";
            textBoxColor.Size = new Size(155, 31);
            textBoxColor.TabIndex = 23;
            // 
            // textBoxSpecular
            // 
            textBoxSpecular.Location = new Point(1713, 717);
            textBoxSpecular.Margin = new Padding(4, 3, 4, 3);
            textBoxSpecular.Name = "textBoxSpecular";
            textBoxSpecular.Size = new Size(155, 31);
            textBoxSpecular.TabIndex = 24;
            // 
            // labelMaterial
            // 
            labelMaterial.AutoSize = true;
            labelMaterial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelMaterial.Location = new Point(1583, 624);
            labelMaterial.Margin = new Padding(4, 0, 4, 0);
            labelMaterial.Name = "labelMaterial";
            labelMaterial.Size = new Size(83, 25);
            labelMaterial.TabIndex = 25;
            labelMaterial.Text = "Material";
            // 
            // labelScene
            // 
            labelScene.AutoSize = true;
            labelScene.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelScene.Location = new Point(17, 64);
            labelScene.Margin = new Padding(4, 0, 4, 0);
            labelScene.Name = "labelScene";
            labelScene.Size = new Size(62, 25);
            labelScene.TabIndex = 26;
            labelScene.Text = "Scene";
            // 
            // labelLight
            // 
            labelLight.AutoSize = true;
            labelLight.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelLight.Location = new Point(1583, 826);
            labelLight.Margin = new Padding(4, 0, 4, 0);
            labelLight.Name = "labelLight";
            labelLight.Size = new Size(55, 25);
            labelLight.TabIndex = 27;
            labelLight.Text = "Light";
            // 
            // labelLightColor
            // 
            labelLightColor.AutoSize = true;
            labelLightColor.Location = new Point(1583, 881);
            labelLightColor.Margin = new Padding(4, 0, 4, 0);
            labelLightColor.Name = "labelLightColor";
            labelLightColor.Size = new Size(55, 25);
            labelLightColor.TabIndex = 28;
            labelLightColor.Text = "Color";
            // 
            // labelLightIntensity
            // 
            labelLightIntensity.AutoSize = true;
            labelLightIntensity.Location = new Point(1583, 928);
            labelLightIntensity.Margin = new Padding(4, 0, 4, 0);
            labelLightIntensity.Name = "labelLightIntensity";
            labelLightIntensity.Size = new Size(79, 25);
            labelLightIntensity.TabIndex = 29;
            labelLightIntensity.Text = "Intensity";
            // 
            // textBoxLightColor
            // 
            textBoxLightColor.Location = new Point(1713, 868);
            textBoxLightColor.Margin = new Padding(4, 3, 4, 3);
            textBoxLightColor.Name = "textBoxLightColor";
            textBoxLightColor.Size = new Size(155, 31);
            textBoxLightColor.TabIndex = 30;
            // 
            // textBoxLightIntensity
            // 
            textBoxLightIntensity.Location = new Point(1713, 914);
            textBoxLightIntensity.Margin = new Padding(4, 3, 4, 3);
            textBoxLightIntensity.Name = "textBoxLightIntensity";
            textBoxLightIntensity.Size = new Size(155, 31);
            textBoxLightIntensity.TabIndex = 31;
            // 
            // labelLightDirection
            // 
            labelLightDirection.AutoSize = true;
            labelLightDirection.Location = new Point(1583, 974);
            labelLightDirection.Margin = new Padding(4, 0, 4, 0);
            labelLightDirection.Name = "labelLightDirection";
            labelLightDirection.Size = new Size(83, 25);
            labelLightDirection.TabIndex = 32;
            labelLightDirection.Text = "Direction";
            // 
            // textBoxLightDirection
            // 
            textBoxLightDirection.Location = new Point(1713, 961);
            textBoxLightDirection.Margin = new Padding(4, 3, 4, 3);
            textBoxLightDirection.Name = "textBoxLightDirection";
            textBoxLightDirection.Size = new Size(155, 31);
            textBoxLightDirection.TabIndex = 33;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(1898, 35);
            menuStrip1.TabIndex = 34;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { exportToolStripMenuItem, exitToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(54, 29);
            toolStripMenuItem1.Text = "File";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(165, 34);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(165, 34);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // labelRadius
            // 
            labelRadius.AutoSize = true;
            labelRadius.Location = new Point(1583, 568);
            labelRadius.Margin = new Padding(4, 0, 4, 0);
            labelRadius.Name = "labelRadius";
            labelRadius.Size = new Size(65, 25);
            labelRadius.TabIndex = 35;
            labelRadius.Text = "Radius";
            // 
            // textBoxRadius
            // 
            textBoxRadius.Location = new Point(1719, 565);
            textBoxRadius.Margin = new Padding(4, 3, 4, 3);
            textBoxRadius.Name = "textBoxRadius";
            textBoxRadius.Size = new Size(155, 31);
            textBoxRadius.TabIndex = 36;
            // 
            // labelFoV
            // 
            labelFoV.AutoSize = true;
            labelFoV.Location = new Point(1583, 250);
            labelFoV.Margin = new Padding(4, 0, 4, 0);
            labelFoV.Name = "labelFoV";
            labelFoV.Size = new Size(43, 25);
            labelFoV.TabIndex = 37;
            labelFoV.Text = "FoV";
            // 
            // textBoxFoV
            // 
            textBoxFoV.Location = new Point(1719, 246);
            textBoxFoV.Margin = new Padding(4, 3, 4, 3);
            textBoxFoV.Name = "textBoxFoV";
            textBoxFoV.Size = new Size(155, 31);
            textBoxFoV.TabIndex = 38;
            // 
            // labelScale
            // 
            labelScale.AutoSize = true;
            labelScale.Location = new Point(1583, 517);
            labelScale.Margin = new Padding(4, 0, 4, 0);
            labelScale.Name = "labelScale";
            labelScale.Size = new Size(62, 25);
            labelScale.TabIndex = 39;
            labelScale.Text = "(Scale)";
            // 
            // textBoxScale
            // 
            textBoxScale.Location = new Point(1719, 513);
            textBoxScale.Margin = new Padding(4, 3, 4, 3);
            textBoxScale.Name = "textBoxScale";
            textBoxScale.Size = new Size(155, 31);
            textBoxScale.TabIndex = 40;
            // 
            // labelReflective
            // 
            labelReflective.AutoSize = true;
            labelReflective.Location = new Point(1583, 769);
            labelReflective.Margin = new Padding(4, 0, 4, 0);
            labelReflective.Name = "labelReflective";
            labelReflective.Size = new Size(86, 25);
            labelReflective.TabIndex = 41;
            labelReflective.Text = "Reflective";
            // 
            // textBoxReflective
            // 
            textBoxReflective.Location = new Point(1713, 764);
            textBoxReflective.Margin = new Padding(4, 5, 4, 5);
            textBoxReflective.Name = "textBoxReflective";
            textBoxReflective.Size = new Size(155, 31);
            textBoxReflective.TabIndex = 42;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(textBoxReflective);
            Controls.Add(labelReflective);
            Controls.Add(textBoxScale);
            Controls.Add(labelScale);
            Controls.Add(textBoxFoV);
            Controls.Add(labelFoV);
            Controls.Add(textBoxRadius);
            Controls.Add(labelRadius);
            Controls.Add(textBoxLightDirection);
            Controls.Add(labelLightDirection);
            Controls.Add(textBoxLightIntensity);
            Controls.Add(textBoxLightColor);
            Controls.Add(labelLightIntensity);
            Controls.Add(labelLightColor);
            Controls.Add(labelLight);
            Controls.Add(labelScene);
            Controls.Add(labelMaterial);
            Controls.Add(textBoxSpecular);
            Controls.Add(textBoxColor);
            Controls.Add(labelSpecular);
            Controls.Add(labelColor);
            Controls.Add(labelName);
            Controls.Add(textBoxName);
            Controls.Add(textBoxRotation);
            Controls.Add(textBoxPosition);
            Controls.Add(labelRotation);
            Controls.Add(labelPosition);
            Controls.Add(labelObject);
            Controls.Add(treeView1);
            Controls.Add(textBoxLookUp);
            Controls.Add(textBoxLookAt);
            Controls.Add(textBoxLookFrom);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxLookFrom;
        private TextBox textBoxLookAt;
        private TextBox textBoxLookUp;
        private TreeView treeView1;
        private Label labelObject;
        private Label labelPosition;
        private Label labelRotation;
        private TextBox textBoxPosition;
        private TextBox textBoxRotation;
        private TextBox textBoxName;
        private Label labelName;
        private Label labelColor;
        private Label labelSpecular;
        private TextBox textBoxColor;
        private TextBox textBoxSpecular;
        private Label labelMaterial;
        private Label labelScene;
        private Label labelLight;
        private Label labelLightColor;
        private Label labelLightIntensity;
        private TextBox textBoxLightColor;
        private TextBox textBoxLightIntensity;
        private Label labelLightDirection;
        private TextBox textBoxLightDirection;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label labelRadius;
        private TextBox textBoxRadius;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItemMesh;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem lightToolStripMenuItem;
        private ToolStripMenuItem sphereToolStripMenuItem;
        private ToolStripMenuItem pointToolStripMenuItem;
        private ToolStripMenuItem directionalToolStripMenuItem;
        private Label labelFoV;
        private TextBox textBoxFoV;
        private Label labelScale;
        private TextBox textBoxScale;
        private Label labelReflective;
        private TextBox textBoxReflective;
    }
}
