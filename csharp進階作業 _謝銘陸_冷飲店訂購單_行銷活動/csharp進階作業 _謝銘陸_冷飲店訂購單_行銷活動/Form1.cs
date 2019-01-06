using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp進階作業_謝銘陸_冷飲店訂購單_行銷活動
{
    public partial class Form1 : Form
    {   //類別變數
        double[] 售價 = new double[5] { 0.0, 0.0, 0.0, 0.0, 0.0 }; //品項1~品項5售價初始值        
        int[] 杯數 = new int[5] { 0, 0, 0, 0, 0 }; //杯數1~杯數5初始值
        string[] 品名 = new string[5] { "麥香紅茶", "茉莉綠茶", "珍珠奶茶", "玫瑰花茶", "現打西瓜汁" };
        int[] temp杯數 = new int[5];
        double[] 品項總價 = new double[5] { 0.0, 0.0, 0.0, 0.0, 0.0 };  //品項1總價~品項5總價初始值 
        double 折數 = 0.0, 總價 = 0.0, 折扣後總價 = 0.0;
        int 免費杯數;


        public Form1()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form Load的同時，會存取以下所有資料
            //使品名以及售價更新
            lbl品名1.Text = 品名[0];
            lbl品名2.Text = 品名[1];
            lbl品名3.Text = 品名[2];
            lbl品名4.Text = 品名[3];
            lbl品名5.Text = 品名[4];

            售價[0] = 35.0;  //品項1售價
            售價[1] = 40.0;  //品項2售價
            售價[2] = 45.0;  //品項3售價
            售價[3] = 50.0;  //品項4售價
            售價[4] = 55.0;  //品項5售價

            lbl售價1.Text = 售價[0].ToString();
            lbl售價2.Text = 售價[1].ToString();
            lbl售價3.Text = 售價[2].ToString();
            lbl售價4.Text = 售價[3].ToString();
            lbl售價5.Text = 售價[4].ToString();

        }
        //品項1 紅茶
        private void btn杯數1減_Click(object sender, EventArgs e)
        {
            杯數[0] -= 1;        //為了避免數字出現負數，以條件判斷是來處理。
            if (杯數[0] < 0)
            {
                杯數[0] = 0;
                btn杯數1減.Enabled = false; //杯數=0時，讓減號按鈕失效無法操作
            }
            tb杯數1.Text = 杯數[0].ToString();

        }

        private void btn杯數1加_Click(object sender, EventArgs e)
        {
            杯數[0] += 1;
            btn杯數1減.Enabled = true;
            tb杯數1.Text = 杯數[0].ToString();
        }

        private void tb杯數1_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數1.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數1.Text, out 杯數[0]);
                if ((ifNum == true) && (杯數[0] >= 0))  //輸入正確
                {
                    btn杯數1減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數[0] = 0;
                    tb杯數1.Text = "0";
                }
                if ((ifNum == true) && (杯數[0] > 99))
                {
                    btn杯數1加.Enabled = false;
                    杯數[0] -= 1;
                    MessageBox.Show("請重新輸入", "數量超過上限", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                杯數[0] = 0;
            }
            計算總價();   //方法內的程式碼有順序，所以呼叫計算總價的程式碼必須放在所有計算完成之後
        }

        private void btn杯數2減_Click(object sender, EventArgs e)
        {
            杯數[1] -= 1;
            if (杯數[1] < 0)
            {
                杯數[1] = 0;
                btn杯數2減.Enabled = false;
            }
            tb杯數2.Text = 杯數[1].ToString();
        }

        private void btn杯數2加_Click(object sender, EventArgs e)
        {
            杯數[1] += 1;
            btn杯數2減.Enabled = true;
            tb杯數2.Text = 杯數[1].ToString();
        }

        private void tb杯數2_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數2.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數2.Text, out 杯數[1]);
                if ((ifNum == true) && (杯數[1] >= 0))
                {
                    btn杯數2減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數[1] = 0;
                    tb杯數2.Text = "0";
                }
            }
            else
            {
                杯數[1] = 0;
            }
            計算總價();

        }

        private void btn杯數3減_Click(object sender, EventArgs e)
        {
            杯數[2] -= 1;
            if (杯數[2] < 0)
            {
                杯數[2] = 0;
                btn杯數3減.Enabled = false; 
            }
            tb杯數3.Text = 杯數[2].ToString();

        }

        private void btn杯數3加_Click(object sender, EventArgs e)
        {
            杯數[2] += 1;
            btn杯數3減.Enabled = true;
            tb杯數3.Text = 杯數[2].ToString();

        }

        private void tb杯數3_TextChanged(object sender, EventArgs e)
        {

            if (tb杯數3.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數3.Text, out 杯數[2]);
                if ((ifNum == true) && (杯數[2] >= 0))
                {
                    btn杯數3減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數[2] = 0;
                    tb杯數3.Text = "0";
                }
            }
            else
            {
                杯數[2] = 0;
            }
            計算總價();

        }

        private void btn杯數4減_Click(object sender, EventArgs e)
        {
            杯數[3] -= 1;
            if (杯數[3] < 0)
            {
                杯數[3] = 0;
                btn杯數4減.Enabled = false;
            }
            tb杯數4.Text = 杯數[3].ToString();

        }

        private void btn杯數4加_Click(object sender, EventArgs e)
        {
            杯數[3] += 1;
            btn杯數4減.Enabled = true;
            tb杯數4.Text = 杯數[3].ToString();
        }
    

        private void tb杯數4_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數4.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數4.Text, out 杯數[3]);
                if ((ifNum == true) && (杯數[3] >= 0))
                {
                    btn杯數4減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數[3] = 0;
                    tb杯數4.Text = "0";
                }
            }
            else
            {
                杯數[3] = 0;
            }
            計算總價();

        }

        private void btn杯數5減_Click(object sender, EventArgs e)
        {
            杯數[4] -= 1;
            if (杯數[4] < 0)
            {
                杯數[4] = 0;
                btn杯數5減.Enabled = false;
            }
            tb杯數5.Text = 杯數[4].ToString();

        }

        private void btn杯數5加_Click(object sender, EventArgs e)
        {

            杯數[4] += 1;
            btn杯數5減.Enabled = true;
            tb杯數5.Text = 杯數[4].ToString();
        }

        private void tb杯數5_TextChanged(object sender, EventArgs e)
        {
            if (tb杯數5.Text != "")
            {
                bool ifNum = System.Int32.TryParse(tb杯數5.Text, out 杯數[4]);
                if ((ifNum == true) && (杯數[4] >= 0))
                {
                    btn杯數5減.Enabled = true;
                }
                else
                {
                    MessageBox.Show("杯數輸入錯誤", "輸入錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    杯數[4] = 0;
                    tb杯數5.Text = "0";
                }
            }
            else
            {
                杯數[4] = 0;
            }
            計算總價();

        }

        private void tb折數_TextChanged(object sender, EventArgs e)
        {
            if (tb折數.Text != "")
            {
                bool ifNum = System.Double.TryParse(tb折數.Text, out 折數);
                if (ifNum == true)
                {

                    if ((折數 >= 0.0) && (折數 <= 10.0))
                    {
                        //折數合理
                    }
                    else
                    {
                        MessageBox.Show("折數輸入錯誤(0.0-10.0)");
                        tb折數.Text = "";
                        折數 = 10.0;
                    }
                }
                else
                {
                    MessageBox.Show("折數輸入錯誤(0.0-10.0)");
                    tb折數.Text = "";
                    折數 = 10.0;
                }
            }
            else
            {
                折數 = 10.0;
            }
            計算總價();
        }

        private void btn列印訂購單_Click(object sender, EventArgs e)
        {
            DialogResult drResult; //DialogResult是MessageBox.Show()的回傳值
            drResult = MessageBox.Show("您確認送出訂購單?", "訂單確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                //取消送出
            }
            else
            {
                //確認訂單
                string strOrder = "*****III冷飲店訂購單*****\n";
                strOrder += "--------------------------\n";
                for (int i = 0; i < 5; i += 1)
                {
                    if (杯數[i] > 0)
                    {
                        strOrder += 品名[i] + ":" + 售價[i].ToString() + "x" + 杯數[i].ToString() + "=" + 品項總價[i].ToString() + "\n";
                        strOrder += "--------------------------\n";
                    }
                }
                if (折數 < 10.0)
                {
                    strOrder += "折數:" + string.Format("{0:F2}", 折數) + "\n";
                }
                strOrder += "訂單總價" + string.Format("{0:C}", 總價) + "\n";
                strOrder += "折扣後總價" + string.Format("{0:C}", 折扣後總價) + "\n";
                strOrder += string.Format("{0:D}", DateTime.Now) + "\n";
                strOrder += string.Format("{0:T}", DateTime.Now) + "\n";
                MessageBox.Show(strOrder, "訂單明細", MessageBoxButtons.OK);
            }
       }

        //類別中的程式碼是「事件驅動(偶發)」，所以在類別中的程式碼不受"順序"所影響；
        //在類別層級中，任何地方，建立一個「方法」，有需要用到(計算金額)時再呼叫出來使用
        //寫在最前面或後面都可以。       
        //void代表這個方法沒有"回傳值",()中代表方法代入的參數，空的代表沒有參數
        //而tryparse 就是一個有回傳值(布林值)的方法

        void 計算總價()  //void 方法名稱():無回傳值的方法
        {
            for (int i = 0; i < 5; i += 1) 品項總價[i] = 售價[i] * 杯數[i];
            總價 = 品項總價.Sum();
            折扣後總價 = 總價 * 折數 / 10.0;
            lbl訂單總價.Text = string.Format("{0:C}", 總價);
            lbl折扣後總價.Text = string.Format("{0:C}", 折扣後總價);
        }


        //作業:行銷活動，兩種優惠模式。

        private void btn相同品項第二件6折_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i += 1)
            {
                if (杯數[i] % 2 != 0 && 杯數[i] >= 3) 品項總價[i] = 售價[i] * (杯數[i] * 4 + 1) / 5; //奇數杯計價方式
                else if (杯數[i] % 2 == 0 && 杯數[i] >= 2) 品項總價[i] = 售價[i] * 杯數[i] * 4 / 5;  //偶數杯計價方式
                else if (杯數[i] == 1) 品項總價[i] = 售價[i];
                else 品項總價[i] = 0;
            }
            總價 = 品項總價.Sum();
            折扣後總價 = 總價 * 折數 / 10.0;
            lbl訂單總價.Text = string.Format("{0:C}", 總價);
            lbl折扣後總價.Text = string.Format("{0:C}", 折扣後總價);

        }

       
        private void btn不同品項買三送一_Click(object sender, EventArgs e)
        {
            Array.Copy(杯數, temp杯數, 杯數.Length);
            免費杯數 = 杯數.Sum() / 4;  //每4杯有1杯免費,先計算出可以免費的杯數
            if (杯數.Sum() <= 3) 計算總價(); //3杯以下正常計費
            else
            {
                for (int i = 0; i < 5; i += 1)
                {
                    if (免費杯數 == 0) break;
                    while (temp杯數[i] > 0)
                    {
                        temp杯數[i] -= 1;   //從最低價的品項開始抵扣
                        免費杯數 -= 1;
                        if (免費杯數 == 0) break;  //免費杯數扣完為止
                    }
                }
                for (int i = 0; i < 5; i += 1) 品項總價[i] = 售價[i] * temp杯數[i];
                總價 = 品項總價.Sum();
                折扣後總價 = 總價 * 折數 / 10.0;
                lbl訂單總價.Text = string.Format("{0:C}", 總價);
                lbl折扣後總價.Text = string.Format("{0:C}", 折扣後總價);
            }
        }
    }
}
