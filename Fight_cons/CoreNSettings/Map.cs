using FightCons.Enemies;
using FightCons.World.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FightCons.CoreNSettings
{
    public class Map
    {
        private char[,] MapMas { get; set; }
        private int MapWidth { get; set; }
        private int MapHeight { get; set; }

        // Словарь для интерактивных объектов (сундуки)
        Dictionary<(int, int), Action> InteractiveObjects { get; set; }
        // Словарь для невидимых триггеров (ловушки)
        Dictionary<(int, int), Action> Triggers { get; set; }

        // Словарь для невидимых триггеров (ловушки)
        Dictionary<List<(int, int)>, Action> ScenarioTriggers { get; set; }

        Dictionary<(int, int), Action<Hero>> ExitPoints { get; set; }

        (Action<Hero>, Action<Hero>, double) RestEvent { get; }

        private bool[,] revealed { get; set; }

        //  Спавн позиция игрока
        public static int playerX { get; set; } = 1;
        public static int playerY { get; set; } = 1;

        // Противник обозначается символом "E"
        //public static int enemySpawnX = 18;
        //public static int enemySpawnY = 8;
        static int mapStartLine = -1;
        public static bool rendering = true;

        // Задержка для обновления противника (в миллисекундах)
        //static int enemyUpdateDelay = 500;
        //static DateTime lastEnemyUpdate = DateTime.Now;

        public enum transit
        {
            //  Valley
            CavesToValley,
            OrdoToValley,
            FoothillsToValley,
            NeighborhoodToValley,
            WoodsToValley,

            //  Foothills
            ValleyToFoothills,
            SenisusColonyToFoothills,
        }

        public Map(int mapWidth, int mapHeight, char[,] mapMas, Dictionary<(int, int), Action> interactiveObjects, Dictionary<(int, int), Action> triggers, Dictionary<(int, int), Action<Hero>> exitPoint, (Action<Hero>, Action<Hero>, double) restEvent)
        {
            MapMas = mapMas;
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            InteractiveObjects = interactiveObjects;
            Triggers = triggers;
            ExitPoints = exitPoint;

            revealed = new bool[MapWidth, MapHeight];
            RestEvent = restEvent;
        }

        public Map(int mapWidth, int mapHeight, char[,] mapMas, Dictionary<(int, int), Action> interactiveObjects, Dictionary<List<(int, int)>, Action> triggers, Dictionary<(int, int), Action<Hero>> exitPoint, (Action<Hero>, Action<Hero>, double) restEvent)
        {
            MapMas = mapMas;
            MapWidth = mapWidth;
            MapHeight = mapHeight;
            InteractiveObjects = interactiveObjects;
            ScenarioTriggers = triggers;
            ExitPoints = exitPoint;

            revealed = new bool[MapWidth, MapHeight];
            RestEvent = restEvent;
        }

        public void Transition(Hero hero, Dictionary<Enum, (int, int)> spawnPoints, transit transit, string[] locInfo, List<LocationScenarioEvent> scenario = null)
        {
            playerX = spawnPoints[transit].Item1;
            playerY = spawnPoints[transit].Item2;

            MapMethod(hero, locInfo, scenario);
        }

        public void Transition(Hero hero, (int, int) coordinates, string[] locInfo, List<LocationScenarioEvent> scenario = null)
        {
            playerX = coordinates.Item1;
            playerY = coordinates.Item2;

            MapMethod(hero, locInfo, scenario);
        }

        //public void MapMethod(Hero hero, Dictionary<Enum, (int, int)> spawnPoints, transit transit, List<LocationScenarioEvent> scenario = null)
        //{
        //    playerX = spawnPoints[transit].Item1;
        //    playerY = spawnPoints[transit].Item2;

        //    //if (x != 0 && y != 0)
        //    //{
        //    //    playerX = x;
        //    //    playerY = y;
        //    //}

        //    mapStartLine = -1;

        //    rendering = true;

        //    Console.CursorVisible = false;

        //    //Console.WriteLine("История событий: игра началась...");
        //    Console.WriteLine("\nИспользуйте стрелки для передвижения"
        //                    + "\nR - отдых"
        //                    + "\nQ - ввод команды.");

        //    // Открываем сразу все сундуки (чтобы клетки с 'X' были видны)
        //    //RevealTreasures();

        //    //DrawMap();

        //    while (rendering)
        //    {

        //        /*
        //        // Обновляем противника только если прошло достаточно времени
        //        //if ((DateTime.Now - lastEnemyUpdate).TotalMilliseconds >= enemyUpdateDelay)
        //        //{
        //        //    UpdateEnemy();
        //        //    lastEnemyUpdate = DateTime.Now;
        //        //}*/

        //        DrawMap();
        //        DrawPosition();

        //        if (Console.KeyAvailable)
        //        {
        //            ConsoleKeyInfo key = Console.ReadKey(true);
        //            ProcessInput(key, hero);

        //            TriggerCheck(hero, scenario);
        //        }

        //        Thread.Sleep(300);
        //    }
        //}

        public void MapMethod(Hero hero, string[] locInfo, List<LocationScenarioEvent> scenario = null)
        {
            //if (x != 0 && y != 0)
            //{
            //    playerX = x;
            //    playerY = y;
            //}

            mapStartLine = -1;

            rendering = true;

            Console.CursorVisible = false;

            //Console.WriteLine("История событий: игра началась...");

            Output.WriteColorLine(ConsoleColor.Cyan, "\nЛокация: ", $"{locInfo[0]}\n");
            Output.TwriteLine(locInfo[1], 1);

            hero.HPnMPBar(true, true);

            Console.WriteLine("\nИспользуйте стрелки для передвижения"
                            + "\nR - отдых"
                            + "\nQ - ввод команды.");

            // Открываем сразу все сундуки (чтобы клетки с 'X' были видны)
            //RevealTreasures();

            //DrawMap();

            while (rendering)
            {

                /*
                // Обновляем противника только если прошло достаточно времени
                //if ((DateTime.Now - lastEnemyUpdate).TotalMilliseconds >= enemyUpdateDelay)
                //{
                //    UpdateEnemy();
                //    lastEnemyUpdate = DateTime.Now;
                //}*/
                DrawMap();
                DrawPosition();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ProcessInput(key, hero);

                    TriggerCheck(hero, scenario);
                }

                if (MapHeight >= 17)
                    Thread.Sleep(35 * MapHeight);
                else
                    Thread.Sleep(10 * (MapHeight / 2));
            }

        }

        void DrawMap()
        {
            if (mapStartLine < 0)
                mapStartLine = Console.CursorTop;

            int mapWidth = MapWidth;
            int padding = (Console.WindowWidth - mapWidth) / 2;

            // Очищаем область карты
            for (int row = 0; row < MapHeight; row++)
            {
                Console.SetCursorPosition(0, mapStartLine + row);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            // Рисуем карту
            for (int y = 0; y < MapHeight; y++)
            {
                Console.SetCursorPosition(padding, mapStartLine + y);

                for (int x = 0; x < MapWidth; x++)
                {
                    //Console.SetCursorPosition(x, mapStartLine + y);
                    Console.Write(revealed[x, y] ? MapMas[y, x] : '?');
                }
            }

            // Рисуем противника (E)
            //Console.SetCursorPosition(enemySpawnX, mapStartLine + enemySpawnY);
            //Console.Write("E");

            // Рисуем игрока
            if (playerX >= 0 && playerY >= 0)
            {
                Console.SetCursorPosition(padding + playerX, mapStartLine + playerY);
                Console.Write("P");
            }

            if (IsNearInteractiveObject(out _))
                DrawInteractionHint();
            else
                ClearInteractionHint();

            Console.SetCursorPosition(0, mapStartLine + MapHeight);
        }

        void ProcessInput(ConsoleKeyInfo key, Hero hero)
        {
            int newX = playerX, 
                newY = playerY;

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                case ConsoleKey.Enter:
                    // Если игрок стоит на точке выхода ('O'), активировать выход
                    if (ExitPoints.ContainsKey((playerX, playerY)))
                    {
                        ExitPoints[(playerX, playerY)].Invoke(hero);
                    }
                    // Если рядом с сундуком (X), активировать его действие
                    else if (IsNearInteractiveObject(out var action))
                    {
                        action.Invoke();
                    }
                    return;
                case ConsoleKey.Q:
                    EnterCommandMode(hero);                    
                    return;
                case ConsoleKey.R:
                    //TODO Переделать этот кал
                    rendering = false;
                    if ( GameFormulas.Vero(RestEvent.Item3))
                        RestEvent.Item1.Invoke(hero);
                    else
                        RestEvent.Item2.Invoke(hero);

                    //if (GameFormulas.Vero(0.8))
                    //    Locations.RestEvent(hero);
                    //else
                    //{
                    //    Locations.RestEvent(hero);

                    //    rendering = false;
                    //    //mapStartLine = -1;
                    //    //Console.CursorVisible = true;

                    //    List<Order> battleList = new List<Order>()
                    //    {
                    //        new Order(1, Character.ChaRole.Wild),
                    //    };
                    //    Battles.MakeRandomBattle(hero, battleList);
                    //}
                    return;
            }

            if (newX >= 0 && newX < MapWidth && newY >= 0 && newY < MapHeight)
            {
                // Разрешённые для прохода клетки: 'O', ' ' или '.'
                if (MapMas[newY, newX] == '⌂' || MapMas[newY, newX] == 'O' || MapMas[newY, newX] == ' ' || MapMas[newY, newX] == '.')
                {
                    playerX = newX;
                    playerY = newY;
                    RevealArea(playerX, playerY, 2);
                    if (Triggers != null)
                        TriggerCheck(playerX, playerY);
                    DrawMap();
                }
                else if (MapMas[newY, newX] == 'X') // Сундуки непроходимы
                {
                    if (IsNearInteractiveObject(out var action))
                    {
                        action.Invoke();
                    }
                }
            }
        }

        void TriggerCheck(Hero hero, List<LocationScenarioEvent> scenario) => LocationScenarioEvent.CheckScenarios(hero, ScenarioTriggers, scenario);

        #region Противник на карте
        //  временно в ящик
        /*static void UpdateEnemy()
        {
            int desiredX = enemySpawnX;
            int desiredY = enemySpawnY;

            int dx = spawnX - enemySpawnX;
            int dy = spawnY - enemySpawnY;

            // Приоритет движения по той оси, где расстояние больше
            if (Math.Abs(dx) >= Math.Abs(dy))
            {
                desiredX += dx > 0 ? 1 : (dx < 0 ? -1 : 0);
            }
            else
            {
                desiredY += dy > 0 ? 1 : (dy < 0 ? -1 : 0);
            }

            if (desiredX >= 0 && desiredX < mapWidth && desiredY >= 0 && desiredY < mapHeight &&
                IsCellPassableForEnemy(desiredX, desiredY))
            {
                enemySpawnX = desiredX;
                enemySpawnY = desiredY;
            }
            else
            {
                // Если первый вариант не подходит, пробуем вертикальное движение, затем горизонтальное
                desiredX = enemySpawnX;
                desiredY = enemySpawnY + (dy > 0 ? 1 : (dy < 0 ? -1 : 0));
                if (desiredX >= 0 && desiredX < mapWidth && desiredY >= 0 && desiredY < mapHeight &&
                    IsCellPassableForEnemy(desiredX, desiredY))
                {
                    enemySpawnX = desiredX;
                    enemySpawnY = desiredY;
                }
                else
                {
                    desiredX = enemySpawnX + (dx > 0 ? 1 : (dx < 0 ? -1 : 0));
                    desiredY = enemySpawnY;
                    if (desiredX >= 0 && desiredX < mapWidth && desiredY >= 0 && desiredY < mapHeight &&
                        IsCellPassableForEnemy(desiredX, desiredY))
                    {
                        enemySpawnX = desiredX;
                        enemySpawnY = desiredY;
                    }
                }
            }

            // Если противник столкнулся с игроком
            if (enemySpawnX == spawnX && enemySpawnY == spawnY)
            {
                EnemyCollision();
            }
        }*/

        bool IsCellPassableForEnemy(int x, int y)
        {
            char cell = MapMas[y, x];
            return cell == ' ' || cell == '.' || cell == 'O';
        }

        void EnemyCollision()
        {
            ShowMessage("Противник поймал вас! Игра окончена.");
            rendering = false;
        }
        #endregion

        void RevealArea(int centerX, int centerY, int radius)
        {
            for (int y = centerY - radius; y <= centerY + radius; y++)
            {
                for (int x = centerX - radius; x <= centerX + radius; x++)
                {
                    if (x >= 0 && x < MapWidth && y >= 0 && y < MapHeight)
                    {
                        revealed[x, y] = true;
                    }
                }
            }
        }

        void RevealTreasures()
        {
            for (int y = 0; y < MapHeight; y++)
                for (int x = 0; x < MapWidth; x++)
                    if (MapMas[y, x] == 'X')
                        revealed[x, y] = true;
        }

        bool IsNearInteractiveObject(out Action action)
        {
            // Проверяем соседние клетки (слева, справа, сверху, снизу) для сундуков
            foreach (var offset in new (int x, int y)[] { (-1, 0), (1, 0), (0, -1), (0, 1) })
            {
                int checkX = playerX + offset.x;
                int checkY = playerY + offset.y;
                if (InteractiveObjects.ContainsKey((checkX, checkY)))
                {
                    action = InteractiveObjects[(checkX, checkY)];
                    return true;
                }
            }
            action = null;
            return false;
        }

        void DrawInteractionHint()
        {
            int hintY = mapStartLine + MapHeight;
            Console.SetCursorPosition(0, hintY);
            Console.Write("Нажмите Enter, чтобы взаимодействовать.");
        }

        void DrawPosition()
        {
            int hintY = mapStartLine + MapHeight;
            Console.SetCursorPosition(0, hintY);
            Console.Write($"Позиция игрока: X:{playerX} Y:{playerY}");
        }

        void ClearInteractionHint()
        {
            int hintY = mapStartLine + MapHeight;
            Console.SetCursorPosition(0, hintY);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        void EnterCommandMode(Hero hero)
        {
            int inputY = mapStartLine + MapHeight + 1;
            Console.SetCursorPosition(0, inputY);
            Console.Write("Введите команду: ");
            if (Input.SbyteInput(hero, true) == 1)
            {
                rendering = false;
                //Console.SetCursorPosition(0, inputY);
                //Console.Write(new string(' ', Console.WindowWidth));
                //Console.SetCursorPosition(0, mapStartLine + MapHeight + 2);
                Output.WriteColorLine(ConsoleColor.Cyan, "\nНажмите ", "любую кнопку", " чтобы продолжить...\n");
                Console.ReadKey(true);
            }
            else
            {
                Console.SetCursorPosition(0, inputY);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, mapStartLine + MapHeight + 2);
            }

            //string command = Console.ReadLine();

            //Console.WriteLine($"Вы ввели команду: {command}");
        }

        public void ShowMessage(string message)
        {
            int msgY = mapStartLine + MapHeight + 1;
            Console.SetCursorPosition(0, msgY);
            Console.Write(message);
            Console.ReadKey(true);
            Console.SetCursorPosition(0, msgY);
            Console.Write(new string(' ', Console.WindowWidth));
        }

        void ExitGame()
        {
            ShowMessage("Вы нашли выход! Игра окончена.");
            rendering = false;
        }

        public void TriggerTrap()
        {
            ShowMessage("Осторожно! Вы попали в ловушку!");
        }

        void TriggerCheck(int x, int y)
        {
            if (Triggers.ContainsKey((x, y)))
                Triggers[(x, y)].Invoke();
        }

        public void LocationExit()
        {
            ShowMessage("Вы переходите в другую локацию");
            rendering = false;
        }
    }

    public class LocationScenarioEvent
    {
        public Func<Hero, byte, bool> Condition { get; }
        public Action<Hero> Action { get; }

        public double Vero { get; set; }

        public static bool MultiTrigger = false;


        public LocationScenarioEvent(Func<Hero, byte, bool> condition, Action<Hero> action, bool multiTrigger = false)
        {
            Condition = condition;
            Action = action;
            MultiTrigger = multiTrigger;
        }

        public LocationScenarioEvent(double vero, Func<Hero, byte, bool> condition, Action<Hero> action, bool multiTrigger = false)
        {
            Vero = vero;
            Condition = condition;
            Action = action;
            MultiTrigger = multiTrigger;
        }

        public static void CheckScenarios(Hero hero, Dictionary<List<(int, int)>, Action> triggers, List<LocationScenarioEvent> scenario = null)
        {
            if (scenario != null)
            {
                if (MultiTrigger)
                    CheckMultiScenario(hero, triggers, scenario);
                else
                    CheckSingleScenario(hero, triggers, scenario);
            }
        }

        public static void CheckSingleScenario(Hero hero, Dictionary<List<(int, int)>, Action> triggers, List<LocationScenarioEvent> scenario = null)
        {
            foreach (var bEvent in scenario.Where(x => x.Condition(hero, BattleSession.Round)).ToList())
            {
                if (triggers.Any(c => c.Key.Any(h => h == (Map.playerY, Map.playerX))))
                {
                    Map.rendering = false;
                    bEvent.Action(hero);
                }

                scenario.Remove(bEvent);
            }
        }

        public static void CheckMultiScenario(Hero hero, Dictionary<List<(int, int)>, Action> triggers, List<LocationScenarioEvent> scenario = null)
        {
            foreach (var bEvent in scenario.Where(x => x.Condition(hero, BattleSession.Round)).ToList())
            {
                //if (triggers.Any(c => c.Key.Any(h => h == (Map.playerY, Map.playerX))))
                if (GameFormulas.Vero(bEvent.Vero))
                {
                    Map.rendering = false;
                    Console.Write($"Позиция игрока: X:{Map.playerX} Y:{Map.playerY}");
                    bEvent.Action(hero);
                }
            }
        }
    }
}
