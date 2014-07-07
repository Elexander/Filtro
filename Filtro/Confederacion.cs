using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
class Confederacion : Conexion
{
    #region atributos
    private string _id, _nombre;
    #endregion

    #region Propiedades
    public string Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }

    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }
    #endregion

     #region Constructores
    public Confederacion() 
    {
        _id = "";
        _nombre = "";
    }
    public Confederacion(string id)
    {
        string consulta = "select con_id,con_nombre from confederaciones where con_id="+id;

        DataRow registro = LeerRegistro(consulta);

        if (registro != null)
        {
            _id = registro["con_id"].ToString();
            _nombre = registro["con_nombre"].ToString();
        }
        else
        {
            _id = "";
            _nombre = "";
        }

    }
    #endregion

    #region Metodos    
    public override string ToString()
    {
        return _nombre;
    }
  
    #endregion
}
