using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuesAns : MonoBehaviour
{
    public bool isAns;

    public GameObject Panel;

    public GameObject[] Questions;

    public GameObject Failed_Panel;

    public GameObject particle;

    public GameObject smallCanves;

    public GameObject cubeMesh;

    public int i;

    bool isClueCollected;

    AudioClip ansCube_sound;
    AudioClip quesCube_sound;

    Timer TimerScript;


    void Start()
    {
        TimerScript = (Timer)FindObjectOfType<Timer>().GetComponent<Timer>();

        Panel.active = false;
        if (!isAns) Failed_Panel.active = false;
        ansCube_sound = Resources.Load<AudioClip>("power_UP_02");
        quesCube_sound = Resources.Load<AudioClip>("coin_collect_06");
    }

    void Update()
    {
        if(i >= Questions.Length - 1 && !isAns)
        {
            Instantiate(particle, transform.position, Random.rotation);
            GameObject.Find("Gate").GetComponent<Animator>().SetBool("openGate", true);
            Destroy(gameObject);
        }
    }

    public void Right_Answer()
    {
        Questions[i + 1].active = true;
        Questions[i].active = false;
        i++;
    }
    public void Wrong_Answer()
    {
        Questions[i].active = false;
        i = 0;
        Questions[i].active = true;
        Failed_Panel.active = true;
    }

    public void NextButn()
    {
        if(!isAns) Failed_Panel.active = false;

        Panel.active = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TimerScript.stopTimer = true;

            if(!isAns)
            {
                AudioSource.PlayClipAtPoint(quesCube_sound, other.transform.position);

                Instantiate(particle, transform.position, Random.rotation);
            }

            if(isAns && !isClueCollected)
            {
                AudioSource.PlayClipAtPoint(ansCube_sound, other.transform.position);
                FindObjectOfType<player_script>().clue_collected++;
                isClueCollected = true;
                smallCanves.active = false;
                GetComponent<BoxCollider>().enabled = false;
                cubeMesh.active = false;
            }

            Panel.active = true;
        }
    }
}
