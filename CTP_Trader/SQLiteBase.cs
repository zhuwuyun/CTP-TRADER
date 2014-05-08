using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data.Common;
using System.Data;

namespace SQLiteBase
{
    public class SQLiteBase
    {
        #region 数据库相应公用函数字段初始化
        //连接字段
        public string ConnString;
        //执行语句字段
        public string sSQL;
        //存放执行结果
        public DataTable dt_Result;
        //当前所属的列
        public static int iCount;
        //存放单条结果
        public DataRow filed;
        //数据库连接句柄
        public SQLiteConnection SQLiteConn = null;
        //数据库命令句柄
        public SQLiteCommand SQLiteCMD = null;
        //数据库连接状态
        public bool m_bConn = false;
        //数据库事务状态
        public bool m_bTrans = false;
        //数据库事务句柄
        public DbTransaction DBTrans = null;
        //数据库运行接口句柄
        public SQLiteDataAdapter SQLiteDataAPT= null;
        //是否使用事务
        public bool bTrans;
        #endregion

        /// <summary>
        /// 初始化,不带参数,默认创建内存数据库
        /// </summary>
        public SQLiteBase(bool b=true)
        {
            ConnString = string.Format(@"Data Source={0}", ":memory:");
            dt_Result = new DataTable();
            SQLiteConn = new SQLiteConnection(ConnString);
            bTrans = b;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="s">s为数据库名称</param>
        public SQLiteBase(string s, bool b = true)
        {
            ConnString = string.Format(@"Data Source={0}", s);
            dt_Result = new DataTable();
            SQLiteConn = new SQLiteConnection(ConnString);
            bTrans = b;
        }
        /// <summary>
        /// 数据库的打开
        /// </summary>
        public void OpenDB()
        {
            if (!m_bConn)
            {
                SQLiteConn.Open();
                SQLiteCMD = new SQLiteCommand(SQLiteConn);
                SQLiteCMD.Connection = SQLiteConn;
                m_bConn = true;
            }
        }
        /// <summary>
        /// 数据库关闭
        /// </summary>
        public void CloseDB()
        {
            if (m_bConn)
            {
                if (m_bTrans)
                {
                    Rollback();
                }
                SQLiteConn.Close();
                SQLiteConn = null;
                SQLiteCMD = null;
                DBTrans = null;
                m_bConn = false;
            }
        }
        /// <summary>
        /// 入库
        /// </summary>
        /// <returns>是否入库成功</returns>
        public bool Commit()
        {
            if (m_bTrans)
            {
                DBTrans.Commit();
                m_bTrans = false;
            }
            return true;
        }
        /// <summary>
        /// 回退
        /// </summary>
        /// <returns>是否回退成功</returns>
        public bool Rollback()
        {
            if (m_bTrans)
            {
                DBTrans.Rollback();
                m_bTrans = false;
            }
            return true;
        }
        /// <summary>
        /// 设置SQL
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool setSQL(string s)
        {
            sSQL = s;
            SQLiteCMD.CommandText = sSQL;
            return true;
        }
        /// <summary>
        /// 打开语句
        /// </summary>
        /// <returns></returns>
        public bool OpenSQL()
        {
            dt_Result.Clear();
                if (m_bConn)
                {
                    SQLiteDataAPT = new SQLiteDataAdapter(SQLiteCMD);
                    SQLiteDataAPT.Fill(dt_Result);
                    iCount = 0;
                    return true;
                }
                else
                    return false;
            
        }
        /// <summary>
        /// 取下一条语句
        /// </summary>
        /// <returns></returns>
        public bool Next()
        {
            if (dt_Result.Rows.Count > 0 && iCount < dt_Result.Rows.Count)
            {
                filed = dt_Result.Rows[iCount];
                iCount++;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 执行语句
        /// </summary>
        /// <returns></returns>
        public bool Execute()
        {
            int iResult = 0;
            if (!bTrans)
            {
                    iResult = SQLiteCMD.ExecuteNonQuery();
                    return true;
            }
            else // 使用事务
            {
                //是否已经有事物
                if (!m_bTrans)
                {
                    m_bTrans = true;
                    DBTrans = SQLiteConn.BeginTransaction();
                }
                SQLiteCMD.ExecuteNonQuery();
                return true;
            }
        }
        /// <summary>
        /// 表格是否存在
        /// </summary>
        /// <param name="s">表名</param>
        /// <returns>存在true不存在false</returns>
        public bool existTable(string s)
        {
            sSQL = "SELECT COUNT(*) FROM sqlite_master where type='table' and name='" + s + "';";
            setSQL(sSQL);
            OpenSQL();
            if (Convert.ToInt32(dt_Result.Rows[0][0]) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
