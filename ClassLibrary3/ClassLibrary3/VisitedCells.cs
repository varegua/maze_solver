using ClassLibrary3.mazeSolverService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver.Client.Core
{
    class VisitedCell
    {
        public Position position { get; set; }
        public Direction direction { get; set; }
        public CellType cellType { get; set; }
        public bool disabled { get; set; }
        public bool alreadySee { get; set; }

        public VisitedCell(Position pos, Direction dir, CellType type, bool disabled)
        {
            this.position = pos;
            this.direction = dir;
            this.cellType = type;
            this.disabled = disabled;
            this.alreadySee = false;
        }
    }
}
