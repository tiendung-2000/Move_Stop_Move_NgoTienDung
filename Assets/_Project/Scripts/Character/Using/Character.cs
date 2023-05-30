using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, ITurnBigger
{
    [SerializeField] protected CharacterAnimation characterAnim;
    [SerializeField] protected Material deathMaterial;
    [SerializeField] protected CapsuleCollider capsulCollider;

    public SkinnedMeshRenderer skinnedMeshRenderer;
    public GameObject onHandWeapon;
    public WeaponPool weaponPool;
    protected WeaponType weaponType;

    public List<Character> enemyList = new List<Character>();
    public List<Weapon> pooledWeaponList = new List<Weapon>();

    [SerializeField] protected GameObject body;
    public Transform rightHand;

    public bool isDead = false;
    public bool isMoving = false;
    public bool isHaveHat;
    public bool isHaveShield;


    public virtual void OnInit()
    {
        EnableCollider();
        ResetSize();
        enemyList.Clear();
        isDead = false;
    }

    public abstract void OnDeath();

    public abstract void EnableCollider();

    public abstract void DisableCollider();

    public virtual void SetPosAndRot()
    {
        transform.position = new Vector3(30f, -0.34f, -8.6f);
        transform.rotation = Quaternion.Euler(new Vector3(0, 160, 0));
    }

    public virtual void DisplayOnHandWeapon()
    {
        if (this.onHandWeapon != null)
        {
            this.onHandWeapon.SetActive(true);
        }
    }

    public virtual void UnDisplayOnHandWeapon()
    {
        if (this.onHandWeapon != null)
        {
            this.onHandWeapon.SetActive(false);
        }
    }

    public virtual void TurnBigger()
    {
        TurnBiggerBody();
        TurnBiggerWeapon();
        if(this is Player)
        {
            CameraController.instance.MoveHigher();
        }
    }

    public virtual void TurnBiggerBody()
    {
        Vector3 oldScale = body.transform.localScale;
        Vector3 newScale = oldScale * Constant.SCALE_VALUE;
        body.transform.localScale = newScale;
    }

    public virtual void TurnBiggerWeapon()
    {
        for(int i=0;i<weaponPool.pool.Count;i++)
        {
            GameObject wp = weaponPool.pool[i];
            Vector3 oldBodyScale = wp.transform.localScale;
            Vector3 newBodyScale = oldBodyScale * Constant.SCALE_VALUE;
            wp.transform.localScale = newBodyScale;
        }
    }

    public virtual void ResetSize()
    {
        ResetBodySize();
        ResetWeaponSize();
    }

    public virtual void ResetBodySize()
    {
        this.transform.localScale = Vector3.one;
    }

    public virtual void ResetWeaponSize()
    {
        for (int i = 0; i < weaponPool.pool.Count; i++)
        {
            GameObject wp = weaponPool.pool[i];
            wp.transform.localScale = Vector3.one;
        }
    }
}
