using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacdot : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D co)//проверяем было ли столкновение с пакманом, если да, то уничтожаем
    {//тут можно вести счет
        if (co.name == "pacman")
            Destroy(gameObject);
    }
}
