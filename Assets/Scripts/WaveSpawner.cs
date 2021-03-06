using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

    public GameObject shopUI;
    private TurretBlueprint turretToBuild;

    public float timeBetweenWaves = 5f;
	private float countdown = 10f;

	public Text waveCountdownText;

	public GameManager gameManager;
    BuildManager buildManager;

	private int waveIndex = 0;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    void Update ()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			gameManager.WinLevel();
			this.enabled = false;
		}

		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
            //countdown = timeBetweenWaves;
            shopUI.SetActive(false);
            turretToBuild = null;

            return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;

		if(waveIndex != waves.Length)
        {
            Wave wave = waves[waveIndex];

            EnemiesAlive = wave.count;

            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);
            }

            waveIndex++;
        }
	}

	void SpawnEnemy (GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}

}
