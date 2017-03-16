using MazeSolver.Client.Core.mazeSolverService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeSolver.Client.Core
{
    public class BotPlayerLogics
    {
        private List<VisitedCell> visitedCells;

        public BotPlayerLogics(Player player)
        {
            this.visitedCells = new List<VisitedCell>();
            this.visitedCells.Add(new VisitedCell(player.CurrentPosition, Direction.Down, CellType.Start, false));
        }

        Predicate<VisitedCell> dirDown = (VisitedCell cell) => { return cell.direction == Direction.Down; };
        Predicate<VisitedCell> dirRight = (VisitedCell cell) => { return cell.direction == Direction.Right; };
        Predicate<VisitedCell> dirLeft = (VisitedCell cell) => { return cell.direction == Direction.Left; };
        Predicate<VisitedCell> dirUp = (VisitedCell cell) => { return cell.direction == Direction.Up; };

        public Direction FindBestDirection(Player player)
        {
            List<VisitedCell> neverVisitedCells = PossibleDirections(player.VisibleCells, player);
            if (neverVisitedCells.Count() < 2)
            {
                this.visitedCells.Last<VisitedCell>().disabled = true;
                this.visitedCells.Add(neverVisitedCells.ElementAt(0));
                return neverVisitedCells.ElementAt(0).direction;
            }
            else
            {
                VisitedCell cell = selectBestPossibleDirectionCellWithoutBack(neverVisitedCells);
                this.visitedCells.Add(cell);
                return cell.direction;
            }
        }

        private VisitedCell selectBestPossibleDirectionCellWithoutBack(List<VisitedCell> list)
        {
            VisitedCell cell;
            switch (visitedCells.Last<VisitedCell>().direction)
            {
                case Direction.Down:
                    cell = tryPredicate(list, dirDown, dirRight, dirLeft);
                    break;
                case Direction.Right:
                    cell = tryPredicate(list, dirDown, dirRight, dirUp);
                    break;
                case Direction.Left:
                    cell = tryPredicate(list, dirDown, dirLeft, dirUp);
                    break;
                default:
                    cell = tryPredicate(list, dirRight, dirLeft, dirUp);
                    break;
            }
            return cell;
        }

        private VisitedCell tryPredicate(List<VisitedCell> list, Predicate<VisitedCell> predicate1, Predicate<VisitedCell> predicate2, Predicate<VisitedCell> predicate3)
        {
            List<VisitedCell> predicatedCellList = new List<VisitedCell>();
            VisitedCell cell = list.Find(predicate1);
            if (cell != null)
                predicatedCellList.Add(cell);

             cell = list.Find(predicate2);
            if (cell != null)
                predicatedCellList.Add(cell);

            cell = list.Find(predicate3);
            if (cell != null)
                predicatedCellList.Add(cell);

            VisitedCell finalCell;
            for(int i = 0; i < predicatedCellList.Count(); i++)
            {
                finalCell = predicatedCellList.ElementAt<VisitedCell>(i);
                if (finalCell.alreadySee == false)
                    return finalCell;
            }
            finalCell = predicatedCellList.First<VisitedCell>();
            return finalCell;
        }

        private List<VisitedCell> PossibleDirections(Cell[] visibleCells, Player player)
        {
            List<VisitedCell> listPossibleDirectionCell = new List<VisitedCell>();
            foreach(Cell cell in visibleCells)
            {
                if (!cell.CellType.Equals(CellType.Wall) && !(cell.Position.X == player.CurrentPosition.X && cell.Position.Y == player.CurrentPosition.Y))
                {
                    listPossibleDirectionCell = GetPossibleDirection(listPossibleDirectionCell, cell, player.CurrentPosition);
                }
            }
            listPossibleDirectionCell = RemoveDisabledCells(listPossibleDirectionCell);

            return listPossibleDirectionCell;
        }

        private List<VisitedCell> GetPossibleDirection(List<VisitedCell> list,Cell cell, Position playerPosition)
        {
            Position position = cell.Position;
            //droite
            if (position.X > playerPosition.X && position.Y == playerPosition.Y)
            {
                list.Add(new VisitedCell(cell.Position, Direction.Right, cell.CellType, false));       
             }
            //gauche
            else if (position.X < playerPosition.X && position.Y == playerPosition.Y)
            {
                list.Add(new VisitedCell(cell.Position, Direction.Left, cell.CellType, false));
            }
            //bas
            else if (position.Y > playerPosition.Y && position.X == playerPosition.X)
            {
                list.Add(new VisitedCell(cell.Position, Direction.Down, cell.CellType, false));
            }
            //haut
            else if(position.Y < playerPosition.Y && position.X == playerPosition.X)
            {
                list.Add(new VisitedCell(cell.Position, Direction.Up, cell.CellType, false));
            }
            return list;
        }

        private List<VisitedCell> RemoveDisabledCells(List<VisitedCell> listPossibleDirectionCell)
        {
            List<VisitedCell> listFinalPossibleDirectionCell = new List<VisitedCell>();
            foreach(VisitedCell cell in listPossibleDirectionCell)
            {
                listFinalPossibleDirectionCell.Add(cell);
            }
            foreach(VisitedCell cell in listPossibleDirectionCell)
            {
                foreach(VisitedCell oldCell in this.visitedCells)
                {
                    if(cell.position.X == oldCell.position.X  && cell.position.Y == oldCell.position.Y)
                    {
                        if (oldCell.disabled == true)
                            listFinalPossibleDirectionCell.Remove(cell);
                        else
                            listFinalPossibleDirectionCell.ElementAt<VisitedCell>(listFinalPossibleDirectionCell.IndexOf(cell)).alreadySee = true;
                    }
                }
            }
            return listFinalPossibleDirectionCell;
        }
    }
}
