
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace LF.Dynasty
{
    public class S_Events_Clear : IEcsInitSystem, IEcsRunSystem
    {
        public void Init(IEcsSystems systems)
        {
            //Очищаем события династий
            Planet_Events_Clear();
        }

        public void Run(IEcsSystems systems)
        {
            //Очищаем события династий
            Planet_Events_Clear();
        }

        readonly EcsFilterInject<Inc<SE_Dynasty_Created>> d_Created_SE_F = default;
        void Planet_Events_Clear()
        {
            //Для каждого события создания династии
            foreach (int dEntity in d_Created_SE_F.Value)
            {
                //Удаляем компонент события
                d_Created_SE_F.Pools.Inc1.Del(dEntity);
            }
        }
    }
}
