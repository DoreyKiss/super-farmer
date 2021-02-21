using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SuperFarmer.WPF.ViewModels
{
    public class WellComePageViewModell : AbstractBaseViewModel
    {
        private int _numberOfPlayers = 1;

        public int NumberOfPlayers
        {
            get { return _numberOfPlayers; }
            set
            {
                _numberOfPlayers = value;
                OnPropertyChanged(nameof(NumberOfPlayers));
            }
        }

        private ObservableCollection<int> _numberOfPossiblePlayers = new ObservableCollection<int>() { 1, 2, 3, 4, 5 ,6};
        public ObservableCollection<int> NumberOfPossiblePlayers
        {
            get { return _numberOfPossiblePlayers; }
            private set
            {
                _numberOfPossiblePlayers = value;
                OnPropertyChanged(nameof(NumberOfPossiblePlayers));
            }
        }
    }
}
