using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
class Equipo : Conexion
{
    #region atributos
    private string _id, _nombre;
    private Confederacion _confederacion;
    private Grupo _grupo;
    private byte[] _logo;
    #endregion 

    #region propiedades
    public string Id
    {
        get { return _id; }
        set { _id = value; }
    }
    public string Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }

    public Confederacion Confederacion
    {
        get { return _confederacion; }
        set { _confederacion = value; }
    }
    public Grupo Grupo
    {
        get { return _grupo; }
        set { _grupo = value; }
    }
    public Image Logo
    {
        get { return Convertidor.ByteAImage(_logo); }
        set { _logo = Convertidor.ImageAByte(value); }
    }
    #endregion

    #region constructores

    public Equipo() 
    {
        _id = "";
        _nombre = "";
        _confederacion = new Confederacion();
        _grupo = new Grupo();
        _logo = null;
    }

    public Equipo(string id) 
    { 
        
    }

    #endregion

    #region metodos

    public bool Agregar() 
    {
        string instruccion = "insert into equipos (equ_id,equ_nombre,equ_id_grupo,equ_id_confederacion,equ_logo) values ( @id , @nombre , @grupo , @conf , @logo );";

        SqlCommand comando = new SqlCommand(instruccion);

        comando.Parameters.Add(new SqlParameter("@id", _id));
        comando.Parameters.Add(new SqlParameter("@nombre", _nombre));
        comando.Parameters.Add(new SqlParameter("@grupo", _grupo.Id));
        comando.Parameters.Add(new SqlParameter("@conf", _confederacion.Id));
        comando.Parameters.Add(new SqlParameter("@logo", _logo));

        return EjecutarComando(comando);
    }

    #endregion

}

