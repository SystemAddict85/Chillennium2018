using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
    GameObject childWithParticleSystem;

    [SerializeField]
    private int ultimateDamage = 4;

    void Awake()
    {
        childWithParticleSystem = transform.GetChild(0).gameObject;
    }

    public void ActivateUltimate()
    {
        GetComponentInParent<Player>().transform.position = Vector3.zero;
        StartCoroutine(PauseForDramaticEffect());
    }

    IEnumerator PauseForDramaticEffect()
    {
      //  LevelManager.Instance.Player1.GetComponent<Movement>().enabled = false;
     //   LevelManager.Instance.Player2.GetComponent<Movement>().enabled = false;
        GlobalStuff.FreezeSpawning();
        GlobalStuff.FreezeAllMovement();
        GlobalStuff.LoseAllControl();
        yield return new WaitForSeconds(.5f);
        childWithParticleSystem.SetActive(true);
        yield return new WaitForSeconds(2f);
        FlashScreenUI.Instance.FlashScreen(0, 1f);
        yield return new WaitForSeconds(1.5f);
        FlashScreenUI.Instance.FlashScreen(1, 1f);
        yield return new WaitForSeconds(1.5f);
        FlashScreenUI.Instance.FlashScreen(0, .5f);
        yield return new WaitForSeconds(.6f);
        FlashScreenUI.Instance.FlashScreen(1, .4f);
        yield return new WaitForSeconds(.6f);
        FlashScreenUI.Instance.FlashScreen(0, .4f);
        yield return new WaitForSeconds(.6f);
        FlashScreenUI.Instance.FlashScreen(2, 1f);
        yield return new WaitForSeconds(.9f);
        childWithParticleSystem.SetActive(false);
        yield return new WaitForSeconds(.5f);
        DeactivateUltimate();
    }

    private void DeactivateUltimate()
    {
        foreach(var e in FindObjectsOfType<Enemy>())
        {
            e.Damage(ultimateDamage, Character.Effectiveness.SUPER);
        }

       // LevelManager.Instance.Player1.GetComponent<Movement>().enabled = true;
       // LevelManager.Instance.Player2.GetComponent<Movement>().enabled = true;
        GlobalStuff.UnfreezeSpawning();
        GlobalStuff.UnfreezeAll();
        GlobalStuff.RegainAllControl();        
    }

}
