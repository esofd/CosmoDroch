using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject asteroidPrefab;


    public void ButtonSpawn()
    {
        StartCoroutine(Spawn(asteroidPrefab, 10f, 20f, 100, 3f));
    }
 


    IEnumerator Spawn(GameObject go, float minRadius, float maxRadius, int count, float timeBetweenEntities)
    {
        while(count>0)
        {
            Vector3 position;
            do
            {
                position = Random.insideUnitSphere;
                
            } while (position == Vector3.zero);
            position = position.normalized * minRadius + position * (maxRadius - minRadius);
            Instantiate(go, position, Quaternion.identity);
            Debug.Log(position);
            count--;
            yield return new WaitForSeconds(timeBetweenEntities);
        }    
    }
}
