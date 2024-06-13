using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData weapon;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletImpact;
    private int curAmmo;

    // Start is called before the first frame update
    void Start()
    {
        
        MeshFilter meshFilter = GetComponentInChildren<MeshFilter>();
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();

        
        curAmmo = weapon.MagazineCap;

        meshFilter.mesh = weapon.Model;
        meshRenderer.material = weapon.Material;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Fire()
    {
         if (CanFire())
        {
            StartCoroutine(FireCoroutine());
        }
    }

    private IEnumerator FireCoroutine()
    {

        // Verifica se pode disparar
        
            curAmmo--;
            shoot();

            yield return new WaitForSeconds(weapon.TimeBetweenShoots);

    }

    private bool CanFire()
    {
        return curAmmo > 0;
    }

    private void shoot()
    {
        RaycastHit hit;

        Vector3 direction = firePoint.forward;

        if (weapon.Spread > 0f)
        {
            direction += Random.insideUnitSphere * weapon.Spread;
        }

        if (Physics.Raycast(firePoint.position, direction, out hit, weapon.Range))
        {
            Debug.DrawLine(firePoint.position, hit.point, Color.red, 0.1f);
            Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
        }
       else
        {
            Debug.DrawRay(firePoint.position, direction * weapon.Range, Color.green, 0.1f);
        }
    }

    private void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        if (curAmmo < weapon.MagazineCap)
        {
            yield return new WaitForSeconds(weapon.ReloadTime);
            curAmmo = weapon.MagazineCap;
        }
    }

    public void UpdateWeapon(WeaponData newWeapon)
    {
        weapon = newWeapon;
        MeshFilter meshFilter = GetComponentInChildren<MeshFilter>();
        MeshRenderer meshRenderer = GetComponentInChildren<MeshRenderer>();

        curAmmo = weapon.MagazineCap;

        meshFilter.mesh = weapon.Model;
        meshRenderer.material = weapon.Material;
    }
    private void OnDrawGizmos()
    {
        if (firePoint != null && weapon != null)
        {
            Gizmos.color = Color.yellow;


            Gizmos.DrawLine(firePoint.position, firePoint.position + firePoint.forward * weapon.Range);


        }

    }
}
    


