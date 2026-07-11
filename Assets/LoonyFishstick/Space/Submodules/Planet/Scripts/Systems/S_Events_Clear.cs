
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LF.Planet
{
    public class S_Events_Clear : IEcsInitSystem, IEcsRunSystem
    {
        public void Init(IEcsSystems systems)
        {
            //Очищаем события планет
            Planet_Events_Clear();
        }

        public void Run(IEcsSystems systems)
        {
            //Очищаем события планет
            Planet_Events_Clear();
        }

        readonly EcsFilterInject<Inc<SE_Planet_Created>> p_Created_SE_F = default;
        void Planet_Events_Clear()
        {
            //Для каждого события создания планеты
            foreach (int planetEntity in p_Created_SE_F.Value)
            {
                //Удаляем компонент события
                p_Created_SE_F.Pools.Inc1.Del(planetEntity);
            }
        }
    }
}