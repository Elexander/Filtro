using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class Conexion
{
    #region atributos

    private static string _cadenaConexion = ConfigurationManager.ConnectionStrings["cadenaConexion"].ConnectionString;
    private static SqlConnection _conexion = new SqlConnection();

    #endregion

    #region métodos

    /// <summary>
    /// Abre una conexión al servidor de base de datos
    /// </summary>
    /// <returns></returns>
    private static bool Conectar()
    {
        //resultado
        bool conectado = false;
        //cadena de conexion
        _conexion.ConnectionString = _cadenaConexion;
        //intentar abrir conexión
        try
        {
            _conexion.Open(); //abrir conexión
            conectado = true; //si se pudo conectar
        }
        catch (SqlException ex)
        {
        }
        //regresar resultado
        return conectado;
    }
    /// <summary>
    /// Cierra la conexión al servidor de base de datos
    /// </summary>
    private static void Desconectar()
    {
        if (_conexion.State==ConnectionState.Open) _conexion.Close(); //cerra conexión
    }
    /// <summary>
    /// Ejecuta una consulta de SQL y regresa la tabla resultante
    /// </summary>
    /// <param name="consulta">Consulta de SQL</param>
    /// <returns></returns>
    protected static DataTable LeerTabla(string consulta)
    {
        //tabla de resultado
        DataTable tabla = new DataTable();
        //conectarse al servidor de base de datos
        if (Conectar())
        {
            //comando
            SqlCommand comando = new SqlCommand(consulta, _conexion);
            //adaptador
            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            //intentar ejecutar consulta
            try
            {
                adaptador.Fill(tabla); //ejecutar consulta, llenar tabla
                
            }
            catch (SqlException ex)
            {
            }
            Desconectar(); //cerrar la conexión
        }
        //regresar tabla de resultados
        return tabla;
    }
    /// <summary>
    /// Ejecuta una consulta de SQL filtrada por la llave primaria 
    /// y regresa el registro resultante
    /// </summary>
    /// <param name="consulta">Consulta de SQL</param>
    /// <returns></returns>
    protected static DataRow LeerRegistro(string consulta)
    {
        //registro
        DataRow registro = null;
        //ejecutar consulta
        DataTable tabla = LeerTabla(consulta);
        //verificar si se encontró el registro
        if (tabla.Rows.Count > 0) registro = tabla.Rows[0];
        //regresar registro
        return registro;
    }
    /// <summary>
    /// Ejecuta una instrucción de SQL que no sea consulta
    /// (INSERT, UPDATE o DELETE)
    /// </summary>
    /// <param name="instruccion">Instrucción de SQL</param>
    /// <returns></returns>
    protected static bool EjecutarInstruccion(string instruccion)
    {
        //resultado
        bool ejecutado = false;
        //abrir conexion
        if (Conectar())
        {
            try
            {
                //comando
                SqlCommand comando = new SqlCommand(instruccion, _conexion);
                //ejecutrar instruccion
                comando.ExecuteNonQuery();
                //ejecutado sin error
                ejecutado = true;
            }
            catch (SqlException ex)
            {
            }
            //cerrar conexion
            Desconectar();
        }
        //regresar resultado
        return ejecutado;
    }
    /// <summary>
    /// Ejecuta un comando de SQL con parámetros
    /// </summary>
    /// <param name="comando">Comando de SQL</param>
    /// <returns></returns>
    protected static bool EjecutarComando(SqlCommand comando)
    {
        //resultado
        bool ejecutado = false;
        //abrir conexion
        if (Conectar())
        {
            try
            {
                //asignar conexión a comando
                comando.Connection = _conexion;
                //ejecutrar instruccion
                comando.ExecuteNonQuery();
                //ejecutado sin error
                ejecutado = true;
            }
            catch (SqlException ex)
            {
            }
            //cerrar conexion
            Desconectar();
        }
        //regresar resultado
        return ejecutado;
    }
    /// <summary>
    /// Ejecuta un procedimiento almacenado
    /// </summary>
    /// <param name="comando">Comando de SQL</param>
    /// <returns></returns>
    protected static bool EjecutarProcedimiento(SqlCommand comando)
    {
        return false;
    }

    #endregion
}
