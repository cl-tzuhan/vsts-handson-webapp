using System;
using System.Data;
using System.Web.UI;

namespace HandsOnWebApp {

    public partial class Default : Page {

        /// <summary>
        /// TextBox1 と TextBox2 の値を足し算して、結果を Label1 に表示します。
        /// </summary>
        protected void Button1_Click(object sender, EventArgs e) {
            float val = this.Calculate(this.TextBox1.Text, this.TextBox2.Text);
            this.Label1.Text = string.Format("{0}", val);

            // 履歴を残します。
            this.SqlDataSource1.InsertParameters.Add("v1", DbType.Double, this.TextBox1.Text);
            this.SqlDataSource1.InsertParameters.Add("v2", DbType.Double, this.TextBox2.Text);
            this.SqlDataSource1.InsertParameters.Add("sum", DbType.Double, this.Label1.Text);
            this.SqlDataSource1.Insert();
        }

        /// <summary>
        /// 履歴を消去します。
        /// </summary>
        protected void Button2_Click(object sender, EventArgs e) {
            this.SqlDataSource1.Delete();
        }

        /// <summary>
        /// 文字列の数値から、足し算の結果を返します。
        /// </summary>
        /// <param name="s1">足される数を表す文字列。</param>
        /// <param name="s2">足す数を表す文字列。</param>
        /// <returns>足し算の結果。</returns>
        private float Calculate(string s1, string s2) {
            float f1 = float.Parse(s1);
            float f2 = float.Parse(s2);
            return f1 + f2;
        }
    }
}