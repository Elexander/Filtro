using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
class Grupo : Conexion
{
    #region atributos
    private string _id, _nombre;
    private Equipo _equipos;

    #endregion

    #region Propiedades
    /// <summary>
    /// Identificador del Grupo
    /// </summary>
    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }
    /// <summary>
    /// Letra del Grupo
    /// </summary>
    public string Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }
    /// <summary>
    /// Equipo al que pertenece el Grupo
    /// </summary>
    public Equipo Equipos
    {
        get { return _equipos; }
        set { _equipos = value; }
    }
    #endregion

    #region Constructores
    public Grupo() 
    {
        _id = "";
        _nombre = "";
    }
    public Grupo(string id)
    {
        string consulta = "select gru_id,gru_nombre from grupos where gru_id="+id;

        DataRow registro = LeerRegistro(consulta);

        if (registro != null)
        {
            _id = registro["gru_id"].ToString();
            _nombre = registro["gru_nombre"].ToString();
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
