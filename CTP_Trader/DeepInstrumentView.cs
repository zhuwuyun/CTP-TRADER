using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SQLiteBase;

namespace CTP_TRADER
{
    public partial class DeepInstrumentView : Form
    {
        SQLiteBase.SQLiteBase sqldb;
        string table_name = string.Empty;
        DataTable dt;
        string vSQL = string.Empty;

        public DeepInstrumentView(string sTablename,string stip, SQLiteBase.SQLiteBase MemDB)
        {
            InitializeComponent();

            sqldb = MemDB;
            table_name = sTablename;
            vSQL = "SELECT INSTRUMENTID as 合约名,TRADINGDAY as 交易日,UPDATETIME as 时间, UPDATEMILLISEC 毫秒, lastprice 最新价 ,VOLUME ,TURNOVER, OPENINTEREST, BIDPRICE1 as 叫买价, BIDVOLUME1 as 叫买量,ASKPRICE1 as 叫卖价, ASKVOLUME1 as 叫卖量 from " + sTablename + " where INSTRUMENTID='" + stip + "';";
            sqldb.setSQL(vSQL);
            sqldb.OpenSQL();
            dt = sqldb.dt_Result.Copy();
            this.Text = stip + " - " + this.Text;
        }

        private void DeepInstrumentView_Load(object sender, EventArgs e)
        {
            this.GridView_DeepInstrumentView.DataSource = dt;
            this.GridView_DeepInstrumentView.Columns[0].Visible = false;
        }

        private void toolStripMenuItem_refreshInstrumentView_Click(object sender, EventArgs e)
        {
            sqldb.setSQL(vSQL);
            sqldb.OpenSQL();
            dt = sqldb.dt_Result.Copy();
            this.GridView_DeepInstrumentView.DataSource = dt;
            this.GridView_DeepInstrumentView.Columns[0].Visible = false;
        }

    }
}
