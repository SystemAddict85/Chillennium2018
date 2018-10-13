using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{    
    [SerializeField]
    private ProjectilePool[] pools;

    [SerializeField]
    private float shootRate = 20f;          // the higher the number, the smaller the interval
    private bool readyToShoot = true;

    private Controller controller;

    private void Awake()
    {
        controller = GetComponent<Controller>();
    }

    private void Update()
    {       
           
     
    }

    IEnumerator WaitToShoot()
    {
        readyToShoot = false;
        yield return new WaitForSeconds(1 / shootRate);
        readyToShoot = true;

    }

    public void Shoot(int poolNum = 0)
    {
        if (readyToShoot)
        {
            StartCoroutine(WaitToShoot());
            var proj = pools[poolNum].Get();
            if (proj != null)
            {
                proj.transform.position = transform.position;
                proj.gameObject.SetActive(true);
                proj.Shoot(new Vector2(controller.HorizontalAim, controller.VerticalAim));
            }
            else
            {
                // do something about no bullets
            }
        }
    }


    
}
