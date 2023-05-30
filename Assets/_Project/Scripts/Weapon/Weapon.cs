using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;
    public Transform child;
    public MeshRenderer meshRenderer;
    private WeaponPool weaponPool;
    private Character owner;
    public int currentMaterialIndex;
    public bool isStuckAtObstacle;
    public bool isPurchased;
    private void Start()
    {
        currentMaterialIndex = 0;
        isStuckAtObstacle = false;
    }
    public void ChangeMaterial(int index)
    {
        meshRenderer.material = weaponData.GetWeaponMaterial(index);
    }
    public Character GetOwner()
    {
        return this.owner;
    }
    public void SetOwnerAndWeaponPool(Character owner, WeaponPool weaponPool)
    {
        this.owner = owner;
        this.weaponPool = weaponPool;
    }
    public IEnumerator ReturnToPoolAfterSeconds()
    {
        yield return new WaitForSeconds(1);
        weaponPool.ReturnToPool(this.gameObject);
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constant.BOT)|| other.gameObject.CompareTag(Constant.PLAYER))
        {
            Character character = other.gameObject.GetComponent<Character>();
            if(character != this.owner){
                weaponPool.ReturnToPool(this.gameObject);
                this.owner.TurnBigger();
            }
            if(character is Bot && this.owner is Player)
            {
                LevelManager.instance.coin += 10;
                UIManager.instance.UpdateCoin();
            }
        }
    }
}