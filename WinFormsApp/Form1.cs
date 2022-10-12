using CarConditionCheck;
using System.Media;

namespace WinFormsApp
{
    public partial class CarConditionCheck : System.Windows.Forms.Form
    {

        CheckCar[] checks = new CheckCar[20];
        int i = 0;
        public CarConditionCheck()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double oilLevel, tirePressure, waterLevel;
            int milliage, year, day, month;
            oilLevel = Convert.ToDouble(textBox1.Text == "" ? "0" : textBox1.Text);
            waterLevel = Convert.ToDouble(textBox2.Text == "" ? "0" : textBox2.Text);
            milliage = Convert.ToInt32(textBox3.Text == "" ? "0" : textBox3.Text);
            tirePressure = Convert.ToDouble(textBox4.Text == "" ? "0" : textBox4.Text);
            day = Convert.ToInt32(textBox5.Text);
            month = Convert.ToInt32(textBox6.Text);
            year = Convert.ToInt32(textBox7.Text);
            checks[i] = new CheckCar(year, month, day, milliage, oilLevel, tirePressure, waterLevel);
            LastCheck.Text = "Последний Введенный тех. осмотр:\n" + checks[i].GetDataInString();
            checksComboBox.Items.Clear();
            foreach (var check in checks)
            {
                if(check == null)
                {
                    break;
                }
                checksComboBox.Items.Add(check.GetDateString());
            }
            i++;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void MilliageByPeriodButton_Click(object sender, EventArgs e)
        {
            int firstYear = Convert.ToInt32(firstYearTextBox.Text);
            int lastYear = Convert.ToInt32(lastYearTextBox.Text);
            MilliageByPeriodLabel.Text = $"Пробег за указанный период - {CheckCar.GetMilliageByPeriod(firstYear, lastYear, checks)}";
        }

        private void GetAvgChecksButton_Click(object sender, EventArgs e)
        {
            int firstYear = Convert.ToInt32(firstYearTextBox2.Text);
            int lastYear = Convert.ToInt32(lastYearTextBox2.Text);
            GetAvgChecksLabel.Text = CheckCar.GetAvgChecks(checks, firstYear, lastYear);
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void avgMilliageButton_Click(object sender, EventArgs e)
        {
            avgMilliageLabel.Text = $"Средний пробег - {CheckCar.GetAveregeMilliage(checks)}";
        }

        private void checksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = checksComboBox.SelectedIndex;
            choosenCheckLabel.Text = checks[checksComboBox.SelectedIndex].GetDataInString();
            textBox1.Text = Convert.ToString(checks[id].GetOilLevel());
            textBox2.Text = Convert.ToString(checks[id].GetWaterLevel());
            textBox3.Text = Convert.ToString(checks[id].GetMilliage());
            textBox4.Text = Convert.ToString(checks[id].GetTirePressure());
            textBox5.Text = Convert.ToString(checks[id].GetDateParamString("day"));
            textBox6.Text = Convert.ToString(checks[id].GetDateParamString("month"));
            textBox7.Text = Convert.ToString(checks[id].GetDateParamString("year"));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double oilLevel, tirePressure, waterLevel;
            int milliage, year, day, month;
            oilLevel = Convert.ToDouble(textBox1.Text == "" ? "0" : textBox1.Text);
            waterLevel = Convert.ToDouble(textBox2.Text == "" ? "0" : textBox2.Text);
            milliage = Convert.ToInt32(textBox3.Text == "" ? "0" : textBox3.Text);
            tirePressure = Convert.ToDouble(textBox4.Text == "" ? "0" : textBox4.Text);
            day = Convert.ToInt32(textBox5.Text);
            month = Convert.ToInt32(textBox6.Text);
            year = Convert.ToInt32(textBox7.Text);
            checks[checksComboBox.SelectedIndex] = new CheckCar(year, month, day, milliage, oilLevel, tirePressure, waterLevel);
            checksComboBox.Items.Clear();
            foreach (var check in checks)
            {
                if (check == null)
                {
                    break;
                }
                checksComboBox.Items.Add(check.GetDateString());
            }
        }
    }
}