using MontyHall.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHall.Models
{
    public class Game
    {
        private const int DOORS_COUNT = 3;

        public Game()
        {
            Doors = Enumerable.Range(0, DOORS_COUNT).Select(x => new Door()).ToList();
            Doors.Random().ContainsPrize = true;
        }

        public List<Door> Doors { get; set; }

        public void SelectDoor()
        {
            Doors.Random().IsSelected = true;
        }

        public void OpenEmptyNotSelectedDoor()
        {
            List<Door> doorsForSelection = Doors.Where(d => !d.IsSelected && !d.ContainsPrize).ToList();
            doorsForSelection.Random().IsOpened = true;
        }

        public void ReselectDoor()
        {
            Door tmpDoor = Doors.First(x => x.IsSelected);
            Doors.First(d => !d.IsSelected && !d.IsOpened).IsSelected = true;
            tmpDoor.IsSelected = false;
        }

        public void OpenPrizeDoor()
        {
            Doors.First(d => d.ContainsPrize).IsOpened = true;
        }

        public bool IsCorrectGuess()
        {
            return Doors.Any(d => d.IsSelected && d.ContainsPrize);
        }
    }
}
