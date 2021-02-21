using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using SuperFarmer.DataModell;
using SuperFarmer.PlayArea;
using SuperFarmer.WPF.Resources;
using SuperFarmer.WPF.ViewModels;

namespace SuperFarmer.WPF
{
    public class MainViewModel : AbstractBaseViewModel
    {
        private int _numberOfPlayersPlaying;

        public int NumberOfPlayersPlaying
        {
            get { return _numberOfPlayersPlaying; }
            set
            {
                _numberOfPlayersPlaying = value;
                OnPropertyChanged(nameof(NumberOfPlayersPlaying));
            }
        }

        private StateEnum _gameStateEnum;

        public StateEnum GameStateEnum
        {
            get { return _gameStateEnum; }
            set
            {
                _gameStateEnum = value;
                OnPropertyChanged(nameof(GameStateEnum));
            }
        }

        private AnimalEnum _blueDice;

        public AnimalEnum BlueDice
        {
            get { return _blueDice; }
            set
            {
                _blueDice = value;
                OnPropertyChanged(nameof(BlueDice));
            }
        }

        private AnimalEnum _redDice;

        public AnimalEnum RedDice
        {
            get { return _redDice; }
            set
            {
                _redDice = value;
                OnPropertyChanged(nameof(RedDice));
            }
        }

        private int _currentPlayerIndex;

        public int CurrentPlayerIndex
        {
            get { return _currentPlayerIndex; }
            set
            {
                _currentPlayerIndex = value;
                OnPropertyChanged(nameof(CurrentPlayerIndex));
                OnPropertyChanged(nameof(CurrentPlayerNumber));
            }
        }

        public int CurrentPlayerNumber
        {
            get { return _currentPlayerIndex + 1; }
        }

        private int _numberOfCurrentPlayersBunnies;


        public int NumberOfCurrentPlayersBunnies
        {
            get { return _numberOfCurrentPlayersBunnies; }
            set
            {
                _numberOfCurrentPlayersBunnies = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersBunnies));
            }
        }

        private int _numberOfCurrentPlayersSheeps;
        public int NumberOfCurrentPlayersSheeps
        {
            get { return _numberOfCurrentPlayersSheeps; }
            set
            {
                _numberOfCurrentPlayersSheeps = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersSheeps));
            }
        }

        private int _numberOfCurrentPlayersPigs;
        public int NumberOfCurrentPlayersPigs
        {
            get { return _numberOfCurrentPlayersPigs; }
            set
            {
                _numberOfCurrentPlayersPigs = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersPigs));
            }
        }

        private int _numberOfCurrentPlayersCows;
        public int NumberOfCurrentPlayersCows
        {
            get { return _numberOfCurrentPlayersCows; }
            set
            {
                _numberOfCurrentPlayersCows = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersCows));
            }
        }

        private int _numberOfCurrentPlayersHorses;
        public int NumberOfCurrentPlayersHorses
        {
            get { return _numberOfCurrentPlayersHorses; }
            set
            {
                _numberOfCurrentPlayersHorses = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersHorses));
            }
        }

        private int _numberOfCurrentPlayersSmallDogs;
        public int NumberOfCurrentPlayersSmallDogs
        {
            get { return _numberOfCurrentPlayersSmallDogs; }
            set
            {
                _numberOfCurrentPlayersSmallDogs = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersSmallDogs));
            }
        }

        private int _numberOfCurrentPlayersBigDogs;
        public int NumberOfCurrentPlayersBigDogs
        {
            get { return _numberOfCurrentPlayersBigDogs; }
            set
            {
                _numberOfCurrentPlayersBigDogs = value;
                OnPropertyChanged(nameof(NumberOfCurrentPlayersBigDogs));
            }
        }

        private ObservableCollection<string> _possibleChanges;
        public ObservableCollection<string> PossibleChanges
        {
            get { return _possibleChanges; }
            set
            {
                _possibleChanges = value;
                OnPropertyChanged(nameof(PossibleChanges));
            }
        }

        private string _selectedChange;
        public string SelectedChange
        {
            get
            {
                return _selectedChange ?? StringResources.NOCHANGEREQUIRED;
            }
            set
            {
                if (SelectedChange == value)
                    return;

                _selectedChange = value;
                OnPropertyChanged(nameof(SelectedChange));
            }
        }
    }
}
