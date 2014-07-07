using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
class Jugador : Conexion
{
    #region atributos
    private string _id;
    private string _nombre;
    private int _numero;
    private Posicion _posicion;
    private Equipo _equipo;
    private byte[] _foto;
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


    public int Numero
    {
        get { return _numero; }
        set { _numero = value; }
    }

    public Posicion Posicion
    {
        get { return _posicion; }
        set { _posicion = value; }
    }

    public Equipo Equipo
    {
        get { return _equipo; }
        set { _equipo = value; }
    }

    public Image Foto
    {
        get { return Convertidor.ByteAImage(_foto); }
        set { _foto = Convertidor.ImageAByte(value); }
    }

    #endregion

    #region constructores

    public Jugador()
    {
        _id = "";
        _nombre = "";
        _numero = 0;
    }

    public Jugador(string id)
    {
        string consulta = " select jug_id,jug_nombre,jug_numero,jug_id_posicion,jug_foto,jug_id_equipo from jugadores where jug_id = '" + id + "'";
        DataRow registro = LeerRegistro(consulta);
        if (registro != null)
        {

        }
    }
    
    #endregion

    #region metodos

    /*public bool Agregar()
    {
        //Ojo, parece que solo inserta con formato PNG, no con JPG
        string instruccion = "insert into carros(car_id,car_id_modelo,car_anio,car_precio,car_foto) values (@NUMERO,@MODELO,@ANIO,@PRECIO,@FOTO)";
        //crear comando
        SqlCommand comando = new SqlCommand(instruccion);
        comando.Parameters.Add(new SqlParameter("@NUMERO", _id));
        comando.Parameters.Add(new SqlParameter("@MODELO", _modelo.Id.ToString()));
        comando.Parameters.Add(new SqlParameter("@ANIO", _anio));
        comando.Parameters.Add(new SqlParameter("@PRECIO", _precio));
        comando.Parameters.Add(new SqlParameter("@FOTO", _fotografia));

        //ejecutar comando
        return EjecutarComando(comando);
    }*/

    public bool Agregar()
    {
        string instruccion = "  insert into jugadores(jug_id,jug_nombre,jug_numero,jug_id_posicion,jug_foto,jug_id_equipo) values(@ID,@NOMBRE,@NUMERO,@POSICION,@FOTO,@EQUIPO) ";
        SqlCommand comando = new SqlCommand(instruccion);
        comando.Parameters.Add(new SqlParameter("@ID", _id));
        comando.Parameters.Add(new SqlParameter("@NOMBRE", _nombre));
        comando.Parameters.Add(new SqlParameter("@NUMERO", _numero));
        comando.Parameters.Add(new SqlParameter("@POSICION", Posicion.Id.ToString()));
        comando.Parameters.Add(new SqlParameter("@FOTO", _foto));
        comando.Parameters.Add(new SqlParameter("@EQUIPO", Equipo.Id.ToString()));
        return EjecutarComando(comando);
    }

    #endregion
}

