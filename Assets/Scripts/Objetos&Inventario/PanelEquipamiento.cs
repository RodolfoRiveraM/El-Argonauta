using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelEquipamiento : MonoBehaviour
{
    public static PanelEquipamiento instance;
    public Atributos atributos;
    public CasillaEquipamiento[] casillaEquipamientos;
    public List<Equipamiento> equipamientos = new List<Equipamiento>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        casillaEquipamientos = GetComponentsInChildren<CasillaEquipamiento>();
    }

    public Equipamiento EquiparObjeto(Equipamiento equipamiento)
    {
        foreach(CasillaEquipamiento casillaEquipo in casillaEquipamientos)
        {
            if (equipamiento.tipoDeEquipamiento == casillaEquipo.tipoEquipamiento)
            {
                if (!casillaEquipo.itemAlmacenado)
                {
                    Debug.Log("Casilla esta Vacia");
                    AgregarEquipo(equipamiento, casillaEquipo);
                    return null;
                }
                else
                {
                    Equipamiento objetoEquipado = casillaEquipo.itemAlmacenado as Equipamiento;
                    AgregarEquipo(equipamiento, casillaEquipo);
                    return objetoEquipado;
                }
            }
        }
        return null;
    }

    private void AgregarEquipo(Equipamiento equipamiento,CasillaEquipamiento casillaEquipamiento)
    {
        casillaEquipamiento.AgregarObjeto(equipamiento, 1);
        equipamientos.Add(equipamiento);
        atributos.ActualizarEquipamiento(equipamientos);
    }

    public void RemoverEquipo(Equipamiento equipamiento)
    {
        equipamientos.Remove(equipamiento);
        atributos.ActualizarEquipamiento(equipamientos);
    }

}
