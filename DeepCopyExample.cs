using UnityEngine;

//паттерн Прототип
namespace Asteroids
{
    internal sealed class DeepCopyExample : MonoBehaviour
    {
        private void Update()
        {
            RespawnObject();
        }

        private void RespawnObject()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                var copyGameObject = GameObject.FindGameObjectWithTag("AsteroidPrototype"); 
                var copyData = copyGameObject.GetComponent<AsteroidPrototype>()._asteroidPrototypeData; 

                Debug.Log("CurrentHP" + copyData._hp.CurrentHP);
                Debug.Log("speed" + copyData._speed); // исходные значения CurrentHP = 100 и _speed = 15

                AsteroidPrototypeData dataNew = copyData.DeepCopy(); 
                dataNew._hp.CurrentHP = 300;
                dataNew._speed = 20; 

                Debug.Log("------------------------");
                Debug.Log("CurrentHP" + dataNew._hp.CurrentHP);
                Debug.Log("speed" + dataNew._speed); // здесь CurrentHP = 300 и _speed = 20

                var prefab = Resources.Load("Enemy/AsteroidPrototype") as GameObject; 
                prefab.transform.position = SearchRespawnPoint();

                var asteroidNew = Instantiate(prefab);

                var script = asteroidNew.GetComponent<AsteroidPrototype>(); 

                script._asteroidPrototypeData = dataNew; //такое присвоение почему-то не меняет исходные переменные,
                                                         //(то есть не присваивает CurrentHP = 300 и _speed = 20) у созданного объекта

                asteroidNew.SetActive(true);

                script.SetData(dataNew); //так данные у созданного объекта вроде меняются, но есть непонятка...

                var currentHp = asteroidNew.GetComponent<AsteroidPrototype>()._hp.CurrentHP;
                var currentSpeed = asteroidNew.GetComponent<AsteroidPrototype>()._speed;
                
                Debug.Log("------------------------");
                Debug.Log(currentHp); 
                Debug.Log(currentSpeed); //здесь отображает уже новые значения переменных (CurrentHP = 300 и _speed = 20),
                                         //но при этом в инспекторе у объекта отображаются старые значения (CurrentHP = 100 и _speed = 15),
                                         //не понимаю, в чем тут дело
            }
        }

        private Vector3 SearchRespawnPoint()
        {
            var point = GameObject.FindGameObjectWithTag("Respawn");
            return point.transform.position;
        }
    }
}
