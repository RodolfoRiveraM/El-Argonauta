using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputPlayer : MonoBehaviour
{

   [HideInInspector] public float ejeHorizontal {get; private set; }
   [HideInInspector] public float ejeVertical  {get; private set; }
   [HideInInspector] public bool atacar       {get; private set; }
   [HideInInspector] public bool habilidad1    {get; private set; }
   [HideInInspector] public bool habilidad2   {get; private set; }
   [HideInInspector] public bool inventario   {get; private set; }
   [HideInInspector] public bool interactuar   {get; private set; }

    [HideInInspector]
    public Vector2  direccionMirada = new Vector2(0, -1f);

    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //atacar = Input.GetKeyDown("KeyCode.A");
        atacar = Input.GetButtonDown("Atacar");
        habilidad1 = Input.GetButtonDown("Habilidad1");
        habilidad2 = Input.GetButtonDown("Habilidad2");
        inventario = Input.GetButtonDown("Inventario");
        interactuar = Input.GetButtonDown("Interactuar");

        //DEfinir ejes de movimiento
        ejeHorizontal = Input.GetAxis("Horizontal");
        ejeVertical = Input.GetAxis("Vertical");

        DeterminarDireccionMirada();
        Debug.DrawLine(transform.position, transform.position + (Vector3)direccionMirada * 3);

    }

    private void DeterminarDireccionMirada()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            direccionMirada.x = ejeHorizontal;
            direccionMirada.y = ejeVertical;
        }
    }
}
