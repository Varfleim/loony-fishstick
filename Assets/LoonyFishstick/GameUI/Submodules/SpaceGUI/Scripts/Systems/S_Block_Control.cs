
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

using GBB.Map.Render;
using GS.UI;

namespace LF.GameUI.Space
{
    public class S_Block_Control : IEcsRunSystem
    {
        readonly EcsPoolInject<C_Block_PlanetSystemSurvey> b_PSSurvey_P = default;

        public void Run(IEcsSystems systems)
        {
            //Проверяем действия в блоках-списках
            BlockLists_Action();
        }

        readonly EcsFilterInject<Inc<R_BlockList_Action>> bL_Action_R_F = default;
        void BlockLists_Action()
        {
            //Для каждого запроса действия в блоке-списке
            foreach (int rEntity in bL_Action_R_F.Value)
            {
                //Берём запрос
                ref R_BlockList_Action rComp = ref bL_Action_R_F.Pools.Inc1.Get(rEntity);

                //Проверяем, было ли совершено какое-либо действие
                bool isActionComplete = false;

                //Если у блока есть элемент блока исследования планетарной системы
                if (b_PSSurvey_P.Value.Has(rComp.blockEntity))
                {
                    //Выполняем действие
                    Block_PSSurvey_Action(ref rComp);

                    isActionComplete = true;
                }

                //Если действие было совершено
                if (isActionComplete)
                {
                    UnityEngine.Debug.LogWarning("MSpace BlockAction!");

                    //Удаляем запрос
                    bL_Action_R_F.Pools.Inc1.Del(rEntity);
                }
            }
        }

        readonly EcsPoolInject<SR_Map_Activation> map_Activation_SR_P = default;
        void Block_PSSurvey_Action(
            ref R_BlockList_Action rComp)
        {
            //Берём элемент списка
            UI_BlockList_ElementPanel elementPanel = rComp.actionObject.GetComponent<UI_BlockList_ElementPanel>();

            //ТЕСТ
            //Запрашиваем активацию карты
            MapRender_Data.Map_Activation_SR(
                elementPanel.elementEntity,
                map_Activation_SR_P.Value);
            //ТЕСТ
        }
    }
}
