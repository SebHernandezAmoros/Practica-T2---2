using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float JumpForce = 10;
    public float Velocity = 10;
    public GameObject BulletPrefab;

    private SpriteRenderer _spriteRenderer; // null
    private Rigidbody2D _rb;
    private Animator _animator;

    private static readonly string ANIMATOR_STATE = "State";
    private static readonly int ANIMATION_IDLE = 0;
    private static readonly int ANIMATION_RUN = 1;
    private static readonly int ANIMATION_RUNGUN = 2;
    private static readonly int ANIMATION_JUMP = 3;

    private static readonly int RIGHT = 1;
    private static readonly int LEFT = -1;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var velocidadActualY = _rb.velocity.y;
        _rb.velocity = new Vector2(0, velocidadActualY);
        ChangeAnimation(ANIMATION_IDLE);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Desplazarse(RIGHT);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Desplazarse(LEFT);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            ChangeAnimation(ANIMATION_JUMP);

        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Disparar();

        }
    }

    private void Disparar()
    {

        var x = this.transform.position.x;
        var y = this.transform.position.y;
        var bulletGO = Instantiate(BulletPrefab, new Vector2(x, y), Quaternion.identity) as GameObject;
        var controller = bulletGO.GetComponent<BulletController>();
        // controller.SetPlayerController(this);
        if (_spriteRenderer.flipX)
        {
            controller.Velocidad = controller.Velocidad * -1;
        }
    }

    private void Desplazarse(int position)
    {
        _rb.velocity = new Vector2(Velocity * position, _rb.velocity.y);
        _spriteRenderer.flipX = position == LEFT;
        if (Input.GetKey(KeyCode.X))
        {
            ChangeAnimation(ANIMATION_RUNGUN);
        }
        else
        {
            ChangeAnimation(ANIMATION_RUN);
        }
            
    }

    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }
}
