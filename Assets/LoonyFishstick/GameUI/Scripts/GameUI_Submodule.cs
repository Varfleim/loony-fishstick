
using UnityEngine;

using GBB;

namespace LF.GameUI
{
    public class GameUI_Submodule : GameSubmodule
    {
        [SerializeField]
        private GameUI_Data gameUI_Data;

        public override void Systems_Add(GameStartup startup)
        {
            //Добавляем системы инициализации
            #region PreInit
            //Инициализация обзорных панелей
            startup.PreInitSystem_Add(new S_OverviewPanel_Initialization());
            #endregion

            //Добавляем системы рендеринга

            //Добавляем потиковые системы
            #region PostTick
            //Обновление GameUI после тика
            startup.PostTickSystem_Add(new S_GameWindow_TickUpdate());
            #endregion
        }

        public override void Data_Inject(GameStartup startup)
        {
            //Вводим данные
            startup.Data_Inject(gameUI_Data);
        }
    }
}
