using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{

    public float moveSpeed = 4f;

    public float jumpForce = 6f;

    private Rigidbody2D rb;

    private int jumpCount;

    private int maxJumps = 1;

    private float moveInput;

    private bool isGrounded = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown ("Jump") && jumpCount < maxJumps){

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Auxilia na parte dos pulos

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // Aplica impulso para padronizar os pulos(atributos de força da unity 

            jumpCount++;   
        }

    }

    private void FixedUpdate()
    {
        float targetVelocity = moveInput != 0 ? moveInput * moveSpeed : 0f; // ? um if else TERNÁRIO (DICK caso o ultilizar pensar direito como o utilizar mas as vezes pessoas iniciantes não entendam)

        rb.linearVelocity = new Vector2(targetVelocity, rb.linearVelocity.y);

        if (isGrounded)
        {
            jumpCount = 0;
        }

        isGrounded = false;

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded =true;
        }
    }
}
