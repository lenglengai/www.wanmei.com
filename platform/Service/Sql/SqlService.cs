using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace platform
{
    public class SqlService : IHeadstream
    {
        public void _headSerialize(ISerialize nSerialize)
        {
            nSerialize._serialize(ref mConnectionString, @"connectionString");
        }

        public string _streamName()
        {
            return @"sqlService";
        }

        public bool _runSqlCommand(SqlCommand nSqlCommand)
        {
            bool result_ = true;
            MySqlConnection mySqlConnection_ = new MySqlConnection(mConnectionString);
            try
            {
                mySqlConnection_.Open();
                MySqlCommand mySqlCommand_ = new MySqlCommand();
                mySqlCommand_.Connection = mySqlConnection_;
                string sqlCommand_ = nSqlCommand._sqlCommand();
                mySqlCommand_.CommandText = sqlCommand_;
                IList<SqlParameter> fields_ = nSqlCommand._getFields();
                foreach (SqlParameter i in fields_)
                {
                    string name_ = i._getName();
                    object value_ = i._getValue();
                    mySqlCommand_.Parameters.AddWithValue(name_, value_);
                }
                mySqlCommand_.ExecuteNonQuery();
            }
            catch (MySqlException exception_)
            {
                LogService logService_ = __singleton<LogService>._instance();
                logService_._logError(string.Format(@"sqlError:{0},{1}", exception_.Number, exception_.Message));
                result_ = false;
            }
            mySqlConnection_.Close();
            return result_;
        }

        public bool _runSqlCommand(SqlCommand nSqlCommand, ISqlHeadstream nSqlHeadstream)
        {
            bool result = true;
            MySqlConnection mySqlConnection_ = new MySqlConnection(mConnectionString);
            try
            {
                mySqlConnection_.Open();
                string sqlCommand_ = nSqlCommand._sqlCommand();
                MySqlCommand mySqlCommand_ = new MySqlCommand(sqlCommand_, mySqlConnection_);
                MySqlDataReader mySqlDataReader_ = mySqlCommand_.ExecuteReader();
                SqlReader sqlReader_ = new SqlReader(mySqlDataReader_);
                while (sqlReader_._runRead())
                {
                    nSqlHeadstream._runSelect(sqlReader_);
                }
                sqlReader_._runClose();
            }
            catch (MySqlException exception_)
            {
                LogService logService_ = __singleton<LogService>._instance();
                logService_._logError(string.Format(@"sqlError:{0},{1}", exception_.Number, exception_.Message));
                result = false;
            }
            mySqlConnection_.Close();
            return result;
        }

        public void _runInit()
        {
            this._initConfig();
        }

        void _initConfig()
        {
            string sqlUrl_ = @"config/sqlConfig.xml";
            XmlReader xmlReader_ = new XmlReader();
            xmlReader_._openUrl(sqlUrl_);
            xmlReader_._selectStream(_streamName());
            this._headSerialize(xmlReader_);
            xmlReader_._runClose();
        }

        public SqlService()
        {
            mConnectionString = null;
        }

        string mConnectionString;
    }
}
