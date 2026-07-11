
using UnityEngine;

using GBB;

namespace LF.GameUI.Dynasty
{
    public class DynastyGUI_Interlayer : GameSubmodule
    {
        [SerializeField]
        private DynastyGUI_Data dynastyGUI_Data;

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
            startup.Data_Inject(dynastyGUI_Data);
        }
    }
}
