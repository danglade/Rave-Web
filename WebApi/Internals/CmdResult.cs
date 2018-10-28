using System;
using System.Data;

public class CmdResult
{
    private int _Code;
    private string _Msg;
    private DataSet _Ds = null;
    public int Code
    {
        get { return _Code; }
    }
    public string Msg
    {
        get { return _Msg; }
    }
    public DataSet DS
    {
        get { return _Ds; }
    }
    private void ConsiderToTerminate()
    {
        if (_Code != -777777777)
            return;
        if ((_Msg == null) || string.IsNullOrEmpty(_Msg))
        {
            _Msg = "A message code to restart has been received. Pls login again!";
        }

        System.Environment.Exit(1);
    }
    public CmdResult(DataSet ds)
    {
        DataRow result = ds.Tables[ds.Tables.Count - 1].Rows[0];
        _Code = Convert.ToInt32(result["code"]);
        _Msg = result["msg"].ToString().Replace("[[CrLf]]", System.Environment.NewLine);
        ConsiderToTerminate();
        _Ds = ds;
        _Ds.Tables[ds.Tables.Count - 1].TableName = "Result";
    }
    public CmdResult(int aCode, string aMsg)
    {
        _Code = aCode;
        _Msg = aMsg;
        _Ds.Tables[_Ds.Tables.Count - 1].TableName = "Result";
        ConsiderToTerminate();
    }
    public CmdResult(int aCode, string aMsg, DataSet ds)
    {
        _Code = aCode;
        _Msg = aMsg;
        ConsiderToTerminate();
        DataTable codeTbl = new DataTable();
        codeTbl.Columns.Add("code", typeof(int));
        codeTbl.Columns.Add("msg", typeof(string));
        codeTbl.Rows.Add(_Code, _Msg);
        ds.Tables.Add(codeTbl);
        _Ds.Tables[_Ds.Tables.Count - 1].TableName = "Result";
        _Ds = ds;

    }
}
