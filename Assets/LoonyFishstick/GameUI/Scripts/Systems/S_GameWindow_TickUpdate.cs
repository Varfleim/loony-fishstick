
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

using GS.UI;

namespace LF.GameUI
{
    public class S_GameWindow_TickUpdate : IEcsRunSystem
    {
        readonly EcsCustomInject<UI_Core> uI_Core = default;

        public void Run(IEcsSystems systems)
        {
            //Если активно окно игры
            if (uI_Core.Value.activeWindow == uI_Core.Value.gameWindow.gameObject)
            {
                //Проверяем, не требуется ли обновление в окне игры
                GameWindow_TickUpdate();
            }
        }

        void GameWindow_TickUpdate()
        {

        }
    }
}
