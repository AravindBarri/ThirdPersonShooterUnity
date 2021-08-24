using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float playerSpeed;
    public float backSpeed;
    public float turnSpeed;
    Animator anim;
    ScoreManager score;

    public int healthP = 0;

    public static PlayerMovement instance;
    // AudioSource audioSource;
    //public AudioClip audioClip;

    // Start is called before the first frame update
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        score = FindObjectOfType<ScoreManager>();
        instance = this;
    }
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);
        anim.SetFloat("Speed", vertical);
        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
        if (vertical != 0)
        {
            float moveSpeed = (vertical > 0) ? playerSpeed : backSpeed;
            characterController.SimpleMove(transform.forward * vertical * moveSpeed);
            //audioSource.clip = audioClip;
            //audioSource.Play();
        }
        //Quaternion direction = Quaternion.LookRotation(movement);
        //transform.rotation = Quaternion.Slerp(transform.rotation, direction, Time.deltaTime * turnSpeed); ;
    }
    /*private void onTriggerEnter(Collision collision)
    {
        print("Trigger");
        if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("Coin");
        }
        else if (collision.gameObject.tag == "Bottle")
        {
            print("Bottle");
            collision.gameObject.SetActive(false);
            score.BottleScore();
        }
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bottle")
        {
            print("Bottle");
            other.gameObject.SetActive(false);
            score.BottleScore();
            healthP = score.health;
        }
        if (other.gameObject.tag == "Coin")
        {
            print("Coin");
            other.gameObject.SetActive(false);
            score.CoinScore();
        }
    }
}
