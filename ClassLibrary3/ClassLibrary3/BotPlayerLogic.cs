using ClassLibrary3.mazeSolverService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class BotPlayerLogic
    {
        private List<PossibleDirectionCell> oldMoves;

        public BotPlayerLogic(Player player)
        {
            this.oldMoves = new List<PossibleDirectionCell>();
            this.oldMoves.Add(new PossibleDirectionCell(player.CurrentPosition, Direction.Down, CellType.Start, false));
        }


        Predicate<PossibleDirectionCell> dirDown = (PossibleDirectionCell cell) => { return cell.direction == Direction.Down; };
        Predicate<PossibleDirectionCell> dirRight = (PossibleDirectionCell cell) => { return cell.direction == Direction.Right; };
        Predicate<PossibleDirectionCell> dirLeft = (PossibleDirectionCell cell) => { return cell.direction == Direction.Left; };
        Predicate<PossibleDirectionCell> dirUp = (PossibleDirectionCell cell) => { return cell.direction == Direction.Up; };



        public Direction SelectBestDirection(Player player)
        {
            List<PossibleDirectionCell> listPossibleDir = PossibleDirections(player.VisibleCells, player);
            if (listPossibleDir.Count() < 2)
            {

                this.oldMoves.Last<PossibleDirectionCell>().disabled = true;
                
                this.oldMoves.Add(listPossibleDir.ElementAt(0));
                return listPossibleDir.ElementAt(0).direction;
            }
            else
            {
                PossibleDirectionCell cell = selectBestPossibleDirectionCellWithoutBack(listPossibleDir);
                this.oldMoves.Add(cell);
                return cell.direction;
            }
        }

        private PossibleDirectionCell selectBestPossibleDirectionCellWithoutBack(List<PossibleDirectionCell> list)
        {
            PossibleDirectionCell cell;
            switch (oldMoves.Last<PossibleDirectionCell>().direction)
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

        private PossibleDirectionCell tryPredicate(List<PossibleDirectionCell> list, Predicate<PossibleDirectionCell> predicate1, Predicate<PossibleDirectionCell> predicate2, Predicate<PossibleDirectionCell> predicate3)
        {
            List<PossibleDirectionCell> predicteListCell = new List<PossibleDirectionCell>();
            PossibleDirectionCell  cell = list.Find(predicate1);
            if (cell != null)
                predicteListCell.Add(cell);

             cell = list.Find(predicate2);
            if (cell != null)
                predicteListCell.Add(cell);

            cell = list.Find(predicate3);
            if (cell != null)
                predicteListCell.Add(cell);

            PossibleDirectionCell finalCell;
            for(int i = 0; i < predicteListCell.Count(); i++)
            {
                finalCell = predicteListCell.ElementAt<PossibleDirectionCell>(i);
                if (finalCell.alreadySee == false)
                    return finalCell;
            }
            finalCell = predicteListCell.First<PossibleDirectionCell>();
            return finalCell;

        }

        public List<PossibleDirectionCell> PossibleDirections(Cell[] visibleCells, Player player)
        {
            List<PossibleDirectionCell> listPossibleDirectionCell = new List<PossibleDirectionCell>();
            foreach(Cell cell in visibleCells)
            {
                if (!cell.CellType.Equals(CellType.Wall) && !(cell.Position.X == player.CurrentPosition.X && cell.Position.Y == player.CurrentPosition.Y))
                {
                    listPossibleDirectionCell = GetPossibleDirection(listPossibleDirectionCell, cell, player.CurrentPosition);
                }
            }
            listPossibleDirectionCell = removeDisabledCells(listPossibleDirectionCell);

            return listPossibleDirectionCell;
        }

        private List<PossibleDirectionCell> GetPossibleDirection(List<PossibleDirectionCell> list,Cell cell, Position playerPosition)
        {
            Position position = cell.Position;
            //droite
            if (position.X > playerPosition.X && position.Y == playerPosition.Y)
            {
                list.Add(new PossibleDirectionCell(cell.Position, Direction.Right, cell.CellType, false));       
             }
            //gauche
            else if (position.X < playerPosition.X && position.Y == playerPosition.Y)
            {
                list.Add(new PossibleDirectionCell(cell.Position, Direction.Left, cell.CellType, false));
            }
            //bas
            else if (position.Y > playerPosition.Y && position.X == playerPosition.X)
            {
                list.Add(new PossibleDirectionCell(cell.Position, Direction.Down, cell.CellType, false));
            }
            //haut
            else if(position.Y < playerPosition.Y && position.X == playerPosition.X)
            {
                list.Add(new PossibleDirectionCell(cell.Position, Direction.Up, cell.CellType, false));
            }
            return list;
        }

        private List<PossibleDirectionCell> removeDisabledCells(List<PossibleDirectionCell> listPossibleDirectionCell)
        {
            List<PossibleDirectionCell> listFinalPossibleDirectionCell = new List<PossibleDirectionCell>();
            foreach(PossibleDirectionCell cell in listPossibleDirectionCell)
            {
                listFinalPossibleDirectionCell.Add(cell);
            }
            foreach(PossibleDirectionCell cell in listPossibleDirectionCell)
            {
                foreach(PossibleDirectionCell oldCell in this.oldMoves)
                {
                    if(cell.position.X == oldCell.position.X  && cell.position.Y == oldCell.position.Y)
                    {
                        if (oldCell.disabled == true)
                            listFinalPossibleDirectionCell.Remove(cell);
                        else
                            listFinalPossibleDirectionCell.ElementAt<PossibleDirectionCell>(listFinalPossibleDirectionCell.IndexOf(cell)).alreadySee = true;
                    }
                }
            }
            return listFinalPossibleDirectionCell;
        }
    }
}
