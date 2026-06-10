using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptWoody : MonoBehaviour
{
    public LayerMask mascara;
    public GameObject pe;
    private Rigidbody2D rbd;

    private Animator anim;
    public float vel;
    public float pulo;
    private bool chao;
    private bool direita = true;

    // Start is called before the first frame update
    void Start()
    {
        pulo = 600;
        vel = 5;
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        chao = true;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        chao = false;     
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        rbd.velocity = new Vector2(x * vel, rbd.velocity.y);

        if (x == 0)
        {
            anim.SetBool("movendo", false);
        } else
        {
            anim.SetBool("movendo", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && chao) {
            rbd.AddForce(new Vector2(0, pulo));
        }

        // Detectando direção
        if (x < 0 && direita || x > 0 && !direita)
        {
            transform.Rotate(new Vector2(0, 180));
            direita = !direita;
        }

        // Detectando o chão -> ISSO ESTAVA BUGANDO, POR ISSO NÃO COLOQUEI
        // RaycastHit2D hit;

        // hit = Physics2D.Raycast(pe.transform.position,Vector2.down,0.1f,mascara); // posição inicial = pé, direção = para baixo (se o objeto rotacionasse, o ideal seria colocar -transform.up), quanto que quer de raio para baixo, layer que quer que identifique = mascara 

        // // agora verifica só em uma direção
        // if (hit.collider==null)
        //     chao = false;
        // else
        //     chao = true;
        
    }
}
