using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieSphere : Ennemi
{

    GameObject player;
    public float speed;
    Rigidbody rgb;
    AudioSource audioSource;
    public AudioMusic audioMusic;
    public GameObject particuleSystemDeath;
    int cptEnnemi = 0;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        rgb = GetComponent<Rigidbody>();
        audioSource = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        ChangeFormeEnnemi();
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        rgb.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position,
            speed * Time.deltaTime));
    }

    private void ChangeFormeEnnemi()
    {

        if (cptEnnemi == 0)
        {
            speed = Random.Range(3, 30);
            rgb.transform.localScale += new Vector3(Random.Range(0.0f, 3.0f), 0, 0);
            cptEnnemi += 1;
        }
    }


    public override void Die()
    {
        audioSource.PlayOneShot(audioMusic.soundToPlay);
        Instantiate(particuleSystemDeath, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
