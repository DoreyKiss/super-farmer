using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using SuperFarmer.DataModell;

namespace SuperFarmer.WPF
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //todo miért csak az idexen megy a binding?
        private int _NumberOfPLayers = 1;

        public int NumberOfPlayers
        {
            get { return _NumberOfPLayers; }
            set
            {
                _NumberOfPLayers = value + 1;
                OnPropertyChanged(nameof(NumberOfPlayers));
            }
        }

        private AnimalEnum _BlueDice;

        public AnimalEnum BlueDice
        {
            get { return _BlueDice ; }
            set
            {
                _BlueDice = value;
                OnPropertyChanged(nameof(BlueDice));
            }
        }

        private AnimalEnum _RedDice;

        public AnimalEnum RedDice
        {
            get { return _RedDice ; }
            set
            {
                _RedDice = value;
                OnPropertyChanged(nameof(RedDice));
            }
        }

        private int _CurrentPLayerIndex;

        public int CurrentPLayerIndex
        {
            get { return _CurrentPLayerIndex; }
            set
            {
                _CurrentPLayerIndex = value;
                OnPropertyChanged(nameof(CurrentPLayerIndex));
            }
        }

        private int _NumberOfCurrentPlayersBunnies;


        public int NumberOfCurrentPlayersBunnies
        {
            get { return _NumberOfCurrentPlayersBunnies; }
            set
            {
                _NumberOfCurrentPlayersBunnies = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersBunnies));
            }
        }

        private int _NumberOfCurrentPlayersSheeps;
        public int NumberOfCurrentPlayersSheeps
        {
            get { return _NumberOfCurrentPlayersSheeps; }
            set
            {
                _NumberOfCurrentPlayersSheeps = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersSheeps));
            }
        }

        private int _NumberOfCurrentPlayersPigs;
        public int NumberOfCurrentPlayersPigs
        {
            get { return _NumberOfCurrentPlayersPigs; }
            set
            {
                _NumberOfCurrentPlayersPigs = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersPigs));
            }
        }

        private int _NumberOfCurrentPlayersCows;
        public int NumberOfCurrentPlayersCows
        {
            get { return _NumberOfCurrentPlayersCows; }
            set
            {
                _NumberOfCurrentPlayersCows = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersCows));
            }
        }

        private int _NumberOfCurrentPlayersHorses;
        public int NumberOfCurrentPlayersHorses
        {
            get { return _NumberOfCurrentPlayersHorses; }
            set
            {
                _NumberOfCurrentPlayersHorses = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersHorses));
            }
        }

        private int _NumberOfCurrentPlayersSmallDogs;
        public int NumberOfCurrentPlayersSmallDogs
        {
            get { return _NumberOfCurrentPlayersSmallDogs; }
            set
            {
                _NumberOfCurrentPlayersSmallDogs = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersSmallDogs));
            }
        }

        private int _NumberOfCurrentPlayersBigDogs;
        public int NumberOfCurrentPlayersBigDogs
        {
            get { return _NumberOfCurrentPlayersBigDogs; }
            set
            {
                _NumberOfCurrentPlayersBigDogs = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersBigDogs));
            }
        }
    }
}
