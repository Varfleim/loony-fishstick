
using UnityEngine;

using Leopotam.EcsLite;

namespace LF.GameUI.Space
{
    public class SpaceGUI_Data : MonoBehaviour
    {
        #region BlockPanel
        public static void Block_PlanetSystemSurvey_Creation_SR(
            int bEntity,
            EcsPool<SR_Block_PlanetSystemSurvey_Creation> r_P)
        {
            //Ќазначаем переданной сущности запрос создани€ блока исследовани€ планетарной системы
            ref SR_Block_PlanetSystemSurvey_Creation rComp = ref r_P.Add(bEntity);

            //«аполн€ем данные запроса
            rComp = new(0);
        }
        #endregion
    }
}
