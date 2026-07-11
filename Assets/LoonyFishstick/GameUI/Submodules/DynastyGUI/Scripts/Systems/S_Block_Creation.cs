
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LF.GameUI.Dynasty
{
    public class S_Block_Creation : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            //Создаём обзорные блоки династий
            Blocks_DOverview_Creation();
        }

        readonly EcsFilterInject<Inc<SR_Block_DynastyOverview_Creation>> b_DOverview_Creation_SR_F = default;
        void Blocks_DOverview_Creation()
        {
            //Для каждого запроса создания блока
            foreach(int bEntity in b_DOverview_Creation_SR_F.Value)
            {
                //Берём запрос
                ref SR_Block_DynastyOverview_Creation rComp = ref b_DOverview_Creation_SR_F.Pools.Inc1.Get(bEntity);

                //Создаём блок
                Block_DOverview_Creation(
                    bEntity,
                    ref rComp);

                //Удаляем запрос
                b_DOverview_Creation_SR_F.Pools.Inc1.Del(bEntity);
            }
        }

        readonly EcsPoolInject<C_Block_DynastyOverview> b_DOverview_P = default;
        void Block_DOverview_Creation(
            int bEntity,
            ref SR_Block_DynastyOverview_Creation rComp)
        {
            //Назначаем сущности компонент обзорного блока династий
            ref C_Block_DynastyOverview bDO = ref b_DOverview_P.Value.Add(bEntity);
        }
    }
}
