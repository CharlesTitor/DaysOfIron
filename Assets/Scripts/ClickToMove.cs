using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class ClickToMove : MonoBehaviour
{
   [SerializeField] private InputAction move_click;
   [SerializeField] private float speed=10f;
   [SerializeField] private GameObject moveIndicator;


   Camera camera;
   Coroutine coroutine;
   Vector3 target_ubi,destination;
   Vector2 mouse_position;
   Ray ray;
   bool collision;


   private void Awake()
   {
        camera=Camera.main;
   }


   private void OnEnable()
   {
        move_click.Enable();
        move_click.performed += Move; //No es suma, es funcion que debe ejecutarse cuando esa accion se cumpla
   }


   private void OnDisable()
   {
        move_click.performed -= Move;
        move_click.Disable();
   }


   private void Move(InputAction.CallbackContext context) //informacion de lo que acaba de ocurrir
   {
        /*
        ray= linea invisible que sale desde un punto hacia piso (como un puntero laser)
        ScreenPointToRay=es para que el 2d del click del mouse se pueda leer en 3d
            -Donde damos click-> saca el rayo laser de ahi hasta que toque piso (ese es z)
            Physics.Raycast= pregunta si el rayo choco con piso
        */
        mouse_position=Mouse.current.position.ReadValue();
        ray= camera.ScreenPointToRay(mouse_position);
        RaycastHit hit; //guardo la coordenada de donde llego el laser
        collision=Physics.Raycast(ray, out hit); //Esto es para que le devuelva la informacion a hit y hit lo ponga en su memoria
        if (collision==true)
        {
            if (coroutine!=null) //Si se clickean en muchos lugares pausa en el que estaba y cambia su direccion al ultimo lugar donde clickeaste
            {
                StopCoroutine(coroutine);
            }
            Vector3 target = hit.point;
            target.y = transform.position.y;
            Vector3 indicatorPosition = hit.point;
            indicatorPosition.y += 0.05f;
            moveIndicator.SetActive(true);
            moveIndicator.transform.position = indicatorPosition;
            coroutine = StartCoroutine(PlayerMoveTowards(target));
            target_ubi = target;


        }
   }


   private IEnumerator PlayerMoveTowards(Vector3 target) //Esto hace que se mueva poco a poquito en vez de que solo se telertransporte (es la coroutine)
   {
        while (Vector3.Distance(transform.position,target)>0.1f)
        {
            destination= Vector3.MoveTowards(transform.position,target, speed*Time.deltaTime);
            transform.position=destination;
            yield return null;
        }
   }


   private void OnDrawGizmos()
   {
        Gizmos.color=Color.red;
        Gizmos.DrawSphere(target_ubi,.2f);
   }


}
