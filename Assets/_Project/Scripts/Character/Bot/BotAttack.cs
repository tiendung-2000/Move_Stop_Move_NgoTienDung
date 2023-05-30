using System.Collections;
using UnityEngine;

public class BotAttack : CharacterAttack
{
    [SerializeField] private CharacterAnimation characterAnim;
    [SerializeField] private Bot bot;


    public void Update()
    {
        if (bot.enemyList.Count > 0)
        {
            FindNearestTarget();
        }
        else
        {
            enemy = null;
        }
    }

    public override IEnumerator Attack()
    {
        Vector3 enemyPos = enemy.transform.position;

        bot.DisplayOnHandWeapon();

        characterAnim.ChangeAnim(Constant.ATTACK);

        RotateToTarget();

        yield return new WaitForSeconds(0.4f);
        if (character.isDead)
        {
            yield break;
        }

        bot.UnDisplayOnHandWeapon();
        GameObject obj = weaponPool.GetObject();
        obj.transform.position = rightHand.transform.position;

        ReCaculateTargetWeapon(obj, enemyPos);
        
        WeaponType wpt = bot.onHandWeapon.GetComponent<Weapon>().weaponData.weaponType;
        if (wpt == WeaponType.Boomerang)
        {
            Vector3 target2 = this.transform.position;
            StartCoroutine(FlyBoomerangToTarget(obj, targetWeapon.position, target2, 10f));
        }
        else
        {
            StartCoroutine(FlyWeaponToTarget(obj, targetWeapon.position, 10f));
        }
        yield return null;
    }
}
