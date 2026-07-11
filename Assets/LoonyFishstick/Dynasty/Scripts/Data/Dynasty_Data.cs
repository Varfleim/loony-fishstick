using UnityEngine;

using Leopotam.EcsLite;

namespace LF.Dynasty
{
    public class Dynasty_Data : MonoBehaviour
    {
        public static void Dynasty_Creation_SR(
            int dEntity,
            EcsPool<SR_Dynasty_Creation> r_P,
            string dynastyName)
        {
            //Назначаем сущности запрос создания династии и заполняем его данные
            ref SR_Dynasty_Creation rComp = ref r_P.Add(dEntity);
            rComp = new(dynastyName);
        }
    }
}
