using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

class Posicion : Conexion
{
    #region atributos

    private string _id;
    private string _descripcion;

    #endregion

    #region propiedades

    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Descripcion
    {
        get{ return _descripcion;}
        set {_descripcion = value;}
    }

    #endregion

    #region constructores

    public Posicion()
    {
        _id = "";
        _descripcion = "";
    }

    public Posicion(string id)
    {
        string consulta = " select pos_id, pos_descripcion from posiciones where pos_id = '" + id + "'";
        DataRow registro = LeerRegistro(consulta);
        if (registro != null)
        {
            _id = id;
            _descripcion = registro["pos_descripcion"].ToString();
        }
        else
        {
            _id = "";
            _descripcion = "";
        }
    }

    #endregion

    #region metodos

    public override string ToString()
    {
        return _descripcion;
    }

    #endregion
}
