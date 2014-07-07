using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

class Catalogo : Conexion
{
    public static List<Posicion> Posiciones()
    {
        List<Posicion> Posiciones = new List<Posicion>();
        string consulta = "  select pos_id, pos_descripcion from posiciones ";
        DataTable tabla = LeerTabla(consulta);
        foreach (DataRow registro in tabla.Rows)
        {
            Posiciones.Add(new Posicion(registro["pos_id"].ToString()));
        }
        return Posiciones;
    }
    public static List<Equipo> Equipos()
    {
        List<Equipo> Equipos = new List<Equipo>();
        string consulta = "  select equ_id,equ_nombre,equ_id_grupo, equ_id_confederacion from equipos ";
        DataTable tabla = LeerTabla(consulta);
        foreach (DataRow registro in tabla.Rows)
        {
            Equipos.Add(new Equipo(registro["equ_id"].ToString()));
        }
        return Equipos;
    }
}

