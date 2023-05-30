using System.Collections;
using UnityEngine;

public class PlayerAttack : CharacterAttack
{
    [SerializeField] private TargetCircle targetCircle;
    private bool canAttack;


    protected  void Start()
    {
        canAttack = true;
        targetCircle.Deactive();
    }

    protected  void Update()
    {
        if (LevelManager.instance.isGaming == false)
        {
            return;
        }
        if (character.isDead == true)
        {
            targetCircle.Deactive();
            return;
        }
        if (character.isMoving)
        {
            canAttack = false;
        }
        if (Input.GetMouseButton(0))
        {
            if (!character.onHandWeapon.activeSelf)
            {
                character.DisplayOnHandWeapon();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            canAttack = true;
        }

        if(character.enemyList.Count>0)
        {
            FindNearestTarget();
        }
        else
        {
            enemy = null;
        }

        if (canAttack && character.isMoving==false && enemy!=null)
        {
            RotateToTarget();
            StartCoroutine(Attack());
            StartCoroutine(DelayAttack(1.1f));
        }

        if(character.enemyList.Count > 0)
        {
            targetCircle.Active();
        }
        else
        {
            targetCircle.Deactive();
        }
    }

    public override IEnumerator Attack()
    {
        if (enemy != null)
        {
            Vector3 enemyPos = enemy.transform.position;
            
            character.DisplayOnHandWeapon();

            characterAnimation.ChangeAnim(Constant.ATTACK);

            float elapsedTime = 0f;
            float duration = 0.4f;
            while (elapsedTime < duration)
            {
                if (character.isMoving)
                {
                    goto label;
                }
                else
                {
                    elapsedTime += Time.deltaTime;
                }
                yield return null;
            }

            character.UnDisplayOnHandWeapon();
            GameObject obj = character.weaponPool.GetObject();
            obj.transform.position = rightHand.transform.position;
            
            ReCaculateTargetWeapon(obj, enemyPos);
            
            WeaponType wpt = character.onHandWeapon.GetComponent<Weapon>().weaponData.weaponType;
            if (wpt == WeaponType.Boomerang)
            {
                Vector3 target2 = this.transform.position;
                StartCoroutine(FlyBoomerangToTarget(obj, targetWeapon.position, target2, 10f));
            }
            else
            {
                StartCoroutine(FlyWeaponToTarget(obj, targetWeapon.position, 10f));
            }
        }
    label:;
        yield return null;
    }

    public IEnumerator DelayAttack(float delayTime)
    {
        canAttack = false;
        float elapsedTime = 0f;
        float duration = delayTime;
        while (elapsedTime < duration)
        {
            if (character.isMoving)
            {
                goto label1;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
            yield return null;
        }
        canAttack = true;
        if (!character.isDead)
        {
            characterAnimation.ChangeAnim(Constant.IDLE);
        }
        character.DisplayOnHandWeapon();
        label1:;
    }
}