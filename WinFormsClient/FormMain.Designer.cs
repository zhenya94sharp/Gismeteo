
namespace WinFormsClient
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGetWeathers = new System.Windows.Forms.Button();
            this.comboBoxCities = new System.Windows.Forms.ComboBox();
            this.labelName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPressure = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelHumidity = new System.Windows.Forms.Label();
            this.labelTemperatureDay = new System.Windows.Forms.Label();
            this.labelPrecipitation = new System.Windows.Forms.Label();
            this.labelWind = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDays = new System.Windows.Forms.ComboBox();
            this.labelTemperatureNight = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGetWeathers
            // 
            this.buttonGetWeathers.Location = new System.Drawing.Point(158, 396);
            this.buttonGetWeathers.Name = "buttonGetWeathers";
            this.buttonGetWeathers.Size = new System.Drawing.Size(151, 42);
            this.buttonGetWeathers.TabIndex = 1;
            this.buttonGetWeathers.Text = "Получить прогноз";
            this.buttonGetWeathers.UseVisualStyleBackColor = true;
            this.buttonGetWeathers.Click += new System.EventHandler(this.buttonGetWeathers_Click);
            // 
            // comboBoxCities
            // 
            this.comboBoxCities.FormattingEnabled = true;
            this.comboBoxCities.Items.AddRange(new object[] {
            "Барнаул",
            "Белгород",
            "Волгоград",
            "Воронеж",
            "Екатеринбург",
            "Казань",
            "Калининград",
            "Краснодар",
            "Красноярск",
            "Москва",
            "Нижний Новгород",
            "Новосибирск",
            "Омск",
            "Оренбург",
            "Пенза",
            "Пермь",
            "Ростов-на-Дону",
            "Самара",
            "Санкт-Петербург",
            "Саратов",
            "Тольятти",
            "Тюмень",
            "Уфа",
            "Челябинск"});
            this.comboBoxCities.Location = new System.Drawing.Point(289, 158);
            this.comboBoxCities.Name = "comboBoxCities";
            this.comboBoxCities.Size = new System.Drawing.Size(152, 21);
            this.comboBoxCities.TabIndex = 3;
            this.comboBoxCities.SelectedIndexChanged += new System.EventHandler(this.comboBoxCities_SelectedIndexChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(177, 19);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(19, 20);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "_";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(22, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Осадки";
            // 
            // labelPressure
            // 
            this.labelPressure.AutoSize = true;
            this.labelPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPressure.Location = new System.Drawing.Point(163, 289);
            this.labelPressure.Name = "labelPressure";
            this.labelPressure.Size = new System.Drawing.Size(18, 20);
            this.labelPressure.TabIndex = 7;
            this.labelPressure.Text = "_";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(22, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Давление";
            // 
            // labelHumidity
            // 
            this.labelHumidity.AutoSize = true;
            this.labelHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHumidity.Location = new System.Drawing.Point(12, 104);
            this.labelHumidity.Name = "labelHumidity";
            this.labelHumidity.Size = new System.Drawing.Size(18, 20);
            this.labelHumidity.TabIndex = 9;
            this.labelHumidity.Text = "_";
            // 
            // labelTemperatureDay
            // 
            this.labelTemperatureDay.AutoSize = true;
            this.labelTemperatureDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTemperatureDay.Location = new System.Drawing.Point(42, 192);
            this.labelTemperatureDay.Name = "labelTemperatureDay";
            this.labelTemperatureDay.Size = new System.Drawing.Size(27, 29);
            this.labelTemperatureDay.TabIndex = 10;
            this.labelTemperatureDay.Text = "_";
            // 
            // labelPrecipitation
            // 
            this.labelPrecipitation.AutoSize = true;
            this.labelPrecipitation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrecipitation.Location = new System.Drawing.Point(163, 254);
            this.labelPrecipitation.Name = "labelPrecipitation";
            this.labelPrecipitation.Size = new System.Drawing.Size(18, 20);
            this.labelPrecipitation.TabIndex = 11;
            this.labelPrecipitation.Text = "_";
            // 
            // labelWind
            // 
            this.labelWind.AutoSize = true;
            this.labelWind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWind.Location = new System.Drawing.Point(163, 321);
            this.labelWind.Name = "labelWind";
            this.labelWind.Size = new System.Drawing.Size(18, 20);
            this.labelWind.TabIndex = 12;
            this.labelWind.Text = "_";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(22, 321);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "Ветер";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(308, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Выберите город";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Выберите день";
            // 
            // comboBoxDays
            // 
            this.comboBoxDays.FormattingEnabled = true;
            this.comboBoxDays.Items.AddRange(new object[] {
            "сегодня",
            "завтра",
            "послезавтра",
            "4 день",
            "5 день",
            "6 день",
            "7 день",
            "8 день",
            "9 день",
            "10 день"});
            this.comboBoxDays.Location = new System.Drawing.Point(289, 225);
            this.comboBoxDays.Name = "comboBoxDays";
            this.comboBoxDays.Size = new System.Drawing.Size(152, 21);
            this.comboBoxDays.TabIndex = 16;
            this.comboBoxDays.SelectedIndexChanged += new System.EventHandler(this.comboBoxDays_SelectedIndexChanged);
            // 
            // labelTemperatureNight
            // 
            this.labelTemperatureNight.AutoSize = true;
            this.labelTemperatureNight.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTemperatureNight.Location = new System.Drawing.Point(169, 192);
            this.labelTemperatureNight.Name = "labelTemperatureNight";
            this.labelTemperatureNight.Size = new System.Drawing.Size(27, 29);
            this.labelTemperatureNight.TabIndex = 18;
            this.labelTemperatureNight.Text = "_";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(38, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Днём";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(154, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Ночью";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(56, 30);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(88, 57);
            this.pictureBox.TabIndex = 21;
            this.pictureBox.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 450);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelTemperatureNight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDays);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelWind);
            this.Controls.Add(this.labelPrecipitation);
            this.Controls.Add(this.labelTemperatureDay);
            this.Controls.Add(this.labelHumidity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelPressure);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.comboBoxCities);
            this.Controls.Add(this.buttonGetWeathers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Gismeteo";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonGetWeathers;
        private System.Windows.Forms.ComboBox comboBoxCities;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label labelName;
        public System.Windows.Forms.Label labelPressure;
        public System.Windows.Forms.Label labelHumidity;
        public System.Windows.Forms.Label labelTemperatureDay;
        public System.Windows.Forms.Label labelPrecipitation;
        public System.Windows.Forms.Label labelWind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDays;
        public System.Windows.Forms.Label labelTemperatureNight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.PictureBox pictureBox;
    }
}

