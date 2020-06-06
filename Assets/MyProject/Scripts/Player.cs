using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    [Range(1, 100)]
    [SerializeField]
    private float damageExtinguisher;
    [SerializeField]
    private Animator animator;

    private bool canExtinguish;
    private Fire currentFire;
    private float time;
    
    public bool HasExtinguisher { get; set; }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        GameEventManager.Instance.onPlayerNearFire += EnableExtinguish;
        GameEventManager.Instance.onPlayerExitFire += DisableExtinguish;
        GameEventManager.Instance.onCompletedLevel += LevelCompleted;
        UIManager.Instance.SetInfoText("UWAGA alarm ! Proszę znajdź pożar. Nie zapomnij o gaśnicy,ubraniu,i hełmie!");
    }

    void Update()
    {
        if (canExtinguish && Input.GetMouseButton(1))
        {
            if (HasExtinguisher)
            {
                if (currentFire!=null && CheckViewAtExtinguish() <= -0.6f)
                {
                    currentFire.Extinguish(Time.deltaTime * damageExtinguisher);
                    UIManager.Instance.SetInfoText("Trwa gaszenie Brawo!");
                }
                else UIManager.Instance.SetInfoText("Skieruj się w stronę ognia!");
            }
            else UIManager.Instance.SetInfoText("Musisz mieć gaśnicę");

        }

        time += Time.deltaTime;
        UIManager.Instance.SetInfoTime(time);
        SimpleAnimation();
    }

    // We check that we directly look at fire ,we cannot use Extinguish if we have fire behind character
    private float CheckViewAtExtinguish()
    {

        float dotproduct = Vector3.Dot(currentFire.transform.GetChild(2).transform.forward.normalized, transform.forward);
        return dotproduct;
    }

    private void SimpleAnimation()
    {
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("Run",true);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
        }
    }


    private void EnableExtinguish(Fire fire)
    {
        UIManager.Instance.SetInfoText("Brawo udało się zanleść pożar.Przytrzymaj prawy przycisk myszy!");
        UIManager.Instance.ShowProgressExtinguish();
        canExtinguish = true;
        currentFire = fire;
    }

    private void DisableExtinguish()
    {
        UIManager.Instance.SetInfoText("UWAGA alarm ! Proszę znajdź pożar.");
        UIManager.Instance.HideProgressExtinguish();
        canExtinguish = false;
        currentFire = null;
    }


    private void LevelCompleted()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GetComponent<FirstPersonController>().enabled = false;
        UIManager.Instance.ShowPanelCompletedLevel(time);
    }
}
