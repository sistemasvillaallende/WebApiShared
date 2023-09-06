using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data.SqlClient;

namespace SeguridadNet.Library
{
  /// Libreria y Funciones para Base de Datos
  /// Autor: Ing Manuel A. Andr�s.
  /// Implementa EnterpriseLibrary
  /// Testa Consulting Group
  /// 

  public class DBHelper
  {

    struct DBHelperProps
    {
      public long TotalRows;
    }


    DBHelperProps o;


    public DBHelper()
    {
      o = new DBHelperProps();
      o.TotalRows = 0;
    }

    ~DBHelper()
    {
      //oDal = null;
    }

    public long TotalRows
    {

      get { return o.TotalRows; }

    }


    public string MakeInsertSQL(string SQLStr, string FieldName, object Value)
    {
      string retStr = "";
      string sep = "";
      string fields = "";
      string values = "";

      if (SQLStr.Length == 0)
      {
        fields = "()";
        values = "()";
        sep = "";
      }
      else
      {
        int ef = SQLStr.IndexOf(")");
        int sv = SQLStr.LastIndexOf("(");

        fields = SQLStr.Substring(0, ef + 1);
        values = SQLStr.Substring(sv);
        sep = ",";
      }
      string strValue = this.GetStrValue(Value);

      fields = fields.Replace(")", sep + FieldName + ")");
      values = values.Replace(")", sep + strValue + ")");
      retStr = fields + " values " + values;

      return retStr;

    }



    public string MakeUpdateSQL(string SQLStr, string FieldName, object Value)
    {
      string retStr = "";
      string sep = "";

      if (SQLStr.Length == 0)
      {
        retStr = " set ";
        sep = "";
      }
      else
      {
        retStr = SQLStr;
        sep = ",";
      }
      string strValue = this.GetStrValue(Value);

      retStr = retStr + sep + " " + FieldName + "=" + strValue;
      return retStr;
    }


    public string GetXML(string strCom, long Page, long RowsPerPage)
    {
      return this.GetXMLRs("Records", "Record", strCom, Page, RowsPerPage);
    }


    public string GetXML(string RootNodeName, string NodeName, string strCom, long Page, long RowsPerPage)
    {
      return this.GetXMLRs(RootNodeName, NodeName, strCom, Page, RowsPerPage);
    }


    private string GetXMLRs(string NodeName, string SubNodeName, string strCom, long Page, long RowsPerPage)
    {

      XMLHelper oLibXML = new XMLHelper();
      string GetXML = "";

      o.TotalRows = this.RowCount(strCom);

      Database db = DatabaseFactory.CreateDatabase("Local");
      DbCommand cmd = db.GetSqlStringCommand(strCom);
      DbConnection cnn = db.CreateConnection();
      cmd.Connection = cnn;

      try
      {
        cnn.Open();
        DbDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
          GetXML = oLibXML.RsToXMLStr(reader, NodeName, SubNodeName, Page, RowsPerPage);
        else
          GetXML = "<" + NodeName.Trim() + "/>";

        reader.Close();
        return GetXML;
      }
      finally
      {
        cnn.Close();
        oLibXML = null;
      }
    }


    private string GetStrValue(object Value)
    {
      string strValue = "";
      if (Value == null)
      {
        strValue = "null";
      }
      else
      {
        switch (Value.GetType().ToString())
        {
          case "System.String":
            strValue = "'" + Value.ToString().Replace("'", "\'").Replace(",", ".") + "'";
            break;

          case "System.Boolean":
            strValue = ((System.Convert.ToBoolean(Value)) ? System.Convert.ToString(1) : System.Convert.ToString(0));
            break;

          case "System.Int16":
            strValue = System.Convert.ToInt16(Value).ToString();
            break;
          case "System.Int32":
            strValue = System.Convert.ToInt32(Value).ToString();
            break;
          case "System.Int64":
            strValue = System.Convert.ToInt64(Value).ToString();
            break;

          case "System.Decimal":
            //strValue = System.Convert.ToDouble(Value).ToString();
            strValue = "'" + Value.ToString().Replace(",", ".") + "'";
            break;

          case "System.DateTime":
            strValue = "'" + System.DateTime.Parse(Value.ToString()).ToString("dd/MM/yyyy hh:mm:ss") + "'";
            //strValue = "'" + System.DateTime.Parse(Value.ToString()).ToString("yyyy-MM-dd hh:mm:ss") + "'";
            break;
          //case "System.Nullable":
          //  strValue = null;
          //  //strValue = "'" + System.DateTime.Parse(Value.ToString()).ToString("yyyy-MM-dd hh:mm:ss") + "'";
          //  break;

        }
      }
      return strValue;
    }


