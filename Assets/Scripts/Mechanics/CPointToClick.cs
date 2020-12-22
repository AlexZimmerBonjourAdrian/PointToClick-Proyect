using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPointToClick : MonoBehaviour
{
    // Start is called before the first frame update


    //Vector2 mousePosition = new Vector2(init)
    //private Ray2D collisions;
    private static int ACTIONSTATE_NONE = 0;
    private static int ACTIONSTATE_HOVE = 1;
    private static int ACTIONSTATE_INTERACT = 2;
    GameObject anyObject;
    private int _actionState;
    private Component _actionObj;

    public static CPointToClick Inst
    {
        get
        {
            if (_inst == null)
            {
                GameObject obj = new GameObject("PointMechanic");

                return obj.AddComponent<CPointToClick>();
            }
            return _inst;
        }
    }
    private static CPointToClick _inst;



    public void Awake()
    {
       
        if (_inst != null && _inst != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        _inst = this;
    }




    /*
     void Start()
     {

     }
    */
    // Update is called once per frame
    void Update()
    {
        if (_actionState == ACTIONSTATE_NONE)
        {
            GameObject obj = RayCollision();
            if (obj == null)
                return;

            Component actionObj = obj.GetComponent(typeof(Iinteract));
            if (actionObj != null)
            {
                _actionObj = actionObj;
                _actionState = ACTIONSTATE_HOVE;
            }
        }
        else if (_actionState == ACTIONSTATE_HOVE)
        {
            GameObject obj = RayCollision();
            if (obj == null)
            {
                _actionObj = null;
                _actionState = ACTIONSTATE_NONE;
                return;
            }

            Component actionObj = obj.GetComponent(typeof(Iinteract));
            if (actionObj == null)
            {
                _actionObj = null;
                _actionState = ACTIONSTATE_NONE;
            }
            else if (actionObj != _actionObj)
            {
                _actionObj = actionObj;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _actionState = ACTIONSTATE_INTERACT;
                Debug.Log("Entra en el entract");
                Debug.Log(_actionObj.name);
            }
        }
        else if (_actionState == ACTIONSTATE_INTERACT)
        {
            (_actionObj as Iinteract).Oninteract();
            _actionState = ACTIONSTATE_NONE;
            _actionObj = null;
        }






    }
    /*
           if(Input.GetKeyDown(KeyCode.Mouse0))
           {
               targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

           }
           */
    //Metodo 1º
    //if(Input.GetKeyDown(KeyCode.Mouse0))
    //  {
    /*
    Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hitInfo;

    if(Physics.Raycast(myRay, out hitInfo, 100))
    {
       Debug.Log("Hola"); 
    }
//    */
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    if(Physics.Raycast(ray))
    //    {
    //        Debug.Log("Detecta el objeto");
    //    }

    //}
    //Metodo 2º
    /*
    if (_actionState == ACTIONSTATE_NONE)
        {
            //GameObject obj = coll
        }
    */
    // }
    //  transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5); 


    private GameObject RayCollision()
    {


        //TODO:Modificar para usarlo con un arreglo en vez de solo una accion
        //PS:Esto funciona pero aun asi bastante bien, aun asi se puede mejorar
        //   float size= 2f;
        //    Collision2D[] collisions = Physics2D.OverlapCircleAll(, size);
        //Ray2D Ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Ray2D ray = new Ray2D(new Vector2(Input.mousePosition.x,Input.mousePosition.y), transform.forward);
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitinfo = Physics2D.Raycast(worldPoint, Vector2.zero);
        //  Component actionObj = obj.GetComponent(typeof(Iinteract));
        //if (Physics.Raycast(Ray)
        //   {

        if (hitinfo.collider != null)
        {
            //  Debug.Log("Entra");
            // anyObject = Collider2D.;
            // (_actionObj as Iinteract).Oninteract();
            //Debug.Log(hitinfo.collider.gameObject.name);
            anyObject = hitinfo.collider.gameObject;
            return anyObject;
        }

        return null;
    }

    void OnDrawGizmos()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(worldPoint, .3f);

    }

    public void CreatePoint()
    {
        

    }
}
