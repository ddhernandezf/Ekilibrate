using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ekilibrate.Data.Access.Common
{
    public interface IDBContext
    {
        IDbConnection Conn { get; set; }
    }

    public interface IDBTrnContext : IDBContext, IDisposable
    {
        IDbTransaction Trn { get; set; }
        bool ActiveTransaction { get; set; }
        void BeginTransaction();
        void CommitTransaction();
        void Rollback();
    }

    public abstract class DBContext : IDBContext, IDisposable
    {
        public IDbConnection Conn { get; set; }

        public DBContext()
        {
            var _conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlServerPool"].ConnectionString);
            _conn.Open();
            Conn = _conn;
        }

        void IDisposable.Dispose()
        {
            if (Conn != null) Conn.Dispose();
        }
    }


    public class DBReadonlyContext : DBContext
    {
        public DBReadonlyContext() : base() { }
    }

    public class DBTrnContext : DBContext, IDBTrnContext, IDisposable
    {
        public IDbTransaction Trn { get; set; }
        public bool ActiveTransaction { get; set; }

        public DBTrnContext()
            : base()
        {
            ActiveTransaction = false;
        }

        public void BeginTransaction()
        {
            Trn = Conn.BeginTransaction();
            ActiveTransaction = true;
        }

        public void CommitTransaction()
        {
            if (Trn != null && ActiveTransaction == true)
            {
                Trn.Commit();
                ActiveTransaction = false;
            }
        }

        public void Rollback()
        {
            if (Trn != null)
            {
                Trn.Rollback();
                ActiveTransaction = false;
            }
        }

        void IDisposable.Dispose()
        {
            if (ActiveTransaction == true) Rollback();
            Trn.Dispose();
            Conn.Dispose();
        }
    }
}

//namespace Kaizen.Data.Access.Common
//{
//    public class clsConnection : IDisposable
//    {
//        private static IDbConnection myconn;
//        private static IDbTransaction trans;
//        private static Boolean _transaccionFinalizada;

//        static clsConnection()
//        {
//            try
//            {
//                myconn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Kaizen.bl.Constants.DataAccess.DBKey].ConnectionString);
//                myconn.Open();
//                trans = myconn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
//                _transaccionFinalizada = false;
//            }
//            catch (Exception ex)
//            {
//                Console.Write(ex.ToString());
//            }
//        }

//        public static IDbConnection Connection
//        {
//            get
//            { 
//                return myconn; 
//            }
//            set
//            { 
//                myconn = value; 
//            }
//        }

//        public static IDbTransaction Trn
//        {
//            get
//            {
//                return trans;
//            }
//            set 
//            {
//                trans = value;
//            }
//        }

//        public static void CommitTransaction()
//        {
//            trans.Commit();
//        }

//        public static void RollbackTransaction()
//        {
//            trans.Rollback();
//        }

//        void IDisposable.Dispose()
//        {
//            if (_transaccionFinalizada == false)
//            {
//                trans.Rollback();
//                myconn.Close();
//            }
//        }
//    }
//}
