
using UnityEngine;

using GBB;

namespace LF.GameUI.Space
{
    public class SpaceGUI_Interlayer : GameSubmodule
    {
        [SerializeField]
        private SpaceGUI_Data spaceGUI_Data;

        public override void Systems_Add(GameStartup startup)
        {
            //Добавляем системы инициализации
            #region Init
            //Создание блоков
            startup.InitSystem_Add(new S_Block_Creation());
            #endregion

            //Добавляем системы рендеринга
            #region PreRender
            //Управление блоками
            startup.PreRenderSystem_Add(new S_Block_Control());
            #endregion
            #region Render
            //Обновление блоков
            startup.RenderSystem_Add(new S_Block_Update());
            #endregion
        }

        public override void Data_Inject(GameStartup startup)
        {
            //Вводим данные
            startup.Data_Inject(spaceGUI_Data);
        }
    }
}
