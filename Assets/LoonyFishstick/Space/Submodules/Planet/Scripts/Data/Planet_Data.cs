
using UnityEngine;

using Leopotam.EcsLite;

namespace LF.Planet
{
    public class Planet_Data : MonoBehaviour
    {
        public static void Planet_Creation_SR(
            int pEntity,
            EcsPool<SR_Planet_Creation> r_P,
            string planetName)
        {
            //Назначаем сущности запрос создания планеты и заполняем его данные
            ref SR_Planet_Creation rComp = ref r_P.Add(pEntity);
            rComp = new(planetName);
        }
    }
}