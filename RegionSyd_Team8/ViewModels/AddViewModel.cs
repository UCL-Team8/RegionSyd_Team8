using RegionSyd_Team8.Models;
using RegionSyd_Team8.MVVM;
using RegionSyd_Team8.Views;

namespace RegionSyd_Team8.ViewModels
{
    class AddViewModel : ViewModelBase
    {
        //Propertys Assignment and Description
        public Assignment NewAssignment { get; set; }
        public string Description { get; set; }

        // PickUpTimeDate property
        //With Start value
        private DateTime _pickUpTimeDate = DateTime.Now;
        public DateTime PickUpTimeDate
        {
            get { return _pickUpTimeDate; }
            set
            {
                _pickUpTimeDate = value;
                UpdateCombinedPickUpTime();
            }
        }

        // PickUpTimeString property
        //With Start value
        private string _pickUpTimeString = DateTime.Now.ToString("HH:mm");
        public string PickUpTimeString
        {
            get { return _pickUpTimeString; }
            set
            {
                _pickUpTimeString = value;
                UpdateCombinedPickUpTime();
            }
        }

        // CombinedPickUpTime property

        public DateTime CombinedPickUpTime { get; private set; }

        // DropOffTimeDate property
        //With Start value 
        private DateTime _dropOffTimeDate = DateTime.Now;
        public DateTime DropOffTimeDate
        {
            get { return _dropOffTimeDate; }
            set
            {
                _dropOffTimeDate = value;
                UpdateCombinedDropOffTime();
            }
        }

        // DropOffTimeString property
        //With Start value
        private string _dropOffTimeString = DateTime.Now.ToString("HH:mm");
        public string DropOffTimeString
        {
            get { return _dropOffTimeString; }
            set
            {
                _dropOffTimeString = value;
                UpdateCombinedDropOffTime();
            }
        }

        // CombinedPickUpTime property
        public DateTime CombinedDropOffTime { get; private set; }

        //Other properties

        public string FromAddress { get; set; }
        public string ToAddress { get; set; }

        public RelayCommand AddTaskCommand => new RelayCommand(execute => AddNewTaskCommand(execute));

        // Help Method to update the combined pick-up time
        //class internal method
        private void UpdateCombinedPickUpTime()
        {

            //forsøger at konvertere (parse) PickUpTimeString (som forventes at være en tidsstreng, f.eks. "14:30")
            //til et TimeSpan-objekt, der repræsenterer tidsintervallet fra midnat til den angivne tid.
            if (TimeSpan.TryParse(PickUpTimeString, out TimeSpan time))
            {

                //PickUpTime.Date returnerer datoen fra PickUpTime, men nulstiller tiden til 00:00:00 (midnat). Det betyder, at du kun får datoen uden tidskomponenten.
                //2024-03-01 00:00:00

                //time er det TimeSpan-objekt, som vi fik fra PickUpTimeString. Det repræsenterer det tidspunkt, som er indtastet af brugeren, f.eks. "14:30".
                //Når vi lægger PickUpTime.Date og time sammen, kombinerer vi datoen fra PickUpTime med tiden fra PickUpTimeString. Dette opdaterer CombinedPickUpTime med
                //en komplet DateTime, som indeholder både dato og tid.

                CombinedPickUpTime = PickUpTimeDate.Date + time;
            }
        }

        //  Help Method to update the combined drop-off time
        //class internal method
        private void UpdateCombinedDropOffTime()
        {
            if (TimeSpan.TryParse(DropOffTimeString, out TimeSpan time))
            {
                CombinedDropOffTime = DropOffTimeDate.Date + time;
            }
        }

        private void AddNewTaskCommand(object parameter)
        {
            // Use CombinedPickUpTime and CombinedDropOffTime for the assignment
            NewAssignment = new Assignment(Description, CombinedPickUpTime, CombinedDropOffTime, FromAddress, ToAddress, false, false);

            if (parameter is AddWindow addWindow)
            {
                addWindow.DialogResult = true;
                addWindow.Close();
            }
        }
    }





}

