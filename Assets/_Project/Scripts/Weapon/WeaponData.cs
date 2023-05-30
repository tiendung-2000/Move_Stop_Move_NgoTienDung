using UnityEngine;

public enum WeaponType
{
    Knife = 0,
    Hammer = 1,
    Boomerang = 2,
}

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
    public WeaponType weaponType;
    public string weaponName;
    public GameObject weaponObject;
    public Material[] weaponMats;
    public int weaponCost;
    public Material GetWeaponMaterial(int type)
    {
        return weaponMats[(int)type];
    }
}
