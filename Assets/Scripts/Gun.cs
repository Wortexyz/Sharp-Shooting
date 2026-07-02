using StarterAssets;
using UnityEngine;

public class Gun : MonoBehaviour
{
[SerializeField] int Damageamount = 10;
[SerializeField] ParticleSystem muzzleFlash;
[SerializeField] Animator animator;
[SerializeField] GameObject HitVFXPrefab; 

StarterAssetsInputs starterAssetsInputs;
EnemyHealth enemyHealth;

const string SHOOT_STRING = "Shoot";
    RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
            HandleShoot();
        
        
    }

     void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {

            muzzleFlash.Play();

            animator.Play(SHOOT_STRING , 0, 0f );
            starterAssetsInputs.ShootInput(false);
            Instantiate(HitVFXPrefab,hit.point, Quaternion.LookRotation(hit.normal));

           
                EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
                Debug.Log("Hit Enemy");
                // if (enemyHealth != null)
                // {
                //     enemyHealth.TakeDamage(Damageamount);
                // }  same thane anu adiyil ullath
                enemyHealth?.TakeDamage(Damageamount);
                
            

        }
    }
}
