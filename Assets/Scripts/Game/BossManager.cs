using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int currentEnergy;
    [SerializeField] private int energyThreshold;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpawner; 
    private bool bossCalled = false;

	// Start is called before the first frame update
	void Start()
    {
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEnergy() 
    {
        if (bossCalled)
        {
            return;
        }
        currentEnergy += 1;
        if (currentEnergy == energyThreshold) 
        {
            CallBoss();
        }
    }

    private void CallBoss() 
    {
        bossCalled = true;
        boss.SetActive(true);
        enemySpawner.SetActive(false);
    }
}
