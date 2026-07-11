
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

using GS.UI;

namespace LF.GameUI.Dynasty
{
    public class S_Block_Control : IEcsRunSystem
    {
        readonly EcsPoolInject<C_Block_DynastyOverview> b_DOverview_P = default;

        public void Run(IEcsSystems systems)
        {
            //Проверяем действия в блоках-списках
            BlockLists_Action();
        }

        readonly EcsFilterInject<Inc<R_BlockList_Action>> bL_Action_R_F = default;
        void BlockLists_Action()
        {
            //Для каждого запроса действия в блоке-списке
            foreach(int rEntity in bL_Action_R_F.Value)
            {
                //Берём запрос
                ref R_BlockList_Action rComp = ref bL_Action_R_F.Pools.Inc1.Get(rEntity);

                //Проверяем, было ли совершено какое-либо действия
                bool isActionComplete = false;

                //Если у блока есть элемент обзорного блока династий
                if(b_DOverview_P.Value.Has(rComp.blockEntity))
                {
                    //Выполняем действие
                    Block_DOverview_Action(ref rComp);

                    isActionComplete = true;
                }

                //Если действие было совершено
                if(isActionComplete)
                {
                    UnityEngine.Debug.LogWarning("SMDynasty BlockAction!");

                    //Удаляем запрос
                    bL_Action_R_F.Pools.Inc1.Del(rEntity);
                }
            }
        }

        void Block_DOverview_Action(
            ref R_BlockList_Action rComp)
        {

        }
    }
}
