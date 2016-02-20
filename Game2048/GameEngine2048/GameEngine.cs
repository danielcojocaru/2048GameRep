using GameEngine2048.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameEngine2048
{
    public class GameEngine : IGameEngine
    {
        #region Fields
        
        /// <summary>
        /// List of all the moves in the current game
        /// </summary>
        private List<int[,]> historyMatrix;

        private List<int> historyScore;

        private const int timeToSearchEndGame = 5000;

        /// <summary>
        /// Current matrix
        /// </summary>
        public int[,] CurrentMatrix;

        /// <summary>
        /// Random
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Size of current matrix.
        /// </summary>
        private int size;
        private int toAddToScore;
        private object locker = new object();

        #endregion Fields

        #region Events

        /// <summary>
        /// Triggers when there are no more moves that can be applied
        /// </summary>
        public event EventHandler GameOver;

        /// <summary>
        /// Trigger for GameEnded event
        /// </summary>
        private void OnGameOver()
        {
            if (GameOver != null)
                GameOver(this, EventArgs.Empty);
        }

        #endregion Events

        #region Constructors

        /// <summary>
        /// Gets an instance of GameEngine
        /// </summary>
        public GameEngine(int size)
        {
            this.size = size;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets current score
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Gets current number of moves
        /// </summary>
        public int Moves { get; private set; }

        #endregion Properties

        #region Public methods

        /// <summary>
        /// Gets an initialized matrix of the given size with two random numbers in random positions.
        /// </summary>
        /// <param name="size">The size of the desired matrix.</param>
        /// <returns></returns>
        public void StartGame()
        {
            InitializeGameData();
            SetStartingMatrix();
            AddCurrentStepToHistory();

            Task.Factory.StartNew(CheckIfTheGameIsOver);
        }

        private void CheckIfTheGameIsOver()
        {
            while (true)
            {
                Thread.Sleep(timeToSearchEndGame);
                if (GameIsOver())
                {
                    OnGameOver();
                }
            }
        }

        private bool GameIsOver()
        {
            int[,] firstMatrix = new int[this.size, this.size];
            int[,] secondMatrix = new int[this.size, this.size];
            lock (this.locker)
            {
                firstMatrix = GetLastMatrixFromHistory();
                secondMatrix = GetLastMatrixFromHistory();
            }

            TryChangeMatrix(secondMatrix);

            return TheMatrixesAreIdentical(firstMatrix, secondMatrix);
        }


        private void TryChangeMatrix(int[,] secondMatrix)
        {
            TryChangeMatrix(secondMatrix, EMoveType.Down);
            TryChangeMatrix(secondMatrix, EMoveType.Up);
            TryChangeMatrix(secondMatrix, EMoveType.Right);
            TryChangeMatrix(secondMatrix, EMoveType.Left);
        }

        private void AddCurrentStepToHistory()
        {
            lock (this.locker)
            {
                this.historyMatrix.Add(this.CurrentMatrix);
            }
            this.historyScore.Add(this.Score);
        }

        /// <summary>
        /// Applies the move to the current matrix and gets the resulting one.
        /// </summary>
        /// <param name="moveType">Move type.</param>
        /// <returns></returns>
        public void ApplyMove(EMoveType moveType)
        {
            this.CurrentMatrix = GetLastMatrixFromHistory();
            TryChangeMatrix(this.CurrentMatrix, moveType);
            bool currentMatrixChanged = !TheMatrixesAreIdentical(this.CurrentMatrix, this.historyMatrix[this.historyMatrix.Count - 1]);
            if (currentMatrixChanged)
            {
                this.Score += toAddToScore;
                this.toAddToScore = 0;

                AddRandomNumberOnCurrentMatrix();

                AddCurrentStepToHistory();
                this.Moves = this.historyScore.Count - 1;
            }
        }

        private int[,] GetLastMatrixFromHistory()
        {
            int[,] lastMatrix = new int[size, size];
            int[,] lastMatrixInHistory = this.historyMatrix[this.historyMatrix.Count - 1];

            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    lastMatrix[i,j] = lastMatrixInHistory[i, j];
                }
            }
            return lastMatrix;
        }

        private void TryChangeMatrix(int[,] matrix, EMoveType move)
        {
            switch (move)
            {
                case EMoveType.Left:
                    for (int x = 0; x < this.size; x++)
                    {
                        List<int> toChangeList = new List<int>();

                        for (int y = 0; y < this.size; y++)
                        {
                            toChangeList.Add(matrix[x, y]);
                        }
                        OrderList(toChangeList);
                        for (int y = 0; y < this.size; y++)
                        {
                            matrix[x, y] = toChangeList[y];
                        }
                    }
                    break;

                case EMoveType.Right:
                    for (int x = 0; x < this.size; x++)
                    {
                        List<int> toChangeList = new List<int>();
                        int listIndex = -1;

                        for (int y = this.size - 1; y >= 0; y--)
                        {
                            toChangeList.Add(matrix[x, y]);
                        }
                        OrderList(toChangeList);
                        for (int y = this.size - 1; y >= 0; y--)
                        {
                            listIndex += 1;
                            matrix[x, y] = toChangeList[listIndex];
                        }
                    }
                    break;

                case EMoveType.Up:
                    for (int y = 0; y < this.size; y++)
                    {
                        List<int> toChangeList = new List<int>();

                        for (int x = 0; x < this.size; x++)
                        {
                            toChangeList.Add(matrix[x, y]);
                        }
                        OrderList(toChangeList);
                        for (int x = 0; x < this.size; x++)
                        {
                            matrix[x, y] = toChangeList[x];
                        }
                    }
                    break;

                case EMoveType.Down:
                    for (int y = 0; y < this.size; y++)
                    {
                        List<int> toChangeList = new List<int>();
                        int listIndex = -1;

                        for (int x = this.size - 1; x >= 0; x--)
                        {
                            toChangeList.Add(matrix[x, y]);
                        }
                        OrderList(toChangeList);
                        for (int x = this.size - 1; x >= 0; x--)
                        {
                            listIndex += 1;
                            matrix[x, y] = toChangeList[listIndex];
                        }
                    }
                    break;
            }
        }

        private void OrderList(List<int> listToBeOrdered)
        {
            EliminateZeros(listToBeOrdered);
            EliminateDuplicates(listToBeOrdered);
            EliminateZeros(listToBeOrdered);
        }

        private void EliminateZeros(List<int> listToBeOrdered)
        {
            bool keepEliminateZeros = true;
            while (keepEliminateZeros)
            {
                keepEliminateZeros = false;
                for (int i = 1; i < listToBeOrdered.Count; i++)
                {
                    if (listToBeOrdered[i] != 0 && listToBeOrdered[i - 1] == 0)
                    {
                        keepEliminateZeros = true;
                        listToBeOrdered[i - 1] = listToBeOrdered[i];
                        listToBeOrdered[i] = 0;
                    }
                }
            }
        }

        private void EliminateDuplicates(List<int> listToBeOrdered)
        {
            for (int i = 1; i < listToBeOrdered.Count; i++)
            {
                if (listToBeOrdered[i] != 0 && listToBeOrdered[i] == listToBeOrdered[i - 1])
                {
                    listToBeOrdered[i - 1] = listToBeOrdered[i - 1] * 2;
                    listToBeOrdered[i] = 0;
                    this.toAddToScore += listToBeOrdered[i - 1];
                }
            }
        }

        private bool TheMatrixesAreIdentical(int[,] fistMatrix, int[,] secondMatrix)
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (fistMatrix[i,j] != secondMatrix[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Gets the previous matrix that was created.
        /// </summary>
        /// <returns></returns>
        public void Undo()
        {
            if (this.Moves > 0)
            {
                MakeTheUndoMove();
            }
        }

        private void MakeTheUndoMove()
        {
            this.historyMatrix.RemoveAt(this.historyMatrix.Count - 1);
            GetLastMatrixFromHistory();

            this.historyScore.RemoveAt(historyScore.Count - 1);
            this.Score = this.historyScore[this.historyScore.Count - 1];

            this.Moves--;
        }

        #endregion Public methods

        #region Private methods



        private void InitializeGameData()
        {
            this.historyMatrix = new List<int[,]>();
            this.historyScore = new List<int>();
            this.CurrentMatrix = null;
            this.Score = 0;
            this.Moves = 0;
            this.toAddToScore = 0;
        }

        private void SetStartingMatrix()
        {
            this.CurrentMatrix = new int[size, size];
            for (int i = 0; i < 2; i++)
            {
                AddRandomNumberOnCurrentMatrix();
            }
        }

        private void AddRandomNumberOnCurrentMatrix()
        {
            Position pos = GetRandomEmptyPosition(this.CurrentMatrix);
            if (pos != null)
            {
                this.CurrentMatrix[pos.X, pos.Y] = GetRandomNewNumber();
            }
        }

        private int GetRandomNewNumber()
        {
            int newNumber = 2;
            double randomDouble = _random.NextDouble();
            if (randomDouble >= 0.9)
            {
                newNumber = 4;
            }
            return newNumber;
        }

        private Position GetRandomEmptyPosition(int[,] matrix)
        {
            List<Position> allAvailablePositions = GetAvailableSpaces(matrix);
            if (allAvailablePositions.Count > 0)
            {
                int randomIndex = _random.Next(0, allAvailablePositions.Count);
                return allAvailablePositions[randomIndex];
            }
            return null;
        }

        private List<Position> GetAvailableSpaces(int[,] matrix)
        {
            List<Position> result = new List<Position>();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        Position pos = new Position(i, j);
                        result.Add(pos);
                    }
                }
            }            

            return result;
        }


        #endregion Private methods
    }
}
