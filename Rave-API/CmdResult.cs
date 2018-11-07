using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Rave_API
{
    public class CmdResult
    {
        private int _Code;
        private string _Msg;
        private DataSet _Ds = null;


        public int Code
        {
            get
            {
                return _Code;
            }
        }

        public string Msg
        {
            get
            {
                return _Msg;
            }
        }

        public DataSet DS
        {
            get
            {
                return _Ds;
            }
        }

        public CmdResult(DataSet ds)
        {
            DataRow result = ds.Tables[ds.Tables.Count - 1].Rows[0];
            ds.Tables[ds.Tables.Count - 1].TableName = "Result";
            _Code = System.Convert.ToInt32(result["code"]);
            _Msg = result["msg"].ToString().Replace("[[CRLF]]", System.Environment.NewLine);
            _Ds = ds;
        }

        public CmdResult(int aCode, string aMsg)
        {
            _Code = aCode;
            _Msg = aMsg;
        }


        public CmdResult(int aCode, string aMsg, DataSet ds)
        {
            _Code = aCode;
            _Msg = aMsg;
            DataTable codeTbl = new DataTable();
            codeTbl.TableName = "Result";
            codeTbl.Columns.Add("code", typeof(int));
            codeTbl.Columns.Add("msg", typeof(string));
            codeTbl.Rows.Add(_Code, _Msg);
            ds.Tables.Add(codeTbl);
            _Ds = ds;
        }
    }
}