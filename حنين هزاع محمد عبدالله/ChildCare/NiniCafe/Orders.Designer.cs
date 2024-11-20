
namespace NiniCafe
{
    partial class Orders
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.OrdersGV = new Guna.UI.WinForms.GunaDataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.AddToCartBtn = new System.Windows.Forms.Button();
            this.childCareDataSet14 = new NiniCafe.ChildCareDataSet14();
            this.view3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_3TableAdapter = new NiniCafe.ChildCareDataSet14TableAdapters.View_3TableAdapter();
            this.subscriptionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.childIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.childNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activityIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activityNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foodIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childCareDataSet14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view3BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OrdersGV
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.OrdersGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.OrdersGV.AutoGenerateColumns = false;
            this.OrdersGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.OrdersGV.BackgroundColor = System.Drawing.Color.White;
            this.OrdersGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OrdersGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.OrdersGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.OrdersGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.OrdersGV.ColumnHeadersHeight = 25;
            this.OrdersGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subscriptionIDDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.childIDDataGridViewTextBoxColumn,
            this.childNameDataGridViewTextBoxColumn,
            this.activityIDDataGridViewTextBoxColumn,
            this.activityNameDataGridViewTextBoxColumn,
            this.foodIDDataGridViewTextBoxColumn,
            this.foodNameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.OrdersGV.DataSource = this.view3BindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.OrdersGV.DefaultCellStyle = dataGridViewCellStyle3;
            this.OrdersGV.EnableHeadersVisualStyles = false;
            this.OrdersGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.OrdersGV.Location = new System.Drawing.Point(44, 80);
            this.OrdersGV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OrdersGV.Name = "OrdersGV";
            this.OrdersGV.RowHeadersVisible = false;
            this.OrdersGV.RowHeadersWidth = 51;
            this.OrdersGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrdersGV.Size = new System.Drawing.Size(622, 634);
            this.OrdersGV.TabIndex = 29;
            this.OrdersGV.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.OrdersGV.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.OrdersGV.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.OrdersGV.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.OrdersGV.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.OrdersGV.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.OrdersGV.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.OrdersGV.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.OrdersGV.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.OrdersGV.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.OrdersGV.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.OrdersGV.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.OrdersGV.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.OrdersGV.ThemeStyle.HeaderStyle.Height = 25;
            this.OrdersGV.ThemeStyle.ReadOnly = false;
            this.OrdersGV.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.OrdersGV.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.OrdersGV.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.OrdersGV.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.OrdersGV.ThemeStyle.RowsStyle.Height = 22;
            this.OrdersGV.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.OrdersGV.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.No;
            this.label5.Font = new System.Drawing.Font("Algerian", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(220, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 41);
            this.label5.TabIndex = 30;
            this.label5.Text = "list fo orders";
            // 
            // AddToCartBtn
            // 
            this.AddToCartBtn.BackColor = System.Drawing.Color.White;
            this.AddToCartBtn.FlatAppearance.BorderSize = 0;
            this.AddToCartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddToCartBtn.Font = new System.Drawing.Font("Algerian", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddToCartBtn.ForeColor = System.Drawing.Color.DeepPink;
            this.AddToCartBtn.Location = new System.Drawing.Point(262, 721);
            this.AddToCartBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AddToCartBtn.Name = "AddToCartBtn";
            this.AddToCartBtn.Size = new System.Drawing.Size(169, 44);
            this.AddToCartBtn.TabIndex = 31;
            this.AddToCartBtn.Text = "close";
            this.AddToCartBtn.UseVisualStyleBackColor = false;
            this.AddToCartBtn.Click += new System.EventHandler(this.AddToCartBtn_Click);
            // 
            // childCareDataSet14
            // 
            this.childCareDataSet14.DataSetName = "ChildCareDataSet14";
            this.childCareDataSet14.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // view3BindingSource
            // 
            this.view3BindingSource.DataMember = "View_3";
            this.view3BindingSource.DataSource = this.childCareDataSet14;
            // 
            // view_3TableAdapter
            // 
            this.view_3TableAdapter.ClearBeforeFill = true;
            // 
            // subscriptionIDDataGridViewTextBoxColumn
            // 
            this.subscriptionIDDataGridViewTextBoxColumn.DataPropertyName = "SubscriptionID";
            this.subscriptionIDDataGridViewTextBoxColumn.HeaderText = "SubscriptionID";
            this.subscriptionIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.subscriptionIDDataGridViewTextBoxColumn.Name = "subscriptionIDDataGridViewTextBoxColumn";
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "UserID";
            this.userIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "User";
            this.userNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            // 
            // childIDDataGridViewTextBoxColumn
            // 
            this.childIDDataGridViewTextBoxColumn.DataPropertyName = "ChildID";
            this.childIDDataGridViewTextBoxColumn.HeaderText = "ChildID";
            this.childIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.childIDDataGridViewTextBoxColumn.Name = "childIDDataGridViewTextBoxColumn";
            this.childIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // childNameDataGridViewTextBoxColumn
            // 
            this.childNameDataGridViewTextBoxColumn.DataPropertyName = "ChildName";
            this.childNameDataGridViewTextBoxColumn.HeaderText = "Child";
            this.childNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.childNameDataGridViewTextBoxColumn.Name = "childNameDataGridViewTextBoxColumn";
            // 
            // activityIDDataGridViewTextBoxColumn
            // 
            this.activityIDDataGridViewTextBoxColumn.DataPropertyName = "ActivityID";
            this.activityIDDataGridViewTextBoxColumn.HeaderText = "ActivityID";
            this.activityIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.activityIDDataGridViewTextBoxColumn.Name = "activityIDDataGridViewTextBoxColumn";
            this.activityIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // activityNameDataGridViewTextBoxColumn
            // 
            this.activityNameDataGridViewTextBoxColumn.DataPropertyName = "ActivityName";
            this.activityNameDataGridViewTextBoxColumn.HeaderText = "Activity";
            this.activityNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.activityNameDataGridViewTextBoxColumn.Name = "activityNameDataGridViewTextBoxColumn";
            // 
            // foodIDDataGridViewTextBoxColumn
            // 
            this.foodIDDataGridViewTextBoxColumn.DataPropertyName = "FoodID";
            this.foodIDDataGridViewTextBoxColumn.HeaderText = "FoodID";
            this.foodIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.foodIDDataGridViewTextBoxColumn.Name = "foodIDDataGridViewTextBoxColumn";
            this.foodIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // foodNameDataGridViewTextBoxColumn
            // 
            this.foodNameDataGridViewTextBoxColumn.DataPropertyName = "FoodName";
            this.foodNameDataGridViewTextBoxColumn.HeaderText = "Food";
            this.foodNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.foodNameDataGridViewTextBoxColumn.Name = "foodNameDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepPink;
            this.ClientSize = new System.Drawing.Size(710, 780);
            this.Controls.Add(this.OrdersGV);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddToCartBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Orders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.Orders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OrdersGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childCareDataSet14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view3BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaDataGridView OrdersGV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddToCartBtn;
        private ChildCareDataSet14 childCareDataSet14;
        private System.Windows.Forms.BindingSource view3BindingSource;
        private ChildCareDataSet14TableAdapters.View_3TableAdapter view_3TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn subscriptionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn childIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn childNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activityIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn activityNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foodIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
    }
}