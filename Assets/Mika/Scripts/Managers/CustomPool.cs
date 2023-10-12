using UnityEngine;

namespace Mika
{
    [DisallowMultipleComponent]
    public sealed class AsteroidPool : MonoBehaviour
    {
        #region Singleton
        public static AsteroidPool Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }
        #endregion
        [SerializeField] private GameObject[] asteroidBrownPrefabs;
        [SerializeField] private GameObject[] asteroidGrayPrefabs;
        [SerializeField] private AsteroidModel asteroidModel;

        private void Start()
        {
            GameObject[] asteroidPrefabs = GetAsteroidModels();
            for (int i = 0; i < asteroidPrefabs.Length; i++)
            {
                CreateAsteroid(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)]);
            }
        }

        public GameObject Get()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject asteroid = transform.GetChild(i).gameObject;
                if (!asteroid.activeSelf)
                {
                    if (asteroid.TryGetComponent(out DefaultAsteroid defaultAsteroidScript))
                    {
                        defaultAsteroidScript.ResetLifetime();
                    }
                    asteroid.SetActive(true);
                    return asteroid;
                }
            }
            GameObject o = CreateAsteroid();
            o.SetActive(true);
            return o;
        }
        private GameObject CreateAsteroid()
        {
            GameObject[] asteroidPrefabs = GetAsteroidModels();
            return CreateAsteroid(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)]);
        }

        private GameObject CreateAsteroid(GameObject asteroidPrefab)
        {
            GameObject o = Instantiate(asteroidPrefab, asteroidPrefab.transform.position, asteroidPrefab.transform.rotation);
            o.transform.SetParent(transform);
            o.SetActive(false);
            return o;
        }

        private GameObject[] GetAsteroidModels()
        {
            return asteroidModel == AsteroidModel.BROWN ? asteroidBrownPrefabs : asteroidGrayPrefabs;
        }

        public enum AsteroidModel { BROWN, GRAY }
    }
}