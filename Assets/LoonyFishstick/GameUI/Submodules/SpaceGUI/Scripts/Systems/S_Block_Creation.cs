
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LF.GameUI.Space
{
    public class S_Block_Creation : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            //Создаём блоки исследования планетарных систем
            Blocks_PSSurvey_Creation();
        }

        readonly EcsFilterInject<Inc<SR_Block_PlanetSystemSurvey_Creation>> b_PSSurvey_Creation_SR_F = default;
        void Blocks_PSSurvey_Creation()
        {
            //Для каждого запроса создания блока
            foreach (int bEntity in b_PSSurvey_Creation_SR_F.Value)
            {
                //Берём запрос
                ref SR_Block_PlanetSystemSurvey_Creation rComp = ref b_PSSurvey_Creation_SR_F.Pools.Inc1.Get(bEntity);

                //Создаём блок
                Block_PSSurvey_Creation(
                    bEntity,
                    ref rComp);

                //Удаляем запрос
                b_PSSurvey_Creation_SR_F.Pools.Inc1.Del(bEntity);
            }
        }

        readonly EcsPoolInject<C_Block_PlanetSystemSurvey> b_PSSurvey_P = default;
        void Block_PSSurvey_Creation(
            int bEntity,
            ref SR_Block_PlanetSystemSurvey_Creation rComp)
        {
            //Назначаем сущности компонент блока исследования планетарной системы
            ref C_Block_PlanetSystemSurvey bPSS = ref b_PSSurvey_P.Value.Add(bEntity);
        }
    }
}
