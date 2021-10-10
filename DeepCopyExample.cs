using UnityEngine;

namespace Asteroids
{
    //Роман, тут я запутался и хотел бы попросить помочь разобраться
    //прокомментировал свои действия, как я их понимаю
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
                var copyGameObject = GameObject.FindGameObjectWithTag("AsteroidPrototype"); //ищу по тэгу объект на сцене, который буду респавнить
                var copyData = copyGameObject.GetComponent<AsteroidPrototype>()._asteroidPrototypeData; //обращаюсь к полю скрипта, висящего на объекте

                Debug.Log("CurrentHP" + copyData._hp.CurrentHP);
                Debug.Log("speed" + copyData._speed); //проверяю исходные значения - 100 и 15

                AsteroidPrototypeData dataNew = copyData.DeepCopy(); //выполняю глубокое копирование, результат кладу в dataNew
                dataNew._hp.CurrentHP = 300;
                dataNew._speed = 20; // меняю значения

                Debug.Log("------------------------");
                Debug.Log("CurrentHP" + dataNew._hp.CurrentHP);
                Debug.Log("speed" + dataNew._speed); // Debug.Log показывет, что новые значения (300 и 20) присвоены

                var asteroidRespawn = Resources.Load("Enemy/AsteroidPrototype") as GameObject; // создаю ссылку на префаб
                asteroidRespawn.transform.position = SearchRespawnPoint();
                Instantiate(asteroidRespawn);
                
                var script = asteroidRespawn.GetComponent<AsteroidPrototype>(); // получаю ссылку на скрипт, висящий на объекте
                

                script._asteroidPrototypeData = dataNew; //почему-то не присваивает новые значения переменных (_speed = 20 и _hp.CurrentHP = 300)
                                                         //на gameobject, который будет создан командой Instantiate

                

                script.SetData(dataNew, dataNew._hp, dataNew._speed); //тоже нет присвоения новых значений на gameobject
                                                                      //пробовал с модификаторами ref, out и без них - без результата                  

                var currentHp = asteroidRespawn.GetComponent<AsteroidPrototype>()._hp.CurrentHP;
                var currentSpeed = asteroidRespawn.GetComponent<AsteroidPrototype>()._speed;
                
                Debug.Log("------------------------");
                Debug.Log(currentHp); // показывает 100 - как описано в исходном варианте класса AsteroidPrototypeHp
                Debug.Log(currentSpeed); // показывет значение 0 - вообще непонятно откуда оно
            }
        }

        private Vector3 SearchRespawnPoint()
        {
            var point = GameObject.FindGameObjectWithTag("Respawn");
            return point.transform.position;
        }
    }
}
