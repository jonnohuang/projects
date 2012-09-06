/* 
    Copyright (c) 2011 Microsoft Corporation.  All rights reserved.
    Use of this sample source code is subject to the terms of the Microsoft license 
    agreement under which you licensed this sample source code and is provided AS-IS.
    If you did not accept the terms of the license agreement, you are not authorized 
    to use this sample source code.  For the terms of the license, please see the 
    license agreement between you and Microsoft.
  
    To see all Code Samples for Windows Phone, visit http://go.microsoft.com/fwlink/?LinkID=219604 
  
*/
using System.ComponentModel;

namespace locationWeatherForecastCS
{
    public class City : INotifyPropertyChanged
    {        
        private string actionName;
        private string latitude;
        private string longitude;

        public string ActionName
        {
            get
            {
                return actionName;
            }
            set
            {
                if (value != actionName)
                {
                    actionName = value;
                    NotifyPropertyChanged("ActionName");
                }
            }
        }

        public string Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                if (value != latitude)
                {
                    latitude = value;
                    NotifyPropertyChanged("Latitude");
                }
            }
        }

        public string Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                if (value != longitude)
                {
                    longitude = value;
                    NotifyPropertyChanged("Longitude");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Constructor with full city information
        /// </summary> 

        public City(string actionName, string latitude, string longitude)
        {
            ActionName = actionName;
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Raise the PropertyChanged event and pass along the property that changed
        /// </summary>
        private void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


    }
}