    private long RowCount(string strSQL)
    {

      string sqlCount = "";
      long count = 0;


      Database db = DatabaseFactory.CreateDatabase("Local");
      DbConnection cnn = db.CreateConnection();
      DbCommand cmd = null;
      DbDataReader reader = null;

      if (strSQL.ToLower().IndexOf("group", 0) > 0)
      {
        sqlCount = "select count(*) as TotalRows " + strSQL.Substring(strSQL.ToLower().LastIndexOf("from"));

        cmd = db.GetSqlStringCommand(sqlCount);
        cmd.Connection = cnn;
        cnn.Open();
        reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
          reader.Read();
          count = reader.GetInt32(0);
        }

        reader.Close();
      }
      else
      
      {
        if (strSQL.ToLower().IndexOf("order", 0) > 0)
        {
          int i1 = strSQL.ToLower().IndexOf("select");
          int i2 = strSQL.ToLower().LastIndexOf("order");
          

          strSQL = strSQL.Substring(i1, i2-1);
          sqlCount = "select count(*) as TotalRows " + strSQL.Substring(strSQL.ToLower().LastIndexOf("from"));
          cmd = db.GetSqlStringCommand(sqlCount);
          cmd.Connection = cnn;
          cnn.Open();
          reader = cmd.ExecuteReader();

          if (reader.HasRows)
          {
            reader.Read();
            count = reader.GetInt32(0);
          }
          reader.Close();
        }
        
        else
        {
          sqlCount = "SELECT COUNT(*) as TotalRows " + strSQL.Substring(strSQL.ToLower().LastIndexOf("from"));

          cmd = db.GetSqlStringCommand(sqlCount);
          cmd.Connection = cnn;
          cnn.Open();
          reader = cmd.ExecuteReader();

          if (reader.HasRows)
          {
            reader.Read();
            count = reader.GetInt32(0);
          }

          reader.Close();
        }
      }
      cnn.Close();
      db = null;
      return count;
    }



    private decimal Totaldeuda(string strSQL)
    {
      string sqlSum = "";
      decimal total = 0;

      Database db = DatabaseFactory.CreateDatabase("Local");
      DbConnection cnn = db.CreateConnection();
      DbCommand cmd = null;
      DbDataReader reader = null;

      if (strSQL.ToLower().IndexOf("group", 0) > 0)
      {
        sqlSum = "select sum(debe) as Totaldeuda " + strSQL.Substring(strSQL.ToLower().LastIndexOf("from"));

        cmd = db.GetSqlStringCommand(sqlSum);
        cmd.Connection = cnn;
        cnn.Open();
        reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
          reader.Read();
          total = reader.GetInt32(0);
        }

        reader.Close();
      }
      else
      {
        sqlSum = "SELECT sum(debe) as Totaldeuda " + strSQL.Substring(strSQL.ToLower().LastIndexOf("from"));
        cmd = db.GetSqlStringCommand(sqlSum);
        cmd.Connection = cnn;
        cnn.Open();
        reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
          reader.Read();
          total = reader.GetDecimal(0);
        }

