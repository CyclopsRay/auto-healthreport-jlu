using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using test111;

namespace test111
{
    public partial class Form1 : Form
    {
        static int cnt=0;
        static int campus, dormitory;
        public static int curh, nonh, curm, nonm, flg1, ngth, ngtm, flg2;
        static string path = @".\user.json";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flg1 = 0, flg2 = 0;
            String s="设置成功!\n";
            int curh = Convert.ToInt32(DateTime.Now.Hour.ToString());
            int curm = Convert.ToInt32(DateTime.Now.Minute.ToString());
            int cum = curh * 60 + curm;
            int nonh = Convert.ToInt32(textBox6.Text.Substring(0, 2));
            int nonm = Convert.ToInt32(textBox7.Text.Substring(0, 2));
            int nonc = nonh * 60 + nonm;
            int ngth = Convert.ToInt32(textBox9.Text.Substring(0, 2));
            int ngtm = Convert.ToInt32(textBox8.Text.Substring(0, 2));
            int ngtc = ngth * 60 + ngtm;
            if (nonc < cum) {
                s += "早上打卡时间已过\n";
            }
            else
            {
                s += "距离早上打卡还剩" + (int)(nonc - cum) + "分钟\n";
            }
            if (ngtc < cum)
            {
                s += "晚上打卡时间已过\n";
            }
            else
            {
                s += "距离晚上打卡还剩" + (int)(ngtc - cum) + "分钟\n";
            }
                       MessageBox.Show(s);
            //            MessageBox.Show("早打卡已完成!");
            //           textBox10.Text = "早打卡已完成于 " + nonh + " : " + nonm;
            FileStream fs = new FileStream(path, FileMode.Create);
            fs.Close();
            using (StreamWriter file = new StreamWriter(path, true))
            {

                file.WriteLine("{");
                file.WriteLine("\"transaction\": \"BKSMRDK\",");
                file.WriteLine("\"users\": [");
                file.WriteLine("{");
                file.WriteLine("\"username\":\"" + textBox1.Text + "\",");
                file.WriteLine("\"password\":\"" + textBox3.Text + "\",");
                file.WriteLine("\"fields\":{");
                file.WriteLine("\"fieldSQxq\": \"" + campus + "\",");
                file.WriteLine("\"fieldSQgyl\": \"" + dormitory + "\",");
                file.WriteLine("\"fieldSQqsh\":\"" + textBox4.Text + "\",");
                file.WriteLine("\"fieldSQnj\":\"" + textBox1.Text.Substring(textBox1.Text.Length-4,4) + "\",");
                file.WriteLine("\"fieldSQnj_Name\":\"20" + textBox1.Text.Substring(textBox1.Text.Length - 2, 2) + "\",");
                int x = 880 + Convert.ToInt32(textBox4.Text) - 26;
                file.WriteLine("\"fieldSQbj\": \"" + x + "\",");
                file.WriteLine("\"fieldSQbj_Name\":\"" + textBox1.Text.Substring(textBox1.Text.Length - 4, 4) + textBox5.Text + "\"");
                file.WriteLine("}");
                file.WriteLine("}");
                file.WriteLine("]");
                file.WriteLine("}");
                file.Close();
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt++;
            if (cnt == 10)
            {
                
                cnt = 0;
                if (DateTime.Now.Hour == nonh && DateTime.Now.Minute == nonm && flg1 == 0)
                    {
                    try
                    {
                        Class1.daka();
                        if (flg1 == 1)
                        {
                            MessageBox.Show("早打卡已完成！");
                            textBox10.Text = "早打卡完成于" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                        }
                    }
                    catch(Exception ex)
                    {
                        textBox10.Text = ex.ToString();
                    }
                }
                if (DateTime.Now.Hour == ngth && DateTime.Now.Minute == ngtm && flg2 == 0)
                    {
                    try
                    {
                         Class1.daka();
                        if (flg2 == 1)
                        {
                            MessageBox.Show("晚打卡已完成！");
                            textBox10.Text = "晚打卡完成于" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                        }
                    }
                    catch(Exception ex)
                    {
                        textBox11.Text = ex.ToString();
                    }
                }
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString()) //获取选择的内容
            {

                case "中心校区": campus = 1; break;
                case "南岭校区": campus = 2; break;
                case "新民校区": campus = 3; break;
                case "南湖校区": campus = 4; break;
                case "和平校区": campus = 5; break;
                case "朝阳校区": campus = 6; break;
                case "前卫北区": campus = 7; break;

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedItem.ToString()) //获取选择的内容
            {

                case "北苑1公寓": dormitory = 1; break;
                case "北苑2公寓": dormitory = 2; break;
                case "南苑1公寓": dormitory = 3; break;
                case "南苑2公寓": dormitory = 4; break;
                case "南苑3公寓": dormitory = 5; break;
                case "南苑4公寓": dormitory = 6; break;
                case "南苑5公寓A区": dormitory = 7; break;
                case "南苑5公寓B区": dormitory = 8; break;
                case "南苑5公寓C区": dormitory = 9; break;

            }
        }
    }
}
