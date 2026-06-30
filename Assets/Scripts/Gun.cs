using StarterAssets;
using UnityEngine;

public class Gun : MonoBehaviour
{

StarterAssetsInputs starterAssetsInputs;
    RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (starterAssetsInputs.shoot)
        {
            Shoot();
        }
        
    }

     void Shoot()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {

            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Hit Enemy");
            }

            starterAssetsInputs.ShootInput(false);
        }
    }
}
