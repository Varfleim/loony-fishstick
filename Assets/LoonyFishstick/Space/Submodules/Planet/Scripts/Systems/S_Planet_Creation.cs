
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LF.Planet
{
    public class S_Planet_Creation : IEcsInitSystem, IEcsRunSystem
    {
        public void Init(IEcsSystems systems)
        {
            //Создаём планеты
            Planets_Creation();
        }

        public void Run(IEcsSystems systems)
        {
            //Создаём планеты
            Planets_Creation();
        }

        readonly EcsFilterInject<Inc<SR_Planet_Creation>> p_Creation_SR_F = default;
        void Planets_Creation()
        {
            //Для каждого запроса создания планеты
            foreach (int pEntity in p_Creation_SR_F.Value)
            {
                //Берём запрос
                ref SR_Planet_Creation rComp = ref p_Creation_SR_F.Pools.Inc1.Get(pEntity);

                //Создаём планету
                Planet_Creation(
                    pEntity,
                    ref rComp);

                //Удаляем запрос
                p_Creation_SR_F.Pools.Inc1.Del(pEntity);
            }
        }

        readonly EcsPoolInject<C_Planet> p_P = default;
        void Planet_Creation(
            int pEntity,
            ref SR_Planet_Creation rComp)
        {
            //Назначаем сущности компонент планеты и заполняем его данные
            ref C_Planet p = ref p_P.Value.Add(pEntity);

            p = new(rComp.planetName);

            //Создаём событие, сообщающее о создании планеты
            Planet_Created_SE(pEntity);
        }

        readonly EcsPoolInject<SE_Planet_Created> p_Created_SE_P = default;
        void Planet_Created_SE(
            int pEntity)
        {
            //Назначаем сущности компонент события и заполняем его данные
            ref SE_Planet_Created eComp = ref p_Created_SE_P.Value.Add(pEntity);
            eComp = new(0);
        }
    }
}