using DependencyInjection.Common;
using DependencyInjection.Containers;
using DependencyInjection.Contracts;
using DependencyInjection.DI.Attributes;
using DependencyInjection.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DependencyInjection
{
    public class Engine
    {
        private ILogger logger;
        private IReader reader;
        private List<IGameObject> gameObjects;
        private List<IGameObject> enemies;
        private Ball ball;
        private IMover mover;
        public Engine(ILogger logger, IReader reader, IMover mover)
        {
            this.logger = logger;
            this.reader = reader;
            this.mover = mover;
            this.enemies = new List<IGameObject>();
            gameObjects = new List<IGameObject>();
            ball = GlobalInjector.Instance.Inject<Ball>();
            gameObjects.Add(ball);
            enemies.Add(GlobalInjector.Instance.Inject<Enemy>());
        }

        public void Start()
        {
            while (true)
            {
                foreach (var gameObject in gameObjects)
                {
                    gameObject.Draw();
                }
                foreach (var gameObject in enemies)
                {
                    gameObject.Draw();
                    mover.Move(gameObject, new Position(1, 0));
                }
                Position position = reader.ReadKey();

                mover.Move(ball, position);

                Thread.Sleep(100);
                Console.Clear();
            }
        }
        public void End()
        {
            logger.Log("Game Ended");
        }
    }
}
