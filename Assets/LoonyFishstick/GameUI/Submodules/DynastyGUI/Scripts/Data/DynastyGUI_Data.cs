
using UnityEngine;

using Leopotam.EcsLite;

namespace LF.GameUI.Dynasty
{
    public class DynastyGUI_Data : MonoBehaviour
    {
        #region BlockPanel
        public static void Block_DynastyOverview_Creation_SR(
            int bEntity,
            EcsPool<SR_Block_DynastyOverview_Creation> r_P) 
        {
            //Назначаем переанной сущности запрос создания обзорного блока династий
            ref SR_Block_DynastyOverview_Creation rComp = ref r_P.Add(bEntity);

            //Заполняем ланные запроса
            rComp = new(0);
        }
        #endregion
    }
}
