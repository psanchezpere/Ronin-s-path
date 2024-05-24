using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnPlataforma : MonoBehaviour
{

    private Rigidbody2D rb2D;

    [SerializeField] private bool isIdle;
    [SerializeField] private float velocidadDeMovimiento;
    [SerializeField] private float distanciaAbajo;
    [SerializeField] private Transform controladorAbajo;

    [SerializeField] private bool mirandoALaDerecha = true;
    private Animator animator;

    private void Start(){
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate(){
        if(!isIdle){
            animator.SetBool("isIdle", false);
            RaycastHit2D informacionAbajo = Physics2D.Raycast(controladorAbajo.position, Vector2.down, distanciaAbajo);
            rb2D.velocity = new Vector2(velocidadDeMovimiento, rb2D.velocity.y);
        
        
            if (informacionAbajo == false){
                Girar();
            }
        }else{
            animator.SetBool("isIdle", true);
        }
    }

    private void Girar(){
        mirandoALaDerecha = !mirandoALaDerecha;
        transform.eulerAngles = new Vector3(0,transform.eulerAngles.y+180, 0);
        velocidadDeMovimiento *= -1;
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorAbajo.transform.position, controladorAbajo.transform.position + Vector3.down * distanciaAbajo);
                
    }



}
