using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{       
    public float groundRadius = 0.5f;
    public float jumpForce = 10;
    public float movementSmoothing = 0.05f;
    public float speed;
    public float timeBeforeRespawn = 3f;

    public LayerMask groundLayer;
    public PhysicsMaterial2D slipery;
    public PhysicsMaterial2D  no_Slipery;
    public Animator animator;
    public GameManager gameManager;
    public AudioSource checkPointSound;
    public AudioSource deathSlimeSound;
    public AudioSource chestSound;
    public AudioSource blockSound;

    private bool _facingRight = true;
    private bool _isAlive = true;
    private bool _isGrounded = false;

    private PlayerInput _inputs;
    private Rigidbody2D _rb;
    private Vector2 _velocity;
    private Vector3 _checkPoint;

    void Start()
    {
        gameManager = GameManager.instance;

        _inputs = GetComponent<PlayerInput>();
        _rb = GetComponent<Rigidbody2D>();

        _checkPoint = transform.position;
    }

    void FixedUpdate()
    {
        if(_isAlive){
            GroundCheck();
            Movement();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("DeathZone")){
            Death();
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("Check_Point")){
            checkPointSound.Play();
            _checkPoint = other.transform.GetChild(0).position;
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("Coins")){
            gameManager.AddCoins();
            Destroy(other.gameObject);
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("Double_Coin")){
            gameManager.AddDoubleCoins();
            Destroy(other.gameObject);
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("Slime")){
            Death();
        }//degats quand le player touche la slime
        if(other.gameObject.layer == LayerMask.NameToLayer("Death_Slime")){
            deathSlimeSound.Play();
            Destroy(other.transform.parent.gameObject);
        }//Tue la slime quand le player saute dessus
        if(other.gameObject.layer == LayerMask.NameToLayer("Flag")){
            gameManager.WinScreen();
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.layer == LayerMask.NameToLayer("Chest") && _inputs.interaction_Chest){
            chestSound.Play();
            other.GetComponent<Chest>().Open();
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("Brocken_Block") && _inputs.interaction_Block){
            blockSound.Play();
            other.GetComponent<Craked_Block>().Brocken();
        }
    }

    void OnDrawGizmos(){
        Gizmos.color = new Color(0f, 1f, 0f, 0.25f);
        Gizmos.DrawSphere(transform.position, groundRadius);
    }
    //Sphere verte sur le player

    void GroundCheck(){
        _isGrounded = Physics2D.OverlapCircle(transform.position, groundRadius, groundLayer);
    }
    //Pour ne pas rester bloqué sur le bord du sol

    void Movement(){
        Vector2 currentVelocity = _rb.velocity;
        Vector2 targetVelocity = new Vector2(_inputs.movement.x * speed * Time.deltaTime, currentVelocity.y);

        _rb.velocity = Vector2.SmoothDamp(currentVelocity, targetVelocity, ref _velocity, movementSmoothing);

        if((_inputs.movement.x > 0 && !_facingRight) || (_inputs.movement.x < 0 && _facingRight)){
            Flip();
        }

        if(_isGrounded && _inputs.jump){
            _rb.velocity = new Vector3(currentVelocity.x, jumpForce, 0);
        }

        animator.SetFloat("Velocity", Mathf.Abs(_inputs.movement.x));
    }

    void Flip(){
        _facingRight = !_facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void Death(){
        animator.SetTrigger("Death");
        GameManager.instance.LifeCounts();
    }

    public void Stop(){        
        _rb.velocity = Vector2.zero;
        _rb.sharedMaterial = no_Slipery;
        _isAlive = false;
    }
    //Player ne peut pas bouger pendant l'animation death

    public void Respawn(){
        transform.position = new Vector3(_checkPoint.x, _checkPoint.y, transform.position.z);
        _isAlive = true;
        _rb.sharedMaterial = slipery;
    }
    //Respawn correctement quand le player meurt
}