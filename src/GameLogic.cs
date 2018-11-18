﻿using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Models;
using System.Threading.Tasks;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace thegame
{
    public class GameLogic
    {
        private readonly int rows = 4;
        private readonly int columns = 4;
        public int[,] Field { get; private set; }
        public int Score { get; private set; } = 0;
        private static readonly Random R = new Random();

        public GameLogic()
        {
            Field = new int[rows, columns];
            GenerateTile();
            GenerateTile();
        }

        public GameLogic(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            Field = new int[rows, columns];
            GenerateTile();
            GenerateTile();
        }

        int[,] Copy()
        {
            int[,] f = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    f[i, j] = Field[i, j];
                }
            }

            return f;
        }

        bool isChanged(int[,] f)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (f[i, j] != Field[i, j]) return true;
                }
            }

            return false;
        }

        public void Move(Direction dir)
        {
            var f = Copy();
            switch (dir)
            {
                case Direction.Up:
                    MergeUp();
                    MoveUp();
                    break;
                case Direction.Down:
                    MergeDown();
                    MoveDown();
                    break;
                case Direction.Right:
                    MergeRight();
                    MoveRight();
                    break;
                case Direction.Left:
                    MergeLeft();
                    MoveLeft();
                    break;
            }
            if (isChanged(f))
                GenerateTile();
        }

        void MergeUp()
        {
            int lastValue = 0;
            var lastPos = (I: 0, J: 0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (Field[i, j] == 0) continue;
                    if (Field[i, j] == lastValue)
                    {
                        Field[lastPos.I, lastPos.J] *= 2;
                        Score += Field[lastPos.I, lastPos.J];
                        Field[i, j] = 0;
                        lastValue = 0;
                        continue;
                    }
                    lastValue = Field[i, j];
                    lastPos = (i, j);
                }

                lastValue = 0;
            }
        }

        void MergeDown()
        {
            int lastValue = 0;
            var lastPos = (I: 0, J: 0);
            for (int i = 0; i < rows; i++)
            {
                for (int j = columns - 1; j > -1; j--)
                {
                    if (Field[i, j] == 0) continue;
                    if (Field[i, j] == lastValue)
                    {
                        Field[lastPos.I, lastPos.J] *= 2;
                        Score += Field[lastPos.I, lastPos.J];
                        Field[i, j] = 0;
                        lastValue = 0;
                        continue;
                    }
                    lastValue = Field[i, j];
                    lastPos = (i, j);
                }

                lastValue = 0;
            }
        }

        void MergeLeft()
        {
            int lastValue = 0;
            var lastPos = (I: 0, J: 0);
            for (int j = 0; j < columns; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (Field[i, j] == 0) continue;
                    if (Field[i, j] == lastValue)
                    {
                        Field[lastPos.I, lastPos.J] *= 2;
                        Score += Field[lastPos.I, lastPos.J];
                        Field[i, j] = 0;
                        lastValue = 0;
                        continue;
                    }
                    lastValue = Field[i, j];
                    lastPos = (i, j);
                }

                lastValue = 0;
            }
        }

        void MergeRight()
        {
            int lastValue = 0;
            var lastPos = (I: 0, J: 0);
            for (int j = 0; j < columns; j++)
            {
                for (int i = rows - 1; i > -1; i--)
                {
                    if (Field[i, j] == 0) continue;
                    if (Field[i, j] == lastValue)
                    {
                        Field[lastPos.I, lastPos.J] *= 2;
                        Score += Field[lastPos.I, lastPos.J];
                        Field[i, j] = 0;
                        lastValue = 0;
                        continue;
                    }
                    lastValue = Field[i, j];
                    lastPos = (i, j);
                }

                lastValue = 0;
            }
        }

        void MoveUp()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (Field[i, j] == 0)
                    {
                        for (int k = j; k < columns; k++)
                        {
                            if (Field[i, k] != 0)
                            {
                                Field[i, j] = Field[i, k];
                                Field[i, k] = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        void MoveDown()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = columns - 1; j > -1; j--)
                {
                    if (Field[i, j] == 0)
                    {
                        for (int k = j; k > -1; k--)
                        {
                            if (Field[i, k] != 0)
                            {
                                Field[i, j] = Field[i, k];
                                Field[i, k] = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        void MoveLeft()
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (Field[j, i] == 0)
                    {
                        for (int k = j; k < rows; k++)
                        {
                            if (Field[k, i] != 0)
                            {
                                Field[j, i] = Field[k, i];
                                Field[k, i] = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        void MoveRight()
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = rows - 1; j > -1; j--)
                {
                    if (Field[j, i] == 0)
                    {
                        for (int k = j; k > -1; k--)
                        {
                            if (Field[k, i] != 0)
                            {
                                Field[j, i] = Field[k, i];
                                Field[k, i] = 0;
                                break;
                            }
                        }
                    }
                }
            }
        }

        void GenerateTile()
        {
            var emptys = GetEmptyTiles().ToArray();
            if (emptys.Length == 0) return;
            var selectedEmpty = emptys[R.Next() % emptys.Length];
            Field[selectedEmpty.Item1, selectedEmpty.Item2] = GetNewTileValue();
        }

        int GetNewTileValue()
        {
            return R.Next() % 5 == 0 ? 4 : 2;
        }

        IEnumerable<(int, int)> GetEmptyTiles()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (Field[i, j] == 0)
                    {
                        yield return (i, j);
                    }
                }
            }
        }
    }
}
