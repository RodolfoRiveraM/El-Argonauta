﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Equipo
{
    casco,armadura,arma
}

[CreateAssetMenu(menuName = "ObjetosEscriptables/items/Equipamiento")]
public class Equipamiento : Item
{
    public Equipo tipoDeEquipamiento;
    public int salud;
    public int ataque;
    public int velocidad;

    public override bool UsarItem()
    {
        //Equipar o desequipar
        Equipamiento equipamientoActualmenteEquipado = PanelEquipamiento.instance.EquiparObjeto(this);
        
        if (equipamientoActualmenteEquipado)
        {
            PanelEquipamiento.instance.RemoverEquipo(equipamientoActualmenteEquipado);
            Inventario.instance.AgregarObjeto(equipamientoActualmenteEquipado, 1);
        }
        return true;
    }
}
