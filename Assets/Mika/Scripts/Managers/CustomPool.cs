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
            for (int i = 0; i < this.transform.childCount; i++)
            {
                GameObject asteroid = transform.GetChild(i).gameObject;
                if (!asteroid.activeInHierarchy)
                {
                    asteroid.SetActive(true);
                    return asteroid;
                }
            }
            GameObject o = CreateAsteroid();
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
            o.transform.SetParent(this.transform);
            o.SetActive(false);
            return o;
        }

        private GameObject[] GetAsteroidModels()
        {
            return this.asteroidModel == AsteroidModel.BROWN ? this.asteroidBrownPrefabs : this.asteroidGrayPrefabs;
        }

        public enum AsteroidModel { BROWN, GRAY }
    }
}