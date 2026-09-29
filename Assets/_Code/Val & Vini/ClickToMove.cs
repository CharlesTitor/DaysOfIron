using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public class ClickToMove : MonoBehaviour , IInteractor
{
    [FormerlySerializedAs("move_click")]
    [SerializeField] private InputAction _moveClick;
    [SerializeField] private InputAction _interactClick;
    
    [FormerlySerializedAs("speed")]
    [SerializeField] private float _speed=10f;
    [FormerlySerializedAs("ground_layer")]
    [SerializeField] private LayerMask _groundLayer;
    [FormerlySerializedAs("invisible_wall_layer")]
    [SerializeField] private LayerMask _invisibleWallLayer;
    [FormerlySerializedAs("move_indicator")]
    [SerializeField] private GameObject _moveIndicator;


   private Camera camera;
   private Coroutine coroutine;
   private Vector3 targetUbication;
   private Vector3 destination;
   private Vector2 mousePosition;
   private Ray ray;
   private bool isColliding;


   private void Awake()
   {
        camera=Camera.main;
   }


   private void OnEnable()
   {
        _moveClick.Enable();
        _interactClick.Enable();
        _moveClick.performed += Move; //No es suma, es funcion que debe ejecutarse cuando esa accion se cumpla
        _interactClick.performed += ClickInteract;
   }


   private void OnDisable()
   {
        _moveClick.performed -= Move;
        _interactClick.performed -= ClickInteract;
        _moveClick.Disable();
        _interactClick.Disable();
   }


   private void Move(InputAction.CallbackContext context) //informacion de lo que acaba de ocurrir
   {
        /*
        ray= linea invisible que sale desde un punto hacia piso (como un puntero laser)
        ScreenPointToRay=es para que el 2d del click del mouse se pueda leer en 3d
            -Donde damos click-> saca el rayo laser de ahi hasta que toque piso (ese es z)
            Physics.Raycast= pregunta si el rayo choco con piso
        */
        mousePosition=Mouse.current.position.ReadValue();
        ray= camera.ScreenPointToRay(mousePosition);
        RaycastHit hit; //guardo la coordenada de donde llego el laser
        isColliding=Physics.Raycast(ray, out hit); //Esto es para que le devuelva la informacion a hit y hit lo ponga en su memoria
        if (isColliding && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))//si toca algo que no es el piso
        {
            if (coroutine!=null) //Si se clickean en muchos lugares pausa en el que estaba y cambia su direccion al ultimo lugar donde clickeaste
            {
                StopCoroutine(coroutine);
            }
            Vector3 target = hit.point;
            target.y = transform.position.y;
            Vector3 indicatorPosition = hit.point;
            indicatorPosition.y += 0.05f;
            _moveIndicator.SetActive(true);
            _moveIndicator.transform.position = indicatorPosition;
            coroutine = StartCoroutine(PlayerMoveTowards(target));
            targetUbication = target;


        }
   }

    private void ClickInteract(InputAction.CallbackContext context)
    {
        mousePosition = Mouse.current.position.ReadValue();
        ray = camera.ScreenPointToRay(mousePosition);
        RaycastHit hit; //guardo la coordenada de donde llego el laser
        isColliding = Physics.Raycast(ray, out hit); //Esto es para que le devuelva la informacion a hit y hit lo ponga en su memoria

        IInteractable currentInteractable = hit.collider.gameObject.GetComponentInChildren<IInteractable>();

        if (isColliding && currentInteractable != null)//si toca algo que no es el piso
        {
            if (currentInteractable.CanInteract(this)) currentInteractable.Interact(this);
        }
    }


   private IEnumerator PlayerMoveTowards(Vector3 target) //Esto hace que se mueva poco a poquito en vez de que solo se telertransporte (es la coroutine)
   {
        while (Vector3.Distance(transform.position,target)>0.1f)
        {
            destination= Vector3.MoveTowards(transform.position,target, _speed*Time.deltaTime);
            transform.position=destination;
            yield return null;
        }
        _moveIndicator.SetActive(false);
   }


   private void OnDrawGizmos()
   {
        Gizmos.color=Color.red;
        Gizmos.DrawSphere(targetUbication,.2f);
   }


}
