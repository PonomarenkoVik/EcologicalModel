using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcologicalModel
{
    class Ocean:ICloneable
    {
        
        
        public Ocean(byte numCols = 70, byte numRows = 25, ushort numPreys = 150, ushort numPredators = 20, ushort numObstacles = 75)
        {
            NumCols = numCols <= MaxCols ? numCols : MaxCols;
            NumRows = numRows <= MaxRows ? numRows : MaxRows;
            NumPreys = numPreys;
            NumPredators = numPredators;
            NumObstacles = numObstacles;
            _cells = new Cell[NumCols, NumRows];
            NumBornPrey = 0;
            NumBornPredators = 0;
            NumEaten = 0;
        }

#region Properties
        public byte NumCols { get; private set; }
        public byte NumRows { get; private set; }
        public int NumPreys { get; protected internal set; }
        public int NumPredators { get; protected internal set; }
        public int NumObstacles { get; private set; }
        public int NumEaten { get; protected internal set; }
        public int NumBornPrey { get; protected internal set; }
        public int NumBornPredators { get; protected internal set; }

        public int Size
        {
            get
            {
                return NumCols*NumRows;
            }
        }
#endregion

#region Indexer
        public Cell this[Coordinate source]
        {
            get
            {
                Cell result = null;

                if (source.X < NumCols && source.Y < NumRows && _cells[source.X, source.Y] != null)
                {
                    result = (Cell)_cells[source.X, source.Y].Clone();
                }
                return result;
            }
            set
            {
                if (source.X < NumCols && source.Y < NumRows)
                {
                    if (value != null)
                    {
                        _cells[source.X, source.Y] = (Cell)value.Clone(); 
                    }
                    else
                    {
                        _cells[source.X, source.Y] = null;
                    }
                    
                }
            }
        }
#endregion


#region Methods
        public object Clone()
        {
            Ocean clone = (Ocean)MemberwiseClone();
            Cell [,] cellClone = new Cell[NumCols, NumRows];
            for (int y = 0; y < NumRows; y++)
            {
                for (int x = 0; x < NumCols; x++)
                {
                    if (_cells[x, y] != null)
                    {
                        cellClone[x, y] = (Cell)_cells[x, y].Clone(); 
                    }                   
                }
            }
            return clone;
        }

        public void InitCells()
        {
            AddPrey();
            AddPredators();
            AddObstacle();
        }

        public void Process()
        {           
            foreach (var cell in _cells)
            {
                var processable = cell as IProcessable;
                if (processable != null && processable.Processed == false)
                {
                    processable.Process();
                }
            }

            foreach (var cell in _cells)
            {
                var processable = cell as IProcessable;
                if (processable != null)
                {
                    processable.Processed = false;
                }
            }
        }

        private void AddPrey()
        {
            for (int i = 0; i < NumPreys; i++)
            {
                 while (true) 
                {
                    byte x = (byte)_random.Next(0, NumCols);
                    byte y = (byte)_random.Next(0, NumRows);
                    if (_cells[x,y] == null)
                    {
                        _cells[x, y] = new Prey(new Coordinate(x, y));   
                    }
                    else
                    {
                        continue;
                    }
                    break;
                }
            }
        }

        private void AddPredators()
        {
            for (int i = 0; i < NumPredators; i++)
            {
                while (true)
                {
                    byte x = (byte)_random.Next(0, NumCols);
                    byte y = (byte)_random.Next(0, NumRows);
                    if (_cells[x, y] == null)
                    {
                        _cells[x, y] = new Predator(new Coordinate(x, y));
                    }
                    else
                    {
                        continue;
                    }
                    break;
                }
            }
        }

        private void AddObstacle()
        {
            for (int i = 0; i < NumObstacles; i++)
            {
                while (true)
                {
                    byte x = (byte)_random.Next(0, NumCols);
                    byte y = (byte)_random.Next(0, NumRows);
                    if (_cells[x, y] == null)
                    {
                        _cells[x, y] = new Obstacle(new Coordinate(x, y));
                    }
                    else
                    {
                        continue;
                    }
                    break;
                }
            }
        }
#endregion
        private static byte MaxCols = 70;
        private static byte MaxRows = 25;
        private readonly Random _random = new Random();
        private readonly Cell[,] _cells;
    }
}
