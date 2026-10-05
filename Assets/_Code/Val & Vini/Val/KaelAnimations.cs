using UnityEngine;

public class KaelAnimations : MonoBehaviour
{
    private Animator _kaelAnimator;
    private SpriteRenderer _kaelSprite;
    private Vector3 _lastPosition;

    void Awake()
    {
        _kaelAnimator=GetComponent<Animator>();
        _kaelSprite=GetComponent<SpriteRenderer>();
        _lastPosition=transform.position;

    }

    void Update()
    {
        //necesitas un float por que comparas con 0, por eso el .x
        float movementX=transform.position.x-_lastPosition.x;

        if (movementX!=0)
        {
            _kaelAnimator.SetBool("IsWalking",true);
            if (movementX<0)//izquierda
            {
                _kaelSprite.flipX=true;
            }
            else if (movementX>0)
            {
                _kaelSprite.flipX=false;
            }
        } else
        {
            _kaelAnimator.SetBool("IsWalking",false);
        }

        _lastPosition=transform.position;
    }


}
