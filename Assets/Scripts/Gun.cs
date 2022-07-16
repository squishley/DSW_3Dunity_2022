using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float range = 100f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem muzzleFlash2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        muzzleFlash2.Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.Die();
            }

        }
    }
}



