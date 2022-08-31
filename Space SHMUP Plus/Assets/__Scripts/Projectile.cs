using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bndCheck;
    private Renderer rend;
    [Header("Set Dynamically")]
    public Rigidbody rigid;
    [SerializeField]
    private WeaponType _type;

    public WeaponType type {
        get {
            return (_type);
        }
        set {
            SetType(value);
        }
    }

    void Awake() {
        bndCheck = GetComponent<BoundsCheck>();
        rend = GetComponent<Renderer>();
        rigid = GetComponent<Rigidbody>();
    }

    public void SetType(WeaponType eType) {
        _type = eType;
        WeaponDefinition def = Main.GetWeaponDefinition(_type);
        rend.material.color = def.projectileColor;
    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (bndCheck.offUp) {
            Destroy(gameObject);
        }
    }
}