        reader.Close();
      }
      cnn.Close();
      db = null;
      return total;
    }



    public DataSet Pagination(string tableName, string strSQL, int Page, int RowsPerPage, string OrderBy, string Order)
    {
      o.TotalRows = this.RowCount(strSQL);
      if (OrderBy.Trim().Length > 0)
      {
        strSQL += " Order by " + OrderBy + " " + Order;
      }
      Database db = DatabaseFactory.CreateDatabase("Local");
      DbConnection cnn = db.CreateConnection();
      DbCommand cmd = db.GetSqlStringCommand(strSQL);
      cmd.Connection = cnn;

      DbDataAdapter adapter = db.GetDataAdapter();
      adapter.SelectCommand = cmd;

      DataSet ds = new DataSet();

      try
      {
        cnn.Open();
        adapter.Fill(ds, Page, RowsPerPage, tableName);
        return ds;
      }
      catch (SqlException e)
      {
        throw e;
      }
      finally { cnn.Close(); }
    }

    public DataSet Pagination(string strSQL, int Page, int RowsPerPage, string OrderBy, string Order)
    {
      o.TotalRows = this.RowCount(strSQL);
      if (OrderBy.Trim().Length > 0)
      {
        strSQL += " Order by " + OrderBy + " " + Order;
      }
      Database db = DatabaseFactory.CreateDatabase("Local");
      DbConnection cnn = db.CreateConnection();
      DbCommand cmd = db.GetSqlStringCommand(strSQL);
      cmd.Connection = cnn;

      DbDataAdapter adapter = db.GetDataAdapter();
      adapter.SelectCommand = cmd;

      DataSet ds = new DataSet();

      try
      {
        cnn.Open();
        adapter.Fill(ds, Page, RowsPerPage, "Result");
        return ds;
      }
      catch (SqlException e)
      {
        throw e;
      }
      finally { cnn.Close(); }
    }


    public int NewID(string tableName, string campo, string condicion)
    {
      int id = 0;
      int resultado = 0;
      string strSQL = "";
      strSQL = "Select isnull(max(" + campo + "),0) as mayor ";
      strSQL += " FROM " + tableName;
      if (condicion.Trim() != "")
      {
        strSQL += " where " + condicion;
      }
      Database db = DatabaseFactory.CreateDatabase("Local");
      DbConnection cnn = db.CreateConnection();
      try
      {
        cnn.Open();
        resultado = Convert.ToInt16((db.ExecuteScalar(CommandType.Text, strSQL)));
        if (resultado != 0)
          id = resultado;
        else
          id = 0;

        if (id > 0)
          id = id + 1;
        else
          id = 1;
        return id;
      }
      catch (Exception ex)
      {
        System.Console.WriteLine("Error, no se pudo obtener el prox. c�digo, " + ex.Message);
        throw new Exception(ex.Message);
        /*EventLog.WriteEntry("netLibraty - nvoCodigo ", ex.Message);*/
      }
      finally { cnn.Close(); }
    }


    public DataSet GetDataSet(string strSQL, string tableName, int lngMaxRegistros)
    {
      o.TotalRows = this.RowCount(strSQL);
      int p = 0;
      if (lngMaxRegistros > 0)
      {
        strSQL = strSQL.Trim();
        ///Busco el Primer espacio en la cadena SQL.
        p = strSQL.IndexOf(" ", 0);
        ///Inserto la clausula TOP
        strSQL = strSQL.Insert(p - 1, " TOP " + lngMaxRegistros);
      }

      Database db = DatabaseFactory.CreateDatabase("Local");
      DbCommand cmd = db.GetSqlStringCommand(strSQL);
      DbConnection cnn = db.CreateConnection();
      cmd.Connection = cnn;
      cnn.Open();
      DbDataAdapter adapter = db.GetDataAdapter();
      adapter.SelectCommand = cmd;

      DataSet ds = new DataSet();

      try
      {
        adapter.Fill(ds, tableName);
        return ds;
      }
      catch (SqlException e)
      {
        throw e;
      }
      finally
      {
        cnn.Close();
      }
    }

    public DataSet GetDataSet2(string strSQL, string tableName, int lngMaxRegistros)
    {
      //o.TotalRows = this.RowCount(strSQL);
      int p = 0;
      if (lngMaxRegistros > 0)
      {
        strSQL = strSQL.Trim();
        ///Busco el Primer espacio en la cadena SQL.
        p = strSQL.IndexOf(" ", 0);
        ///Inserto la clausula TOP
        strSQL = strSQL.Insert(p - 1, " TOP " + lngMaxRegistros);
      }

      Database db = DatabaseFactory.CreateDatabase("Local");
      DbCommand cmd = db.GetSqlStringCommand(strSQL);
      DbConnection cnn = db.CreateConnection();
      cmd.Connection = cnn;
      cnn.Open();
      DbDataAdapter adapter = db.GetDataAdapter();
      adapter.SelectCommand = cmd;

      DataSet ds = new DataSet();

      try
      {
        adapter.Fill(ds, tableName);
        return ds;
      }
      catch (SqlException e)
      {
        throw e;
      }
      finally
      {
        cnn.Close();
      }
    }

    public IDataReader GetDataReader(string strSQL, string tableName, int lngMaxRegistros)
    {
      //o.TotalRows = this.RowCount(strSQL);
      int p = 0;
      if (lngMaxRegistros > 0)
      {
        strSQL = strSQL.Trim();
        ///Busco el Primer espacio en la cadena SQL.
        p = strSQL.IndexOf(" ", 0);
        ///Inserto la clausula TOP
        strSQL = strSQL.Insert(p - 1, " TOP " + lngMaxRegistros);
      }

      Database db = DatabaseFactory.CreateDatabase("Local");
      DbCommand cmd = db.GetSqlStringCommand(strSQL);
      DbConnection cnn = db.CreateConnection();
      cmd.Connection = cnn;
      cnn.Open();
      try
      {
        IDataReader reader = db.ExecuteReader(cmd);

        return reader;
      }
      catch (SqlException e)
      {
        throw e;
      }
      finally
      {
        cnn.Close();
      }
    }






    #region Funciones Varias para ADONET
    //public DataSet FillDataset(string strSQL, string tableName)
    //{ 
    //  //this.OpenConn();
    //  this.OpenConn();
    //  SqlCommand cmd         = new SqlCommand(strSQL,this.conn);
    //  SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    //  DataSet ds             = new DataSet();
    //  adapter.Fill(ds,tableName);
    //  //this.CloseConn();
    //  this.CloseConn();
    //  return ds;
    //}

    //public DataSet GetDS(string strSQL, string tableName,int lngMaxRegistros)
    //{
    //  int p = 0;
    //  if (lngMaxRegistros > 0)
    //  {
    //    strSQL = strSQL.Trim();
    //    ///Busco el Primer espacio en la cadena SQL.
    //    p      = strSQL.IndexOf(" ",0);
    //    ///Inserto la clausula TOP
    //    strSQL = strSQL.Insert(p-1," TOP " + lngMaxRegistros);
    //  }
    //  DataSet ds             = new DataSet();
    //  ds                     = FillDataset(strSQL,tableName);
    //  return ds;
    //}

    //public DataTable GetTableSchema(string tableName)
    //{
    //  //this.OpenConn();
    //  this.OpenConn();
    //  SqlDataAdapter adapter = new SqlDataAdapter();
    //  DataTable table        = null;
    //  string strSQL          = "Select * From " + tableName;
    //  adapter.SelectCommand  = new SqlCommand(strSQL,this.conn);
    //  DataSet ds             = new DataSet(tableName);
    //  try
    //  {
    //    adapter.Fill(ds);
    //    table = ds.Tables[0];
    //    return table;
    //  }
    //  catch (Exception ex)
    //  {
    //    /*EventLog.WriteEntry("netLibraty - obtenerEstructura ", ex.Message);
    //    System.Console.WriteLine("Error, no se pudo obtener la estructuta de la tabla " +         ex.Message);*/
    //    throw ex;
    //  }
    //  finally
    //  {
    //    //this.CloseConn();
    //    this.CloseConn();
    //    adapter = null;
    //    ds      = null;
    //  }
    //}
    ////[AutoComplete]
    //public long NewID(string tableName, string campo, string condicion)
    //{ 
    //  long id = 0;
    //  string strSQL = "";
    //  strSQL  = "Select max(" + campo + ") as mayor ";
    //  strSQL += " FROM " + tableName;
    //  if (condicion.Trim()!="")
    //  {
    //    strSQL += " " + condicion;
    //  }
    //  //this.OpenConn(); 
    //  this.OpenConn();
    //  SqlCommand cmd   = new SqlCommand(strSQL);
    //  try
    //  { 
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = strSQL;
    //    cmd.Connection  = this.conn;
    //    string resultado = cmd.ExecuteScalar().ToString();

    //    if (resultado != "")
    //      id = Convert.ToInt64(resultado);
    //    else
    //      id = 0;

    //    if (id > 0)
    //      id = id + 1;
    //    else
    //      id = 1;
    //    return id;
    //  }
    //  catch(Exception ex)
    //  {
    //    System.Console.WriteLine("Error, no se pudo obtener el prox. c�digo, " + ex.Message);
    //    throw ex;
    //    /*EventLog.WriteEntry("netLibraty - nvoCodigo ", ex.Message);*/
    //  }
    //  finally
    //  {
    //    //this.CloseConn();
    //    this.CloseConn();
    //    cmd = null;
    //  }
    //}

    ////[AutoComplete]
    //public bool ExecSql(string strSQL)
    //{
    //  //this.OpenConn();
    //  this.OpenConn();
    //  SqlCommand cmd   = new SqlCommand(strSQL,this.conn);

    //  try
    //  { 
    //    cmd.ExecuteNonQuery();
    //    return true;
    //  }
    //  catch(Exception ex)
    //  {
    //    /*EventLog.WriteEntry("netLibrary - executeSQL", ex.Message);
    //    System.Console.WriteLine("Error, problemas con la Consulta, " + ex.Message);*/
    //    throw ex;
    //  }
    //  finally
    //  { 
    //    cmd = null;         
    //    //this.CloseConn();
    //    this.CloseConn();

    //  }
    //}

    ////[AutoComplete]
    //public bool UpdateDS(DataSet ds, string tableName, string campo)
    //{
    //  string strSQL    = "";
    //  strSQL           = "SELECT * FROM " + tableName; 
    //  strSQL          += " WHERE " + campo + " is null"; 
    //  //this.OpenConn();
    //  this.OpenConn();
    //  SqlDataAdapter adapter  = new SqlDataAdapter(strSQL,this.conn);
    //  SqlCommandBuilder cmdCB = new SqlCommandBuilder(adapter);
    //  try
    //  {
    //    if (ds.HasChanges())
    //    {
    //      adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
    //      adapter.Update(ds,tableName);
    //    }
    //    return true;
    //  }
    //  catch(Exception ex)
    //  {
    //    /*EventLog.WriteEntry("netLibrary - abm", ex.Message);
    //    System.Console.WriteLine("Error en la actualizac�n, " + ex.Message);*/
    //    throw ex;
    //  }
    //  finally
    //  {
    //    adapter = null;
    //    cmdCB = null;
    //    //this.CloseConn();
    //    this.CloseConn();
    //  }
    //}
    //public bool UpdateDS2(DataSet ds, string tableName, string campo)
    //{
    //  string strSQL    = "";
    //  strSQL           = "SELECT * FROM " + tableName; 
    //  strSQL          += " WHERE " + campo + " is null"; 
    //  //this.OpenConn(); 
    //  this.OpenConn();
    //  SqlDataAdapter adapter  = new SqlDataAdapter(strSQL,this.conn);
    //  SqlCommandBuilder cmdCB = new SqlCommandBuilder(adapter);
    //  try 
    //  {
    //    adapter.Update(ds,tableName);
    //    return true;
    //  }
    //  catch(Exception ex) 
    //  {
    //    throw ex;
    //  }
    //  finally 
    //  {
    //    adapter = null;
    //    cmdCB   = null;
    //    //this.CloseConn();
    //    this.CloseConn();
    //  }
    //}

    ///*public SqlDataReader dr(string strSQL,string sp)
    //{
    //  SqlConnection cn = new SqlConnection(this.strConn.Trim());
    //  SqlCommand cmd   = new SqlCommand(sp,cn);
    //  cmd.CommandType  = CommandType.StoredProcedure;
    //  SqlDataReader dr = new SqlDataReader();
    //  //cn     = null;
    //  //cmd    = null;
    //  //dr     = null;
    //}*/

    //public int ExecuteSP (string strSP, SqlParameter sqlParametros)
    //{
    //  //this.OpenConn();
    //  this.OpenConn();
    //  SqlCommand cmd   = new SqlCommand(strSP, this.conn);
    //  int intReturn    = 0;
    //  try
    //  {
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    if (sqlParametros != null)
    //    {
    //      //this. BuildInputParam(sqlParametros, cmd);
    //    }
    //    intReturn = cmd.ExecuteNonQuery();
    //  }
    //  catch(Exception ex)
    //  {
    //    throw ex;
    //  }
    //  finally
    //  {
    //    cmd = null;
    //    //this.CloseConn();
    //    this.CloseConn();
    //  }
    //  return intReturn;
    //}

    #endregion

  }
}
