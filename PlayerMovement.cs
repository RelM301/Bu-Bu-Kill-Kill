using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    #region VARIABLES
    public JoystickMovement joystickMovement;
    public ParticleSystem dust;
    public float movementSpeed = 2f;

    private Rigidbody2D rb;
    private Animator anim;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        //Previene al jugador de moverse cuando un diálogo está activo.
        if (DialogueManager.isActive == true)
            return;
        
        //Control de movimiento del jugador.
        float horizontal = joystickMovement.joystickVec.x;
        float vertical = joystickMovement.joystickVec.y;

        if (horizontal != 0 || vertical != 0)
        {
            anim.SetFloat("Horizontal", horizontal);
            anim.SetFloat("Vertical", vertical);
            anim.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));

            // Rotación de partículas.
            float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
            dust.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            anim.SetFloat("Speed", 0f);
        }

        if (horizontal != 0 || vertical != 0)
        {
            if (!dust.isPlaying)
            {
                dust.Play();
            }
        }
        else
        {
            dust.Stop();
        }
    }

    //Actualiza la posición del jugador mediante el moviento del joystick.
    void FixedUpdate()
    {
        if (DialogueManager.isActive == true)
            return;
            
        float horizontal = joystickMovement.joystickVec.x;
        float vertical = joystickMovement.joystickVec.y;

        if (joystickMovement.joystickVec != Vector2.zero)
        {
            Vector2 movement = new Vector2(horizontal, vertical) * movementSpeed;
            rb.velocity = movement;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
