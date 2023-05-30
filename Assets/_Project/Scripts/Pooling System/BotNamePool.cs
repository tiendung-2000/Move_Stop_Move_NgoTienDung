using System.Collections.Generic;
using UnityEngine;

public class BotNamePool : MonoBehaviour
{
    [SerializeField] private GameObject botNamePrefab;
    [SerializeField] private Canvas canvas;
    private List<GameObject> pool = new List<GameObject>();
    public List<string> nameList = new List<string>();
    public int poolSize;

    public static BotNamePool instance;
    private void Awake()
    {
        instance = this; 
    }
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(botNamePrefab);
            obj.transform.SetParent(canvas.gameObject.transform);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(botNamePrefab);
        newObj.transform.SetParent(canvas.gameObject.transform);
        pool.Add(newObj);
        return newObj;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}