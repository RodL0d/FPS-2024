using System.Collections;
using System.Collections.Generic;
using UnityEngine;



        [CreateAssetMenu(menuName = "My Assets/weapon")]
    public class WeaponData : ScriptableObject

{

    [SerializeField] float damage, range, fireRate, spread, reloadTime, timeBetweenShots;
    [SerializeField] int magazineCap, bulletsPerShot;
    [SerializeField] bool automatic, scope;
    [SerializeField] Mesh model;
    [SerializeField] Material material; 
    [SerializeField] Vector3 weaponPosition;

    public float Damage { get => damage;}
    public float Range { get => range;}
    public float FireRate { get => fireRate;}
    public float Spread { get => spread;}
    public float ReloadTime { get => reloadTime;}
    public float TimeBetweenShoots { get => timeBetweenShots; }
    public int MagazineCap { get => magazineCap;}
    public int BulletsForShoot { get => bulletsPerShot; }
    public bool Automatic { get => automatic;}
    public bool Scope { get => scope;}
    public Mesh Model { get => model;}
    public Material Material { get => material;}
    public Vector3 WeaponPosition { get => weaponPosition;}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
