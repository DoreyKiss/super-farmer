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
    }
}
