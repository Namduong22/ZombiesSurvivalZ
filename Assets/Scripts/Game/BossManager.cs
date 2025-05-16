using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyThreshold;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpawner; 
    private bool bossCalled = false;
    [SerializeField] private Image energyBar;
    [SerializeField] GameObject energyBarUI;
	[SerializeField] GameObject bossHealthBarUI;
	[SerializeField] private GameObject winMenu;

	// Start is called before the first frame update
	void Start()
    {
        currentEnergy = 0;
        UpdateEnergyBar();
		boss.SetActive(false);
        bossHealthBarUI.SetActive(false);
        winMenu.SetActive(false);

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
        UpdateEnergyBar();
		if (currentEnergy == energyThreshold) 
        {
            CallBoss();
        }
    }

    private void CallBoss() 
    {
        bossCalled = true;
        boss.SetActive(true);
        bossHealthBarUI.SetActive(true); 
        enemySpawner.SetActive(false);
        energyBarUI.SetActive(false);
    }

    private void UpdateEnergyBar()
    {
        if (energyBar != null )
        {
			float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
			energyBar.fillAmount = fillAmount;
		}
    }

    public void WinGame()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
