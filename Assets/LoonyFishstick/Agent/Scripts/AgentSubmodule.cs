
using UnityEngine;

using GBB;

namespace LF.Agent
{
    public class AgentSubmodule : GameSubmodule
    {
        [SerializeField]
        private AgentData agentData;

        public override void AddSystems(GameStartup startup)
        {
            //Добавляем системы инициализации
            #region PreInit
            //Создание агентов
            startup.AddPreInitSystem(new S_Agent_Creation());
            #endregion
            #region PostInit
            //Очистка событий
            startup.AddPostInitSystem(new S_Events_Clear());
            #endregion

            //Добавляем потиковые системы
            #region PreTick
            //Создание агентов
            startup.AddPreTickSystem(new S_Agent_Creation());
            #endregion
            #region PostTick
            //Очистка событий
            startup.AddPostTickSystem(new S_Events_Clear());
            #endregion
        }

        public override void InjectData(GameStartup startup)
        {
            //Вводим данные
            startup.InjectData(agentData);
        }
    }
}
