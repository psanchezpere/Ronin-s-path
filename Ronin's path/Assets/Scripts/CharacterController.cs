
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterController : MonoBehaviour
{

    public float velocidad;
    public float fuerzaSalto;
    public LayerMask capaSuelo;

    private float escalaGravedad;
    [Range(0,1)] [SerializeField] private float multiplicadorCancelarSalto;
    [SerializeField] private float multiplicadorGravedad;
    public int saltosMaximos = 1;
    private int contadorSaltos = 0;
    private MenuPausa menuPausa;
    private Rigidbody2D rigidBody;
    private PolygonCollider2D boxCollider;
    private bool mirandoDerecha = true;
    private Animator animator;

    private void Start(){
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<PolygonCollider2D>();
        animator = GetComponent<Animator>();
        menuPausa = GameObject.Find("CanvasUI").GetComponent<MenuPausa>();
        escalaGravedad = rigidBody.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (!menuPausa.IsOpen()){
            ProcesarMovimiento();
        }
    }

    bool EstaEnElSuelo(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return (raycastHit.collider != null);
    }

    void DeteccionAccion(){

        if(EstaEnElSuelo() && IsDefenseRelease()){
            if(Input.GetKeyDown(KeyCode.Space)){
                RealizarSalto();
                animator.SetBool("isJumping", true);
            }else if(Input.GetKeyDown(KeyCode.F)){
                animator.SetBool("isSoftAttack", true);
            }else if(Input.GetKeyDown(KeyCode.G)){
                animator.SetBool("isPowerfulAttack", true);
            }else if(Input.GetKeyDown(KeyCode.H)){
                animator.SetBool("isFarAttack", true);
            }else if(Input.GetKeyDown(KeyCode.N)){
                animator.SetBool("isDefense", true);
            }else if(Input.GetKeyDown(KeyCode.Escape)){
                menuPausa.OpenControls();
            }else{
                if (IsDefenseRelease() && 
                (IsRunningOrIdle() || (!IsRunningOrIdle() && IsFinishAnimation()))){
                animator.SetBool("isJumping", false);
                animator.SetBool("isDefense", false);
                animator.SetBool("isPowerfulAttack", false);
                animator.SetBool("isFarAttack", false);
                animator.SetBool("isSoftAttack", false);
                contadorSaltos = 0;
                }
            }
        }else if((contadorSaltos < saltosMaximos) && Input.GetKeyDown(KeyCode.Space)){
            RealizarSalto();
            
        }else if(!Input.GetKey(KeyCode.Space)){
            CancelarSalto();
        }
    }

    bool IsDefenseRelease(){
        return ((!animator.GetCurrentAnimatorStateInfo(0).IsName("Shield") && animator.GetBool("isDefense") != true) ||
        (Input.GetKeyUp(KeyCode.N) && animator.GetCurrentAnimatorStateInfo(0).IsName("Shield")));
    }
    bool IsFinishAnimation(){
       return animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.99f;
    }
    // Método para controlar si está parado o corriendo y la animación anterior a terminado. 
    bool IsRunningOrIdle(){
       return animator.GetCurrentAnimatorStateInfo(0).IsName("Run")  || animator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
    }

    bool IsJumping(){
       return animator.GetCurrentAnimatorStateInfo(0).IsName("Jump");
    }

    void ProcesarMovimiento(){

        DeteccionAccion();
        UpdateGravity();

        float inputMovimiento = Input.GetAxis("Horizontal");
        
        if(IsJumping()){
            rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y); 
            GestionarOrientacion(inputMovimiento);
        }else{
            if(IsDefenseRelease() && EstaEnElSuelo() && 
            (IsRunningOrIdle() || (!IsRunningOrIdle() && IsFinishAnimation()))){
                if (inputMovimiento != 0f && EstaEnElSuelo()){
                    animator.SetBool("isRunning", true);
                }else{
                    animator.SetBool("isRunning", false);
                }
                rigidBody.velocity = new Vector2(inputMovimiento * velocidad, rigidBody.velocity.y); 
                GestionarOrientacion(inputMovimiento);
            // Condicion para que si está atacando o defendiendose no siga avanzando
            }else{
                rigidBody.velocity = new Vector2(0f, rigidBody.velocity.y);
            }
        }

    }

    void GestionarOrientacion(float inputMovimiento){

        if((mirandoDerecha == true && inputMovimiento <0) || (mirandoDerecha == false && inputMovimiento > 0)){

            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }


    void RealizarSalto(){
        rigidBody.velocity=(Vector2.up * fuerzaSalto);
        contadorSaltos++;
    }

    void UpdateGravity(){
        if((rigidBody.velocity.y < 0 && !EstaEnElSuelo())|| !Input.GetKey(KeyCode.Space)){
            rigidBody.gravityScale = escalaGravedad * multiplicadorGravedad;
        }else{
            rigidBody.gravityScale = escalaGravedad *multiplicadorGravedad/2;
        }
    }

    void CancelarSalto(){
        if(rigidBody.velocity.y > 0){
            Vector2 vector2 = Vector2.down * rigidBody.velocity.y * (1 - multiplicadorCancelarSalto);
            rigidBody.AddForce(vector2, ForceMode2D.Impulse);
        }
    }

}
