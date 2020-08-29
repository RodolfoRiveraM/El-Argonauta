using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public bool inventarioLleno;
    public static Inventario instance;
    private Casilla[] casillas;
    private List<Item> objetos = new List<Item>();
    private int casillaVacia = 0;

    private void Awake()
    {
        instance = this;
        casillas = GetComponentsInChildren<Casilla>();
    }

    void DeterminarSiguienteCasillaVacia()
    {
        casillaVacia = 0;
        foreach (Casilla casilla in casillas)
        {
            if (casilla.itemAlmacenado)
            {
                casillaVacia++;
            }
            else
            {
                break;
            }
        }
        if (casillaVacia >= casillas.Length)
        {
            inventarioLleno = true;
        }
    }

    public bool AgregarObjeto(Item item, int cantidad)
    {
        DeterminarSiguienteCasillaVacia();
        //El inventario esta lleno? el objeto a gregar es apilable? si es apilable, tengo una copia de este en mi inventario
        if ((item.apilable && !objetos.Contains(item) && !inventarioLleno) || (!item.apilable && !inventarioLleno))
        {
            //nuestro item es apilable y no tenemos copia de el o nuestro objeto no es apilable
            Casilla casillaAñadir = casillas[casillaVacia];
            objetos.Add(item);
            casillaAñadir.AgregarObjeto(item, cantidad);
            return true;
        }
        else if (item.apilable == true && objetos.Contains(item))
        {
            //Nuestro objeto es apilable y tenemos una copia de el en alguna casilla
            for (int i = 0; i < casillas.Length; i++)
            {
                if (item == casillas[i].itemAlmacenado)
                {
                    casillas[i].cantidadStock += cantidad;
                    break;
                }
            }
            return true;

        }
        else
        {
            Debug.Log("InventarioLleno");
            return false;
        }
    }

    public void RemoverObjeto(Item item)
    {
        objetos.Remove(item);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
